/*--------------------------------------------------------------------------------------------        
Tipo Objeto				: Stored Procedure        
Objeto					: SP_UPDATE_USER
Objetivo				: Atualiza um usu�rio no banco de dados
Projeto					: Administra��o de banco de Dados         
Empresa Respons�vel		: BFS Treinamentos
Criado em				: 11/02/2025
Execu��o				: SSMS        
Palavras-chave			: Indices, Tabelas, Tamanho, Utiliza��o  
----------------------------------------------------------------------------------------------        
Dicion�rio:        

- Criar a procedure no banco de dados LibraryDB. 
- Executar a instru��o abaixo no banco de dados LibraryDB

  Execute sp_ms_marksystemobject 'sp_HelpIndex2'

-- IDBUG [00000]
----------------------------------------------------------------------------------------------        
Hist�rico:        
Autor                  IDBug Data       Descri��o        
---------------------- ----- ---------- ------------------------------------------------------------
Bruno Silva			   00000 11/02/2025 Cria��o da procedure
*/
CREATE PROCEDURE SP_UPDATE_USER
	@ID INT,
	@NAME NVARCHAR(100),
	@EMAIL NVARCHAR(50),
	@CPF NVARCHAR(11),
	@PASSWORD NVARCHAR(8)
AS
BEGIN
	UPDATE USERS 
	SET NAME = @NAME, EMAIL = @EMAIL, CPF = @CPF, PASSWORD = @PASSWORD 
	WHERE ID = @ID
END
GO