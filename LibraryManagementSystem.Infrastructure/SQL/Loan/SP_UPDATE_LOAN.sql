/*--------------------------------------------------------------------------------------------        
Tipo Objeto				: Stored Procedure        
Objeto					: SP_UPDATE_LOAN
Objetivo				: Atualiza emprestimo no banco
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
CREATE PROCEDURE SP_UPDATE_LOAN
@ID INT,
@ID_USER INT,
@ID_BOOK INT,
@DATE_LOAN DATETIME,
@DATE_DEVOLUTION DATETIME
AS
BEGIN
	UPDATE LOAN
	SET ID_USER = @ID_USER,
		ID_BOOK = @ID_BOOK,
		DATE_LOAN = @DATE_LOAN,
		DATE_DEVOLUTION = @DATE_DEVOLUTION
	WHERE ID = @ID
END