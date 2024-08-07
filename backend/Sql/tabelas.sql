CREATE TABLE financas.users (
    id SERIAL PRIMARY KEY,
    name TEXT NOT NULL,
    email TEXT NOT NULL,
    password TEXT NOT NULL,
    balance DECIMAL(18, 2) NOT NULL,
    created_at TIMESTAMP NOT NULL,
    updated_at TIMESTAMP NOT NULL 
);

CREATE TABLE financas.receives (
    id SERIAL PRIMARY KEY,
    description TEXT NOT NULL,
    value DECIMAL(18, 2) NOT NULL,
    type TEXT NOT NULL,
    date TIMESTAMP NOT NULL,
    created_at TIMESTAMP NOT NULL,
    updated_at TIMESTAMP NOT NULL,
    user_id INTEGER NOT NULL,
    CONSTRAINT receives_user_id_fkey FOREIGN KEY (user_id) REFERENCES financas.users (id) ON DELETE RESTRICT ON UPDATE CASCADE
);