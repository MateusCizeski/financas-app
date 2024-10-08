using financas_app.Data;
using financas_app.DTOs;
using financas_app.Models;
using FinanceAppBackend.Data;
using FinanceAppBackend.DTOs;
using FinanceAppBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace FinanceAppBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TransactionsController : ControllerBase
    {
        private readonly FinanceAppContext _context;

        public TransactionsController(FinanceAppContext context)
        {
            _context = context;
        }

        // POST: api/Transactions
        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] TransactionCreateDTO transactionDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!DateTime.TryParseExact(transactionDTO.Date, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                return BadRequest("Data inválida. Utilize o formato d/m/Y.");

            var userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);

            var transaction = new Transaction
            {
                Description = transactionDTO.Description,
                Amount = transactionDTO.Amount,
                Date = parsedDate,
                Type = (TransactionType)transactionDTO.TransactionType,
                UserId = userId,
                ///*CategoryId*/ = transactionDTO.CategoryId
            };

            _context.Transaction.Add(transaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTransactionById), new { id = transaction.Id }, new TransactionReadDTO
            {
                Id = transaction.Id,
                Description = transaction.Description,
                Amount = transaction.Amount,
                Date = transaction.Date.ToString("d/M/yyyy"),
                TransactionType = transaction.Type.ToString(),
                //Category = transaction.Category?.Name // Se implementar categorias
            });
        }

        // GET: api/Transactions/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionById(int id)
        {
            var userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);

            var transaction = await _context.Transaction
                //.Include(t => t.Category) // Se implementar categorias
                .Where(t => t.Id == id && t.UserId == userId)
                .FirstOrDefaultAsync();

            if (transaction == null)
                return NotFound();

            var transactionDTO = new TransactionReadDTO
            {
                Id = transaction.Id,
                Description = transaction.Description,
                Amount = transaction.Amount,
                Date = transaction.Date.ToString("d/M/yyyy"),
                TransactionType = transaction.Type.ToString(),
                //Category = transaction.Category?.Name // Se implementar categorias
            };

            return Ok(transactionDTO);
        }

        // GET: api/Transactions
        [HttpGet]
        public async Task<IActionResult> GetTransactions([FromQuery] string? startDate, [FromQuery] string? endDate, [FromQuery] TransactionTypeDTO? type)
        {
            var userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);

            var query = _context.Transaction
                //.Include(t => t.Category) // Se implementar categorias
                .Where(t => t.UserId == userId);

            if (!string.IsNullOrEmpty(startDate))
            {
                if (!DateTime.TryParseExact(startDate, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedStartDate))
                    return BadRequest("StartDate inválida. Utilize o formato d/m/Y.");

                query = query.Where(t => t.Date >= parsedStartDate);
            }

            if (!string.IsNullOrEmpty(endDate))
            {
                if (!DateTime.TryParseExact(endDate, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedEndDate))
                    return BadRequest("EndDate inválida. Utilize o formato d/m/Y.");

                query = query.Where(t => t.Date <= parsedEndDate);
            }

            if (type.HasValue)
            {
                query = query.Where(t => t.Type == (TransactionType)type.Value);
            }

            var transactions = await query.OrderByDescending(t => t.Date).ToListAsync();

            var transactionDTOs = transactions.Select(t => new TransactionReadDTO
            {
                Id = t.Id,
                Description = t.Description,
                Amount = t.Amount,
                Date = t.Date.ToString("d/M/yyyy"),
                TransactionType = t.Type.ToString(),
                //Category = t.Category?.Name // Se implementar categorias
            });

            return Ok(transactionDTOs);
        }

        // PUT: api/Transactions/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction(int id, [FromBody] TransactionUpdateDTO transactionDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!DateTime.TryParseExact(transactionDTO.Date, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                return BadRequest("Data inválida. Utilize o formato d/m/Y.");

            var userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);

            var transaction = await _context.Transaction.FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);

            if (transaction == null)
                return NotFound();

            transaction.Description = transactionDTO.Description;
            transaction.Amount = transactionDTO.Amount;
            transaction.Date = parsedDate;
            transaction.Type = (TransactionType)transactionDTO.TransactionType;
            //transaction.CategoryId = transactionDTO.CategoryId;

            _context.Transaction.Update(transaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Transactions/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);

            var transaction = await _context.Transaction.FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);

            if (transaction == null)
                return NotFound();

            _context.Transaction.Remove(transaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
