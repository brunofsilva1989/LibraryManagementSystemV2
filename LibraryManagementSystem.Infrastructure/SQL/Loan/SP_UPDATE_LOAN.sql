/*--------------------------------------------------------------------------------------------        
Tipo Objeto				: Stored Procedure        
Objeto					: SP_UPDATE_LOAN
Objetivo				: Atualiza emprestimo no banco
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
Bruno Silva			   00000 11/02/2025 Criação da procedure
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