-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 23/12/2021 às 03:32
-- Versão do servidor: 10.4.22-MariaDB
-- Versão do PHP: 8.0.13

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `brincalhoeskids`
--
CREATE DATABASE brincalhoeskids;

-- --------------------------------------------------------

--
-- Estrutura para tabela `carrinho`
--

CREATE TABLE `carrinho` (
  `Id` int(11) NOT NULL,
  `IdProduto` int(11) NOT NULL,
  `Quantidade` int(11) NOT NULL,
  `IdUsuario` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Despejando dados para a tabela `carrinho`
--

INSERT INTO `carrinho` (`Id`, `IdProduto`, `Quantidade`, `IdUsuario`) VALUES
(40, 10, 1, 6),
(41, 3, 1, 6),
(42, 5, 1, 7);

-- --------------------------------------------------------

--
-- Estrutura para tabela `produtos`
--

CREATE TABLE `produtos` (
  `Id` int(11) NOT NULL,
  `Nome` varchar(50) NOT NULL,
  `Descricao` varchar(150) NOT NULL,
  `Valor` double(9,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Despejando dados para a tabela `produtos`
--

INSERT INTO `produtos` (`Id`, `Nome`, `Descricao`, `Valor`) VALUES
(2, 'Homem Aranha', 'Marvel', 104.99),
(3, 'Capitão América', 'Marvel', 104.99),
(4, 'Incrível Hulk', 'Marvel', 114.99),
(5, 'Homem de Ferro', 'Marvel', 104.99),
(6, 'Thanos', 'Marvel', 119.99),
(7, 'Casa dos Sonhos', 'Barbie', 1399.99),
(8, 'Carro Conversível', 'Barbie', 167.39),
(9, 'Barbie Fashionista', 'Barbie', 269.99),
(10, 'Barbie Olímpiadas', 'Barbie', 150.99),
(11, 'Big Dreams Brooklyn', 'Barbie', 140.99),
(12, 'Funko Darth Vader', 'Star Wars', 238.99),
(13, 'Luke Skywalker', 'Star Wars', 719.99),
(14, 'Baby Yoda', 'Star Wars', 309.99),
(15, 'Mandalorian', 'Star Wars', 80.99),
(16, 'Cajado Mestre Yoda', 'Star Wars', 276.01),
(17, 'Stitch', 'Disney', 63.99),
(18, 'Funko Simba', 'Disney', 153.99),
(19, 'Bela e Fera', 'Disney', 899.99),
(20, 'Pack Mickey Mouse', 'Disney', 87.99),
(21, 'Pack Branca de neve', 'Disney', 119.01),
(22, 'Thor', 'Marvel', 78.99),
(23, 'Gwen Aranha', 'Marvel', 119.99),
(24, 'Loki', 'Marvel', 119.99),
(25, 'Pantera Negra', 'Marvel', 78.99),
(26, 'Mini Homem Aranha', 'Marvel', 99.99);

-- --------------------------------------------------------

--
-- Estrutura para tabela `usuarios`
--

CREATE TABLE `usuarios` (
  `Id` int(11) NOT NULL,
  `Admin` tinyint(1) NOT NULL,
  `Nome` varchar(80) NOT NULL,
  `Sobrenome` varchar(80) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `Login` varchar(20) NOT NULL,
  `Senha` varchar(30) NOT NULL,
  `DataNascimento` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Despejando dados para a tabela `usuarios`
--

INSERT INTO `usuarios` (`Id`, `Admin`, `Nome`, `Sobrenome`, `Email`, `Login`, `Senha`, `DataNascimento`) VALUES
(6, 0, 'João', 'Batista', 'joao@gmail.com', 'joao123', '123456', '2001-12-10'),
(7, 0, 'Iago', 'Oliveira', 'iago@gmail.com', 'iago', '123456', '2001-02-20');

--
-- Índices para tabelas despejadas
--

--
-- Índices de tabela `carrinho`
--
ALTER TABLE `carrinho`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IdProduto` (`IdProduto`),
  ADD KEY `IdUsuario` (`IdUsuario`);

--
-- Índices de tabela `produtos`
--
ALTER TABLE `produtos`
  ADD PRIMARY KEY (`Id`);

--
-- Índices de tabela `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `Email` (`Email`);

--
-- AUTO_INCREMENT para tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `carrinho`
--
ALTER TABLE `carrinho`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=43;

--
-- AUTO_INCREMENT de tabela `produtos`
--
ALTER TABLE `produtos`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- AUTO_INCREMENT de tabela `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- Restrições para tabelas despejadas
--

--
-- Restrições para tabelas `carrinho`
--
ALTER TABLE `carrinho`
  ADD CONSTRAINT `carrinho_ibfk_1` FOREIGN KEY (`IdProduto`) REFERENCES `produtos` (`Id`),
  ADD CONSTRAINT `carrinho_ibfk_2` FOREIGN KEY (`IdUsuario`) REFERENCES `usuarios` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
