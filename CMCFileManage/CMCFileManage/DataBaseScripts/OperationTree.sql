USE [CMCFileManage]
GO
/****** Object:  Table [dbo].[OperationTree]    Script Date: 07/20/2010 13:56:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OperationTree](
	[PKID] [int] IDENTITY(1,1) NOT NULL,
	[NodeID] [int] NULL,
	[ParentID] [int] NULL,
	[NodeText] [varchar](50) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[NavigateURL] [varchar](100) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[NodeValue] [varchar](100) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL,
	[AccessRole] [int] NULL,
	[DeleteFlag] [int] NULL,
 CONSTRAINT [PK_OperationTree] PRIMARY KEY CLUSTERED 
(
	[PKID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'PKID' , @level0type=N'USER',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperationTree', @level2type=N'COLUMN',@level2name=N'PKID'
GO
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'節點ID' , @level0type=N'USER',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperationTree', @level2type=N'COLUMN',@level2name=N'NodeID'
GO
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'父節點ID，如果沒有則為0' , @level0type=N'USER',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperationTree', @level2type=N'COLUMN',@level2name=N'ParentID'
GO
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'菜單文本顯示的text內容' , @level0type=N'USER',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperationTree', @level2type=N'COLUMN',@level2name=N'NodeText'
GO
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'點擊URL，若果沒有為空' , @level0type=N'USER',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperationTree', @level2type=N'COLUMN',@level2name=N'NavigateURL'
GO
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'所在菜單順序位置，以0為起始' , @level0type=N'USER',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperationTree', @level2type=N'COLUMN',@level2name=N'NodeValue'
GO
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'顯示權限，自定義' , @level0type=N'USER',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperationTree', @level2type=N'COLUMN',@level2name=N'AccessRole'
GO
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'刪除標示' , @level0type=N'USER',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperationTree', @level2type=N'COLUMN',@level2name=N'DeleteFlag'