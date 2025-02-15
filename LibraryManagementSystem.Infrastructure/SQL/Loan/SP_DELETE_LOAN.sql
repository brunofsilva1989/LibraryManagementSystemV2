/*--------------------------------------------------------------------------------------------        
Tipo Objeto				: Stored Procedure        
Objeto					: SP_DELETE_LOAN
Objetivo				: Delete um emprestimo no Banco de Dados
Projeto					: Administra��o de banco de Dados         
Empresa Respons�vel		: BFS Treinamentos
Criado em				: 15/02/2025
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
Bruno Silva			   00000 15/02/2025 Cria��o da procedure
*/
CREATE PROCEDURE SP_DELETE_LOAN
@IDLOAN INT
AS
BEGIN
	DELETE FROM LOAN
	WHERE ID = @IDLOAN AND STATUS = 0
END

