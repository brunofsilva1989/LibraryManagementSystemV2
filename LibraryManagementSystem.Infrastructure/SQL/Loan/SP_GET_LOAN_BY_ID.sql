/*--------------------------------------------------------------------------------------------        
Tipo Objeto				: Stored Procedure        
Objeto					: SP_GET_LOAN_BY_ID
Objetivo				: Busca um empréstimo pelo ID
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
CREATE PROCEDURE SP_GET_LOAN_BY_ID
@ID INT
AS
BEGIN
	SELECT * FROM LOAN(NOLOCK)
	WHERE ID = @ID
END
