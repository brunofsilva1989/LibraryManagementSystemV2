/*--------------------------------------------------------------------------------------------        
Tipo Objeto				: Stored Procedure        
Objeto					: SP_DELETE_BOOKS
Objetivo				: Buscar um livro no banco de dados pelo seu ID
Projeto					: Administração de banco de Dados         
Empresa Responsável		: BFS Treinamentos
Criado em				: 10/02/2025
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
Bruno Silva			   00000 10/02/2025 Criação da procedure
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