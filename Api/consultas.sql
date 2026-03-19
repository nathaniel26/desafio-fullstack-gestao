SELECT * FROM Usuarios;
SELECT COUNT(*) FROM Usuarios;
SELECT * FROM Usuarios WHERE Id = 1;

SELECT * FROM Produtos;

INSERT INTO Usuarios (NomeCompleto, Email, Senha)
VALUES 
('Ana Silva', 'ana.silva@email.com', '123456'),
('Bruno Costa', 'bruno.costa@email.com', '123456'),
('Carla Mendes', 'carla.mendes@email.com', '123456');

INSERT INTO Produtos (Titulo, Descricao, Quantidade, ImagemUrl)
VALUES
('Teclado Mecânico', 'Teclado mecânico RGB, USB', 10, 'teclado.jpg'),
('Mouse Gamer', 'Mouse gamer com sensor de alta precisão', 15, 'mouse.jpg'),
('Monitor 24"', 'Monitor Full HD 24 polegadas', 8, 'monitor.jpg');