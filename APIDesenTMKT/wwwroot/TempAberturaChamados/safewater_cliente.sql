-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 07-Nov-2022 às 23:42
-- Versão do servidor: 10.4.22-MariaDB
-- versão do PHP: 8.1.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `safewater_cliente`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `acesso`
--

CREATE TABLE `acesso` (
  `id_acesso` int(11) NOT NULL,
  `Acesso_empresa` varchar(500) NOT NULL,
  `nome_empresa` varchar(500) NOT NULL,
  `login_empresa` varchar(500) NOT NULL,
  `senha_empresa` varchar(1000) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `armazenamento`
--

CREATE TABLE `armazenamento` (
  `id_arm` int(11) NOT NULL,
  `nome_arm` varchar(250) NOT NULL,
  `nivel_arm` int(250) NOT NULL,
  `capacidade_arm` int(250) NOT NULL,
  `quantidade_saida` int(250) NOT NULL,
  `setor_abastecido` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `chamados`
--

CREATE TABLE `chamados` (
  `id_chamados` int(11) NOT NULL,
  `protocolo_chamados` int(250) NOT NULL,
  `data` date NOT NULL,
  `descricao_chamado` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `coleta`
--

CREATE TABLE `coleta` (
  `id_coleta` int(11) NOT NULL,
  `metros_cubicos` int(255) NOT NULL,
  `setor_coleta` varchar(500) NOT NULL,
  `nivel_coleta` int(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `contato`
--

CREATE TABLE `contato` (
  `id_contato` int(11) NOT NULL,
  `email` varchar(1000) NOT NULL,
  `numero_contato` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `empresa`
--

CREATE TABLE `empresa` (
  `razao_social` varchar(150) NOT NULL,
  `cnpj` int(20) NOT NULL,
  `pacote_contratado` varchar(100) NOT NULL,
  `tipo_mapeamento` varchar(200) NOT NULL,
  `quantidade_setor` int(100) NOT NULL,
  `tipo_hidrometo` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `endereco`
--

CREATE TABLE `endereco` (
  `id_endereco` int(11) NOT NULL,
  `logradouro` varchar(1000) NOT NULL,
  `cep` int(20) NOT NULL,
  `cidade` varchar(500) NOT NULL,
  `bairro` varchar(1000) NOT NULL,
  `estado` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `endereco`
--

INSERT INTO `endereco` (`id_endereco`, `logradouro`, `cep`, `cidade`, `bairro`, `estado`) VALUES
(0, '', 0, '', '', '');

-- --------------------------------------------------------

--
-- Estrutura da tabela `financeiro`
--

CREATE TABLE `financeiro` (
  `id_financeiro` int(11) NOT NULL,
  `num_boleto` int(250) NOT NULL,
  `data_pagamento` date NOT NULL,
  `vencimento_fin` date NOT NULL,
  `valor_fin` int(255) NOT NULL,
  `consumo_fin` int(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `monitoramento`
--

CREATE TABLE `monitoramento` (
  `id_moni` int(11) NOT NULL,
  `sensor_moni` varchar(250) NOT NULL,
  `setor_moni` varchar(250) NOT NULL,
  `medicao_saida` int(250) NOT NULL,
  `quanti_sensor` int(250) NOT NULL,
  `reuso_moni` varchar(250) NOT NULL,
  `descricao` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `propriedades_empresa`
--

CREATE TABLE `propriedades_empresa` (
  `id_propriedade` int(11) NOT NULL,
  `entrada_agua` varchar(250) NOT NULL,
  `nome_propriedade` varchar(250) NOT NULL,
  `descricao_propriedade` varchar(250) NOT NULL,
  `quantidade_entrada` int(250) NOT NULL,
  `origem_propriedade` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `saida_agua`
--

CREATE TABLE `saida_agua` (
  `id_saida` int(11) NOT NULL,
  `setor_saida` varchar(250) NOT NULL,
  `quantidade_saida` int(250) NOT NULL,
  `tipo_saida` varchar(250) NOT NULL,
  `origem_abastecimento` varchar(250) NOT NULL,
  `quantidade_gasta` int(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `setor`
--

CREATE TABLE `setor` (
  `id_setor` int(11) NOT NULL,
  `nome_setor` varchar(200) NOT NULL,
  `tipo_setor` varchar(200) NOT NULL,
  `saida_agua_setor` int(200) NOT NULL,
  `consumo_diario` int(200) NOT NULL,
  `consumo_semanal` int(200) NOT NULL,
  `consumo_mensal` int(200) NOT NULL,
  `intervalo_consumo` int(200) NOT NULL,
  `reuso` varchar(200) NOT NULL,
  `relatorio_setor` varchar(200) NOT NULL,
  `sensor_principal` varchar(200) NOT NULL,
  `sensor_local` varchar(200) NOT NULL,
  `tipo_sensor` varchar(200) NOT NULL,
  `data_instalacao_sensor` date NOT NULL,
  `necessidade_sensor` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `setor_nreu`
--

CREATE TABLE `setor_nreu` (
  `id_nreu` int(11) NOT NULL,
  `nome_setor_nreu` varchar(250) NOT NULL,
  `origem_agua` varchar(250) NOT NULL,
  `motivo_nreu` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `setor_reutilazavel`
--

CREATE TABLE `setor_reutilazavel` (
  `id_estra` int(11) NOT NULL,
  `setor_reut` varchar(250) NOT NULL,
  `tipo_reuso` varchar(250) NOT NULL,
  `quanti_reuso` int(250) NOT NULL,
  `fonte_reuso` varchar(250) NOT NULL,
  `saida_reuti` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `acesso`
--
ALTER TABLE `acesso`
  ADD PRIMARY KEY (`id_acesso`);

--
-- Índices para tabela `armazenamento`
--
ALTER TABLE `armazenamento`
  ADD PRIMARY KEY (`id_arm`);

--
-- Índices para tabela `coleta`
--
ALTER TABLE `coleta`
  ADD PRIMARY KEY (`id_coleta`);

--
-- Índices para tabela `contato`
--
ALTER TABLE `contato`
  ADD PRIMARY KEY (`id_contato`);

--
-- Índices para tabela `empresa`
--
ALTER TABLE `empresa`
  ADD PRIMARY KEY (`cnpj`);

--
-- Índices para tabela `endereco`
--
ALTER TABLE `endereco`
  ADD PRIMARY KEY (`id_endereco`);

--
-- Índices para tabela `financeiro`
--
ALTER TABLE `financeiro`
  ADD PRIMARY KEY (`id_financeiro`);

--
-- Índices para tabela `monitoramento`
--
ALTER TABLE `monitoramento`
  ADD PRIMARY KEY (`id_moni`);

--
-- Índices para tabela `propriedades_empresa`
--
ALTER TABLE `propriedades_empresa`
  ADD PRIMARY KEY (`id_propriedade`);

--
-- Índices para tabela `saida_agua`
--
ALTER TABLE `saida_agua`
  ADD PRIMARY KEY (`id_saida`);

--
-- Índices para tabela `setor`
--
ALTER TABLE `setor`
  ADD PRIMARY KEY (`id_setor`);

--
-- Índices para tabela `setor_nreu`
--
ALTER TABLE `setor_nreu`
  ADD PRIMARY KEY (`id_nreu`);

--
-- Índices para tabela `setor_reutilazavel`
--
ALTER TABLE `setor_reutilazavel`
  ADD PRIMARY KEY (`id_estra`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `acesso`
--
ALTER TABLE `acesso`
  MODIFY `id_acesso` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `armazenamento`
--
ALTER TABLE `armazenamento`
  MODIFY `id_arm` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `coleta`
--
ALTER TABLE `coleta`
  MODIFY `id_coleta` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `contato`
--
ALTER TABLE `contato`
  MODIFY `id_contato` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `financeiro`
--
ALTER TABLE `financeiro`
  MODIFY `id_financeiro` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `monitoramento`
--
ALTER TABLE `monitoramento`
  MODIFY `id_moni` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `propriedades_empresa`
--
ALTER TABLE `propriedades_empresa`
  MODIFY `id_propriedade` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `saida_agua`
--
ALTER TABLE `saida_agua`
  MODIFY `id_saida` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `setor`
--
ALTER TABLE `setor`
  MODIFY `id_setor` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `setor_nreu`
--
ALTER TABLE `setor_nreu`
  MODIFY `id_nreu` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `setor_reutilazavel`
--
ALTER TABLE `setor_reutilazavel`
  MODIFY `id_estra` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
