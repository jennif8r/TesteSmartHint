CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `Clientes` (
    `Id` char(36) COLLATE ascii_general_ci NOT NULL,
    `Nome` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `Documento` varchar(14) CHARACTER SET utf8mb4 NOT NULL,
    `Mail` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `Telefone` varchar(11) CHARACTER SET utf8mb4 NOT NULL,
    `DataCadastro` datetime(6) NOT NULL,
    `TipoCliente` int NOT NULL,
    `InscricaoEstadual` varchar(12) CHARACTER SET utf8mb4 NULL,
    `Isento` tinyint(1) NULL,
    `Genero` int NULL,
    `DataNascimento` date NULL,
    `Bloqueado` tinyint(1) NOT NULL,
    `Senha` varchar(15) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_Clientes` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20231108160807_primeirodata', '6.0.3');

COMMIT;

