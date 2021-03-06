SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WF_DeleteAttachFileInfoByCondition]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[WF_DeleteAttachFileInfoByCondition]
(
	@SearchCondition nvarchar(1000) --##PARAM @SearchCondition 查詢條件
)
--WITH  ENCRYPTION  
AS
SET NOCOUNT ON

Declare @SQLScript nvarchar(2000)
Set @SQLScript=''''

Set @SQLScript=''
    UPDATE WF_AttachFileInfo
    SET RecordDeleted = 1
    WHERE ''+@SearchCondition

--Print(@SQLScript)
EXEC(@SQLScript)

SET NOCOUNT OFF
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WF_LoadAttachFileInfoBySearchCondition]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[WF_LoadAttachFileInfoBySearchCondition]
(
	@SearchCondition nvarchar(2000) --##PARAM @SearchCondition 查詢條件
)
--WITH  ENCRYPTION  
AS
SET NOCOUNT ON

Declare @SQLScript nvarchar(4000)
Set @SQLScript=''''
If(@SearchCondition<>'''')
        Set @SQLScript=''
        SELECT
                FileID,
                ParentID,
                ParentCategory,
                ParentSubCategory,
                FileGuID,
                FileName,
                FileExtension,
                FileSize,
                FileClientName,
                Extend1,
                Extend2,
                Extend3,
                Extend4,
                Extend5,
                RecordVersion,
                RecordCreateTime,
                RecordDeleted
        FROM 
                WF_AttachFileInfo
        WHERE ''+@SearchCondition
+'' AND RecordDeleted = 0''
Else
        Set @SQLScript=''
        SELECT
                FileID,
                ParentID,
                ParentCategory,
                ParentSubCategory,
                FileGuID,
                FileName,
                FileExtension,
                FileSize,
                FileClientName,
                Extend1,
                Extend2,
                Extend3,
                Extend4,
                Extend5,
                RecordVersion,
                RecordCreateTime,
                RecordDeleted
        FROM 
                WF_AttachFileInfo
        WHERE RecordDeleted = 0''

--Print(@SQLScript)
EXEC(@SQLScript)

SET NOCOUNT OFF
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WF_DeleteAttachFileInfoByFileGuid]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[WF_DeleteAttachFileInfoByFileGuid]
(
    @FileGuid nvarchar(50)--##PARAM @FileGuid 附件@FileGuid
)
--WITH  ENCRYPTION  
AS
SET NOCOUNT ON

delete WF_AttachFileInfo
WHERE
    FileGuid= @FileGuid

SET NOCOUNT OFF

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WF_ChangeAttachFileInfoByFileGuid]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[WF_ChangeAttachFileInfoByFileGuid]
(
@ParentID as int, 
@FileGuid nvarchar(2000)
) 
AS
SET NOCOUNT ON
Declare @TblFileGUID table(FileGuID varchar(50))
Declare @i int

set @FileGuid =rtrim(ltrim(@FileGuid))
set @i=charindex('';'',@FileGuid )
while @i>=1
 begin
  insert @TblFileGUID values(left(@FileGuid,@i-1))
  set @FileGuid=substring(@FileGuid,@i+1,len(@FileGuid)-@i)
  set @i=charindex('';'',@FileGuid)
 end
if @FileGuid<>'''' 
    insert @TblFileGUID values(@FileGuid)

set @FileGuid =''''--清空
DECLARE FileGuidCursor CURSOR FOR
Select FileGuID From @TblFileGUID

OPEN FileGuidCursor 
FETCH NEXT FROM FileGuidCursor into @FileGuid 

WHILE @@FETCH_STATUS = 0
BEGIN
	
update Wf_AttachFileInfo set ParentID=@ParentID 
where FileGuID=@FileGuid
	FETCH NEXT FROM FileGuidCursor into @FileGuid 
End
CLOSE FileGuidCursor 
DEALLOCATE FileGuidCursor 

SET NOCOUNT OFF




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WF_LoadAttachFileInfoByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[WF_LoadAttachFileInfoByPrimaryKey]
(
    @FileID int--##PARAM @FileID 附件PKID
)
--WITH  ENCRYPTION  
AS
SET NOCOUNT ON

SELECT
        FileID,
        ParentID,
        ParentCategory,
        ParentSubCategory,
        FileGuID,
        FileName,
        FileExtension,
        FileSize,
        FileClientName,
        Extend1,
        Extend2,
        Extend3,
        Extend4,
        Extend5,
        RecordVersion,
        RecordCreateTime,
        RecordDeleted
FROM
        WF_AttachFileInfo
WHERE 
        FileID= @FileID

SET NOCOUNT OFF
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WF_InsertAttachFileInfo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[WF_InsertAttachFileInfo]
(
    @ParentID int,-- ##PARAM @ParentID 附件主表PKID
    @ParentCategory int,-- ##PARAM @ParentCategory 附件類別(不同模組附件的區分)
    @ParentSubCategory int=NULL,-- ##PARAM @ParentSubCategory 附件子類別(同一模組不同類別附件的區分)
    @FileGuID uniqueidentifier=NULL,-- ##PARAM @FileGuID 附件GuID
    @FileName nvarchar(200),-- ##PARAM @FileName 附件名稱
    @FileExtension nvarchar(50),-- ##PARAM @FileExtension 附件類型
    @FileSize int,-- ##PARAM @FileSize 附件大小
    @FileClientName nvarchar(500)=NULL,-- ##PARAM @FileClientName 附件客戶端名稱
    @Extend1 nvarchar(50)=NULL,-- ##PARAM @Extend1 擴展欄位1
    @Extend2 nvarchar(50)=NULL,-- ##PARAM @Extend2 擴展欄位2
    @Extend3 nvarchar(50)=NULL,-- ##PARAM @Extend3 擴展欄位3
    @Extend4 nvarchar(50)=NULL,-- ##PARAM @Extend4 擴展欄位4
    @Extend5 nvarchar(100)=NULL,-- ##PARAM @Extend5 擴展欄位5
    @RecordVersion nvarchar(50)=NULL,-- ##PARAM @RecordVersion 記錄版本
    @RecordCreateTime datetime=NULL,-- ##PARAM @RecordCreateTime 記錄創建時間
    @RecordDeleted int=NULL-- ##PARAM @RecordDeleted 記錄刪除標記(0:未刪除,1:已刪除)
)
--WITH  ENCRYPTION  
AS
SET NOCOUNT ON 

INSERT INTO [WF_AttachFileInfo]
(
    ParentID,
    ParentCategory,
    ParentSubCategory,
    FileGuID,
    FileName,
    FileExtension,
    FileSize,
    FileClientName,
    Extend1,
    Extend2,
    Extend3,
    Extend4,
    Extend5,
    RecordVersion,
    RecordCreateTime,
    RecordDeleted
)
VALUES
(
    @ParentID,
    @ParentCategory,
    @ParentSubCategory,
    @FileGuID,
    @FileName,
    @FileExtension,
    @FileSize,
    @FileClientName,
    @Extend1,
    @Extend2,
    @Extend3,
    @Extend4,
    @Extend5,
    @RecordVersion,
    @RecordCreateTime,
    @RecordDeleted
)

SELECT CAST(SCOPE_IDENTITY() as INT)

SET NOCOUNT OFF
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WF_UpdateAttachFileInfo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[WF_UpdateAttachFileInfo]
(
    @FileID int,-- ##PARAM @FileID 附件PKID
    @ParentID int,-- ##PARAM @ParentID 附件主表PKID
    @ParentCategory int,-- ##PARAM @ParentCategory 附件類別(不同模組附件的區分)
    @ParentSubCategory int=NULL,-- ##PARAM @ParentSubCategory 附件子類別(同一模組不同類別附件的區分)
    @FileGuID uniqueidentifier=NULL,-- ##PARAM @FileGuID 附件GuID
    @FileName nvarchar(200),-- ##PARAM @FileName 附件名稱
    @FileExtension nvarchar(50),-- ##PARAM @FileExtension 附件類型
    @FileSize int,-- ##PARAM @FileSize 附件大小
    @FileClientName nvarchar(500)=NULL,-- ##PARAM @FileClientName 附件客戶端名稱
    @Extend1 nvarchar(50)=NULL,-- ##PARAM @Extend1 擴展欄位1
    @Extend2 nvarchar(50)=NULL,-- ##PARAM @Extend2 擴展欄位2
    @Extend3 nvarchar(50)=NULL,-- ##PARAM @Extend3 擴展欄位3
    @Extend4 nvarchar(50)=NULL,-- ##PARAM @Extend4 擴展欄位4
    @Extend5 nvarchar(100)=NULL,-- ##PARAM @Extend5 擴展欄位5
    @RecordVersion nvarchar(50)=NULL,-- ##PARAM @RecordVersion 記錄版本
    @RecordCreateTime datetime=NULL,-- ##PARAM @RecordCreateTime 記錄創建時間
    @RecordDeleted int=NULL-- ##PARAM @RecordDeleted 記錄刪除標記(0:未刪除,1:已刪除)
)
--WITH  ENCRYPTION  
AS
SET NOCOUNT ON

UPDATE [WF_AttachFileInfo] 
SET
    ParentID = @ParentID,
    ParentCategory = @ParentCategory,
    ParentSubCategory = @ParentSubCategory,
    FileGuID = @FileGuID,
    FileName = @FileName,
    FileExtension = @FileExtension,
    FileSize = @FileSize,
    FileClientName = @FileClientName,
    Extend1 = @Extend1,
    Extend2 = @Extend2,
    Extend3 = @Extend3,
    Extend4 = @Extend4,
    Extend5 = @Extend5,
    RecordVersion = @RecordVersion,
    RecordCreateTime = @RecordCreateTime,
    RecordDeleted = @RecordDeleted
WHERE
    FileID= @FileID

IF @@Error=0
     Select 1 as ReturnValue
Else 
     Select 0 as ReturnValue

SET NOCOUNT OFF
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WF_DeleteAttachFileInfoByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[WF_DeleteAttachFileInfoByPrimaryKey]
(
    @FileID int--##PARAM @FileID 附件PKID
)
--WITH  ENCRYPTION  
AS
SET NOCOUNT ON

DELETE WF_AttachFileInfo
WHERE
    FileID= @FileID

SET NOCOUNT OFF

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WF_GetAllDirtyAttachFileInfo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
--獲取所有ParentID為0的附件
--在排程時會調用并刪除指定文件夾下的文件，同時刪除數據庫中ParentID=0的記錄
CREATE PROCEDURE [dbo].[WF_GetAllDirtyAttachFileInfo]

--WITH  ENCRYPTION  
AS
SET NOCOUNT ON

select * from  WF_AttachFileInfo
WHERE
    ParentID= 0

SET NOCOUNT OFF

' 
END
