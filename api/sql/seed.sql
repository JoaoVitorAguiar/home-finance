BEGIN;


INSERT INTO "Persons" ("Id", "Name", "BirthDate", "CreatedAt", "UpdatedAt")
VALUES
(1, 'João da Silva', '1995-03-12', NOW(), NOW()),
(2, 'Maria Santos', '1998-07-22', NOW(), NOW()),
(3, 'Rafael Lima', '1990-11-03', NOW(), NOW()),
(4, 'Rita Oliveira', '1987-01-15', NOW(), NOW()),
(5, 'Cíntia Rocha', '2000-05-30', NOW(), NOW());


INSERT INTO "Categories" ("Id", "Description", "Purpose", "CreatedAt", "UpdatedAt")
VALUES
(1, 'Food', 'Expense', NOW(), NOW()),
(2, 'Rent', 'Expense', NOW(), NOW()),
(3, 'Transport', 'Expense', NOW(), NOW()),
(4, 'Salary', 'Income', NOW(), NOW()),
(5, 'Freelance', 'Income', NOW(), NOW()),
(6, 'General', 'Both', NOW(), NOW());


INSERT INTO "Transactions"
("Description", "Amount", "Type", "PersonId", "CategoryId", "CreatedAt", "UpdatedAt")
VALUES
('Lunch at restaurant', 45.90, 'Expense', 1, 1, NOW(), NOW()),
('Supermarket', 120.00, 'Expense', 2, 1, NOW(), NOW()),
('Bus card', 80.00, 'Expense', 3, 3, NOW(), NOW()),
('January salary', 3500.00, 'Income', 4, 4, NOW(), NOW()),
('Freelance website', 1200.00, 'Income', 3, 5, NOW(), NOW()),
('Electricity bill', 210.40, 'Expense', 5, 2, NOW(), NOW()),
('Extra income', 500.00, 'Income', 1, 6, NOW(), NOW()),
('Gym membership', 99.90, 'Expense', 2, 6, NOW(), NOW());

COMMIT;
