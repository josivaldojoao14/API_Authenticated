CREATE TABLE IF NOT EXISTS `clientes` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `nome` varchar(80) NOT NULL,
  `sobrenome` varchar(80) NOT NULL,
  `email` varchar(100) NOT NULL,
  `idade` int NOT NULL,
  `senha` varchar(100),
  `perfil` varchar(100),
  PRIMARY KEY (`id`)
)