/*--------------------------------------------------------------------------------------------        
Tipo Objeto				: Stored Procedure        
Objeto					: SP_CREATE_LOAN
Objetivo				: Cria um novo emprestimo no Banco de Dados
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
*/
ALTER PROCEDURE SP_CREATE_LOAN
@IDUSER INT,
@IDBOOK INT
AS

DECLARE @LOANDATE DATETIME, @RETURNDATE DATETIME;
SET @LOANDATE = GETDATE();
SET @RETURNDATE = DATEADD(DAY, 7, @LOANDATE);


BEGIN
	INSERT INTO LOAN(IDUSER, IDBOOK, LOANDATE, RETURNDATE, STATUS)
	VALUES(@IDUSER, @IDBOOK, @LOANDATE, @RETURNDATE, 1)
END

--select * from loan