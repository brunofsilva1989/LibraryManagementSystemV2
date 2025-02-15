/*--------------------------------------------------------------------------------------------        
Tipo Objeto				: Stored Procedure        
Objeto					: SP_RETURN_LOAN
Objetivo				: Cliente devolve livro e da baixa no empr�stimo no Banco de Dados
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
Bruno Silva			   00000 15/02/2025 Cria��o da procedure
Bruno Silva			   00001 15/02/2025 Altera��o de parametros e execu��o.
*/
ALTER PROCEDURE SP_RETURN_LOAN
@IDLOAN INT
AS
BEGIN
	UPDATE LOAN
	SET ActualReturnDate = GETDATE(), STATUS = 2
	WHERE ID = @IDLOAN
END



