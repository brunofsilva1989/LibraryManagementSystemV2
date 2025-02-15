/*--------------------------------------------------------------------------------------------        
Tipo Objeto				: Stored Procedure        
Objeto					: SP_RETURN_LOAN
Objetivo				: Cliente devolve livro e da baixa no empréstimo no Banco de Dados
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
Bruno Silva			   00000 15/02/2025 Criação da procedure
Bruno Silva			   00001 15/02/2025 Alteração de parametros e execução.
*/
ALTER PROCEDURE SP_RETURN_LOAN
@IDLOAN INT
AS
BEGIN
	UPDATE LOAN
	SET ActualReturnDate = GETDATE(), STATUS = 2
	WHERE ID = @IDLOAN
END



