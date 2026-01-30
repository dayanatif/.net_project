-- Create app_user table for login (MySQL)
-- Run this if you are not using EF Core migrations.
-- After creating the table, start the app once; it will seed admin and user (see README).

CREATE TABLE IF NOT EXISTS app_user (
    Id INT NOT NULL AUTO_INCREMENT,
    UserName VARCHAR(256) NOT NULL,
    PasswordHash VARCHAR(256) NOT NULL,
    Role VARCHAR(64) NOT NULL,
    PRIMARY KEY (Id),
    UNIQUE KEY IX_app_user_UserName (UserName)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
