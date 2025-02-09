/*--------------------------------------------------------------------------------------------        
Tipo Objeto				: Stored Procedure        
Objeto					: SP_BOOKS 
Objetivo				: Buscar todos os Livros no banco de dados
Projeto					: Administração de banco de Dados         
Empresa Responsável		: BFS Treinamentos
Criado em				: 07/02/2025
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
Bruno Silva			   00000 07/02/2025 Criação da procedure
*/
ALTER PROCEDURE SP_BOOKS

AS
BEGIN
	-- CONFIGURE O MODO DE RETORNO DE ERRO
	SET NOCOUNT ON;

	SELECT Id, Title, Author, ISBN, YearPublication 
	FROM BOOK WITH(NOLOCK)

END;