/*--------------------------------------------------------------------------------------------        
Tipo Objeto				: Stored Procedure        
Objeto					: SP_DELETE_BOOKS
Objetivo				: Buscar um livro no banco de dados pelo seu ID
Projeto					: Administra��o de banco de Dados         
Empresa Respons�vel		: BFS Treinamentos
Criado em				: 10/02/2025
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
Bruno Silva			   00000 10/02/2025 Cria��o da procedure
*/
CREATE PROCEDURE SP_DELETE_BOOKS
	@Id INT
	AS
	BEGIN
		-- CONFIGURE O MODO DE RETORNO DE ERRO
		SET NOCOUNT ON;
		DELETE FROM BOOK
		WHERE Id = @Id
	END;