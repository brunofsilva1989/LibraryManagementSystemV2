/*--------------------------------------------------------------------------------------------        
Tipo Objeto				: Stored Procedure        
Objeto					: SP_CREATE_BOOKS
Objetivo				: Cria um livro no banco de dados
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
CREATE PROCEDURE SP_CREATE_BOOKS
	@Title NVARCHAR(100),
	@Author NVARCHAR(100),
	@ISBN NVARCHAR(100),
	@YearPublication INT
AS
BEGIN
	-- CONFIGURE O MODO DE RETORNO DE ERRO
		SET NOCOUNT ON;

	-- INSERIR UM NOVO LIVRO
		INSERT INTO BOOK (Title, Author, ISBN, YearPublication)
		VALUES (@Title, @Author, @ISBN, @YearPublication)

		RAISERROR('Livro criado com sucesso', 0, 1) WITH NOWAIT
	
END;