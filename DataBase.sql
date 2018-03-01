CREATE SCHEMA `gestao_condominio` ;

CREATE SCHEMA IF NOT EXISTS `gestao_condominio` DEFAULT CHARACTER SET utf8 ;
USE `gestao_condominio` ;

-- -----------------------------------------------------
-- Table `gestao_condominio`.`apartamento`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gestao_condominio`.`apartamento` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `numero` INT NOT NULL,
  `bloco` VARCHAR(10) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `gestao_condominio`.`morador`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gestao_condominio`.`morador` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(250) NULL,
  `data_nascimento` DATE NULL,
  `telefone` INT NULL,
  `cpf` INT NULL,
  `email` VARCHAR(250) NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `gestao_condominio`.`apartamento_morador`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `gestao_condominio`.`apartamento_morador` (
  `id_apartamento` INT NOT NULL,
  `id_morador` INT NOT NULL,
  `responsavel` TINYINT NULL,
  PRIMARY KEY (`id_apartamento`, `id_morador`),
  INDEX `fk_apartamento_morador_apartamento_idx` (`id_apartamento` ASC),
  INDEX `fk_apartamento_morador_morador1_idx` (`id_morador` ASC),
  CONSTRAINT `fk_apartamento_morador_apartamento`
    FOREIGN KEY (`id_apartamento`)
    REFERENCES `gestao_condominio`.`apartamento` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_apartamento_morador_morador1`
    FOREIGN KEY (`id_morador`)
    REFERENCES `gestao_condominio`.`morador` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

insert gestao_condominio.usuario (login, senha) values ('admin', '61467231c92990d884e2584df8b4c84b96bff2d76c3bd6b3e6aed2dab59459ab');
