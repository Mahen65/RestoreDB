USE [master]
GO

/****** Object:  StoredProcedure [dbo].[spRestoreDB]    Script Date: 03-Dec-2018 2:35:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spRestoreDB]
(
 @Path VARCHAR(1000),
 @Data_File_Path VARCHAR(1000),
 @Log_File_Path VARCHAR(1000)
)
AS
BEGIN
  
    SET NOCOUNT ON 
	IF(RIGHT(@Data_File_Path,1)<>'\')
	BEGIN
		SET @Data_File_Path=@Data_File_Path+'\'
	END

	IF(RIGHT(@Log_File_Path,1)<>'\')
	BEGIN
		SET @Log_File_Path=@Log_File_Path+'\'
	END

	DECLARE @LogicalTable TABLE (LogicalName varchar(128),[PhysicalName] varchar(128), [Type] varchar, [FileGroupName] varchar(128), [Size] varchar(128), 
				[MaxSize] varchar(128), [FileId]varchar(128), [CreateLSN]varchar(128), [DropLSN]varchar(128), [UniqueId]varchar(128), [ReadOnlyLSN]varchar(128), [ReadWriteLSN]varchar(128), 
				[BackupSizeInBytes] varchar(128), [SourceBlockSize]varchar(128), [FileGroupId]varchar(128),[LogGroupGUID]varchar(128), [DifferentialBaseLSN]varchar(128), [DifferentialBaseGUID]varchar(128), [IsReadOnly]varchar(128), [IsPresent]varchar(128), [TDEThumbprint]varchar(128)
	)
	DECLARE @NameTable	TABLE(BackupName varchar(128),BackupDescription varchar(128),BackupType	varchar(128),ExpirationDate varchar(128)
						,Compressed	varchar(128),Position varchar(128),DeviceType varchar(128),UserName varchar(128),ServerName varchar(128)
						,DatabaseName varchar(128),DatabaseVersion varchar(128),DatabaseCreationDate varchar(128),BackupSize varchar(128),FirstLSN varchar(128)
						,LastLSN varchar(128),CheckpointLSN varchar(128),DatabaseBackupLSN varchar(128),BackupStartDate DATETIME,BackupFinishDate varchar(128)
						,SortOrder varchar(128),CodePage varchar(128),UnicodeLocaleId varchar(128),UnicodeComparisonStyle varchar(128),CompatibilityLevel varchar(128)
						,SoftwareVendorId varchar(128),SoftwareVersionMajor	varchar(128),SoftwareVersionMinor varchar(128),SoftwareVersionBuild varchar(128)
						,MachineName varchar(128),Flags varchar(128),BindingID varchar(128),RecoveryForkID varchar(128),Collation varchar(128),FamilyGUID varchar(128)
						,HasBulkLoggedData varchar(128),IsSnapshot varchar(128),IsReadOnly	varchar(128),IsSingleUser varchar(128),HasBackupChecksums varchar(128)
						,IsDamaged	varchar(128),BeginsLogChain	varchar(128),HasIncompleteMetaData	varchar(128),IsForceOffline	varchar(128),IsCopyOnly	varchar(128)
						,FirstRecoveryForkID varchar(128),ForkPointLSN	varchar(128),RecoveryModel	varchar(128),DifferentialBaseLSN varchar(128),DifferentialBaseGUID	varchar(128)
						,BackupTypeDescription	varchar(128),BackupSetGUID	varchar(128),CompressedBackupSize	varchar(128),Containment varchar(128))

	DECLARE @LogicalNameData varchar(128),@LogicalNameLog varchar(128),@DBName varchar(128)

	INSERT INTO @NameTable
	EXEC('RESTORE HEADERONLY  FROM DISK = '''+ @Path +'''')
	INSERT INTO @LogicalTable
	EXEC('RESTORE FILELISTONLY FROM DISK=''' +@Path+ '''')

	SET @DBName=(SELECT DatabaseName FROM @NameTable WHERE Position=(SELECT MAX(Position) FROM @NameTable))
	SET @LogicalNameData=(SELECT PhysicalName FROM @LogicalTable WHERE Type='D')
	SET @LogicalNameLog=(SELECT PhysicalName FROM @LogicalTable WHERE Type='L')
	SELECT @LogicalNameData,@LogicalNameLog

	SET @Data_File_Path=@Data_File_Path + REVERSE(SUBSTRING(REVERSE(@LogicalNameData),0,CHARINDEX('\',REVERSE(@LogicalNameData))))
	SET @Log_File_Path =@Log_File_Path  + REVERSE(SUBSTRING(REVERSE(@LogicalNameLog),0,CHARINDEX('\',REVERSE(@LogicalNameLog))))

	SELECT @Data_File_Path ,@Log_File_Path

	RESTORE DATABASE @DBName  
		FROM DISK = @Path
	   WITH  REPLACE,  
	MOVE @LogicalNameData TO  @Data_File_Path,
	MOVE @LogicalNameLog TO @Log_File_Path

	DECLARE @TEMPLATE varchar(128),@SQL_SCRIPT varchar(255)


	SET @TEMPLATE='USE {DBName}
				   ALTER DATABASE {DBName}
				   SET RECOVERY SIMPLE
				   DBCC SHRINKFILE ({LogicalNameLog}, 1)'

	SET @SQL_SCRIPT = REPLACE(REPLACE(@TEMPLATE, '{DBNAME}', @DBName),'{LogicalNameLog}',@LogicalNameLog)

	EXEC (@SQL_SCRIPT)


END
GO

