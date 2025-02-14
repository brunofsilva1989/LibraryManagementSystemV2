/*--------------------------------------------------------------------------------------------        
Tipo Objeto				: Stored Procedure        
Objeto					: SP_GET_USERS
Objetivo				: Seleciona e mostra todos os usu�rios criados no banco.
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
Bruno Silva			   00000 11/02/2025 Cria��o da procedure
*/
CREATE PROCEDURE SP_GET_USERS
AS
BEGIN
	SELECT ID, NAME, CPF, EMAIL, PASSWORD, CREATIONDATE, UPDATEDATE FROM USERS(NOLOCK)
END