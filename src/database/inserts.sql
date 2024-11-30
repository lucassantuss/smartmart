-- INSERTS NO BANCO

-- Clientes
Insert into Clientes values
('Lucas', 'Rua José de Almeida', 'lucas@gmail.com.br', '(11) 91212-1242'),
('Renan', 'Rua dos coqueiros', 'renan@hotmail.com.br', '(51) 95648-2568'),
('Danilo', 'Rua Alfajor', 'danilo@outlook.com.br', '(33) 94545-4542'),
('Maik', 'Rua Vitória', 'maik@terra.com.br', '(11) 92323-2322'),
('Luan', 'Rua Pereira Barreto', 'luan@gmail.com.br', '(30) 96556-3232'),
('Admin', 'Rua 404', 'admin@anonymous.org', '(11) 97070-7070')

-- Usuários
Insert into Usuarios values
(CAST('abcd' AS VARBINARY(MAX)), 'lucas.santos', '1234', 'Funcionario', 1),
(CAST('abcd' AS VARBINARY(MAX)), 'renan_cesar', '1234', 'Funcionario', 2),
(CAST('abcd' AS VARBINARY(MAX)), 'danilo.rodrigues', '1234', 'Cliente', 3),
(CAST('abcd' AS VARBINARY(MAX)), 'maik_soares', '1234', 'Funcionario', 4),
(CAST('abcd' AS VARBINARY(MAX)), 'luan_pereira', '1234', 'Cliente', 5),
(CAST('abcd' AS VARBINARY(MAX)), 'admin', 'admin', 'Administrador', 6)

-- Fornecedores
Insert into Fornecedores values
('Coca-Cola', 'Atlanta, Geórgia, EUA', 'coca-cola@corp.com', '(11) 97458-2565'),
('Nabisco', 'São Paulo, Brasil', 'nabisco@gmail.com', '(33) 93586-7895'),
('Garoto', 'Vila Velha, Espírito Santo', 'garoto@outlook.com', '(30) 95859-3696'),
('Kibon', 'Brooklin, São Paulo', 'kibon@hotmail.com', '(11) 92565-2626'),
('Elma Chips', 'Curitiba, Paraná', 'elma_chips@pepsico.com.br', '(33) 98588-8989')

-- Produtos
Insert into Produtos values
(1, 'Coca Cola', NULL, 'Refrigerante garrafa 2L', 9.99, 10),
(2, 'Trakinas', NULL, 'Bolacha', 2.99, 30),
(3, 'Caixa de Bombom', NULL, 'Caixa de bombom da marca Garoto', 9.99, 11),
(4, 'Sorvete', NULL, 'Sorvete napolitano com 3 sabores', 10.00, 25),
(5, 'Fandangos', NULL, 'Salgadinho 300g', 3.99, 20)
