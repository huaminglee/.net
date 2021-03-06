SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[WF_AttachFileInfo]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[WF_AttachFileInfo](
	[FileID] [int] IDENTITY(1,1) NOT NULL,
	[ParentID] [int] NOT NULL,
	[ParentCategory] [int] NOT NULL,
	[ParentSubCategory] [int] NULL,
	[FileGuID] [uniqueidentifier] NULL,
	[FileName] [nvarchar](200) NOT NULL,
	[FileExtension] [nvarchar](50) NOT NULL,
	[FileSize] [int] NOT NULL,
	[FileClientName] [nvarchar](500) NULL,
	[Extend1] [nvarchar](50) NULL,
	[Extend2] [nvarchar](50) NULL,
	[Extend3] [nvarchar](50) NULL,
	[Extend4] [nvarchar](50) NULL,
	[Extend5] [nvarchar](100) NULL,
	[RecordVersion] [nvarchar](50) NULL CONSTRAINT [DF_Extra_Files_RecordVersion]  DEFAULT (N'((V1.0))'),
	[RecordCreateTime] [datetime] NULL CONSTRAINT [DF_Extra_Files_RecordCreateTime]  DEFAULT (getdate()),
	[RecordDeleted] [int] NULL CONSTRAINT [DF_Extra_Files_RecordDeleted]  DEFAULT ((0)),
 CONSTRAINT [PK_WF_AttachFileInfo] PRIMARY KEY CLUSTERED 
(
	[FileID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'附件PKID' ,@level0type=N'USER', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WF_AttachFileInfo', @level2type=N'COLUMN', @level2name=N'FileID'

GO
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'附件主表PKID' ,@level0type=N'USER', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WF_AttachFileInfo', @level2type=N'COLUMN', @level2name=N'ParentID'

GO
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'附件類別(不同模組附件的區分)' ,@level0type=N'USER', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WF_AttachFileInfo', @level2type=N'COLUMN', @level2name=N'ParentCategory'

GO
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'附件子類別(同一模組不同類別附件的區分)' ,@level0type=N'USER', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WF_AttachFileInfo', @level2type=N'COLUMN', @level2name=N'ParentSubCategory'

GO
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'附件GuID' ,@level0type=N'USER', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WF_AttachFileInfo', @level2type=N'COLUMN', @level2name=N'FileGuID'

GO
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'附件名稱' ,@level0type=N'USER', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WF_AttachFileInfo', @level2type=N'COLUMN', @level2name=N'FileName'

GO
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'附件類型' ,@level0type=N'USER', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WF_AttachFileInfo', @level2type=N'COLUMN', @level2name=N'FileExtension'

GO
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'附件大小' ,@level0type=N'USER', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WF_AttachFileInfo', @level2type=N'COLUMN', @level2name=N'FileSize'

GO
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'附件客戶端名稱' ,@level0type=N'USER', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WF_AttachFileInfo', @level2type=N'COLUMN', @level2name=N'FileClientName'

GO
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'擴展欄位1' ,@level0type=N'USER', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WF_AttachFileInfo', @level2type=N'COLUMN', @level2name=N'Extend1'

GO
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'擴展欄位2' ,@level0type=N'USER', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WF_AttachFileInfo', @level2type=N'COLUMN', @level2name=N'Extend2'

GO
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'擴展欄位3' ,@level0type=N'USER', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WF_AttachFileInfo', @level2type=N'COLUMN', @level2name=N'Extend3'

GO
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'擴展欄位4' ,@level0type=N'USER', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WF_AttachFileInfo', @level2type=N'COLUMN', @level2name=N'Extend4'

GO
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'擴展欄位5' ,@level0type=N'USER', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WF_AttachFileInfo', @level2type=N'COLUMN', @level2name=N'Extend5'

GO
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'記錄版本' ,@level0type=N'USER', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WF_AttachFileInfo', @level2type=N'COLUMN', @level2name=N'RecordVersion'

GO
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'記錄創建時間' ,@level0type=N'USER', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WF_AttachFileInfo', @level2type=N'COLUMN', @level2name=N'RecordCreateTime'

GO
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'記錄刪除標記(0:未刪除,1:已刪除)' ,@level0type=N'USER', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'WF_AttachFileInfo', @level2type=N'COLUMN', @level2name=N'RecordDeleted'

