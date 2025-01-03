﻿CREATE TABLE IF NOT EXISTS sys_user(
    id SERIAL NOT NULL PRIMARY KEY,
    first_name VARCHAR(100) NOT NULL,
    last_name VARCHAR(100) NOT NULL,
    phone_number VARCHAR(100) NOT NULL UNIQUE,
    password_hash VARCHAR(256) NOT NULL,
    is_admin BOOLEAN DEFAULT FALSE,
    created_date TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT NOW(),
    modified_date TIMESTAMP WITHOUT TIME ZONE,
    is_active BOOLEAN DEFAULT TRUE
)