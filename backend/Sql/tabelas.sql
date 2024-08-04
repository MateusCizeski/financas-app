CREATE TABLE financas.users (
    id TEXT NOT NULL PRIMARY KEY,
    name TEXT NOT NULL,
    email TEXT NOT NULL,
    password TEXT NOT NULL,
    balance REAL NOT NULL,
    created_at DATE DEFAULT CURRENT_TIMESTAMP,
    updated_at DATE DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE financas.receives (
    id TEXT NOT NULL PRIMARY KEY,
    description TEXT NOT NULL,
    value REAL NOT NULL,
    type TEXT NOT NULL,
    date TEXT NOT NULL,
    created_at DATE DEFAULT CURRENT_TIMESTAMP,
    updated_at DATE DEFAULT CURRENT_TIMESTAMP,
    user_id TEXT NOT NULL,
    CONSTRAINT receives_user_id_fkey FOREIGN KEY (user_id) REFERENCES financas.users (id) ON DELETE RESTRICT ON UPDATE CASCADE
);