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
	@NAME VARCHAR(100),
	@EMAIL VARCHAR(50),
	@CPF VARCHAR(11),
	@PASSWORD VARCHAR(8),
	@CREATIONDATE SMALLDATETIME = null,
	@UPDATEDATE SMALLDATETIME = null
AS

BEGIN

	-- Se não for passado um valor, use GETDATE()
    IF @CREATIONDATE IS NULL 
        SET @CREATIONDATE = GETDATE();

    IF @UPDATEDATE IS NULL 
        SET @UPDATEDATE = GETDATE();

	INSERT INTO USERS (NAME, EMAIL, CPF, PASSWORD, CREATIONDATE, UPDATEDATE) 
	VALUES (@NAME, @EMAIL, @CPF, @PASSWORD, @CREATIONDATE, @UPDATEDATE)
END


	
