/*
Navicat SQL Server Data Transfer

Source Server         : 05服务器
Source Server Version : 105000
Source Host           : 192.168.1.5:1433
Source Database       : EHECD_PermissionSystem
Source Schema         : dbo

Target Server Type    : SQL Server
Target Server Version : 105000
File Encoding         : 65001

Date: 2016-09-12 14:50:22
*/


-- ----------------------------
-- Table structure for EHECD_FunctionMenu
-- ----------------------------
DROP TABLE [dbo].[EHECD_FunctionMenu]
GO
CREATE TABLE [dbo].[EHECD_FunctionMenu] (
[ID] uniqueidentifier NOT NULL DEFAULT (newid()) ,
[sMenuName] nvarchar(20) NOT NULL DEFAULT '' ,
[sPID] uniqueidentifier NULL ,
[sUrl] nvarchar(50) NOT NULL DEFAULT '' ,
[bIsDeleted] bit NOT NULL DEFAULT ((0)) ,
[iOrder] int NOT NULL DEFAULT ((0)) 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_FunctionMenu', 
'COLUMN', N'ID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'唯一标识'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_FunctionMenu'
, @level2type = 'COLUMN', @level2name = N'ID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'唯一标识'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_FunctionMenu'
, @level2type = 'COLUMN', @level2name = N'ID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_FunctionMenu', 
'COLUMN', N'sMenuName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'菜单名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_FunctionMenu'
, @level2type = 'COLUMN', @level2name = N'sMenuName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'菜单名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_FunctionMenu'
, @level2type = 'COLUMN', @level2name = N'sMenuName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_FunctionMenu', 
'COLUMN', N'sPID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'上级菜单标识'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_FunctionMenu'
, @level2type = 'COLUMN', @level2name = N'sPID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'上级菜单标识'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_FunctionMenu'
, @level2type = 'COLUMN', @level2name = N'sPID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_FunctionMenu', 
'COLUMN', N'sUrl')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'对应链接地址'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_FunctionMenu'
, @level2type = 'COLUMN', @level2name = N'sUrl'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'对应链接地址'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_FunctionMenu'
, @level2type = 'COLUMN', @level2name = N'sUrl'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_FunctionMenu', 
'COLUMN', N'bIsDeleted')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否删除'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_FunctionMenu'
, @level2type = 'COLUMN', @level2name = N'bIsDeleted'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否删除'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_FunctionMenu'
, @level2type = 'COLUMN', @level2name = N'bIsDeleted'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_FunctionMenu', 
'COLUMN', N'iOrder')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'排序编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_FunctionMenu'
, @level2type = 'COLUMN', @level2name = N'iOrder'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'排序编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_FunctionMenu'
, @level2type = 'COLUMN', @level2name = N'iOrder'
GO

-- ----------------------------
-- Records of EHECD_FunctionMenu
-- ----------------------------
INSERT INTO [dbo].[EHECD_FunctionMenu] ([ID], [sMenuName], [sPID], [sUrl], [bIsDeleted], [iOrder]) VALUES (N'0C196427-C8C8-C676-DF6E-08D3D661DB10', N'ceshi', N'A04BADFD-4F07-46BD-9816-A71EC4776B84', N'', N'1', N'1')
GO
GO
INSERT INTO [dbo].[EHECD_FunctionMenu] ([ID], [sMenuName], [sPID], [sUrl], [bIsDeleted], [iOrder]) VALUES (N'FB2A6AC6-BBD2-C82C-7304-08D3D661E166', N'caidan1', N'0C196427-C8C8-C676-DF6E-08D3D661DB10', N'111', N'1', N'0')
GO
GO
INSERT INTO [dbo].[EHECD_FunctionMenu] ([ID], [sMenuName], [sPID], [sUrl], [bIsDeleted], [iOrder]) VALUES (N'B4C85782-2975-C701-5AEB-08D3D924FA07', N'测试菜单', null, N'', N'1', N'1')
GO
GO
INSERT INTO [dbo].[EHECD_FunctionMenu] ([ID], [sMenuName], [sPID], [sUrl], [bIsDeleted], [iOrder]) VALUES (N'06D353AA-895C-CB69-D6AD-08D3D92500FD', N'测试子菜单', N'B4C85782-2975-C701-5AEB-08D3D924FA07', N'', N'1', N'1')
GO
GO
INSERT INTO [dbo].[EHECD_FunctionMenu] ([ID], [sMenuName], [sPID], [sUrl], [bIsDeleted], [iOrder]) VALUES (N'9F05F7DE-2B39-C6FB-DC27-08D3D9250D19', N'测试叶子菜单', N'06D353AA-895C-CB69-D6AD-08D3D92500FD', N'1', N'1', N'1')
GO
GO
INSERT INTO [dbo].[EHECD_FunctionMenu] ([ID], [sMenuName], [sPID], [sUrl], [bIsDeleted], [iOrder]) VALUES (N'75A5C98A-EBC9-C2D8-394F-08D3D94C6D0E', N'kf', N'9F05F7DE-2B39-C6FB-DC27-08D3D9250D19', N'1', N'1', N'1')
GO
GO
INSERT INTO [dbo].[EHECD_FunctionMenu] ([ID], [sMenuName], [sPID], [sUrl], [bIsDeleted], [iOrder]) VALUES (N'0F9EC590-1540-C15D-D311-08D3D94C6FDF', N'11', N'75A5C98A-EBC9-C2D8-394F-08D3D94C6D0E', N'11', N'1', N'11')
GO
GO
INSERT INTO [dbo].[EHECD_FunctionMenu] ([ID], [sMenuName], [sPID], [sUrl], [bIsDeleted], [iOrder]) VALUES (N'D98442F5-2667-C64A-6719-08D3D957C31B', N'<input>', N'A04BADFD-4F07-46BD-9816-A71EC4776B84', N'<input>', N'1', N'1')
GO
GO
INSERT INTO [dbo].[EHECD_FunctionMenu] ([ID], [sMenuName], [sPID], [sUrl], [bIsDeleted], [iOrder]) VALUES (N'BD0F732F-2662-CF03-3663-08D3D989603A', N'1', null, N'', N'1', N'1')
GO
GO
INSERT INTO [dbo].[EHECD_FunctionMenu] ([ID], [sMenuName], [sPID], [sUrl], [bIsDeleted], [iOrder]) VALUES (N'C210BC43-6DC5-C009-7993-08D3D98963F3', N'1', N'BD0F732F-2662-CF03-3663-08D3D989603A', N'', N'1', N'1')
GO
GO
INSERT INTO [dbo].[EHECD_FunctionMenu] ([ID], [sMenuName], [sPID], [sUrl], [bIsDeleted], [iOrder]) VALUES (N'69B9227D-BCE3-C45A-8734-08D3D9896603', N'1', N'BD0F732F-2662-CF03-3663-08D3D989603A', N'', N'1', N'1')
GO
GO
INSERT INTO [dbo].[EHECD_FunctionMenu] ([ID], [sMenuName], [sPID], [sUrl], [bIsDeleted], [iOrder]) VALUES (N'21D2E35F-346B-CAB9-C7CF-08D3D9896864', N'1', null, N'', N'1', N'1')
GO
GO
INSERT INTO [dbo].[EHECD_FunctionMenu] ([ID], [sMenuName], [sPID], [sUrl], [bIsDeleted], [iOrder]) VALUES (N'FD8A7ED9-97E7-C723-29D9-08D3D9896AF4', N'2', N'21D2E35F-346B-CAB9-C7CF-08D3D9896864', N'', N'1', N'2')
GO
GO
INSERT INTO [dbo].[EHECD_FunctionMenu] ([ID], [sMenuName], [sPID], [sUrl], [bIsDeleted], [iOrder]) VALUES (N'9666BED1-9A31-C4D6-30A6-08D3D9896D49', N'3', null, N'', N'1', N'3')
GO
GO
INSERT INTO [dbo].[EHECD_FunctionMenu] ([ID], [sMenuName], [sPID], [sUrl], [bIsDeleted], [iOrder]) VALUES (N'7548D71D-3173-C6F7-08E8-08D3D989700D', N'1', N'9666BED1-9A31-C4D6-30A6-08D3D9896D49', N'', N'1', N'1')
GO
GO
INSERT INTO [dbo].[EHECD_FunctionMenu] ([ID], [sMenuName], [sPID], [sUrl], [bIsDeleted], [iOrder]) VALUES (N'CFE121E7-FE7E-C75F-BDD7-08D3D9897CF5', N'3', null, N'', N'1', N'3')
GO
GO
INSERT INTO [dbo].[EHECD_FunctionMenu] ([ID], [sMenuName], [sPID], [sUrl], [bIsDeleted], [iOrder]) VALUES (N'F5590FDC-FC37-C39C-0857-08D3D9897F52', N'3', N'CFE121E7-FE7E-C75F-BDD7-08D3D9897CF5', N'', N'1', N'3')
GO
GO
INSERT INTO [dbo].[EHECD_FunctionMenu] ([ID], [sMenuName], [sPID], [sUrl], [bIsDeleted], [iOrder]) VALUES (N'1F3B2D17-79B8-C582-F00A-08D3D98981C2', N'3', N'CFE121E7-FE7E-C75F-BDD7-08D3D9897CF5', N'', N'1', N'3')
GO
GO
INSERT INTO [dbo].[EHECD_FunctionMenu] ([ID], [sMenuName], [sPID], [sUrl], [bIsDeleted], [iOrder]) VALUES (N'777AABEE-5110-CDC0-2B01-08D3D98983D6', N'3', N'CFE121E7-FE7E-C75F-BDD7-08D3D9897CF5', N'', N'1', N'3')
GO
GO
INSERT INTO [dbo].[EHECD_FunctionMenu] ([ID], [sMenuName], [sPID], [sUrl], [bIsDeleted], [iOrder]) VALUES (N'83FB4ECF-B802-CF85-B25B-08D3D989868E', N'4', null, N'', N'1', N'4')
GO
GO
INSERT INTO [dbo].[EHECD_FunctionMenu] ([ID], [sMenuName], [sPID], [sUrl], [bIsDeleted], [iOrder]) VALUES (N'24119645-E080-CE0F-3C62-08D3D9898977', N'4', N'83FB4ECF-B802-CF85-B25B-08D3D989868E', N'', N'1', N'4')
GO
GO
INSERT INTO [dbo].[EHECD_FunctionMenu] ([ID], [sMenuName], [sPID], [sUrl], [bIsDeleted], [iOrder]) VALUES (N'8525F941-F07D-C765-6E7E-08D3D9898C4B', N'4', N'83FB4ECF-B802-CF85-B25B-08D3D989868E', N'', N'1', N'4')
GO
GO
INSERT INTO [dbo].[EHECD_FunctionMenu] ([ID], [sMenuName], [sPID], [sUrl], [bIsDeleted], [iOrder]) VALUES (N'ECEB4232-5189-C6B9-8B60-08D3D989930F', N'4', N'A04BADFD-4F07-46BD-9816-A71EC4776B84', N'', N'1', N'4')
GO
GO
INSERT INTO [dbo].[EHECD_FunctionMenu] ([ID], [sMenuName], [sPID], [sUrl], [bIsDeleted], [iOrder]) VALUES (N'C82F164B-34F8-C4BD-C898-08D3D989986D', N'4', null, N'', N'1', N'4')
GO
GO
INSERT INTO [dbo].[EHECD_FunctionMenu] ([ID], [sMenuName], [sPID], [sUrl], [bIsDeleted], [iOrder]) VALUES (N'49CDFEA1-A8FC-C407-F847-08D3D9899B48', N'4', N'C82F164B-34F8-C4BD-C898-08D3D989986D', N'', N'1', N'4')
GO
GO
INSERT INTO [dbo].[EHECD_FunctionMenu] ([ID], [sMenuName], [sPID], [sUrl], [bIsDeleted], [iOrder]) VALUES (N'5CFAA5F3-239A-C4F7-AEA5-08D3DAA989E7', N'111', N'A04BADFD-4F07-46BD-9816-A71EC4776B84', N'', N'1', N'111')
GO
GO
INSERT INTO [dbo].[EHECD_FunctionMenu] ([ID], [sMenuName], [sPID], [sUrl], [bIsDeleted], [iOrder]) VALUES (N'AE10A1D0-EBEC-CC01-3AA5-08D3DAA98D12', N'11', N'5CFAA5F3-239A-C4F7-AEA5-08D3DAA989E7', N'', N'1', N'11')
GO
GO
INSERT INTO [dbo].[EHECD_FunctionMenu] ([ID], [sMenuName], [sPID], [sUrl], [bIsDeleted], [iOrder]) VALUES (N'4149B58D-82ED-C688-EB15-08D3DAA98FA8', N'111', N'AE10A1D0-EBEC-CC01-3AA5-08D3DAA98D12', N'', N'1', N'111')
GO
GO
INSERT INTO [dbo].[EHECD_FunctionMenu] ([ID], [sMenuName], [sPID], [sUrl], [bIsDeleted], [iOrder]) VALUES (N'B2D24E47-EBCF-C31A-00B5-08D3DAA99219', N'11', N'4149B58D-82ED-C688-EB15-08D3DAA98FA8', N'', N'1', N'111')
GO
GO
INSERT INTO [dbo].[EHECD_FunctionMenu] ([ID], [sMenuName], [sPID], [sUrl], [bIsDeleted], [iOrder]) VALUES (N'F4E60D2B-114E-CAC7-8F95-08D3DAA99768', N'11', N'B2D24E47-EBCF-C31A-00B5-08D3DAA99219', N'11', N'1', N'111')
GO
GO
INSERT INTO [dbo].[EHECD_FunctionMenu] ([ID], [sMenuName], [sPID], [sUrl], [bIsDeleted], [iOrder]) VALUES (N'B138CE7D-048E-4293-AEB5-210F55FCB674', N'菜单管理', N'A04BADFD-4F07-46BD-9816-A71EC4776B84', N'/Admin/MenuManage', N'0', N'0')
GO
GO
INSERT INTO [dbo].[EHECD_FunctionMenu] ([ID], [sMenuName], [sPID], [sUrl], [bIsDeleted], [iOrder]) VALUES (N'7E7D35EB-A425-4288-8D0F-9ABEA6EDCEB9', N'用户管理', N'A04BADFD-4F07-46BD-9816-A71EC4776B84', N'/Admin/SystemUser', N'0', N'2')
GO
GO
INSERT INTO [dbo].[EHECD_FunctionMenu] ([ID], [sMenuName], [sPID], [sUrl], [bIsDeleted], [iOrder]) VALUES (N'A04BADFD-4F07-46BD-9816-A71EC4776B84', N'系统管理', null, N'', N'0', N'0')
GO
GO
INSERT INTO [dbo].[EHECD_FunctionMenu] ([ID], [sMenuName], [sPID], [sUrl], [bIsDeleted], [iOrder]) VALUES (N'13663269-A6F3-4E97-8546-E6192E61C5AC', N'角色管理', N'A04BADFD-4F07-46BD-9816-A71EC4776B84', N'/Admin/RoleManage', N'0', N'1')
GO
GO

-- ----------------------------
-- Table structure for EHECD_MenuButton
-- ----------------------------
DROP TABLE [dbo].[EHECD_MenuButton]
GO
CREATE TABLE [dbo].[EHECD_MenuButton] (
[ID] uniqueidentifier NOT NULL DEFAULT (newid()) ,
[sButtonName] nvarchar(20) NOT NULL DEFAULT '' ,
[bIsDeleted] bit NOT NULL DEFAULT ((0)) ,
[iOrder] int NOT NULL DEFAULT ((0)) ,
[sIcon] nvarchar(15) NOT NULL DEFAULT ('icon-add') ,
[sDataID] nvarchar(25) NOT NULL DEFAULT '' 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_MenuButton', 
'COLUMN', N'ID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'唯一标识'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_MenuButton'
, @level2type = 'COLUMN', @level2name = N'ID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'唯一标识'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_MenuButton'
, @level2type = 'COLUMN', @level2name = N'ID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_MenuButton', 
'COLUMN', N'sButtonName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'按钮名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_MenuButton'
, @level2type = 'COLUMN', @level2name = N'sButtonName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'按钮名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_MenuButton'
, @level2type = 'COLUMN', @level2name = N'sButtonName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_MenuButton', 
'COLUMN', N'bIsDeleted')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否删除'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_MenuButton'
, @level2type = 'COLUMN', @level2name = N'bIsDeleted'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否删除'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_MenuButton'
, @level2type = 'COLUMN', @level2name = N'bIsDeleted'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_MenuButton', 
'COLUMN', N'iOrder')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'排序编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_MenuButton'
, @level2type = 'COLUMN', @level2name = N'iOrder'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'排序编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_MenuButton'
, @level2type = 'COLUMN', @level2name = N'iOrder'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_MenuButton', 
'COLUMN', N'sIcon')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'菜单ICON'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_MenuButton'
, @level2type = 'COLUMN', @level2name = N'sIcon'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'菜单ICON'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_MenuButton'
, @level2type = 'COLUMN', @level2name = N'sIcon'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_MenuButton', 
'COLUMN', N'sDataID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'标识符'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_MenuButton'
, @level2type = 'COLUMN', @level2name = N'sDataID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'标识符'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_MenuButton'
, @level2type = 'COLUMN', @level2name = N'sDataID'
GO

-- ----------------------------
-- Records of EHECD_MenuButton
-- ----------------------------
INSERT INTO [dbo].[EHECD_MenuButton] ([ID], [sButtonName], [bIsDeleted], [iOrder], [sIcon], [sDataID]) VALUES (N'BEFACFC7-E5A7-C33E-C038-08D3D4C348A4', N'删除菜单', N'0', N'2', N'icon-remove', N'del_menu_button')
GO
GO
INSERT INTO [dbo].[EHECD_MenuButton] ([ID], [sButtonName], [bIsDeleted], [iOrder], [sIcon], [sDataID]) VALUES (N'1D6C01C3-6346-C07C-5026-08D3D4C35598', N'编辑菜单', N'0', N'1', N'icon-edit', N'edit_menu_button')
GO
GO
INSERT INTO [dbo].[EHECD_MenuButton] ([ID], [sButtonName], [bIsDeleted], [iOrder], [sIcon], [sDataID]) VALUES (N'9C2E9C1A-4EE4-C683-A4D5-08D3D4C5A173', N'查询角色', N'0', N'0', N'icon-search', N'search_role_button')
GO
GO
INSERT INTO [dbo].[EHECD_MenuButton] ([ID], [sButtonName], [bIsDeleted], [iOrder], [sIcon], [sDataID]) VALUES (N'E9F0409C-E979-CC62-02DD-08D3D4C5B3B3', N'新建角色', N'0', N'1', N'icon-add', N'add_role_button')
GO
GO
INSERT INTO [dbo].[EHECD_MenuButton] ([ID], [sButtonName], [bIsDeleted], [iOrder], [sIcon], [sDataID]) VALUES (N'E35156B3-0D4C-C13B-29D3-08D3D4C6A755', N'删除角色', N'0', N'3', N'icon-remove', N'del_role_button')
GO
GO
INSERT INTO [dbo].[EHECD_MenuButton] ([ID], [sButtonName], [bIsDeleted], [iOrder], [sIcon], [sDataID]) VALUES (N'7D5D83C6-EC1C-CC0F-4C08-08D3D4C6D2E4', N'编辑角色', N'0', N'2', N'icon-edit', N'edit_role_button')
GO
GO
INSERT INTO [dbo].[EHECD_MenuButton] ([ID], [sButtonName], [bIsDeleted], [iOrder], [sIcon], [sDataID]) VALUES (N'6F85B3F8-9ACB-CA9B-F84F-08D3D4C74935', N'查询用户', N'0', N'0', N'icon-search', N'search_user_button')
GO
GO
INSERT INTO [dbo].[EHECD_MenuButton] ([ID], [sButtonName], [bIsDeleted], [iOrder], [sIcon], [sDataID]) VALUES (N'7C5CD6FD-9F29-C92D-853E-08D3D4C7605E', N'新建用户', N'0', N'1', N'icon-add', N'add_systemuser_button')
GO
GO
INSERT INTO [dbo].[EHECD_MenuButton] ([ID], [sButtonName], [bIsDeleted], [iOrder], [sIcon], [sDataID]) VALUES (N'B9FDF00F-FC25-CD11-692D-08D3D4C76C31', N'编辑用户', N'0', N'2', N'icon-edit', N'edit_user_button')
GO
GO
INSERT INTO [dbo].[EHECD_MenuButton] ([ID], [sButtonName], [bIsDeleted], [iOrder], [sIcon], [sDataID]) VALUES (N'7335A1B5-368D-CFBC-6B84-08D3D4C777DE', N'删除用户', N'0', N'3', N'icon-remove', N'del_user_button')
GO
GO
INSERT INTO [dbo].[EHECD_MenuButton] ([ID], [sButtonName], [bIsDeleted], [iOrder], [sIcon], [sDataID]) VALUES (N'B4D8AB85-4AB1-CF48-7C6D-08D3D65FC9E1', N'添加按钮', N'0', N'3', N'icon-add', N'add_menubutton_button')
GO
GO
INSERT INTO [dbo].[EHECD_MenuButton] ([ID], [sButtonName], [bIsDeleted], [iOrder], [sIcon], [sDataID]) VALUES (N'4B36B98F-A75A-C43E-752A-08D3D65FF139', N'编辑按钮', N'0', N'4', N'icon-edit', N'edit_menubutton_button')
GO
GO
INSERT INTO [dbo].[EHECD_MenuButton] ([ID], [sButtonName], [bIsDeleted], [iOrder], [sIcon], [sDataID]) VALUES (N'5E31A2B0-402A-CCCD-0045-08D3D661F420', N'111', N'1', N'1', N'icon-edit', N'111')
GO
GO
INSERT INTO [dbo].[EHECD_MenuButton] ([ID], [sButtonName], [bIsDeleted], [iOrder], [sIcon], [sDataID]) VALUES (N'35B593CB-45DD-C6BD-BD16-08D3D661F6B3', N'11', N'1', N'11', N'icon-edit', N'11')
GO
GO
INSERT INTO [dbo].[EHECD_MenuButton] ([ID], [sButtonName], [bIsDeleted], [iOrder], [sIcon], [sDataID]) VALUES (N'683BD737-93EB-C199-28A9-08D3D966521D', N'添加菜单', N'0', N'0', N'icon-add', N'add_menu_button')
GO
GO
INSERT INTO [dbo].[EHECD_MenuButton] ([ID], [sButtonName], [bIsDeleted], [iOrder], [sIcon], [sDataID]) VALUES (N'647BB4C1-CDC3-CC87-5262-08D3D96A9D73', N'删除按钮', N'0', N'5', N'icon-remove', N'del_menubutton_button')
GO
GO
INSERT INTO [dbo].[EHECD_MenuButton] ([ID], [sButtonName], [bIsDeleted], [iOrder], [sIcon], [sDataID]) VALUES (N'203C1D23-2597-CF9F-6D52-08D3D9EDD7F4', N'1', N'1', N'1', N'icon-edit', N'1')
GO
GO
INSERT INTO [dbo].[EHECD_MenuButton] ([ID], [sButtonName], [bIsDeleted], [iOrder], [sIcon], [sDataID]) VALUES (N'4256CB77-8426-C2E1-0A45-08D3D9F9EB9D', N'冻结用户', N'0', N'4', N'icon-filter', N'frozen_systemuser_button')
GO
GO
INSERT INTO [dbo].[EHECD_MenuButton] ([ID], [sButtonName], [bIsDeleted], [iOrder], [sIcon], [sDataID]) VALUES (N'693045DE-EC3D-C8BE-DDD5-08D3DAA99BDA', N'123', N'1', N'123', N'icon-edit', N'123')
GO
GO

-- ----------------------------
-- Table structure for EHECD_Privilege
-- ----------------------------
DROP TABLE [dbo].[EHECD_Privilege]
GO
CREATE TABLE [dbo].[EHECD_Privilege] (
[ID] uniqueidentifier NOT NULL DEFAULT (newid()) ,
[sPrivilegeMaster] varchar(15) NOT NULL DEFAULT '' ,
[sPrivilegeMasterValue] uniqueidentifier NOT NULL DEFAULT (newid()) ,
[sPrivilegeAccess] varchar(15) NOT NULL DEFAULT '' ,
[sPrivilegeAccessValue] uniqueidentifier NOT NULL DEFAULT (newid()) ,
[sBelong] varchar(15) NOT NULL DEFAULT '' ,
[sBelongValue] uniqueidentifier NOT NULL DEFAULT (newid()) ,
[bPrivilegeOperation] bit NOT NULL DEFAULT ((0)) ,
[bIsDeleted] bit NOT NULL DEFAULT ((0)) 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_Privilege', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'该表将记录下某种权限或者某个角色所拥有的特权
   比如 
   xx角色拥有xx菜单
   xx用户拥有xx按钮
   xx角色拥有xx按钮'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_Privilege'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'该表将记录下某种权限或者某个角色所拥有的特权
   比如 
   xx角色拥有xx菜单
   xx用户拥有xx按钮
   xx角色拥有xx按钮'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_Privilege'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_Privilege', 
'COLUMN', N'ID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'唯一标识'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_Privilege'
, @level2type = 'COLUMN', @level2name = N'ID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'唯一标识'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_Privilege'
, @level2type = 'COLUMN', @level2name = N'ID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_Privilege', 
'COLUMN', N'sPrivilegeMaster')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'配置该特权所属的对象
   
   如，
   
   这个特权是属于角色的，那么这个字段表示为role
   这个特权是属于用户的，那么这个字段表示为user'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_Privilege'
, @level2type = 'COLUMN', @level2name = N'sPrivilegeMaster'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'配置该特权所属的对象
   
   如，
   
   这个特权是属于角色的，那么这个字段表示为role
   这个特权是属于用户的，那么这个字段表示为user'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_Privilege'
, @level2type = 'COLUMN', @level2name = N'sPrivilegeMaster'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_Privilege', 
'COLUMN', N'sPrivilegeMasterValue')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'对应的特权所有者的唯一标识
   如特权所有者是role
   则该字段就是记录的对应的特权所有者的ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_Privilege'
, @level2type = 'COLUMN', @level2name = N'sPrivilegeMasterValue'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'对应的特权所有者的唯一标识
   如特权所有者是role
   则该字段就是记录的对应的特权所有者的ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_Privilege'
, @level2type = 'COLUMN', @level2name = N'sPrivilegeMasterValue'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_Privilege', 
'COLUMN', N'sPrivilegeAccess')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'特权类型标识
   该字段标识了这个特权的类型
   比如：
   这是一个菜单特权，则这里用menu来标识
   这是一个按钮特权，则这里用button来标识'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_Privilege'
, @level2type = 'COLUMN', @level2name = N'sPrivilegeAccess'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'特权类型标识
   该字段标识了这个特权的类型
   比如：
   这是一个菜单特权，则这里用menu来标识
   这是一个按钮特权，则这里用button来标识'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_Privilege'
, @level2type = 'COLUMN', @level2name = N'sPrivilegeAccess'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_Privilege', 
'COLUMN', N'sPrivilegeAccessValue')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'对应的特权
   如
   对应的菜单ID
   对应的按钮ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_Privilege'
, @level2type = 'COLUMN', @level2name = N'sPrivilegeAccessValue'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'对应的特权
   如
   对应的菜单ID
   对应的按钮ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_Privilege'
, @level2type = 'COLUMN', @level2name = N'sPrivilegeAccessValue'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_Privilege', 
'COLUMN', N'sBelong')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'标识这个特权所有者的类型
   与特权所属对象对应，以指定这个特权所属的类型
   如，该特权是赋予用户的，则用user来标识
   如，该特权是赋予角色的，则用role来标识'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_Privilege'
, @level2type = 'COLUMN', @level2name = N'sBelong'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'标识这个特权所有者的类型
   与特权所属对象对应，以指定这个特权所属的类型
   如，该特权是赋予用户的，则用user来标识
   如，该特权是赋予角色的，则用role来标识'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_Privilege'
, @level2type = 'COLUMN', @level2name = N'sBelong'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_Privilege', 
'COLUMN', N'sBelongValue')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'标识这个特权是属于哪个的'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_Privilege'
, @level2type = 'COLUMN', @level2name = N'sBelongValue'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'标识这个特权是属于哪个的'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_Privilege'
, @level2type = 'COLUMN', @level2name = N'sBelongValue'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_Privilege', 
'COLUMN', N'bPrivilegeOperation')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否要禁用该特权 0为不禁用 1为禁用'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_Privilege'
, @level2type = 'COLUMN', @level2name = N'bPrivilegeOperation'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否要禁用该特权 0为不禁用 1为禁用'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_Privilege'
, @level2type = 'COLUMN', @level2name = N'bPrivilegeOperation'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_Privilege', 
'COLUMN', N'bIsDeleted')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否删除 0 未删除 1删除'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_Privilege'
, @level2type = 'COLUMN', @level2name = N'bIsDeleted'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否删除 0 未删除 1删除'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_Privilege'
, @level2type = 'COLUMN', @level2name = N'bIsDeleted'
GO

-- ----------------------------
-- Records of EHECD_Privilege
-- ----------------------------
INSERT INTO [dbo].[EHECD_Privilege] ([ID], [sPrivilegeMaster], [sPrivilegeMasterValue], [sPrivilegeAccess], [sPrivilegeAccessValue], [sBelong], [sBelongValue], [bPrivilegeOperation], [bIsDeleted]) VALUES (N'059BDEB5-55C4-479D-9D15-03040B30C866', N'role', N'689A7510-70EF-42CD-9AD1-1611B29061D2', N'menu', N'13663269-A6F3-4E97-8546-E6192E61C5AC', N'role', N'893B8FA1-F002-4206-936B-1B357A478B34', N'0', N'0')
GO
GO
INSERT INTO [dbo].[EHECD_Privilege] ([ID], [sPrivilegeMaster], [sPrivilegeMasterValue], [sPrivilegeAccess], [sPrivilegeAccessValue], [sBelong], [sBelongValue], [bPrivilegeOperation], [bIsDeleted]) VALUES (N'03FFD356-44D7-C9DE-C038-08D3D4C348A4', N'menu', N'B138CE7D-048E-4293-AEB5-210F55FCB674', N'button', N'BEFACFC7-E5A7-C33E-C038-08D3D4C348A4', N'menu', N'B138CE7D-048E-4293-AEB5-210F55FCB674', N'0', N'0')
GO
GO
INSERT INTO [dbo].[EHECD_Privilege] ([ID], [sPrivilegeMaster], [sPrivilegeMasterValue], [sPrivilegeAccess], [sPrivilegeAccessValue], [sBelong], [sBelongValue], [bPrivilegeOperation], [bIsDeleted]) VALUES (N'8FC39B5D-3F7E-CD57-5026-08D3D4C35598', N'menu', N'B138CE7D-048E-4293-AEB5-210F55FCB674', N'button', N'1D6C01C3-6346-C07C-5026-08D3D4C35598', N'menu', N'B138CE7D-048E-4293-AEB5-210F55FCB674', N'0', N'0')
GO
GO
INSERT INTO [dbo].[EHECD_Privilege] ([ID], [sPrivilegeMaster], [sPrivilegeMasterValue], [sPrivilegeAccess], [sPrivilegeAccessValue], [sBelong], [sBelongValue], [bPrivilegeOperation], [bIsDeleted]) VALUES (N'D3A5B2C3-DB5A-C265-A4D5-08D3D4C5A173', N'menu', N'13663269-A6F3-4E97-8546-E6192E61C5AC', N'button', N'9C2E9C1A-4EE4-C683-A4D5-08D3D4C5A173', N'menu', N'13663269-A6F3-4E97-8546-E6192E61C5AC', N'0', N'0')
GO
GO
INSERT INTO [dbo].[EHECD_Privilege] ([ID], [sPrivilegeMaster], [sPrivilegeMasterValue], [sPrivilegeAccess], [sPrivilegeAccessValue], [sBelong], [sBelongValue], [bPrivilegeOperation], [bIsDeleted]) VALUES (N'29E73873-6846-C93A-02DD-08D3D4C5B3B3', N'menu', N'13663269-A6F3-4E97-8546-E6192E61C5AC', N'button', N'E9F0409C-E979-CC62-02DD-08D3D4C5B3B3', N'menu', N'13663269-A6F3-4E97-8546-E6192E61C5AC', N'0', N'0')
GO
GO
INSERT INTO [dbo].[EHECD_Privilege] ([ID], [sPrivilegeMaster], [sPrivilegeMasterValue], [sPrivilegeAccess], [sPrivilegeAccessValue], [sBelong], [sBelongValue], [bPrivilegeOperation], [bIsDeleted]) VALUES (N'7012B54D-3AF7-CC55-29D3-08D3D4C6A755', N'menu', N'13663269-A6F3-4E97-8546-E6192E61C5AC', N'button', N'E35156B3-0D4C-C13B-29D3-08D3D4C6A755', N'menu', N'13663269-A6F3-4E97-8546-E6192E61C5AC', N'0', N'0')
GO
GO
INSERT INTO [dbo].[EHECD_Privilege] ([ID], [sPrivilegeMaster], [sPrivilegeMasterValue], [sPrivilegeAccess], [sPrivilegeAccessValue], [sBelong], [sBelongValue], [bPrivilegeOperation], [bIsDeleted]) VALUES (N'373F2FF4-078A-C0F3-4C08-08D3D4C6D2E4', N'menu', N'13663269-A6F3-4E97-8546-E6192E61C5AC', N'button', N'7D5D83C6-EC1C-CC0F-4C08-08D3D4C6D2E4', N'menu', N'13663269-A6F3-4E97-8546-E6192E61C5AC', N'0', N'0')
GO
GO
INSERT INTO [dbo].[EHECD_Privilege] ([ID], [sPrivilegeMaster], [sPrivilegeMasterValue], [sPrivilegeAccess], [sPrivilegeAccessValue], [sBelong], [sBelongValue], [bPrivilegeOperation], [bIsDeleted]) VALUES (N'48A024A2-4E4C-C145-F84F-08D3D4C74935', N'menu', N'7E7D35EB-A425-4288-8D0F-9ABEA6EDCEB9', N'button', N'6F85B3F8-9ACB-CA9B-F84F-08D3D4C74935', N'menu', N'7E7D35EB-A425-4288-8D0F-9ABEA6EDCEB9', N'0', N'0')
GO
GO
INSERT INTO [dbo].[EHECD_Privilege] ([ID], [sPrivilegeMaster], [sPrivilegeMasterValue], [sPrivilegeAccess], [sPrivilegeAccessValue], [sBelong], [sBelongValue], [bPrivilegeOperation], [bIsDeleted]) VALUES (N'633E45F9-1218-C4A1-853E-08D3D4C7605E', N'menu', N'7E7D35EB-A425-4288-8D0F-9ABEA6EDCEB9', N'button', N'7C5CD6FD-9F29-C92D-853E-08D3D4C7605E', N'menu', N'7E7D35EB-A425-4288-8D0F-9ABEA6EDCEB9', N'0', N'0')
GO
GO
INSERT INTO [dbo].[EHECD_Privilege] ([ID], [sPrivilegeMaster], [sPrivilegeMasterValue], [sPrivilegeAccess], [sPrivilegeAccessValue], [sBelong], [sBelongValue], [bPrivilegeOperation], [bIsDeleted]) VALUES (N'10907BF1-FCFA-C4FD-692D-08D3D4C76C31', N'menu', N'7E7D35EB-A425-4288-8D0F-9ABEA6EDCEB9', N'button', N'B9FDF00F-FC25-CD11-692D-08D3D4C76C31', N'menu', N'7E7D35EB-A425-4288-8D0F-9ABEA6EDCEB9', N'0', N'0')
GO
GO
INSERT INTO [dbo].[EHECD_Privilege] ([ID], [sPrivilegeMaster], [sPrivilegeMasterValue], [sPrivilegeAccess], [sPrivilegeAccessValue], [sBelong], [sBelongValue], [bPrivilegeOperation], [bIsDeleted]) VALUES (N'BF44696D-F290-C14E-6B84-08D3D4C777DE', N'menu', N'7E7D35EB-A425-4288-8D0F-9ABEA6EDCEB9', N'button', N'7335A1B5-368D-CFBC-6B84-08D3D4C777DE', N'menu', N'7E7D35EB-A425-4288-8D0F-9ABEA6EDCEB9', N'0', N'0')
GO
GO
INSERT INTO [dbo].[EHECD_Privilege] ([ID], [sPrivilegeMaster], [sPrivilegeMasterValue], [sPrivilegeAccess], [sPrivilegeAccessValue], [sBelong], [sBelongValue], [bPrivilegeOperation], [bIsDeleted]) VALUES (N'35C3F5F7-CB16-CD83-7C6D-08D3D65FC9E1', N'menu', N'B138CE7D-048E-4293-AEB5-210F55FCB674', N'button', N'B4D8AB85-4AB1-CF48-7C6D-08D3D65FC9E1', N'menu', N'B138CE7D-048E-4293-AEB5-210F55FCB674', N'0', N'0')
GO
GO
INSERT INTO [dbo].[EHECD_Privilege] ([ID], [sPrivilegeMaster], [sPrivilegeMasterValue], [sPrivilegeAccess], [sPrivilegeAccessValue], [sBelong], [sBelongValue], [bPrivilegeOperation], [bIsDeleted]) VALUES (N'755D0FA1-3780-CB42-752A-08D3D65FF139', N'menu', N'B138CE7D-048E-4293-AEB5-210F55FCB674', N'button', N'4B36B98F-A75A-C43E-752A-08D3D65FF139', N'menu', N'B138CE7D-048E-4293-AEB5-210F55FCB674', N'0', N'0')
GO
GO
INSERT INTO [dbo].[EHECD_Privilege] ([ID], [sPrivilegeMaster], [sPrivilegeMasterValue], [sPrivilegeAccess], [sPrivilegeAccessValue], [sBelong], [sBelongValue], [bPrivilegeOperation], [bIsDeleted]) VALUES (N'8266DA8F-81BC-CB26-0045-08D3D661F420', N'menu', N'FB2A6AC6-BBD2-C82C-7304-08D3D661E166', N'button', N'5E31A2B0-402A-CCCD-0045-08D3D661F420', N'menu', N'FB2A6AC6-BBD2-C82C-7304-08D3D661E166', N'0', N'1')
GO
GO
INSERT INTO [dbo].[EHECD_Privilege] ([ID], [sPrivilegeMaster], [sPrivilegeMasterValue], [sPrivilegeAccess], [sPrivilegeAccessValue], [sBelong], [sBelongValue], [bPrivilegeOperation], [bIsDeleted]) VALUES (N'86445FEE-02D9-C23F-BD16-08D3D661F6B3', N'menu', N'FB2A6AC6-BBD2-C82C-7304-08D3D661E166', N'button', N'35B593CB-45DD-C6BD-BD16-08D3D661F6B3', N'menu', N'FB2A6AC6-BBD2-C82C-7304-08D3D661E166', N'0', N'1')
GO
GO
INSERT INTO [dbo].[EHECD_Privilege] ([ID], [sPrivilegeMaster], [sPrivilegeMasterValue], [sPrivilegeAccess], [sPrivilegeAccessValue], [sBelong], [sBelongValue], [bPrivilegeOperation], [bIsDeleted]) VALUES (N'BBBE4050-D5DA-CA3E-28A9-08D3D966521D', N'menu', N'B138CE7D-048E-4293-AEB5-210F55FCB674', N'button', N'683BD737-93EB-C199-28A9-08D3D966521D', N'menu', N'B138CE7D-048E-4293-AEB5-210F55FCB674', N'0', N'0')
GO
GO
INSERT INTO [dbo].[EHECD_Privilege] ([ID], [sPrivilegeMaster], [sPrivilegeMasterValue], [sPrivilegeAccess], [sPrivilegeAccessValue], [sBelong], [sBelongValue], [bPrivilegeOperation], [bIsDeleted]) VALUES (N'7A5C92B3-8BDA-C5FF-5262-08D3D96A9D73', N'menu', N'B138CE7D-048E-4293-AEB5-210F55FCB674', N'button', N'647BB4C1-CDC3-CC87-5262-08D3D96A9D73', N'menu', N'B138CE7D-048E-4293-AEB5-210F55FCB674', N'0', N'0')
GO
GO
INSERT INTO [dbo].[EHECD_Privilege] ([ID], [sPrivilegeMaster], [sPrivilegeMasterValue], [sPrivilegeAccess], [sPrivilegeAccessValue], [sBelong], [sBelongValue], [bPrivilegeOperation], [bIsDeleted]) VALUES (N'136F7099-9CDD-CA7E-6D52-08D3D9EDD7F4', N'menu', N'75A5C98A-EBC9-C2D8-394F-08D3D94C6D0E', N'button', N'203C1D23-2597-CF9F-6D52-08D3D9EDD7F4', N'menu', N'75A5C98A-EBC9-C2D8-394F-08D3D94C6D0E', N'0', N'1')
GO
GO
INSERT INTO [dbo].[EHECD_Privilege] ([ID], [sPrivilegeMaster], [sPrivilegeMasterValue], [sPrivilegeAccess], [sPrivilegeAccessValue], [sBelong], [sBelongValue], [bPrivilegeOperation], [bIsDeleted]) VALUES (N'9D30C754-D042-CAA7-0A45-08D3D9F9EB9D', N'menu', N'7E7D35EB-A425-4288-8D0F-9ABEA6EDCEB9', N'button', N'4256CB77-8426-C2E1-0A45-08D3D9F9EB9D', N'menu', N'7E7D35EB-A425-4288-8D0F-9ABEA6EDCEB9', N'0', N'0')
GO
GO
INSERT INTO [dbo].[EHECD_Privilege] ([ID], [sPrivilegeMaster], [sPrivilegeMasterValue], [sPrivilegeAccess], [sPrivilegeAccessValue], [sBelong], [sBelongValue], [bPrivilegeOperation], [bIsDeleted]) VALUES (N'225D646C-F166-CBAD-DDD5-08D3DAA99BDA', N'menu', N'F4E60D2B-114E-CAC7-8F95-08D3DAA99768', N'button', N'693045DE-EC3D-C8BE-DDD5-08D3DAA99BDA', N'menu', N'F4E60D2B-114E-CAC7-8F95-08D3DAA99768', N'0', N'1')
GO
GO
INSERT INTO [dbo].[EHECD_Privilege] ([ID], [sPrivilegeMaster], [sPrivilegeMasterValue], [sPrivilegeAccess], [sPrivilegeAccessValue], [sBelong], [sBelongValue], [bPrivilegeOperation], [bIsDeleted]) VALUES (N'EAC133FA-BF88-4361-A98A-435D701A528D', N'role', N'689A7510-70EF-42CD-9AD1-1611B29061D2', N'menu', N'7E7D35EB-A425-4288-8D0F-9ABEA6EDCEB9', N'role', N'893B8FA1-F002-4206-936B-1B357A478B34', N'0', N'0')
GO
GO
INSERT INTO [dbo].[EHECD_Privilege] ([ID], [sPrivilegeMaster], [sPrivilegeMasterValue], [sPrivilegeAccess], [sPrivilegeAccessValue], [sBelong], [sBelongValue], [bPrivilegeOperation], [bIsDeleted]) VALUES (N'0A8B88D7-F018-4C3F-94AD-8B98383345B3', N'role', N'689A7510-70EF-42CD-9AD1-1611B29061D2', N'menu', N'A04BADFD-4F07-46BD-9816-A71EC4776B84', N'role', N'893B8FA1-F002-4206-936B-1B357A478B34', N'0', N'0')
GO
GO
INSERT INTO [dbo].[EHECD_Privilege] ([ID], [sPrivilegeMaster], [sPrivilegeMasterValue], [sPrivilegeAccess], [sPrivilegeAccessValue], [sBelong], [sBelongValue], [bPrivilegeOperation], [bIsDeleted]) VALUES (N'603FFF0B-C037-467D-99AA-AD2DF817C2AE', N'role', N'689A7510-70EF-42CD-9AD1-1611B29061D2', N'menu', N'B138CE7D-048E-4293-AEB5-210F55FCB674', N'role', N'893B8FA1-F002-4206-936B-1B357A478B34', N'0', N'0')
GO
GO

-- ----------------------------
-- Table structure for EHECD_Role
-- ----------------------------
DROP TABLE [dbo].[EHECD_Role]
GO
CREATE TABLE [dbo].[EHECD_Role] (
[ID] uniqueidentifier NOT NULL DEFAULT (newid()) ,
[sRoleName] nvarchar(20) NOT NULL DEFAULT '' ,
[bEnable] bit NOT NULL DEFAULT ((0)) ,
[dCreateTime] datetime NOT NULL DEFAULT (getdate()) ,
[dModifyTime] datetime NOT NULL DEFAULT (getdate()) ,
[bIsDeleted] bit NOT NULL DEFAULT ((0)) ,
[iOrder] int NOT NULL DEFAULT ((0)) 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_Role', 
'COLUMN', N'ID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'唯一标识'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_Role'
, @level2type = 'COLUMN', @level2name = N'ID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'唯一标识'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_Role'
, @level2type = 'COLUMN', @level2name = N'ID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_Role', 
'COLUMN', N'sRoleName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'角色名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_Role'
, @level2type = 'COLUMN', @level2name = N'sRoleName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'角色名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_Role'
, @level2type = 'COLUMN', @level2name = N'sRoleName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_Role', 
'COLUMN', N'bEnable')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否可用'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_Role'
, @level2type = 'COLUMN', @level2name = N'bEnable'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否可用'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_Role'
, @level2type = 'COLUMN', @level2name = N'bEnable'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_Role', 
'COLUMN', N'dCreateTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_Role'
, @level2type = 'COLUMN', @level2name = N'dCreateTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_Role'
, @level2type = 'COLUMN', @level2name = N'dCreateTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_Role', 
'COLUMN', N'dModifyTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'修改时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_Role'
, @level2type = 'COLUMN', @level2name = N'dModifyTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'修改时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_Role'
, @level2type = 'COLUMN', @level2name = N'dModifyTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_Role', 
'COLUMN', N'bIsDeleted')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否删除'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_Role'
, @level2type = 'COLUMN', @level2name = N'bIsDeleted'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否删除'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_Role'
, @level2type = 'COLUMN', @level2name = N'bIsDeleted'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_Role', 
'COLUMN', N'iOrder')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'排序编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_Role'
, @level2type = 'COLUMN', @level2name = N'iOrder'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'排序编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_Role'
, @level2type = 'COLUMN', @level2name = N'iOrder'
GO

-- ----------------------------
-- Records of EHECD_Role
-- ----------------------------
INSERT INTO [dbo].[EHECD_Role] ([ID], [sRoleName], [bEnable], [dCreateTime], [dModifyTime], [bIsDeleted], [iOrder]) VALUES (N'D1F76ABD-EC5E-C725-044C-08D3D5959E35', N'测试角色', N'1', N'2016-09-05 22:04:57.000', N'2016-09-05 22:41:28.000', N'0', N'3')
GO
GO
INSERT INTO [dbo].[EHECD_Role] ([ID], [sRoleName], [bEnable], [dCreateTime], [dModifyTime], [bIsDeleted], [iOrder]) VALUES (N'D7DF1C18-5A22-C377-831A-08D3D595BFE5', N'测试角色', N'1', N'2016-09-05 22:05:53.000', N'2016-09-06 22:37:40.000', N'0', N'1')
GO
GO
INSERT INTO [dbo].[EHECD_Role] ([ID], [sRoleName], [bEnable], [dCreateTime], [dModifyTime], [bIsDeleted], [iOrder]) VALUES (N'689A7510-70EF-42CD-9AD1-1611B29061D2', N'管理员', N'1', N'2016-08-28 08:41:35.003', N'2016-08-28 08:41:35.003', N'0', N'0')
GO
GO

-- ----------------------------
-- Table structure for EHECD_SystemUser
-- ----------------------------
DROP TABLE [dbo].[EHECD_SystemUser]
GO
CREATE TABLE [dbo].[EHECD_SystemUser] (
[ID] uniqueidentifier NOT NULL DEFAULT (newid()) ,
[sLoginName] nvarchar(20) NOT NULL DEFAULT '' ,
[sPassWord] nvarchar(50) NOT NULL DEFAULT '' ,
[sUserName] nvarchar(15) NOT NULL DEFAULT '' ,
[tUserState] tinyint NOT NULL DEFAULT ((0)) ,
[tUserType] tinyint NOT NULL DEFAULT ((0)) ,
[sUserNickName] nvarchar(20) NOT NULL DEFAULT '' ,
[dCreateTime] datetime NOT NULL DEFAULT (getdate()) ,
[dLastLoginTime] datetime NOT NULL DEFAULT (getdate()) ,
[sProvice] nvarchar(20) NOT NULL DEFAULT '' ,
[sCity] nvarchar(20) NOT NULL DEFAULT '' ,
[sCounty] nvarchar(20) NOT NULL DEFAULT '' ,
[sAddress] nvarchar(30) NOT NULL DEFAULT '' ,
[tSex] tinyint NOT NULL DEFAULT ((0)) ,
[bIsDeleted] bit NOT NULL DEFAULT ((0)) ,
[sMobileNum] nvarchar(25) NOT NULL DEFAULT '' 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_SystemUser', 
'COLUMN', N'ID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'唯一标识'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser'
, @level2type = 'COLUMN', @level2name = N'ID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'唯一标识'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser'
, @level2type = 'COLUMN', @level2name = N'ID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_SystemUser', 
'COLUMN', N'sLoginName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'登录名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser'
, @level2type = 'COLUMN', @level2name = N'sLoginName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'登录名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser'
, @level2type = 'COLUMN', @level2name = N'sLoginName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_SystemUser', 
'COLUMN', N'sPassWord')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'登录密码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser'
, @level2type = 'COLUMN', @level2name = N'sPassWord'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'登录密码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser'
, @level2type = 'COLUMN', @level2name = N'sPassWord'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_SystemUser', 
'COLUMN', N'sUserName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户姓名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser'
, @level2type = 'COLUMN', @level2name = N'sUserName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户姓名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser'
, @level2type = 'COLUMN', @level2name = N'sUserName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_SystemUser', 
'COLUMN', N'tUserState')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户状态'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser'
, @level2type = 'COLUMN', @level2name = N'tUserState'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户状态'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser'
, @level2type = 'COLUMN', @level2name = N'tUserState'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_SystemUser', 
'COLUMN', N'tUserType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户类型'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser'
, @level2type = 'COLUMN', @level2name = N'tUserType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户类型'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser'
, @level2type = 'COLUMN', @level2name = N'tUserType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_SystemUser', 
'COLUMN', N'sUserNickName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户昵称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser'
, @level2type = 'COLUMN', @level2name = N'sUserNickName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户昵称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser'
, @level2type = 'COLUMN', @level2name = N'sUserNickName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_SystemUser', 
'COLUMN', N'dCreateTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser'
, @level2type = 'COLUMN', @level2name = N'dCreateTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser'
, @level2type = 'COLUMN', @level2name = N'dCreateTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_SystemUser', 
'COLUMN', N'dLastLoginTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'最后登录时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser'
, @level2type = 'COLUMN', @level2name = N'dLastLoginTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'最后登录时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser'
, @level2type = 'COLUMN', @level2name = N'dLastLoginTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_SystemUser', 
'COLUMN', N'sProvice')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'所在省'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser'
, @level2type = 'COLUMN', @level2name = N'sProvice'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'所在省'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser'
, @level2type = 'COLUMN', @level2name = N'sProvice'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_SystemUser', 
'COLUMN', N'sCity')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'所在市'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser'
, @level2type = 'COLUMN', @level2name = N'sCity'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'所在市'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser'
, @level2type = 'COLUMN', @level2name = N'sCity'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_SystemUser', 
'COLUMN', N'sCounty')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'所在地区'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser'
, @level2type = 'COLUMN', @level2name = N'sCounty'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'所在地区'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser'
, @level2type = 'COLUMN', @level2name = N'sCounty'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_SystemUser', 
'COLUMN', N'sAddress')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'详细地址'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser'
, @level2type = 'COLUMN', @level2name = N'sAddress'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'详细地址'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser'
, @level2type = 'COLUMN', @level2name = N'sAddress'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_SystemUser', 
'COLUMN', N'tSex')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'性别'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser'
, @level2type = 'COLUMN', @level2name = N'tSex'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'性别'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser'
, @level2type = 'COLUMN', @level2name = N'tSex'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_SystemUser', 
'COLUMN', N'bIsDeleted')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否删除'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser'
, @level2type = 'COLUMN', @level2name = N'bIsDeleted'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否删除'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser'
, @level2type = 'COLUMN', @level2name = N'bIsDeleted'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_SystemUser', 
'COLUMN', N'sMobileNum')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'手机号码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser'
, @level2type = 'COLUMN', @level2name = N'sMobileNum'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'手机号码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser'
, @level2type = 'COLUMN', @level2name = N'sMobileNum'
GO

-- ----------------------------
-- Records of EHECD_SystemUser
-- ----------------------------
INSERT INTO [dbo].[EHECD_SystemUser] ([ID], [sLoginName], [sPassWord], [sUserName], [tUserState], [tUserType], [sUserNickName], [dCreateTime], [dLastLoginTime], [sProvice], [sCity], [sCounty], [sAddress], [tSex], [bIsDeleted], [sMobileNum]) VALUES (N'893B8FA1-F002-4206-936B-1B357A478B34', N'admin', N'202cb962ac59075b964b07152d234b70', N'管理员', N'0', N'0', N'超级管理员', N'2016-08-28 08:39:33.260', N'2016-08-28 08:39:33.260', N'四川省', N'成都', N'青羊区', N'光华中心', N'0', N'0', N'13888888888')
GO
GO

-- ----------------------------
-- Table structure for EHECD_SystemUser_R_Role
-- ----------------------------
DROP TABLE [dbo].[EHECD_SystemUser_R_Role]
GO
CREATE TABLE [dbo].[EHECD_SystemUser_R_Role] (
[ID] uniqueidentifier NOT NULL DEFAULT (newid()) ,
[sUserID] uniqueidentifier NOT NULL DEFAULT (newid()) ,
[sRoleID] uniqueidentifier NOT NULL DEFAULT (newid()) ,
[bIsDeleted] bit NOT NULL DEFAULT ((0)) 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_SystemUser_R_Role', 
'COLUMN', N'ID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'唯一标识'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser_R_Role'
, @level2type = 'COLUMN', @level2name = N'ID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'唯一标识'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser_R_Role'
, @level2type = 'COLUMN', @level2name = N'ID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_SystemUser_R_Role', 
'COLUMN', N'sUserID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户的ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser_R_Role'
, @level2type = 'COLUMN', @level2name = N'sUserID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户的ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser_R_Role'
, @level2type = 'COLUMN', @level2name = N'sUserID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_SystemUser_R_Role', 
'COLUMN', N'sRoleID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'角色的ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser_R_Role'
, @level2type = 'COLUMN', @level2name = N'sRoleID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'角色的ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser_R_Role'
, @level2type = 'COLUMN', @level2name = N'sRoleID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'EHECD_SystemUser_R_Role', 
'COLUMN', N'bIsDeleted')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否删除'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser_R_Role'
, @level2type = 'COLUMN', @level2name = N'bIsDeleted'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否删除'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'EHECD_SystemUser_R_Role'
, @level2type = 'COLUMN', @level2name = N'bIsDeleted'
GO

-- ----------------------------
-- Records of EHECD_SystemUser_R_Role
-- ----------------------------
INSERT INTO [dbo].[EHECD_SystemUser_R_Role] ([ID], [sUserID], [sRoleID], [bIsDeleted]) VALUES (N'B31E707A-E0B1-4C70-A058-9BEF67656ADB', N'893B8FA1-F002-4206-936B-1B357A478B34', N'689A7510-70EF-42CD-9AD1-1611B29061D2', N'0')
GO
GO

-- ----------------------------
-- Indexes structure for table EHECD_FunctionMenu
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table EHECD_FunctionMenu
-- ----------------------------
ALTER TABLE [dbo].[EHECD_FunctionMenu] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Checks structure for table EHECD_FunctionMenu
-- ----------------------------
ALTER TABLE [dbo].[EHECD_FunctionMenu] ADD CHECK (([bIsDeleted]>=(0) AND [bIsDeleted]<=(1)))
GO

-- ----------------------------
-- Indexes structure for table EHECD_MenuButton
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table EHECD_MenuButton
-- ----------------------------
ALTER TABLE [dbo].[EHECD_MenuButton] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Checks structure for table EHECD_MenuButton
-- ----------------------------
ALTER TABLE [dbo].[EHECD_MenuButton] ADD CHECK (([bIsDeleted]>=(0) AND [bIsDeleted]<=(1)))
GO

-- ----------------------------
-- Indexes structure for table EHECD_Privilege
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table EHECD_Privilege
-- ----------------------------
ALTER TABLE [dbo].[EHECD_Privilege] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Checks structure for table EHECD_Privilege
-- ----------------------------
ALTER TABLE [dbo].[EHECD_Privilege] ADD CHECK (([bIsDeleted]>=(0) AND [bIsDeleted]<=(1)))
GO

-- ----------------------------
-- Indexes structure for table EHECD_Role
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table EHECD_Role
-- ----------------------------
ALTER TABLE [dbo].[EHECD_Role] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Checks structure for table EHECD_Role
-- ----------------------------
ALTER TABLE [dbo].[EHECD_Role] ADD CHECK (([bIsDeleted]>=(0) AND [bIsDeleted]<=(1)))
GO

-- ----------------------------
-- Indexes structure for table EHECD_SystemUser
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table EHECD_SystemUser
-- ----------------------------
ALTER TABLE [dbo].[EHECD_SystemUser] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Checks structure for table EHECD_SystemUser
-- ----------------------------
ALTER TABLE [dbo].[EHECD_SystemUser] ADD CHECK (([tUserState]>=(0) AND [tUserState]<=(10)))
GO
ALTER TABLE [dbo].[EHECD_SystemUser] ADD CHECK (([tUserType]>=(0) AND [tUserType]<=(10)))
GO
ALTER TABLE [dbo].[EHECD_SystemUser] ADD CHECK (([tSex]>=(0) AND [tSex]<=(60)))
GO

-- ----------------------------
-- Indexes structure for table EHECD_SystemUser_R_Role
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table EHECD_SystemUser_R_Role
-- ----------------------------
ALTER TABLE [dbo].[EHECD_SystemUser_R_Role] ADD PRIMARY KEY ([ID])
GO
