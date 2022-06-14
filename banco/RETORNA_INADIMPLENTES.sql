CREATE OR ALTER PROCEDURE [dbo].[RETORNA_INADIMPLENTES]
@CPF NVARCHAR(450) = NULL
AS
BEGIN
	IF @CPF IS NULL
		SELECT 
			U.CPF, 
			U.NOME, 
			S.DESCRICAO, 
			S.PRECO 
		FROM USUARIOS U
			INNER JOIN INADIMPLENTES I
				ON U.CPF = I.CPF_USUARIO
			INNER JOIN SERVICOS S
				ON I.ID_SERVICO = S.ID
	ELSE
		SELECT 
			U.CPF, 
			U.NOME, 
			S.DESCRICAO, 
			S.PRECO 
		FROM USUARIOS U
			INNER JOIN INADIMPLENTES I
				ON U.CPF = I.CPF_USUARIO
			INNER JOIN SERVICOS S
				ON I.ID_SERVICO = S.ID
		WHERE U.CPF = @CPF
	
	SET NOCOUNT OFF
END