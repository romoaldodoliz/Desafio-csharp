CREATE TABLE Atores (
    Id INT PRIMARY KEY,
    PrimeiroNome VARCHAR(20),
    UltimoNome VARCHAR(20),
    Genero VARCHAR(1)
);

CREATE TABLE Filmes (
    Id INT PRIMARY KEY,
    Nome VARCHAR(50),
    Ano INT,
    Duracao INT
);

CREATE TABLE Generos (
    Id INT PRIMARY KEY,
    Genero VARCHAR(20)
);

CREATE TABLE FilmesGenero (
    IdGenero INT,
    IdFilme INT,
    FOREIGN KEY (IdGenero) REFERENCES Generos(Id),
    FOREIGN KEY (IdFilme) REFERENCES Filmes(Id)
);

CREATE TABLE ElencoFilme (
    Id INT PRIMARY KEY,
    IdAtor INT,
    IdFilme INT,
    Papel VARCHAR(30),
    FOREIGN KEY (IdAtor) REFERENCES Atores(Id),
    FOREIGN KEY (IdFilme) REFERENCES Filmes(Id)
);

-- =============================================
-- INSERÇÃO DE DADOS MOCK
-- =============================================

INSERT INTO Atores VALUES (1, 'Keanu', 'Reeves', 'M');
INSERT INTO Atores VALUES (2, 'Al', 'Pacino', 'M');
INSERT INTO Atores VALUES (3, 'Carrie-Anne', 'Moss', 'F');

INSERT INTO Filmes VALUES (1, 'Matrix', 1999, 136);
INSERT INTO Filmes VALUES (2, 'O Poderoso Chefão', 1972, 175);
INSERT INTO Filmes VALUES (3, 'John Wick', 2014, 101);
INSERT INTO Filmes VALUES (4, 'O Irlandês', 2019, 209);

INSERT INTO Generos VALUES (1, 'Ação');
INSERT INTO Generos VALUES (2, 'Ficção');
INSERT INTO Generos VALUES (3, 'Drama');
INSERT INTO Generos VALUES (4, 'Suspense');

INSERT INTO FilmesGenero VALUES (1, 1); -- Matrix - Ação
INSERT INTO FilmesGenero VALUES (2, 1); -- Matrix - Ficção
INSERT INTO FilmesGenero VALUES (1, 3); -- John Wick - Ação
INSERT INTO FilmesGenero VALUES (3, 2); -- Chefão - Drama
INSERT INTO FilmesGenero VALUES (3, 4); -- Irlandês - Drama

INSERT INTO ElencoFilme VALUES (1, 1, 1, 'Protagonista'); -- Keanu em Matrix
INSERT INTO ElencoFilme VALUES (2, 2, 2, 'Don Corleone'); -- Al em Chefão
INSERT INTO ElencoFilme VALUES (3, 3, 1, 'Trinity'); -- Carrie-Anne em Matrix

-- =============================================
-- CONSULTAS EXEMPLO
-- =============================================

-- 1. Filmes e ano de lançamento
SELECT Nome, Ano FROM Filmes;

-- 2. Atores cadastrados
SELECT PrimeiroNome, UltimoNome FROM Atores;

-- 3. Filmes com seus gêneros
SELECT f.Nome AS Filme, g.Genero
FROM Filmes f
JOIN FilmesGenero fg ON f.Id = fg.IdFilme
JOIN Generos g ON fg.IdGenero = g.Id;

-- 4. Atores que participaram de Matrix
SELECT a.PrimeiroNome, a.UltimoNome
FROM Atores a
JOIN ElencoFilme ef ON a.Id = ef.IdAtor
JOIN Filmes f ON ef.IdFilme = f.Id
WHERE f.Nome = 'Matrix';

-- 5. Filmes lançados após 2000
SELECT Nome, Ano FROM Filmes WHERE Ano > 2000;

-- 6. Atores e papéis desempenhados
SELECT a.PrimeiroNome, a.UltimoNome, ef.Papel, f.Nome AS Filme
FROM Atores a
JOIN ElencoFilme ef ON a.Id = ef.IdAtor
JOIN Filmes f ON ef.IdFilme = f.Id;

-- 7. Quantidade de filmes por gênero
SELECT g.Genero, COUNT(fg.IdFilme) AS QuantidadeFilmes
FROM Generos g
JOIN FilmesGenero fg ON g.Id = fg.IdGenero
GROUP BY g.Genero;

-- 8. Filmes ordenados por duração
SELECT Nome, Duracao FROM Filmes ORDER BY Duracao DESC;

-- 9. Gêneros sem filmes
SELECT g.Genero
FROM Generos g
LEFT JOIN FilmesGenero fg ON g.Id = fg.IdGenero
WHERE fg.IdFilme IS NULL;

-- 10. Total de filmes
SELECT COUNT(*) AS TotalFilmes FROM Filmes;

-- 11. Atores do gênero masculino
SELECT PrimeiroNome, UltimoNome FROM Atores WHERE Genero = 'M';

-- 12. Filmes com mais de um gênero
SELECT f.Nome, COUNT(fg.IdGenero) AS QuantidadeGeneros
FROM Filmes f
JOIN FilmesGenero fg ON f.Id = fg.IdFilme
GROUP BY f.Nome
HAVING COUNT(fg.IdGenero) > 1;