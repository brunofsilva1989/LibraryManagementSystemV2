/*--------------------------------------------------------------------------------------------        
Tipo Objeto				: Stored Procedure        
Objeto					: SP_UPDATE_LOAN
Objetivo				: Estende o empréstimo do livro por mais 7 dias, e se o livro foi devolvido.
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
*/
CREATE PROCEDURE SP_UPDATE_LOAN
@IDLOAN INT
AS
BEGIN
	UPDATE LOAN
	SET RETURNDATE = DATEADD(DAY, 7, GETDATE()), RENEWCOUNT = RENEWCOUNT + 1
	WHERE ID = @IDLOAN AND STATUS = 1
END