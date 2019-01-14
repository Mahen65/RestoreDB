USE [master]
GO

/****** Object:  StoredProcedure [dbo].[spRestoreFromFolder]    Script Date: 03-Dec-2018 2:35:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spRestoreFromFolder] 
(

 @Path VARCHAR(128),
 @DataFilePath VARCHAR(128)=NULL,
 @LogFilePath VARCHAR(128)=NULL

)

AS

BEGIN

DECLARE @DefaultPath AS VARCHAR(128)
SET NOCOUNT ON;

SET @DefaultPath='C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA'

IF @DataFilePath IS NULL 
	BEGIN
		SET @DataFilePath=@DefaultPath
	END
IF @LogFilePath IS NULL
	BEGIN
		SET @LogFilePath=@DefaultPath
	END

EXEC sp_configure 'show advanced options', 1 
RECONFIGURE
EXEC sp_configure 'xp_cmdshell', 1
RECONFIGURE 

DECLARE @FileName varchar(128),@FilePath varchar(128),@CMD varchar(128)


SET @CMD='dir '+@Path +' /b'
DECLARE @files TABLE (FILENAME VARCHAR(100))
INSERT INTO @files EXECUTE xp_cmdshell @CMD


DECLARE FILES_CURSER CURSOR FOR SELECT FILENAME FROM @files WHERE FILENAME IS NOT NULL
OPEN FILES_CURSER  
		FETCH NEXT FROM FILES_CURSER INTO @FileName

	WHILE @@FETCH_STATUS = 0  
	BEGIN 
		SET @FilePath=@Path +'\'+@FileName
		EXEC spRestoreDB @FilePath,@DataFilePath,@LogFilePath
		FETCH NEXT FROM FILES_CURSER   INTO @FileName  
	END   
	CLOSE FILES_CURSER
	DEALLOCATE FILES_CURSER 

EXEC sp_configure 'xp_cmdshell', 0
RECONFIGURE 
EXEC sp_configure 'show advanced options', 0 
RECONFIGURE

END
GO

