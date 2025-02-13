/*--------------------------------------------------------------------------------------------        
Tipo Objeto				: Stored Procedure        
Objeto					: SP_CREATE_USER
Objetivo				: Cria um novo usuário no Banco de Dados
Projeto					: Administração de banco de Dados         
Empresa Responsável		: BFS Treinamentos
Criado em				: 11/02/2025
Execução				: SSMS        
Palavras-chave			: Indices, Tabelas, Tamanho, Utilização  
----------------------------------------------------------------------------------------------        
Dicionário:        

- Criar a procedure no banco de dados LibraryDB. 
- Executar a instrução abaixo no banco de dados LibraryDB

  Execute sp_ms_marksystemobject 'sp_HelpIndex2'

-- IDBUG [00000]
----------------------------------------------------------------------------------------------        
Histórico:        
Autor                  IDBug Data       Descrição        
---------------------- ----- ---------- ------------------------------------------------------------
Bruno Silva			   00000 11/02/2025 Criação da procedure
*/
CREATE PROCEDURE SP_CREATE_USER
	@NAME NVARCHAR(100),
	@EMAIL NVARCHAR(50),
	@CPF NVARCHAR(11),
	@PASSWORD NVARCHAR(8),
	@CREATIONDATE SMALLDATETIME = GETDATE,
	@UPDATEDATE SMALLDATETIME = GETDATE
AS

BEGIN
	INSERT INTO USERS (NAME, EMAIL, CPF, PASSWORD, CREATIONDATE, UPDATEDATE) 
	VALUES (@NAME, @EMAIL, @CPF, @PASSWORD, @CREATIONDATE, @UPDATEDATE)
END

GO
	