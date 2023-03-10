CREATE TABLE TB_CLIENTES
(
	Nome VARCHAR(100) NOT NULL,
	Cpf VARCHAR(14) NOT NULL PRIMARY KEY,
	Uf VARCHAR(2) NOT NULL,
	Celular VARCHAR(12) NOT NULL,
)


CREATE TABLE TB_FINANCIAMENTOS
(
	IdFinanciamento INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Cpf VARCHAR(14) NOT NULL,
	TipoFinanciamento VARCHAR(14) NOT NULL,
	ValorTotal DECIMAL NOT NULL,
	DataUltimoFinanciamento DATETIME NOT NULL,
	FOREIGN KEY(Cpf) REFERENCES TB_CLIENTES(Cpf)
)

CREATE TABLE TB_PARCELAS
(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	NumeroParcela VARCHAR(14) NOT NULL,
	ValorParcela DECIMAL NOT NULL,
	DataVencimento DATETIME NOT NULL,
	DataPagamento DATETIME NULL,
	IdFinanciamento INT NOT NULL,
	FOREIGN KEY(IdFinanciamento) REFERENCES TB_FINANCIAMENTOS(IdFinanciamento)
)

INSERT INTO TB_CLIENTES VALUES('Erik Rocha', '48071622762', 'SP', '11954265105')
INSERT INTO TB_CLIENTES VALUES('Lucas Souza', '63726188762', 'SP', '11954265105')
INSERT INTO TB_CLIENTES VALUES('Bruno Souza', '29384766353', 'RJ', '11954265105')
INSERT INTO TB_CLIENTES VALUES('Maria Silva', '17283766272', 'SP', '11954265105')

INSERT INTO TB_FINANCIAMENTOS(Cpf, TipoFinanciamento, ValorTotal, DataUltimoFinanciamento) VALUES('48071622762', 'TESTE', 200, '2023-01-01')
INSERT INTO TB_FINANCIAMENTOS(Cpf, TipoFinanciamento, ValorTotal, DataUltimoFinanciamento) VALUES('63726188762', 'TESTE', 200, '2023-01-01')

INSERT INTO TB_PARCELAS VALUES('1', 200, '2023-02-01', null, 1) 
INSERT INTO TB_PARCELAS VALUES('1', 200, '2023-02-01', null, 2) 
INSERT INTO TB_PARCELAS VALUES('3', 200, '2023-02-01', '2023-05-01', 2) 


--CLIENTE DE SP COM MAIS DE 60% DAS PARCELAS PAGAS
SELECT CLI.* FROM TB_CLIENTES AS CLI 
INNER JOIN TB_FINANCIAMENTOS AS FINAN ON CLI.Cpf = FINAN.Cpf 
INNER JOIN TB_PARCELAS AS PAR ON FINAN.IdFinanciamento = PAR.IdFinanciamento
WHERE CLI.Uf = 'SP'
GROUP BY CLI.Nome, CLI.Cpf, CLI.Uf, CLI.Celular
HAVING COUNT(CASE WHEN DataPagamento IS NOT NULL THEN NumeroParcela END) >= 0.6 * COUNT(NumeroParcela);