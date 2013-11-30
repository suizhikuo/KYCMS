/*
Navicat SQL Server Data Transfer

Source Server         : 1921680159sql2005
Source Server Version : 90000
Source Host           : 192.168.0.159\sql2005:1433
Source Database       : KyCms
Source Schema         : dbo

Target Server Type    : SQL Server
Target Server Version : 90000
File Encoding         : 65001

Date: 2013-11-27 10:31:15
*/


-- ----------------------------
-- Table structure for dtproperties
-- ----------------------------
DROP TABLE [dbo].[dtproperties]
GO
CREATE TABLE [dbo].[dtproperties] (
[id] int NOT NULL IDENTITY(1,1) ,
[objectid] int NULL ,
[property] varchar(64) NOT NULL ,
[value] varchar(255) NULL ,
[uvalue] nvarchar(255) NULL ,
[lvalue] image NULL ,
[version] int NOT NULL DEFAULT (0) 
)


GO

-- ----------------------------
-- Records of dtproperties
-- ----------------------------
SET IDENTITY_INSERT [dbo].[dtproperties] ON
GO
SET IDENTITY_INSERT [dbo].[dtproperties] OFF
GO

-- ----------------------------
-- Table structure for Ky_User_Business
-- ----------------------------
DROP TABLE [dbo].[Ky_User_Business]
GO
CREATE TABLE [dbo].[Ky_User_Business] (
[Id] int NOT NULL IDENTITY(1,1) ,
[UId] int NULL ,
[AddTime] datetime NULL ,
[UpdateTime] datetime NULL ,
[Industry] nvarchar(100) NULL DEFAULT '' ,
[Capital] nvarchar(100) NULL DEFAULT '' ,
[EmployNumber] nvarchar(100) NULL DEFAULT ('5') ,
[LegalPerson] nvarchar(100) NULL DEFAULT '' ,
[License] nvarchar(100) NULL DEFAULT '' ,
[TaxCertificates] nvarchar(100) NULL DEFAULT '' ,
[OtherCertificates] nvarchar(100) NULL DEFAULT '' ,
[ContactPersonal] nvarchar(100) NULL DEFAULT '' ,
[Telephone] nvarchar(100) NULL DEFAULT '' ,
[CompanyEmail] nvarchar(100) NULL DEFAULT '' ,
[Fax] nvarchar(100) NULL DEFAULT '' ,
[Address] nvarchar(100) NULL DEFAULT '' ,
[Zip] int NULL ,
[HomePage] nvarchar(100) NULL DEFAULT '' ,
[LOGO] nvarchar(100) NULL DEFAULT '' ,
[Introduce] ntext NULL ,
[name] nvarchar(100) NULL DEFAULT '' ,
[lx] nvarchar(100) NULL DEFAULT '' 
)


GO

-- ----------------------------
-- Records of Ky_User_Business
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Ky_User_Business] ON
GO
SET IDENTITY_INSERT [dbo].[Ky_User_Business] OFF
GO

-- ----------------------------
-- Table structure for Ky_User_Personal
-- ----------------------------
DROP TABLE [dbo].[Ky_User_Personal]
GO
CREATE TABLE [dbo].[Ky_User_Personal] (
[Id] int NOT NULL IDENTITY(1,1) ,
[UId] int NULL ,
[AddTime] datetime NULL ,
[UpdateTime] datetime NULL ,
[Sex] nvarchar(100) NULL DEFAULT ('保密') ,
[TrueName] nvarchar(100) NULL DEFAULT '' ,
[area_Id] int NULL ,
[area] nvarchar(100) NULL DEFAULT '' ,
[Geographical_Id] int NULL ,
[Geographical] nvarchar(100) NULL DEFAULT '' ,
[Address] nvarchar(100) NULL DEFAULT '' ,
[Phone] nvarchar(100) NULL DEFAULT '' ,
[qq] int NULL ,
[Email] nvarchar(100) NULL DEFAULT '' ,
[Picture] nvarchar(100) NULL DEFAULT '' 
)


GO

-- ----------------------------
-- Records of Ky_User_Personal
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Ky_User_Personal] ON
GO
SET IDENTITY_INSERT [dbo].[Ky_User_Personal] OFF
GO

-- ----------------------------
-- Table structure for KyAd
-- ----------------------------
DROP TABLE [dbo].[KyAd]
GO
CREATE TABLE [dbo].[KyAd] (
[AdId] int NOT NULL IDENTITY(1,1) ,
[CategoryId] varchar(100) NULL ,
[AdName] nvarchar(50) NULL DEFAULT '' ,
[AdType] int NULL DEFAULT (1) ,
[Content] nvarchar(1000) NULL ,
[EndTime] datetime NULL DEFAULT (getdate()) ,
[Weight] int NULL DEFAULT (10) ,
[HitCount] int NULL DEFAULT (0) 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyAd', 
'COLUMN', N'AdId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'广告编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyAd'
, @level2type = 'COLUMN', @level2name = N'AdId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'广告编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyAd'
, @level2type = 'COLUMN', @level2name = N'AdId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyAd', 
'COLUMN', N'CategoryId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'所属广告位编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyAd'
, @level2type = 'COLUMN', @level2name = N'CategoryId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'所属广告位编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyAd'
, @level2type = 'COLUMN', @level2name = N'CategoryId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyAd', 
'COLUMN', N'AdName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'广告名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyAd'
, @level2type = 'COLUMN', @level2name = N'AdName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'广告名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyAd'
, @level2type = 'COLUMN', @level2name = N'AdName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyAd', 
'COLUMN', N'AdType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'广告类型 1图片 2Flash 3纯文本 4代码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyAd'
, @level2type = 'COLUMN', @level2name = N'AdType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'广告类型 1图片 2Flash 3纯文本 4代码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyAd'
, @level2type = 'COLUMN', @level2name = N'AdType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyAd', 
'COLUMN', N'Content')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'广告内容 存放广告显示数据.比如如果是图片则包含图片的宽高,提示,URL,打开方式等'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyAd'
, @level2type = 'COLUMN', @level2name = N'Content'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'广告内容 存放广告显示数据.比如如果是图片则包含图片的宽高,提示,URL,打开方式等'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyAd'
, @level2type = 'COLUMN', @level2name = N'Content'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyAd', 
'COLUMN', N'EndTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'显示截至日期'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyAd'
, @level2type = 'COLUMN', @level2name = N'EndTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'显示截至日期'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyAd'
, @level2type = 'COLUMN', @level2name = N'EndTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyAd', 
'COLUMN', N'Weight')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'权重 值越大,显示几率越高'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyAd'
, @level2type = 'COLUMN', @level2name = N'Weight'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'权重 值越大,显示几率越高'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyAd'
, @level2type = 'COLUMN', @level2name = N'Weight'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyAd', 
'COLUMN', N'HitCount')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'点击次数'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyAd'
, @level2type = 'COLUMN', @level2name = N'HitCount'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'点击次数'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyAd'
, @level2type = 'COLUMN', @level2name = N'HitCount'
GO

-- ----------------------------
-- Records of KyAd
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyAd] ON
GO
SET IDENTITY_INSERT [dbo].[KyAd] OFF
GO

-- ----------------------------
-- Table structure for KyAdCategory
-- ----------------------------
DROP TABLE [dbo].[KyAdCategory]
GO
CREATE TABLE [dbo].[KyAdCategory] (
[AdCategoryId] int NOT NULL IDENTITY(1,1) ,
[CategoryName] nvarchar(50) NULL ,
[IsDisabled] int NULL DEFAULT (1) ,
[WidthHeigth] varchar(12) NULL DEFAULT (468 | 60) ,
[DisplayType] int NULL DEFAULT (1) ,
[Description] nvarchar(50) NULL DEFAULT '' 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyAdCategory]', RESEED, 4)
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyAdCategory', 
'COLUMN', N'AdCategoryId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'广告位ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyAdCategory'
, @level2type = 'COLUMN', @level2name = N'AdCategoryId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'广告位ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyAdCategory'
, @level2type = 'COLUMN', @level2name = N'AdCategoryId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyAdCategory', 
'COLUMN', N'CategoryName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'广告位名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyAdCategory'
, @level2type = 'COLUMN', @level2name = N'CategoryName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'广告位名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyAdCategory'
, @level2type = 'COLUMN', @level2name = N'CategoryName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyAdCategory', 
'COLUMN', N'IsDisabled')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否禁用 1正常 2禁用'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyAdCategory'
, @level2type = 'COLUMN', @level2name = N'IsDisabled'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否禁用 1正常 2禁用'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyAdCategory'
, @level2type = 'COLUMN', @level2name = N'IsDisabled'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyAdCategory', 
'COLUMN', N'WidthHeigth')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'宽高'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyAdCategory'
, @level2type = 'COLUMN', @level2name = N'WidthHeigth'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'宽高'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyAdCategory'
, @level2type = 'COLUMN', @level2name = N'WidthHeigth'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyAdCategory', 
'COLUMN', N'DisplayType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'显示方式 1矩形横幅 2对联 3随屏移动 4随机浮动 5版位广告'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyAdCategory'
, @level2type = 'COLUMN', @level2name = N'DisplayType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'显示方式 1矩形横幅 2对联 3随屏移动 4随机浮动 5版位广告'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyAdCategory'
, @level2type = 'COLUMN', @level2name = N'DisplayType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyAdCategory', 
'COLUMN', N'Description')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'广告位描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyAdCategory'
, @level2type = 'COLUMN', @level2name = N'Description'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'广告位描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyAdCategory'
, @level2type = 'COLUMN', @level2name = N'Description'
GO

-- ----------------------------
-- Records of KyAdCategory
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyAdCategory] ON
GO
SET IDENTITY_INSERT [dbo].[KyAdCategory] OFF
GO

-- ----------------------------
-- Table structure for KyAdmin
-- ----------------------------
DROP TABLE [dbo].[KyAdmin]
GO
CREATE TABLE [dbo].[KyAdmin] (
[UserId] int NOT NULL IDENTITY(1,1) ,
[LoginName] nvarchar(20) NULL ,
[UserName] nvarchar(20) NULL ,
[Password] varchar(200) NULL ,
[LastLoginIP] varchar(11) NULL ,
[LastLoginTime] datetime NULL ,
[LastLogoutTime] datetime NULL ,
[LoginTime] int NULL DEFAULT (0) ,
[AllowMultiLogin] bit NULL DEFAULT (1) ,
[CheckCount] int NULL DEFAULT (0) ,
[AddCount] int NULL DEFAULT (0) ,
[RejectCount] int NULL DEFAULT (0) ,
[GroupId] int NULL ,
[GroupName] nvarchar(50) NULL ,
[RandNumber] varchar(30) NULL DEFAULT (0) 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyAdmin]', RESEED, 10)
GO

-- ----------------------------
-- Records of KyAdmin
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyAdmin] ON
GO
INSERT INTO [dbo].[KyAdmin] ([UserId], [LoginName], [UserName], [Password], [LastLoginIP], [LastLoginTime], [LastLogoutTime], [LoginTime], [AllowMultiLogin], [CheckCount], [AddCount], [RejectCount], [GroupId], [GroupName], [RandNumber]) VALUES (N'1', N'admin', N'admin', N'7fef6171469e80d32c0559f88b377245', N'127.0.0.1', N'2008-03-06 16:03:42.280', null, N'538', N'1', N'0', N'0', N'0', N'1', N'超级管理员组', N'77pyibhesm0ohwl1')
GO
GO
INSERT INTO [dbo].[KyAdmin] ([UserId], [LoginName], [UserName], [Password], [LastLoginIP], [LastLoginTime], [LastLogoutTime], [LoginTime], [AllowMultiLogin], [CheckCount], [AddCount], [RejectCount], [GroupId], [GroupName], [RandNumber]) VALUES (N'10', N'51aspx', N'51aspx', N'9ce853eb7ee8e362e1d121eb4df2dc91', N'127.0.0.1', N'2009-06-26 10:07:14.187', null, N'1', N'1', N'0', N'0', N'0', N'1', N'超级管理员组', N'61xn2fv80633ga9q')
GO
GO
SET IDENTITY_INSERT [dbo].[KyAdmin] OFF
GO

-- ----------------------------
-- Table structure for KyAnomaly
-- ----------------------------
DROP TABLE [dbo].[KyAnomaly]
GO
CREATE TABLE [dbo].[KyAnomaly] (
[Id] int NOT NULL IDENTITY(1,1) ,
[InfoId] int NULL ,
[ChId] int NULL ,
[ColName] nvarchar(50) NULL ,
[Title] varchar(200) NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyAnomaly', 
'COLUMN', N'InfoId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'内容Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyAnomaly'
, @level2type = 'COLUMN', @level2name = N'InfoId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'内容Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyAnomaly'
, @level2type = 'COLUMN', @level2name = N'InfoId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyAnomaly', 
'COLUMN', N'ChId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'频道Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyAnomaly'
, @level2type = 'COLUMN', @level2name = N'ChId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'频道Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyAnomaly'
, @level2type = 'COLUMN', @level2name = N'ChId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyAnomaly', 
'COLUMN', N'ColName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'栏目名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyAnomaly'
, @level2type = 'COLUMN', @level2name = N'ColName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'栏目名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyAnomaly'
, @level2type = 'COLUMN', @level2name = N'ColName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyAnomaly', 
'COLUMN', N'Title')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'标题'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyAnomaly'
, @level2type = 'COLUMN', @level2name = N'Title'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'标题'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyAnomaly'
, @level2type = 'COLUMN', @level2name = N'Title'
GO

-- ----------------------------
-- Records of KyAnomaly
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyAnomaly] ON
GO
SET IDENTITY_INSERT [dbo].[KyAnomaly] OFF
GO

-- ----------------------------
-- Table structure for KyArticle
-- ----------------------------
DROP TABLE [dbo].[KyArticle]
GO
CREATE TABLE [dbo].[KyArticle] (
[Id] int NOT NULL IDENTITY(1,1) ,
[ColId] int NOT NULL ,
[Title] nvarchar(200) NULL DEFAULT '' ,
[TitleColor] nvarchar(6) NULL DEFAULT '' ,
[TitleFontType] int NULL DEFAULT '' ,
[TitleType] int NULL DEFAULT (0) ,
[TitleImgPath] varchar(255) NULL DEFAULT '' ,
[UId] int NOT NULL ,
[UName] nvarchar(20) NOT NULL ,
[UserType] int NOT NULL ,
[AdminUId] int NULL ,
[AdminUName] nvarchar(20) NULL DEFAULT '' ,
[Status] int NULL DEFAULT (0) ,
[HitCount] int NULL DEFAULT (0) ,
[AddTime] datetime NOT NULL ,
[UpdateTime] datetime NOT NULL ,
[TemplatePath] varchar(255) NULL DEFAULT '' ,
[PageType] int NULL DEFAULT (1) ,
[IsCreated] bit NULL DEFAULT (0) ,
[UserCateId] int NULL DEFAULT (0) ,
[PointCount] int NULL DEFAULT (0) ,
[ChargeType] int NULL DEFAULT (1) ,
[ChargeHourCount] int NULL DEFAULT (0) ,
[ChargeViewCount] int NULL DEFAULT (0) ,
[IsOpened] int NULL DEFAULT (2) ,
[GroupIdStr] varchar(200) NULL DEFAULT '' ,
[IsDeleted] bit NULL DEFAULT (0) ,
[IsRecommend] bit NULL DEFAULT (0) ,
[IsTop] bit NULL DEFAULT (0) ,
[IsFocus] bit NULL DEFAULT (0) ,
[IsSideShow] bit NULL DEFAULT (0) ,
[IsAllowComment] bit NULL DEFAULT (0) ,
[TagIdStr] varchar(300) NULL DEFAULT '' ,
[TagNameStr] nvarchar(300) NULL DEFAULT '' ,
[SpecialIdStr] varchar(200) NULL DEFAULT '' ,
[LongTitle] nvarchar(500) NULL DEFAULT '' ,
[Content] ntext NULL DEFAULT '' ,
[ShortContent] nvarchar(200) NULL DEFAULT '' ,
[OuterUrl] varchar(255) NULL DEFAULT '' ,
[Author] nvarchar(50) NULL DEFAULT '' ,
[Source] nvarchar(50) NULL DEFAULT '' ,
[IsHeader] bit NULL DEFAULT (0) ,
[HeaderFont] nvarchar(100) NULL DEFAULT '' ,
[HeaderImgPath] varchar(255) NULL DEFAULT '' ,
[StarLevel] nvarchar(50) NULL DEFAULT '' ,
[IsShowCommentLink] bit NULL DEFAULT (0) ,
[IsIrregular] bit NULL DEFAULT (0) ,
[IrregularId] int NULL DEFAULT (0) ,
[ViewUName] ntext NULL DEFAULT '' ,
[ViewUName2] ntext NULL DEFAULT '' ,
[ViewEndTime] nvarchar(20) NULL DEFAULT '' ,
[ExpireTime] datetime NOT NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyArticle]', RESEED, 1794)
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'Id')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'内容编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'Id'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'内容编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'Id'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'ColId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'栏目编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'ColId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'栏目编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'ColId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'Title')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'内容名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'Title'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'内容名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'Title'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'TitleColor')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'标题颜色代码 形如6c6c6c 前面没有#'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'TitleColor'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'标题颜色代码 形如6c6c6c 前面没有#'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'TitleColor'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'TitleFontType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'标题字体类型 0普通 1粗体 2斜体'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'TitleFontType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'标题字体类型 0普通 1粗体 2斜体'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'TitleFontType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'TitleType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'标题类型 1文字标题 2图片标题'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'TitleType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'标题类型 1文字标题 2图片标题'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'TitleType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'TitleImgPath')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'图片标题路径 当为图片标题时必填'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'TitleImgPath'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'图片标题路径 当为图片标题时必填'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'TitleImgPath'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'UId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'录入者编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'UId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'录入者编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'UId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'UName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'录入者名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'UName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'录入者名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'UName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'UserType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'录入者类型  0用户 1管理员'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'UserType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'录入者类型  0用户 1管理员'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'UserType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'AdminUId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'审核者编号/责任编辑编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'AdminUId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'审核者编号/责任编辑编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'AdminUId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'AdminUName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'审核者名称/责任编辑名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'AdminUName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'审核者名称/责任编辑名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'AdminUName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'Status')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'-1草稿 0待审 1一审 2二审 3三审'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'Status'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'-1草稿 0待审 1一审 2二审 3三审'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'Status'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'HitCount')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'点击次数'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'HitCount'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'点击次数'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'HitCount'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'AddTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'添加时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'AddTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'添加时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'AddTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'UpdateTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'最后修改时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'UpdateTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'最后修改时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'UpdateTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'TemplatePath')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'模板路径'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'TemplatePath'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'模板路径'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'TemplatePath'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'PageType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'1 html 2 htm 3 shtml 4 aspx'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'PageType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'1 html 2 htm 3 shtml 4 aspx'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'PageType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'IsCreated')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否已经生成'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'IsCreated'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否已经生成'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'IsCreated'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'UserCateId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户专栏编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'UserCateId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户专栏编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'UserCateId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'PointCount')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'收费金币个数'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'PointCount'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'收费金币个数'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'PointCount'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'ChargeType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'收费方式'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'ChargeType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'收费方式'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'ChargeType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'ChargeHourCount')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'多少小时后重复收费'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'ChargeHourCount'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'多少小时后重复收费'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'ChargeHourCount'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'ChargeViewCount')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'多少次后重复收费'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'ChargeViewCount'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'多少次后重复收费'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'ChargeViewCount'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'IsOpened')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否时开放内容  0认证 1开放 2继承栏目设置'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'IsOpened'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否时开放内容  0认证 1开放 2继承栏目设置'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'IsOpened'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'GroupIdStr')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'认证时允许访问用户组编号串 用 |编号1|编号2| 的形式'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'GroupIdStr'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'认证时允许访问用户组编号串 用 |编号1|编号2| 的形式'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'GroupIdStr'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'IsDeleted')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否被删除到回收站'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'IsDeleted'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否被删除到回收站'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'IsDeleted'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'IsRecommend')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'推荐'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'IsRecommend'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'推荐'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'IsRecommend'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'IsTop')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'置顶'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'IsTop'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'置顶'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'IsTop'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'IsFocus')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'焦点'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'IsFocus'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'焦点'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'IsFocus'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'IsSideShow')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'幻灯'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'IsSideShow'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'幻灯'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'IsSideShow'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'IsAllowComment')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否允许评论'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'IsAllowComment'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否允许评论'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'IsAllowComment'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'TagIdStr')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'关键字编号串'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'TagIdStr'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'关键字编号串'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'TagIdStr'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'TagNameStr')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'关键字名称串 '
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'TagNameStr'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'关键字名称串 '
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'TagNameStr'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'SpecialIdStr')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'专题Id串'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'SpecialIdStr'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'专题Id串'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'SpecialIdStr'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'LongTitle')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'副标题'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'LongTitle'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'副标题'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'LongTitle'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'Content')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'描述信息'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'Content'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'描述信息'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'Content'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'IsHeader')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'头条'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'IsHeader'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'头条'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'IsHeader'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'HeaderFont')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'头条文字和属性'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'HeaderFont'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'头条文字和属性'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'HeaderFont'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'HeaderImgPath')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'图片头条路径'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'HeaderImgPath'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'图片头条路径'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'HeaderImgPath'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'StarLevel')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'评分等级 ★'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'StarLevel'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'评分等级 ★'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'StarLevel'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'IsShowCommentLink')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否标题旁显示评论链接'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'IsShowCommentLink'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否标题旁显示评论链接'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'IsShowCommentLink'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'IsIrregular')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否不规则'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'IsIrregular'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否不规则'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'IsIrregular'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'IrregularId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'不规则新闻所属类别编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'IrregularId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'不规则新闻所属类别编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'IrregularId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'ViewUName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'指定可以阅读该内容的用户串'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'ViewUName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'指定可以阅读该内容的用户串'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'ViewUName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'ViewUName2')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'已经阅读过的用户'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'ViewUName2'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'已经阅读过的用户'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'ViewUName2'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'ViewEndTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'最后签收时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'ViewEndTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'最后签收时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'ViewEndTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyArticle', 
'COLUMN', N'ExpireTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'过期时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'ExpireTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'过期时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyArticle'
, @level2type = 'COLUMN', @level2name = N'ExpireTime'
GO

-- ----------------------------
-- Records of KyArticle
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyArticle] ON
GO
INSERT INTO [dbo].[KyArticle] ([Id], [ColId], [Title], [TitleColor], [TitleFontType], [TitleType], [TitleImgPath], [UId], [UName], [UserType], [AdminUId], [AdminUName], [Status], [HitCount], [AddTime], [UpdateTime], [TemplatePath], [PageType], [IsCreated], [UserCateId], [PointCount], [ChargeType], [ChargeHourCount], [ChargeViewCount], [IsOpened], [GroupIdStr], [IsDeleted], [IsRecommend], [IsTop], [IsFocus], [IsSideShow], [IsAllowComment], [TagIdStr], [TagNameStr], [SpecialIdStr], [LongTitle], [Content], [ShortContent], [OuterUrl], [Author], [Source], [IsHeader], [HeaderFont], [HeaderImgPath], [StarLevel], [IsShowCommentLink], [IsIrregular], [IrregularId], [ViewUName], [ViewUName2], [ViewEndTime], [ExpireTime]) VALUES (N'1792', N'120', N'酷源SP1全开源版源码', N'', N'0', N'1', N'', N'10', N'51aspx', N'1', N'10', N'51aspx', N'3', N'2', N'2009-06-26 10:12:32.170', N'2009-06-26 10:12:32.170', N'/Template/文章/内容页.html', N'1', N'0', N'0', N'0', N'1', N'0', N'0', N'2', N'', N'0', N'0', N'0', N'0', N'0', N'1', N'', N'', N'', N'', N'<p>酷源SP1全开源版源码</p>
<p>酷源CMS内容网站管理系统是基于微软最新的ASP.NET平台开发的一款最优秀的网站管理系统。<br />
利用本系统您可以快捷、便利的搭建起一套功能强大的网站。<br />
酷源CMS拥有包含新闻系统、下载系统、图片系统、供求系统、人才系统、房产系统、会员系统等丰富的功能模块。<br />
酷源CMS原创的自定义模型、自定义表单功能使您无需编程也能够根据自己的特殊需求自定义数据表、自定义字段列名、自定义字段属性值、自定义数据录入界面、自定义数据显示界面。通过酷源CMS独创的自定义条件列表功能，您可以轻松实现以任意字段为条件的列表输出。</p>
<p>酷源V1.0版亮点功能: <br />
1:自定义模型及强大的字段属性设置功能,轻松实现分类信息\房产\人才\供求\小说等模型. <br />
2:异常简易的标签调用模型数据功能,可视化的模板标签编辑界面.您可以通过可视化界面筛选调用任意数据。 <br />
3:强大的自定义表单管理,可以生成订单编号,实现在线预定,后台可设置属性字段,设置多种属性值.</p>
<p>DB_51aspx下为Sql数据库文件，附加即可<br />
默认管理帐号/密码：51aspx/51aspx</p>
<p>数据库配置文件：kycon.config</p>
<p>作者：酷源，发布者：drweb<br />
源码下载及讨论地址：<a href="http://www.51aspx.com/CV/kycms">http://www.51aspx.com/CV/kycms</a></p>', N'', N'', N'', N'', N'0', N'|常规|12px|', N'', N'★★★', N'0', N'0', N'0', N'', N'', N'', N'2009-08-25 00:00:00.000')
GO
GO
INSERT INTO [dbo].[KyArticle] ([Id], [ColId], [Title], [TitleColor], [TitleFontType], [TitleType], [TitleImgPath], [UId], [UName], [UserType], [AdminUId], [AdminUName], [Status], [HitCount], [AddTime], [UpdateTime], [TemplatePath], [PageType], [IsCreated], [UserCateId], [PointCount], [ChargeType], [ChargeHourCount], [ChargeViewCount], [IsOpened], [GroupIdStr], [IsDeleted], [IsRecommend], [IsTop], [IsFocus], [IsSideShow], [IsAllowComment], [TagIdStr], [TagNameStr], [SpecialIdStr], [LongTitle], [Content], [ShortContent], [OuterUrl], [Author], [Source], [IsHeader], [HeaderFont], [HeaderImgPath], [StarLevel], [IsShowCommentLink], [IsIrregular], [IrregularId], [ViewUName], [ViewUName2], [ViewEndTime], [ExpireTime]) VALUES (N'1793', N'121', N'ertwerwerwr23424', N'', N'0', N'1', N'', N'10', N'51aspx', N'1', N'10', N'51aspx', N'3', N'0', N'2009-06-26 10:19:52.483', N'2009-06-26 10:19:52.483', N'/Template/文章/内容页.html', N'1', N'0', N'0', N'0', N'1', N'0', N'0', N'2', N'', N'0', N'0', N'0', N'0', N'0', N'1', N'|1|', N'|test,51aspx|', N'', N'', N'<p>234242424</p>
<p>&nbsp;</p>
<p>sddadaasd</p>', N'', N'', N'', N'', N'0', N'|常规|12px|', N'', N'★★★', N'0', N'0', N'0', N'', N'', N'', N'2009-08-25 00:00:00.000')
GO
GO
INSERT INTO [dbo].[KyArticle] ([Id], [ColId], [Title], [TitleColor], [TitleFontType], [TitleType], [TitleImgPath], [UId], [UName], [UserType], [AdminUId], [AdminUName], [Status], [HitCount], [AddTime], [UpdateTime], [TemplatePath], [PageType], [IsCreated], [UserCateId], [PointCount], [ChargeType], [ChargeHourCount], [ChargeViewCount], [IsOpened], [GroupIdStr], [IsDeleted], [IsRecommend], [IsTop], [IsFocus], [IsSideShow], [IsAllowComment], [TagIdStr], [TagNameStr], [SpecialIdStr], [LongTitle], [Content], [ShortContent], [OuterUrl], [Author], [Source], [IsHeader], [HeaderFont], [HeaderImgPath], [StarLevel], [IsShowCommentLink], [IsIrregular], [IrregularId], [ViewUName], [ViewUName2], [ViewEndTime], [ExpireTime]) VALUES (N'1794', N'121', N'21313131313', N'', N'0', N'1', N'', N'10', N'51aspx', N'1', N'10', N'51aspx', N'3', N'0', N'2009-06-26 10:22:07.173', N'2009-06-26 10:22:07.173', N'/Template/文章/内容页.html', N'1', N'0', N'0', N'0', N'1', N'0', N'0', N'2', N'', N'0', N'0', N'0', N'0', N'0', N'1', N'', N'', N'', N'', N'<p>酷源V1.0版亮点功能: <br />
1:自定义模型及强大的字段属性设置功能,轻松实现分类信息\房产\人才\供求\小说等模型. <br />
2:异常简易的标签调用模型数据功能,可视化的模板标签编辑界面.您可以通过可视化界面筛选调用任意数据。 <br />
3:强大的自定义表单管理,可以生成订单编号,实现在线预定,后台可设置属性字段,设置多种属性值.</p>
<p>DB_51aspx下为Sql数据库文件，附加即可<br />
默认管理帐号/密码：51aspx/51aspx</p>
<p>数据库配置文件：kycon.config</p>
<p>作者：酷源，发布者：drweb<br />
源码下载及讨论地址：<a href="http://www.51aspx.com/CV/KyCms">http://www.51aspx.com/CV/KyCms</a></p>
<p>本源码由51aspx调测并进行注释添加，如需转载请注明作者信息及来源，以示对他人劳动成果的尊重！<br />
获得更有效的技术支持看这里：<a href="http://bbs.51aspx.com/showtopic-7928.html">http://bbs.51aspx.com/showtopic-7928.html</a><u><font color="#810081">酷源V1.0版亮点功能: <br />
1:自定义模型及强大的字段属性设置功能,轻松实现分类信息\房产\人才\供求\小说等模型. <br />
2:异常简易的标签调用模型数据功能,可视化的模板标签编辑界面.您可以通过可视化界面筛选调用任意数据。 <br />
3:强大的自定义表单管理,可以生成订单编号,实现在线预定,后台可设置属性字段,设置多种属性值.</font></u></p>
<p><u><font color="#810081">DB_51aspx下为Sql数据库文件，附加即可<br />
默认管理帐号/密码：51aspx/51aspx</font></u></p>
<p><u><font color="#810081">数据库配置文件：kycon.config</font></u></p>
<p><u><font color="#810081">作者：酷源，发布者：drweb<br />
源码下载及讨论地址：<a href="http://www.51aspx.com/CV/KyCms">http://www.51aspx.com/CV/KyCms</a></font></u></p>
<p><u><font color="#810081">本源码由51aspx调测并进行注释添加，如需转载请注明作者信息及来源，以示对他人劳动成果的尊重！<br />
获得更有效的技术支持看这里：<a href="http://bbs.51aspx.com/showtopic-7928.html">http://bbs.51aspx.com/showtopic-7928.html</a>酷源V1.0版亮点功能: <br />
1:自定义模型及强大的字段属性设置功能,轻松实现分类信息\房产\人才\供求\小说等模型. <br />
2:异常简易的标签调用模型数据功能,可视化的模板标签编辑界面.您可以通过可视化界面筛选调用任意数据。 <br />
3:强大的自定义表单管理,可以生成订单编号,实现在线预定,后台可设置属性字段,设置多种属性值.</font></u></p>
<p><u><font color="#810081">DB_51aspx下为Sql数据库文件，附加即可<br />
默认管理帐号/密码：51aspx/51aspx</font></u></p>
<p><u><font color="#810081">数据库配置文件：kycon.config</font></u></p>
<p><u><font color="#810081">作者：酷源，发布者：drweb<br />
源码下载及讨论地址：<a href="http://www.51aspx.com/CV/KyCms">http://www.51aspx.com/CV/KyCms</a></font></u></p>
<p><u><font color="#810081">本源码由51aspx调测并进行注释添加，如需转载请注明作者信息及来源，以示对他人劳动成果的尊重！<br />
获得更有效的技术支持看这里：<a href="http://bbs.51aspx.com/showtopic-7928.html">http://bbs.51aspx.com/showtopic-7928.html</a>酷源V1.0版亮点功能: <br />
1:自定义模型及强大的字段属性设置功能,轻松实现分类信息\房产\人才\供求\小说等模型. <br />
2:异常简易的标签调用模型数据功能,可视化的模板标签编辑界面.您可以通过可视化界面筛选调用任意数据。 <br />
3:强大的自定义表单管理,可以生成订单编号,实现在线预定,后台可设置属性字段,设置多种属性值.</font></u></p>
<p><u><font color="#810081">DB_51aspx下为Sql数据库文件，附加即可<br />
默认管理帐号/密码：51aspx/51aspx</font></u></p>
<p><u><font color="#810081">数据库配置文件：kycon.config</font></u></p>
<p><u><font color="#810081">作者：酷源，发布者：drweb<br />
源码下载及讨论地址：<a href="http://www.51aspx.com/CV/KyCms">http://www.51aspx.com/CV/KyCms</a></font></u></p>
<p><u><font color="#810081">本源码由51aspx调测并进行注释添加，如需转载请注明作者信息及来源，以示对他人劳动成果的尊重！<br />
获得更有效的技术支持看这里：<a href="http://bbs.51aspx.com/showtopic-7928.html">http://bbs.51aspx.com/showtopic-7928.html</a>酷源V1.0版亮点功能: <br />
1:自定义模型及强大的字段属性设置功能,轻松实现分类信息\房产\人才\供求\小说等模型. <br />
2:异常简易的标签调用模型数据功能,可视化的模板标签编辑界面.您可以通过可视化界面筛选调用任意数据。 <br />
3:强大的自定义表单管理,可以生成订单编号,实现在线预定,后台可设置属性字段,设置多种属性值.</font></u></p>
<p><u><font color="#810081">DB_51aspx下为Sql数据库文件，附加即可<br />
默认管理帐号/密码：51aspx/51aspx</font></u></p>
<p><u><font color="#810081">数据库配置文件：kycon.config</font></u></p>
<p><u><font color="#810081">作者：酷源，发布者：drweb<br />
源码下载及讨论地址：<a href="http://www.51aspx.com/CV/KyCms">http://www.51aspx.com/CV/KyCms</a></font></u></p>
<p><u><font color="#810081">本源码由51aspx调测并进行注释添加，如需转载请注明作者信息及来源，以示对他人劳动成果的尊重！<br />
获得更有效的技术支持看这里：<a href="http://bbs.51aspx.com/showtopic-7928.html">http://bbs.51aspx.com/showtopic-7928.html</a></font></u></p>', N'', N'', N'', N'', N'0', N'|常规|12px|', N'', N'★★★', N'0', N'0', N'0', N'', N'', N'', N'2009-08-25 00:00:00.000')
GO
GO
SET IDENTITY_INSERT [dbo].[KyArticle] OFF
GO

-- ----------------------------
-- Table structure for KyCard
-- ----------------------------
DROP TABLE [dbo].[KyCard]
GO
CREATE TABLE [dbo].[KyCard] (
[ID] int NOT NULL IDENTITY(10000,1) ,
[Type] int NULL ,
[CardAccount] varchar(20) NULL ,
[Password] varchar(200) NOT NULL ,
[IsUsed] bit NULL ,
[CardPoint] int NULL ,
[CardDay] int NULL ,
[AdminID] int NULL ,
[AdminName] varchar(50) NULL ,
[UserID] int NULL ,
[UserName] nvarchar(18) NULL ,
[OverdueDate] datetime NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyCard]', RESEED, 12293)
GO

-- ----------------------------
-- Records of KyCard
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyCard] ON
GO
SET IDENTITY_INSERT [dbo].[KyCard] OFF
GO

-- ----------------------------
-- Table structure for KyChannel
-- ----------------------------
DROP TABLE [dbo].[KyChannel]
GO
CREATE TABLE [dbo].[KyChannel] (
[ChId] int NOT NULL IDENTITY(1,1) ,
[ChName] nvarchar(50) NOT NULL ,
[Description] nvarchar(255) NULL DEFAULT '' ,
[TemplatePath] nvarchar(255) NOT NULL ,
[IsChildSite] bit NULL DEFAULT (0) ,
[ChildSiteUrl] nvarchar(255) NULL DEFAULT '' ,
[IsOpenLink] bit NULL DEFAULT (0) ,
[ModelType] int NOT NULL ,
[DirName] nvarchar(50) NOT NULL ,
[TypeName] nvarchar(10) NOT NULL ,
[TypeUnit] nvarchar(10) NOT NULL ,
[IsDisabled] bit NULL DEFAULT (0) ,
[IsOpened] bit NULL DEFAULT (1) ,
[GroupIdStr] varchar(500) NULL DEFAULT '' ,
[VerifyType] int NULL DEFAULT (0) ,
[Notice1] nvarchar(500) NULL DEFAULT '' ,
[Notice2] nvarchar(500) NULL DEFAULT '' ,
[Keyword] nvarchar(100) NULL DEFAULT '' ,
[Content] nvarchar(300) NULL DEFAULT '' ,
[MiniHitCount] int NOT NULL DEFAULT (500) ,
[IsStaticType] bit NOT NULL DEFAULT (1) ,
[ColumnSortType] int NOT NULL DEFAULT (1) ,
[InfoSortType] int NOT NULL DEFAULT (1) ,
[FileNameType] int NOT NULL ,
[ChannelPageType] int NULL DEFAULT (1) ,
[ColumnPageType] int NULL DEFAULT (1) ,
[InfoPageType] int NULL DEFAULT (1) ,
[AddTime] datetime NOT NULL ,
[Sort] int NULL DEFAULT (1) ,
[ColumnTemplatePath] nvarchar(255) NOT NULL DEFAULT '' ,
[InfoTemplatePath] nvarchar(255) NOT NULL DEFAULT '' ,
[CommentTemplatePath] nvarchar(255) NOT NULL DEFAULT '' ,
[IsDeleted] bit NOT NULL DEFAULT (0) ,
[ChType] int NULL DEFAULT (0) 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyChannel]', RESEED, 19)
GO

-- ----------------------------
-- Records of KyChannel
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyChannel] ON
GO
INSERT INTO [dbo].[KyChannel] ([ChId], [ChName], [Description], [TemplatePath], [IsChildSite], [ChildSiteUrl], [IsOpenLink], [ModelType], [DirName], [TypeName], [TypeUnit], [IsDisabled], [IsOpened], [GroupIdStr], [VerifyType], [Notice1], [Notice2], [Keyword], [Content], [MiniHitCount], [IsStaticType], [ColumnSortType], [InfoSortType], [FileNameType], [ChannelPageType], [ColumnPageType], [InfoPageType], [AddTime], [Sort], [ColumnTemplatePath], [InfoTemplatePath], [CommentTemplatePath], [IsDeleted], [ChType]) VALUES (N'1', N'新闻中心', N'新闻中心', N'/Template/文章/index.html', N'0', N'', N'0', N'1', N'article', N'新闻', N'篇', N'0', N'1', N'', N'0', N'', N'', N'', N'', N'500', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'2007-12-14 16:22:15.593', N'0', N'/Template/文章/父栏目.html', N'/Template/文章/内容页.html', N'/Template/文章/更多评论.html', N'0', N'2')
GO
GO
INSERT INTO [dbo].[KyChannel] ([ChId], [ChName], [Description], [TemplatePath], [IsChildSite], [ChildSiteUrl], [IsOpenLink], [ModelType], [DirName], [TypeName], [TypeUnit], [IsDisabled], [IsOpened], [GroupIdStr], [VerifyType], [Notice1], [Notice2], [Keyword], [Content], [MiniHitCount], [IsStaticType], [ColumnSortType], [InfoSortType], [FileNameType], [ChannelPageType], [ColumnPageType], [InfoPageType], [AddTime], [Sort], [ColumnTemplatePath], [InfoTemplatePath], [CommentTemplatePath], [IsDeleted], [ChType]) VALUES (N'2', N'资源下载', N'下载频道', N'/Template/下载/index.html', N'0', N'', N'0', N'3', N'download', N'软件', N'个', N'0', N'1', N'', N'0', N'', N'', N'', N'', N'500', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'2007-12-14 17:16:04.643', N'0', N'/Template/下载/终极栏目.html', N'/Template/下载/内容页.html', N'/Template/下载/更多评论.html', N'0', N'3')
GO
GO
INSERT INTO [dbo].[KyChannel] ([ChId], [ChName], [Description], [TemplatePath], [IsChildSite], [ChildSiteUrl], [IsOpenLink], [ModelType], [DirName], [TypeName], [TypeUnit], [IsDisabled], [IsOpened], [GroupIdStr], [VerifyType], [Notice1], [Notice2], [Keyword], [Content], [MiniHitCount], [IsStaticType], [ColumnSortType], [InfoSortType], [FileNameType], [ChannelPageType], [ColumnPageType], [InfoPageType], [AddTime], [Sort], [ColumnTemplatePath], [InfoTemplatePath], [CommentTemplatePath], [IsDeleted], [ChType]) VALUES (N'3', N'图片频道', N'', N'/Template/图片/index.html', N'0', N'', N'0', N'2', N'Image', N'图片', N'张', N'0', N'1', N'', N'0', N'', N'', N'', N'', N'500', N'1', N'1', N'1', N'1', N'1', N'1', N'1', N'2007-12-15 10:50:52.687', N'0', N'/Template/图片/终极栏目.html', N'/Template/图片/内容页.html', N'/Template/图片/终极栏目.html', N'0', N'4')
GO
GO
SET IDENTITY_INSERT [dbo].[KyChannel] OFF
GO

-- ----------------------------
-- Table structure for KyCollection
-- ----------------------------
DROP TABLE [dbo].[KyCollection]
GO
CREATE TABLE [dbo].[KyCollection] (
[Id] int NOT NULL IDENTITY(1,1) ,
[ObjectName] nvarchar(50) NULL ,
[WebSite] nvarchar(500) NULL ,
[ColId] int NULL ,
[SpecialId] nvarchar(500) NULL ,
[CharSet] nvarchar(50) NULL ,
[ListPageUrl] nvarchar(500) NULL ,
[ObjectDemo] text NULL ,
[ListStartCode] ntext NULL ,
[ListEndCode] ntext NULL ,
[LinkStartCode] ntext NULL ,
[LinkEndCode] ntext NULL ,
[PageSet] nvarchar(1000) NULL ,
[ContentPageSet] nvarchar(1000) NULL ,
[FieldListSet] ntext NULL ,
[SimpleFilterRule] nvarchar(50) NULL ,
[ComplexityFilterRule] nvarchar(50) NULL ,
[ProterySet] nvarchar(50) NULL ,
[StarLevel] nvarchar(50) NULL ,
[HiteCount] int NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyCollection]', RESEED, 73)
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCollection', 
'COLUMN', N'Id')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'自动编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'Id'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'自动编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'Id'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCollection', 
'COLUMN', N'ObjectName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'项目名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'ObjectName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'项目名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'ObjectName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCollection', 
'COLUMN', N'WebSite')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'目标站点'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'WebSite'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'目标站点'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'WebSite'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCollection', 
'COLUMN', N'ColId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'栏目Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'ColId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'栏目Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'ColId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCollection', 
'COLUMN', N'SpecialId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'专题Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'SpecialId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'专题Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'SpecialId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCollection', 
'COLUMN', N'CharSet')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'编码方式'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'CharSet'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'编码方式'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'CharSet'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCollection', 
'COLUMN', N'ListPageUrl')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'列表页链接地地址'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'ListPageUrl'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'列表页链接地地址'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'ListPageUrl'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCollection', 
'COLUMN', N'ObjectDemo')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'项目备注'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'ObjectDemo'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'项目备注'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'ObjectDemo'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCollection', 
'COLUMN', N'ListStartCode')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'列表页开始代码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'ListStartCode'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'列表页开始代码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'ListStartCode'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCollection', 
'COLUMN', N'ListEndCode')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'列表页结束代码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'ListEndCode'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'列表页结束代码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'ListEndCode'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCollection', 
'COLUMN', N'LinkStartCode')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'链接开始代码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'LinkStartCode'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'链接开始代码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'LinkStartCode'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCollection', 
'COLUMN', N'LinkEndCode')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'链接结束代码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'LinkEndCode'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'链接结束代码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'LinkEndCode'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCollection', 
'COLUMN', N'PageSet')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'分页设置'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'PageSet'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'分页设置'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'PageSet'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCollection', 
'COLUMN', N'FieldListSet')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'字段列表设置'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'FieldListSet'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'字段列表设置'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'FieldListSet'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCollection', 
'COLUMN', N'SimpleFilterRule')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'简单过滤规则'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'SimpleFilterRule'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'简单过滤规则'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'SimpleFilterRule'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCollection', 
'COLUMN', N'ComplexityFilterRule')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'复杂过滤规则'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'ComplexityFilterRule'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'复杂过滤规则'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'ComplexityFilterRule'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCollection', 
'COLUMN', N'ProterySet')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'属性设置'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'ProterySet'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'属性设置'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'ProterySet'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCollection', 
'COLUMN', N'StarLevel')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'评分等级'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'StarLevel'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'评分等级'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'StarLevel'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCollection', 
'COLUMN', N'HiteCount')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'点击数'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'HiteCount'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'点击数'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollection'
, @level2type = 'COLUMN', @level2name = N'HiteCount'
GO

-- ----------------------------
-- Records of KyCollection
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyCollection] ON
GO
SET IDENTITY_INSERT [dbo].[KyCollection] OFF
GO

-- ----------------------------
-- Table structure for KyCollectionAddress
-- ----------------------------
DROP TABLE [dbo].[KyCollectionAddress]
GO
CREATE TABLE [dbo].[KyCollectionAddress] (
[Id] int NOT NULL IDENTITY(1,1) ,
[ColectionId] int NULL ,
[CollectionUrl] nvarchar(500) NULL ,
[State] bit NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCollectionAddress', 
'COLUMN', N'Id')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'自动编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollectionAddress'
, @level2type = 'COLUMN', @level2name = N'Id'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'自动编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollectionAddress'
, @level2type = 'COLUMN', @level2name = N'Id'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCollectionAddress', 
'COLUMN', N'ColectionId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'采集参数据表的Id号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollectionAddress'
, @level2type = 'COLUMN', @level2name = N'ColectionId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'采集参数据表的Id号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollectionAddress'
, @level2type = 'COLUMN', @level2name = N'ColectionId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCollectionAddress', 
'COLUMN', N'CollectionUrl')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'采集的列表地址'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollectionAddress'
, @level2type = 'COLUMN', @level2name = N'CollectionUrl'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'采集的列表地址'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollectionAddress'
, @level2type = 'COLUMN', @level2name = N'CollectionUrl'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCollectionAddress', 
'COLUMN', N'State')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否采集成功'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollectionAddress'
, @level2type = 'COLUMN', @level2name = N'State'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否采集成功'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCollectionAddress'
, @level2type = 'COLUMN', @level2name = N'State'
GO

-- ----------------------------
-- Records of KyCollectionAddress
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyCollectionAddress] ON
GO
SET IDENTITY_INSERT [dbo].[KyCollectionAddress] OFF
GO

-- ----------------------------
-- Table structure for KyColumn
-- ----------------------------
DROP TABLE [dbo].[KyColumn]
GO
CREATE TABLE [dbo].[KyColumn] (
[ColId] int NOT NULL IDENTITY(1,1) ,
[ChId] int NOT NULL ,
[ColName] nvarchar(50) NOT NULL ,
[ColDirName] nvarchar(50) NOT NULL ,
[ColParentId] int NOT NULL ,
[IsOuterColumn] bit NULL DEFAULT (0) ,
[OuterColumnUrl] varchar(255) NULL ,
[ColumnImgPath] nvarchar(255) NULL ,
[Description] nvarchar(255) NULL ,
[Keyword] nvarchar(100) NULL ,
[Content] nvarchar(300) NULL ,
[IsAllowAddInfo] bit NULL DEFAULT (1) ,
[ColumnTemplatePath] nvarchar(255) NOT NULL ,
[InfoTemplatePath] nvarchar(255) NOT NULL ,
[CommentTemplatePath] nvarchar(255) NOT NULL ,
[Sort] int NULL DEFAULT (1) ,
[IsAllowComment] bit NULL DEFAULT (1) ,
[IsCheckComment] bit NULL DEFAULT (0) ,
[InfoTableName] nvarchar(50) NOT NULL DEFAULT '' ,
[ScoreReward] int NULL DEFAULT (0) ,
[PointCount] int NULL DEFAULT (0) ,
[ChargeType] int NULL DEFAULT (1) ,
[ChargeHourCount] int NULL DEFAULT (0) ,
[ChargeViewCount] int NULL DEFAULT (0) ,
[IsOpened] bit NULL ,
[GroupIdStr] varchar(500) NULL DEFAULT '' ,
[ColumnPageType] int NULL DEFAULT (1) ,
[InfoPageType] int NULL DEFAULT (1) ,
[IsDeleted] bit NULL DEFAULT (0) ,
[AddTime] datetime NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyColumn]', RESEED, 122)
GO

-- ----------------------------
-- Records of KyColumn
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyColumn] ON
GO
INSERT INTO [dbo].[KyColumn] ([ColId], [ChId], [ColName], [ColDirName], [ColParentId], [IsOuterColumn], [OuterColumnUrl], [ColumnImgPath], [Description], [Keyword], [Content], [IsAllowAddInfo], [ColumnTemplatePath], [InfoTemplatePath], [CommentTemplatePath], [Sort], [IsAllowComment], [IsCheckComment], [InfoTableName], [ScoreReward], [PointCount], [ChargeType], [ChargeHourCount], [ChargeViewCount], [IsOpened], [GroupIdStr], [ColumnPageType], [InfoPageType], [IsDeleted], [AddTime]) VALUES (N'120', N'1', N'新闻文章', N'Xwwz', N'0', N'0', N'', N'', N'51aspx测试', N'', N'', N'0', N'/Template/文章/父栏目.html', N'/Template/文章/内容页.html', N'/Template/文章/更多评论.html', N'10', N'1', N'0', N'', N'0', N'0', N'1', N'0', N'0', N'1', N'', N'1', N'1', N'0', N'2009-06-26 10:11:08.720')
GO
GO
INSERT INTO [dbo].[KyColumn] ([ColId], [ChId], [ColName], [ColDirName], [ColParentId], [IsOuterColumn], [OuterColumnUrl], [ColumnImgPath], [Description], [Keyword], [Content], [IsAllowAddInfo], [ColumnTemplatePath], [InfoTemplatePath], [CommentTemplatePath], [Sort], [IsAllowComment], [IsCheckComment], [InfoTableName], [ScoreReward], [PointCount], [ChargeType], [ChargeHourCount], [ChargeViewCount], [IsOpened], [GroupIdStr], [ColumnPageType], [InfoPageType], [IsDeleted], [AddTime]) VALUES (N'121', N'1', N'51aspx源码', N'aspx', N'0', N'0', N'', N'', N'', N'', N'', N'0', N'/Template/文章/父栏目.html', N'/Template/文章/内容页.html', N'/Template/文章/更多评论.html', N'10', N'1', N'0', N'', N'0', N'0', N'1', N'0', N'0', N'1', N'', N'1', N'1', N'0', N'2009-06-26 10:11:29.127')
GO
GO
INSERT INTO [dbo].[KyColumn] ([ColId], [ChId], [ColName], [ColDirName], [ColParentId], [IsOuterColumn], [OuterColumnUrl], [ColumnImgPath], [Description], [Keyword], [Content], [IsAllowAddInfo], [ColumnTemplatePath], [InfoTemplatePath], [CommentTemplatePath], [Sort], [IsAllowComment], [IsCheckComment], [InfoTableName], [ScoreReward], [PointCount], [ChargeType], [ChargeHourCount], [ChargeViewCount], [IsOpened], [GroupIdStr], [ColumnPageType], [InfoPageType], [IsDeleted], [AddTime]) VALUES (N'122', N'2', N'Asp.net源码', N'www51aspx', N'0', N'0', N'', N'', N'', N'', N'', N'0', N'/Template/下载/终极栏目.html', N'/Template/下载/内容页.html', N'/Template/下载/更多评论.html', N'10', N'1', N'0', N'', N'0', N'0', N'1', N'0', N'0', N'1', N'', N'1', N'1', N'0', N'2009-06-26 10:19:10.187')
GO
GO
SET IDENTITY_INSERT [dbo].[KyColumn] OFF
GO

-- ----------------------------
-- Table structure for KyComment
-- ----------------------------
DROP TABLE [dbo].[KyComment]
GO
CREATE TABLE [dbo].[KyComment] (
[ID] int NOT NULL IDENTITY(1,1) ,
[SiteID] int NULL ,
[ReviewType] tinyint NULL ,
[ReviewResideID] nvarchar(18) NULL ,
[ReviewTitle] nvarchar(100) NULL ,
[IsArgue] bit NULL ,
[IsSquare] tinyint NULL ,
[BrarNum] int NULL ,
[FightNum] int NULL ,
[IsElite] bit NULL ,
[ReviewContent] ntext NULL ,
[ReviewTime] datetime NULL ,
[UserNum] nvarchar(18) NULL ,
[ReviewIP] nvarchar(20) NULL 
)


GO

-- ----------------------------
-- Records of KyComment
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyComment] ON
GO
SET IDENTITY_INSERT [dbo].[KyComment] OFF
GO

-- ----------------------------
-- Table structure for KyController
-- ----------------------------
DROP TABLE [dbo].[KyController]
GO
CREATE TABLE [dbo].[KyController] (
[ControllerId] int NOT NULL IDENTITY(1,1) ,
[ControllerName] nvarchar(50) NULL ,
[LinkURI] varchar(255) NULL ,
[OrderNum] int NULL ,
[UserId] int NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyController]', RESEED, 54)
GO

-- ----------------------------
-- Records of KyController
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyController] ON
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'1', N'模板管理', N'template/CreateFolder.aspx', N'1', N'0')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'2', N'样式管理', N'label/StyleManager.aspx', N'2', N'0')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'3', N'标签管理', N'label/LabelManager.aspx', N'3', N'0')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'4', N'频道管理', N'info/ChannelList.aspx', N'4', N'0')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'5', N'专题管理', N'info/SpecialList.aspx', N'5', N'0')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'6', N'模型管理', N'infomodel/ModelList.aspx', N'6', N'0')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'7', N'表单管理', N'infomodel/CustomFormList.aspx', N'7', N'0')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'8', N'用户管理', N'user/GroupList.aspx', N'8', N'0')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'9', N'管理员管理', N'user/AdminList.aspx', N'9', N'0')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'10', N'模板管理', N'template/CreateFolder.aspx', N'1', N'1')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'11', N'样式管理', N'label/StyleManager.aspx', N'2', N'1')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'12', N'标签管理', N'label/LabelManager.aspx', N'3', N'1')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'13', N'频道管理', N'info/ChannelList.aspx', N'4', N'1')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'14', N'专题管理', N'info/SpecialList.aspx', N'5', N'1')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'15', N'模型管理', N'infomodel/ModelList.aspx', N'6', N'1')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'16', N'表单管理', N'infomodel/CustomFormList.aspx', N'7', N'1')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'17', N'用户管理', N'user/GroupList.aspx', N'8', N'1')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'18', N'管理员管理', N'user/AdminList.aspx', N'9', N'1')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'19', N'模板管理', N'template/CreateFolder.aspx', N'1', N'7')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'20', N'样式管理', N'label/StyleManager.aspx', N'2', N'7')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'21', N'标签管理', N'label/LabelManager.aspx', N'3', N'7')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'22', N'频道管理', N'info/ChannelList.aspx', N'4', N'7')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'23', N'专题管理', N'info/SpecialList.aspx', N'5', N'7')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'24', N'模型管理', N'infomodel/ModelList.aspx', N'6', N'7')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'25', N'表单管理', N'infomodel/CustomFormList.aspx', N'7', N'7')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'26', N'用户管理', N'user/GroupList.aspx', N'8', N'7')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'27', N'管理员管理', N'user/AdminList.aspx', N'9', N'7')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'28', N'模板管理', N'template/CreateFolder.aspx', N'1', N'8')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'29', N'样式管理', N'label/StyleManager.aspx', N'2', N'8')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'30', N'标签管理', N'label/LabelManager.aspx', N'3', N'8')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'31', N'频道管理', N'info/ChannelList.aspx', N'4', N'8')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'32', N'专题管理', N'info/SpecialList.aspx', N'5', N'8')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'33', N'模型管理', N'infomodel/ModelList.aspx', N'6', N'8')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'34', N'表单管理', N'infomodel/CustomFormList.aspx', N'7', N'8')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'35', N'用户管理', N'user/GroupList.aspx', N'8', N'8')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'36', N'管理员管理', N'user/AdminList.aspx', N'9', N'8')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'37', N'模板管理', N'template/CreateFolder.aspx', N'1', N'9')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'38', N'样式管理', N'label/StyleManager.aspx', N'2', N'9')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'39', N'标签管理', N'label/LabelManager.aspx', N'3', N'9')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'40', N'频道管理', N'info/ChannelList.aspx', N'4', N'9')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'41', N'专题管理', N'info/SpecialList.aspx', N'5', N'9')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'42', N'模型管理', N'infomodel/ModelList.aspx', N'6', N'9')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'43', N'表单管理', N'infomodel/CustomFormList.aspx', N'7', N'9')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'44', N'用户管理', N'user/GroupList.aspx', N'8', N'9')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'45', N'管理员管理', N'user/AdminList.aspx', N'9', N'9')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'46', N'模板管理', N'template/CreateFolder.aspx', N'1', N'10')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'47', N'样式管理', N'label/StyleManager.aspx', N'2', N'10')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'48', N'标签管理', N'label/LabelManager.aspx', N'3', N'10')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'49', N'频道管理', N'info/ChannelList.aspx', N'4', N'10')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'50', N'专题管理', N'info/SpecialList.aspx', N'5', N'10')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'51', N'模型管理', N'infomodel/ModelList.aspx', N'6', N'10')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'52', N'表单管理', N'infomodel/CustomFormList.aspx', N'7', N'10')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'53', N'用户管理', N'user/GroupList.aspx', N'8', N'10')
GO
GO
INSERT INTO [dbo].[KyController] ([ControllerId], [ControllerName], [LinkURI], [OrderNum], [UserId]) VALUES (N'54', N'管理员管理', N'user/AdminList.aspx', N'9', N'10')
GO
GO
SET IDENTITY_INSERT [dbo].[KyController] OFF
GO

-- ----------------------------
-- Table structure for KyCountDay
-- ----------------------------
DROP TABLE [dbo].[KyCountDay]
GO
CREATE TABLE [dbo].[KyCountDay] (
[0] int NULL DEFAULT (0) ,
[1] int NULL DEFAULT (0) ,
[2] int NULL DEFAULT (0) ,
[3] int NULL DEFAULT (0) ,
[4] int NULL DEFAULT (0) ,
[5] int NULL DEFAULT (0) ,
[6] int NULL DEFAULT (0) ,
[7] int NULL DEFAULT (0) ,
[8] int NULL DEFAULT (0) ,
[9] int NULL DEFAULT (0) ,
[10] int NULL DEFAULT (0) ,
[11] int NULL DEFAULT (0) ,
[12] int NULL DEFAULT (0) ,
[13] int NULL DEFAULT (0) ,
[14] int NULL DEFAULT (0) ,
[15] int NULL DEFAULT (0) ,
[16] int NULL DEFAULT (0) ,
[17] int NULL DEFAULT (0) ,
[18] int NULL DEFAULT (0) ,
[19] int NULL DEFAULT (0) ,
[20] int NULL DEFAULT (0) ,
[21] int NULL DEFAULT (0) ,
[22] int NULL DEFAULT (0) ,
[23] int NULL DEFAULT (0) ,
[Flag] nvarchar(10) NULL 
)


GO

-- ----------------------------
-- Records of KyCountDay
-- ----------------------------
INSERT INTO [dbo].[KyCountDay] ([0], [1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12], [13], [14], [15], [16], [17], [18], [19], [20], [21], [22], [23], [Flag]) VALUES (N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'28', N'8', N'2', N'2007-11-08')
GO
GO
INSERT INTO [dbo].[KyCountDay] ([0], [1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12], [13], [14], [15], [16], [17], [18], [19], [20], [21], [22], [23], [Flag]) VALUES (N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'1', N'10', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'2007-11-09')
GO
GO
INSERT INTO [dbo].[KyCountDay] ([0], [1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12], [13], [14], [15], [16], [17], [18], [19], [20], [21], [22], [23], [Flag]) VALUES (N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'2', N'10', N'0', N'0', N'0', N'0', N'2', N'18', N'0', N'0', N'0', N'0', N'28', N'8', N'2', N'total')
GO
GO
INSERT INTO [dbo].[KyCountDay] ([0], [1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12], [13], [14], [15], [16], [17], [18], [19], [20], [21], [22], [23], [Flag]) VALUES (N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'2', N'18', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'2007-11-13')
GO
GO
INSERT INTO [dbo].[KyCountDay] ([0], [1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12], [13], [14], [15], [16], [17], [18], [19], [20], [21], [22], [23], [Flag]) VALUES (N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'1', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'2007-11-15')
GO
GO

-- ----------------------------
-- Table structure for KyCountMonth
-- ----------------------------
DROP TABLE [dbo].[KyCountMonth]
GO
CREATE TABLE [dbo].[KyCountMonth] (
[1] int NULL DEFAULT (0) ,
[2] int NULL DEFAULT (0) ,
[3] int NULL DEFAULT (0) ,
[4] int NULL DEFAULT (0) ,
[5] int NULL DEFAULT (0) ,
[6] int NULL DEFAULT (0) ,
[7] int NULL DEFAULT (0) ,
[8] int NULL DEFAULT (0) ,
[9] int NULL DEFAULT (0) ,
[10] int NULL DEFAULT (0) ,
[11] int NULL DEFAULT (0) ,
[12] int NULL DEFAULT (0) ,
[13] int NULL DEFAULT (0) ,
[14] int NULL DEFAULT (0) ,
[15] int NULL DEFAULT (0) ,
[16] int NULL DEFAULT (0) ,
[17] int NULL DEFAULT (0) ,
[18] int NULL DEFAULT (0) ,
[19] int NULL DEFAULT (0) ,
[20] int NULL DEFAULT (0) ,
[21] int NULL DEFAULT (0) ,
[22] int NULL DEFAULT (0) ,
[23] int NULL DEFAULT (0) ,
[24] int NULL DEFAULT (0) ,
[25] int NULL DEFAULT (0) ,
[26] int NULL DEFAULT (0) ,
[27] int NULL DEFAULT (0) ,
[28] int NULL DEFAULT (0) ,
[29] int NULL DEFAULT (0) ,
[30] int NULL DEFAULT (0) ,
[31] int NULL DEFAULT (0) ,
[Flag] nvarchar(10) NULL 
)


GO

-- ----------------------------
-- Records of KyCountMonth
-- ----------------------------
INSERT INTO [dbo].[KyCountMonth] ([1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12], [13], [14], [15], [16], [17], [18], [19], [20], [21], [22], [23], [24], [25], [26], [27], [28], [29], [30], [31], [Flag]) VALUES (N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'38', N'12', N'0', N'0', N'0', N'18', N'0', N'1', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'2007-11')
GO
GO
INSERT INTO [dbo].[KyCountMonth] ([1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12], [13], [14], [15], [16], [17], [18], [19], [20], [21], [22], [23], [24], [25], [26], [27], [28], [29], [30], [31], [Flag]) VALUES (N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'38', N'12', N'0', N'0', N'0', N'18', N'0', N'1', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'total')
GO
GO

-- ----------------------------
-- Table structure for KyCountWeek
-- ----------------------------
DROP TABLE [dbo].[KyCountWeek]
GO
CREATE TABLE [dbo].[KyCountWeek] (
[1] int NULL DEFAULT (0) ,
[2] int NULL DEFAULT (0) ,
[3] int NULL DEFAULT (0) ,
[4] int NULL DEFAULT (0) ,
[5] int NULL DEFAULT (0) ,
[6] int NULL DEFAULT (0) ,
[7] int NULL DEFAULT (0) ,
[Flag] nvarchar(10) NULL 
)


GO

-- ----------------------------
-- Records of KyCountWeek
-- ----------------------------
INSERT INTO [dbo].[KyCountWeek] ([1], [2], [3], [4], [5], [6], [7], [Flag]) VALUES (N'0', N'25', N'0', N'1', N'0', N'0', N'0', N'total')
GO
GO
INSERT INTO [dbo].[KyCountWeek] ([1], [2], [3], [4], [5], [6], [7], [Flag]) VALUES (N'0', N'19', N'0', N'1', N'0', N'0', N'0', N'2007-11-14')
GO
GO

-- ----------------------------
-- Table structure for KyCountYear
-- ----------------------------
DROP TABLE [dbo].[KyCountYear]
GO
CREATE TABLE [dbo].[KyCountYear] (
[1] int NULL DEFAULT (0) ,
[2] int NULL DEFAULT (0) ,
[3] int NULL DEFAULT (0) ,
[4] int NULL DEFAULT (0) ,
[5] int NULL DEFAULT (0) ,
[6] int NULL DEFAULT (0) ,
[7] int NULL DEFAULT (0) ,
[8] int NULL DEFAULT (0) ,
[9] int NULL DEFAULT (0) ,
[10] int NULL DEFAULT (0) ,
[11] int NULL DEFAULT (0) ,
[12] int NULL DEFAULT (0) ,
[Flag] nvarchar(10) NULL 
)


GO

-- ----------------------------
-- Records of KyCountYear
-- ----------------------------
INSERT INTO [dbo].[KyCountYear] ([1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12], [Flag]) VALUES (N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'69', N'0', N'2007')
GO
GO
INSERT INTO [dbo].[KyCountYear] ([1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12], [Flag]) VALUES (N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'0', N'69', N'0', N'total')
GO
GO

-- ----------------------------
-- Table structure for KyCustomForm
-- ----------------------------
DROP TABLE [dbo].[KyCustomForm]
GO
CREATE TABLE [dbo].[KyCustomForm] (
[CustomFormId] int NOT NULL IDENTITY(1,1) ,
[ShowForm] int NULL ,
[FormName] nvarchar(50) NULL ,
[TableName] nvarchar(50) NULL ,
[UploadPath] nvarchar(50) NULL ,
[UploadSize] int NULL DEFAULT (0) ,
[FormDesc] nvarchar(200) NULL ,
[IsUnlockTime] bit NULL ,
[StartTime] datetime NULL ,
[EndTime] datetime NULL ,
[UserGroup] nvarchar(100) NULL ,
[IsSubmitNum] bit NULL ,
[Money] int NULL ,
[IsValidate] bit NULL ,
[AddTime] datetime NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCustomForm', 
'COLUMN', N'ShowForm')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'表单显示控制'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomForm'
, @level2type = 'COLUMN', @level2name = N'ShowForm'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'表单显示控制'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomForm'
, @level2type = 'COLUMN', @level2name = N'ShowForm'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCustomForm', 
'COLUMN', N'FormName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'表单名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomForm'
, @level2type = 'COLUMN', @level2name = N'FormName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'表单名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomForm'
, @level2type = 'COLUMN', @level2name = N'FormName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCustomForm', 
'COLUMN', N'TableName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'表名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomForm'
, @level2type = 'COLUMN', @level2name = N'TableName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'表名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomForm'
, @level2type = 'COLUMN', @level2name = N'TableName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCustomForm', 
'COLUMN', N'UploadPath')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'上传路径'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomForm'
, @level2type = 'COLUMN', @level2name = N'UploadPath'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'上传路径'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomForm'
, @level2type = 'COLUMN', @level2name = N'UploadPath'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCustomForm', 
'COLUMN', N'UploadSize')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'允许上传文件大小'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomForm'
, @level2type = 'COLUMN', @level2name = N'UploadSize'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'允许上传文件大小'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomForm'
, @level2type = 'COLUMN', @level2name = N'UploadSize'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCustomForm', 
'COLUMN', N'IsUnlockTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否开启时间限制'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomForm'
, @level2type = 'COLUMN', @level2name = N'IsUnlockTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否开启时间限制'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomForm'
, @level2type = 'COLUMN', @level2name = N'IsUnlockTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCustomForm', 
'COLUMN', N'StartTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'开始时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomForm'
, @level2type = 'COLUMN', @level2name = N'StartTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'开始时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomForm'
, @level2type = 'COLUMN', @level2name = N'StartTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCustomForm', 
'COLUMN', N'EndTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'结束时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomForm'
, @level2type = 'COLUMN', @level2name = N'EndTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'结束时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomForm'
, @level2type = 'COLUMN', @level2name = N'EndTime'
GO

-- ----------------------------
-- Records of KyCustomForm
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyCustomForm] ON
GO
SET IDENTITY_INSERT [dbo].[KyCustomForm] OFF
GO

-- ----------------------------
-- Table structure for KyCustomFormField
-- ----------------------------
DROP TABLE [dbo].[KyCustomFormField]
GO
CREATE TABLE [dbo].[KyCustomFormField] (
[FieldId] int NOT NULL IDENTITY(1,1) ,
[CustomFormId] int NULL ,
[Name] nvarchar(50) NULL ,
[Alias] nvarchar(150) NULL ,
[Description] nvarchar(200) NULL ,
[IsNotNull] bit NULL ,
[IsSearchForm] bit NULL ,
[Type] nvarchar(50) NULL ,
[Content] ntext NULL ,
[OrderId] int NULL DEFAULT (0) ,
[IsList] bit NULL ,
[IsUserInsert] bit NULL ,
[AddDate] datetime NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyCustomFormField]', RESEED, 3)
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCustomFormField', 
'COLUMN', N'CustomFormId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'表单Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomFormField'
, @level2type = 'COLUMN', @level2name = N'CustomFormId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'表单Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomFormField'
, @level2type = 'COLUMN', @level2name = N'CustomFormId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCustomFormField', 
'COLUMN', N'Name')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'字段名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomFormField'
, @level2type = 'COLUMN', @level2name = N'Name'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'字段名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomFormField'
, @level2type = 'COLUMN', @level2name = N'Name'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCustomFormField', 
'COLUMN', N'Alias')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'字段别名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomFormField'
, @level2type = 'COLUMN', @level2name = N'Alias'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'字段别名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomFormField'
, @level2type = 'COLUMN', @level2name = N'Alias'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCustomFormField', 
'COLUMN', N'Description')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'字段描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomFormField'
, @level2type = 'COLUMN', @level2name = N'Description'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'字段描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomFormField'
, @level2type = 'COLUMN', @level2name = N'Description'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCustomFormField', 
'COLUMN', N'IsNotNull')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否必填'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomFormField'
, @level2type = 'COLUMN', @level2name = N'IsNotNull'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否必填'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomFormField'
, @level2type = 'COLUMN', @level2name = N'IsNotNull'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCustomFormField', 
'COLUMN', N'IsSearchForm')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否在搜索表单显示'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomFormField'
, @level2type = 'COLUMN', @level2name = N'IsSearchForm'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否在搜索表单显示'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomFormField'
, @level2type = 'COLUMN', @level2name = N'IsSearchForm'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCustomFormField', 
'COLUMN', N'Type')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'字段类型'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomFormField'
, @level2type = 'COLUMN', @level2name = N'Type'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'字段类型'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomFormField'
, @level2type = 'COLUMN', @level2name = N'Type'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCustomFormField', 
'COLUMN', N'Content')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'字段内容'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomFormField'
, @level2type = 'COLUMN', @level2name = N'Content'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'字段内容'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomFormField'
, @level2type = 'COLUMN', @level2name = N'Content'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCustomFormField', 
'COLUMN', N'OrderId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'排序'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomFormField'
, @level2type = 'COLUMN', @level2name = N'OrderId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'排序'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomFormField'
, @level2type = 'COLUMN', @level2name = N'OrderId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCustomFormField', 
'COLUMN', N'IsList')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否在列表页中显示'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomFormField'
, @level2type = 'COLUMN', @level2name = N'IsList'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否在列表页中显示'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomFormField'
, @level2type = 'COLUMN', @level2name = N'IsList'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyCustomFormField', 
'COLUMN', N'IsUserInsert')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否允许用户录入数据'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomFormField'
, @level2type = 'COLUMN', @level2name = N'IsUserInsert'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否允许用户录入数据'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyCustomFormField'
, @level2type = 'COLUMN', @level2name = N'IsUserInsert'
GO

-- ----------------------------
-- Records of KyCustomFormField
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyCustomFormField] ON
GO
SET IDENTITY_INSERT [dbo].[KyCustomFormField] OFF
GO

-- ----------------------------
-- Table structure for KyDictionary
-- ----------------------------
DROP TABLE [dbo].[KyDictionary]
GO
CREATE TABLE [dbo].[KyDictionary] (
[ID] int NOT NULL IDENTITY(1,1) ,
[ParentId] int NOT NULL ,
[DicName] nvarchar(50) NOT NULL ,
[Sort] int NULL DEFAULT (5) 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyDictionary]', RESEED, 162)
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDictionary', 
'COLUMN', N'ID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDictionary'
, @level2type = 'COLUMN', @level2name = N'ID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDictionary'
, @level2type = 'COLUMN', @level2name = N'ID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDictionary', 
'COLUMN', N'ParentId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'父ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDictionary'
, @level2type = 'COLUMN', @level2name = N'ParentId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'父ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDictionary'
, @level2type = 'COLUMN', @level2name = N'ParentId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDictionary', 
'COLUMN', N'DicName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDictionary'
, @level2type = 'COLUMN', @level2name = N'DicName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDictionary'
, @level2type = 'COLUMN', @level2name = N'DicName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDictionary', 
'COLUMN', N'Sort')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'排序值'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDictionary'
, @level2type = 'COLUMN', @level2name = N'Sort'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'排序值'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDictionary'
, @level2type = 'COLUMN', @level2name = N'Sort'
GO

-- ----------------------------
-- Records of KyDictionary
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyDictionary] ON
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'1', N'0', N'频道所属类别', N'1')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'2', N'1', N'文章系统', N'1')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'3', N'1', N'下载系统', N'2')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'4', N'1', N'图片系统', N'3')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'8', N'0', N'问答分类', N'2')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'9', N'8', N'电脑/网络', N'1')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'10', N'8', N'生活/时尚', N'2')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'11', N'9', N'硬件', N'1')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'12', N'10', N'购物', N'1')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'13', N'9', N'反病毒', N'2')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'14', N'9', N'互联网', N'3')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'15', N'10', N'生活百科', N'2')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'16', N'10', N'服饰', N'3')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'17', N'0', N'普通用户空间模板', N'3')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'18', N'17', N'空间模板一', N'1')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'19', N'17', N'空间模板二', N'2')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'20', N'17', N'空间模板三', N'3')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'21', N'17', N'空间模板四', N'4')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'22', N'17', N'空间模板五', N'5')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'23', N'17', N'空间模板六', N'6')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'24', N'17', N'空间模板七', N'7')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'25', N'0', N'企业用户空间模板', N'4')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'26', N'25', N'空间模板一', N'1')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'27', N'25', N'空间模板二', N'2')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'28', N'0', N'软件语言', N'5')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'29', N'28', N'简体中文', N'1')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'30', N'28', N'繁体中文', N'2')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'31', N'28', N'多国语言', N'3')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'32', N'28', N'英文', N'4')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'33', N'28', N'法语', N'5')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'34', N'28', N'印第安', N'6')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'35', N'28', N'其它语言', N'7')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'36', N'0', N'软件类别', N'6')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'37', N'36', N'国产软件', N'1')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'38', N'36', N'国外软件', N'2')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'39', N'36', N'汉化补丁', N'3')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'40', N'36', N'程序源码', N'4')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'41', N'36', N'电影下载', N'5')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'42', N'36', N'Flash动画', N'6')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'43', N'36', N'其他软件类别', N'7')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'44', N'0', N'软件授权方式', N'7')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'45', N'44', N'免费版', N'1')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'46', N'44', N'共享版', N'2')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'47', N'44', N'试用版', N'3')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'48', N'44', N'演示版', N'4')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'49', N'44', N'注册版', N'5')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'50', N'44', N'破解版', N'6')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'51', N'44', N'零售版', N'7')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'52', N'44', N'其它版本', N'8')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'53', N'0', N'软件平台', N'8')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'54', N'53', N'WIN9x', N'1')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'55', N'53', N'Me', N'2')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'56', N'53', N'NT', N'3')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'57', N'53', N'Win2000', N'4')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'58', N'53', N'XP', N'5')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'59', N'53', N'ASP环境', N'6')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'60', N'53', N'CGI环境', N'7')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'61', N'53', N'PHP环境', N'8')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'62', N'53', N'PHP+MYSQL环境', N'9')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'63', N'53', N'JSP环境', N'10')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'64', N'53', N'.NET环境', N'11')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'65', N'53', N'其它', N'12')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'66', N'0', N'相册类别', N'9')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'67', N'66', N'人物摄影', N'1')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'68', N'66', N'旅游风景', N'2')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'69', N'66', N'生活空间', N'3')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'70', N'66', N'大千世界', N'4')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'71', N'66', N'开心天地', N'5')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'72', N'66', N'企业(公司)相册', N'6')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'73', N'0', N'友情链接', N'10')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'74', N'0', N'企业信息类别', N'11')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'75', N'74', N'公司新闻', N'1')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'76', N'74', N'资质证书', N'2')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'77', N'0', N'房产系统', N'12')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'78', N'77', N'装修程度', N'1')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'79', N'78', N'尚未装修', N'1')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'80', N'78', N'简易装修', N'2')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'81', N'78', N'中档装修', N'3')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'82', N'78', N'高档装修', N'4')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'83', N'77', N'配套设施', N'2')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'84', N'83', N'厨房', N'1')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'85', N'83', N'床', N'2')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'86', N'83', N'家具', N'3')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'87', N'83', N'有线电视', N'4')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'88', N'83', N'宽带网', N'5')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'89', N'83', N'电话', N'6')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'90', N'83', N'热水器', N'7')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'91', N'83', N'电视机', N'8')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'92', N'73', N'互联网', N'1')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'93', N'83', N'空调', N'9')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'94', N'83', N'洗衣机', N'10')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'95', N'83', N'冰箱', N'11')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'96', N'83', N'煤气', N'12')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'97', N'83', N'暖气', N'13')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'98', N'83', N'汽车库', N'14')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'99', N'77', N'付款要求', N'3')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'100', N'99', N'一月一付', N'1')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'101', N'99', N'一季一付', N'2')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'102', N'99', N'半年一付', N'3')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'103', N'99', N'一年一付', N'4')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'104', N'99', N'面议', N'5')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'105', N'77', N'押金要求', N'4')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'106', N'105', N'半月租金', N'1')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'107', N'105', N'一月租金', N'2')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'108', N'105', N'两月租金', N'3')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'109', N'105', N'一季租金', N'4')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'110', N'105', N'面议', N'5')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'111', N'77', N'房    型', N'5')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'112', N'111', N'普通住宅', N'1')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'113', N'111', N'小高层住宅', N'2')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'114', N'111', N'高层住宅', N'3')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'115', N'111', N'民房', N'4')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'116', N'111', N'别墅', N'5')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'117', N'111', N'排屋', N'6')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'118', N'111', N'商住楼', N'7')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'119', N'111', N'写字楼', N'8')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'120', N'111', N'商铺', N'9')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'121', N'111', N'厂房', N'10')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'122', N'111', N'库房', N'11')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'123', N'111', N'车库', N'12')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'124', N'111', N'其他', N'13')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'125', N'77', N'户　　型', N'6')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'126', N'125', N'单间', N'1')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'127', N'125', N'1室1厅1卫', N'2')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'128', N'125', N'2室1厅1卫', N'3')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'129', N'125', N'2室1厅2卫', N'4')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'130', N'125', N'2室2厅1卫', N'5')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'131', N'125', N'2室2厅2卫', N'6')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'132', N'125', N'3室1厅1卫', N'7')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'133', N'125', N'3室2厅1卫', N'8')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'134', N'125', N'3室2厅2卫', N'9')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'135', N'125', N'4室1厅1卫', N'10')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'136', N'125', N'4室2厅1卫', N'11')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'137', N'125', N'4室2厅2卫', N'12')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'138', N'125', N'4室3厅2卫', N'13')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'139', N'125', N'4室3厅3卫', N'14')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'140', N'125', N'5室户', N'15')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'141', N'125', N'6室户', N'16')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'142', N'125', N'标间', N'17')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'144', N'77', N'测试一', N'7')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'145', N'0', N'顶层', N'15')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'146', N'145', N'国内', N'5')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'147', N'145', N'国际', N'54')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'148', N'146', N'国内一', N'5')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'149', N'146', N'国内二', N'5')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'150', N'0', N'工作岗位', N'5')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'151', N'150', N'房地产/物业类', N'1')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'152', N'150', N'咨询/中介/造价类', N'2')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'153', N'151', N'报建/报批专员', N'1')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'154', N'151', N'拆迁专员', N'2')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'155', N'152', N'配套工程师', N'1')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'156', N'152', N'咨询工程师', N'2')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'157', N'0', N'地域分类', N'5')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'158', N'157', N'北京', N'1')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'159', N'157', N'上海', N'2')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'160', N'158', N'朝阳区', N'1')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'161', N'158', N'东城区', N'2')
GO
GO
INSERT INTO [dbo].[KyDictionary] ([ID], [ParentId], [DicName], [Sort]) VALUES (N'162', N'159', N'上海市', N'1')
GO
GO
SET IDENTITY_INSERT [dbo].[KyDictionary] OFF
GO

-- ----------------------------
-- Table structure for KyDig
-- ----------------------------
DROP TABLE [dbo].[KyDig]
GO
CREATE TABLE [dbo].[KyDig] (
[Id] int NOT NULL IDENTITY(1,1) ,
[InfoId] int NULL ,
[ModelId] int NULL ,
[DigCount] int NULL DEFAULT (0) 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyDig]', RESEED, 16)
GO

-- ----------------------------
-- Records of KyDig
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyDig] ON
GO
INSERT INTO [dbo].[KyDig] ([Id], [InfoId], [ModelId], [DigCount]) VALUES (N'1', N'1', N'1', N'20')
GO
GO
INSERT INTO [dbo].[KyDig] ([Id], [InfoId], [ModelId], [DigCount]) VALUES (N'2', N'92', N'1', N'23')
GO
GO
INSERT INTO [dbo].[KyDig] ([Id], [InfoId], [ModelId], [DigCount]) VALUES (N'3', N'103', N'1', N'4')
GO
GO
INSERT INTO [dbo].[KyDig] ([Id], [InfoId], [ModelId], [DigCount]) VALUES (N'4', N'34', N'1', N'3')
GO
GO
INSERT INTO [dbo].[KyDig] ([Id], [InfoId], [ModelId], [DigCount]) VALUES (N'5', N'35', N'1', N'1')
GO
GO
INSERT INTO [dbo].[KyDig] ([Id], [InfoId], [ModelId], [DigCount]) VALUES (N'6', N'190', N'1', N'3')
GO
GO
INSERT INTO [dbo].[KyDig] ([Id], [InfoId], [ModelId], [DigCount]) VALUES (N'7', N'1604', N'1', N'2')
GO
GO
INSERT INTO [dbo].[KyDig] ([Id], [InfoId], [ModelId], [DigCount]) VALUES (N'8', N'187', N'1', N'1')
GO
GO
INSERT INTO [dbo].[KyDig] ([Id], [InfoId], [ModelId], [DigCount]) VALUES (N'9', N'189', N'1', N'1')
GO
GO
INSERT INTO [dbo].[KyDig] ([Id], [InfoId], [ModelId], [DigCount]) VALUES (N'10', N'1608', N'1', N'1')
GO
GO
INSERT INTO [dbo].[KyDig] ([Id], [InfoId], [ModelId], [DigCount]) VALUES (N'11', N'1605', N'1', N'1')
GO
GO
INSERT INTO [dbo].[KyDig] ([Id], [InfoId], [ModelId], [DigCount]) VALUES (N'12', N'8', N'33', N'1')
GO
GO
INSERT INTO [dbo].[KyDig] ([Id], [InfoId], [ModelId], [DigCount]) VALUES (N'13', N'119', N'3', N'1')
GO
GO
INSERT INTO [dbo].[KyDig] ([Id], [InfoId], [ModelId], [DigCount]) VALUES (N'14', N'1', N'7', N'1')
GO
GO
INSERT INTO [dbo].[KyDig] ([Id], [InfoId], [ModelId], [DigCount]) VALUES (N'15', N'7', N'33', N'1')
GO
GO
INSERT INTO [dbo].[KyDig] ([Id], [InfoId], [ModelId], [DigCount]) VALUES (N'16', N'6', N'33', N'1')
GO
GO
SET IDENTITY_INSERT [dbo].[KyDig] OFF
GO

-- ----------------------------
-- Table structure for KyDownLoadAddress
-- ----------------------------
DROP TABLE [dbo].[KyDownLoadAddress]
GO
CREATE TABLE [dbo].[KyDownLoadAddress] (
[AddressId] int NOT NULL IDENTITY(1,1) ,
[DownLoadDataId] int NOT NULL ,
[AddressNum] int NULL ,
[DownLoadServerID] int NULL ,
[AddressName] nvarchar(100) NULL ,
[AddressPath] nvarchar(100) NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadAddress', 
'COLUMN', N'AddressId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'下载地址d(自动编号)I'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadAddress'
, @level2type = 'COLUMN', @level2name = N'AddressId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'下载地址d(自动编号)I'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadAddress'
, @level2type = 'COLUMN', @level2name = N'AddressId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadAddress', 
'COLUMN', N'DownLoadDataId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'所属下载数据Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadAddress'
, @level2type = 'COLUMN', @level2name = N'DownLoadDataId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'所属下载数据Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadAddress'
, @level2type = 'COLUMN', @level2name = N'DownLoadDataId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadAddress', 
'COLUMN', N'AddressNum')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'当前下载的下载地址个数数'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadAddress'
, @level2type = 'COLUMN', @level2name = N'AddressNum'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'当前下载的下载地址个数数'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadAddress'
, @level2type = 'COLUMN', @level2name = N'AddressNum'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadAddress', 
'COLUMN', N'DownLoadServerID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'下载地址的服务器类别编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadAddress'
, @level2type = 'COLUMN', @level2name = N'DownLoadServerID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'下载地址的服务器类别编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadAddress'
, @level2type = 'COLUMN', @level2name = N'DownLoadServerID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadAddress', 
'COLUMN', N'AddressName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'下载地址名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadAddress'
, @level2type = 'COLUMN', @level2name = N'AddressName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'下载地址名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadAddress'
, @level2type = 'COLUMN', @level2name = N'AddressName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadAddress', 
'COLUMN', N'AddressPath')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'下载地址路径'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadAddress'
, @level2type = 'COLUMN', @level2name = N'AddressPath'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'下载地址路径'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadAddress'
, @level2type = 'COLUMN', @level2name = N'AddressPath'
GO

-- ----------------------------
-- Records of KyDownLoadAddress
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyDownLoadAddress] ON
GO
SET IDENTITY_INSERT [dbo].[KyDownLoadAddress] OFF
GO

-- ----------------------------
-- Table structure for KyDownLoadData
-- ----------------------------
DROP TABLE [dbo].[KyDownLoadData]
GO
CREATE TABLE [dbo].[KyDownLoadData] (
[Id] int NOT NULL IDENTITY(1,1) ,
[ColId] int NOT NULL ,
[Title] nvarchar(200) NULL DEFAULT '' ,
[TitleColor] nvarchar(6) NULL DEFAULT '' ,
[TitleFontType] int NULL DEFAULT '' ,
[TitleType] int NULL DEFAULT (0) ,
[TitleImgPath] varchar(255) NULL DEFAULT '' ,
[UId] int NOT NULL ,
[UName] nvarchar(20) NOT NULL ,
[UserType] int NOT NULL ,
[AdminUId] int NULL ,
[AdminUName] nvarchar(20) NULL DEFAULT '' ,
[Status] int NULL DEFAULT (0) ,
[HitCount] int NULL DEFAULT (0) ,
[AddTime] datetime NOT NULL ,
[UpdateTime] datetime NOT NULL ,
[TemplatePath] varchar(255) NULL DEFAULT '' ,
[PageType] int NULL DEFAULT (1) ,
[IsCreated] bit NULL DEFAULT (0) ,
[UserCateId] int NULL DEFAULT (0) ,
[PointCount] int NULL DEFAULT (0) ,
[ChargeType] int NULL DEFAULT (1) ,
[ChargeHourCount] int NULL DEFAULT (0) ,
[ChargeViewCount] int NULL DEFAULT (0) ,
[IsOpened] int NULL DEFAULT (2) ,
[GroupIdStr] varchar(200) NULL DEFAULT '' ,
[IsDeleted] bit NULL DEFAULT (0) ,
[IsRecommend] bit NULL DEFAULT (0) ,
[IsTop] bit NULL DEFAULT (0) ,
[IsFocus] bit NULL DEFAULT (0) ,
[IsSideShow] bit NULL DEFAULT (0) ,
[IsAllowComment] bit NULL DEFAULT (0) ,
[TagIdStr] varchar(300) NULL DEFAULT '' ,
[TagNameStr] nvarchar(300) NULL DEFAULT '' ,
[SpecialIdStr] varchar(200) NULL DEFAULT '' ,
[Content] nvarchar(500) NULL ,
[Edition] nvarchar(50) NULL ,
[PlayAddress] nvarchar(100) NULL ,
[DownLoadDownNum] int NULL ,
[DownLoadDownMonthNum] int NULL ,
[DownLoadDownWeekNum] int NULL ,
[DownLoadDownDayNum] int NULL ,
[DownLoadOS] nvarchar(100) NULL ,
[DownLoadServerDataId] int NULL ,
[Language] nvarchar(50) NULL ,
[WarrantType] nvarchar(50) NULL ,
[DownLoadSize] nvarchar(20) NULL ,
[RegAddress] nvarchar(100) NULL ,
[Plugin] nvarchar(20) NULL ,
[DownLoadStarLevel] nvarchar(50) NULL ,
[DownLoadDisplePwd] nvarchar(50) NULL ,
[DownLoadType] nvarchar(50) NULL ,
[MonthCountTime] datetime NULL DEFAULT (getdate()) ,
[WeekCountTime] datetime NULL DEFAULT (getdate()) ,
[DayCountTime] datetime NULL DEFAULT (getdate()) 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyDownLoadData]', RESEED, 120)
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'Id')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'内容编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'Id'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'内容编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'Id'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'ColId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'栏目编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'ColId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'栏目编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'ColId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'Title')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'内容名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'Title'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'内容名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'Title'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'TitleColor')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'标题颜色代码 形如6c6c6c 前面没有#'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'TitleColor'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'标题颜色代码 形如6c6c6c 前面没有#'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'TitleColor'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'TitleFontType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'标题字体类型 0普通 1粗体 2斜体'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'TitleFontType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'标题字体类型 0普通 1粗体 2斜体'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'TitleFontType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'TitleType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'标题类型 1文字标题 2图片标题'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'TitleType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'标题类型 1文字标题 2图片标题'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'TitleType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'TitleImgPath')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'图片标题路径 当为图片标题时必填'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'TitleImgPath'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'图片标题路径 当为图片标题时必填'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'TitleImgPath'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'UId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'录入者编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'UId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'录入者编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'UId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'UName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'录入者名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'UName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'录入者名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'UName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'UserType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'录入者类型  0用户 1管理员'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'UserType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'录入者类型  0用户 1管理员'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'UserType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'AdminUId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'审核者编号/责任编辑编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'AdminUId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'审核者编号/责任编辑编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'AdminUId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'AdminUName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'审核者名称/责任编辑名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'AdminUName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'审核者名称/责任编辑名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'AdminUName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'Status')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'-1草稿 0待审 1一审 2二审 3三审'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'Status'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'-1草稿 0待审 1一审 2二审 3三审'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'Status'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'HitCount')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'点击次数'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'HitCount'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'点击次数'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'HitCount'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'AddTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'添加时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'AddTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'添加时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'AddTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'UpdateTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'最后修改时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'UpdateTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'最后修改时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'UpdateTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'TemplatePath')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'模板路径'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'TemplatePath'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'模板路径'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'TemplatePath'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'PageType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'1 html 2 htm 3 shtml 4 aspx'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'PageType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'1 html 2 htm 3 shtml 4 aspx'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'PageType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'IsCreated')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否已经生成'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'IsCreated'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否已经生成'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'IsCreated'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'UserCateId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户专栏编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'UserCateId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户专栏编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'UserCateId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'PointCount')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'收费金币个数'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'PointCount'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'收费金币个数'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'PointCount'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'ChargeType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'收费方式'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'ChargeType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'收费方式'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'ChargeType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'ChargeHourCount')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'多少小时后重复收费'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'ChargeHourCount'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'多少小时后重复收费'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'ChargeHourCount'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'ChargeViewCount')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'多少次后重复收费'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'ChargeViewCount'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'多少次后重复收费'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'ChargeViewCount'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'IsOpened')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否时开放内容  0认证 1开放 2继承栏目设置'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'IsOpened'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否时开放内容  0认证 1开放 2继承栏目设置'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'IsOpened'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'GroupIdStr')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'认证时允许访问用户组编号串 用 |编号1|编号2| 的形式'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'GroupIdStr'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'认证时允许访问用户组编号串 用 |编号1|编号2| 的形式'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'GroupIdStr'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'IsDeleted')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否被删除到回收站'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'IsDeleted'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否被删除到回收站'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'IsDeleted'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'IsRecommend')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'推荐'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'IsRecommend'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'推荐'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'IsRecommend'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'IsTop')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'置顶'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'IsTop'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'置顶'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'IsTop'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'IsFocus')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'焦点'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'IsFocus'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'焦点'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'IsFocus'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'IsSideShow')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'幻灯'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'IsSideShow'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'幻灯'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'IsSideShow'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'IsAllowComment')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否允许评论'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'IsAllowComment'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否允许评论'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'IsAllowComment'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'TagIdStr')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'关键字编号串'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'TagIdStr'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'关键字编号串'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'TagIdStr'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'TagNameStr')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'关键字名称串 '
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'TagNameStr'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'关键字名称串 '
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'TagNameStr'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'SpecialIdStr')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'专题Id串'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'SpecialIdStr'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'专题Id串'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'SpecialIdStr'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'Content')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'下载介绍(内容)'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'Content'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'下载介绍(内容)'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'Content'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'Edition')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'版本号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'Edition'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'版本号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'Edition'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'PlayAddress')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'演示地址'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'PlayAddress'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'演示地址'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'PlayAddress'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'DownLoadDownNum')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'下载统计(总计)'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'DownLoadDownNum'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'下载统计(总计)'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'DownLoadDownNum'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'DownLoadDownMonthNum')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'下载统计(月数)'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'DownLoadDownMonthNum'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'下载统计(月数)'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'DownLoadDownMonthNum'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'DownLoadDownWeekNum')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'下载统计(周数)'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'DownLoadDownWeekNum'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'下载统计(周数)'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'DownLoadDownWeekNum'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'DownLoadDownDayNum')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'下载统计(天数)'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'DownLoadDownDayNum'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'下载统计(天数)'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'DownLoadDownDayNum'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'DownLoadOS')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'运行环境'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'DownLoadOS'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'运行环境'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'DownLoadOS'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'DownLoadServerDataId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'下载服务器类别ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'DownLoadServerDataId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'下载服务器类别ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'DownLoadServerDataId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'Language')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'下载数据语言'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'Language'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'下载数据语言'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'Language'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'WarrantType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'授权方式'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'WarrantType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'授权方式'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'WarrantType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'DownLoadSize')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'文件大小'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'DownLoadSize'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'文件大小'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'DownLoadSize'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'RegAddress')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'注册地址'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'RegAddress'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'注册地址'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'RegAddress'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'Plugin')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'插件认证'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'Plugin'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'插件认证'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'Plugin'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'DownLoadStarLevel')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'下载等级 ★'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'DownLoadStarLevel'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'下载等级 ★'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'DownLoadStarLevel'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadData', 
'COLUMN', N'DownLoadDisplePwd')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'解压密码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'DownLoadDisplePwd'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'解压密码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadData'
, @level2type = 'COLUMN', @level2name = N'DownLoadDisplePwd'
GO

-- ----------------------------
-- Records of KyDownLoadData
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyDownLoadData] ON
GO
SET IDENTITY_INSERT [dbo].[KyDownLoadData] OFF
GO

-- ----------------------------
-- Table structure for KyDownLoadServerData
-- ----------------------------
DROP TABLE [dbo].[KyDownLoadServerData]
GO
CREATE TABLE [dbo].[KyDownLoadServerData] (
[DownLoadServerDataId] int NOT NULL IDENTITY(1,1) ,
[TypeId] int NULL ,
[DownLoadServerName] nvarchar(50) NULL ,
[DownLoadServerDir] nvarchar(50) NULL ,
[IsOpened] bit NULL DEFAULT (0) ,
[IsOuter] int NULL DEFAULT (0) ,
[UnionId] text NULL ,
[DayDownNum] int NULL ,
[AllDownNum] int NULL ,
[AddTime] datetime NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyDownLoadServerData]', RESEED, 11)
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadServerData', 
'COLUMN', N'DownLoadServerDataId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'下载服务器Id(自动编号)'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadServerData'
, @level2type = 'COLUMN', @level2name = N'DownLoadServerDataId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'下载服务器Id(自动编号)'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadServerData'
, @level2type = 'COLUMN', @level2name = N'DownLoadServerDataId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadServerData', 
'COLUMN', N'TypeId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'所属类别编号Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadServerData'
, @level2type = 'COLUMN', @level2name = N'TypeId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'所属类别编号Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadServerData'
, @level2type = 'COLUMN', @level2name = N'TypeId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadServerData', 
'COLUMN', N'DownLoadServerName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'下载服务器名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadServerData'
, @level2type = 'COLUMN', @level2name = N'DownLoadServerName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'下载服务器名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadServerData'
, @level2type = 'COLUMN', @level2name = N'DownLoadServerName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadServerData', 
'COLUMN', N'DownLoadServerDir')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'下载服务器路径'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadServerData'
, @level2type = 'COLUMN', @level2name = N'DownLoadServerDir'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'下载服务器路径'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadServerData'
, @level2type = 'COLUMN', @level2name = N'DownLoadServerDir'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadServerData', 
'COLUMN', N'IsOpened')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'服务器状态0 禁用 1启用'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadServerData'
, @level2type = 'COLUMN', @level2name = N'IsOpened'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'服务器状态0 禁用 1启用'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadServerData'
, @level2type = 'COLUMN', @level2name = N'IsOpened'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadServerData', 
'COLUMN', N'IsOuter')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否外部链接地址0 否 1 WEB迅雷专用下载地址 2 FLASHGET(快车)专用下载地址'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadServerData'
, @level2type = 'COLUMN', @level2name = N'IsOuter'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否外部链接地址0 否 1 WEB迅雷专用下载地址 2 FLASHGET(快车)专用下载地址'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadServerData'
, @level2type = 'COLUMN', @level2name = N'IsOuter'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadServerData', 
'COLUMN', N'UnionId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'联盟Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadServerData'
, @level2type = 'COLUMN', @level2name = N'UnionId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'联盟Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadServerData'
, @level2type = 'COLUMN', @level2name = N'UnionId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadServerData', 
'COLUMN', N'DayDownNum')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'下载数(天数)'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadServerData'
, @level2type = 'COLUMN', @level2name = N'DayDownNum'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'下载数(天数)'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadServerData'
, @level2type = 'COLUMN', @level2name = N'DayDownNum'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadServerData', 
'COLUMN', N'AllDownNum')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'下载数(总计)'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadServerData'
, @level2type = 'COLUMN', @level2name = N'AllDownNum'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'下载数(总计)'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadServerData'
, @level2type = 'COLUMN', @level2name = N'AllDownNum'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyDownLoadServerData', 
'COLUMN', N'AddTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'添加时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadServerData'
, @level2type = 'COLUMN', @level2name = N'AddTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'添加时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyDownLoadServerData'
, @level2type = 'COLUMN', @level2name = N'AddTime'
GO

-- ----------------------------
-- Records of KyDownLoadServerData
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyDownLoadServerData] ON
GO
SET IDENTITY_INSERT [dbo].[KyDownLoadServerData] OFF
GO

-- ----------------------------
-- Table structure for KyDownLoadServerType
-- ----------------------------
DROP TABLE [dbo].[KyDownLoadServerType]
GO
CREATE TABLE [dbo].[KyDownLoadServerType] (
[TypeId] int NOT NULL IDENTITY(1,1) ,
[TypeName] nvarchar(100) NOT NULL DEFAULT '' 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyDownLoadServerType]', RESEED, 4)
GO

-- ----------------------------
-- Records of KyDownLoadServerType
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyDownLoadServerType] ON
GO
SET IDENTITY_INSERT [dbo].[KyDownLoadServerType] OFF
GO

-- ----------------------------
-- Table structure for KyEnterprise
-- ----------------------------
DROP TABLE [dbo].[KyEnterprise]
GO
CREATE TABLE [dbo].[KyEnterprise] (
[Id] int NOT NULL IDENTITY(1,1) ,
[UserId] int NULL ,
[TypeId] int NULL DEFAULT (0) ,
[Title] nvarchar(200) NULL ,
[Conetent] text NULL ,
[AddTime] nvarchar(50) NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyEnterprise]', RESEED, 29)
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyEnterprise', 
'COLUMN', N'UserId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyEnterprise'
, @level2type = 'COLUMN', @level2name = N'UserId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyEnterprise'
, @level2type = 'COLUMN', @level2name = N'UserId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyEnterprise', 
'COLUMN', N'TypeId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'类别ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyEnterprise'
, @level2type = 'COLUMN', @level2name = N'TypeId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'类别ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyEnterprise'
, @level2type = 'COLUMN', @level2name = N'TypeId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyEnterprise', 
'COLUMN', N'Title')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'公司新闻标题'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyEnterprise'
, @level2type = 'COLUMN', @level2name = N'Title'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'公司新闻标题'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyEnterprise'
, @level2type = 'COLUMN', @level2name = N'Title'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyEnterprise', 
'COLUMN', N'Conetent')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'公司新闻内容'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyEnterprise'
, @level2type = 'COLUMN', @level2name = N'Conetent'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'公司新闻内容'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyEnterprise'
, @level2type = 'COLUMN', @level2name = N'Conetent'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyEnterprise', 
'COLUMN', N'AddTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'添加时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyEnterprise'
, @level2type = 'COLUMN', @level2name = N'AddTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'添加时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyEnterprise'
, @level2type = 'COLUMN', @level2name = N'AddTime'
GO

-- ----------------------------
-- Records of KyEnterprise
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyEnterprise] ON
GO
INSERT INTO [dbo].[KyEnterprise] ([Id], [UserId], [TypeId], [Title], [Conetent], [AddTime]) VALUES (N'1', N'730', N'75', N'fff', N'<p>fddfdf</p>', N'2007-12-11 11:44:47')
GO
GO
INSERT INTO [dbo].[KyEnterprise] ([Id], [UserId], [TypeId], [Title], [Conetent], [AddTime]) VALUES (N'2', N'730', N'75', N'aa', N'<p>aa</p>', N'2007-12-11 15:27:49')
GO
GO
INSERT INTO [dbo].[KyEnterprise] ([Id], [UserId], [TypeId], [Title], [Conetent], [AddTime]) VALUES (N'3', N'730', N'75', N'aa', N'<p>aa</p>', N'2007-12-11 15:27:56')
GO
GO
INSERT INTO [dbo].[KyEnterprise] ([Id], [UserId], [TypeId], [Title], [Conetent], [AddTime]) VALUES (N'4', N'730', N'75', N'aa', N'<p>aa</p>', N'2007-12-11 15:29:00')
GO
GO
INSERT INTO [dbo].[KyEnterprise] ([Id], [UserId], [TypeId], [Title], [Conetent], [AddTime]) VALUES (N'8', N'730', N'75', N'中国四川成都分公司信息1', N'<p举嘭国巛拝逐勽<br>儆卬俸惡兯宅1为嘭国巛拝逐勽儆卬俸惡兯宅1:</p>
<p>中国四川成都分公司信息内容:中国四川成都分公司信息内容:</p>
<p><strike>中国四川成都分公司信息内容:<br />
中国四川成都分公司信息内容:</strike></p>', N'2007-12-12 14:20:58')
GO
GO
INSERT INTO [dbo].[KyEnterprise] ([Id], [UserId], [TypeId], [Title], [Conetent], [AddTime]) VALUES (N'9', N'730', N'122', N'中国四川成都分公司信息2', N'<p举嘭国巛拝逐勽儆卬俸惡兯宅1为嘭国巛拝逐勽儆卬俸惡兯宅1:</p>
<p>中国四川成都分公司信息内容:中国四川成都分公司信息内容:</p>
<p><strike>中国四川成都分公司信息内容:<br />
中国四川成都分公司信息内容:</strike></p>', N'2007-12-12 14:20:58')
GO
GO
INSERT INTO [dbo].[KyEnterprise] ([Id], [UserId], [TypeId], [Title], [Conetent], [AddTime]) VALUES (N'10', N'730', N'122', N'中国四川成都分公司信息3', N'<p举嘭国巛拝逐勽<br>儆卬俸惡兯宅1为嘭国巛拝逐勽儆卬俸惡兯宅1:</p>
<p>中国四川成都分公司信息内容:中国四川成都分公司信息内容:</p>
<p><strike>中国四川成都分公司信息内容:<br />
中国四川成都分公司信息内容:</strike></p>', N'2007-12-12 14:20:58')
GO
GO
INSERT INTO [dbo].[KyEnterprise] ([Id], [UserId], [TypeId], [Title], [Conetent], [AddTime]) VALUES (N'15', N'730', N'0', N'fff', N'<p>fddfdf</p>', N'2007-12-11 11:44:47')
GO
GO
INSERT INTO [dbo].[KyEnterprise] ([Id], [UserId], [TypeId], [Title], [Conetent], [AddTime]) VALUES (N'16', N'730', N'123', N'aa', N'<p>aa</p>', N'2007-12-11 15:27:49')
GO
GO
INSERT INTO [dbo].[KyEnterprise] ([Id], [UserId], [TypeId], [Title], [Conetent], [AddTime]) VALUES (N'17', N'730', N'123', N'aabbbbbbbbbbbbbbb', N'<p>aa</p>', N'2007-12-11 15:27:56')
GO
GO
INSERT INTO [dbo].[KyEnterprise] ([Id], [UserId], [TypeId], [Title], [Conetent], [AddTime]) VALUES (N'18', N'730', N'122', N'aa', N'<p>aa</p>', N'2007-12-11 15:29:00')
GO
GO
INSERT INTO [dbo].[KyEnterprise] ([Id], [UserId], [TypeId], [Title], [Conetent], [AddTime]) VALUES (N'20', N'730', N'123', N'zizhezhengshu', N'<p>zizhezhengshuzizhezhengshuzizhezhengshu</p>
<p>zizhezhengshu</p>
<p>zizhezhengshu</p>', N'2007-12-12 18:11:17')
GO
GO
INSERT INTO [dbo].[KyEnterprise] ([Id], [UserId], [TypeId], [Title], [Conetent], [AddTime]) VALUES (N'21', N'730', N'0', N'证书2', N'<p>fddfdf</p>', N'2007-12-11 11:44:47')
GO
GO
INSERT INTO [dbo].[KyEnterprise] ([Id], [UserId], [TypeId], [Title], [Conetent], [AddTime]) VALUES (N'22', N'730', N'123', N'aabbbbb', N'<p>aa</p>', N'2007-12-11 15:27:49')
GO
GO
INSERT INTO [dbo].[KyEnterprise] ([Id], [UserId], [TypeId], [Title], [Conetent], [AddTime]) VALUES (N'23', N'730', N'123', N'aabbbbbbbbbbbbbbbbb', N'<p>aa</p>', N'2007-12-11 15:27:56')
GO
GO
INSERT INTO [dbo].[KyEnterprise] ([Id], [UserId], [TypeId], [Title], [Conetent], [AddTime]) VALUES (N'24', N'730', N'122', N'资质证书11u', N'<p>aa</p>', N'2007-12-11 15:29:00')
GO
GO
INSERT INTO [dbo].[KyEnterprise] ([Id], [UserId], [TypeId], [Title], [Conetent], [AddTime]) VALUES (N'25', N'730', N'123', N'zizhezhengshu', N'<p>zizhezhengshuzizhezhengshuzizhezhengshu</p>
<p>zizhezhengshu</p>
<p>zizhezhengshu</p>', N'2007-12-12 18:11:17')
GO
GO
INSERT INTO [dbo].[KyEnterprise] ([Id], [UserId], [TypeId], [Title], [Conetent], [AddTime]) VALUES (N'26', N'730', N'75', N'111', N'<p>1111111111111</p>', N'2008-1-2 10:41:42')
GO
GO
INSERT INTO [dbo].[KyEnterprise] ([Id], [UserId], [TypeId], [Title], [Conetent], [AddTime]) VALUES (N'27', N'730', N'76', N'fsdf', N'<p>sadfsda</p>', N'2008-1-2 10:43:36')
GO
GO
INSERT INTO [dbo].[KyEnterprise] ([Id], [UserId], [TypeId], [Title], [Conetent], [AddTime]) VALUES (N'28', N'727', N'75', N'qqqqqqqqqqq', N'<p>qqqqqqqqqqq</p>', N'2008-1-2 14:14:17')
GO
GO
INSERT INTO [dbo].[KyEnterprise] ([Id], [UserId], [TypeId], [Title], [Conetent], [AddTime]) VALUES (N'29', N'727', N'76', N'wwwwwwwww', N'<p>wwwwwwwwwwwwwwwwwwwssssss</p>', N'2008-1-2 14:14:33')
GO
GO
SET IDENTITY_INSERT [dbo].[KyEnterprise] OFF
GO

-- ----------------------------
-- Table structure for KyExpireArticle
-- ----------------------------
DROP TABLE [dbo].[KyExpireArticle]
GO
CREATE TABLE [dbo].[KyExpireArticle] (
[Id] int NOT NULL ,
[ColId] int NOT NULL ,
[Title] nvarchar(50) NULL DEFAULT '' ,
[TitleColor] nvarchar(6) NULL DEFAULT '' ,
[TitleFontType] int NULL DEFAULT '' ,
[TitleType] int NULL DEFAULT (0) ,
[TitleImgPath] varchar(255) NULL DEFAULT '' ,
[UId] int NOT NULL ,
[UName] nvarchar(20) NOT NULL ,
[UserType] int NOT NULL ,
[AdminUId] int NULL ,
[AdminUName] nvarchar(20) NULL DEFAULT '' ,
[Status] int NULL DEFAULT (0) ,
[HitCount] int NULL DEFAULT (0) ,
[AddTime] datetime NOT NULL ,
[UpdateTime] datetime NOT NULL ,
[TemplatePath] varchar(255) NULL DEFAULT '' ,
[PageType] int NULL DEFAULT (1) ,
[IsCreated] bit NULL DEFAULT (0) ,
[UserCateId] int NULL DEFAULT (0) ,
[PointCount] int NULL DEFAULT (0) ,
[ChargeType] int NULL DEFAULT (1) ,
[ChargeHourCount] int NULL DEFAULT (0) ,
[ChargeViewCount] int NULL DEFAULT (0) ,
[IsOpened] int NULL DEFAULT (2) ,
[GroupIdStr] varchar(1000) NULL DEFAULT '' ,
[IsDeleted] bit NULL DEFAULT (0) ,
[IsRecommend] bit NULL DEFAULT (0) ,
[IsTop] bit NULL DEFAULT (0) ,
[IsFocus] bit NULL DEFAULT (0) ,
[IsSideShow] bit NULL DEFAULT (0) ,
[IsAllowComment] bit NULL DEFAULT (0) ,
[TagIdStr] varchar(300) NULL DEFAULT '' ,
[TagNameStr] nvarchar(300) NULL DEFAULT '' ,
[SpecialIdStr] varchar(500) NULL DEFAULT '' ,
[LongTitle] nvarchar(100) NULL DEFAULT '' ,
[Content] ntext NULL DEFAULT '' ,
[ShortContent] nvarchar(200) NULL DEFAULT '' ,
[OuterUrl] varchar(255) NULL DEFAULT '' ,
[Author] nvarchar(50) NULL DEFAULT '' ,
[Source] nvarchar(50) NULL DEFAULT '' ,
[IsHeader] bit NULL DEFAULT (0) ,
[HeaderFont] nvarchar(100) NULL DEFAULT '' ,
[HeaderImgPath] varchar(255) NULL DEFAULT '' ,
[StarLevel] nvarchar(50) NULL DEFAULT '' ,
[IsShowCommentLink] bit NULL DEFAULT (0) ,
[IsIrregular] bit NULL DEFAULT (0) ,
[IrregularId] int NULL DEFAULT (0) ,
[ViewUName] ntext NULL DEFAULT '' ,
[ViewUName2] ntext NULL DEFAULT '' ,
[ViewEndTime] nvarchar(20) NULL DEFAULT '' ,
[ExpireTime] datetime NOT NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'Id')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'内容编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'Id'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'内容编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'Id'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'ColId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'栏目编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'ColId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'栏目编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'ColId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'Title')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'内容名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'Title'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'内容名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'Title'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'TitleColor')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'标题颜色代码 形如6c6c6c 前面没有#'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'TitleColor'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'标题颜色代码 形如6c6c6c 前面没有#'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'TitleColor'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'TitleFontType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'标题字体类型 0普通 1粗体 2斜体'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'TitleFontType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'标题字体类型 0普通 1粗体 2斜体'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'TitleFontType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'TitleType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'标题类型 1文字标题 2图片标题'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'TitleType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'标题类型 1文字标题 2图片标题'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'TitleType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'TitleImgPath')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'图片标题路径 当为图片标题时必填'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'TitleImgPath'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'图片标题路径 当为图片标题时必填'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'TitleImgPath'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'UId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'录入者编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'UId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'录入者编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'UId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'UName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'录入者名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'UName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'录入者名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'UName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'UserType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'录入者类型  0用户 1管理员'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'UserType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'录入者类型  0用户 1管理员'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'UserType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'AdminUId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'审核者编号/责任编辑编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'AdminUId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'审核者编号/责任编辑编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'AdminUId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'AdminUName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'审核者名称/责任编辑名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'AdminUName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'审核者名称/责任编辑名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'AdminUName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'Status')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'-1草稿 0待审 1一审 2二审 3三审'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'Status'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'-1草稿 0待审 1一审 2二审 3三审'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'Status'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'HitCount')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'点击次数'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'HitCount'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'点击次数'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'HitCount'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'AddTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'添加时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'AddTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'添加时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'AddTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'UpdateTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'最后修改时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'UpdateTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'最后修改时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'UpdateTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'TemplatePath')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'模板路径'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'TemplatePath'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'模板路径'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'TemplatePath'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'PageType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'1 html 2 htm 3 shtml 4 aspx'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'PageType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'1 html 2 htm 3 shtml 4 aspx'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'PageType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'IsCreated')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否已经生成'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'IsCreated'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否已经生成'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'IsCreated'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'UserCateId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户专栏编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'UserCateId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户专栏编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'UserCateId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'PointCount')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'收费金币个数'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'PointCount'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'收费金币个数'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'PointCount'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'ChargeType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'收费方式'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'ChargeType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'收费方式'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'ChargeType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'ChargeHourCount')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'多少小时后重复收费'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'ChargeHourCount'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'多少小时后重复收费'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'ChargeHourCount'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'ChargeViewCount')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'多少次后重复收费'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'ChargeViewCount'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'多少次后重复收费'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'ChargeViewCount'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'IsOpened')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否时开放内容  0认证 1开放 2继承栏目设置'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'IsOpened'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否时开放内容  0认证 1开放 2继承栏目设置'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'IsOpened'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'GroupIdStr')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'认证时允许访问用户组编号串 用 |编号1|编号2| 的形式'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'GroupIdStr'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'认证时允许访问用户组编号串 用 |编号1|编号2| 的形式'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'GroupIdStr'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'IsDeleted')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否被删除到回收站'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'IsDeleted'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否被删除到回收站'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'IsDeleted'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'IsRecommend')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'推荐'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'IsRecommend'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'推荐'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'IsRecommend'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'IsTop')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'置顶'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'IsTop'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'置顶'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'IsTop'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'IsFocus')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'焦点'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'IsFocus'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'焦点'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'IsFocus'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'IsSideShow')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'幻灯'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'IsSideShow'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'幻灯'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'IsSideShow'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'IsAllowComment')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否允许评论'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'IsAllowComment'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否允许评论'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'IsAllowComment'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'TagIdStr')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'关键字编号串'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'TagIdStr'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'关键字编号串'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'TagIdStr'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'TagNameStr')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'关键字名称串 '
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'TagNameStr'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'关键字名称串 '
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'TagNameStr'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'SpecialIdStr')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'专题Id串'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'SpecialIdStr'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'专题Id串'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'SpecialIdStr'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'LongTitle')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'副标题'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'LongTitle'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'副标题'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'LongTitle'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'Content')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'描述信息'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'Content'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'描述信息'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'Content'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'IsHeader')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'头条'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'IsHeader'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'头条'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'IsHeader'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'HeaderFont')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'头条文字和属性'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'HeaderFont'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'头条文字和属性'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'HeaderFont'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'HeaderImgPath')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'图片头条路径'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'HeaderImgPath'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'图片头条路径'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'HeaderImgPath'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'StarLevel')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'评分等级 ★'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'StarLevel'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'评分等级 ★'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'StarLevel'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'IsShowCommentLink')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否标题旁显示评论链接'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'IsShowCommentLink'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否标题旁显示评论链接'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'IsShowCommentLink'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'IsIrregular')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否不规则'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'IsIrregular'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否不规则'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'IsIrregular'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'IrregularId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'不规则新闻所属类别编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'IrregularId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'不规则新闻所属类别编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'IrregularId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'ViewUName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'指定可以阅读该内容的用户串'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'ViewUName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'指定可以阅读该内容的用户串'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'ViewUName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'ViewUName2')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'已经阅读过的用户'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'ViewUName2'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'已经阅读过的用户'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'ViewUName2'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyExpireArticle', 
'COLUMN', N'ViewEndTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'最后签收时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'ViewEndTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'最后签收时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyExpireArticle'
, @level2type = 'COLUMN', @level2name = N'ViewEndTime'
GO

-- ----------------------------
-- Records of KyExpireArticle
-- ----------------------------

-- ----------------------------
-- Table structure for KyFeedback
-- ----------------------------
DROP TABLE [dbo].[KyFeedback]
GO
CREATE TABLE [dbo].[KyFeedback] (
[ID] int NOT NULL IDENTITY(1,1) ,
[ParentId] int NULL ,
[title] nvarchar(100) NOT NULL DEFAULT '' ,
[author] nvarchar(20) NOT NULL DEFAULT '' ,
[reward] int NULL DEFAULT (0) ,
[scoring] int NULL DEFAULT (0) ,
[categoryId] int NULL DEFAULT (5) ,
[content] ntext NULL DEFAULT '' ,
[state] int NULL DEFAULT (0) ,
[replyDate] datetime NULL DEFAULT (getdate()) ,
[EndDate] datetime NULL ,
[IP] nvarchar(15) NULL DEFAULT '' 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyFeedback]', RESEED, 11)
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyFeedback', 
'COLUMN', N'ID')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyFeedback'
, @level2type = 'COLUMN', @level2name = N'ID'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyFeedback'
, @level2type = 'COLUMN', @level2name = N'ID'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyFeedback', 
'COLUMN', N'ParentId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'父编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyFeedback'
, @level2type = 'COLUMN', @level2name = N'ParentId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'父编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyFeedback'
, @level2type = 'COLUMN', @level2name = N'ParentId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyFeedback', 
'COLUMN', N'title')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'标题'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyFeedback'
, @level2type = 'COLUMN', @level2name = N'title'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'标题'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyFeedback'
, @level2type = 'COLUMN', @level2name = N'title'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyFeedback', 
'COLUMN', N'author')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'作者'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyFeedback'
, @level2type = 'COLUMN', @level2name = N'author'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'作者'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyFeedback'
, @level2type = 'COLUMN', @level2name = N'author'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyFeedback', 
'COLUMN', N'reward')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'悬赏分'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyFeedback'
, @level2type = 'COLUMN', @level2name = N'reward'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'悬赏分'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyFeedback'
, @level2type = 'COLUMN', @level2name = N'reward'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyFeedback', 
'COLUMN', N'scoring')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'得分'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyFeedback'
, @level2type = 'COLUMN', @level2name = N'scoring'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'得分'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyFeedback'
, @level2type = 'COLUMN', @level2name = N'scoring'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyFeedback', 
'COLUMN', N'categoryId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'问答所属分类'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyFeedback'
, @level2type = 'COLUMN', @level2name = N'categoryId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'问答所属分类'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyFeedback'
, @level2type = 'COLUMN', @level2name = N'categoryId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyFeedback', 
'COLUMN', N'content')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'详细内容'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyFeedback'
, @level2type = 'COLUMN', @level2name = N'content'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'详细内容'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyFeedback'
, @level2type = 'COLUMN', @level2name = N'content'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyFeedback', 
'COLUMN', N'state')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'问答状态 0问答中 1已完成 2锁定'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyFeedback'
, @level2type = 'COLUMN', @level2name = N'state'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'问答状态 0问答中 1已完成 2锁定'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyFeedback'
, @level2type = 'COLUMN', @level2name = N'state'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyFeedback', 
'COLUMN', N'replyDate')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'帖子发布日期'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyFeedback'
, @level2type = 'COLUMN', @level2name = N'replyDate'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'帖子发布日期'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyFeedback'
, @level2type = 'COLUMN', @level2name = N'replyDate'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyFeedback', 
'COLUMN', N'EndDate')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'截至日期'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyFeedback'
, @level2type = 'COLUMN', @level2name = N'EndDate'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'截至日期'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyFeedback'
, @level2type = 'COLUMN', @level2name = N'EndDate'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyFeedback', 
'COLUMN', N'IP')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'Ip'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyFeedback'
, @level2type = 'COLUMN', @level2name = N'IP'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'Ip'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyFeedback'
, @level2type = 'COLUMN', @level2name = N'IP'
GO

-- ----------------------------
-- Records of KyFeedback
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyFeedback] ON
GO
SET IDENTITY_INSERT [dbo].[KyFeedback] OFF
GO

-- ----------------------------
-- Table structure for KyHireInfo
-- ----------------------------
DROP TABLE [dbo].[KyHireInfo]
GO
CREATE TABLE [dbo].[KyHireInfo] (
[ID] int NOT NULL IDENTITY(1,1) ,
[UId] int NULL ,
[UserName] nvarchar(20) NULL ,
[UnitId] int NULL ,
[UnitName] nvarchar(100) NULL ,
[UserType] int NULL ,
[Status] int NULL ,
[AddTime] datetime NULL ,
[JobId] int NULL 
)


GO

-- ----------------------------
-- Records of KyHireInfo
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyHireInfo] ON
GO
SET IDENTITY_INSERT [dbo].[KyHireInfo] OFF
GO

-- ----------------------------
-- Table structure for KyImage
-- ----------------------------
DROP TABLE [dbo].[KyImage]
GO
CREATE TABLE [dbo].[KyImage] (
[Id] int NOT NULL IDENTITY(1,1) ,
[ColId] int NOT NULL ,
[Title] nvarchar(200) NULL DEFAULT '' ,
[TitleColor] nvarchar(6) NULL DEFAULT (0) ,
[TitleFontType] int NULL DEFAULT (0) ,
[TitleType] int NULL DEFAULT (0) ,
[TitleImgPath] varchar(255) NULL DEFAULT '' ,
[UId] int NOT NULL ,
[UName] nvarchar(20) NOT NULL ,
[UserType] int NOT NULL ,
[AdminUId] int NULL ,
[AdminUName] nvarchar(20) NULL DEFAULT '' ,
[Status] int NULL DEFAULT (0) ,
[HitCount] int NULL DEFAULT (0) ,
[AddTime] datetime NOT NULL ,
[UpdateTime] datetime NOT NULL ,
[TemplatePath] varchar(255) NULL DEFAULT '' ,
[PageType] int NULL DEFAULT (1) ,
[IsCreated] bit NULL DEFAULT (0) ,
[UserCateId] int NULL DEFAULT (0) ,
[PointCount] int NULL DEFAULT (0) ,
[ChargeType] int NULL DEFAULT (1) ,
[ChargeHourCount] int NULL DEFAULT (0) ,
[ChargeViewCount] int NULL DEFAULT (0) ,
[IsOpened] int NULL DEFAULT (2) ,
[GroupIdStr] varchar(200) NULL DEFAULT '' ,
[IsDeleted] bit NOT NULL DEFAULT (0) ,
[IsRecommend] bit NULL DEFAULT (0) ,
[IsTop] bit NULL DEFAULT (0) ,
[IsFocus] bit NULL DEFAULT (0) ,
[IsSideShow] bit NULL DEFAULT (0) ,
[TagIdStr] varchar(300) NULL DEFAULT '' ,
[IsAllowComment] bit NULL DEFAULT (0) ,
[TagNameStr] nvarchar(300) NULL DEFAULT '' ,
[SpecialIdStr] varchar(200) NULL DEFAULT '' ,
[Content] ntext NULL DEFAULT '' ,
[ImgPath] ntext NULL DEFAULT '' 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyImage]', RESEED, 128)
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyImage', 
'COLUMN', N'Id')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'内容编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'Id'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'内容编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'Id'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyImage', 
'COLUMN', N'ColId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'栏目编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'ColId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'栏目编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'ColId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyImage', 
'COLUMN', N'Title')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'标题名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'Title'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'标题名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'Title'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyImage', 
'COLUMN', N'TitleColor')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'标题颜色代码 形如6c6c6c 前面没有#'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'TitleColor'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'标题颜色代码 形如6c6c6c 前面没有#'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'TitleColor'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyImage', 
'COLUMN', N'TitleFontType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'标题字体类型 0普通 1粗体 2斜体'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'TitleFontType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'标题字体类型 0普通 1粗体 2斜体'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'TitleFontType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyImage', 
'COLUMN', N'TitleType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'标题类型 1文字标题 2图片标题'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'TitleType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'标题类型 1文字标题 2图片标题'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'TitleType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyImage', 
'COLUMN', N'TitleImgPath')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'图片标题路径 当为图片标题时必填'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'TitleImgPath'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'图片标题路径 当为图片标题时必填'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'TitleImgPath'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyImage', 
'COLUMN', N'UId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'录入者编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'UId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'录入者编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'UId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyImage', 
'COLUMN', N'UName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'录入者名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'UName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'录入者名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'UName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyImage', 
'COLUMN', N'UserType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'录入者类型  0用户 1管理员'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'UserType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'录入者类型  0用户 1管理员'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'UserType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyImage', 
'COLUMN', N'AdminUId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'审核者编号/责任编辑编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'AdminUId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'审核者编号/责任编辑编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'AdminUId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyImage', 
'COLUMN', N'AdminUName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'审核者名称/责任编辑名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'AdminUName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'审核者名称/责任编辑名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'AdminUName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyImage', 
'COLUMN', N'Status')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'-1草稿 0待审 1一审 2二审 3三审'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'Status'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'-1草稿 0待审 1一审 2二审 3三审'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'Status'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyImage', 
'COLUMN', N'HitCount')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'点击次数'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'HitCount'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'点击次数'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'HitCount'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyImage', 
'COLUMN', N'AddTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'添加时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'AddTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'添加时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'AddTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyImage', 
'COLUMN', N'UpdateTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'最后修改时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'UpdateTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'最后修改时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'UpdateTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyImage', 
'COLUMN', N'TemplatePath')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'模板路径'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'TemplatePath'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'模板路径'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'TemplatePath'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyImage', 
'COLUMN', N'PageType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'1 html 2 htm 3 shtml 4 aspx'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'PageType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'1 html 2 htm 3 shtml 4 aspx'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'PageType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyImage', 
'COLUMN', N'IsCreated')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否已经生成'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'IsCreated'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否已经生成'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'IsCreated'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyImage', 
'COLUMN', N'UserCateId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户专栏编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'UserCateId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户专栏编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'UserCateId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyImage', 
'COLUMN', N'PointCount')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'收费金币个数'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'PointCount'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'收费金币个数'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'PointCount'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyImage', 
'COLUMN', N'ChargeType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'收费方式'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'ChargeType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'收费方式'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'ChargeType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyImage', 
'COLUMN', N'IsOpened')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否时开放内容  0认证 1开放 2继承栏目设置'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'IsOpened'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否时开放内容  0认证 1开放 2继承栏目设置'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'IsOpened'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyImage', 
'COLUMN', N'GroupIdStr')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'认证时允许访问用户组编号串 用 |编号1|编号2| 的形式'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'GroupIdStr'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'认证时允许访问用户组编号串 用 |编号1|编号2| 的形式'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'GroupIdStr'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyImage', 
'COLUMN', N'IsDeleted')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否被删除到回收站'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'IsDeleted'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否被删除到回收站'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'IsDeleted'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyImage', 
'COLUMN', N'IsRecommend')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'推荐'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'IsRecommend'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'推荐'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'IsRecommend'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyImage', 
'COLUMN', N'IsTop')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'置顶'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'IsTop'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'置顶'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'IsTop'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyImage', 
'COLUMN', N'IsFocus')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'焦点'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'IsFocus'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'焦点'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'IsFocus'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyImage', 
'COLUMN', N'IsSideShow')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'幻灯'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'IsSideShow'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'幻灯'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'IsSideShow'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyImage', 
'COLUMN', N'TagIdStr')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'关键字编号串'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'TagIdStr'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'关键字编号串'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'TagIdStr'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyImage', 
'COLUMN', N'IsAllowComment')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否允许评论'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'IsAllowComment'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否允许评论'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'IsAllowComment'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyImage', 
'COLUMN', N'TagNameStr')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'关键字名称串 '
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'TagNameStr'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'关键字名称串 '
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'TagNameStr'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyImage', 
'COLUMN', N'SpecialIdStr')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'所属专题编号串 |编号1|编号2|'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'SpecialIdStr'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'所属专题编号串 |编号1|编号2|'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'SpecialIdStr'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyImage', 
'COLUMN', N'Content')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'描述信息'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'Content'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'描述信息'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'Content'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyImage', 
'COLUMN', N'ImgPath')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'图片文件名称串 |文件名|'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'ImgPath'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'图片文件名称串 |文件名|'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyImage'
, @level2type = 'COLUMN', @level2name = N'ImgPath'
GO

-- ----------------------------
-- Records of KyImage
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyImage] ON
GO
SET IDENTITY_INSERT [dbo].[KyImage] OFF
GO

-- ----------------------------
-- Table structure for KyLabelContent
-- ----------------------------
DROP TABLE [dbo].[KyLabelContent]
GO
CREATE TABLE [dbo].[KyLabelContent] (
[LabelCategoryID] int NOT NULL IDENTITY(1,1) ,
[Name] nvarchar(50) NULL ,
[Content] text NULL ,
[AnomalyStyle] text NULL ,
[LbCategoryId] int NULL ,
[ModeType] int NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyLabelContent]', RESEED, 41)
GO

-- ----------------------------
-- Records of KyLabelContent
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyLabelContent] ON
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'1', N'{Ky_日期调用}', N'<script>
<!--var day="";
var month="";
var ampm="";
var ampmhour="";
var myweekday="";
var year="";
mydate=new Date();
myweekday=mydate.getDay();
mymonth=mydate.getMonth()+1;
myday= mydate.getDate();
myyear= mydate.getYear();
year=(myyear > 200) ? myyear : 1900 + myyear;
if(myweekday == 0)
weekday=" 星期日 ";
else if(myweekday == 1)
weekday=" 星期一 ";
else if(myweekday == 2)
weekday=" 星期二 ";
else if(myweekday == 3)
weekday=" 星期三 ";
else if(myweekday == 4)
weekday=" 星期四 ";
else if(myweekday == 5)
weekday=" 星期五 ";
else if(myweekday == 6)
weekday=" 星期六 ";
document.write(year+"年"+mymonth+"月"+myday+"日 "+weekday);
	//-->
  </script>', N'', N'3', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'2', N'{Ky_用户登陆}', N'{$ky arrange="vertical"  id="login"  /}', N'', N'3', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'3', N'{Ky_最新文章}', N'{$ky id="ch_infolist" chid="1" cellcount="1" liststyle="1" modelid="1" showstyle="out_table" dateformat="YY年MM月DD日" infocount="7" property1="" property2="" daterange="0" order="datedesc" titlelength="30" rowcount="" compart="" /}', N'', N'2', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'4', N'{Ky_全站导航}', N'{$ky id="index_ch_nav" navcss="1" arrange="true" target="_self" navcount="10" compart="┋"/}', N'', N'3', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'5', N'{Ky_搜索}', N'{$ky id="searchform" chcolsearch="show" /}', N'', N'2', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'6', N'{Ky_首页文章列表}', N'{$ky id="ch_infolist" chid="1" cellcount="1" liststyle="2" modelid="1" showstyle="out_table" dateformat="MM月DD日" infocount="8" property1="" property2="" daterange="0" order="datedesc" titlelength="36" rowcount="" compart="" /}', N'', N'2', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'7', N'{Ky_热门阅读}', N'{$ky id="ch_infolist" chid="1" cellcount="1" liststyle="3" modelid="1" showstyle="out_table" dateformat="YY年MM月DD日" infocount="10" property1="ishot$1" property2="" daterange="0" order="hitdesc" titlelength="22" rowcount="" compart="" /}', N'', N'2', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'8', N'{Ky_文章图片}', N'{$ky id="ch_infolist" chid="1" cellcount="4" liststyle="4" modelid="1" showstyle="out_table" dateformat="YY年MM月DD日" infocount="4" property1="titletype$2" property2="" daterange="0" order="datedesc" titlelength="20" rowcount="" compart="" /}', N'', N'2', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'9', N'{Ky_首页最新文章图片}', N'{$ky id="ch_infolist" chid="1" cellcount="1" liststyle="5" modelid="1" showstyle="out_table" dateformat="YY年MM月DD日" infocount="1" property1="titletype$2" property2="" daterange="0" order="datedesc" titlelength="20" rowcount="" compart="" /}', N'', N'2', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'10', N'{Ky_首页幻灯}', N'{$ky id="col_flashinfolist" chid="1" colid="all" includesub="true" infocount="5" titlelength="24" imgsize="170,236" /}', N'', N'2', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'11', N'{Ky_热门下载}', N'{$ky id="ch_infolist" chid="2" cellcount="1" liststyle="3" modelid="3" showstyle="out_table" dateformat="YY年MM月DD日" infocount="10" property1="ishot$1" property2="" daterange="0" order="hitdesc" titlelength="22" rowcount="" compart="" /}', N'', N'2', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'12', N'{Ky_首页投票}', N'{$ky id="vote" topicstyle="" votesubjectid="1" optionstyle="" arrange="vertical" /}', N'', N'2', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'13', N'{Ky_信息统计}', N'{$ky id="infototal" /}', N'', N'2', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'14', N'{Ky_首页下载图片}', N'{$ky id="ch_infolist" chid="2" cellcount="2" liststyle="4" modelid="3" showstyle="out_table" dateformat="YY年MM月DD日" infocount="4" property1="titletype$2" property2="" daterange="0" order="datedesc" titlelength="22" rowcount="" compart="" /}', N'', N'2', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'15', N'{Ky_首页下载列表}', N'{$ky id="ch_infolist" chid="2" cellcount="1" liststyle="2" modelid="3" showstyle="out_table" dateformat="YY年MM月DD日" infocount="9" property1="" property2="" daterange="0" order="datedesc" titlelength="30" rowcount="" compart="" /}', N'', N'2', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'16', N'{Ky_首页图片频道}', N'{$ky id="ch_infolist" chid="3" cellcount="4" liststyle="4" modelid="2" showstyle="out_table" dateformat="YY年MM月DD日" infocount="4" property1="titletype$2" property2="" daterange="0" order="datedesc" titlelength="30" rowcount="" compart="" /}', N'', N'2', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'17', N'{Ky_友情链接}', N'{$ky id="kylink" type="2" linkcount="20" arrange="false" rowcount="10" linktarget="_blank"  /}', N'', N'2', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'18', N'{Ky_页脚链接}', N'<table width="100%" border="0" cellpadding="0" cellspacing="0" class="td2">
  <tr>
    <td height="30" align="center" bgcolor="EBEBEB" class="copy_1">‖ 设为首页 ‖ 加入收藏 ‖ <a href="mailto:" target="_blank">联系我们</a> ‖ <a href="#" target="_blank">友情链接</a> ‖ <a href="#" target="_blank">免责申明</a> ‖ <a href="../system/login.aspx" target="_blank">管理登录</a> ‖</td>
  </tr>
</table>
<table width="100%" border="0" cellpadding="0" cellspacing="0" class="td2">
  <tr>
    <td height="5"></td>
  </tr>
</table>
<table width="100%" border="0" cellpadding="0" cellspacing="0" class="td2">
  <tr>
    <td align="center" class="copy">Copyright 2007- 2008 &copy; <a href="http://WWW.KYCmS.CoM" target="_blank">WWW.KYCmS.CoM</a><br />
      中华人民共和国信息产业部备案序列号：川ICP备<a href="http://www.miibeian.gov.cn/" target="_blank">00000000</a>号<br />
    程序开发：酷源科技(成都)有限公司 </td>
  </tr>
</table>', N'', N'3', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'19', N'{Ky_频道导航}', N'{$ky id="ch_col_nav" navcss=" " arrange="true" target="_self" navcount="10" compart=" | "/}', N'', N'3', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'20', N'{Ky_当前位置}', N'{$ky id="my_pos" hrefcss="" compart=" >> " showchannel="true" /}', N'', N'3', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'21', N'{Ky_频道推荐}', N'{$ky id="ch_infolist" chid="0" cellcount="1" liststyle="2" modelid="1" showstyle="out_table" dateformat="MM-DD" infocount="10" property1="isrecommend$1" property2="" daterange="0" order="datedesc" titlelength="22" rowcount="" compart="" /}', N'', N'4', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'22', N'{Ky_栏目循环}', N'{$ky id="ch_col_infolist" chid="0" colcount="0" includesub="true" colidstr="" colstyle="6" liststyle="2" modelid="1" colcellcount="2" showstyle="out_table" divid="" divclass="" ulid="" ulclass="" liid="" liclass="" dateformat="MM月DD日" infocount="10" daterange="0" order="datedesc" titlelength="36" rowcount="" compart="" /}', N'', N'4', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'23', N'{Ky_栏目推荐}', N'{$ky id="col_infolist" colid="0" includesub="true" cellcount="1" liststyle="2" modelid="1" showstyle="out_table" dateformat="MM-DD" infocount="10" property1="isrecommend$1" property2="" daterange="0" order="datedesc" titlelength="22" rowcount="" compart="" /}', N'', N'4', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'24', N'{Ky_栏目名称}', N'{$ky id="page_info" type="1" /}', N'', N'4', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'25', N'{Ky_终极列表}', N'{$ky id="col_finallyinfolist" pagenav="<tr><td>{@page_nav}</td></tr>" padding="true" paddingstyle="3" pagesize="10" paddingcss="page" liststyle="2" cellcount="1" modelid="1" showstyle="out_table" dateformat="MM-DD" infocount="0" daterange="0" order="datedesc" titlelength="0" rowcount="" compart="" /}
', N'', N'4', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'26', N'{Ky_图片终极}', N'{$ky id="col_finallyinfolist" padding="true" paddingstyle="" pagesize="10" paddingcss="" liststyle="4" cellcount="4" modelid="2" pagenav="<tr><td>{@page_nav}</td></tr>" showstyle="out_table" dateformat="YY年MM月DD日" infocount="12" daterange="0" order="datedesc" titlelength="20" rowcount="" compart="" /}', N'', N'4', N'2')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'27', N'{Ky_子类循环}', N'{$ky id="col_childcol_infolist" chid="0" colcount="" includesub="true"colstyle="6" liststyle="2" modelid="1" colcellcount="2" showstyle="out_table" divid="" divclass="" ulid="" ulclass="" liid="" liclass="" dateformat="MM-DD" infocount="10" daterange="0" order="datedesc" titlelength="30" rowcount="" compart="" /}', N'', N'4', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'28', N'{Ky_热门图片}', N'{$ky id="col_infolist" colid="0" includesub="true" cellcount="1" liststyle="3" modelid="2" showstyle="out_table" dateformat="YY年MM月DD日" infocount="10" property1="ishot$1" property2="" daterange="0" order="hitdesc" titlelength="22" rowcount="" compart="" /}', N'', N'4', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'29', N'{Ky_推荐图片}', N'{$ky id="ch_infolist" chid="3" cellcount="1" liststyle="2" modelid="2" showstyle="out_table" dateformat="MM-DD" infocount="10" property1="isrecommend$1" property2="" daterange="0" order="datedesc" titlelength="22" rowcount="" compart="" /}', N'', N'4', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'30', N'{Ky_下载最新}', N'{$ky id="ch_infolist" chid="2" cellcount="1" liststyle="1" modelid="3" showstyle="out_table" dateformat="YY年MM月DD日" infocount="7" property1="" property2="" daterange="0" order="datedesc" titlelength="30" rowcount="" compart="" /}', N'', N'4', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'31', N'{Ky_图片最新}', N'{$ky id="ch_infolist" chid="3" cellcount="1" liststyle="1" modelid="2" showstyle="out_table" dateformat="YY年MM月DD日" infocount="7" property1="" property2="" daterange="0" order="datedesc" titlelength="30" rowcount="" compart="" /}', N'', N'4', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'32', N'{Ky_图片最新缩图}', N'{$ky id="ch_infolist" chid="3" cellcount="1" liststyle="5" modelid="2" showstyle="out_table" dateformat="YY年MM月DD日" infocount="1" property1="titletype$2" property2="" daterange="0" order="datedesc" titlelength="22" rowcount="" compart="" /}', N'', N'4', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'33', N'{Ky_新闻推荐}', N'{$ky id="ch_infolist" chid="1" cellcount="1" liststyle="2" modelid="1" showstyle="out_table" dateformat="MM-DD" infocount="10" property1="isrecommend$1" property2="" daterange="0" order="datedesc" titlelength="22" rowcount="" compart="" /}', N'', N'4', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'34', N'{Ky_下载终极}', N'{$ky id="col_finallyinfolist" padding="true" paddingstyle="3" pagesize="10" paddingcss="page" liststyle="9" cellcount="1" modelid="3" showstyle="out_table" dateformat="20YY-MM-DD" infocount="10" daterange="0" order="datedesc" titlelength="30" rowcount="" compart="" /}


', N'', N'4', N'3')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'35', N'{Ky_下载最新图片}', N'{$ky id="ch_infolist" chid="2" cellcount="1" liststyle="5" modelid="3" showstyle="out_table" dateformat="YY年MM月DD日" infocount="1" property1="titletype$2" property2="" daterange="0" order="datedesc" titlelength="22" rowcount="" compart="" /}', N'', N'4', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'36', N'{Ky_图片内容页}', N'{$ky id="browse_info" style="10" dateformat="YY年MM月DD日" /}', N'', N'5', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'37', N'{Ky_文章内容}', N'{$ky id="browse_info" style="7" dateformat="YY年MM月DD日" /}', N'', N'5', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'38', N'{Ky_更多评论}', N'{$ky id="morereviewlist" pagesize="20" /}', N'', N'5', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'39', N'{Ky_下载内容页}', N'{$ky id="browse_info" style="8" dateformat="YY年MM月DD日" /}', N'', N'5', N'1')
GO
GO
INSERT INTO [dbo].[KyLabelContent] ([LabelCategoryID], [Name], [Content], [AnomalyStyle], [LbCategoryId], [ModeType]) VALUES (N'41', N'{Ky_栏目导航}', N'{$ky id="col_childcol_nav" navcss="" arrange="true" target="_self" navcount="" compart=" | "/}', N'', N'4', N'1')
GO
GO
SET IDENTITY_INSERT [dbo].[KyLabelContent] OFF
GO

-- ----------------------------
-- Table structure for KyLbCategory
-- ----------------------------
DROP TABLE [dbo].[KyLbCategory]
GO
CREATE TABLE [dbo].[KyLbCategory] (
[LbCategoryID] int NOT NULL IDENTITY(1,1) ,
[Name] nvarchar(50) NOT NULL ,
[ParentID] int NOT NULL DEFAULT (0) ,
[Desc] nvarchar(100) NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyLbCategory]', RESEED, 37)
GO

-- ----------------------------
-- Records of KyLbCategory
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyLbCategory] ON
GO
INSERT INTO [dbo].[KyLbCategory] ([LbCategoryID], [Name], [ParentID], [Desc]) VALUES (N'1', N'不规则标签', N'0', N'不规则标签')
GO
GO
INSERT INTO [dbo].[KyLbCategory] ([LbCategoryID], [Name], [ParentID], [Desc]) VALUES (N'2', N'首页标签', N'0', null)
GO
GO
INSERT INTO [dbo].[KyLbCategory] ([LbCategoryID], [Name], [ParentID], [Desc]) VALUES (N'3', N'通用标签', N'0', null)
GO
GO
INSERT INTO [dbo].[KyLbCategory] ([LbCategoryID], [Name], [ParentID], [Desc]) VALUES (N'4', N'栏目标签', N'0', N'')
GO
GO
INSERT INTO [dbo].[KyLbCategory] ([LbCategoryID], [Name], [ParentID], [Desc]) VALUES (N'5', N'内容页标签', N'0', N'')
GO
GO
SET IDENTITY_INSERT [dbo].[KyLbCategory] OFF
GO

-- ----------------------------
-- Table structure for KyLink
-- ----------------------------
DROP TABLE [dbo].[KyLink]
GO
CREATE TABLE [dbo].[KyLink] (
[LinkId] int NOT NULL IDENTITY(1,1) ,
[LinkType] int NULL DEFAULT (1) ,
[LinkCategory] nvarchar(20) NULL DEFAULT '' ,
[SiteName] nvarchar(50) NULL DEFAULT '' ,
[SiteUrl] varchar(255) NOT NULL ,
[SiteLogo] varchar(255) NULL DEFAULT '' ,
[OwnerName] nvarchar(50) NULL DEFAULT '' ,
[Email] nvarchar(50) NOT NULL ,
[Description] nvarchar(200) NULL DEFAULT '' ,
[AddTime] datetime NULL ,
[Status] int NOT NULL DEFAULT (1) ,
[IsDisable] bit NULL DEFAULT (0) 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyLink]', RESEED, 18)
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyLink', 
'COLUMN', N'LinkId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'友情链接编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyLink'
, @level2type = 'COLUMN', @level2name = N'LinkId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'友情链接编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyLink'
, @level2type = 'COLUMN', @level2name = N'LinkId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyLink', 
'COLUMN', N'LinkType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'链接类型 1文字链接 2图片链接'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyLink'
, @level2type = 'COLUMN', @level2name = N'LinkType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'链接类型 1文字链接 2图片链接'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyLink'
, @level2type = 'COLUMN', @level2name = N'LinkType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyLink', 
'COLUMN', N'LinkCategory')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'友情链接所属分类名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyLink'
, @level2type = 'COLUMN', @level2name = N'LinkCategory'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'友情链接所属分类名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyLink'
, @level2type = 'COLUMN', @level2name = N'LinkCategory'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyLink', 
'COLUMN', N'SiteName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'站点名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyLink'
, @level2type = 'COLUMN', @level2name = N'SiteName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'站点名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyLink'
, @level2type = 'COLUMN', @level2name = N'SiteName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyLink', 
'COLUMN', N'SiteUrl')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'站点Url'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyLink'
, @level2type = 'COLUMN', @level2name = N'SiteUrl'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'站点Url'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyLink'
, @level2type = 'COLUMN', @level2name = N'SiteUrl'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyLink', 
'COLUMN', N'SiteLogo')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'站点Logo 当LinkType=2时,为必填'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyLink'
, @level2type = 'COLUMN', @level2name = N'SiteLogo'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'站点Logo 当LinkType=2时,为必填'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyLink'
, @level2type = 'COLUMN', @level2name = N'SiteLogo'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyLink', 
'COLUMN', N'OwnerName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'站长姓名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyLink'
, @level2type = 'COLUMN', @level2name = N'OwnerName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'站长姓名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyLink'
, @level2type = 'COLUMN', @level2name = N'OwnerName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyLink', 
'COLUMN', N'Email')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'站长联系Email'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyLink'
, @level2type = 'COLUMN', @level2name = N'Email'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'站长联系Email'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyLink'
, @level2type = 'COLUMN', @level2name = N'Email'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyLink', 
'COLUMN', N'Description')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'站点描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyLink'
, @level2type = 'COLUMN', @level2name = N'Description'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'站点描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyLink'
, @level2type = 'COLUMN', @level2name = N'Description'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyLink', 
'COLUMN', N'AddTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'申请时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyLink'
, @level2type = 'COLUMN', @level2name = N'AddTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'申请时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyLink'
, @level2type = 'COLUMN', @level2name = N'AddTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyLink', 
'COLUMN', N'Status')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'状态 1待审 2正常'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyLink'
, @level2type = 'COLUMN', @level2name = N'Status'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'状态 1待审 2正常'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyLink'
, @level2type = 'COLUMN', @level2name = N'Status'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyLink', 
'COLUMN', N'IsDisable')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否停用'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyLink'
, @level2type = 'COLUMN', @level2name = N'IsDisable'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否停用'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyLink'
, @level2type = 'COLUMN', @level2name = N'IsDisable'
GO

-- ----------------------------
-- Records of KyLink
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyLink] ON
GO
INSERT INTO [dbo].[KyLink] ([LinkId], [LinkType], [LinkCategory], [SiteName], [SiteUrl], [SiteLogo], [OwnerName], [Email], [Description], [AddTime], [Status], [IsDisable]) VALUES (N'18', N'1', N'92', N'51aspx', N'http://www.51aspx.com', N'', N'51aspx', N'', N'Asp.net源码下载专业站', N'2009-06-26 10:14:00.640', N'2', N'0')
GO
GO
SET IDENTITY_INSERT [dbo].[KyLink] OFF
GO

-- ----------------------------
-- Table structure for KyListStyleContent
-- ----------------------------
DROP TABLE [dbo].[KyListStyleContent]
GO
CREATE TABLE [dbo].[KyListStyleContent] (
[ModelId] int NOT NULL ,
[Content] ntext NULL DEFAULT '' 
)


GO

-- ----------------------------
-- Records of KyListStyleContent
-- ----------------------------
INSERT INTO [dbo].[KyListStyleContent] ([ModelId], [Content]) VALUES (N'1', N'<table cellpadding=0 cellspacing=1 width="1000px" height="100px" style="border:solid 1px gray" align="center">
<tr><td>请自行修改111</td></tr>
</table>
<table cellpadding="0" cellspacing="1" width="1000px" height="22px" align="center">
<tr><td>当前位置： {@curr_nav} >> 信息列表</td></tr>
</table>
<table align="center" cellspacing="1" cellpadding="0" style="width:1000px;background-color:gray">
<tr height="28px" style="text-align:center;font-weight:bold;background-color:#a3c7e2">
<td width="600px">标 题</td>
<td width="200px">点击数</td>
<td width="200px">添加时间</td>
</tr>
<ky_loop>
<tr height="22px" style="background-color:white"><td style="padding-left:2px">● [<a href="list.aspx?chid={ky_chid}&colid={ky_colid}">{ky_colname}</a>]<a href="{ky_infourl}" target=''_blank''>{ky_title}</a></td><td align=center>{ky_hitcount}次</td><td align=center>{ky_addtime}</td></tr>
</ky_loop>
</table>
<table cellpadding="0" cellspacing="1" border="0" align="center" width=1000px>
<tr height="22px"><td>{@page_nav}</td></tr>
</table>
<table cellpadding="0" cellspacing="0" width="1000px" height="100px" style="border:solid 1px gray" align="center">
<tr><td>请自行修改</td></tr>
</table>')
GO
GO
INSERT INTO [dbo].[KyListStyleContent] ([ModelId], [Content]) VALUES (N'2', N'<table cellpadding=0 cellspacing=1 width="1000px" height="100px" style="border:solid 1px gray" align="center">
<tr><td>请自行修改</td></tr>
</table>
<table cellpadding="0" cellspacing="1" width="1000px" height="22px" align="center">
<tr><td>当前位置： {@curr_nav} >> 信息列表</td></tr>
</table>
<table align="center" cellspacing="1" cellpadding="0" style="width:1000px;background-color:gray">
<tr height="28px" style="text-align:center;font-weight:bold;background-color:#a3c7e2">
<td width="600px">标 题</td>
<td width="200px">点击数</td>
<td width="200px">添加时间</td>
</tr>
<ky_loop>
<tr height="22px" style="background-color:white"><td style="padding-left:2px">● [<a href="list.aspx?chid={ky_chid}&colid={ky_colid}">{ky_colname}</a>]<a href="{ky_infourl}" target=''_blank''>{ky_title}</a></td><td align=center>{ky_hitcount}次</td><td align=center>{ky_addtime}</td></tr>
</ky_loop>
</table>
<table cellpadding="0" cellspacing="1" border="0" align="center" width=1000px>
<tr height="22px"><td>{@page_nav}</td></tr>
</table>
<table cellpadding="0" cellspacing="0" width="1000px" height="100px" style="border:solid 1px gray" align="center">
<tr><td>请自行修改</td></tr>
</table>')
GO
GO
INSERT INTO [dbo].[KyListStyleContent] ([ModelId], [Content]) VALUES (N'4', N'<table align=center cellspacing=1 cellpadding=0 style=''width:1000px;background-color:gray''>
<tr height=28px style=''text-align:center;font-weight:bold;background-color:#a3c7e2''><td>所属地区</td><td>标 题</td><td>点击数</td><td>添加时间</td></tr>
<ky_loop>
<tr height=22px style=''background-color:white''><td><a href=javascript:showlist("","{KY_chid}","diqu","{KY_diqu}")>{KY_diqu}</a></td><td style=''padding-left:2px''>● [<a href=''list.aspx?chid={ky_chid}&colid={ky_colid}''>{ky_colname}</a>]<a href=''{ky_infourl}'' target=''_blank''>{ky_title}</a></td><td align=center>{ky_hitcount}次</td><td align=center>{ky_addtime}</td></tr>
</ky_loop>
</table>')
GO
GO
INSERT INTO [dbo].[KyListStyleContent] ([ModelId], [Content]) VALUES (N'5', N'<table align=center cellspacing=1 cellpadding=0 style=''width:1000px;background-color:gray''>
<tr height=28px style=''text-align:center;font-weight:bold;background-color:#a3c7e2''><td width="80">自定义字段</td><td>标 题</td><td>点击数</td><td>添加时间</td></tr>
<ky_loop>
<tr height=22px style=''background-color:white''><td width="80" align="center">

<a href=''javascript:showlist('','')''>{KY_dxxl}</a>



</td><td style=''padding-left:2px''>● [<a href=''list.aspx?chid={ky_chid}&colid={ky_colid}''>{ky_colname}</a>]<a href=''{ky_infourl}'' target=''_blank''>{ky_title}</a></td><td align=center>{ky_hitcount}次</td><td align=center>{ky_addtime}</td></tr>
</ky_loop>
</table>

<href=''javascript:list.aspx('''',''{KY_chid}'',''字段名称'',''KY_字段名称'')''>字段值</a>')
GO
GO
INSERT INTO [dbo].[KyListStyleContent] ([ModelId], [Content]) VALUES (N'32', N'<table cellpadding=0 cellspacing=1 width="1000px" height="100px" style="border:solid 1px gray" align="center">
<tr><td>请自行修改</td></tr>
</table>
<table cellpadding="0" cellspacing="1" width="1000px" height="22px" align="center">
<tr><td>当前位置： {@curr_nav} >> 信息列表</td></tr>
</table>
<table align="center" cellspacing="1" cellpadding="0" style="width:1000px;background-color:gray">
<tr height="28px" style="text-align:center;font-weight:bold;background-color:#a3c7e2">
<td width="600px">标 题</td>
<td width="200px">点击数</td>
<td width="200px">添加时间</td>
</tr>
<ky_loop>
<tr height="22px" style="background-color:white"><td style="padding-left:2px">● [<a href="list.aspx?chid={ky_chid}&colid={ky_colid}">{ky_colname}</a>]<a href="{ky_infourl}" target=''_blank''>{ky_title}</a></td><td align=center>{ky_hitcount}次</td><td align=center>{ky_addtime}</td></tr>
</ky_loop>
</table>
<table cellpadding="0" cellspacing="1" border="0" align="center" width=1000px>
<tr height="22px"><td>{@page_nav}</td></tr>
</table>
<table cellpadding="0" cellspacing="0" width="1000px" height="100px" style="border:solid 1px gray" align="center">
<tr><td>请自行修改</td></tr>
</table>')
GO
GO

-- ----------------------------
-- Table structure for KyLog
-- ----------------------------
DROP TABLE [dbo].[KyLog]
GO
CREATE TABLE [dbo].[KyLog] (
[LogId] int NOT NULL IDENTITY(1,1) ,
[Description] nvarchar(100) NULL ,
[UserId] int NULL ,
[UserName] nvarchar(20) NULL ,
[LogTime] datetime NULL ,
[IpAddress] varchar(15) NULL ,
[LogType] int NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyLog]', RESEED, 7)
GO

-- ----------------------------
-- Records of KyLog
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyLog] ON
GO
INSERT INTO [dbo].[KyLog] ([LogId], [Description], [UserId], [UserName], [LogTime], [IpAddress], [LogType]) VALUES (N'2', N'登陆后台', N'10', N'51aspx', N'2009-06-26 10:07:14.267', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyLog] ([LogId], [Description], [UserId], [UserName], [LogTime], [IpAddress], [LogType]) VALUES (N'3', N'配置全站参数设置成功', N'10', N'51aspx', N'2009-06-26 10:09:56.220', N'127.0.0.1', N'3')
GO
GO
INSERT INTO [dbo].[KyLog] ([LogId], [Description], [UserId], [UserName], [LogTime], [IpAddress], [LogType]) VALUES (N'4', N'配置全站参数设置成功', N'10', N'51aspx', N'2009-06-26 10:10:20.000', N'127.0.0.1', N'3')
GO
GO
INSERT INTO [dbo].[KyLog] ([LogId], [Description], [UserId], [UserName], [LogTime], [IpAddress], [LogType]) VALUES (N'5', N'添加栏目：新闻文章', N'10', N'51aspx', N'2009-06-26 10:11:08.733', N'127.0.0.1', N'2')
GO
GO
INSERT INTO [dbo].[KyLog] ([LogId], [Description], [UserId], [UserName], [LogTime], [IpAddress], [LogType]) VALUES (N'6', N'添加栏目：51aspx源码', N'10', N'51aspx', N'2009-06-26 10:11:29.140', N'127.0.0.1', N'2')
GO
GO
INSERT INTO [dbo].[KyLog] ([LogId], [Description], [UserId], [UserName], [LogTime], [IpAddress], [LogType]) VALUES (N'7', N'添加栏目：Asp.net源码', N'10', N'51aspx', N'2009-06-26 10:19:10.187', N'127.0.0.1', N'2')
GO
GO
SET IDENTITY_INSERT [dbo].[KyLog] OFF
GO

-- ----------------------------
-- Table structure for KyModel
-- ----------------------------
DROP TABLE [dbo].[KyModel]
GO
CREATE TABLE [dbo].[KyModel] (
[ModelId] int NOT NULL IDENTITY(1,1) ,
[ModelName] nvarchar(20) NOT NULL ,
[ModelDesc] nvarchar(200) NULL DEFAULT '' ,
[TableName] nvarchar(50) NOT NULL ,
[UploadPath] varchar(50) NOT NULL ,
[UploadSize] int NULL DEFAULT (0) ,
[IsSystem] bit NOT NULL DEFAULT (0) ,
[AddTime] datetime NOT NULL DEFAULT (getdate()) ,
[ModelHtml] ntext NULL ,
[IsHtml] bit NULL DEFAULT (0) 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyModel]', RESEED, 36)
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyModel', 
'COLUMN', N'ModelId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'模型编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyModel'
, @level2type = 'COLUMN', @level2name = N'ModelId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'模型编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyModel'
, @level2type = 'COLUMN', @level2name = N'ModelId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyModel', 
'COLUMN', N'ModelName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'模型名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyModel'
, @level2type = 'COLUMN', @level2name = N'ModelName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'模型名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyModel'
, @level2type = 'COLUMN', @level2name = N'ModelName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyModel', 
'COLUMN', N'ModelDesc')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'模型描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyModel'
, @level2type = 'COLUMN', @level2name = N'ModelDesc'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'模型描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyModel'
, @level2type = 'COLUMN', @level2name = N'ModelDesc'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyModel', 
'COLUMN', N'TableName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'所对应的数据表名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyModel'
, @level2type = 'COLUMN', @level2name = N'TableName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'所对应的数据表名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyModel'
, @level2type = 'COLUMN', @level2name = N'TableName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyModel', 
'COLUMN', N'UploadPath')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'上传到upload目录下的文件夹名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyModel'
, @level2type = 'COLUMN', @level2name = N'UploadPath'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'上传到upload目录下的文件夹名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyModel'
, @level2type = 'COLUMN', @level2name = N'UploadPath'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyModel', 
'COLUMN', N'UploadSize')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'所允许上传的文件大小 单位 KB 0为不限制'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyModel'
, @level2type = 'COLUMN', @level2name = N'UploadSize'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'所允许上传的文件大小 单位 KB 0为不限制'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyModel'
, @level2type = 'COLUMN', @level2name = N'UploadSize'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyModel', 
'COLUMN', N'IsSystem')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否是系统模型'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyModel'
, @level2type = 'COLUMN', @level2name = N'IsSystem'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否是系统模型'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyModel'
, @level2type = 'COLUMN', @level2name = N'IsSystem'
GO

-- ----------------------------
-- Records of KyModel
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyModel] ON
GO
INSERT INTO [dbo].[KyModel] ([ModelId], [ModelName], [ModelDesc], [TableName], [UploadPath], [UploadSize], [IsSystem], [AddTime], [ModelHtml], [IsHtml]) VALUES (N'1', N'文章模型', N'文章模型', N'KyArticle', N'news', N'0', N'1', N'2007-11-19 00:00:00.000', null, N'0')
GO
GO
INSERT INTO [dbo].[KyModel] ([ModelId], [ModelName], [ModelDesc], [TableName], [UploadPath], [UploadSize], [IsSystem], [AddTime], [ModelHtml], [IsHtml]) VALUES (N'2', N'图片模型', N'图片模型', N'KyImage', N'image', N'0', N'1', N'2007-11-19 00:00:00.000', null, N'0')
GO
GO
INSERT INTO [dbo].[KyModel] ([ModelId], [ModelName], [ModelDesc], [TableName], [UploadPath], [UploadSize], [IsSystem], [AddTime], [ModelHtml], [IsHtml]) VALUES (N'3', N'下载模型', N'下载模型', N'KyDownLoadData', N'down', N'0', N'1', N'2007-11-19 00:00:00.000', null, N'0')
GO
GO
SET IDENTITY_INSERT [dbo].[KyModel] OFF
GO

-- ----------------------------
-- Table structure for KyModelField
-- ----------------------------
DROP TABLE [dbo].[KyModelField]
GO
CREATE TABLE [dbo].[KyModelField] (
[FieldId] int NOT NULL IDENTITY(1,1) ,
[ModelId] int NULL ,
[Name] nvarchar(50) NULL ,
[Alias] nvarchar(150) NULL ,
[Description] nvarchar(200) NULL ,
[IsNotNull] bit NULL ,
[IsSearchForm] bit NULL ,
[Type] nvarchar(50) NULL ,
[Content] ntext NULL ,
[OrderId] int NULL DEFAULT (0) ,
[AddDate] datetime NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyModelField]', RESEED, 349)
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyModelField', 
'COLUMN', N'ModelId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'模型表Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyModelField'
, @level2type = 'COLUMN', @level2name = N'ModelId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'模型表Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyModelField'
, @level2type = 'COLUMN', @level2name = N'ModelId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyModelField', 
'COLUMN', N'Name')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'字段名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyModelField'
, @level2type = 'COLUMN', @level2name = N'Name'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'字段名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyModelField'
, @level2type = 'COLUMN', @level2name = N'Name'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyModelField', 
'COLUMN', N'Alias')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'字段别名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyModelField'
, @level2type = 'COLUMN', @level2name = N'Alias'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'字段别名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyModelField'
, @level2type = 'COLUMN', @level2name = N'Alias'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyModelField', 
'COLUMN', N'Description')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'字段描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyModelField'
, @level2type = 'COLUMN', @level2name = N'Description'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'字段描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyModelField'
, @level2type = 'COLUMN', @level2name = N'Description'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyModelField', 
'COLUMN', N'IsNotNull')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否必填'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyModelField'
, @level2type = 'COLUMN', @level2name = N'IsNotNull'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否必填'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyModelField'
, @level2type = 'COLUMN', @level2name = N'IsNotNull'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyModelField', 
'COLUMN', N'IsSearchForm')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否在搜索表单显示'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyModelField'
, @level2type = 'COLUMN', @level2name = N'IsSearchForm'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否在搜索表单显示'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyModelField'
, @level2type = 'COLUMN', @level2name = N'IsSearchForm'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyModelField', 
'COLUMN', N'Type')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'字段类型'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyModelField'
, @level2type = 'COLUMN', @level2name = N'Type'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'字段类型'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyModelField'
, @level2type = 'COLUMN', @level2name = N'Type'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyModelField', 
'COLUMN', N'Content')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'字段内容'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyModelField'
, @level2type = 'COLUMN', @level2name = N'Content'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'字段内容'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyModelField'
, @level2type = 'COLUMN', @level2name = N'Content'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyModelField', 
'COLUMN', N'OrderId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'排序'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyModelField'
, @level2type = 'COLUMN', @level2name = N'OrderId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'排序'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyModelField'
, @level2type = 'COLUMN', @level2name = N'OrderId'
GO

-- ----------------------------
-- Records of KyModelField
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyModelField] ON
GO
SET IDENTITY_INSERT [dbo].[KyModelField] OFF
GO

-- ----------------------------
-- Table structure for KyNotice
-- ----------------------------
DROP TABLE [dbo].[KyNotice]
GO
CREATE TABLE [dbo].[KyNotice] (
[NoticeId] int NOT NULL IDENTITY(1,1) ,
[Title] nvarchar(150) NULL ,
[Content] ntext NULL ,
[UserId] int NULL ,
[UserName] nvarchar(50) NULL ,
[OverdueDate] datetime NULL ,
[IsPriority] int NULL ,
[IsState] nvarchar(10) NULL ,
[AddDate] datetime NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyNotice]', RESEED, 8)
GO

-- ----------------------------
-- Records of KyNotice
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyNotice] ON
GO
INSERT INTO [dbo].[KyNotice] ([NoticeId], [Title], [Content], [UserId], [UserName], [OverdueDate], [IsPriority], [IsState], [AddDate]) VALUES (N'7', N'公告``', N'公告``', N'1', N'admin', N'2007-12-09 00:00:00.000', N'0', N'审核通过', N'2007-11-09 18:03:02.797')
GO
GO
INSERT INTO [dbo].[KyNotice] ([NoticeId], [Title], [Content], [UserId], [UserName], [OverdueDate], [IsPriority], [IsState], [AddDate]) VALUES (N'8', N'aaaaa', N'aaaaaa', N'1', N'admin', N'2008-01-14 00:00:00.000', N'0', N'审核通过', N'2007-12-14 18:13:49.770')
GO
GO
SET IDENTITY_INSERT [dbo].[KyNotice] OFF
GO

-- ----------------------------
-- Table structure for KyPowerColumn
-- ----------------------------
DROP TABLE [dbo].[KyPowerColumn]
GO
CREATE TABLE [dbo].[KyPowerColumn] (
[PCId] int NOT NULL IDENTITY(1,1) ,
[PowerColumnName] nvarchar(50) NULL ,
[ColumnErrorCodes] nvarchar(500) NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyPowerColumn]', RESEED, 49)
GO

-- ----------------------------
-- Records of KyPowerColumn
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyPowerColumn] ON
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'1', N'内容管理', null)
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'2', N'用户管理', N'<li>对不起，你没有用户管理的权限</li>')
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'3', N'专题管理', N'<li>对不起，你没有专题管理的权限</li>')
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'4', N'评论管理', N'<li>对不起，你没有评论管理的权限!</li>')
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'5', N'充值卡管理', N'<li>对不起，你没有卡操作的权限</li>')
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'6', N'标签管理', N'<li>对不起，你没有管理标签的权限</li>')
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'7', N'生成管理', N'<li>对不起，你没有生成操作的权限</li>')
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'8', N'模板管理', N'<li>对不起，你没有超级标签管理的权限</li>')
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'9', N'超级标签', N'<li>对不起，你没有模板管理的权限</li>')
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'10', N'样式管理', N'<li>对不起，你没有管理样式的权限</li>')
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'11', N'投票管理', N'<li>对不起，你没有投票管理的权限</li>')
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'12', N'数据字典', N'<li>对不起，你没有管理数据字典的权限<li>')
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'13', N'会员组管理', N'<li>对不起，你没有用户组管理的权限</li>')
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'14', N'管理员管理', N'<li>对不起，你没有管理员管理的权限</li>')
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'15', N'管理员组管理', N'<li>对不起，你没有管理员组管理权限</li>')
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'16', N'添加会员', N'<li>对不起，你没有添加会员的权限</li>')
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'17', N'查看会员信息', N'<li>对不起，你没有查看会员信息的权限</li>')
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'18', N'修改会员信息', N'<li>对不起，你没有修改会员信息的权限</li>')
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'19', N'友情链接管理', N'<li>对不起，你没有友情链接管理的权限</li>')
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'20', N'锁定/解锁会员', null)
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'21', N'删除会员', null)
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'22', N'会员资金管理', null)
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'23', N'会员点券管理', null)
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'24', N'会员有效期管理', null)
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'25', N'会员有效期明细管理', null)
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'26', N'会员消费明细管理', null)
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'27', N'新闻归档操作', N'<li>对不起，你没有归档操作的权限</li>')
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'28', N'TAG 管理', N'<li>对不起，你没有管理关键字的权限</li>')
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'29', N'网站统计', N'<li>对不起，您没有查看站点统计的权限</li>')
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'30', N'广告管理', N'<li>对不起，你没有广告管理的权限</li>')
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'31', N'全站参数设置', N'<li>对不起，你没有设置全站参数的权限</li>')
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'32', N'举报管理', N'<li>对不起，你没有举报管理的权限</li>')
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'33', N'表单管理', N'<li>对不起，你没有表单管理的权限</li>')
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'34', N'下载服务器管理', null)
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'35', N'模型管理', N'<li>对不起，你没有模型管理的权限</li>')
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'36', N'频道/栏目管理', N'<li>对不起，你没有频道/栏目管理的权限</li>')
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'37', N'回收站管理', N'<li>对不起，你没有回收站管理的权限</li>')
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'38', N'客户反馈', N'<li>对不起，你没有客户反馈管理的权限</li>')
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'39', N'站点统计', null)
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'40', N'内容批量删除', null)
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'41', N'内容批量替换', null)
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'42', N'内容批量移动', N'<li>对不起，你没有批量移动的权限</li>')
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'43', N'内容批量设置', N'<li>对不起，你没有批量设置的权限</li>')
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'44', N'模板批量捆绑', N'<li>对不起，你没有批量捆绑模板的权限</li>')
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'45', N'栏目批量移动', N'<li>对不起，你没有栏目移动的权限</li>')
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'46', N'公告管理', N'<li>对不起，你没有公告管理的权限</li>')
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'47', N'短消息管理', N'<li>对不起，你没有短消息管理的权限</li>')
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'48', N'采集管理', N'<li>对不起，你没有采集管理的权限</li>')
GO
GO
INSERT INTO [dbo].[KyPowerColumn] ([PCId], [PowerColumnName], [ColumnErrorCodes]) VALUES (N'49', N'用户组模型', N'<li>对不起，你没有用户组模型管理的权限</li>')
GO
GO
SET IDENTITY_INSERT [dbo].[KyPowerColumn] OFF
GO

-- ----------------------------
-- Table structure for KyPowerGroup
-- ----------------------------
DROP TABLE [dbo].[KyPowerGroup]
GO
CREATE TABLE [dbo].[KyPowerGroup] (
[PowerId] int NOT NULL IDENTITY(1,1) ,
[PowerName] nvarchar(50) NULL ,
[PowerColumn] ntext NULL ,
[PowerChannel] ntext NULL ,
[PowerAuditing] ntext NULL ,
[PowerModel] nvarchar(50) NULL ,
[PowerContent] nvarchar(500) NULL ,
[IsSystem] int NULL DEFAULT (0) ,
[AddDate] datetime NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyPowerGroup]', RESEED, 12)
GO

-- ----------------------------
-- Records of KyPowerGroup
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyPowerGroup] ON
GO
INSERT INTO [dbo].[KyPowerGroup] ([PowerId], [PowerName], [PowerColumn], [PowerChannel], [PowerAuditing], [PowerModel], [PowerContent], [IsSystem], [AddDate]) VALUES (N'1', N'超级管理员组', N'1=1,2=1,3=1,4=1,5=1,6=1,7=1,8=1,9=1,10=1,11=1,12=1,13=1,14=1,15=1,16=1,17=1,18=1,19=1,20=1,21=1,22=1,23=1,24=1,25=1,26=1,27=1,28=1,29=1,30=1,31=1,32=1,33=1,34=1,35=1,36=1,37=1,38=1,39=1,40=1,41=1,42=1,43=1,44=1,45=1,46=1,47=1', N'1@0=1|1|1|1|,1@2=1|1|1|1|,1@18=1|1|1|1|,1@19=1|1|1|1|,1@20=1|1|1|1|,1@21=1|1|1|1|,1@3=1|1|1|1|,1@5=1|1|1|1|,1@6=1|1|1|1|,2@0=1|1|1|1|,2@1=1|1|1|1|,2@11=1|1|1|1|,2@12=1|1|1|1|,2@22=1|1|1|1|,2@23=1|1|1|1|,2@24=1|1|1|1|,2@25=1|1|1|1|,2@13=1|1|1|1|,3@0=1|1|1|1|,3@4=1|1|1|1|,3@16=1|1|1|1|,3@17=1|1|1|1|,3@26=1|1|1|1|,3@27=1|1|1|1|', N'1=3,2=3,3=3,', N'否', N'超级管理员组,不能够删除', N'1', N'2007-09-19 17:05:56.000')
GO
GO
SET IDENTITY_INSERT [dbo].[KyPowerGroup] OFF
GO

-- ----------------------------
-- Table structure for KyRechargeRecord
-- ----------------------------
DROP TABLE [dbo].[KyRechargeRecord]
GO
CREATE TABLE [dbo].[KyRechargeRecord] (
[ID] int NOT NULL IDENTITY(1,1) ,
[UserId] int NOT NULL ,
[CardAccount] varchar(15) NOT NULL ,
[CardPoint] int NULL ,
[CardDay] int NULL ,
[RechargeDate] datetime NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyRechargeRecord]', RESEED, 9)
GO

-- ----------------------------
-- Records of KyRechargeRecord
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyRechargeRecord] ON
GO
INSERT INTO [dbo].[KyRechargeRecord] ([ID], [UserId], [CardAccount], [CardPoint], [CardDay], [RechargeDate]) VALUES (N'1', N'13', N'KYCMS10110', N'1000', N'0', N'2007-11-08 15:48:30.607')
GO
GO
INSERT INTO [dbo].[KyRechargeRecord] ([ID], [UserId], [CardAccount], [CardPoint], [CardDay], [RechargeDate]) VALUES (N'2', N'17', N'KYCMS10109', N'1000', N'0', N'2007-11-08 17:38:32.123')
GO
GO
INSERT INTO [dbo].[KyRechargeRecord] ([ID], [UserId], [CardAccount], [CardPoint], [CardDay], [RechargeDate]) VALUES (N'3', N'14', N'KYCMS10108', N'1000', N'0', N'2007-11-10 15:47:05.310')
GO
GO
INSERT INTO [dbo].[KyRechargeRecord] ([ID], [UserId], [CardAccount], [CardPoint], [CardDay], [RechargeDate]) VALUES (N'4', N'11', N'KYCMS10107', N'1000', N'0', N'2007-11-11 17:46:16.700')
GO
GO
INSERT INTO [dbo].[KyRechargeRecord] ([ID], [UserId], [CardAccount], [CardPoint], [CardDay], [RechargeDate]) VALUES (N'5', N'44', N'KYCMS10131', N'30', N'0', N'2007-11-14 16:53:13.390')
GO
GO
INSERT INTO [dbo].[KyRechargeRecord] ([ID], [UserId], [CardAccount], [CardPoint], [CardDay], [RechargeDate]) VALUES (N'6', N'77', N'KYCMSK1E12290', N'30', N'0', N'2007-12-12 15:13:37.787')
GO
GO
INSERT INTO [dbo].[KyRechargeRecord] ([ID], [UserId], [CardAccount], [CardPoint], [CardDay], [RechargeDate]) VALUES (N'7', N'1', N'KYCMSV3J12289', N'30', N'0', N'2007-12-14 17:18:47.700')
GO
GO
INSERT INTO [dbo].[KyRechargeRecord] ([ID], [UserId], [CardAccount], [CardPoint], [CardDay], [RechargeDate]) VALUES (N'8', N'1', N'KYCMS4SH12292', N'10', N'0', N'2007-12-19 11:23:01.200')
GO
GO
INSERT INTO [dbo].[KyRechargeRecord] ([ID], [UserId], [CardAccount], [CardPoint], [CardDay], [RechargeDate]) VALUES (N'9', N'1', N'KYCMS5HA12291 ', N'10', N'0', N'2007-12-19 12:09:04.257')
GO
GO
SET IDENTITY_INSERT [dbo].[KyRechargeRecord] OFF
GO

-- ----------------------------
-- Table structure for KyReport
-- ----------------------------
DROP TABLE [dbo].[KyReport]
GO
CREATE TABLE [dbo].[KyReport] (
[ReportId] int NOT NULL IDENTITY(1,1) ,
[Content] nvarchar(1000) NOT NULL ,
[Url] varchar(255) NOT NULL ,
[UserId] int NOT NULL ,
[UserName] nvarchar(20) NOT NULL ,
[IsComplete] int NOT NULL DEFAULT (0) ,
[AddTime] datetime NULL DEFAULT (getdate()) 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyReport]', RESEED, 3)
GO

-- ----------------------------
-- Records of KyReport
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyReport] ON
GO
SET IDENTITY_INSERT [dbo].[KyReport] OFF
GO

-- ----------------------------
-- Table structure for KyReview
-- ----------------------------
DROP TABLE [dbo].[KyReview]
GO
CREATE TABLE [dbo].[KyReview] (
[Id] int NOT NULL IDENTITY(1,1) ,
[ModelType] int NOT NULL ,
[InfoId] int NOT NULL ,
[ReviewTitle] nvarchar(100) NULL ,
[IsArgue] bit NULL ,
[IsSquare] tinyint NULL ,
[BrarNum] int NULL ,
[FightNum] int NULL ,
[IsElite] bit NULL ,
[ReviewContent] ntext NULL ,
[ReviewTime] datetime NULL ,
[UserNum] nvarchar(18) NULL ,
[ReviewIP] nvarchar(20) NULL ,
[IsCheck] bit NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyReview]', RESEED, 145)
GO

-- ----------------------------
-- Records of KyReview
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyReview] ON
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'14', N'1', N'21', N'', N'0', N'3', N'0', N'0', N'0', N'', N'2007-11-08 15:21:54.173', N'12', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'15', N'1', N'21', N'', N'0', N'3', N'0', N'0', N'0', N'', N'2007-11-08 15:23:46.720', N'12', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'17', N'1', N'21', N'', N'0', N'3', N'0', N'0', N'0', N'', N'2007-11-08 15:24:06.517', N'11', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'18', N'1', N'21', N'', N'0', N'3', N'0', N'0', N'0', N'fdasfasd', N'2007-11-08 15:24:09.767', N'11', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'21', N'1', N'21', N'', N'0', N'3', N'0', N'0', N'0', N'', N'2007-11-08 15:24:41.640', N'11', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'22', N'1', N'21', N'', N'0', N'3', N'0', N'0', N'0', N'', N'2007-11-08 15:24:44.577', N'11', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'23', N'1', N'21', N'', N'0', N'3', N'0', N'0', N'0', N'', N'2007-11-08 15:25:49.720', N'12', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'24', N'1', N'21', N'', N'0', N'3', N'0', N'0', N'0', N'', N'2007-11-08 15:27:38.500', N'12', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'25', N'1', N'21', N'', N'0', N'3', N'0', N'0', N'0', N'fasf', N'2007-11-08 15:27:42.313', N'12', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'26', N'1', N'21', N'', N'0', N'3', N'0', N'0', N'0', N'dsafsdaf', N'2007-11-08 15:28:49.500', N'12', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'27', N'1', N'21', N'', N'0', N'3', N'0', N'0', N'0', N'', N'2007-11-08 15:31:18.157', N'12', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'28', N'1', N'21', N'', N'0', N'3', N'0', N'0', N'0', N'', N'2007-11-08 15:31:56.720', N'12', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'31', N'1', N'21', N'', N'0', N'3', N'0', N'0', N'0', N'', N'2007-11-08 15:40:25.930', N'12', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'36', N'1', N'21', N'', N'0', N'3', N'0', N'0', N'0', N'fsafasf', N'2007-11-08 15:47:12.673', N'12', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'40', N'1', N'21', N'', N'0', N'3', N'0', N'0', N'0', N'mmm', N'2007-11-08 15:52:01.170', N'12', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'44', N'1', N'21', N'', N'0', N'3', N'0', N'0', N'0', N'hhhh', N'2007-11-08 15:53:39.890', N'12', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'49', N'1', N'21', N'', N'0', N'3', N'0', N'0', N'0', N'fasf', N'2007-11-08 16:01:33.157', N'12', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'50', N'1', N'21', N'', N'0', N'3', N'0', N'0', N'0', N'fasf', N'2007-11-08 16:04:37.733', N'0', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'51', N'1', N'21', N'', N'0', N'3', N'0', N'0', N'0', N'ssss', N'2007-11-08 16:26:16.313', N'12', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'62', N'1', N'45', N'', N'0', N'3', N'0', N'0', N'0', N'fasfs', N'2007-11-09 09:50:02.127', N'12', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'87', N'4', N'1', N'', N'0', N'3', N'0', N'0', N'0', N'测试附带评论', N'2007-11-09 20:31:07.453', N'0', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'88', N'4', N'1', N'', N'0', N'3', N'0', N'0', N'0', N'二册地方', N'2007-11-09 20:31:31.687', N'0', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'89', N'4', N'1', N'', N'0', N'3', N'0', N'0', N'0', N'的萨芬的萨芬但是', N'2007-11-09 20:31:34.530', N'0', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'90', N'4', N'1', N'', N'0', N'3', N'0', N'0', N'0', N'范德萨发大水当时的', N'2007-11-09 20:31:37.923', N'0', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'91', N'1', N'74', N'', N'0', N'3', N'0', N'0', N'0', N'resgegre', N'2007-11-10 11:38:39.827', N'0', N'192.168.0.4', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'93', N'1', N'46', N'', N'0', N'3', N'0', N'0', N'0', N'fdsafdsfsdfsdafs', N'2007-11-10 20:57:41.140', N'14', N'192.168.0.4', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'94', N'5', N'16', N'', N'0', N'3', N'0', N'0', N'0', N'dshfsdh', N'2007-11-12 17:42:06.203', N'12', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'95', N'5', N'16', N'', N'0', N'3', N'0', N'0', N'0', N'gggggggggggg', N'2007-11-12 17:42:10.890', N'12', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'100', N'1', N'21', N'', N'0', N'3', N'0', N'0', N'0', N'GVDSHBFHFHDGBGFSFWF', N'2007-11-18 11:57:19.827', N'0', N'192.168.0.147', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'101', N'1', N'21', N'', N'0', N'3', N'0', N'0', N'0', N'DGFHFGJBVCSCFGDGVF1231654654687964321324798', N'2007-11-18 11:57:27.610', N'0', N'192.168.0.147', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'102', N'1', N'21', N'', N'0', N'3', N'0', N'0', N'0', N'15646132168412348643416464654', N'2007-11-18 11:57:37.530', N'0', N'192.168.0.147', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'108', N'1', N'27', N'', N'0', N'3', N'0', N'0', N'0', N'6543513514', N'2007-11-18 13:00:34.377', N'0', N'192.168.0.147', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'109', N'1', N'27', N'', N'0', N'3', N'0', N'0', N'0', N'674453213+94', N'2007-11-18 13:00:38.483', N'0', N'192.168.0.147', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'110', N'1', N'27', N'', N'0', N'3', N'0', N'0', N'0', N'56149876513215', N'2007-11-18 13:00:41.733', N'0', N'192.168.0.147', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'111', N'1', N'27', N'', N'0', N'3', N'0', N'0', N'0', N'584415413132410124', N'2007-11-18 13:00:46.907', N'0', N'192.168.0.147', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'112', N'1', N'27', N'', N'0', N'3', N'0', N'0', N'0', N'+89945315410230..00

', N'2007-11-18 13:00:51.703', N'0', N'192.168.0.147', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'113', N'1', N'27', N'', N'0', N'3', N'0', N'0', N'0', N'4221645174135145', N'2007-11-18 13:00:56.407', N'0', N'192.168.0.147', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'114', N'1', N'27', N'', N'0', N'3', N'0', N'0', N'0', N'465132164613216', N'2007-11-18 13:01:00.110', N'0', N'192.168.0.147', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'115', N'1', N'27', N'', N'0', N'3', N'0', N'0', N'0', N'1561121031031034684110
3210321541651320132156416513213', N'2007-11-18 13:01:16.577', N'0', N'192.168.0.147', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'116', N'1', N'27', N'', N'0', N'3', N'0', N'0', N'0', N'451231321321132102120', N'2007-11-18 13:01:20.877', N'0', N'192.168.0.147', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'117', N'1', N'27', N'', N'0', N'3', N'0', N'0', N'0', N'84654654987498465456122288', N'2007-11-18 13:01:25.547', N'0', N'192.168.0.147', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'118', N'1', N'27', N'', N'0', N'3', N'0', N'0', N'0', N'451320165410.', N'2007-11-18 13:03:28.173', N'0', N'192.168.0.147', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'119', N'1', N'29', N'', N'0', N'3', N'0', N'0', N'0', N'jvnjfhnfhfh', N'2007-11-18 13:46:53.313', N'0', N'192.168.0.147', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'120', N'1', N'29', N'', N'0', N'3', N'0', N'0', N'0', N'sdgdzxcvxcvsfvfddfsdfc', N'2007-11-18 13:46:57.407', N'0', N'192.168.0.147', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'121', N'1', N'29', N'', N'0', N'3', N'0', N'0', N'0', N'xzgvdsgfbvxvcscfasx', N'2007-11-18 13:47:01.657', N'0', N'192.168.0.147', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'122', N'1', N'29', N'', N'0', N'3', N'0', N'0', N'0', N'zvxbcfvcxvxcv', N'2007-11-18 13:47:05.530', N'0', N'192.168.0.147', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'123', N'1', N'29', N'', N'0', N'3', N'0', N'0', N'0', N'bvcvnvn nzxczdxvc', N'2007-11-18 13:47:09.827', N'0', N'192.168.0.147', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'124', N'1', N'29', N'', N'0', N'3', N'0', N'0', N'0', N'dgdfhbcc xvc zcdgb v', N'2007-11-18 13:47:25.593', N'0', N'192.168.0.147', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'125', N'1', N'29', N'', N'0', N'3', N'0', N'0', N'0', N'fei456fei456fei456fei456fei456fei456
测试评论', N'2007-11-18 13:47:59.953', N'0', N'192.168.0.147', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'126', N'1', N'29', N'', N'0', N'3', N'0', N'0', N'0', N'fei456fei456fei456fei456fei456fei456
测试评论', N'2007-11-18 13:49:04.733', N'0', N'192.168.0.147', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'127', N'1', N'29', N'', N'0', N'3', N'0', N'0', N'0', N'fei456fei456fei456fei456fei456fei456
测试评论fei456fei456fei456fei456fei456fei456
测试评论fei456fei456fei456fei456fei456fei456
测试评论fei456fei456fei456fei456fei456fei456
测试评论fei456fei456fei456fei456fei456fei456
测试评论fei456fei456fei456fei456fei456fei456
测试评论', N'2007-11-18 13:49:55.267', N'49', N'192.168.0.147', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'131', N'2', N'20', N'', N'0', N'3', N'0', N'0', N'0', N'13216545', N'2007-11-18 20:37:29.267', N'49', N'192.168.0.147', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'134', N'1', N'43', N'', N'0', N'3', N'0', N'0', N'0', N'fdsf', N'2007-12-03 14:01:06.630', N'0', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'135', N'1', N'43', N'', N'0', N'3', N'0', N'0', N'0', N'fsdfd', N'2007-12-03 14:01:09.170', N'0', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'136', N'1', N'340', N'', N'0', N'3', N'0', N'0', N'0', N'dsafasdf', N'2007-12-25 15:35:55.390', N'0', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'137', N'1', N'340', N'', N'0', N'3', N'0', N'0', N'0', N'asdfsadfsadf', N'2007-12-25 15:35:59.267', N'0', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'138', N'1', N'1604', N'', N'0', N'3', N'0', N'0', N'0', N'fasdfasf', N'2007-12-25 15:38:21.563', N'0', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'139', N'1', N'1278', N'', N'0', N'3', N'0', N'0', N'0', N'得到', N'2007-12-25 15:39:53.233', N'0', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'140', N'1', N'1278', N'', N'0', N'3', N'0', N'0', N'0', N'fsdf', N'2007-12-25 15:42:47.220', N'0', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'141', N'1', N'1604', N'', N'0', N'3', N'0', N'0', N'0', N'fsafsad', N'2007-12-25 16:05:49.767', N'0', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'142', N'1', N'1604', N'', N'0', N'3', N'0', N'0', N'0', N'fsafdasdfsadfsadfsadfsadf', N'2007-12-25 16:05:56.453', N'0', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'143', N'1', N'1604', N'', N'0', N'3', N'0', N'0', N'0', N'fsafasfsadf', N'2007-12-25 16:06:38.170', N'0', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'144', N'1', N'1604', N'', N'0', N'3', N'0', N'0', N'0', N'fsadfsadfsadf', N'2007-12-25 16:07:48.437', N'0', N'127.0.0.1', N'1')
GO
GO
INSERT INTO [dbo].[KyReview] ([Id], [ModelType], [InfoId], [ReviewTitle], [IsArgue], [IsSquare], [BrarNum], [FightNum], [IsElite], [ReviewContent], [ReviewTime], [UserNum], [ReviewIP], [IsCheck]) VALUES (N'145', N'1', N'1604', N'', N'0', N'3', N'0', N'0', N'0', N'asfasdf', N'2007-12-25 16:08:06.687', N'0', N'127.0.0.1', N'1')
GO
GO
SET IDENTITY_INSERT [dbo].[KyReview] OFF
GO

-- ----------------------------
-- Table structure for KySinglePage
-- ----------------------------
DROP TABLE [dbo].[KySinglePage]
GO
CREATE TABLE [dbo].[KySinglePage] (
[SingleId] int NOT NULL IDENTITY(1,1) ,
[Name] nvarchar(100) NULL ,
[FolderPath] nvarchar(50) NULL ,
[FileName] nvarchar(100) NULL ,
[FileExtend] nvarchar(50) NULL ,
[TemplatePath] nvarchar(150) NULL ,
[Content] nvarchar(200) NULL ,
[AddTime] datetime NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[KySinglePage]', RESEED, 7)
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KySinglePage', 
'COLUMN', N'FolderPath')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'文件夹路径'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySinglePage'
, @level2type = 'COLUMN', @level2name = N'FolderPath'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'文件夹路径'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySinglePage'
, @level2type = 'COLUMN', @level2name = N'FolderPath'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KySinglePage', 
'COLUMN', N'FileName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'文件名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySinglePage'
, @level2type = 'COLUMN', @level2name = N'FileName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'文件名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySinglePage'
, @level2type = 'COLUMN', @level2name = N'FileName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KySinglePage', 
'COLUMN', N'FileExtend')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'文件扩展名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySinglePage'
, @level2type = 'COLUMN', @level2name = N'FileExtend'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'文件扩展名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySinglePage'
, @level2type = 'COLUMN', @level2name = N'FileExtend'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KySinglePage', 
'COLUMN', N'TemplatePath')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'模板路径'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySinglePage'
, @level2type = 'COLUMN', @level2name = N'TemplatePath'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'模板路径'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySinglePage'
, @level2type = 'COLUMN', @level2name = N'TemplatePath'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KySinglePage', 
'COLUMN', N'Content')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySinglePage'
, @level2type = 'COLUMN', @level2name = N'Content'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySinglePage'
, @level2type = 'COLUMN', @level2name = N'Content'
GO

-- ----------------------------
-- Records of KySinglePage
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KySinglePage] ON
GO
SET IDENTITY_INSERT [dbo].[KySinglePage] OFF
GO

-- ----------------------------
-- Table structure for KySpecial
-- ----------------------------
DROP TABLE [dbo].[KySpecial]
GO
CREATE TABLE [dbo].[KySpecial] (
[ID] int NOT NULL IDENTITY(1,1) ,
[ParentID] int NULL ,
[SiteID] int NULL ,
[SpecialCName] nvarchar(30) NULL ,
[SpecialEName] nvarchar(20) NULL ,
[SpecialDomain] nvarchar(100) NULL ,
[SpecialRemark] nvarchar(200) NULL ,
[IsLock] bit NULL ,
[IsCommand] bit NULL ,
[SpecialAddTime] datetime NULL ,
[MetaKeyWord] nvarchar(200) NULL ,
[MetaRemark] nvarchar(200) NULL ,
[SpecialTemplet] nvarchar(200) NULL ,
[SpecialItemNum] int NULL ,
[SpecialContent] ntext NULL ,
[SaveDirType] nvarchar(200) NULL ,
[IsDeleted] int NULL ,
[Extension] varchar(50) NULL ,
[PicSavePath] nvarchar(200) NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[KySpecial]', RESEED, 8)
GO

-- ----------------------------
-- Records of KySpecial
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KySpecial] ON
GO
SET IDENTITY_INSERT [dbo].[KySpecial] OFF
GO

-- ----------------------------
-- Table structure for KyStyle
-- ----------------------------
DROP TABLE [dbo].[KyStyle]
GO
CREATE TABLE [dbo].[KyStyle] (
[StyleID] int NOT NULL IDENTITY(1,1) ,
[StyleCategoryId] int NULL ,
[Name] nvarchar(50) NOT NULL ,
[Content] text NULL ,
[Type] int NOT NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyStyle]', RESEED, 11)
GO

-- ----------------------------
-- Records of KyStyle
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyStyle] ON
GO
INSERT INTO [dbo].[KyStyle] ([StyleID], [StyleCategoryId], [Name], [Content], [Type]) VALUES (N'1', N'1', N'·标题', N'<tr><td class="list3">·<a href="{KY_InfoUrl}" target="_blank">{KY_Title}</a> </td></tr>', N'0')
GO
GO
INSERT INTO [dbo].[KyStyle] ([StyleID], [StyleCategoryId], [Name], [Content], [Type]) VALUES (N'2', N'1', N'标题+时间', N'<tr><td class="list1">·<a href="{KY_InfoUrl}" target="_blank">{KY_Title}</a></td><td align=right>{KY_AddTime}&nbsp;</td></tr>', N'0')
GO
GO
INSERT INTO [dbo].[KyStyle] ([StyleID], [StyleCategoryId], [Name], [Content], [Type]) VALUES (N'3', N'1', N'标题+点击', N'<tr><td class="list2">·<a href="{KY_InfoUrl}" target="_blank">{KY_Title}</a></td><td align="right" class="list2" style="color:red;">{KY_HitCount}&nbsp;</td></tr>', N'0')
GO
GO
INSERT INTO [dbo].[KyStyle] ([StyleID], [StyleCategoryId], [Name], [Content], [Type]) VALUES (N'4', N'1', N'缩略图+标题', N'<td align="center"><a href="{KY_InfoUrl}" target="_blank"><img class="bor3"  src="{KY_TitleImgPath}" border="0" height="90" width="130"></a><br /><a href="{KY_ColumnUrl}" target="_blank">{KY_Title}</a></td>', N'0')
GO
GO
INSERT INTO [dbo].[KyStyle] ([StyleID], [StyleCategoryId], [Name], [Content], [Type]) VALUES (N'5', N'1', N'首页大图', N'<table width="154" border="0" cellspacing="0" cellpadding="0" >
            <tr>
              <td height="114" align="left" valign="top" class="hbg"><a href="{KY_ColumnUrl}" target="_blank"><img  src="{KY_TitleImgPath}" border="0" height="110" width="150"></a></td>
            </tr>
			 <tr>
              <td height="20" align="center"><a href="{KY_ColumnUrl}" target="_blank">{KY_Title}</a></td>
            </tr>
          </table>', N'0')
GO
GO
INSERT INTO [dbo].[KyStyle] ([StyleID], [StyleCategoryId], [Name], [Content], [Type]) VALUES (N'6', N'1', N'栏目循环', N'<tr>
<td colspan="2">
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="bg3">
<tr>
<td width="42"><img src="../Template/images/icon4.gif"  border="0" /></td>
<td class="atop"><a href="{KY_ColumnUrl}"><strong>{KY_ColName}</strong></a></td>
<td width="50" class="atop"><a href="{KY_ColumnUrl}"><img src="../Template/images/more.gif" border="0" /></a></td>
</tr>
</table>
</td>
</tr>', N'0')
GO
GO
INSERT INTO [dbo].[KyStyle] ([StyleID], [StyleCategoryId], [Name], [Content], [Type]) VALUES (N'7', N'1', N'文章内容', N'<tr>
    <td align="center" class="list2" style="padding-right:10px;">作者：{KY_Author}&nbsp;&nbsp;来源：{KY_Source} &nbsp;&nbsp;录入：{KY_UName} 责编：{KY_AdminUName}&nbsp;&nbsp;添加日期：{KY_AddTime}&nbsp;&nbsp;{KY_StarLevel}</td>
  </tr>
  <tr>
    <td class="nr_1">{KY_Content}</td>
  </tr>
  <tr>
    <td height="5">上一篇：<a href="{KY_PreUrl}">{KY_Pre}</a><br>下一篇:<a href="{KY_NextUrl}">{KY_Next}</a> </td>
  </tr>', N'0')
GO
GO
INSERT INTO [dbo].[KyStyle] ([StyleID], [StyleCategoryId], [Name], [Content], [Type]) VALUES (N'8', N'1', N'下载内容页', N'<table width="100%" border="0" cellpadding="4" cellspacing="1" bgcolor="#999999" style="margin-bottom:5px;">
  
  <tr>
    <td width="25%" rowspan="4" align="center" bgcolor="#FFFFFF"><img src="" width="130" height="90" /></td>
    <td width="25%" align="center" bgcolor="#e5e5e5"><strong>软件编号：</strong></td>
    <td width="25%" align="center" bgcolor="#e5e5e5"><strong>软件版本：</strong></td>
    <td align="center" bgcolor="#e5e5e5"><strong>添加日期：</strong></td>
  </tr>
  <tr>
    <td align="center" bgcolor="#FFFFFF">{KY_Id}</td>
    <td align="center" bgcolor="#FFFFFF">{KY_Edition}</td>
    <td align="center" bgcolor="#FFFFFF">{KY_AddTime}</td>
  </tr>
  <tr>
    <td align="center" bgcolor="#e5e5e5"><strong>文件大小：</strong></td>
    <td align="center" bgcolor="#e5e5e5"><strong>软件语言：</strong></td>
    <td align="center" bgcolor="#e5e5e5"><strong>下载等级：</strong></td>
  </tr>
  <tr>
    <td align="center" bgcolor="#FFFFFF">{KY_DownLoadSize}</td>
    <td align="center" bgcolor="#FFFFFF">{KY_Language}</td>
    <td align="center" bgcolor="#FFFFFF">{KY_DownLoadStarLevel}</td>
  </tr>
  <tr>
    <td align="center" bgcolor="#e5e5e5"><strong>运行环境：</strong></td>
    <td align="center" bgcolor="#e5e5e5"><strong>授权方式：</strong></td>
    <td align="center" bgcolor="#e5e5e5"><strong>下载类别：</strong></td>
    <td align="center" bgcolor="#e5e5e5"><strong>点击数量：</strong></td>
  </tr>
  <tr>
    <td align="center" bgcolor="#FFFFFF">{KY_DownLoadOS}</td>
    <td align="center" bgcolor="#FFFFFF">{KY_WarrantType}</td>
    <td align="center" bgcolor="#FFFFFF">{KY_DownLoadType}</td>
    <td align="center" bgcolor="#FFFFFF">{KY_HitCount}</td>
  </tr>
  <tr>
    <td align="center" bgcolor="#e5e5e5"><strong>今日下载：</strong></td>
    <td align="center" bgcolor="#e5e5e5"><strong>本周下载：</strong></td>
    <td align="center" bgcolor="#e5e5e5"><strong>本月下载：</strong></td>
    <td align="center" bgcolor="#e5e5e5"><strong>总点击：</strong></td>
  </tr>
  <tr>
    <td align="center" bgcolor="#FFFFFF">{KY_DownLoadDownDayNum}</td>
    <td align="center" bgcolor="#FFFFFF">{KY_DownLoadDownWeekNum}</td>
    <td align="center" bgcolor="#FFFFFF">{KY_DownLoadDownMonthNum}</td>
    <td align="center" bgcolor="#FFFFFF">{KY_HitCount}</td>
  </tr>
  <tr>
    <td colspan="4" bgcolor="#e5e5e5"><strong>{KY_AddressPath}</strong></td>
  </tr>
  <tr>
    <td colspan="4" bgcolor="#FFFFFF"><strong>软件简介</strong>：{KY_Content}</td>
  </tr>
</table>', N'0')
GO
GO
INSERT INTO [dbo].[KyStyle] ([StyleID], [StyleCategoryId], [Name], [Content], [Type]) VALUES (N'9', N'1', N'下载终极', N'<table width="100%" height="25" border="0" cellpadding="0" cellspacing="1" bgcolor="#FFFFFF">
                    <tr bgcolor="#F1F1F1"> 
                      <td width="600">&nbsp;<a href="{KY_InfoUrl}" title="{KY_Title}"><strong>{KY_Title}</strong></a>&nbsp;&nbsp;[<a href="{KY_ColumnUrl}"><font color="#000000">{KY_ColName}</font></a>]</td>
                      <td width="90" align="center">{KY_AddTime}</td>
                      <td width="65" align="center">{KY_DownLoadSize}</td>
                      <td width="80" align="center">{KY_HitCount}</td>
                    </tr>
                    <tr height="34"> 
                      <td colspan="4"><font color="#777777"> {KY_Content}...</font></td>
                    </tr>
                    <tr height="25"> 
                      <td width="550">&nbsp;<font color="#172D73">授权：{KY_WarrantType} 
                        | 插件情况：</font><font color="#022683">{KY_Plugin}</font>
						| <font color="#172D73">下载类别:[{KY_DownLoadType}]</td>
                      <td align="right" colspan="3"></td>
                    </tr>
                  </table>', N'0')
GO
GO
INSERT INTO [dbo].[KyStyle] ([StyleID], [StyleCategoryId], [Name], [Content], [Type]) VALUES (N'10', N'1', N'图片内容页', N'<img src="{KY_ImgPath}" border="0" title="点击进入下一张图片" /> 
<br />
{KY_Content}', N'0')
GO
GO
SET IDENTITY_INSERT [dbo].[KyStyle] OFF
GO

-- ----------------------------
-- Table structure for KyStyleCategory
-- ----------------------------
DROP TABLE [dbo].[KyStyleCategory]
GO
CREATE TABLE [dbo].[KyStyleCategory] (
[StyleCategoryID] int NOT NULL IDENTITY(1,1) ,
[Name] nvarchar(50) NULL ,
[ParentID] int NULL DEFAULT (0) ,
[Desc] nvarchar(100) NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyStyleCategory]', RESEED, 6)
GO

-- ----------------------------
-- Records of KyStyleCategory
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyStyleCategory] ON
GO
INSERT INTO [dbo].[KyStyleCategory] ([StyleCategoryID], [Name], [ParentID], [Desc]) VALUES (N'1', N'通用样式', N'0', N'')
GO
GO
SET IDENTITY_INSERT [dbo].[KyStyleCategory] OFF
GO

-- ----------------------------
-- Table structure for KySuperior
-- ----------------------------
DROP TABLE [dbo].[KySuperior]
GO
CREATE TABLE [dbo].[KySuperior] (
[id] int NOT NULL IDENTITY(1,1) ,
[Name] nvarchar(200) NULL ,
[StartCode] nvarchar(500) NULL ,
[EndCode] nvarchar(500) NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[KySuperior]', RESEED, 13)
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KySuperior', 
'COLUMN', N'id')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'自动编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySuperior'
, @level2type = 'COLUMN', @level2name = N'id'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'自动编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySuperior'
, @level2type = 'COLUMN', @level2name = N'id'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KySuperior', 
'COLUMN', N'Name')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'高级过滤名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySuperior'
, @level2type = 'COLUMN', @level2name = N'Name'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'高级过滤名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySuperior'
, @level2type = 'COLUMN', @level2name = N'Name'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KySuperior', 
'COLUMN', N'StartCode')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'开始代码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySuperior'
, @level2type = 'COLUMN', @level2name = N'StartCode'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'开始代码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySuperior'
, @level2type = 'COLUMN', @level2name = N'StartCode'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KySuperior', 
'COLUMN', N'EndCode')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'结束代码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySuperior'
, @level2type = 'COLUMN', @level2name = N'EndCode'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'结束代码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySuperior'
, @level2type = 'COLUMN', @level2name = N'EndCode'
GO

-- ----------------------------
-- Records of KySuperior
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KySuperior] ON
GO
SET IDENTITY_INSERT [dbo].[KySuperior] OFF
GO

-- ----------------------------
-- Table structure for KySuperLabel
-- ----------------------------
DROP TABLE [dbo].[KySuperLabel]
GO
CREATE TABLE [dbo].[KySuperLabel] (
[SuperId] int NOT NULL IDENTITY(1,1) ,
[Name] nvarchar(50) NULL ,
[LbCategoryName] nvarchar(50) NULL ,
[LbCategoryId] int NULL ,
[DataBaseType] int NULL ,
[SuperDes] nvarchar(500) NULL ,
[IsUnlockPage] bit NULL ,
[PageSize] int NULL DEFAULT (10) ,
[HostTable] nvarchar(50) NULL ,
[GuestTable] nvarchar(50) NULL ,
[SqlStr] nvarchar(500) NULL ,
[Content] ntext NULL ,
[AddTime] datetime NULL ,
[NumColumns] int NULL DEFAULT (1) ,
[IsHtml] bit NULL DEFAULT (1) ,
[DataBaseConn] nvarchar(300) NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[KySuperLabel]', RESEED, 7)
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KySuperLabel', 
'COLUMN', N'Name')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'标签名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySuperLabel'
, @level2type = 'COLUMN', @level2name = N'Name'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'标签名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySuperLabel'
, @level2type = 'COLUMN', @level2name = N'Name'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KySuperLabel', 
'COLUMN', N'LbCategoryName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'标签类别名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySuperLabel'
, @level2type = 'COLUMN', @level2name = N'LbCategoryName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'标签类别名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySuperLabel'
, @level2type = 'COLUMN', @level2name = N'LbCategoryName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KySuperLabel', 
'COLUMN', N'LbCategoryId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'标签类别ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySuperLabel'
, @level2type = 'COLUMN', @level2name = N'LbCategoryId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'标签类别ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySuperLabel'
, @level2type = 'COLUMN', @level2name = N'LbCategoryId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KySuperLabel', 
'COLUMN', N'DataBaseType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'数据库类型'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySuperLabel'
, @level2type = 'COLUMN', @level2name = N'DataBaseType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'数据库类型'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySuperLabel'
, @level2type = 'COLUMN', @level2name = N'DataBaseType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KySuperLabel', 
'COLUMN', N'SuperDes')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'标签说明'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySuperLabel'
, @level2type = 'COLUMN', @level2name = N'SuperDes'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'标签说明'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySuperLabel'
, @level2type = 'COLUMN', @level2name = N'SuperDes'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KySuperLabel', 
'COLUMN', N'IsUnlockPage')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否开启分页'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySuperLabel'
, @level2type = 'COLUMN', @level2name = N'IsUnlockPage'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否开启分页'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySuperLabel'
, @level2type = 'COLUMN', @level2name = N'IsUnlockPage'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KySuperLabel', 
'COLUMN', N'PageSize')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'每页显示条数'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySuperLabel'
, @level2type = 'COLUMN', @level2name = N'PageSize'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'每页显示条数'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySuperLabel'
, @level2type = 'COLUMN', @level2name = N'PageSize'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KySuperLabel', 
'COLUMN', N'HostTable')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'主表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySuperLabel'
, @level2type = 'COLUMN', @level2name = N'HostTable'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'主表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySuperLabel'
, @level2type = 'COLUMN', @level2name = N'HostTable'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KySuperLabel', 
'COLUMN', N'GuestTable')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'从表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySuperLabel'
, @level2type = 'COLUMN', @level2name = N'GuestTable'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'从表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySuperLabel'
, @level2type = 'COLUMN', @level2name = N'GuestTable'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KySuperLabel', 
'COLUMN', N'SqlStr')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'sql语句'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySuperLabel'
, @level2type = 'COLUMN', @level2name = N'SqlStr'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'sql语句'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySuperLabel'
, @level2type = 'COLUMN', @level2name = N'SqlStr'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KySuperLabel', 
'COLUMN', N'Content')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'标签内容'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySuperLabel'
, @level2type = 'COLUMN', @level2name = N'Content'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'标签内容'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySuperLabel'
, @level2type = 'COLUMN', @level2name = N'Content'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KySuperLabel', 
'COLUMN', N'NumColumns')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'显示列数'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySuperLabel'
, @level2type = 'COLUMN', @level2name = N'NumColumns'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'显示列数'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KySuperLabel'
, @level2type = 'COLUMN', @level2name = N'NumColumns'
GO

-- ----------------------------
-- Records of KySuperLabel
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KySuperLabel] ON
GO
SET IDENTITY_INSERT [dbo].[KySuperLabel] OFF
GO

-- ----------------------------
-- Table structure for KyTag
-- ----------------------------
DROP TABLE [dbo].[KyTag]
GO
CREATE TABLE [dbo].[KyTag] (
[TagId] bigint NOT NULL IDENTITY(1,1) ,
[Name] nvarchar(20) NOT NULL ,
[TagCategoryId] int NOT NULL ,
[ModelType] int NOT NULL ,
[DaySearchCount] int NULL DEFAULT (0) ,
[YesterdaySearchCount] int NULL DEFAULT (0) ,
[TotalSearchCount] int NULL DEFAULT (0) ,
[UserId] int NULL DEFAULT (0) ,
[UserName] nvarchar(20) NULL ,
[CountTime] datetime NULL DEFAULT (getdate()) 
)


GO

-- ----------------------------
-- Records of KyTag
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyTag] ON
GO
INSERT INTO [dbo].[KyTag] ([TagId], [Name], [TagCategoryId], [ModelType], [DaySearchCount], [YesterdaySearchCount], [TotalSearchCount], [UserId], [UserName], [CountTime]) VALUES (N'1', N'test,51aspx', N'0', N'1', N'0', N'0', N'0', N'0', N'后台管理员', N'2009-06-26 10:19:52.513')
GO
GO
SET IDENTITY_INSERT [dbo].[KyTag] OFF
GO

-- ----------------------------
-- Table structure for KyTagCategory
-- ----------------------------
DROP TABLE [dbo].[KyTagCategory]
GO
CREATE TABLE [dbo].[KyTagCategory] (
[TagCategoryId] int NOT NULL IDENTITY(1,1) ,
[Name] nvarchar(20) NULL ,
[Desc] nvarchar(100) NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyTagCategory]', RESEED, 7)
GO

-- ----------------------------
-- Records of KyTagCategory
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyTagCategory] ON
GO
SET IDENTITY_INSERT [dbo].[KyTagCategory] OFF
GO

-- ----------------------------
-- Table structure for KyUserAlbum
-- ----------------------------
DROP TABLE [dbo].[KyUserAlbum]
GO
CREATE TABLE [dbo].[KyUserAlbum] (
[Id] int NOT NULL IDENTITY(1,1) ,
[AlbumName] nvarchar(50) NULL ,
[AlbumCate] nvarchar(50) NULL ,
[AlbumDescription] nvarchar(500) NULL ,
[ImgCount] int NULL ,
[Logo] nvarchar(50) NULL ,
[IsOpened] int NULL ,
[AlbumPassword] nvarchar(50) NULL ,
[AddTime] nvarchar(50) NULL ,
[UserId] int NULL ,
[UserName] nvarchar(50) NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserAlbum', 
'COLUMN', N'AlbumName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'相册名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserAlbum'
, @level2type = 'COLUMN', @level2name = N'AlbumName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'相册名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserAlbum'
, @level2type = 'COLUMN', @level2name = N'AlbumName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserAlbum', 
'COLUMN', N'AlbumCate')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'所属类别'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserAlbum'
, @level2type = 'COLUMN', @level2name = N'AlbumCate'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'所属类别'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserAlbum'
, @level2type = 'COLUMN', @level2name = N'AlbumCate'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserAlbum', 
'COLUMN', N'AlbumDescription')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'相册描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserAlbum'
, @level2type = 'COLUMN', @level2name = N'AlbumDescription'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'相册描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserAlbum'
, @level2type = 'COLUMN', @level2name = N'AlbumDescription'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserAlbum', 
'COLUMN', N'ImgCount')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'图片数量'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserAlbum'
, @level2type = 'COLUMN', @level2name = N'ImgCount'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'图片数量'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserAlbum'
, @level2type = 'COLUMN', @level2name = N'ImgCount'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserAlbum', 
'COLUMN', N'Logo')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'相册封面'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserAlbum'
, @level2type = 'COLUMN', @level2name = N'Logo'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'相册封面'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserAlbum'
, @level2type = 'COLUMN', @level2name = N'Logo'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserAlbum', 
'COLUMN', N'IsOpened')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否公开 0 密码访问 1完全公开 2仅好友可见'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserAlbum'
, @level2type = 'COLUMN', @level2name = N'IsOpened'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否公开 0 密码访问 1完全公开 2仅好友可见'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserAlbum'
, @level2type = 'COLUMN', @level2name = N'IsOpened'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserAlbum', 
'COLUMN', N'AlbumPassword')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'相册密码 (IsOpened=0 必填)'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserAlbum'
, @level2type = 'COLUMN', @level2name = N'AlbumPassword'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'相册密码 (IsOpened=0 必填)'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserAlbum'
, @level2type = 'COLUMN', @level2name = N'AlbumPassword'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserAlbum', 
'COLUMN', N'AddTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'新建相册时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserAlbum'
, @level2type = 'COLUMN', @level2name = N'AddTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'新建相册时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserAlbum'
, @level2type = 'COLUMN', @level2name = N'AddTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserAlbum', 
'COLUMN', N'UserId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserAlbum'
, @level2type = 'COLUMN', @level2name = N'UserId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserAlbum'
, @level2type = 'COLUMN', @level2name = N'UserId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserAlbum', 
'COLUMN', N'UserName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserAlbum'
, @level2type = 'COLUMN', @level2name = N'UserName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserAlbum'
, @level2type = 'COLUMN', @level2name = N'UserName'
GO

-- ----------------------------
-- Records of KyUserAlbum
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyUserAlbum] ON
GO
SET IDENTITY_INSERT [dbo].[KyUserAlbum] OFF
GO

-- ----------------------------
-- Table structure for KyUserCate
-- ----------------------------
DROP TABLE [dbo].[KyUserCate]
GO
CREATE TABLE [dbo].[KyUserCate] (
[UserCateId] int NOT NULL IDENTITY(1,1) ,
[UserId] int NOT NULL ,
[CateName] varchar(50) NULL ,
[ModelType] int NOT NULL ,
[Discription] text NULL 
)


GO

-- ----------------------------
-- Records of KyUserCate
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyUserCate] ON
GO
SET IDENTITY_INSERT [dbo].[KyUserCate] OFF
GO

-- ----------------------------
-- Table structure for KyUserFavorite
-- ----------------------------
DROP TABLE [dbo].[KyUserFavorite]
GO
CREATE TABLE [dbo].[KyUserFavorite] (
[id] int NOT NULL IDENTITY(1,1) ,
[UserId] int NULL ,
[Title] nvarchar(50) NULL ,
[Url] nvarchar(500) NULL ,
[AddDate] datetime NULL 
)


GO

-- ----------------------------
-- Records of KyUserFavorite
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyUserFavorite] ON
GO
SET IDENTITY_INSERT [dbo].[KyUserFavorite] OFF
GO

-- ----------------------------
-- Table structure for KyUserFriend
-- ----------------------------
DROP TABLE [dbo].[KyUserFriend]
GO
CREATE TABLE [dbo].[KyUserFriend] (
[ID] int NOT NULL IDENTITY(1,1) ,
[UserId] int NOT NULL ,
[FriendId] int NOT NULL ,
[FriendGroupId] int NULL 
)


GO

-- ----------------------------
-- Records of KyUserFriend
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyUserFriend] ON
GO
SET IDENTITY_INSERT [dbo].[KyUserFriend] OFF
GO

-- ----------------------------
-- Table structure for KyUserFriendGroup
-- ----------------------------
DROP TABLE [dbo].[KyUserFriendGroup]
GO
CREATE TABLE [dbo].[KyUserFriendGroup] (
[FriendGroupId] int NOT NULL IDENTITY(1,1) ,
[FriendGroupName] nvarchar(50) NULL ,
[IsUserId] int NULL DEFAULT (0) 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyUserFriendGroup]', RESEED, 5)
GO

-- ----------------------------
-- Records of KyUserFriendGroup
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyUserFriendGroup] ON
GO
INSERT INTO [dbo].[KyUserFriendGroup] ([FriendGroupId], [FriendGroupName], [IsUserId]) VALUES (N'1', N'我的好友', N'0')
GO
GO
INSERT INTO [dbo].[KyUserFriendGroup] ([FriendGroupId], [FriendGroupName], [IsUserId]) VALUES (N'2', N'黑名单', N'0')
GO
GO
INSERT INTO [dbo].[KyUserFriendGroup] ([FriendGroupId], [FriendGroupName], [IsUserId]) VALUES (N'3', N'陌生人', N'8')
GO
GO
INSERT INTO [dbo].[KyUserFriendGroup] ([FriendGroupId], [FriendGroupName], [IsUserId]) VALUES (N'4', N'同事', N'13')
GO
GO
SET IDENTITY_INSERT [dbo].[KyUserFriendGroup] OFF
GO

-- ----------------------------
-- Table structure for KyUserGroup
-- ----------------------------
DROP TABLE [dbo].[KyUserGroup]
GO
CREATE TABLE [dbo].[KyUserGroup] (
[UserGroupId] int NOT NULL IDENTITY(1,1) ,
[UserGroupName] nvarchar(50) NULL ,
[UserGroupContent] nvarchar(500) NULL ,
[TypeId] int NULL ,
[GroupPower] ntext NULL ,
[ColumnPower] ntext NULL ,
[IsSystem] int NULL ,
[AddDate] datetime NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyUserGroup]', RESEED, 6)
GO

-- ----------------------------
-- Records of KyUserGroup
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyUserGroup] ON
GO
INSERT INTO [dbo].[KyUserGroup] ([UserGroupId], [UserGroupName], [UserGroupContent], [TypeId], [GroupPower], [ColumnPower], [IsSystem], [AddDate]) VALUES (N'1', N'个人用户', N'', N'1', N'Contribute=2|,Collection=0|,Invite=5|,IssueManuscript=5|,ChargingType=0|,SmashMoney=0|,Status=1', N'1@0=1|1|1|,2@0=1|1|1|,3@0=1|1|1|,1@120=0|0|0|,1@121=0|0|0|,2@122=0|0|0|', N'0', N'2008-03-06 16:04:55.000')
GO
GO
INSERT INTO [dbo].[KyUserGroup] ([UserGroupId], [UserGroupName], [UserGroupContent], [TypeId], [GroupPower], [ColumnPower], [IsSystem], [AddDate]) VALUES (N'2', N'企业用户', N'', N'2', N'Contribute=2|,Collection=0|,Invite=5|,IssueManuscript=5|,ChargingType=0|,SmashMoney=0|,Status=1', N'1@0=1|1|1|,2@0=1|1|1|,3@0=1|1|1|,1@120=0|0|0|,1@121=0|0|0|,2@122=0|0|0|', N'0', N'2008-03-06 16:04:48.000')
GO
GO
SET IDENTITY_INSERT [dbo].[KyUserGroup] OFF
GO

-- ----------------------------
-- Table structure for KyUserGroupModel
-- ----------------------------
DROP TABLE [dbo].[KyUserGroupModel]
GO
CREATE TABLE [dbo].[KyUserGroupModel] (
[Id] int NOT NULL IDENTITY(1,1) ,
[Name] nvarchar(50) NULL ,
[TableName] nvarchar(100) NULL ,
[Content] nvarchar(500) NULL ,
[IsHtml] bit NULL ,
[ModelHtml] ntext NULL ,
[IsValidate] bit NULL ,
[UserGroupId] int NULL ,
[AddTime] datetime NULL ,
[SpaceTypeId] int NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyUserGroupModel]', RESEED, 5)
GO

-- ----------------------------
-- Records of KyUserGroupModel
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyUserGroupModel] ON
GO
INSERT INTO [dbo].[KyUserGroupModel] ([Id], [Name], [TableName], [Content], [IsHtml], [ModelHtml], [IsValidate], [UserGroupId], [AddTime], [SpaceTypeId]) VALUES (N'1', N'普通用户', N'Ky_User_Personal', N'', N'0', N'<tr>
<td align="right" class="bqleft">性别：</td>
<td class="bqright"><input id="txt_Sex_0" type="radio" name="txt_Sex" value="男" checked />男<input id="txt_Sex_1" type="radio" name="txt_Sex" value="女" />女<input id="txt_Sex_2" type="radio" name="txt_Sex" value="保密" />保密 </td>
</tr>
<tr>
<td align="right" class="bqleft">真实姓名：</td>
<td class="bqright"><input type="text" name="txt_TrueName" size="35" value="">  </td>
</tr>
<tr>
<td align="right" class="bqleft">省市：</td>
<td class="bqright"><select name="select_Geographical" onchange="GetLinkage(''select_Geographical'',''select_area'',0)"><option value="0">请选择</option><option value="158">北京</option><option value="159">上海</option></select><input type="txt" name="txt_Geographical" value="0" style="display:none"><input type="txt" name="txt_Geographical_Id" value="0" style="display:none"> <select name="select_area" onchange="GetSmallLinkage(''select_area'')"><option value="0">请选择</option></select><input type="txt" name="txt_area" value="0" style="display:none"><input type="txt" name="txt_area_Id" value="0" style="display:none"> </td>
</tr>
<tr>
<td align="right" class="bqleft">详细地址：</td>
<td class="bqright"><input type="text" name="txt_Address" size="35" value="">  </td>
</tr>
<tr>
<td align="right" class="bqleft">联系电话：</td>
<td class="bqright"><input type="text" name="txt_Phone" size="35" value="">  </td>
</tr>
<tr>
<td align="right" class="bqleft">常用QQ：</td>
<td class="bqright"><input type="text" name="txt_qq" size="35" value=""  onpropertychange="if(/\D/g.test(value))value=value.replace(/\D/g,'''')" style="ime-mode:disabled" ondragenter="return false" maxlength="9">  </td>
</tr>
<tr>
<td align="right" class="bqleft">常用邮箱：</td>
<td class="bqright"><input type="text" name="txt_Email" size="35" value="">  </td>
</tr>
<tr>
<td align="right" class="bqleft">用户照片：</td>
<td class="bqright"><input type="text" name="txt_Picture" size="35"> <input type="button" class="btn" onclick="WinOpenDialog(''/common/SelectPic.aspx?ControlId=txt_Picture'',''500'',''400'')" value=" 选择图片 ">  用户照片</td>
</tr>', N'0', N'1', N'2008-03-05 15:18:43.173', N'1')
GO
GO
INSERT INTO [dbo].[KyUserGroupModel] ([Id], [Name], [TableName], [Content], [IsHtml], [ModelHtml], [IsValidate], [UserGroupId], [AddTime], [SpaceTypeId]) VALUES (N'2', N'企业用户', N'Ky_User_Business', N'', N'0', N'<tr>
<td align="right" class="bqleft">企业名称：</td>
<td class="bqright"><input type="text" name="txt_name" size="50" value=""> <font color="red">*</font> </td>
</tr>
<tr>
<td align="right" class="bqleft">所属行业：</td>
<td class="bqright"><select name="txt_Industry"><option value="政府机构">政府机构</option><option value="外商投资">外商投资</option><option value="环保行业">环保行业</option><option value="酒店旅游">酒店旅游</option><option value="大中企业">大中企业</option><option value="进出口业">进出口业</option><option value="其它行业">其它行业</option></select>  </td>
</tr>
<tr>
<td align="right" class="bqleft">公司类型：</td>
<td class="bqright"><select name="txt_lx"><option value="个人独资">个人独资</option><option value="合资公司">合资公司</option><option value="股份公司">股份公司</option><option value="集团公司">集团公司</option></select>  </td>
</tr>
<tr>
<td align="right" class="bqleft">注册资本：</td>
<td class="bqright"><select name="txt_Capital"><option value="1万以下">1万以下</option><option value="1-5万">1-5万</option><option value="5-10万">5-10万</option><option value="10-20万">10-20万</option><option value="20-50万">20-50万</option><option value="50-100万">50-100万</option><option value="100万以上">100万以上</option></select>  </td>
</tr>
<tr>
<td align="right" class="bqleft">员工人数：</td>
<td class="bqright"><select name="txt_EmployNumber"><option value="1-5人">1-5人</option><option value="6-10人">6-10人</option><option value="11-20人">11-20人</option><option value="20-50人">20-50人</option><option value="50-100人">50-100人</option><option value="100人以上">100人以上</option></select>  </td>
</tr>
<tr>
<td align="right" class="bqleft">法人代表：</td>
<td class="bqright"><input type="text" name="txt_LegalPerson" size="35" value="">  </td>
</tr>
<tr>
<td align="right" class="bqleft">经营许可证：</td>
<td class="bqright"><input type="text" name="txt_License" size="35"> <input type="button" class="btn" onclick="WinOpenDialog(''/common/SelectPic.aspx?ControlId=txt_License'',''500'',''400'')" value=" 选择图片 ">  </td>
</tr>
<tr>
<td align="right" class="bqleft">其他证书：</td>
<td class="bqright"><input type="text" name="txt_OtherCertificates" size="35"> <input type="button" class="btn" onclick="WinOpenDialog(''/common/SelectPic.aspx?ControlId=txt_OtherCertificates'',''500'',''400'')" value=" 选择图片 ">  </td>
</tr>
<tr>
<td align="right" class="bqleft">税务登记证：</td>
<td class="bqright"><input type="text" name="txt_TaxCertificates" size="35"> <input type="button" class="btn" onclick="WinOpenDialog(''/common/SelectPic.aspx?ControlId=txt_TaxCertificates'',''500'',''400'')" value=" 选择图片 ">  </td>
</tr>
<tr>
<td align="right" class="bqleft">联系人：</td>
<td class="bqright"><input type="text" name="txt_ContactPersonal" size="35" value="">  </td>
</tr>
<tr>
<td align="right" class="bqleft">联系电话：</td>
<td class="bqright"><input type="text" name="txt_Telephone" size="35" value="">  </td>
</tr>
<tr>
<td align="right" class="bqleft">联系邮箱：</td>
<td class="bqright"><input type="text" name="txt_CompanyEmail" size="35" value="">  </td>
</tr>
<tr>
<td align="right" class="bqleft">传真：</td>
<td class="bqright"><input type="text" name="txt_Fax" size="35" value="">  </td>
</tr>
<tr>
<td align="right" class="bqleft">通讯地址：</td>
<td class="bqright"><input type="text" name="txt_Address" size="35" value="">  </td>
</tr>
<tr>
<td align="right" class="bqleft">邮编：</td>
<td class="bqright"><input type="text" name="txt_Zip" size="35" value="">  </td>
</tr>
<tr>
<td align="right" class="bqleft">企业网址：</td>
<td class="bqright"><input type="text" name="txt_HomePage" size="35" value="">  </td>
</tr>
<tr>
<td align="right" class="bqleft">企业LOGO：</td>
<td class="bqright"><input type="text" name="txt_LOGO" size="35"> <input type="button" class="btn" onclick="WinOpenDialog(''/common/SelectPic.aspx?ControlId=txt_LOGO'',''500'',''400'')" value=" 选择图片 ">  </td>
</tr>
<tr>
<td align="right" class="bqleft">公司介绍：</td>
<td class="bqright"><input type="hidden" id="txt_Introduce" name="txt_Introduce" value=""><input type="hidden" id="txt_Introduce___Config" value=""><iframe id="txt_Introduce___Frame" src="/editor/fckeditor_2.html?InstanceName=txt_Introduce&Toolbar=Default" width="715px" height="400px" frameborder="no" scrolling="no"></iframe>  </td>
</tr>', N'1', N'2', N'2007-12-25 16:00:11.687', N'2')
GO
GO
SET IDENTITY_INSERT [dbo].[KyUserGroupModel] OFF
GO

-- ----------------------------
-- Table structure for KyUserGroupModelField
-- ----------------------------
DROP TABLE [dbo].[KyUserGroupModelField]
GO
CREATE TABLE [dbo].[KyUserGroupModelField] (
[FieldId] int NOT NULL IDENTITY(1,1) ,
[ModelId] int NULL ,
[Name] nvarchar(50) NULL ,
[Alias] nvarchar(150) NULL ,
[Description] nvarchar(200) NULL ,
[IsNotNull] bit NULL ,
[IsSearchForm] bit NULL ,
[Type] nvarchar(50) NULL ,
[Content] ntext NULL ,
[OrderId] int NULL DEFAULT (0) ,
[IsList] bit NULL ,
[IsUserInsert] bit NULL ,
[AddDate] datetime NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyUserGroupModelField]', RESEED, 40)
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserGroupModelField', 
'COLUMN', N'ModelId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'表单Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserGroupModelField'
, @level2type = 'COLUMN', @level2name = N'ModelId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'表单Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserGroupModelField'
, @level2type = 'COLUMN', @level2name = N'ModelId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserGroupModelField', 
'COLUMN', N'Name')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'字段名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserGroupModelField'
, @level2type = 'COLUMN', @level2name = N'Name'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'字段名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserGroupModelField'
, @level2type = 'COLUMN', @level2name = N'Name'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserGroupModelField', 
'COLUMN', N'Alias')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'字段别名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserGroupModelField'
, @level2type = 'COLUMN', @level2name = N'Alias'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'字段别名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserGroupModelField'
, @level2type = 'COLUMN', @level2name = N'Alias'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserGroupModelField', 
'COLUMN', N'Description')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'字段描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserGroupModelField'
, @level2type = 'COLUMN', @level2name = N'Description'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'字段描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserGroupModelField'
, @level2type = 'COLUMN', @level2name = N'Description'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserGroupModelField', 
'COLUMN', N'IsNotNull')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否必填'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserGroupModelField'
, @level2type = 'COLUMN', @level2name = N'IsNotNull'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否必填'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserGroupModelField'
, @level2type = 'COLUMN', @level2name = N'IsNotNull'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserGroupModelField', 
'COLUMN', N'IsSearchForm')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否在搜索表单显示'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserGroupModelField'
, @level2type = 'COLUMN', @level2name = N'IsSearchForm'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否在搜索表单显示'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserGroupModelField'
, @level2type = 'COLUMN', @level2name = N'IsSearchForm'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserGroupModelField', 
'COLUMN', N'Type')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'字段类型'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserGroupModelField'
, @level2type = 'COLUMN', @level2name = N'Type'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'字段类型'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserGroupModelField'
, @level2type = 'COLUMN', @level2name = N'Type'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserGroupModelField', 
'COLUMN', N'Content')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'字段内容'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserGroupModelField'
, @level2type = 'COLUMN', @level2name = N'Content'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'字段内容'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserGroupModelField'
, @level2type = 'COLUMN', @level2name = N'Content'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserGroupModelField', 
'COLUMN', N'OrderId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'排序'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserGroupModelField'
, @level2type = 'COLUMN', @level2name = N'OrderId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'排序'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserGroupModelField'
, @level2type = 'COLUMN', @level2name = N'OrderId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserGroupModelField', 
'COLUMN', N'IsList')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否在列表页中显示'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserGroupModelField'
, @level2type = 'COLUMN', @level2name = N'IsList'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否在列表页中显示'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserGroupModelField'
, @level2type = 'COLUMN', @level2name = N'IsList'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserGroupModelField', 
'COLUMN', N'IsUserInsert')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否允许用户录入数据'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserGroupModelField'
, @level2type = 'COLUMN', @level2name = N'IsUserInsert'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否允许用户录入数据'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserGroupModelField'
, @level2type = 'COLUMN', @level2name = N'IsUserInsert'
GO

-- ----------------------------
-- Records of KyUserGroupModelField
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyUserGroupModelField] ON
GO
INSERT INTO [dbo].[KyUserGroupModelField] ([FieldId], [ModelId], [Name], [Alias], [Description], [IsNotNull], [IsSearchForm], [Type], [Content], [OrderId], [IsList], [IsUserInsert], [AddDate]) VALUES (N'7', N'2', N'Industry', N'所属行业', N'', N'0', N'0', N'RadioType', N'1=政府机构|外商投资|环保行业|酒店旅游|大中企业|进出口业|其它行业,Property=True,Default=', N'2', N'0', N'1', N'2007-12-14 23:23:31.390')
GO
GO
INSERT INTO [dbo].[KyUserGroupModelField] ([FieldId], [ModelId], [Name], [Alias], [Description], [IsNotNull], [IsSearchForm], [Type], [Content], [OrderId], [IsList], [IsUserInsert], [AddDate]) VALUES (N'8', N'2', N'Capital', N'注册资本', N'', N'0', N'0', N'RadioType', N'1=1万以下|1-5万|5-10万|10-20万|20-50万|50-100万|100万以上,Property=True,Default=', N'4', N'0', N'1', N'2007-12-14 17:18:47.843')
GO
GO
INSERT INTO [dbo].[KyUserGroupModelField] ([FieldId], [ModelId], [Name], [Alias], [Description], [IsNotNull], [IsSearchForm], [Type], [Content], [OrderId], [IsList], [IsUserInsert], [AddDate]) VALUES (N'9', N'2', N'EmployNumber', N'员工人数', N'', N'0', N'0', N'RadioType', N'1=1-5人|6-10人|11-20人|20-50人|50-100人|100人以上,Property=True,Default=5', N'6', N'0', N'1', N'2007-12-14 17:21:12.657')
GO
GO
INSERT INTO [dbo].[KyUserGroupModelField] ([FieldId], [ModelId], [Name], [Alias], [Description], [IsNotNull], [IsSearchForm], [Type], [Content], [OrderId], [IsList], [IsUserInsert], [AddDate]) VALUES (N'10', N'2', N'LegalPerson', N'法人代表', N'', N'0', N'0', N'TextType', N'TitleSize=35,IsPassword=text,DefaultValue=', N'7', N'0', N'1', N'2008-03-06 16:03:59.923')
GO
GO
INSERT INTO [dbo].[KyUserGroupModelField] ([FieldId], [ModelId], [Name], [Alias], [Description], [IsNotNull], [IsSearchForm], [Type], [Content], [OrderId], [IsList], [IsUserInsert], [AddDate]) VALUES (N'11', N'2', N'Introduce', N'公司介绍', N'', N'0', N'0', N'MultipleHtmlType', N'Width=715,Height=400,IsEditor=2', N'19', N'0', N'1', N'2007-12-25 16:00:50.300')
GO
GO
INSERT INTO [dbo].[KyUserGroupModelField] ([FieldId], [ModelId], [Name], [Alias], [Description], [IsNotNull], [IsSearchForm], [Type], [Content], [OrderId], [IsList], [IsUserInsert], [AddDate]) VALUES (N'12', N'2', N'License', N'经营许可证', N'', N'0', N'0', N'PicType', N'', N'8', N'0', N'1', N'2007-12-14 17:29:36.437')
GO
GO
INSERT INTO [dbo].[KyUserGroupModelField] ([FieldId], [ModelId], [Name], [Alias], [Description], [IsNotNull], [IsSearchForm], [Type], [Content], [OrderId], [IsList], [IsUserInsert], [AddDate]) VALUES (N'13', N'2', N'TaxCertificates', N'税务登记证', N'', N'0', N'0', N'PicType', N'', N'10', N'0', N'1', N'2007-12-14 17:30:47.437')
GO
GO
INSERT INTO [dbo].[KyUserGroupModelField] ([FieldId], [ModelId], [Name], [Alias], [Description], [IsNotNull], [IsSearchForm], [Type], [Content], [OrderId], [IsList], [IsUserInsert], [AddDate]) VALUES (N'14', N'2', N'OtherCertificates', N'其他证书', N'', N'0', N'0', N'PicType', N'', N'9', N'0', N'1', N'2007-12-14 17:31:17.110')
GO
GO
INSERT INTO [dbo].[KyUserGroupModelField] ([FieldId], [ModelId], [Name], [Alias], [Description], [IsNotNull], [IsSearchForm], [Type], [Content], [OrderId], [IsList], [IsUserInsert], [AddDate]) VALUES (N'15', N'2', N'ContactPersonal', N'联系人', N'', N'0', N'0', N'TextType', N'TitleSize=35,IsPassword=text,DefaultValue=', N'11', N'0', N'1', N'2007-12-14 17:32:20.703')
GO
GO
INSERT INTO [dbo].[KyUserGroupModelField] ([FieldId], [ModelId], [Name], [Alias], [Description], [IsNotNull], [IsSearchForm], [Type], [Content], [OrderId], [IsList], [IsUserInsert], [AddDate]) VALUES (N'16', N'2', N'Telephone', N'联系电话', N'', N'0', N'0', N'TextType', N'TitleSize=35,IsPassword=text,DefaultValue=', N'12', N'0', N'1', N'2007-12-14 17:33:06.733')
GO
GO
INSERT INTO [dbo].[KyUserGroupModelField] ([FieldId], [ModelId], [Name], [Alias], [Description], [IsNotNull], [IsSearchForm], [Type], [Content], [OrderId], [IsList], [IsUserInsert], [AddDate]) VALUES (N'17', N'2', N'CompanyEmail', N'联系邮箱', N'', N'0', N'0', N'TextType', N'TitleSize=35,IsPassword=text,DefaultValue=', N'13', N'0', N'1', N'2007-12-14 17:36:15.470')
GO
GO
INSERT INTO [dbo].[KyUserGroupModelField] ([FieldId], [ModelId], [Name], [Alias], [Description], [IsNotNull], [IsSearchForm], [Type], [Content], [OrderId], [IsList], [IsUserInsert], [AddDate]) VALUES (N'18', N'2', N'Fax', N'传真', N'', N'0', N'0', N'TextType', N'TitleSize=35,IsPassword=text,DefaultValue=', N'14', N'0', N'1', N'2007-12-14 17:37:20.673')
GO
GO
INSERT INTO [dbo].[KyUserGroupModelField] ([FieldId], [ModelId], [Name], [Alias], [Description], [IsNotNull], [IsSearchForm], [Type], [Content], [OrderId], [IsList], [IsUserInsert], [AddDate]) VALUES (N'19', N'2', N'Address', N'通讯地址', N'', N'0', N'0', N'TextType', N'TitleSize=35,IsPassword=text,DefaultValue=', N'15', N'0', N'1', N'2007-12-14 17:37:34.327')
GO
GO
INSERT INTO [dbo].[KyUserGroupModelField] ([FieldId], [ModelId], [Name], [Alias], [Description], [IsNotNull], [IsSearchForm], [Type], [Content], [OrderId], [IsList], [IsUserInsert], [AddDate]) VALUES (N'20', N'2', N'Zip', N'邮编', N'', N'0', N'0', N'TextType', N'TitleSize=35,IsPassword=text,DefaultValue=', N'16', N'0', N'1', N'2007-12-14 17:38:01.703')
GO
GO
INSERT INTO [dbo].[KyUserGroupModelField] ([FieldId], [ModelId], [Name], [Alias], [Description], [IsNotNull], [IsSearchForm], [Type], [Content], [OrderId], [IsList], [IsUserInsert], [AddDate]) VALUES (N'21', N'2', N'HomePage', N'企业网址', N'', N'0', N'0', N'TextType', N'TitleSize=35,IsPassword=text,DefaultValue=', N'17', N'0', N'1', N'2007-12-14 17:38:20.297')
GO
GO
INSERT INTO [dbo].[KyUserGroupModelField] ([FieldId], [ModelId], [Name], [Alias], [Description], [IsNotNull], [IsSearchForm], [Type], [Content], [OrderId], [IsList], [IsUserInsert], [AddDate]) VALUES (N'22', N'2', N'LOGO', N'企业LOGO', N'', N'0', N'0', N'PicType', N'', N'18', N'0', N'1', N'2007-12-14 17:38:40.157')
GO
GO
INSERT INTO [dbo].[KyUserGroupModelField] ([FieldId], [ModelId], [Name], [Alias], [Description], [IsNotNull], [IsSearchForm], [Type], [Content], [OrderId], [IsList], [IsUserInsert], [AddDate]) VALUES (N'23', N'2', N'name', N'企业名称', N'', N'1', N'0', N'TextType', N'TitleSize=50,IsPassword=text,DefaultValue=', N'0', N'1', N'1', N'2007-12-14 23:21:50.453')
GO
GO
INSERT INTO [dbo].[KyUserGroupModelField] ([FieldId], [ModelId], [Name], [Alias], [Description], [IsNotNull], [IsSearchForm], [Type], [Content], [OrderId], [IsList], [IsUserInsert], [AddDate]) VALUES (N'28', N'2', N'lx', N'公司类型', N'', N'0', N'0', N'RadioType', N'1=个人独资|合资公司|股份公司|集团公司,Property=False,Default=', N'3', N'0', N'1', N'2007-12-20 12:19:11.157')
GO
GO
INSERT INTO [dbo].[KyUserGroupModelField] ([FieldId], [ModelId], [Name], [Alias], [Description], [IsNotNull], [IsSearchForm], [Type], [Content], [OrderId], [IsList], [IsUserInsert], [AddDate]) VALUES (N'32', N'1', N'Sex', N'性别', N'', N'0', N'0', N'RadioType', N'2=男|女|保密,Property=False,Default=保密', N'0', N'0', N'1', N'2008-03-06 16:04:05.297')
GO
GO
INSERT INTO [dbo].[KyUserGroupModelField] ([FieldId], [ModelId], [Name], [Alias], [Description], [IsNotNull], [IsSearchForm], [Type], [Content], [OrderId], [IsList], [IsUserInsert], [AddDate]) VALUES (N'33', N'1', N'TrueName', N'真实姓名', N'', N'0', N'0', N'TextType', N'TitleSize=35,IsPassword=text,DefaultValue=', N'1', N'0', N'1', N'2008-03-05 15:19:05.000')
GO
GO
INSERT INTO [dbo].[KyUserGroupModelField] ([FieldId], [ModelId], [Name], [Alias], [Description], [IsNotNull], [IsSearchForm], [Type], [Content], [OrderId], [IsList], [IsUserInsert], [AddDate]) VALUES (N'34', N'1', N'Geographical', N'省市', N'', N'0', N'0', N'ErLinkageType', N'YiId=157,Er_Alias=市,Er_Name=area', N'2', N'0', N'1', N'2008-03-05 15:19:13.127')
GO
GO
INSERT INTO [dbo].[KyUserGroupModelField] ([FieldId], [ModelId], [Name], [Alias], [Description], [IsNotNull], [IsSearchForm], [Type], [Content], [OrderId], [IsList], [IsUserInsert], [AddDate]) VALUES (N'35', N'1', N'Address', N'详细地址', N'', N'0', N'0', N'TextType', N'TitleSize=35,IsPassword=text,DefaultValue=', N'3', N'0', N'1', N'2008-03-05 15:19:30.720')
GO
GO
INSERT INTO [dbo].[KyUserGroupModelField] ([FieldId], [ModelId], [Name], [Alias], [Description], [IsNotNull], [IsSearchForm], [Type], [Content], [OrderId], [IsList], [IsUserInsert], [AddDate]) VALUES (N'36', N'1', N'Phone', N'联系电话', N'', N'0', N'0', N'TextType', N'TitleSize=35,IsPassword=text,DefaultValue=', N'4', N'0', N'1', N'2008-03-05 15:19:37.140')
GO
GO
INSERT INTO [dbo].[KyUserGroupModelField] ([FieldId], [ModelId], [Name], [Alias], [Description], [IsNotNull], [IsSearchForm], [Type], [Content], [OrderId], [IsList], [IsUserInsert], [AddDate]) VALUES (N'37', N'1', N'qq', N'常用QQ', N'', N'0', N'0', N'NumberType', N'TitleSize=35,DefaultValue=', N'5', N'0', N'1', N'2008-03-05 15:19:45.140')
GO
GO
INSERT INTO [dbo].[KyUserGroupModelField] ([FieldId], [ModelId], [Name], [Alias], [Description], [IsNotNull], [IsSearchForm], [Type], [Content], [OrderId], [IsList], [IsUserInsert], [AddDate]) VALUES (N'38', N'1', N'Email', N'常用邮箱', N'', N'0', N'0', N'TextType', N'TitleSize=35,IsPassword=text,DefaultValue=', N'6', N'0', N'1', N'2008-03-05 15:19:59.827')
GO
GO
INSERT INTO [dbo].[KyUserGroupModelField] ([FieldId], [ModelId], [Name], [Alias], [Description], [IsNotNull], [IsSearchForm], [Type], [Content], [OrderId], [IsList], [IsUserInsert], [AddDate]) VALUES (N'40', N'1', N'Picture', N'用户照片', N'用户照片', N'0', N'0', N'PicType', N'', N'7', N'0', N'1', N'2008-03-05 16:45:48.673')
GO
GO
SET IDENTITY_INSERT [dbo].[KyUserGroupModelField] OFF
GO

-- ----------------------------
-- Table structure for KyUserLog
-- ----------------------------
DROP TABLE [dbo].[KyUserLog]
GO
CREATE TABLE [dbo].[KyUserLog] (
[ID] int NOT NULL IDENTITY(1,1) ,
[UserId] int NOT NULL ,
[UserName] nvarchar(20) NOT NULL ,
[Description] nvarchar(1000) NULL ,
[InfoId] int NOT NULL ,
[ModelType] int NOT NULL ,
[Point] int NULL DEFAULT (0) ,
[AddTime] datetime NOT NULL 
)


GO

-- ----------------------------
-- Records of KyUserLog
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyUserLog] ON
GO
SET IDENTITY_INSERT [dbo].[KyUserLog] OFF
GO

-- ----------------------------
-- Table structure for KyUserMessage
-- ----------------------------
DROP TABLE [dbo].[KyUserMessage]
GO
CREATE TABLE [dbo].[KyUserMessage] (
[Id] int NOT NULL IDENTITY(1,1) ,
[Title] nvarchar(100) NULL ,
[Content] text NULL ,
[UserId] int NULL ,
[AnounName] nvarchar(50) NULL ,
[HomePage] nvarchar(100) NULL DEFAULT (N'http://') ,
[IsPrivacy] bit NULL ,
[IsResume] bit NULL ,
[ResumeContent] text NULL ,
[PostTime] nvarchar(100) NULL ,
[ResumeTime] nvarchar(50) NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserMessage', 
'COLUMN', N'Id')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'留言板编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserMessage'
, @level2type = 'COLUMN', @level2name = N'Id'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'留言板编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserMessage'
, @level2type = 'COLUMN', @level2name = N'Id'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserMessage', 
'COLUMN', N'Title')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'留言标题'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserMessage'
, @level2type = 'COLUMN', @level2name = N'Title'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'留言标题'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserMessage'
, @level2type = 'COLUMN', @level2name = N'Title'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserMessage', 
'COLUMN', N'Content')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'留言内容'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserMessage'
, @level2type = 'COLUMN', @level2name = N'Content'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'留言内容'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserMessage'
, @level2type = 'COLUMN', @level2name = N'Content'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserMessage', 
'COLUMN', N'UserId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserMessage'
, @level2type = 'COLUMN', @level2name = N'UserId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserMessage'
, @level2type = 'COLUMN', @level2name = N'UserId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserMessage', 
'COLUMN', N'AnounName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'留言人昵称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserMessage'
, @level2type = 'COLUMN', @level2name = N'AnounName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'留言人昵称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserMessage'
, @level2type = 'COLUMN', @level2name = N'AnounName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserMessage', 
'COLUMN', N'HomePage')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'留言人主页'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserMessage'
, @level2type = 'COLUMN', @level2name = N'HomePage'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'留言人主页'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserMessage'
, @level2type = 'COLUMN', @level2name = N'HomePage'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserMessage', 
'COLUMN', N'IsPrivacy')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否悄悄话 0否 1是'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserMessage'
, @level2type = 'COLUMN', @level2name = N'IsPrivacy'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否悄悄话 0否 1是'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserMessage'
, @level2type = 'COLUMN', @level2name = N'IsPrivacy'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserMessage', 
'COLUMN', N'IsResume')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否回复 0 否 1是'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserMessage'
, @level2type = 'COLUMN', @level2name = N'IsResume'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否回复 0 否 1是'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserMessage'
, @level2type = 'COLUMN', @level2name = N'IsResume'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserMessage', 
'COLUMN', N'ResumeContent')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'回复内容'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserMessage'
, @level2type = 'COLUMN', @level2name = N'ResumeContent'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'回复内容'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserMessage'
, @level2type = 'COLUMN', @level2name = N'ResumeContent'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserMessage', 
'COLUMN', N'PostTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'留言(发表)时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserMessage'
, @level2type = 'COLUMN', @level2name = N'PostTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'留言(发表)时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserMessage'
, @level2type = 'COLUMN', @level2name = N'PostTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserMessage', 
'COLUMN', N'ResumeTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'回复时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserMessage'
, @level2type = 'COLUMN', @level2name = N'ResumeTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'回复时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserMessage'
, @level2type = 'COLUMN', @level2name = N'ResumeTime'
GO

-- ----------------------------
-- Records of KyUserMessage
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyUserMessage] ON
GO
SET IDENTITY_INSERT [dbo].[KyUserMessage] OFF
GO

-- ----------------------------
-- Table structure for KyUserPhoto
-- ----------------------------
DROP TABLE [dbo].[KyUserPhoto]
GO
CREATE TABLE [dbo].[KyUserPhoto] (
[PhotoId] int NOT NULL IDENTITY(1,1) ,
[AlbumId] int NOT NULL ,
[FileName] nvarchar(50) NULL ,
[FilePath] nvarchar(100) NULL ,
[Description] nvarchar(500) NULL ,
[PostTime] nvarchar(50) NULL ,
[VisitNum] int NULL DEFAULT (0) ,
[UserId] int NULL ,
[UserName] nvarchar(50) NULL ,
[FileSize] int NULL DEFAULT (0) 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserPhoto', 
'COLUMN', N'PhotoId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'相片编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserPhoto'
, @level2type = 'COLUMN', @level2name = N'PhotoId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'相片编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserPhoto'
, @level2type = 'COLUMN', @level2name = N'PhotoId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserPhoto', 
'COLUMN', N'AlbumId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'所属相册编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserPhoto'
, @level2type = 'COLUMN', @level2name = N'AlbumId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'所属相册编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserPhoto'
, @level2type = 'COLUMN', @level2name = N'AlbumId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserPhoto', 
'COLUMN', N'FileName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'相片名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserPhoto'
, @level2type = 'COLUMN', @level2name = N'FileName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'相片名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserPhoto'
, @level2type = 'COLUMN', @level2name = N'FileName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserPhoto', 
'COLUMN', N'FilePath')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'相片路径'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserPhoto'
, @level2type = 'COLUMN', @level2name = N'FilePath'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'相片路径'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserPhoto'
, @level2type = 'COLUMN', @level2name = N'FilePath'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserPhoto', 
'COLUMN', N'Description')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'相片描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserPhoto'
, @level2type = 'COLUMN', @level2name = N'Description'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'相片描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserPhoto'
, @level2type = 'COLUMN', @level2name = N'Description'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserPhoto', 
'COLUMN', N'PostTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'上传时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserPhoto'
, @level2type = 'COLUMN', @level2name = N'PostTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'上传时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserPhoto'
, @level2type = 'COLUMN', @level2name = N'PostTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserPhoto', 
'COLUMN', N'VisitNum')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'浏览次数'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserPhoto'
, @level2type = 'COLUMN', @level2name = N'VisitNum'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'浏览次数'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserPhoto'
, @level2type = 'COLUMN', @level2name = N'VisitNum'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserPhoto', 
'COLUMN', N'UserId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserPhoto'
, @level2type = 'COLUMN', @level2name = N'UserId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserPhoto'
, @level2type = 'COLUMN', @level2name = N'UserId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserPhoto', 
'COLUMN', N'UserName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserPhoto'
, @level2type = 'COLUMN', @level2name = N'UserName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserPhoto'
, @level2type = 'COLUMN', @level2name = N'UserName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserPhoto', 
'COLUMN', N'FileSize')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'照片大小'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserPhoto'
, @level2type = 'COLUMN', @level2name = N'FileSize'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'照片大小'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserPhoto'
, @level2type = 'COLUMN', @level2name = N'FileSize'
GO

-- ----------------------------
-- Records of KyUserPhoto
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyUserPhoto] ON
GO
SET IDENTITY_INSERT [dbo].[KyUserPhoto] OFF
GO

-- ----------------------------
-- Table structure for KyUsers
-- ----------------------------
DROP TABLE [dbo].[KyUsers]
GO
CREATE TABLE [dbo].[KyUsers] (
[UserID] int NOT NULL IDENTITY(1,1) ,
[LogName] nvarchar(20) NULL ,
[UserPwd] nvarchar(200) NULL ,
[Email] varchar(100) NULL ,
[TypeId] int NULL ,
[GroupID] int NULL ,
[Question] nvarchar(50) NULL ,
[Answer] nvarchar(50) NULL ,
[Integral] int NULL ,
[YellowBoy] decimal(10) NULL DEFAULT (0) ,
[IsLock] bit NULL DEFAULT (0) ,
[LoginNum] int NULL DEFAULT (1) ,
[LastLoginIP] nvarchar(20) NULL ,
[RegTime] datetime NULL DEFAULT (getdate()) ,
[LastLoginTime] datetime NULL DEFAULT (getdate()) ,
[Secret] tinyint NULL ,
[ErrorNum] int NULL DEFAULT (0) ,
[ErrorTime] datetime NULL DEFAULT (getdate()) ,
[ExpireTime] datetime NULL DEFAULT (getdate()) ,
[ConfirmRegCode] varchar(50) NULL ,
[Status] int NULL 
)


GO

-- ----------------------------
-- Records of KyUsers
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyUsers] ON
GO
SET IDENTITY_INSERT [dbo].[KyUsers] OFF
GO

-- ----------------------------
-- Table structure for KyUserSpace
-- ----------------------------
DROP TABLE [dbo].[KyUserSpace]
GO
CREATE TABLE [dbo].[KyUserSpace] (
[Id] int NOT NULL IDENTITY(1,1) ,
[SpaceName] nvarchar(50) NOT NULL ,
[SpaceDescription] nvarchar(500) NULL ,
[PrevPower] int NULL ,
[Password] nvarchar(50) NULL ,
[AddTime] nvarchar(50) NULL ,
[UserId] int NOT NULL ,
[UserName] nvarchar(50) NULL ,
[TemplateId] int NULL ,
[UserType] int NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserSpace', 
'COLUMN', N'SpaceName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'空间名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserSpace'
, @level2type = 'COLUMN', @level2name = N'SpaceName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'空间名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserSpace'
, @level2type = 'COLUMN', @level2name = N'SpaceName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserSpace', 
'COLUMN', N'SpaceDescription')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'空间描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserSpace'
, @level2type = 'COLUMN', @level2name = N'SpaceDescription'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'空间描述'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserSpace'
, @level2type = 'COLUMN', @level2name = N'SpaceDescription'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserSpace', 
'COLUMN', N'PrevPower')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'查看权限0 允许所有人 1仅好友可见 2密码访问'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserSpace'
, @level2type = 'COLUMN', @level2name = N'PrevPower'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'查看权限0 允许所有人 1仅好友可见 2密码访问'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserSpace'
, @level2type = 'COLUMN', @level2name = N'PrevPower'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserSpace', 
'COLUMN', N'Password')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'访问密码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserSpace'
, @level2type = 'COLUMN', @level2name = N'Password'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'访问密码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserSpace'
, @level2type = 'COLUMN', @level2name = N'Password'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserSpace', 
'COLUMN', N'AddTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'申请时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserSpace'
, @level2type = 'COLUMN', @level2name = N'AddTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'申请时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserSpace'
, @level2type = 'COLUMN', @level2name = N'AddTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserSpace', 
'COLUMN', N'UserId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserSpace'
, @level2type = 'COLUMN', @level2name = N'UserId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserSpace'
, @level2type = 'COLUMN', @level2name = N'UserId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserSpace', 
'COLUMN', N'UserName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserSpace'
, @level2type = 'COLUMN', @level2name = N'UserName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserSpace'
, @level2type = 'COLUMN', @level2name = N'UserName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserSpace', 
'COLUMN', N'TemplateId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'模板ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserSpace'
, @level2type = 'COLUMN', @level2name = N'TemplateId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'模板ID'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserSpace'
, @level2type = 'COLUMN', @level2name = N'TemplateId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'KyUserSpace', 
'COLUMN', N'UserType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户类别 1 普通用户 2 企业用户'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserSpace'
, @level2type = 'COLUMN', @level2name = N'UserType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户类别 1 普通用户 2 企业用户'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'KyUserSpace'
, @level2type = 'COLUMN', @level2name = N'UserType'
GO

-- ----------------------------
-- Records of KyUserSpace
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyUserSpace] ON
GO
SET IDENTITY_INSERT [dbo].[KyUserSpace] OFF
GO

-- ----------------------------
-- Table structure for KyViewLog
-- ----------------------------
DROP TABLE [dbo].[KyViewLog]
GO
CREATE TABLE [dbo].[KyViewLog] (
[Id] int NOT NULL IDENTITY(1,1) ,
[UserId] int NOT NULL ,
[UserName] nvarchar(20) NOT NULL ,
[ModelType] int NOT NULL ,
[InfoId] int NOT NULL ,
[AddTime] datetime NOT NULL DEFAULT (getdate()) 
)


GO

-- ----------------------------
-- Records of KyViewLog
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyViewLog] ON
GO
SET IDENTITY_INSERT [dbo].[KyViewLog] OFF
GO

-- ----------------------------
-- Table structure for KyVote
-- ----------------------------
DROP TABLE [dbo].[KyVote]
GO
CREATE TABLE [dbo].[KyVote] (
[VoteId] int NOT NULL IDENTITY(1,1) ,
[SubjectId] int NULL ,
[VoteTitle] nvarchar(100) NULL ,
[DisplayType] int NULL DEFAULT (1) ,
[IsMore] bit NULL ,
[ModelType] int NOT NULL DEFAULT (1) ,
[ItemTitle1] nvarchar(100) NULL ,
[ItemNum1] int NULL ,
[ItemTitle2] nvarchar(100) NULL ,
[ItemNum2] int NULL ,
[ItemTitle3] nvarchar(100) NULL ,
[ItemNum3] int NULL ,
[ItemTitle4] nvarchar(100) NULL ,
[ItemNum4] int NULL ,
[ItemTitle5] nvarchar(100) NULL ,
[ItemNum5] int NULL ,
[ItemTitle6] nvarchar(100) NULL ,
[ItemNum6] int NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyVote]', RESEED, 6)
GO

-- ----------------------------
-- Records of KyVote
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyVote] ON
GO
INSERT INTO [dbo].[KyVote] ([VoteId], [SubjectId], [VoteTitle], [DisplayType], [IsMore], [ModelType], [ItemTitle1], [ItemNum1], [ItemTitle2], [ItemNum2], [ItemTitle3], [ItemNum3], [ItemTitle4], [ItemNum4], [ItemTitle5], [ItemNum5], [ItemTitle6], [ItemNum6]) VALUES (N'1', N'1', N'您觉得酷源CMS怎么样?', N'1', N'0', N'1', N'我觉得非常好', N'0', N'很好很好很好', N'0', N'真的是很不错', N'0', N'没有什么感觉', N'0', N'不爱这个系统', N'0', N'', N'0')
GO
GO
SET IDENTITY_INSERT [dbo].[KyVote] OFF
GO

-- ----------------------------
-- Table structure for KyVoteCategory
-- ----------------------------
DROP TABLE [dbo].[KyVoteCategory]
GO
CREATE TABLE [dbo].[KyVoteCategory] (
[CategoryId] int NOT NULL IDENTITY(1,1) ,
[Name] nvarchar(200) NOT NULL 
)


GO

-- ----------------------------
-- Records of KyVoteCategory
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyVoteCategory] ON
GO
INSERT INTO [dbo].[KyVoteCategory] ([CategoryId], [Name]) VALUES (N'1', N'常规投票')
GO
GO
SET IDENTITY_INSERT [dbo].[KyVoteCategory] OFF
GO

-- ----------------------------
-- Table structure for KyVoteSubject
-- ----------------------------
DROP TABLE [dbo].[KyVoteSubject]
GO
CREATE TABLE [dbo].[KyVoteSubject] (
[VoteSubjectId] int NOT NULL IDENTITY(1,1) ,
[Subject] nvarchar(200) NOT NULL ,
[StartDate] datetime NULL ,
[EndDate] datetime NULL ,
[RequireLogin] bit NULL ,
[CategoryId] int NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[KyVoteSubject]', RESEED, 3)
GO

-- ----------------------------
-- Records of KyVoteSubject
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyVoteSubject] ON
GO
INSERT INTO [dbo].[KyVoteSubject] ([VoteSubjectId], [Subject], [StartDate], [EndDate], [RequireLogin], [CategoryId]) VALUES (N'1', N'您觉得酷源CMS怎么样', N'2007-11-15 00:00:00.000', N'2016-12-21 00:00:00.000', N'0', N'1')
GO
GO
SET IDENTITY_INSERT [dbo].[KyVoteSubject] OFF
GO

-- ----------------------------
-- Table structure for KyWebMessage
-- ----------------------------
DROP TABLE [dbo].[KyWebMessage]
GO
CREATE TABLE [dbo].[KyWebMessage] (
[WMId] int NOT NULL IDENTITY(1,1) ,
[ReceiverId] int NULL ,
[ReceiverName] nvarchar(50) NULL ,
[SendId] int NULL ,
[SendName] nvarchar(50) NULL ,
[Title] nvarchar(150) NULL ,
[Content] ntext NULL ,
[IsSend] int NULL DEFAULT (0) ,
[IsRead] int NULL DEFAULT (0) ,
[ReceiverDel] int NULL DEFAULT (0) ,
[SendDel] int NULL ,
[AllUser] int NULL DEFAULT (0) ,
[UserGroupId] int NULL DEFAULT (0) ,
[OverdueDate] datetime NULL ,
[AddDate] datetime NULL 
)


GO

-- ----------------------------
-- Records of KyWebMessage
-- ----------------------------
SET IDENTITY_INSERT [dbo].[KyWebMessage] ON
GO
SET IDENTITY_INSERT [dbo].[KyWebMessage] OFF
GO

-- ----------------------------
-- Procedure structure for dt_addtosourcecontrol
-- ----------------------------
DROP PROCEDURE [dbo].[dt_addtosourcecontrol]
GO
create proc [dbo].[dt_addtosourcecontrol]
    @vchSourceSafeINI varchar(255) = '',
    @vchProjectName   varchar(255) ='',
    @vchComment       varchar(255) ='',
    @vchLoginName     varchar(255) ='',
    @vchPassword      varchar(255) =''

as

set nocount on

declare @iReturn int
declare @iObjectId int
select @iObjectId = 0

declare @iStreamObjectId int
select @iStreamObjectId = 0

declare @VSSGUID varchar(100)
select @VSSGUID = 'SQLVersionControl.VCS_SQL'

declare @vchDatabaseName varchar(255)
select @vchDatabaseName = db_name()

declare @iReturnValue int
select @iReturnValue = 0

declare @iPropertyObjectId int
declare @vchParentId varchar(255)

declare @iObjectCount int
select @iObjectCount = 0

    exec @iReturn = master.dbo.sp_OACreate @VSSGUID, @iObjectId OUT
    if @iReturn <> 0 GOTO E_OAError


    /* Create Project in SS */
    exec @iReturn = master.dbo.sp_OAMethod @iObjectId,
											'AddProjectToSourceSafe',
											NULL,
											@vchSourceSafeINI,
											@vchProjectName output,
											@@SERVERNAME,
											@vchDatabaseName,
											@vchLoginName,
											@vchPassword,
											@vchComment


    if @iReturn <> 0 GOTO E_OAError

    /* Set Database Properties */

    begin tran SetProperties

    /* add high level object */

    exec @iPropertyObjectId = dbo.dt_adduserobject_vcs 'VCSProjectID'

    select @vchParentId = CONVERT(varchar(255),@iPropertyObjectId)

    exec dbo.dt_setpropertybyid @iPropertyObjectId, 'VCSProjectID', @vchParentId , NULL
    exec dbo.dt_setpropertybyid @iPropertyObjectId, 'VCSProject' , @vchProjectName , NULL
    exec dbo.dt_setpropertybyid @iPropertyObjectId, 'VCSSourceSafeINI' , @vchSourceSafeINI , NULL
    exec dbo.dt_setpropertybyid @iPropertyObjectId, 'VCSSQLServer', @@SERVERNAME, NULL
    exec dbo.dt_setpropertybyid @iPropertyObjectId, 'VCSSQLDatabase', @vchDatabaseName, NULL

    if @@error <> 0 GOTO E_General_Error

    commit tran SetProperties
    
    select @iObjectCount = 0;

CleanUp:
    select @vchProjectName
    select @iObjectCount
    return

E_General_Error:
    /* this is an all or nothing.  No specific error messages */
    goto CleanUp

E_OAError:
    exec dbo.dt_displayoaerror @iObjectId, @iReturn
    goto CleanUp



GO

-- ----------------------------
-- Procedure structure for dt_addtosourcecontrol_u
-- ----------------------------
DROP PROCEDURE [dbo].[dt_addtosourcecontrol_u]
GO
create proc [dbo].[dt_addtosourcecontrol_u]
    @vchSourceSafeINI nvarchar(255) = '',
    @vchProjectName   nvarchar(255) ='',
    @vchComment       nvarchar(255) ='',
    @vchLoginName     nvarchar(255) ='',
    @vchPassword      nvarchar(255) =''

as
	-- This procedure should no longer be called;  dt_addtosourcecontrol should be called instead.
	-- Calls are forwarded to dt_addtosourcecontrol to maintain backward compatibility
	set nocount on
	exec dbo.dt_addtosourcecontrol 
		@vchSourceSafeINI, 
		@vchProjectName, 
		@vchComment, 
		@vchLoginName, 
		@vchPassword



GO

-- ----------------------------
-- Procedure structure for dt_adduserobject
-- ----------------------------
DROP PROCEDURE [dbo].[dt_adduserobject]
GO
/*
**	Add an object to the dtproperties table
*/
create procedure [dbo].[dt_adduserobject]
as
	set nocount on
	/*
	** Create the user object if it does not exist already
	*/
	begin transaction
		insert dbo.dtproperties (property) VALUES ('DtgSchemaOBJECT')
		update dbo.dtproperties set objectid=@@identity 
			where id=@@identity and property='DtgSchemaOBJECT'
	commit
	return @@identity

GO

-- ----------------------------
-- Procedure structure for dt_adduserobject_vcs
-- ----------------------------
DROP PROCEDURE [dbo].[dt_adduserobject_vcs]
GO
create procedure [dbo].[dt_adduserobject_vcs]
    @vchProperty varchar(64)

as

set nocount on

declare @iReturn int
    /*
    ** Create the user object if it does not exist already
    */
    begin transaction
        select @iReturn = objectid from dbo.dtproperties where property = @vchProperty
        if @iReturn IS NULL
        begin
            insert dbo.dtproperties (property) VALUES (@vchProperty)
            update dbo.dtproperties set objectid=@@identity
                    where id=@@identity and property=@vchProperty
            select @iReturn = @@identity
        end
    commit
    return @iReturn



GO

-- ----------------------------
-- Procedure structure for dt_checkinobject
-- ----------------------------
DROP PROCEDURE [dbo].[dt_checkinobject]
GO
create proc [dbo].[dt_checkinobject]
    @chObjectType  char(4),
    @vchObjectName varchar(255),
    @vchComment    varchar(255)='',
    @vchLoginName  varchar(255),
    @vchPassword   varchar(255)='',
    @iVCSFlags     int = 0,
    @iActionFlag   int = 0,   /* 0 => AddFile, 1 => CheckIn */
    @txStream1     Text = '', /* drop stream   */ /* There is a bug that if items are NULL they do not pass to OLE servers */
    @txStream2     Text = '', /* create stream */
    @txStream3     Text = ''  /* grant stream  */


as

	set nocount on

	declare @iReturn int
	declare @iObjectId int
	select @iObjectId = 0
	declare @iStreamObjectId int

	declare @VSSGUID varchar(100)
	select @VSSGUID = 'SQLVersionControl.VCS_SQL'

	declare @iPropertyObjectId int
	select @iPropertyObjectId  = 0

    select @iPropertyObjectId = (select objectid from dbo.dtproperties where property = 'VCSProjectID')

    declare @vchProjectName   varchar(255)
    declare @vchSourceSafeINI varchar(255)
    declare @vchServerName    varchar(255)
    declare @vchDatabaseName  varchar(255)
    declare @iReturnValue	  int
    declare @pos			  int
    declare @vchProcLinePiece varchar(255)

    
    exec dbo.dt_getpropertiesbyid_vcs @iPropertyObjectId, 'VCSProject',       @vchProjectName   OUT
    exec dbo.dt_getpropertiesbyid_vcs @iPropertyObjectId, 'VCSSourceSafeINI', @vchSourceSafeINI OUT
    exec dbo.dt_getpropertiesbyid_vcs @iPropertyObjectId, 'VCSSQLServer',     @vchServerName    OUT
    exec dbo.dt_getpropertiesbyid_vcs @iPropertyObjectId, 'VCSSQLDatabase',   @vchDatabaseName  OUT

    if @chObjectType = 'PROC'
    begin
        if @iActionFlag = 1
        begin
            /* Procedure Can have up to three streams
            Drop Stream, Create Stream, GRANT stream */

            begin tran compile_all

            /* try to compile the streams */
            exec (@txStream1)
            if @@error <> 0 GOTO E_Compile_Fail

            exec (@txStream2)
            if @@error <> 0 GOTO E_Compile_Fail

            exec (@txStream3)
            if @@error <> 0 GOTO E_Compile_Fail
        end

        exec @iReturn = master.dbo.sp_OACreate @VSSGUID, @iObjectId OUT
        if @iReturn <> 0 GOTO E_OAError

        exec @iReturn = master.dbo.sp_OAGetProperty @iObjectId, 'GetStreamObject', @iStreamObjectId OUT
        if @iReturn <> 0 GOTO E_OAError
        
        if @iActionFlag = 1
        begin
            
            declare @iStreamLength int
			
			select @pos=1
			select @iStreamLength = datalength(@txStream2)
			
			if @iStreamLength > 0
			begin
			
				while @pos < @iStreamLength
				begin
						
					select @vchProcLinePiece = substring(@txStream2, @pos, 255)
					
					exec @iReturn = master.dbo.sp_OAMethod @iStreamObjectId, 'AddStream', @iReturnValue OUT, @vchProcLinePiece
            		if @iReturn <> 0 GOTO E_OAError
            		
					select @pos = @pos + 255
					
				end
            
				exec @iReturn = master.dbo.sp_OAMethod @iObjectId,
														'CheckIn_StoredProcedure',
														NULL,
														@sProjectName = @vchProjectName,
														@sSourceSafeINI = @vchSourceSafeINI,
														@sServerName = @vchServerName,
														@sDatabaseName = @vchDatabaseName,
														@sObjectName = @vchObjectName,
														@sComment = @vchComment,
														@sLoginName = @vchLoginName,
														@sPassword = @vchPassword,
														@iVCSFlags = @iVCSFlags,
														@iActionFlag = @iActionFlag,
														@sStream = ''
                                        
			end
        end
        else
        begin
        
            select colid, text into #ProcLines
            from syscomments
            where id = object_id(@vchObjectName)
            order by colid

            declare @iCurProcLine int
            declare @iProcLines int
            select @iCurProcLine = 1
            select @iProcLines = (select count(*) from #ProcLines)
            while @iCurProcLine <= @iProcLines
            begin
                select @pos = 1
                declare @iCurLineSize int
                select @iCurLineSize = len((select text from #ProcLines where colid = @iCurProcLine))
                while @pos <= @iCurLineSize
                begin                
                    select @vchProcLinePiece = convert(varchar(255),
                        substring((select text from #ProcLines where colid = @iCurProcLine),
                                  @pos, 255 ))
                    exec @iReturn = master.dbo.sp_OAMethod @iStreamObjectId, 'AddStream', @iReturnValue OUT, @vchProcLinePiece
                    if @iReturn <> 0 GOTO E_OAError
                    select @pos = @pos + 255                  
                end
                select @iCurProcLine = @iCurProcLine + 1
            end
            drop table #ProcLines

            exec @iReturn = master.dbo.sp_OAMethod @iObjectId,
													'CheckIn_StoredProcedure',
													NULL,
													@sProjectName = @vchProjectName,
													@sSourceSafeINI = @vchSourceSafeINI,
													@sServerName = @vchServerName,
													@sDatabaseName = @vchDatabaseName,
													@sObjectName = @vchObjectName,
													@sComment = @vchComment,
													@sLoginName = @vchLoginName,
													@sPassword = @vchPassword,
													@iVCSFlags = @iVCSFlags,
													@iActionFlag = @iActionFlag,
													@sStream = ''
        end

        if @iReturn <> 0 GOTO E_OAError

        if @iActionFlag = 1
        begin
            commit tran compile_all
            if @@error <> 0 GOTO E_Compile_Fail
        end

    end

CleanUp:
	return

E_Compile_Fail:
	declare @lerror int
	select @lerror = @@error
	rollback tran compile_all
	RAISERROR (@lerror,16,-1)
	goto CleanUp

E_OAError:
	if @iActionFlag = 1 rollback tran compile_all
	exec dbo.dt_displayoaerror @iObjectId, @iReturn
	goto CleanUp



GO

-- ----------------------------
-- Procedure structure for dt_checkinobject_u
-- ----------------------------
DROP PROCEDURE [dbo].[dt_checkinobject_u]
GO
create proc [dbo].[dt_checkinobject_u]
    @chObjectType  char(4),
    @vchObjectName nvarchar(255),
    @vchComment    nvarchar(255)='',
    @vchLoginName  nvarchar(255),
    @vchPassword   nvarchar(255)='',
    @iVCSFlags     int = 0,
    @iActionFlag   int = 0,   /* 0 => AddFile, 1 => CheckIn */
    @txStream1     text = '',  /* drop stream   */ /* There is a bug that if items are NULL they do not pass to OLE servers */
    @txStream2     text = '',  /* create stream */
    @txStream3     text = ''   /* grant stream  */

as	
	-- This procedure should no longer be called;  dt_checkinobject should be called instead.
	-- Calls are forwarded to dt_checkinobject to maintain backward compatibility.
	set nocount on
	exec dbo.dt_checkinobject
		@chObjectType,
		@vchObjectName,
		@vchComment,
		@vchLoginName,
		@vchPassword,
		@iVCSFlags,
		@iActionFlag,   
		@txStream1,		
		@txStream2,		
		@txStream3		



GO

-- ----------------------------
-- Procedure structure for dt_checkoutobject
-- ----------------------------
DROP PROCEDURE [dbo].[dt_checkoutobject]
GO
create proc [dbo].[dt_checkoutobject]
    @chObjectType  char(4),
    @vchObjectName varchar(255),
    @vchComment    varchar(255),
    @vchLoginName  varchar(255),
    @vchPassword   varchar(255),
    @iVCSFlags     int = 0,
    @iActionFlag   int = 0/* 0 => Checkout, 1 => GetLatest, 2 => UndoCheckOut */

as

	set nocount on

	declare @iReturn int
	declare @iObjectId int
	select @iObjectId =0

	declare @VSSGUID varchar(100)
	select @VSSGUID = 'SQLVersionControl.VCS_SQL'

	declare @iReturnValue int
	select @iReturnValue = 0

	declare @vchTempText varchar(255)

	/* this is for our strings */
	declare @iStreamObjectId int
	select @iStreamObjectId = 0

    declare @iPropertyObjectId int
    select @iPropertyObjectId = (select objectid from dbo.dtproperties where property = 'VCSProjectID')

    declare @vchProjectName   varchar(255)
    declare @vchSourceSafeINI varchar(255)
    declare @vchServerName    varchar(255)
    declare @vchDatabaseName  varchar(255)
    exec dbo.dt_getpropertiesbyid_vcs @iPropertyObjectId, 'VCSProject',       @vchProjectName   OUT
    exec dbo.dt_getpropertiesbyid_vcs @iPropertyObjectId, 'VCSSourceSafeINI', @vchSourceSafeINI OUT
    exec dbo.dt_getpropertiesbyid_vcs @iPropertyObjectId, 'VCSSQLServer',     @vchServerName    OUT
    exec dbo.dt_getpropertiesbyid_vcs @iPropertyObjectId, 'VCSSQLDatabase',   @vchDatabaseName  OUT

    if @chObjectType = 'PROC'
    begin
        /* Procedure Can have up to three streams
           Drop Stream, Create Stream, GRANT stream */

        exec @iReturn = master.dbo.sp_OACreate @VSSGUID, @iObjectId OUT

        if @iReturn <> 0 GOTO E_OAError

        exec @iReturn = master.dbo.sp_OAMethod @iObjectId,
												'CheckOut_StoredProcedure',
												NULL,
												@sProjectName = @vchProjectName,
												@sSourceSafeINI = @vchSourceSafeINI,
												@sObjectName = @vchObjectName,
												@sServerName = @vchServerName,
												@sDatabaseName = @vchDatabaseName,
												@sComment = @vchComment,
												@sLoginName = @vchLoginName,
												@sPassword = @vchPassword,
												@iVCSFlags = @iVCSFlags,
												@iActionFlag = @iActionFlag

        if @iReturn <> 0 GOTO E_OAError


        exec @iReturn = master.dbo.sp_OAGetProperty @iObjectId, 'GetStreamObject', @iStreamObjectId OUT

        if @iReturn <> 0 GOTO E_OAError

        create table #commenttext (id int identity, sourcecode varchar(255))


        select @vchTempText = 'STUB'
        while @vchTempText is not null
        begin
            exec @iReturn = master.dbo.sp_OAMethod @iStreamObjectId, 'GetStream', @iReturnValue OUT, @vchTempText OUT
            if @iReturn <> 0 GOTO E_OAError
            
            if (@vchTempText = '') set @vchTempText = null
            if (@vchTempText is not null) insert into #commenttext (sourcecode) select @vchTempText
        end

        select 'VCS'=sourcecode from #commenttext order by id
        select 'SQL'=text from syscomments where id = object_id(@vchObjectName) order by colid

    end

CleanUp:
    return

E_OAError:
    exec dbo.dt_displayoaerror @iObjectId, @iReturn
    GOTO CleanUp



GO

-- ----------------------------
-- Procedure structure for dt_checkoutobject_u
-- ----------------------------
DROP PROCEDURE [dbo].[dt_checkoutobject_u]
GO
create proc [dbo].[dt_checkoutobject_u]
    @chObjectType  char(4),
    @vchObjectName nvarchar(255),
    @vchComment    nvarchar(255),
    @vchLoginName  nvarchar(255),
    @vchPassword   nvarchar(255),
    @iVCSFlags     int = 0,
    @iActionFlag   int = 0/* 0 => Checkout, 1 => GetLatest, 2 => UndoCheckOut */

as

	-- This procedure should no longer be called;  dt_checkoutobject should be called instead.
	-- Calls are forwarded to dt_checkoutobject to maintain backward compatibility.
	set nocount on
	exec dbo.dt_checkoutobject
		@chObjectType,  
		@vchObjectName, 
		@vchComment,    
		@vchLoginName,  
		@vchPassword,  
		@iVCSFlags,    
		@iActionFlag 



GO

-- ----------------------------
-- Procedure structure for dt_displayoaerror
-- ----------------------------
DROP PROCEDURE [dbo].[dt_displayoaerror]
GO
CREATE PROCEDURE [dbo].[dt_displayoaerror]
    @iObject int,
    @iresult int
as

set nocount on

declare @vchOutput      varchar(255)
declare @hr             int
declare @vchSource      varchar(255)
declare @vchDescription varchar(255)

    exec @hr = master.dbo.sp_OAGetErrorInfo @iObject, @vchSource OUT, @vchDescription OUT

    select @vchOutput = @vchSource + ': ' + @vchDescription
    raiserror (@vchOutput,16,-1)

    return


GO

-- ----------------------------
-- Procedure structure for dt_displayoaerror_u
-- ----------------------------
DROP PROCEDURE [dbo].[dt_displayoaerror_u]
GO
CREATE PROCEDURE [dbo].[dt_displayoaerror_u]
    @iObject int,
    @iresult int
as
	-- This procedure should no longer be called;  dt_displayoaerror should be called instead.
	-- Calls are forwarded to dt_displayoaerror to maintain backward compatibility.
	set nocount on
	exec dbo.dt_displayoaerror
		@iObject,
		@iresult



GO

-- ----------------------------
-- Procedure structure for dt_droppropertiesbyid
-- ----------------------------
DROP PROCEDURE [dbo].[dt_droppropertiesbyid]
GO
/*
**	Drop one or all the associated properties of an object or an attribute 
**
**	dt_dropproperties objid, null or '' -- drop all properties of the object itself
**	dt_dropproperties objid, property -- drop the property
*/
create procedure [dbo].[dt_droppropertiesbyid]
	@id int,
	@property varchar(64)
as
	set nocount on

	if (@property is null) or (@property = '')
		delete from dbo.dtproperties where objectid=@id
	else
		delete from dbo.dtproperties 
			where objectid=@id and property=@property


GO

-- ----------------------------
-- Procedure structure for dt_dropuserobjectbyid
-- ----------------------------
DROP PROCEDURE [dbo].[dt_dropuserobjectbyid]
GO
/*
**	Drop an object from the dbo.dtproperties table
*/
create procedure [dbo].[dt_dropuserobjectbyid]
	@id int
as
	set nocount on
	delete from dbo.dtproperties where objectid=@id

GO

-- ----------------------------
-- Procedure structure for dt_generateansiname
-- ----------------------------
DROP PROCEDURE [dbo].[dt_generateansiname]
GO
/* 
**	Generate an ansi name that is unique in the dtproperties.value column 
*/ 
create procedure [dbo].[dt_generateansiname](@name varchar(255) output) 
as 
	declare @prologue varchar(20) 
	declare @indexstring varchar(20) 
	declare @index integer 
 
	set @prologue = 'MSDT-A-' 
	set @index = 1 
 
	while 1 = 1 
	begin 
		set @indexstring = cast(@index as varchar(20)) 
		set @name = @prologue + @indexstring 
		if not exists (select value from dtproperties where value = @name) 
			break 
		 
		set @index = @index + 1 
 
		if (@index = 10000) 
			goto TooMany 
	end 
 
Leave: 
 
	return 
 
TooMany: 
 
	set @name = 'DIAGRAM' 
	goto Leave 

GO

-- ----------------------------
-- Procedure structure for dt_getobjwithprop
-- ----------------------------
DROP PROCEDURE [dbo].[dt_getobjwithprop]
GO
/*
**	Retrieve the owner object(s) of a given property
*/
create procedure [dbo].[dt_getobjwithprop]
	@property varchar(30),
	@value varchar(255)
as
	set nocount on

	if (@property is null) or (@property = '')
	begin
		raiserror('Must specify a property name.',-1,-1)
		return (1)
	end

	if (@value is null)
		select objectid id from dbo.dtproperties
			where property=@property

	else
		select objectid id from dbo.dtproperties
			where property=@property and value=@value

GO

-- ----------------------------
-- Procedure structure for dt_getobjwithprop_u
-- ----------------------------
DROP PROCEDURE [dbo].[dt_getobjwithprop_u]
GO
/*
**	Retrieve the owner object(s) of a given property
*/
create procedure [dbo].[dt_getobjwithprop_u]
	@property varchar(30),
	@uvalue nvarchar(255)
as
	set nocount on

	if (@property is null) or (@property = '')
	begin
		raiserror('Must specify a property name.',-1,-1)
		return (1)
	end

	if (@uvalue is null)
		select objectid id from dbo.dtproperties
			where property=@property

	else
		select objectid id from dbo.dtproperties
			where property=@property and uvalue=@uvalue

GO

-- ----------------------------
-- Procedure structure for dt_getpropertiesbyid
-- ----------------------------
DROP PROCEDURE [dbo].[dt_getpropertiesbyid]
GO
/*
**	Retrieve properties by id's
**
**	dt_getproperties objid, null or '' -- retrieve all properties of the object itself
**	dt_getproperties objid, property -- retrieve the property specified
*/
create procedure [dbo].[dt_getpropertiesbyid]
	@id int,
	@property varchar(64)
as
	set nocount on

	if (@property is null) or (@property = '')
		select property, version, value, lvalue
			from dbo.dtproperties
			where  @id=objectid
	else
		select property, version, value, lvalue
			from dbo.dtproperties
			where  @id=objectid and @property=property

GO

-- ----------------------------
-- Procedure structure for dt_getpropertiesbyid_u
-- ----------------------------
DROP PROCEDURE [dbo].[dt_getpropertiesbyid_u]
GO
/*
**	Retrieve properties by id's
**
**	dt_getproperties objid, null or '' -- retrieve all properties of the object itself
**	dt_getproperties objid, property -- retrieve the property specified
*/
create procedure [dbo].[dt_getpropertiesbyid_u]
	@id int,
	@property varchar(64)
as
	set nocount on

	if (@property is null) or (@property = '')
		select property, version, uvalue, lvalue
			from dbo.dtproperties
			where  @id=objectid
	else
		select property, version, uvalue, lvalue
			from dbo.dtproperties
			where  @id=objectid and @property=property

GO

-- ----------------------------
-- Procedure structure for dt_getpropertiesbyid_vcs
-- ----------------------------
DROP PROCEDURE [dbo].[dt_getpropertiesbyid_vcs]
GO
create procedure [dbo].[dt_getpropertiesbyid_vcs]
    @id       int,
    @property varchar(64),
    @value    varchar(255) = NULL OUT

as

    set nocount on

    select @value = (
        select value
                from dbo.dtproperties
                where @id=objectid and @property=property
                )


GO

-- ----------------------------
-- Procedure structure for dt_getpropertiesbyid_vcs_u
-- ----------------------------
DROP PROCEDURE [dbo].[dt_getpropertiesbyid_vcs_u]
GO
create procedure [dbo].[dt_getpropertiesbyid_vcs_u]
    @id       int,
    @property varchar(64),
    @value    nvarchar(255) = NULL OUT

as

    -- This procedure should no longer be called;  dt_getpropertiesbyid_vcsshould be called instead.
	-- Calls are forwarded to dt_getpropertiesbyid_vcs to maintain backward compatibility.
	set nocount on
    exec dbo.dt_getpropertiesbyid_vcs
		@id,
		@property,
		@value output


GO

-- ----------------------------
-- Procedure structure for dt_isundersourcecontrol
-- ----------------------------
DROP PROCEDURE [dbo].[dt_isundersourcecontrol]
GO
create proc [dbo].[dt_isundersourcecontrol]
    @vchLoginName varchar(255) = '',
    @vchPassword  varchar(255) = '',
    @iWhoToo      int = 0 /* 0 => Just check project; 1 => get list of objs */

as

	set nocount on

	declare @iReturn int
	declare @iObjectId int
	select @iObjectId = 0

	declare @VSSGUID varchar(100)
	select @VSSGUID = 'SQLVersionControl.VCS_SQL'

	declare @iReturnValue int
	select @iReturnValue = 0

	declare @iStreamObjectId int
	select @iStreamObjectId   = 0

	declare @vchTempText varchar(255)

    declare @iPropertyObjectId int
    select @iPropertyObjectId = (select objectid from dbo.dtproperties where property = 'VCSProjectID')

    declare @vchProjectName   varchar(255)
    declare @vchSourceSafeINI varchar(255)
    declare @vchServerName    varchar(255)
    declare @vchDatabaseName  varchar(255)
    exec dbo.dt_getpropertiesbyid_vcs @iPropertyObjectId, 'VCSProject',       @vchProjectName   OUT
    exec dbo.dt_getpropertiesbyid_vcs @iPropertyObjectId, 'VCSSourceSafeINI', @vchSourceSafeINI OUT
    exec dbo.dt_getpropertiesbyid_vcs @iPropertyObjectId, 'VCSSQLServer',     @vchServerName    OUT
    exec dbo.dt_getpropertiesbyid_vcs @iPropertyObjectId, 'VCSSQLDatabase',   @vchDatabaseName  OUT

    if (@vchProjectName = '')	set @vchProjectName		= null
    if (@vchSourceSafeINI = '') set @vchSourceSafeINI	= null
    if (@vchServerName = '')	set @vchServerName		= null
    if (@vchDatabaseName = '')	set @vchDatabaseName	= null
    
    if (@vchProjectName is null) or (@vchSourceSafeINI is null) or (@vchServerName is null) or (@vchDatabaseName is null)
    begin
        RAISERROR('Not Under Source Control',16,-1)
        return
    end

    if @iWhoToo = 1
    begin

        /* Get List of Procs in the project */
        exec @iReturn = master.dbo.sp_OACreate @VSSGUID, @iObjectId OUT
        if @iReturn <> 0 GOTO E_OAError

        exec @iReturn = master.dbo.sp_OAMethod @iObjectId,
												'GetListOfObjects',
												NULL,
												@vchProjectName,
												@vchSourceSafeINI,
												@vchServerName,
												@vchDatabaseName,
												@vchLoginName,
												@vchPassword

        if @iReturn <> 0 GOTO E_OAError

        exec @iReturn = master.dbo.sp_OAGetProperty @iObjectId, 'GetStreamObject', @iStreamObjectId OUT

        if @iReturn <> 0 GOTO E_OAError

        create table #ObjectList (id int identity, vchObjectlist varchar(255))

        select @vchTempText = 'STUB'
        while @vchTempText is not null
        begin
            exec @iReturn = master.dbo.sp_OAMethod @iStreamObjectId, 'GetStream', @iReturnValue OUT, @vchTempText OUT
            if @iReturn <> 0 GOTO E_OAError
            
            if (@vchTempText = '') set @vchTempText = null
            if (@vchTempText is not null) insert into #ObjectList (vchObjectlist ) select @vchTempText
        end

        select vchObjectlist from #ObjectList order by id
    end

CleanUp:
    return

E_OAError:
    exec dbo.dt_displayoaerror @iObjectId, @iReturn
    goto CleanUp



GO

-- ----------------------------
-- Procedure structure for dt_isundersourcecontrol_u
-- ----------------------------
DROP PROCEDURE [dbo].[dt_isundersourcecontrol_u]
GO
create proc [dbo].[dt_isundersourcecontrol_u]
    @vchLoginName nvarchar(255) = '',
    @vchPassword  nvarchar(255) = '',
    @iWhoToo      int = 0 /* 0 => Just check project; 1 => get list of objs */

as
	-- This procedure should no longer be called;  dt_isundersourcecontrol should be called instead.
	-- Calls are forwarded to dt_isundersourcecontrol to maintain backward compatibility.
	set nocount on
	exec dbo.dt_isundersourcecontrol
		@vchLoginName,
		@vchPassword,
		@iWhoToo 



GO

-- ----------------------------
-- Procedure structure for dt_removefromsourcecontrol
-- ----------------------------
DROP PROCEDURE [dbo].[dt_removefromsourcecontrol]
GO
create procedure [dbo].[dt_removefromsourcecontrol]

as

    set nocount on

    declare @iPropertyObjectId int
    select @iPropertyObjectId = (select objectid from dbo.dtproperties where property = 'VCSProjectID')

    exec dbo.dt_droppropertiesbyid @iPropertyObjectId, null

    /* -1 is returned by dt_droppopertiesbyid */
    if @@error <> 0 and @@error <> -1 return 1

    return 0



GO

-- ----------------------------
-- Procedure structure for dt_setpropertybyid
-- ----------------------------
DROP PROCEDURE [dbo].[dt_setpropertybyid]
GO
/*
**	If the property already exists, reset the value; otherwise add property
**		id -- the id in sysobjects of the object
**		property -- the name of the property
**		value -- the text value of the property
**		lvalue -- the binary value of the property (image)
*/
create procedure [dbo].[dt_setpropertybyid]
	@id int,
	@property varchar(64),
	@value varchar(255),
	@lvalue image
as
	set nocount on
	declare @uvalue nvarchar(255) 
	set @uvalue = convert(nvarchar(255), @value) 
	if exists (select * from dbo.dtproperties 
			where objectid=@id and property=@property)
	begin
		--
		-- bump the version count for this row as we update it
		--
		update dbo.dtproperties set value=@value, uvalue=@uvalue, lvalue=@lvalue, version=version+1
			where objectid=@id and property=@property
	end
	else
	begin
		--
		-- version count is auto-set to 0 on initial insert
		--
		insert dbo.dtproperties (property, objectid, value, uvalue, lvalue)
			values (@property, @id, @value, @uvalue, @lvalue)
	end


GO

-- ----------------------------
-- Procedure structure for dt_setpropertybyid_u
-- ----------------------------
DROP PROCEDURE [dbo].[dt_setpropertybyid_u]
GO
/*
**	If the property already exists, reset the value; otherwise add property
**		id -- the id in sysobjects of the object
**		property -- the name of the property
**		uvalue -- the text value of the property
**		lvalue -- the binary value of the property (image)
*/
create procedure [dbo].[dt_setpropertybyid_u]
	@id int,
	@property varchar(64),
	@uvalue nvarchar(255),
	@lvalue image
as
	set nocount on
	-- 
	-- If we are writing the name property, find the ansi equivalent. 
	-- If there is no lossless translation, generate an ansi name. 
	-- 
	declare @avalue varchar(255) 
	set @avalue = null 
	if (@uvalue is not null) 
	begin 
		if (convert(nvarchar(255), convert(varchar(255), @uvalue)) = @uvalue) 
		begin 
			set @avalue = convert(varchar(255), @uvalue) 
		end 
		else 
		begin 
			if 'DtgSchemaNAME' = @property 
			begin 
				exec dbo.dt_generateansiname @avalue output 
			end 
		end 
	end 
	if exists (select * from dbo.dtproperties 
			where objectid=@id and property=@property)
	begin
		--
		-- bump the version count for this row as we update it
		--
		update dbo.dtproperties set value=@avalue, uvalue=@uvalue, lvalue=@lvalue, version=version+1
			where objectid=@id and property=@property
	end
	else
	begin
		--
		-- version count is auto-set to 0 on initial insert
		--
		insert dbo.dtproperties (property, objectid, value, uvalue, lvalue)
			values (@property, @id, @avalue, @uvalue, @lvalue)
	end

GO

-- ----------------------------
-- Procedure structure for dt_validateloginparams
-- ----------------------------
DROP PROCEDURE [dbo].[dt_validateloginparams]
GO
create proc [dbo].[dt_validateloginparams]
    @vchLoginName  varchar(255),
    @vchPassword   varchar(255)
as

set nocount on

declare @iReturn int
declare @iObjectId int
select @iObjectId =0

declare @VSSGUID varchar(100)
select @VSSGUID = 'SQLVersionControl.VCS_SQL'

    declare @iPropertyObjectId int
    select @iPropertyObjectId = (select objectid from dbo.dtproperties where property = 'VCSProjectID')

    declare @vchSourceSafeINI varchar(255)
    exec dbo.dt_getpropertiesbyid_vcs @iPropertyObjectId, 'VCSSourceSafeINI', @vchSourceSafeINI OUT

    exec @iReturn = master.dbo.sp_OACreate @VSSGUID, @iObjectId OUT
    if @iReturn <> 0 GOTO E_OAError

    exec @iReturn = master.dbo.sp_OAMethod @iObjectId,
											'ValidateLoginParams',
											NULL,
											@sSourceSafeINI = @vchSourceSafeINI,
											@sLoginName = @vchLoginName,
											@sPassword = @vchPassword
    if @iReturn <> 0 GOTO E_OAError

CleanUp:
    return

E_OAError:
    exec dbo.dt_displayoaerror @iObjectId, @iReturn
    GOTO CleanUp



GO

-- ----------------------------
-- Procedure structure for dt_validateloginparams_u
-- ----------------------------
DROP PROCEDURE [dbo].[dt_validateloginparams_u]
GO
create proc [dbo].[dt_validateloginparams_u]
    @vchLoginName  nvarchar(255),
    @vchPassword   nvarchar(255)
as

	-- This procedure should no longer be called;  dt_validateloginparams should be called instead.
	-- Calls are forwarded to dt_validateloginparams to maintain backward compatibility.
	set nocount on
	exec dbo.dt_validateloginparams
		@vchLoginName,
		@vchPassword 



GO

-- ----------------------------
-- Procedure structure for dt_vcsenabled
-- ----------------------------
DROP PROCEDURE [dbo].[dt_vcsenabled]
GO
create proc [dbo].[dt_vcsenabled]

as

set nocount on

declare @iObjectId int
select @iObjectId = 0

declare @VSSGUID varchar(100)
select @VSSGUID = 'SQLVersionControl.VCS_SQL'

    declare @iReturn int
    exec @iReturn = master.dbo.sp_OACreate @VSSGUID, @iObjectId OUT
    if @iReturn <> 0 raiserror('', 16, -1) /* Can't Load Helper DLLC */



GO

-- ----------------------------
-- Procedure structure for dt_verstamp006
-- ----------------------------
DROP PROCEDURE [dbo].[dt_verstamp006]
GO
/*
**	This procedure returns the version number of the stored
**    procedures used by legacy versions of the Microsoft
**	Visual Database Tools.  Version is 7.0.00.
*/
create procedure [dbo].[dt_verstamp006]
as
	select 7000

GO

-- ----------------------------
-- Procedure structure for dt_verstamp007
-- ----------------------------
DROP PROCEDURE [dbo].[dt_verstamp007]
GO
/*
**	This procedure returns the version number of the stored
**    procedures used by the the Microsoft Visual Database Tools.
**	Version is 7.0.05.
*/
create procedure [dbo].[dt_verstamp007]
as
	select 7005

GO

-- ----------------------------
-- Procedure structure for dt_whocheckedout
-- ----------------------------
DROP PROCEDURE [dbo].[dt_whocheckedout]
GO
create proc [dbo].[dt_whocheckedout]
        @chObjectType  char(4),
        @vchObjectName varchar(255),
        @vchLoginName  varchar(255),
        @vchPassword   varchar(255)

as

set nocount on

declare @iReturn int
declare @iObjectId int
select @iObjectId =0

declare @VSSGUID varchar(100)
select @VSSGUID = 'SQLVersionControl.VCS_SQL'

    declare @iPropertyObjectId int

    select @iPropertyObjectId = (select objectid from dbo.dtproperties where property = 'VCSProjectID')

    declare @vchProjectName   varchar(255)
    declare @vchSourceSafeINI varchar(255)
    declare @vchServerName    varchar(255)
    declare @vchDatabaseName  varchar(255)
    exec dbo.dt_getpropertiesbyid_vcs @iPropertyObjectId, 'VCSProject',       @vchProjectName   OUT
    exec dbo.dt_getpropertiesbyid_vcs @iPropertyObjectId, 'VCSSourceSafeINI', @vchSourceSafeINI OUT
    exec dbo.dt_getpropertiesbyid_vcs @iPropertyObjectId, 'VCSSQLServer',     @vchServerName    OUT
    exec dbo.dt_getpropertiesbyid_vcs @iPropertyObjectId, 'VCSSQLDatabase',   @vchDatabaseName  OUT

    if @chObjectType = 'PROC'
    begin
        exec @iReturn = master.dbo.sp_OACreate @VSSGUID, @iObjectId OUT

        if @iReturn <> 0 GOTO E_OAError

        declare @vchReturnValue varchar(255)
        select @vchReturnValue = ''

        exec @iReturn = master.dbo.sp_OAMethod @iObjectId,
												'WhoCheckedOut',
												@vchReturnValue OUT,
												@sProjectName = @vchProjectName,
												@sSourceSafeINI = @vchSourceSafeINI,
												@sObjectName = @vchObjectName,
												@sServerName = @vchServerName,
												@sDatabaseName = @vchDatabaseName,
												@sLoginName = @vchLoginName,
												@sPassword = @vchPassword

        if @iReturn <> 0 GOTO E_OAError

        select @vchReturnValue

    end

CleanUp:
    return

E_OAError:
    exec dbo.dt_displayoaerror @iObjectId, @iReturn
    GOTO CleanUp



GO

-- ----------------------------
-- Procedure structure for dt_whocheckedout_u
-- ----------------------------
DROP PROCEDURE [dbo].[dt_whocheckedout_u]
GO
create proc [dbo].[dt_whocheckedout_u]
        @chObjectType  char(4),
        @vchObjectName nvarchar(255),
        @vchLoginName  nvarchar(255),
        @vchPassword   nvarchar(255)

as

	-- This procedure should no longer be called;  dt_whocheckedout should be called instead.
	-- Calls are forwarded to dt_whocheckedout to maintain backward compatibility.
	set nocount on
	exec dbo.dt_whocheckedout
		@chObjectType, 
		@vchObjectName,
		@vchLoginName, 
		@vchPassword  



GO

-- ----------------------------
-- Procedure structure for Up_Ad_Get
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Ad_Get]
GO
CREATE PROCEDURE [dbo].[Up_Ad_Get]
@Type int,
@AdId int,
@PageSize int=20,
@PageIndex int=1,
@WhereString nvarchar(500)
AS
	declare @SqlStr nvarchar(2000)
	declare @Filter nvarchar(2000)
	if(@WhereString ='')
	begin
	 set @WhereString=' where '
	 set @Filter=''
	end 
else
	begin
		set @Filter=' where '+@WhereString
		set @WhereString=' where '+@WhereString+' and '		
	end
	
if(@Type=1)--获取单条记录
begin
	select * from KyAd where AdId=@AdId
end

if(@Type=2)--获取列表
begin
	if(@PageIndex=1)
		begin
					Set @SqlStr = N'Select Top '+Convert(Nvarchar(10),@PageSize)+' KyAd.*,KyAdCategory.CategoryName FROM KyAd left join KyAdCategory on KyAd.CategoryId=KyAdCategory.AdCategoryId '+@Filter +' Order By AdId Desc'
		end
	else
		begin
				Set @SqlStr = N'Select Top '+Convert(Nvarchar(10),@PageSize)+' KyAd.*,KyAdCategory.CategoryName FROM KyAd  left join KyAdCategory on KyAd.CategoryId=KyAdCategory.AdCategoryId '+@WhereString+' AdId<(Select Min(AdId) From(Select Top '+Convert(Nvarchar(10),(@PageIndex-1)*@PageSize)+' * from KyAd  '+@Filter+' Order By AdId Desc)O) order By AdId Desc'
		end	
		
	Execute Sp_ExecuteSql @SqlStr
	
	Set @SqlStr = 'select count(*) from KyAd '+@Filter
	
	Execute Sp_ExecuteSql @SqlStr
end
GO

-- ----------------------------
-- Procedure structure for Up_Ad_Set
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Ad_Set]
GO
CREATE PROCEDURE [dbo].[Up_Ad_Set]
@Type int,
@AdId int,
@CategoryId varchar(100),
@AdName nvarchar(100),
@AdType int,
@Content nvarchar(2000),
@EndTime datetime,
@Weight int,
@HitCount int
AS
	
if(@Type=1)--添加
begin
	INSERT INTO KyAd(
	[CategoryId],[AdName],[AdType],[Content],[EndTime],[Weight],[HitCount]
	)VALUES(
	@CategoryId,@AdName,@AdType,@Content,@EndTime,@Weight,@HitCount
	)
end

if(@Type=2)--修改
begin
	UPDATE KyAd SET 
	[CategoryId] = @CategoryId,[AdName] = @AdName,[AdType] = @AdType,[Content] = @Content,[EndTime] = @EndTime,[Weight] = @Weight,[HitCount] = @HitCount
	WHERE [AdId] = @AdId
end

if(@Type=3)--删除
begin
	DELETE KyAd
	 WHERE [AdId] = @AdId
end
GO

-- ----------------------------
-- Procedure structure for Up_AdCategory_Get
-- ----------------------------
DROP PROCEDURE [dbo].[Up_AdCategory_Get]
GO
CREATE PROCEDURE [dbo].[Up_AdCategory_Get]
@Type int,
@AdCategoryId int,
@PageSize int=20,
@PageIndex int=1,
@WhereString nvarchar(500)
AS
	declare @SqlStr nvarchar(2000)
	declare @Filter nvarchar(2000)
	if(@WhereString ='')
	begin
	 set @WhereString=' where '
	 set @Filter=''
	end 
else
	begin
		set @Filter=' where '+@WhereString
		set @WhereString=' where '+@WhereString+' and '		
	end
	
if(@Type=1)--获取单条记录
begin
	select * from KyAdCategory where AdCategoryId=@AdCategoryId
end

if(@Type=2)--获取列表
begin
	if(@PageIndex=1)
		begin
					Set @SqlStr = N'Select Top '+Convert(Nvarchar(10),@PageSize)+' * FROM KyAdCategory '+@Filter +' Order By AdCategoryId Desc'
		end
	else
		begin
				Set @SqlStr = N'Select Top '+Convert(Nvarchar(10),@PageSize)+' * FROM KyAdCategory '+@WhereString+' AdCategoryId<(Select Min(AdCategoryId) From(Select Top '+Convert(Nvarchar(10),(@PageIndex-1)*@PageSize)+' * from KyAdCategory  '+@Filter+' Order By AdCategoryId Desc)O) order By AdCategoryId Desc'
		end	
		
		print @SqlStr
		
	Execute Sp_ExecuteSql @SqlStr
	
	Set @SqlStr = 'select count(*) from KyAdCategory '+@Filter
	
	Execute Sp_ExecuteSql @SqlStr
end
GO

-- ----------------------------
-- Procedure structure for Up_AdCategory_Set
-- ----------------------------
DROP PROCEDURE [dbo].[Up_AdCategory_Set]
GO
CREATE PROCEDURE [dbo].[Up_AdCategory_Set]
@Type int,
@AdCategoryId int,
@CategoryName nvarchar(100),
@IsDisabled int,
@WidthHeigth varchar(12),
@DisplayType int,
@Description nvarchar(100)

as

if(@Type=1)--添加
begin
	INSERT INTO KyAdCategory(
	[CategoryName],[IsDisabled],[WidthHeigth],[DisplayType],[Description]
	)VALUES(
	@CategoryName,@IsDisabled,@WidthHeigth,@DisplayType,@Description
	)
end

if(@Type=2)--修改
begin
	UPDATE KyAdCategory SET 
	[CategoryName] = @CategoryName,[IsDisabled] = @IsDisabled,[WidthHeigth] = @WidthHeigth,[DisplayType] = @DisplayType,
	[Description] = @Description
	WHERE [AdCategoryId] = @AdCategoryId
end

if(@Type=3)--删除
begin
	
	DELETE KyAdCategory
	 WHERE [AdCategoryId] = @AdCategoryId
end

GO

-- ----------------------------
-- Procedure structure for Up_Admin_Add
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Admin_Add]
GO

CREATE PROCEDURE [dbo].[Up_Admin_Add]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
	@LogName nvarchar(20),
	@UserName nvarchar(20),
	@Password varchar(200),
	@GroupId int,
	@GroupName nvarchar(50),
	@AllowMultiLogin bit, 
	@output bit output
AS
	/* SET NOCOUNT ON */ 
	If Exists(select * from  KyAdmin where LoginName = @LogName or UserName = @UserName)
	set @output=0
else
begin
	insert into KyAdmin(LoginName,UserName,Password,GroupId,GroupName,AllowMultiLogin) values(@LogName,@UserName,@Password, @GroupId,@GroupName,@AllowMultiLogin)
	set @output=1
end
	RETURN


GO

-- ----------------------------
-- Procedure structure for Up_Admin_Delete
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Admin_Delete]
GO

CREATE  proc [dbo].[Up_Admin_Delete]
	@UserId int
as
delete dbo.KyAdmin
where UserId = @UserId

GO

-- ----------------------------
-- Procedure structure for Up_Admin_GetAdminCount
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Admin_GetAdminCount]
GO

CREATE proc [dbo].[Up_Admin_GetAdminCount]
	@GroupId int
as
select count(*)
from KyAdmin
where GroupId = @GroupId

GO

-- ----------------------------
-- Procedure structure for Up_Admin_GetAdminList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Admin_GetAdminList]
GO

CREATE proc [dbo].[Up_Admin_GetAdminList]
as 
Select UserId,UserName,GroupName,AllowMultiLogin,LastLoginIP,LastLoginTime,LoginTime
From  KyAdmin

GO

-- ----------------------------
-- Procedure structure for Up_Admin_GetAdminListByGroupId
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Admin_GetAdminListByGroupId]
GO

CREATE proc [dbo].[Up_Admin_GetAdminListByGroupId]
	@GroupId int
as
select UserId,UserName,GroupName,AllowMultiLogin,LastLoginIP,LastLoginTime,LoginTime
from KyAdmin
where GroupId = @GroupId

GO

-- ----------------------------
-- Procedure structure for Up_Admin_GetInfoById
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Admin_GetInfoById]
GO

Create Procedure [dbo].[Up_Admin_GetInfoById]
@UserId Int
As
	
	SELECT 
	[UserId],[LoginName],[UserName],[Password],[LastLoginIP],[LastLoginTime],[LastLogoutTime],[LoginTime],[AllowMultiLogin],[CheckCount],[AddCount],[RejectCount],[GroupId],[GroupName],[RandNumber]
	 FROM 
	KyAdmin
	WHERE UserId=@UserId


GO

-- ----------------------------
-- Procedure structure for Up_Admin_GetInfoByNameAndPass
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Admin_GetInfoByNameAndPass]
GO

CREATE Procedure [dbo].[Up_Admin_GetInfoByNameAndPass]
@LoginName Nvarchar(20),
@Password varchar(200)
 AS 
	SELECT 
	[UserId],[LoginName],[UserName],[Password],[LastLoginIP],[LastLoginTime],[LastLogoutTime],[LoginTime],[AllowMultiLogin],[CheckCount],[AddCount],[RejectCount],[GroupId],[GroupName],[RandNumber]
	 FROM 
	KyAdmin
	WHERE LoginName=@LoginName And [Password] = @Password

GO

-- ----------------------------
-- Procedure structure for Up_Admin_Update
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Admin_Update]
GO

CREATE proc [dbo].[Up_Admin_Update]
	@UserId int,
	@Password varchar(200),
	@AllowMultiLogin bit,
	@GroupId int,
	@GroupName nvarchar(50),
	@UserName nvarchar(50)
as
update KyAdmin SET  [Password] = (case @Password when '' then [Password] else @Password end),AllowMultiLogin = @AllowMultiLogin,GroupId = @GroupId,GroupName = @GroupName,UserName=@UserName where UserId = @UserId

GO

-- ----------------------------
-- Procedure structure for Up_Admin_UpdateState
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Admin_UpdateState]
GO

Create Procedure [dbo].[Up_Admin_UpdateState]
@LastLoginIP Varchar(11),
@LastLoginTime DateTime,
@RandNumber Varchar(30),
@LoginName Varchar(50)
As
Update KyAdmin
Set LastLoginIP=@LastLoginIp,LastLoginTime=@LastLoginTime,LoginTime=LoginTime+1,RandNumber=@RandNumber
Where LoginName=@LoginName



GO

-- ----------------------------
-- Procedure structure for Up_Anomaly_Add
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Anomaly_Add]
GO
CREATE PROCEDURE [dbo].[Up_Anomaly_Add]
@InfoId int ,
@ChId int ,
@ColName nvarchar(100) ,
@Title varchar(200) 
 AS 
	INSERT INTO KyAnomaly(
	[InfoId],[ChId],[ColName],[Title]
	)VALUES(
	@InfoId,@ChId,@ColName,@Title
	)
GO

-- ----------------------------
-- Procedure structure for Up_Anomaly_CheckHas
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Anomaly_CheckHas]
GO
CREATE PROCEDURE [dbo].[Up_Anomaly_CheckHas] 
@chid int,
@infoid int
AS
Select [Id] From KyAnomaly Where Chid=@chid and InfoId=@infoid
GO

-- ----------------------------
-- Procedure structure for UP_Anomaly_Delete
-- ----------------------------
DROP PROCEDURE [dbo].[UP_Anomaly_Delete]
GO
CREATE PROCEDURE [dbo].[UP_Anomaly_Delete]
@Id int
 AS 
	DELETE KyAnomaly
	 WHERE [Id] = @Id


GO

-- ----------------------------
-- Procedure structure for Up_Anomaly_GetList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Anomaly_GetList]
GO
CREATE proc [dbo].[Up_Anomaly_GetList]
@chid int,
@pageindex int,
@pagesize int,
@recordcount int output
as
declare @sqlstr nvarchar(2000)
if(@pageindex=1)
	set @sqlstr=N'select top '+convert(nvarchar(15),@pagesize)+' * from KyAnomaly where [chid]= '+convert(nvarchar(15),@chid)+' order by id desc'
else
	set @sqlstr=N'select top '+convert(nvarchar(15),@pagesize)+' * from KyAnomaly where [chid]= '+convert(nvarchar(15),@chid)+' and id<(select min(id) from (select top '+convert(nvarchar(15),(@pageindex-1)*@pagesize)+' id from KyAnomaly where [chid]='+convert(nvarchar(15),@chid)+' order by id desc)o) order by id desc'
Execute Sp_executeSql @sqlstr
set @recordcount =(select count(chid) from KyAnomaly where chid=@chid)

GO

-- ----------------------------
-- Procedure structure for Up_Article_GetExpireArticleCount
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Article_GetExpireArticleCount]
GO
create proc [dbo].[Up_Article_GetExpireArticleCount]
@chid int,  
@colid int  
as
if @colid=0  
  select count([id]) from [kyarticle] i join [kycolumn] co on i.colid=co.colid where co.chid=@chid and expiretime<getdate()  
else
  select count([id]) from [kyarticle] i join [kycolumn] co on i.colid=co.colid where co.chid=@chid and i.colid=@colid and expiretime<getdate()  

  


GO

-- ----------------------------
-- Procedure structure for Up_Article_MoveExpireArticle
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Article_MoveExpireArticle]
GO
CREATE proc [dbo].[Up_Article_MoveExpireArticle]
@chid int,
@colid int
as
if(@colid=0)
begin

	insert into kyexpirearticle([Id],ColId,Title,TitleColor,TitleFontType,TitleType,TitleImgPath,UId,UName,UserType,AdminUId,AdminUName,Status,HitCount,AddTime,UpdateTime,TemplatePath,
PageType,IsCreated,UserCateId,PointCount,ChargeType,ChargeHourCount,ChargeViewCount,IsOpened,GroupIdStr,IsDeleted,IsRecommend,IsTop,
IsFocus,IsSideShow,TagIdStr,TagNameStr,SpecialIdStr,LongTitle,Content,ShortContent,OuterUrl,Author,Source,IsHeader,HeaderFont,HeaderImgPath,
StarLevel,IsShowCommentLink,IsIrregular,IrregularId,ViewUName,ViewUName2,ViewEndTime,IsAllowComment,ExpireTime)
select i.[Id],i.ColId,i.Title,i.TitleColor,i.TitleFontType,i.TitleType,i.TitleImgPath,i.UId,i.UName,i.UserType,i.AdminUId,i.AdminUName,i.Status,i.HitCount,i.AddTime,i.UpdateTime,
i.TemplatePath,i.PageType,i.IsCreated,i.UserCateId,i.PointCount,i.ChargeType,i.ChargeHourCount,i.ChargeViewCount,i.IsOpened,i.GroupIdStr,i.IsDeleted,i.IsRecommend,i.IsTop,
i.IsFocus,i.IsSideShow,i.TagIdStr,i.TagNameStr,i.SpecialIdStr,i.LongTitle,i.Content,i.ShortContent,i.OuterUrl,i.Author,i.Source,i.IsHeader,i.HeaderFont,i.HeaderImgPath,
i.StarLevel,i.IsShowCommentLink,i.IsIrregular,i.IrregularId,i.ViewUName,i.ViewUName2,i.ViewEndTime,i.IsAllowComment,i.ExpireTime 
from kyarticle i join kycolumn co on i.colid=co.colid where co.chid=@chid and i.expiretime<getdate()
delete i from kyarticle i join kycolumn co on i.colid=co.colid where co.chid=@chid and i.expiretime<getdate();

	delete i from kyarticle i join kycolumn co on i.colid=co.colid where co.chid=@chid and i.expiretime<getdate();
end
else
begin
	insert into kyexpirearticle([Id],ColId,Title,TitleColor,TitleFontType,TitleType,TitleImgPath,UId,UName,UserType,AdminUId,AdminUName,Status,HitCount,AddTime,UpdateTime,TemplatePath,
PageType,IsCreated,UserCateId,PointCount,ChargeType,ChargeHourCount,ChargeViewCount,IsOpened,GroupIdStr,IsDeleted,IsRecommend,IsTop,
IsFocus,IsSideShow,TagIdStr,TagNameStr,SpecialIdStr,LongTitle,Content,ShortContent,OuterUrl,Author,Source,IsHeader,HeaderFont,HeaderImgPath,
StarLevel,IsShowCommentLink,IsIrregular,IrregularId,ViewUName,ViewUName2,ViewEndTime,IsAllowComment,ExpireTime)
select i.[Id],i.ColId,i.Title,i.TitleColor,i.TitleFontType,i.TitleType,i.TitleImgPath,i.UId,i.UName,i.UserType,i.AdminUId,i.AdminUName,i.Status,i.HitCount,i.AddTime,i.UpdateTime,
i.TemplatePath,i.PageType,i.IsCreated,i.UserCateId,i.PointCount,i.ChargeType,i.ChargeHourCount,i.ChargeViewCount,i.IsOpened,i.GroupIdStr,i.IsDeleted,i.IsRecommend,i.IsTop,
i.IsFocus,i.IsSideShow,i.TagIdStr,i.TagNameStr,i.SpecialIdStr,i.LongTitle,i.Content,i.ShortContent,i.OuterUrl,i.Author,i.Source,i.IsHeader,i.HeaderFont,i.HeaderImgPath,
i.StarLevel,i.IsShowCommentLink,i.IsIrregular,i.IrregularId,i.ViewUName,i.ViewUName2,i.ViewEndTime,i.IsAllowComment,i.ExpireTime 
from kyarticle i join kycolumn co on i.colid=co.colid where co.chid=@chid and i.colid=@colid and i.expiretime<getdate()
delete i from kyarticle i join kycolumn co on i.colid=co.colid where co.chid=@chid and i.colid=@colid and i.expiretime<getdate();
end


GO

-- ----------------------------
-- Procedure structure for Up_Article_Set
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Article_Set]
GO
CREATE Procedure [dbo].[Up_Article_Set]
@Id int output,
@ColId int ,
@Title nvarchar(200) ,
@TitleColor nvarchar(6) ='' ,
@TitleFontType int ,
@TitleType int ,
@TitleImgPath varchar(255)='' ,
@UId int ,
@UName nvarchar(20) ='' ,
@UserType int ,
@AdminUId int ,
@AdminUName nvarchar(20)='' ,
@Status int ,
@HitCount int ,
@AddTime datetime ,
@UpdateTime datetime ,
@TemplatePath varchar(255)='' ,
@PageType int ,
@IsCreated bit ,
@UserCateId int ,
@PointCount int ,
@ChargeType int ,
@ChargeHourCount int ,
@ChargeViewCount int ,
@IsOpened int ,
@GroupIdStr varchar(200)='' ,
@IsDeleted bit ,
@IsRecommend bit ,
@IsTop bit ,
@IsFocus bit ,
@IsSideShow bit ,
@TagIdStr varchar(300) ='' ,
@TagNameStr nvarchar(300) ='' ,
@SpecialIdStr varchar(200)='' ,
@LongTitle nvarchar(500) ='' ,
@Content ntext='' ,
@ShortContent nvarchar(200) ='' ,
@OuterUrl varchar(255)='' ,
@Author nvarchar(50) ='' ,
@Source nvarchar(50) ='' ,
@IsHeader bit ,
@HeaderFont nvarchar(100) ='' ,
@HeaderImgPath varchar(255) ='' ,
@StarLevel nvarchar(20) ='' ,
@IsShowCommentLink bit ,
@IsIrregular bit ,
@IrregularId int ,
@ViewUName ntext ='' ,
@ViewUName2 ntext='' ,
@ViewEndTime nvarchar(20) ='' ,
@IsAllowComment bit ,
@ExpireTime datetime 

AS
If(@Id=0)
Begin
	INSERT INTO KyArticle(
	[ColId],[Title],[TitleColor],[TitleFontType],[TitleType],[TitleImgPath],[UId],[UName],[UserType],[AdminUId],[AdminUName],[Status],[HitCount],[AddTime],[UpdateTime],[TemplatePath],[PageType],[IsCreated],[UserCateId],[PointCount],[ChargeType],[ChargeHourCount],[ChargeViewCount],[IsOpened],[GroupIdStr],[IsDeleted],[IsRecommend],[IsTop],[IsFocus],[IsSideShow],[TagIdStr],[TagNameStr],[SpecialIdStr],[LongTitle],[Content],[ShortContent],[OuterUrl],[Author],[Source],[IsHeader],[HeaderFont],[HeaderImgPath],[StarLevel],[IsShowCommentLink],[IsIrregular],[IrregularId],[ViewUName],[ViewUName2],[ViewEndTime],[IsAllowComment],[ExpireTime]
	)VALUES(
	@ColId,@Title,@TitleColor,@TitleFontType,@TitleType,@TitleImgPath,@UId,@UName,@UserType,@AdminUId,@AdminUName,@Status,@HitCount,@AddTime,@UpdateTime,@TemplatePath,@PageType,@IsCreated,@UserCateId,@PointCount,@ChargeType,@ChargeHourCount,@ChargeViewCount,@IsOpened,@GroupIdStr,@IsDeleted,@IsRecommend,@IsTop,@IsFocus,@IsSideShow,@TagIdStr,@TagNameStr,@SpecialIdStr,@LongTitle,@Content,@ShortContent,@OuterUrl,@Author,@Source,@IsHeader,@HeaderFont,@HeaderImgPath,@StarLevel,@IsShowCommentLink,@IsIrregular,@IrregularId,@ViewUName,@ViewUName2,@ViewEndTime,@IsAllowComment,@ExpireTime
	)
Set @Id=Scope_identity()

End
Else
Begin
	UPDATE KyArticle SET 
	[AddTime]=@AddTime,[ColId] = @ColId,[Title] = @Title,[TitleColor] = @TitleColor,[TitleFontType] = @TitleFontType,[TitleType] = @TitleType,[TitleImgPath] = @TitleImgPath,[UpdateTime] = @UpdateTime,[TemplatePath] = @TemplatePath,[PageType] = @PageType,[IsCreated] = @IsCreated,[PointCount] = @PointCount,[ChargeType] = @ChargeType,[ChargeHourCount] = @ChargeHourCount,[ChargeViewCount] = @ChargeViewCount,[IsOpened] = @IsOpened,[GroupIdStr] = @GroupIdStr,[IsRecommend] = @IsRecommend,[IsTop] = @IsTop,[IsFocus] = @IsFocus,[IsSideShow] = @IsSideShow,[TagIdStr] = @TagIdStr,[TagNameStr] = @TagNameStr,[SpecialIdStr] = @SpecialIdStr,[LongTitle] = @LongTitle,[Content] = @Content,[ShortContent] = @ShortContent,[OuterUrl] = @OuterUrl,[Author] = @Author,[Source] = @Source,[IsHeader] = @IsHeader,[HeaderFont] = @HeaderFont,[HeaderImgPath] = @HeaderImgPath,[StarLevel] = @StarLevel,[IsShowCommentLink] = @IsShowCommentLink,[IsIrregular] = @IsIrregular,[IrregularId] = @IrregularId,[ViewUName] = @ViewUName,[ViewEndTime] = @ViewEndTime,[IsAllowComment] = @IsAllowComment,[ExpireTime] = @ExpireTime,[HitCount]=@HitCount
	WHERE [Id] = @Id
End
GO

-- ----------------------------
-- Procedure structure for Up_Article_SetViewer
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Article_SetViewer]
GO
Create Procedure [dbo].[Up_Article_SetViewer]
@id int,
@viewername nvarchar(50)
as
update kyarticle set viewuname2=@viewername where id=@id

GO

-- ----------------------------
-- Procedure structure for Up_Card_Add
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Card_Add]
GO

CREATE PROCEDURE [dbo].[Up_Card_Add]
@Type int ,
@CardAccount varchar(20),
@Password varchar(200) ,
@IsUsed bit ,
@CardPoint int ,
@CardDay int ,
@AdminID int ,
@AdminName varchar(50) ,
@OverdueDate datetime 
 AS 
BEGIN 
	INSERT INTO KyCard(
	[Type],[Password],[IsUsed],[CardPoint],[CardDay],[AdminID],[AdminName],[OverdueDate]
	)VALUES(
	@Type,@Password,@IsUsed,@CardPoint,@CardDay,@AdminID,@AdminName,@OverdueDate
	)
	IF @@ROWCOUNT > 0
		BEGIN
		
			DECLARE @ID INT
				
			SET @ID = Scope_Identity()
			
			SET @CardAccount = @CardAccount + Convert(varchar(10),@ID)
			
			UPDATE KyCard SET CardAccount=@CardAccount WHERE [id]=@ID
			
			
					

		END 
		
		select @CardAccount as Account
END
GO

-- ----------------------------
-- Procedure structure for Up_Card_Delete
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Card_Delete]
GO

CREATE PROCEDURE [dbo].[Up_Card_Delete]
@CardAccount varchar(15)
 AS 
	DELETE KyCard
	 WHERE [CardAccount] = @CardAccount

GO

-- ----------------------------
-- Procedure structure for Up_Card_GetCard
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Card_GetCard]
GO

CREATE PROCEDURE [dbo].[Up_Card_GetCard]
@Account varchar(15)
 AS 
	SELECT 
	[Type],[Password],[IsUsed],[CardPoint],[CardDay],[AdminID],[AdminName],[UserID],[UserName],[OverdueDate]
	 FROM KyCard
	 WHERE [CardAccount] = @Account
GO

-- ----------------------------
-- Procedure structure for Up_Card_GetCards
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Card_GetCards]
GO


CREATE PROCEDURE [dbo].[Up_Card_GetCards]
(
@PageSize int=20,
@PageIndex int=1,
@WhereStr varchar(100),
@Total int=0 output
)
AS
	
begin
DECLARE @SqlStr nvarchar(2000)
DECLARE @fff nvarchar(100)

 
if(@WhereStr ='')
	begin
	 set @WhereStr=' where '
	 set @fff=''
	end 
else
	begin
		set @fff=' where '+@WhereStr
		set @WhereStr=' where '+@WhereStr+' and '		
	end
	
--
--print @fff

	if(@PageIndex=1)
		Set @SqlStr = N'Select Top '+Convert(Nvarchar(10),@PageSize)+' * FROM KyCard '+@fff +' Order By ID Desc'
	else
		Set @SqlStr = N'Select Top '+Convert(Nvarchar(10),@PageSize)+' * FROM KyCard '+@WhereStr+' ID<(Select Min(ID) From(Select Top '+Convert(Nvarchar(10),(@PageIndex-1)*@PageSize)+' * from KyCard  '+@fff+' Order By ID Desc)O) order By ID Desc'

end

print @SqlStr
Execute Sp_ExecuteSql @SqlStr


Set @SqlStr =' Select @TRecord =Count(ID) from KyCard '+@fff


Declare @Parm nvarchar(50)
Set @Parm = '@TRecord int output';
Exec Sp_ExecuteSql @SqlStr,@Parm,@TRecord=@Total output;
GO

-- ----------------------------
-- Procedure structure for Up_Card_Update
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Card_Update]
GO

CREATE PROCEDURE [dbo].[Up_Card_Update]
@Type int,
@CardAccount varchar(20),
@Password varchar(200),
@IsUsed bit,
@CardPoint int,
@CardDay int,
@AdminID int,
@AdminName varchar(50),
@UserID int,
@UserName nvarchar(36),
@OverdueDate datetime
 AS 
	UPDATE KyCard SET 
	[Type] = @Type,[Password] = @Password,[IsUsed] = @IsUsed,[CardPoint] = @CardPoint,[CardDay] = @CardDay,[AdminID] = @AdminID,[AdminName] = @AdminName,[UserID] = @UserID,[UserName] = @UserName,[OverdueDate] = @OverdueDate
	WHERE [CardAccount] = @CardAccount
GO

-- ----------------------------
-- Procedure structure for UP_Channel_Add
-- ----------------------------
DROP PROCEDURE [dbo].[UP_Channel_Add]
GO
CREATE PROCEDURE [dbo].[UP_Channel_Add]
@ChName nvarchar(50) ,
@Description nvarchar(255) ,
@TemplatePath nvarchar(255) ,
@IsChildSite bit ,
@ChildSiteUrl nvarchar(255) ,
@IsOpenLink bit ,
@ModelType int ,
@DirName nvarchar(50) ,
@TypeName nvarchar(10) ,
@TypeUnit nvarchar(10) ,
@IsDisabled bit ,
@IsOpened bit ,
@GroupIdStr varchar(500) ,
@VerifyType int ,
@Notice1 nvarchar(500) ,
@Notice2 nvarchar(500) ,
@Keyword nvarchar(100) ,
@Content nvarchar(300) ,
@MiniHitCount int ,
@IsStaticType bit ,
@ColumnSortType int ,
@InfoSortType int ,
@FileNameType int ,
@ChannelPageType int ,
@ColumnPageType int ,
@InfoPageType int,
@AddTime datetime ,
@Sort int ,
@ColumnTemplatePath nvarchar(255) ,
@InfoTemplatePath nvarchar(255) ,
@CommentTemplatePath nvarchar(255) ,
@IsDeleted bit,
@ChType int
 AS 
	INSERT INTO KyChannel(
	[ChName],[Description],[TemplatePath],[IsChildSite],[ChildSiteUrl],[IsOpenLink],[ModelType],[DirName],[TypeName],[TypeUnit],[IsDisabled],[IsOpened],[GroupIdStr],[VerifyType],[Notice1],[Notice2],[Keyword],[Content],[MiniHitCount],[IsStaticType],[ColumnSortType],[InfoSortType],[FileNameType],[ChannelPageType],[ColumnPageType],[InfoPageType],[AddTime],[Sort],[ColumnTemplatePath],[InfoTemplatePath],[CommentTemplatePath],[IsDeleted],[ChType]
	)VALUES(
	@ChName,@Description,@TemplatePath,@IsChildSite,@ChildSiteUrl,@IsOpenLink,@ModelType,@DirName,@TypeName,@TypeUnit,@IsDisabled,@IsOpened,@GroupIdStr,@VerifyType,@Notice1,@Notice2,@Keyword,@Content,@MiniHitCount,@IsStaticType,@ColumnSortType,@InfoSortType,@FileNameType,@ChannelPageType,@ColumnPageType,@InfoPageType,@AddTime,@Sort,@ColumnTemplatePath,@InfoTemplatePath,@CommentTemplatePath,@IsDeleted,@ChType
	)
    Select Scope_identity()

GO

-- ----------------------------
-- Procedure structure for Up_Channel_CompleteDelete
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Channel_CompleteDelete]
GO
CREATE proc [dbo].[Up_Channel_CompleteDelete]  
@chid int  
as  
declare @tablename nvarchar(50)  
set @tablename = (select tablename from kychannel ch join kymodel m on ch.modeltype=m.modelid where ch.chid=@chid)  
declare @sqlstr nvarchar(2000)   
declare @param nvarchar(200)  
set @param = '@tchid int'  
set @sqlstr = 'delete i from ['+@tablename+'] i join kycolumn co on i.colid=co.colid join kychannel ch on co.chid=ch.chid where ch.chid=@tchid'  
execute sp_executesql @sqlstr,@param,@tchid=@chid  
set @sqlstr = 'delete co from kycolumn co join kychannel ch on co.chid=ch.chid where ch.chid=@tchid '  
execute sp_executesql @sqlstr,@param,@tchid=@chid  
set @sqlstr = 'delete from kychannel where chid=@tchid'  
execute sp_executesql @sqlstr,@param,@tchid=@chid
GO

-- ----------------------------
-- Procedure structure for Up_Channel_Delete
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Channel_Delete]
GO
CREATE PROCEDURE [dbo].[Up_Channel_Delete]  
@chid int  
AS  
Set Xact_Abort On
Begin Tran
Declare @modeltype Int 
Set @modeltype=(Select ModelType From KyChannel Where ChId=@ChId);
Declare @tablename nvarchar(50)
Set @tablename = (Select TableName From KyModel Where ModelId=@ModelType)
Declare @sqlstr nvarchar(2000)
Declare @param nvarchar(500)

set @param = '@tchid int'
set @sqlstr = 'update i set i.[isdeleted]=1 from ['+@tablename+'] i join kycolumn co on i.colid=co.colid join kychannel ch on co.chid=ch.chid where ch.chid=@tchid';
execute sp_executesql @sqlstr,@param,@tchid=@chid
set @sqlstr = 'update co set co.[isdeleted]=1 from kycolumn co join kychannel ch on co.chid=ch.chid where ch.chid=@tchid'
execute sp_executesql @sqlstr,@param,@tchid=@chid
set @sqlstr = 'update ch set ch.[isdeleted]=1 from kychannel ch where ch.chid=@tchid';
execute sp_executesql @sqlstr,@param,@tchid=@chid
Commit Tran

GO

-- ----------------------------
-- Procedure structure for Up_Channel_GetAll
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Channel_GetAll]
GO

CREATE Procedure [dbo].[Up_Channel_GetAll]  
AS  
Select * From KyChannel a,KyModel b Where a.ModelType=b.ModelId  order By ModelType,Sort Asc
GO

-- ----------------------------
-- Procedure structure for Up_Channel_SetDisaled
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Channel_SetDisaled]
GO

--禁用/启用 频道
CREATE PROCEDURE [dbo].[Up_Channel_SetDisaled]
@ChId	Int,
@IsDisabled	Bit
as
update KyChannel set IsDisabled=@IsDisabled	where  ChId=@ChId

GO

-- ----------------------------
-- Procedure structure for Up_Channel_Update
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Channel_Update]
GO
CREATE Procedure [dbo].[Up_Channel_Update]
@ChId int,
@ChName nvarchar(50),
@Description nvarchar(255),
@TemplatePath nvarchar(255),
@IsChildSite bit,
@ChildSiteUrl nvarchar(255),
@IsOpenLink bit,
@ModelType int,
@DirName nvarchar(50),
@TypeName nvarchar(10),
@TypeUnit nvarchar(10),
@IsDisabled bit,
@IsOpened bit,
@GroupIdStr varchar(500),
@VerifyType int,
@Notice1 nvarchar(500),
@Notice2 nvarchar(500),
@Keyword nvarchar(100),
@Content nvarchar(300),
@MiniHitCount int,
@IsStaticType bit,
@ColumnSortType int,
@InfoSortType int,
@FileNameType int,
@ChannelPageType int,
@ColumnPageType int,
@InfoPageType int,
@Sort int,
@ColumnTemplatePath nvarchar(255),
@InfoTemplatePath nvarchar(255),
@CommentTemplatePath nvarchar(255),
@ChType int
 AS 
	UPDATE KyChannel SET 
	[ChName] = @ChName,[Description] = @Description,[TemplatePath] = @TemplatePath,[IsChildSite] = @IsChildSite,[ChildSiteUrl] = @ChildSiteUrl,[IsOpenLink] = @IsOpenLink,[ModelType] = @ModelType,[DirName] = @DirName,[TypeName] = @TypeName,[TypeUnit] = @TypeUnit,[IsDisabled] = @IsDisabled,[IsOpened] = @IsOpened,[GroupIdStr] = @GroupIdStr,[VerifyType] = @VerifyType,[Notice1] = @Notice1,[Notice2] = @Notice2,[Keyword] = @Keyword,[Content] = @Content,[MiniHitCount] = @MiniHitCount,[IsStaticType] = @IsStaticType,[ColumnSortType] = @ColumnSortType,[InfoSortType] = @InfoSortType,[FileNameType] = @FileNameType,[ChannelPageType] = @ChannelPageType,[ColumnPageType] = @ColumnPageType,[InfoPageType]=@InfoPageType,[Sort] = @Sort,[ColumnTemplatePath] = @ColumnTemplatePath,[InfoTemplatePath] = @InfoTemplatePath,[CommentTemplatePath] = @CommentTemplatePath,[ChType]=@ChType
	WHERE [ChId] = @ChId
GO

-- ----------------------------
-- Procedure structure for Up_CMS_CheckHas
-- ----------------------------
DROP PROCEDURE [dbo].[Up_CMS_CheckHas]
GO
CREATE Procedure [dbo].[Up_CMS_CheckHas]
@Input Nvarchar(500),
@FileldName Nvarchar(100),
@TableName Nvarchar(100)
As
Declare @SqlStr Nvarchar(2000)
Set @SqlStr = N'If Exists(Select 1 From '+@TableName+' Where '+@FileldName+'='''+Replace(@Input,'''','''''')+''') Select 1 Else Select 0'
Execute SP_ExecuteSql @SqlStr
GO

-- ----------------------------
-- Procedure structure for Up_Collection_Add
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Collection_Add]
GO
CREATE PROCEDURE [dbo].[Up_Collection_Add]
@ObjectName nvarchar(100) ,
@WebSite nvarchar(1000) ,
@ColId int ,
@SpecialId nvarchar(1000) ,
@CharSet nvarchar(100) ,
@ListPageUrl nvarchar(1000) ,
@ObjectDemo text ,
@ListStartCode ntext ,
@ListEndCode ntext ,
@LinkStartCode ntext ,
@LinkEndCode ntext ,
@PageSet nvarchar(2000) ,
@ContentPageSet nvarchar(2000) ,
@FieldListSet ntext ,
@SimpleFilterRule nvarchar(100) ,
@ComplexityFilterRule nvarchar(100) ,
@ProterySet nvarchar(100) ,
@StarLevel nvarchar(100) ,
@HiteCount int 
 AS 
	INSERT INTO KyCollection(
	[ObjectName],[WebSite],[ColId],[SpecialId],[CharSet],[ListPageUrl],[ObjectDemo],[ListStartCode],[ListEndCode],[LinkStartCode],[LinkEndCode],[PageSet],[ContentPageSet],[FieldListSet],[SimpleFilterRule],[ComplexityFilterRule],[ProterySet],[StarLevel],[HiteCount]
	)VALUES(
	@ObjectName,@WebSite,@ColId,@SpecialId,@CharSet,@ListPageUrl,@ObjectDemo,@ListStartCode,@ListEndCode,@LinkStartCode,@LinkEndCode,@PageSet,@ContentPageSet,@FieldListSet,@SimpleFilterRule,@ComplexityFilterRule,@ProterySet,@StarLevel,@HiteCount
	)
GO

-- ----------------------------
-- Procedure structure for Up_Collection_Delete
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Collection_Delete]
GO
CREATE PROCEDURE [dbo].[Up_Collection_Delete]
@Id int
 AS 
	DELETE KyCollection
	 WHERE [Id] = @Id
GO

-- ----------------------------
-- Procedure structure for Up_Collection_GetIdByCollection
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Collection_GetIdByCollection]
GO
CREATE PROCEDURE [dbo].[Up_Collection_GetIdByCollection]
@Id int
 AS 
	SELECT 
	[Id],[ObjectName],[WebSite],[ColId],[SpecialId],[CharSet],[ListPageUrl],[ObjectDemo],[ListStartCode],[ListEndCode],[LinkStartCode],[LinkEndCode],[PageSet],[ContentPageSet],[FieldListSet],[SimpleFilterRule],[ComplexityFilterRule],[ProterySet],[StarLevel],[HiteCount]
	 FROM KyCollection
	 WHERE [Id] = @Id
GO

-- ----------------------------
-- Procedure structure for Up_Collection_GetList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Collection_GetList]
GO
CREATE PROCEDURE [dbo].[Up_Collection_GetList]
 AS 
	SELECT 
	[Id],[ObjectName],[WebSite],[ColId],[SpecialId],[CharSet],[ListPageUrl],[ObjectDemo],[ListStartCode],[ListEndCode],[LinkStartCode],[LinkEndCode],[PageSet],[ContentPageSet],[FieldListSet],[SimpleFilterRule],[ComplexityFilterRule],[ProterySet],[StarLevel],[HiteCount]
	 FROM KyCollection Order by [id] desc
GO

-- ----------------------------
-- Procedure structure for Up_Collection_Update
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Collection_Update]
GO
CREATE PROCEDURE [dbo].[Up_Collection_Update]
@Id int,
@ObjectName nvarchar(100),
@WebSite nvarchar(1000),
@ColId int,
@SpecialId nvarchar(1000),
@CharSet nvarchar(100),
@ListPageUrl nvarchar(1000),
@ObjectDemo text,
@ListStartCode ntext,
@ListEndCode ntext,
@LinkStartCode ntext,
@LinkEndCode ntext,
@PageSet nvarchar(2000),
@ContentPageSet nvarchar(2000),
@FieldListSet ntext,
@SimpleFilterRule nvarchar(100),
@ComplexityFilterRule nvarchar(100),
@ProterySet nvarchar(100),
@StarLevel nvarchar(100),
@HiteCount int
 AS 
	UPDATE KyCollection SET 
	[ObjectName] = @ObjectName,[WebSite] = @WebSite,[ColId] = @ColId,[SpecialId] = @SpecialId,[CharSet] = @CharSet,[ListPageUrl] = @ListPageUrl,[ObjectDemo] = @ObjectDemo,[ListStartCode] = @ListStartCode,[ListEndCode] = @ListEndCode,[LinkStartCode] = @LinkStartCode,[LinkEndCode] = @LinkEndCode,[PageSet] = @PageSet,[ContentPageSet] = @ContentPageSet,[FieldListSet] = @FieldListSet,[SimpleFilterRule] = @SimpleFilterRule,[ComplexityFilterRule] = @ComplexityFilterRule,[ProterySet] = @ProterySet,[StarLevel] = @StarLevel,[HiteCount] = @HiteCount
	WHERE [Id] = @Id
GO

-- ----------------------------
-- Procedure structure for Up_CollectionAddress_Add
-- ----------------------------
DROP PROCEDURE [dbo].[Up_CollectionAddress_Add]
GO
CREATE PROCEDURE [dbo].[Up_CollectionAddress_Add]
@ColectionId int ,
@CollectionUrl nvarchar(1000) ,
@State bit 
 AS 
	INSERT INTO KyCollectionAddress(
	[ColectionId],[CollectionUrl],[State]
	)VALUES(
	@ColectionId,@CollectionUrl,@State
	)
GO

-- ----------------------------
-- Procedure structure for Up_CollectionAddress_CheckAddress
-- ----------------------------
DROP PROCEDURE [dbo].[Up_CollectionAddress_CheckAddress]
GO
CREATE PROCEDURE [dbo].[Up_CollectionAddress_CheckAddress] 
@collectionaddress nvarchar(500)
AS
select CollectionUrl From KyCollectionAddress Where CollectionUrl=@collectionaddress
GO

-- ----------------------------
-- Procedure structure for Up_CollectionAddress_DeleteCollId
-- ----------------------------
DROP PROCEDURE [dbo].[Up_CollectionAddress_DeleteCollId]
GO
CREATE PROCEDURE [dbo].[Up_CollectionAddress_DeleteCollId] 
@collid int,
@state bit
AS
delete from KyCollectionAddress where ColectionId=@collid and State=@state
GO

-- ----------------------------
-- Procedure structure for Up_CollectionAddress_GetCollidByAddress
-- ----------------------------
DROP PROCEDURE [dbo].[Up_CollectionAddress_GetCollidByAddress]
GO
CREATE PROCEDURE [dbo].[Up_CollectionAddress_GetCollidByAddress] 
@collectionid int
AS
select CollectionUrl from KyCollectionAddress Where ColectionId=@collectionid and state=0
GO

-- ----------------------------
-- Procedure structure for Up_CollectionAddress_GetCollIdList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_CollectionAddress_GetCollIdList]
GO
CREATE proc [dbo].[Up_CollectionAddress_GetCollIdList]
@collid int,
@state bit,
@pageindex int,
@pagesize int,
@recordcount int output
as
declare @sqlstr nvarchar(2000);
if(@pageindex=1)
	set @sqlstr=N'select top '+Convert(nvarchar(15),@pagesize)+' * from KyCollectionAddress Where ColectionId='+Convert(nvarchar

(15),@collid)+' and state='+convert(nvarchar(15),@state)+'  order by id desc'
else
	set @sqlstr=N'select top '+convert(nvarchar(15),@pagesize)+' * from KyCollectionAddress Where id <(select min(id) from (select top 

'+convert(nvarchar(15),(@pageindex-1)*@pagesize)+' id from KyCollectionAddress where ColectionId= '+convert(nvarchar(15),@collid)+' and state='+convert(nvarchar(15),@state)+'  order by 

id desc)o) and ColectionId='+Convert(nvarchar(15),@collid)+' and state='+convert(nvarchar(15),@state)+'  order by id desc'
Execute Sp_executeSql @sqlstr
set @recordcount=(select count(id) from KyCollectionAddress where ColectionId=@collid and State=@state)
GO

-- ----------------------------
-- Procedure structure for Up_CollectionAddress_UpdateState
-- ----------------------------
DROP PROCEDURE [dbo].[Up_CollectionAddress_UpdateState]
GO
CREATE PROCEDURE [dbo].[Up_CollectionAddress_UpdateState] 
@collectionaddress nvarchar(500)
AS
Update KyCollectionAddress Set State=1 Where CollectionUrl=@collectionaddress
GO

-- ----------------------------
-- Procedure structure for Up_Column_Add
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Column_Add]
GO

CREATE Procedure [dbo].[Up_Column_Add]
@ChId int ,
@ColName nvarchar(50) ,
@ColDirName nvarchar(50) ,
@ColParentId int ,
@IsOuterColumn bit ,
@OuterColumnUrl varchar(255) ,
@ColumnImgPath nvarchar(510) ,
@Description nvarchar(510) ,
@Keyword nvarchar(100) ,
@Content nvarchar(300) ,
@IsAllowAddInfo bit ,
@ColumnTemplatePath nvarchar(255) ,
@InfoTemplatePath nvarchar(255) ,
@CommentTemplatePath nvarchar(255) ,
@Sort int ,
@IsAllowComment bit ,
@IsCheckComment bit ,
@InfoTableName nvarchar(50) ,
@ScoreReward int ,
@PointCount int ,
@ChargeType int ,
@ChargeHourCount int ,
@ChargeViewCount int ,
@IsOpened bit ,
@GroupIdStr varchar(500) ,
@ColumnPageType int,
@InfoPageType int,
@IsDeleted bit ,
@AddTime datetime 
 AS 
	INSERT INTO KyColumn(
	[ChId],[ColName],[ColDirName],[ColParentId],[IsOuterColumn],[OuterColumnUrl],[ColumnImgPath],[Description],[Keyword],[Content],[IsAllowAddInfo],[ColumnTemplatePath],[InfoTemplatePath],[CommentTemplatePath],[Sort],[IsAllowComment],[IsCheckComment],[InfoTableName],[ScoreReward],[PointCount],[ChargeType],[ChargeHourCount],[ChargeViewCount],[IsOpened],[GroupIdStr],[ColumnPageType],[InfoPageType],[IsDeleted],[AddTime]
	)VALUES(
	@ChId,@ColName,@ColDirName,@ColParentId,@IsOuterColumn,@OuterColumnUrl,@ColumnImgPath,@Description,@Keyword,@Content,@IsAllowAddInfo,@ColumnTemplatePath,@InfoTemplatePath,@CommentTemplatePath,@Sort,@IsAllowComment,@IsCheckComment,@InfoTableName,@ScoreReward,@PointCount,@ChargeType,@ChargeHourCount,@ChargeViewCount,@IsOpened,@GroupIdStr,@ColumnPageType,@InfoPageType,@IsDeleted,@AddTime
	)
	Select Scope_Identity()
GO

-- ----------------------------
-- Procedure structure for Up_Column_CompleteDelete
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Column_CompleteDelete]
GO

CREATE proc [dbo].[Up_Column_CompleteDelete]
@colid int
as
declare @tablename nvarchar(50)
set @tablename = (select tablename from kycolumn co join kychannel ch on co.chid=ch.chid join kymodel m on ch.modeltype=m.modelid where co.colid=@colid)
declare @sqlstr nvarchar(2000) 
set @sqlstr =
'declare @tb table(id int)  '+
'insert into @tb select @tcolid  while exists(select * from kycolumn where (colparentid in(select [id] from @tb)) and (colid not in(select [id] from @tb)))
begin
	insert into @tb select colid from kycolumn where (colparentid in(select [id] from @tb)) and (colid not in(select [id] from @tb))
end  '+
'delete i from ['+@tablename+'] i join @tb t on i.colid=t.[id]  ' +
'delete co from kycolumn co join @tb t on co.colid=t.[id]'
declare @param nvarchar(200)
set @param='@tcolid int'
execute sp_executesql @sqlstr,@param,@tcolid=@colid
GO

-- ----------------------------
-- Procedure structure for Up_Column_Delete
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Column_Delete]
GO

CREATE PROCEDURE [dbo].[Up_Column_Delete]   
@chid int,
@colidstr Nvarchar(2000)
AS  
Set Xact_Abort On
Begin Tran
Declare @modeltype Int 
Set @modeltype=(Select ModelType From kychannel Where chid=@chid);
Declare @tablename nvarchar(50)
Set @tablename = (Select tablename From kymodel Where ModelId=@modeltype)
Declare @sqlstr nvarchar(2000)
set @sqlstr = 'update i set i.[isdeleted]=1 from ['+@tablename+'] i where i.colid in('+@colidstr+')'
execute sp_executesql @sqlstr
set @sqlstr = 'update co set co.[isdeleted]=1 from kycolumn co where co.colid in('+@colidstr+')'
execute sp_executesql @sqlstr
Commit Tran
GO

-- ----------------------------
-- Procedure structure for Up_Column_GetAll
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Column_GetAll]
GO

CREATE Procedure [dbo].[Up_Column_GetAll]
As
Select * From KyColumn order by sort asc ,colid asc
GO

-- ----------------------------
-- Procedure structure for Up_Column_Move
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Column_Move]
GO

CREATE Procedure [dbo].[Up_Column_Move]
@ColId int,
@TargetId int,
@IsChannel bit,
@ChildIdStr Nvarchar(1000)
As
Declare @SqlStr Nvarchar(2000)
If(@IsChannel=1)
Begin

	Update KyColumn Set ChId=@TargetId,ColParentId=0 Where ColId=@ColId;
	Set @SqlStr = N'Update KyColumn Set ChId='+Convert(Nvarchar(15),@TargetId)+' Where ColId In('+@ChildIdStr+')'
	Execute Sp_ExecuteSql @SqlStr
	
	
End
Else
Begin
	Declare @ChId Int
	Set @ChId=(Select ChId From KyColumn Where ColId=@TargetId);
	Update KyColumn Set ChId=@ChId,ColParentId=@TargetId Where ColId=@ColId;
	Set @SqlStr = N'Update KyColumn Set ChId='+Convert(Nvarchar(15),@ChId)+' Where ColId In('+@ChildIdStr+')'
	Execute Sp_ExecuteSql @SqlStr
	
End
GO

-- ----------------------------
-- Procedure structure for Up_Column_SetInfoTemplate
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Column_SetInfoTemplate]
GO
create PROCEDURE [dbo].[Up_Column_SetInfoTemplate]    
 @colid int,
 @tablename nvarchar(50),    
 @InfoTemplatePath varchar(255)
as
declare @sqlstr nvarchar(2000)
set @sqlstr = 'update ['+@tablename+'] set templatepath=@ttemplatepath where colid=@tcolid'
declare @param nvarchar(400)
set @param = '@ttemplatepath varchar(255),@tcolid int'
execute sp_executesql @sqlstr,@param,@ttemplatepath=@InfoTemplatePath,@tcolid=@colid

  


   

  


GO

-- ----------------------------
-- Procedure structure for Up_Column_Update
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Column_Update]
GO

CREATE procedure [dbo].[Up_Column_Update]
@ColId int,
@ChId int,
@ColName nvarchar(50),
@ColDirName nvarchar(50),
@ColParentId int,
@IsOuterColumn bit,
@OuterColumnUrl varchar(255),
@ColumnImgPath nvarchar(255),
@Description nvarchar(510),
@Keyword nvarchar(100),
@Content nvarchar(300),
@IsAllowAddInfo bit,
@ColumnTemplatePath nvarchar(255),
@InfoTemplatePath nvarchar(255),
@CommentTemplatePath nvarchar(255),
@Sort int,
@IsAllowComment bit,
@IsCheckComment bit,
@InfoTableName nvarchar(50),
@ScoreReward int,
@PointCount int,
@ChargeType int,
@ChargeHourCount int,
@ChargeViewCount int,
@IsOpened bit,
@GroupIdStr varchar(500),
@ColumnPageType int,
@InfoPageType int
 AS 
	UPDATE KyColumn SET 
	[ChId] = @ChId,[ColName] = @ColName,[ColDirName] = @ColDirName,[ColParentId] = @ColParentId,[IsOuterColumn] = @IsOuterColumn,[OuterColumnUrl] = @OuterColumnUrl,[ColumnImgPath] = @ColumnImgPath,[Description] = @Description,[Keyword] = @Keyword,[Content] = @Content,[IsAllowAddInfo] = @IsAllowAddInfo,[ColumnTemplatePath] = @ColumnTemplatePath,[InfoTemplatePath] = @InfoTemplatePath,[CommentTemplatePath] = @CommentTemplatePath,[Sort] = @Sort,[IsAllowComment] = @IsAllowComment,[IsCheckComment] = @IsCheckComment,[InfoTableName] = @InfoTableName,[ScoreReward] = @ScoreReward,[PointCount] = @PointCount,[ChargeType] = @ChargeType,[ChargeHourCount] = @ChargeHourCount,[ChargeViewCount] = @ChargeViewCount,[IsOpened] = @IsOpened,[GroupIdStr] = @GroupIdStr,[ColumnPageType]=@ColumnPageType,[InfoPageType]=@InfoPageType
	WHERE [ColId] = @ColId
GO

-- ----------------------------
-- Procedure structure for Up_Column_Update_Template
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Column_Update_Template]
GO

CREATE PROCEDURE [dbo].[Up_Column_Update_Template]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
	@ColId int output,
	@ColumnTemplatePath nvarchar(510) ,
	@InfoTemplatePath nvarchar(510) ,
	@CommentTemplatePath nvarchar(510)
AS
	/* SET NOCOUNT ON */ 
	UPDATE KyColumn SET  [ColumnTemplatePath] = (case @ColumnTemplatePath when '' then [ColumnTemplatePath] else @ColumnTemplatePath end),[InfoTemplatePath] = (case @InfoTemplatePath when '' then [InfoTemplatePath] else @InfoTemplatePath end),[CommentTemplatePath] = (case @CommentTemplatePath when '' then [CommentTemplatePath] else @CommentTemplatePath end ) WHERE [ColId] = @ColId
	RETURN


GO

-- ----------------------------
-- Procedure structure for Up_Controller_Delete
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Controller_Delete]
GO

Create Procedure [dbo].[Up_Controller_Delete]
@ControllerId Int,
@UserId Int
As
Delete From KyController
Where ControllerId=@ControllerId And UserId=@UserId


GO

-- ----------------------------
-- Procedure structure for Up_Controller_GetList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Controller_GetList]
GO

CREATE Procedure [dbo].[Up_Controller_GetList]
@UserId Int
AS
If not Exists(Select * From KyController Where UserId=@UserId)
Begin
	Insert Into KyController(ControllerName,LinkURI,OrderNum,UserId)
	Select ControllerName,LinkURI,OrderNum,@UserId From KyController
	Where UserId=0
End

Select * From KyController
Where UserId=@UserId
Order By OrderNum Asc


GO

-- ----------------------------
-- Procedure structure for Up_Controller_Set
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Controller_Set]
GO

CREATE Procedure [dbo].[Up_Controller_Set]
@ControllerId int,
@ControllerName Nvarchar(50),
@LinkURI Varchar(255),
@OrderNum Int,
@UserId Int

AS

If(@ControllerId=0)
Begin
	Insert Into KyController(ControllerName,LinkURI,OrderNum,UserId)
	Values(@ControllerName,@LinkURI,@OrderNum,@UserId)
End
Else
Begin
	Update KyController
	Set ControllerName=@ControllerName,LinkURI=@LinkURI,OrderNum=@OrderNum
	Where ControllerId=@ControllerId And UserId=@UserId And UserId!=0
End


GO

-- ----------------------------
-- Procedure structure for Up_Controller_Set_Default
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Controller_Set_Default]
GO

Create Procedure [dbo].[Up_Controller_Set_Default]
@UserId Int
As
Delete From KyController Where UserId=@UserId And UserId!=0
Insert Into KyController(ControllerName,LinkURI,OrderNum,UserId)
Select ControllerName,LinkURI,OrderNum,@UserId From KyController
Where UserId=0


GO

-- ----------------------------
-- Procedure structure for Up_Create_Article_HeaderList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Create_Article_HeaderList]
GO
CREATE procedure [dbo].[Up_Create_Article_HeaderList]
@infocount int,
@colid int,
@isimg bit
as
declare @wherestr nvarchar(500)
if(@isimg=0)
	set @wherestr = ' isheader=1 and headerfont<>'''' '
else
	set @wherestr = ' isheader=1 and headerimgpath<>'''' '
set @wherestr =  + ' i.status=3 and i.isdeleted=0 and i.colid=@tcolid and '+@wherestr
declare @fieldstr nvarchar(1000)
set @fieldstr = ' i.*,m.modelid,m.tablename,m.uploadpath,ch.chid,ch.typename,ch.chname,ch.dirName,ch.infosorttype,ch.filenametype,ch.isstatictype,colisopened=co.isopened,co.colName,co.coldirname '
declare @tablestr nvarchar(400)
set @tablestr = ' [kyarticle] as i join kycolumn co on i.colid=co.colid join kychannel ch on co.chid=ch.chid join kymodel m on ch.modeltype=m.modelid '
declare @sqlstr nvarchar(4000)
	set @sqlstr='select top '+convert(nvarchar(15),@infocount)+@fieldstr+'from'+@tablestr+'where'+@wherestr+'order by i.[id] desc'
declare @param nvarchar(400)
set @param = '@tcolid int'
execute sp_executesql @sqlstr,@param,@tcolid=@colid
GO

-- ----------------------------
-- Procedure structure for Up_Create_Ch_GetSpecialInfoCount
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Create_Ch_GetSpecialInfoCount]
GO
CREATE proc [dbo].[Up_Create_Ch_GetSpecialInfoCount]  
@tablename nvarchar(50),    
@infocount int,    
@specialidstr nvarchar(3000),    
@datestr datetime  
as    
declare @fieldstr nvarchar(500)    
set @fieldstr = ' i.[id] '    
declare @tablestr nvarchar(400)    
set @tablestr = ' ['+@tableName+'] as i join kycolumn co on i.colid=co.colid join kychannel ch on co.chid=ch.chid join kymodel m on ch.modeltype=m.modelid '    
declare @wherestr nvarchar(4000)    
set @wherestr = ''    
if(@datestr!='')    
 set @wherestr = @wherestr+' i.addtime>=@tdatestr and '    
set @wherestr = @wherestr + @specialidstr +' i.status=3 and i.isdeleted=0 '    
declare @topnum nvarchar(50)    
set @topnum = '';    
if(@infocount!=0)    
 set @topnum = ' top '+convert(nvarchar(15),@infocount)+' '    
declare @sqlstr nvarchar(4000)    
set @sqlstr = 'select '+@topnum+@fieldstr+'from'+@tablestr+'where'+@wherestr  
declare @param nvarchar(500)    
set @param='@tdatestr datetime'    
declare @countstr nvarchar(4000)  
set @countstr = 'select count(*) from ('+@sqlstr+')o'  
execute sp_executesql @countstr,@param,@tdatestr=@datestr    


GO

-- ----------------------------
-- Procedure structure for Up_Create_Ch_GetSpecialInfoList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Create_Ch_GetSpecialInfoList]
GO
CREATE proc [dbo].[Up_Create_Ch_GetSpecialInfoList]  
@tablename nvarchar(50),  
@infocount int,  
@specialidstr nvarchar(3000),  
@datestr datetime,  
@orderstr nvarchar(100)  
  
as  
declare @fieldstr nvarchar(1000)  
set @fieldstr = ' i.*,m.modelid,m.tablename,m.uploadpath,ch.chid,ch.typename,ch.chname,ch.dirName,ch.infosorttype,ch.filenametype,ch.isstatictype,colisopened=co.isopened,co.colName,co.coldirname '  
declare @tablestr nvarchar(400)  
set @tablestr = ' ['+@tableName+'] as i join kycolumn co on i.colid=co.colid join kychannel ch on co.chid=ch.chid join kymodel m on ch.modeltype=m.modelid '  
declare @wherestr nvarchar(4000)  
set @wherestr = ''  
if(@datestr!='')  
 set @wherestr = @wherestr+' i.addtime>=@tdatestr and '  

--set @wherestr = @wherestr + ' i.[specialidstr] like ''%|'+convert(nvarchar(15),@specialid)+'|%'' and i.status=3 and i.isdeleted=0 '  
set @wherestr = @wherestr + @specialidstr+' i.status=3 and i.isdeleted=0 '  
declare @topnum nvarchar(50)  
set @topnum = '';  
if(@infocount!=0)  
 set @topnum = ' top '+convert(nvarchar(15),@infocount)+' '  
declare @sqlstr nvarchar(4000)  
set @sqlstr = 'select '+@topnum+@fieldstr+'from'+@tablestr+'where'+@wherestr+' order by '+@orderstr  
declare @param nvarchar(500)  
set @param='@tdatestr datetime'  
execute sp_executesql @sqlstr,@param,@tdatestr=@datestr

GO

-- ----------------------------
-- Procedure structure for Up_Create_GetAll_Info
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Create_GetAll_Info]
GO
CREATE Proc [dbo].[Up_Create_GetAll_Info]  
@CursorPage Int,  
@PageSize Int,  
@tableName Nvarchar(50)  
As  
Declare @SqlStr Nvarchar(2000);  
declare @fieldstr nvarchar(500);
set @fieldstr = ' i.*,m.modelid,m.tablename,m.uploadpath,ch.chid,ch.typename,ch.chname,ch.dirName,ch.infosorttype,ch.filenametype,ch.isstatictype,colisopened=co.isopened,co.colName,co.coldirname '
declare @tablestr nvarchar(200)
set @tablestr = ' ['+@tableName+'] as i join kycolumn co on i.colid=co.colid join kychannel ch on co.chid=ch.chid join kymodel m on ch.modeltype=m.modelid '
if(@CursorPage=1)  
 set @SqlStr=N'select top '+Convert(Nvarchar(15),@PageSize)+@fieldstr+' from'+@tablestr+' where i.status=3 and i.isdeleted=0 order by i.[id] desc'
else  
 set @SqlStr=N'select top '+Convert(Nvarchar(15),@PageSize)+@fieldstr+' from'+@tablestr+' where i.status=3 and i.isdeleted=0 and i.Id<(Select min(id) From(Select Top '+Convert(Nvarchar(15),(@CursorPage-1)*@PageSize)+' i.[id] from '+@tablestr+' where i.status=3 and i.isdeleted=0 Order By i.Id Desc)O) Order By i.[id] Desc '  
Execute SP_ExecuteSql @SqlStr
GO

-- ----------------------------
-- Procedure structure for Up_Create_GetChannel_Column_InfoList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Create_GetChannel_Column_InfoList]
GO
CREATE procedure [dbo].[Up_Create_GetChannel_Column_InfoList]
@chid int,
@colcount int,
@colidstr nvarchar(1000)
as
declare @topnum nvarchar(50)
set @topnum = '';
declare @wherestr nvarchar(1000)
set @wherestr = ' co.chid=@tchid and co.colparentid=0 ';
if(@colcount!=0 and @colidstr='')
	set @topnum = ' top '+convert(nvarchar(15),@colcount)+ ' '
else if(@colidstr!='')
	set @wherestr = @wherestr + ' and colid in('+@colidstr+') '

declare @sqlstr nvarchar(4000)
set @sqlstr = 'select '+@topnum+' co.colid,co.colname,co.colid,co.columnimgpath from kycolumn co  where '+@wherestr+' and co.isdeleted=0  order by co.sort asc'
declare @param nvarchar(500)
set @param = '@tchid int'
execute sp_executesql @sqlstr,@param,@tchid=@chid

GO

-- ----------------------------
-- Procedure structure for Up_Create_GetChannel_InfoList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Create_GetChannel_InfoList]
GO
CREATE procedure [dbo].[Up_Create_GetChannel_InfoList]
@tablename nvarchar(50),
@infocount int,
@chid int,
@typestr nvarchar(1000),
@datestr datetime,
@orderstr nvarchar(50)
as
declare @fieldstr nvarchar(1000)
set @fieldstr = ' i.*,m.modelid,m.tablename,m.uploadpath,ch.chid,ch.typename,ch.chname,ch.dirName,ch.infosorttype,ch.filenametype,ch.isstatictype,colisopened=co.isopened,co.colName,co.coldirname '
declare @tablestr nvarchar(400)
set @tablestr = ' ['+@tableName+'] as i join kycolumn co on i.colid=co.colid join kychannel ch on co.chid=ch.chid join kymodel m on ch.modeltype=m.modelid '
declare @topnum nvarchar(50)
set @topnum = '';
if(@infocount!='')
	set @topnum = ' top '+convert(nvarchar(15),@infocount)+' ';
declare @wherestr nvarchar(2000)
set @wherestr = '';
if(@typestr!='')
	set @wherestr = @wherestr+@typestr+' and '
if(@datestr!='')
	set @wherestr = @wherestr+' i.addtime>=@tdatestr and '
set @wherestr=@wherestr+' co.chid=@tchid and i.status=3 and i.isdeleted=0 '
declare @sqlstr nvarchar(1000)
set @sqlstr = 'select '+@topnum+@fieldstr+'from'+@tablestr+'where'+@wherestr+' order by '+@orderstr
declare @param nvarchar(500)
set @param = '@tchid int,@tdatestr datetime'
execute sp_executesql @sqlstr,@param,@tchid=@chid,@tdatestr=@datestr
GO

-- ----------------------------
-- Procedure structure for Up_Create_GetCloseInfo
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Create_GetCloseInfo]
GO
create proc [dbo].[Up_Create_GetCloseInfo]
@tablename nvarchar(50),
@id int,
@colid int,
@direct nvarchar(10)
as
declare @sqlstr nvarchar(2000)
declare @param nvarchar(500)
if(@direct='pre')
	set @sqlstr = 	'if exists(select [id] from ['+@tablename+'] where [id]<@tid and colid=@tcolid and status=3 and isdeleted=0) '+
			'select top 1 [id],title from ['+@tablename+'] where [id]<@tid and colid=@tcolid and status=3 and  isdeleted=0 order by id desc '+
			'else '+
			'select [id]=0'
else
	set @sqlstr =	'if exists(select [id] from ['+@tablename+'] where [id]>@tid and colid=@tcolid and status=3 and isdeleted=0) '+
			'select top 1 [id],title from ['+@tablename+'] where [id]>@tid and colid=@tcolid and status=3 and isdeleted=0 order by id asc '+
			'else '+
			'select [id]=0'
set @param = '@tid int,@tcolid int'
execute sp_executesql @sqlstr,@param,@tid=@id,@tcolid=@colid

GO

-- ----------------------------
-- Procedure structure for Up_Create_GetColumn_ChildCol_InfoList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Create_GetColumn_ChildCol_InfoList]
GO
CREATE Procedure [dbo].[Up_Create_GetColumn_ChildCol_InfoList]  
@colid int,
@colcount int
as
declare @topnum nvarchar(50)
set @topnum = '';
if(@colcount!=0)
	set @topnum = ' top '+convert(nvarchar(15),@colcount)+' '
declare @wherestr nvarchar(500)
set @wherestr = ' co.colparentid=@tcolid and co.isdeleted=0 '
declare @sqlstr nvarchar(2000)
set @sqlstr = 'select '+@topnum+' co.colid,co.colname,co.colid from kycolumn co where'+@wherestr+' order by co.sort asc'
declare @param nvarchar(50)
set @param = '@tcolid int'
execute sp_executesql @sqlstr,@param,@tcolid=@colid

GO

-- ----------------------------
-- Procedure structure for Up_Create_GetColumn_FinallyInfoCount
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Create_GetColumn_FinallyInfoCount]
GO
CREATE proc [dbo].[Up_Create_GetColumn_FinallyInfoCount]
@tablename nvarchar(50),
@colidstr nvarchar(1000),
@datestr nvarchar(50)
as
declare @tablestr nvarchar(400)
set @tablestr = ' ['+@tableName+'] as i join kycolumn co on i.colid=co.colid join kychannel ch on co.chid=ch.chid join kymodel m on ch.modeltype=m.modelid '
declare @wherestr nvarchar(500)
set @wherestr=''
if(@datestr!='')
	set @wherestr=@wherestr+' i.[addtime]>=@tdatestr and '
set @wherestr = @wherestr+' i.colid in('+@colidstr+') and i.status=3 and i.isdeleted=0 '
declare @sqlstr nvarchar(4000)
set @sqlstr = 'select count(i.[id]) from'+@tablestr+'where'+@wherestr
declare @param nvarchar(50)
set @param='@tdatestr datetime'
execute sp_executesql @sqlstr,@param,@tdatestr=@datestr

GO

-- ----------------------------
-- Procedure structure for Up_Create_GetColumn_FinallyInfoList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Create_GetColumn_FinallyInfoList]
GO
CREATE proc [dbo].[Up_Create_GetColumn_FinallyInfoList]
@tablename nvarchar(50),
@colidstr nvarchar(1000),
@datestr nvarchar(50),
@orderstr nvarchar(50),
@ispadding bit,
@pageindex int,
@pagesize int
as

declare @fieldstr nvarchar(1000)
set @fieldstr = ' i.*,m.modelid,m.tablename,m.uploadpath,ch.chid,ch.typename,ch.typeunit,ch.chname,ch.dirName,ch.infosorttype,ch.filenametype,ch.isstatictype,colisopened=co.isopened,co.colName,co.coldirname '
declare @tablestr nvarchar(400)
set @tablestr = ' ['+@tableName+'] as i join kycolumn co on i.colid=co.colid join kychannel ch on co.chid=ch.chid join kymodel m on ch.modeltype=m.modelid '

declare @wherestr nvarchar(500)
set @wherestr = '';
if(@datestr!='')
	set @wherestr=' i.[addtime]>=@tdatestr and '
set @wherestr = @wherestr+' i.colid in('+@colidstr+') and i.status=3 and i.isdeleted=0 '
declare @sqlstr nvarchar(4000)
if(@ispadding=0)
	set @sqlstr = 'select'+@fieldstr+'from'+@tablestr+'where'+@wherestr+' order by '+@orderstr
else
begin
	if(@pageindex=1)
		set @sqlstr = 'select top '+convert(nvarchar(15),@pagesize)+@fieldstr+'from'+@tablestr+'where'+@wherestr+' order by '+@orderstr
	else
		set @sqlstr = 'select top '+convert(nvarchar(15),@pagesize)+@fieldstr+'from'+@tablestr+'where i.[id] not in(select top '+convert(nvarchar(15),(@pageindex-1)*@pagesize)+' i.[id] from'+@tablestr+'where'+@wherestr+' order by '+@orderstr+') and '+@wherestr+' order by '+@orderstr
end

declare @param nvarchar(50)
set @param='@tdatestr datetime'
execute sp_executesql @sqlstr,@param,@tdatestr=@datestr
GO

-- ----------------------------
-- Procedure structure for Up_Create_GetColumn_FlashInfoList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Create_GetColumn_FlashInfoList]
GO
CREATE proc [dbo].[Up_Create_GetColumn_FlashInfoList]  
@tablename nvarchar(50),  
@chid int,
@colidstr varchar(1000),  
@infocount int  
as  
declare @fieldstr nvarchar(1000)  
set @fieldstr = ' i.*,m.modelid,m.tablename,m.uploadpath,ch.chid,ch.typename,ch.chname,ch.dirName,ch.infosorttype,ch.filenametype,ch.isstatictype,colisopened=co.isopened,co.colName,co.coldirname '  
declare @tablestr nvarchar(400)  
set @tablestr = ' ['+@tableName+'] as i join kycolumn co on i.colid=co.colid join kychannel ch on co.chid=ch.chid join kymodel m on ch.modeltype=m.modelid '  
declare @sqlstr nvarchar(4000)  
declare @wherestr nvarchar(1000)
set @wherestr = '';
if(@chid!=0)
	set @wherestr = @wherestr+' ch.chid=@tchid and '
if(@colidstr!='')
	set @wherestr = @wherestr+' i.colid in('+@colidstr+') and '
set @wherestr = @wherestr+' i.status=3 and i.isdeleted=0 and issideshow=1 '
set @sqlstr = 'select top '+convert(nvarchar(15),@infocount)+@fieldstr+'from'+@tablestr+'where '+@wherestr+' order by i.[id] desc'  
declare @param nvarchar(400)
set @param = '@tchid int'
execute sp_executesql @sqlstr  ,@param,@tchid=@chid


GO

-- ----------------------------
-- Procedure structure for Up_Create_GetColumn_Info
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Create_GetColumn_Info]
GO
CREATE PROCEDURE [dbo].[Up_Create_GetColumn_Info]   
@tablename nvarchar(50),  
@colidstr nvarchar(2000),  
@pageindex Int,  
@pagesize Int  
as 
declare @fieldstr nvarchar(1000)
set @fieldstr = ' i.*,m.modelid,m.tablename,m.uploadpath,ch.chid,ch.typename,ch.chname,ch.dirName,ch.infosorttype,ch.filenametype,ch.isstatictype,colisopened=co.isopened,co.colName,co.coldirname '
declare @tablestr nvarchar(400)
set @tablestr = ' ['+@tableName+'] as i join kycolumn co on i.colid=co.colid join kychannel ch on co.chid=ch.chid join kymodel m on ch.modeltype=m.modelid '
declare @wherestr nvarchar(2000)
set @wherestr = ' i.colid in('+@colidstr+') and i.status=3 and i.isdeleted=0 '
declare @sqlstr nvarchar(2000)
if(@pageindex=1)
	set @sqlstr ='select top '+convert(nvarchar(15),@pagesize)+@fieldstr+'from'+@tablestr+'where'+@wherestr+'order by i.[id] desc'
else
	set @sqlstr ='select top '+convert(nvarchar(15),@pagesize)+@fieldstr+'from'+@tablestr+'where i.[id]<(select min(o.[id]) from(select top '+convert(nvarchar(15),(@pageindex-1)*@pagesize)+' i.[id] from'+@tablestr+'where'+@wherestr+'order by i.[id] desc)o) and '+@wherestr+'order by i.[id] desc'
execute sp_executesql @sqlstr
GO

-- ----------------------------
-- Procedure structure for Up_Create_GetColumn_InfoList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Create_GetColumn_InfoList]
GO
CREATE procedure [dbo].[Up_Create_GetColumn_InfoList]
@tablename nvarchar(50),
@infocount int,
@colidstr nvarchar(1000),
@typestr nvarchar(1000),
@datestr datetime,
@orderstr nvarchar(50)
as
declare @fieldstr nvarchar(1000)
set @fieldstr = ' i.*,m.modelid,m.tablename,m.uploadpath,ch.chid,ch.typename,ch.chname,ch.dirName,ch.infosorttype,ch.filenametype,ch.isstatictype,colisopened=co.isopened,co.colName,co.coldirname '
declare @tablestr nvarchar(400)
set @tablestr = ' ['+@tableName+'] as i join kycolumn co on i.colid=co.colid join kychannel ch on co.chid=ch.chid join kymodel m on ch.modeltype=m.modelid '
declare @topnum nvarchar(50)
set @topnum = '';
if(@infocount!='')
	set @topnum = ' top '+convert(nvarchar(15),@infocount)+' ';
declare @wherestr nvarchar(2000)
set @wherestr = '';
if(@typestr!='')
	set @wherestr = @wherestr+@typestr+' and '
if(@datestr!='')
	set @wherestr = @wherestr+' i.addtime>=@tdatestr and '
set @wherestr=@wherestr+' i.colid in('+@colidstr+') and i.status=3 and i.isdeleted=0 '
declare @sqlstr nvarchar(1000)
set @sqlstr = 'select '+@topnum+@fieldstr+'from'+@tablestr+'where'+@wherestr+' order by '+@orderstr
declare @param nvarchar(500)
set @param = '@tdatestr datetime'
execute sp_executesql @sqlstr,@param,@tdatestr=@datestr
GO

-- ----------------------------
-- Procedure structure for Up_Create_GetDateRange_Info
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Create_GetDateRange_Info]
GO
CREATE PROCEDURE [dbo].[Up_Create_GetDateRange_Info] 
@tablename nvarchar(50),
@startdate nvarchar(15),
@enddate nvarchar(15),
@pageindex Int,
@pagesize Int
as
declare @fieldstr nvarchar(1000)
set @fieldstr = ' i.*,m.modelid,m.tablename,m.uploadpath,ch.chid,ch.typename,ch.chname,ch.dirName,ch.infosorttype,ch.filenametype,ch.isstatictype,colisopened=co.isopened,co.colName,co.coldirname '
declare @tablestr nvarchar(400)
set @tablestr = ' ['+@tableName+'] as i join kycolumn co on i.colid=co.colid join kychannel ch on co.chid=ch.chid join kymodel m on ch.modeltype=m.modelid '
declare @wherestr nvarchar(400)
set @wherestr = ' (i.addtime>=@tstartdate and i.addtime<=@tenddate) and i.status=3 and i.isdeleted=0 '
declare @sqlstr nvarchar(2000)
if(@pageindex=1)
	set @sqlstr ='select top '+convert(nvarchar(15),@pagesize)+@fieldstr+'from'+@tablestr+'where'+@wherestr+'order by i.[id] desc'
else
	set @sqlstr ='select top '+convert(nvarchar(15),@pagesize)+@fieldstr+'from'+@tablestr+'where i.[id]<(select min(o.[id]) from(select top '+convert(nvarchar(15),(@pageindex-1)*@pagesize)+' i.[id] from'+@tablestr+'where'+@wherestr+'order by i.[id] desc)o) and '+@wherestr+'order by i.[id] desc'
declare @param nvarchar(400)
set @param = '@tstartdate datetime,@tenddate datetime'
execute sp_executesql @sqlstr,@param,@tstartdate=@startdate,@tenddate=@enddate
GO

-- ----------------------------
-- Procedure structure for Up_Create_GetDigCount
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Create_GetDigCount]
GO
create proc [dbo].[Up_Create_GetDigCount]
@modelid int,
@infoid int
as
select digcount from kydig where modelid=@modelid and infoid=@infoid

GO

-- ----------------------------
-- Procedure structure for Up_Create_GetId_Info
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Create_GetId_Info]
GO
CREATE PROCEDURE [dbo].[Up_Create_GetId_Info]   
@tablename nvarchar(50),  
@id int  
as  
declare @fieldstr nvarchar(1000)
set @fieldstr = ' i.*,m.modelid,m.tablename,m.uploadpath,ch.chid,ch.typename,ch.chname,ch.dirName,ch.isdisabled,ch.infosorttype,ch.filenametype,ch.isstatictype,colisopened=co.isopened,co.colName,co.coldirname '
declare @tablestr nvarchar(400)
set @tablestr = ' ['+@tableName+'] as i join kycolumn co on i.colid=co.colid join kychannel ch on co.chid=ch.chid join kymodel m on ch.modeltype=m.modelid '

declare @sqlstr nvarchar(2000)  
set @sqlstr='select '+@fieldstr+' from '+@tablestr+' where i.[id]=@tid and i.isdeleted=0'  
declare @param nvarchar(200)  
set @param = '@tid int'  
execute sp_executesql @sqlstr,@param,@tid=@id
GO

-- ----------------------------
-- Procedure structure for Up_Create_GetIdRange_Info
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Create_GetIdRange_Info]
GO
CREATE PROCEDURE [dbo].[Up_Create_GetIdRange_Info]  
@tablename nvarchar(50),   
@startid int,  
@endid int,  
@pageindex int,  
@pagesize int  
AS  
declare @sqlstr nvarchar(4000);
declare @wherestr nvarchar(2000)
set @wherestr = ' i.status=3 and i.isdeleted=0 and i.[id] in(select [id] from ['+@tablename+'] where [id]>=@tstartid and [id]<=@tendid) '
declare @fieldstr nvarchar(500);
set @fieldstr = ' i.*,m.modelid,m.tablename,m.uploadpath,ch.chid,ch.typename,ch.chname,ch.dirName,ch.infosorttype,ch.filenametype,ch.isstatictype,colisopened=co.isopened,co.colName,co.coldirname '
declare @tablestr nvarchar(400)
set @tablestr = ' ['+@tableName+'] as i join kycolumn co on i.colid=co.colid join kychannel ch on co.chid=ch.chid join kymodel m on ch.modeltype=m.modelid '
if(@pageindex=1)
	set @sqlstr='select top '+convert(nvarchar(15),@pagesize)+@fieldstr+'from'+@tablestr+'where'+@wherestr+'order by i.[id] desc'
else
	set @sqlstr='select top '+convert(nvarchar(15),@pagesize)+@fieldstr+'from'+@tablestr+'where'+@wherestr+'and i.[id]<(select min(id) from(select top '+convert(nvarchar(15),(@pageindex-1)*@pagesize)+' i.[id] from'+@tablestr+'where'+@wherestr+' order by i.[id] desc )o) order by i.[id] desc'
declare @param nvarchar(400)
set @param = '@tstartid int,@tendid int'
execute sp_executesql @sqlstr,@param,@tstartid=@startid,@tendid=@endid
GO

-- ----------------------------
-- Procedure structure for Up_Create_GetNewRange_Info
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Create_GetNewRange_Info]
GO
CREATE PROCEDURE [dbo].[Up_Create_GetNewRange_Info]  
@tablename nvarchar(50),   
@topnum int,  
@pageIndex Int,  
@pagesize Int  
AS  
declare @sqlstr nvarchar(2000);  
declare @fieldstr nvarchar(500);
set @fieldstr = ' i.*,m.modelid,m.tablename,m.uploadpath,ch.chid,ch.typename,ch.chname,ch.dirName,ch.infosorttype,ch.filenametype,ch.isstatictype,colisopened=co.isopened,co.colName,co.coldirname '
declare @tablestr nvarchar(400)
set @tablestr = ' ['+@tableName+'] as i join kycolumn co on i.colid=co.colid join kychannel ch on co.chid=ch.chid join kymodel m on ch.modeltype=m.modelid '
declare @wherestr nvarchar(400)
set @wherestr = ' where i.status=3 and i.isdeleted=0 '
declare @subsqlstr nvarchar(1000) 
set @subsqlstr = ' select top '+convert(nvarchar(15),@topnum)+@fieldstr+'from'+@tablestr+@wherestr+' order by i.[id] desc '
if(@pageindex=1)
	set @sqlstr = 'select top '+convert(nvarchar(15),@pagesize)+' * from('+@subsqlstr+')o order by o.[id] desc'
else
	set @sqlstr = 'select top '+convert(nvarchar(15),@pagesize)+' * from('+@subsqlstr+')o where o.[id]<(select min([id]) from(select top '+convert(nvarchar(15),(@pageindex-1)*@pagesize)+' k.[id] from ('+@subsqlstr+')k)p) order by o.[id] desc'
execute sp_executesql @sqlstr
GO

-- ----------------------------
-- Procedure structure for Up_Create_Info_RelationInfoList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Create_Info_RelationInfoList]
GO
create proc [dbo].[Up_Create_Info_RelationInfoList]
@tablename nvarchar(50),
@infocount int,
@wherestr nvarchar(2000)
as
declare @fieldstr nvarchar(1000)
set @fieldstr = ' i.*,m.modelid,m.tablename,m.uploadpath,ch.chid,ch.typename,ch.chname,ch.dirName,ch.infosorttype,ch.filenametype,ch.isstatictype,colisopened=co.isopened,co.colName,co.coldirname '
declare @tablestr nvarchar(400)
set @tablestr = ' ['+@tableName+'] as i join kycolumn co on i.colid=co.colid join kychannel ch on co.chid=ch.chid join kymodel m on ch.modeltype=m.modelid '
declare @sqlstr nvarchar(4000)
set @sqlstr = 'select top '+convert(nvarchar(15),@infocount)+@fieldstr+'from'+@tablestr+'where i.status=3 and i.isdeleted=0 '+@wherestr+' order by i.[id] desc'
execute sp_executesql @sqlstr

GO

-- ----------------------------
-- Procedure structure for Up_Create_InfoRecordCount
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Create_InfoRecordCount]
GO
CREATE Proc [dbo].[Up_Create_InfoRecordCount]
@InputStr Nvarchar(2000),
@tableName Nvarchar(200),
@RecordCount Int output
As
Declare @WhereStr Nvarchar(2000);
Declare @SqlStr Nvarchar(2000);
Declare @Param Nvarchar(50)

Set @Param=N'@TRecordCount int output'
Set @WhereStr=Convert(Nvarchar(200),@tableName)+' as i,KyChannel as ch,KyColumn as co where co.Chid=ch.ChId and i.colid=co.colid and i.status=3 and i.isdeleted=0 ';
set @SqlStr=N'Select @TRecordCount=Count(i.Id) From '+@WhereStr+Convert(Nvarchar(2000),@InputStr);
Execute SP_ExecuteSql @SqlStr,@Param,@TRecordCount=@RecordCount output
GO

-- ----------------------------
-- Procedure structure for Up_Create_Irregular_GetInfoList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Create_Irregular_GetInfoList]
GO
CREATE proc [dbo].[Up_Create_Irregular_GetInfoList]
@chid int,
@tablename nvarchar(50),
@pageindex int,
@pagesize int
as



declare @wherestr nvarchar(400)
set @wherestr = '';
if(@tablename='kyarticle')
	set @wherestr = ' ch.chid=@tchid and i.isirregular=1 and i.status=3 and i.isdeleted=0 '
else
	set @wherestr = ' ch.chid=@tchid and i.status=3 and i.isdeleted=0  '

declare @sqlstr nvarchar(3000)
declare @param nvarchar(400)
declare @tablestr nvarchar(500)
set @tablestr = ' ['+@tablename+'] i join kycolumn co on i.[colid]=co.[colid] join kychannel ch on co.[chid]=ch.[chid] '
set @param = '@tchid int'
if(@pageindex=1)
	set @sqlstr='select top '+convert(nvarchar(15),@pagesize)+' co.colname,i.id,i.colid,i.title,i.addtime from '+@tablestr+'  where '+@wherestr+' order by i.addtime desc'
else
	set @sqlstr='select top '+convert(nvarchar(15),@pagesize)+' co.colname,i.id,i.colid,i.title,i.addtime from '+@tablestr+' where '+@wherestr+' and i.[id]<(select min(o.id) from(select top '+convert(nvarchar(15),(@pageindex-1)*@pagesize)+' i.[id] from '+@tablestr+' where '+@wherestr+' order by i.addtime desc)o) order by i.addtime desc'
execute sp_executesql @sqlstr,@param,@tchid=@chid
set @sqlstr = 'select count(*) from '+@tablestr +' where '+@wherestr
execute sp_executesql @sqlstr,@param,@tchid=@chid
GO

-- ----------------------------
-- Procedure structure for Up_Create_ListInfoCount
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Create_ListInfoCount]
GO
CREATE proc [dbo].[Up_Create_ListInfoCount]
@tablename nvarchar(50),
@topnum int
as
declare @recordcount int
declare @sqlstr nvarchar(2000)
set @sqlstr = 'select count(i.[id]) from(select top '+convert(nvarchar(15),@topnum)+' [id] from ['+@tablename+'] where status=3 and isdeleted=0 order by id desc)i'
execute sp_executesql @sqlstr

GO

-- ----------------------------
-- Procedure structure for Up_Create_SetDigCount
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Create_SetDigCount]
GO
CREATE Proc [dbo].[Up_Create_SetDigCount]
@modelid int,
@infoid int
as
if exists(select * from kydig where modelid=@modelid and infoid=@infoid)
update kydig set digcount=digcount+1 where modelid=@modelid and infoid=@infoid
else
insert into kydig(modelid,infoid,digcount)
select @modelid,@infoid,1

GO

-- ----------------------------
-- Procedure structure for Up_CustomField_SubmitNum
-- ----------------------------
DROP PROCEDURE [dbo].[Up_CustomField_SubmitNum]
GO
CREATE PROCEDURE [dbo].[Up_CustomField_SubmitNum]
	@TableName nvarchar(50),
	@UId int
AS
	Declare @sqlstr nvarchar(500)
	set @sqlstr='select * from ['+@TableName+'] where UId='+Convert(Nvarchar(100),@UId)+' order by Id desc'
	execute sp_executesql @sqlstr
	RETURN

GO

-- ----------------------------
-- Procedure structure for Up_CustomForm_Add
-- ----------------------------
DROP PROCEDURE [dbo].[Up_CustomForm_Add]
GO
CREATE PROCEDURE [dbo].[Up_CustomForm_Add]
@ShowForm int ,
@FormName nvarchar(100) ,
@TableName nvarchar(100) ,
@UploadPath nvarchar(100) ,
@FormDesc nvarchar(400) ,
@IsUnlockTime bit ,
@StartTime datetime ,
@EndTime datetime ,
@UserGroup nvarchar(200) ,
@IsSubmitNum bit ,
@Money int ,
@IsValidate bit ,
@AddTime datetime 
AS
	INSERT INTO [KyCustomForm]([ShowForm],[FormName],[TableName],[UploadPath],[FormDesc],[IsUnlockTime],[StartTime],[EndTime],[UserGroup],[IsSubmitNum],[Money],[IsValidate],[AddTime]) VALUES(@ShowForm,@FormName,@TableName,@UploadPath,@FormDesc,@IsUnlockTime,@StartTime,@EndTime,@UserGroup,@IsSubmitNum,@Money,@IsValidate,@AddTime)
	RETURN

GO

-- ----------------------------
-- Procedure structure for Up_CustomForm_AddTable
-- ----------------------------
DROP PROCEDURE [dbo].[Up_CustomForm_AddTable]
GO
CREATE PROCEDURE [dbo].[Up_CustomForm_AddTable]
 @TableName nvarchar(50)  
AS  
 Declare @sqlstr nvarchar(500)  
set @sqlstr=N'  
CREATE TABLE [dbo].['+@TableName+']   
(  
[Id] [int] IDENTITY (1, 1) PRIMARY Key NOT NULL,  
[UId] [int] NULL ,  
[UName] [nvarchar] (100) COLLATE Chinese_PRC_CI_AS NULL ,  
[Ip] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,  
[AddTime] [datetime] NULL)  
CREATE  INDEX [IX_'+@TableName+'_UId] ON ['+@TableName+']([UId]) ON [PRIMARY]'  
exec sp_executesql @sqlstr  

GO

-- ----------------------------
-- Procedure structure for Up_CustomForm_Delete
-- ----------------------------
DROP PROCEDURE [dbo].[Up_CustomForm_Delete]
GO
CREATE PROCEDURE [dbo].[Up_CustomForm_Delete]
	@CustomFormId int
AS	
	declare @tablename nvarchar(50)
	set @tablename=''
	set @tablename=(select TableName from [KyCustomForm] where [CustomFormId] = @CustomFormId)
	declare @sqlstr nvarchar(500)
	if(@tablename!='')
	begin
		set @sqlstr = N'delete from [KyCustomForm] where [CustomFormId]='+convert(nvarchar(15),@CustomFormId)
		exec sp_executesql @sqlstr
		
		set @sqlstr = N'drop table ['+@tablename+']'
		exec sp_executesql @sqlstr
		
		/*set @sqlstr = N'delete from kymodelfield where ModelId='''+@modelid+''''
  		exec sp_executesql @sqlstr*/
	end
RETURN

GO

-- ----------------------------
-- Procedure structure for Up_CustomForm_GetAll
-- ----------------------------
DROP PROCEDURE [dbo].[Up_CustomForm_GetAll]
GO
CREATE PROCEDURE [dbo].[Up_CustomForm_GetAll]
AS
	select * from [KyCustomForm] order by CustomFormId desc
	RETURN

GO

-- ----------------------------
-- Procedure structure for Up_CustomForm_GetModel
-- ----------------------------
DROP PROCEDURE [dbo].[Up_CustomForm_GetModel]
GO
CREATE PROCEDURE [dbo].[Up_CustomForm_GetModel]
	@CustomFormId int
AS
	select * from [KyCustomForm] where CustomFormId=@CustomFormId
	RETURN

GO

-- ----------------------------
-- Procedure structure for Up_CustomForm_Update
-- ----------------------------
DROP PROCEDURE [dbo].[Up_CustomForm_Update]
GO
CREATE PROCEDURE [dbo].[Up_CustomForm_Update]
@CustomFormId int,
@ShowForm int,
@FormName nvarchar(100),
@TableName nvarchar(100),
@UploadPath nvarchar(100),
@FormDesc nvarchar(400),
@IsUnlockTime bit,
@StartTime datetime,
@EndTime datetime,
@UserGroup nvarchar(200),
@IsSubmitNum bit,
@Money int,
@IsValidate bit,
@AddTime datetime
AS
	UPDATE [KyCustomForm] SET [ShowForm] = @ShowForm,[FormName] = @FormName,[TableName] = @TableName,[UploadPath] = @UploadPath,[FormDesc] = @FormDesc,[IsUnlockTime] = @IsUnlockTime,[StartTime] = @StartTime,[EndTime] = @EndTime,[UserGroup] = @UserGroup,[IsSubmitNum] = @IsSubmitNum,[Money] = @Money,[IsValidate] = @IsValidate,[AddTime] = @AddTime WHERE [CustomFormId] = @CustomFormId
	RETURN

GO

-- ----------------------------
-- Procedure structure for Up_CustomFormField_Add
-- ----------------------------
DROP PROCEDURE [dbo].[Up_CustomFormField_Add]
GO
CREATE PROCEDURE [dbo].[Up_CustomFormField_Add]
@CustomFormId int,
@Name nvarchar(100) ,
@Alias nvarchar(300) ,
@Description nvarchar(400) ,
@IsNotNull bit ,
@IsSearchForm bit ,
@Type nvarchar(100) ,
@Content ntext ,
@IsList bit ,
@IsUserInsert bit ,
@AddDate datetime
AS
	Declare @OrderId int; 
	set @OrderId=(select Max(OrderId) from [KyCustomFormField] where CustomFormId=@CustomFormId)
	
	if @OrderId is null
		set @OrderId=0
	else
		set @OrderId=@OrderId+1
	
	INSERT INTO [KyCustomFormField]([CustomFormId],[Name],[Alias],[Description],[IsNotNull],[IsSearchForm],[Type],[Content],[AddDate],[OrderId],[IsList],[IsUserInsert]) VALUES(@CustomFormId,@Name,@Alias,@Description,@IsNotNull,@IsSearchForm,@Type,@Content,@AddDate,@OrderId,@IsList,@IsUserInsert)
	RETURN
GO

-- ----------------------------
-- Procedure structure for Up_CustomFormField_Del
-- ----------------------------
DROP PROCEDURE [dbo].[Up_CustomFormField_Del]
GO
CREATE PROCEDURE [dbo].[Up_CustomFormField_Del]
	@FieldId int
AS
	delete from [KyCustomFormField] where FieldId=@FieldId
	RETURN
GO

-- ----------------------------
-- Procedure structure for Up_CustomFormField_GetIsUserList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_CustomFormField_GetIsUserList]
GO
CREATE PROCEDURE [dbo].[Up_CustomFormField_GetIsUserList]
	@CustomFormId int
AS
	select * from [KyCustomFormField] where CustomFormId=@CustomFormId and IsUserInsert=1 order by OrderId
	RETURN

GO

-- ----------------------------
-- Procedure structure for Up_CustomFormField_GetList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_CustomFormField_GetList]
GO
CREATE PROCEDURE [dbo].[Up_CustomFormField_GetList]
	@CustomFormId int
AS
	select * from [KyCustomFormField] where CustomFormId=@CustomFormId order by OrderId
	RETURN
GO

-- ----------------------------
-- Procedure structure for Up_CustomFormField_GetModel
-- ----------------------------
DROP PROCEDURE [dbo].[Up_CustomFormField_GetModel]
GO
CREATE PROCEDURE [dbo].[Up_CustomFormField_GetModel]
	@FieldId int=0,
	@CustomFormId int=0,
	@Name nvarchar(50)=" ",
	@TypeId int
AS
	if @TypeId=1
		select * from [KyCustomFormField] where FieldId=@FieldId
	else
		select * from [KyCustomFormField] where CustomFormId=@CustomFormId and [Name]=@Name
	RETURN
GO

-- ----------------------------
-- Procedure structure for Up_CustomFormField_GetTitleList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_CustomFormField_GetTitleList]
GO
CREATE PROCEDURE [dbo].[Up_CustomFormField_GetTitleList]
	@CustomFormId int
AS
	select * from [KyCustomFormField] where IsList=1 and CustomFormId=@CustomFormId order by OrderId
	RETURN

GO

-- ----------------------------
-- Procedure structure for Up_CustomFormField_MoveField
-- ----------------------------
DROP PROCEDURE [dbo].[Up_CustomFormField_MoveField]
GO
CREATE PROCEDURE [dbo].[Up_CustomFormField_MoveField]
	@CustomFormId int,
	@FieldId int,
	@MoveType nvarchar(20)
AS
	Declare @OrderId int;
	Declare @NewFieldId int;
	Declare @NewOrderId int;
	
	if @MoveType='UpMove'
	begin	
		declare @MinOrderId int;
		set @MinOrderId=(select min(OrderId) from [KyCustomFormField] where CustomFormId=@CustomFormId)
		
		set @OrderId=(select OrderId from [KyCustomFormField] where CustomFormId=@CustomFormId and FieldId=@FieldId)
		
		if @OrderId!=@MinOrderId
		begin
			set @NewFieldId=(select top 1 FieldId from [KyCustomFormField] where CustomFormId=@CustomFormId and OrderId<@OrderId order by OrderId desc)
			set @NewOrderId=(select OrderId from [KyCustomFormField] where CustomFormId=@CustomFormId and FieldId=@NewFieldId)
			
			update [KyCustomFormField] set OrderId=@OrderId where FieldId=@NewFieldId and CustomFormId=@CustomFormId
			update [KyCustomFormField] set OrderId=@NewOrderId where FieldId=@FieldId and CustomFormId=@CustomFormId
		end
	end
	
	if @MoveType='DownMove'
	begin
		declare @MaxOrderId int;
		set @MaxOrderId=(select max(OrderId) from [KyCustomFormField] where CustomFormId=@CustomFormId)
		
		set @OrderId=(select OrderId from [KyCustomFormField] where CustomFormId=@CustomFormId and FieldId=@FieldId)
		
		if @OrderId!=@MaxOrderId
		begin
			set @NewFieldId=(select top 1 FieldId from [KyCustomFormField] where CustomFormId=@CustomFormId and OrderId>@OrderId order by OrderId)
			set @NewOrderId=(select OrderId from [KyCustomFormField] where CustomFormId=@CustomFormId and FieldId=@NewFieldId)
			
			update [KyCustomFormField] set OrderId=@OrderId where FieldId=@NewFieldId and CustomFormId=@CustomFormId
			update [KyCustomFormField] set OrderId=@NewOrderId where FieldId=@FieldId and CustomFormId=@CustomFormId
		end
	end
	RETURN

GO

-- ----------------------------
-- Procedure structure for Up_CustomFormField_SelectPropertyTrue
-- ----------------------------
DROP PROCEDURE [dbo].[Up_CustomFormField_SelectPropertyTrue]
GO
CREATE PROCEDURE [dbo].[Up_CustomFormField_SelectPropertyTrue]
	@CustomFormId nvarchar(50)
AS
	select * from [KyCustomFormField] where CustomFormId=@CustomFormId and Type='RadioType' and Content like '%Property=True%' order by OrderId
	RETURN

GO

-- ----------------------------
-- Procedure structure for Up_CustomFormField_Update
-- ----------------------------
DROP PROCEDURE [dbo].[Up_CustomFormField_Update]
GO
CREATE PROCEDURE [dbo].[Up_CustomFormField_Update]
@FieldId int,
@CustomFormId int,
@Alias nvarchar(300),
@Description nvarchar(400),
@IsNotNull bit,
@IsSearchForm bit,
@Content ntext,
@IsList bit ,
@IsUserInsert bit ,
@AddDate datetime
AS
	UPDATE KyCustomFormField SET [Alias] = @Alias,[Description] = @Description,[IsNotNull] = @IsNotNull,[IsSearchForm] = @IsSearchForm,[Content] = @Content,[IsList]=@IsList,[IsUserInsert]=@IsUserInsert,[AddDate] = @AddDate WHERE [FieldId] = @FieldId and CustomFormId=@CustomFormId
	RETURN

GO

-- ----------------------------
-- Procedure structure for Up_CustomTable_GetList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_CustomTable_GetList]
GO
CREATE PROCEDURE [dbo].[Up_CustomTable_GetList]
	@TableName nvarchar(50),
	@CurrPage Int,
	@PageSize Int,
	@strWhere nvarchar(2000)
AS
	Declare @SqlStr Nvarchar(3000);  
	If(@CurrPage=1)
		set @SqlStr=N'Select Top '+Convert(Nvarchar(15),@PageSize)+' * from ['+@TableName+'] '+@strWhere+' order by Id desc';
	Else
		if(@strWhere='')
			set @SqlStr=N'Select Top '+Convert(Nvarchar(15),@PageSize)+' * from ['+@TableName+'] where Id<(Select Min(Id) From (select Top '+Convert(Nvarchar(15),(@CurrPage-1)*@PageSize)+' Id from ['+@TableName+'] '+@strWhere+' order by Id desc)o) order by Id desc'; 
		else
			set @SqlStr=N'Select Top '+Convert(Nvarchar(15),@PageSize)+' * from ['+@TableName+'] '+@strWhere+' and Id<(Select Min(Id) From (select Top '+Convert(Nvarchar(15),(@CurrPage-1)*@PageSize)+' Id from ['+@TableName+'] '+@strWhere+' order by Id desc)o) order by Id desc'; 

	Execute Sp_ExecuteSql @SqlStr  
	Set @SqlStr = N'Select Count(Id) From ['+@TableName+']'+@strWhere;
	Execute Sp_ExecuteSql @SqlStr
GO

-- ----------------------------
-- Procedure structure for Up_Dictionary_Get
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Dictionary_Get]
GO
CREATE PROCEDURE [dbo].[Up_Dictionary_Get]
@Type int,
@PageSize int=20,
@PageIndex int=1,
@WhereStr nvarchar(2000),
@Id int
AS

	declare @SqlStr nvarchar(2000)
	declare @Filter nvarchar(2000)
	if(@WhereStr ='')
	begin
	 set @WhereStr=' where '
	 set @Filter=''
	end 
else
	begin
		set @Filter=' where '+@WhereStr
		set @WhereStr=' where '+@WhereStr+' and '		
	end
	
	if(@Type=1)--根据ID获取单条记录
begin
	select * from KyDictionary where [ID]=@Id
end


if(@Type=2)--获取列表
begin
	if(@PageIndex=1)
		begin
					Set @SqlStr = N'Select Top '+Convert(Nvarchar(10),@PageSize)+' * from KyDictionary '+@Filter +' Order By Sort,[ID] Desc'
		end
	else
		begin
				Set @SqlStr = N'Select Top '+Convert(Nvarchar(10),@PageSize)+' * from KyDictionary '+@WhereStr+' [ID]<(Select Min([ID]) From(Select Top '+Convert(Nvarchar(10),(@PageIndex-1)*@PageSize)+' * from KyDictionary  '+@Filter+' Order By Sort,[ID] Desc)O) order By Sort,[ID] Desc'
		end	
		
	Execute Sp_ExecuteSql @SqlStr
	
	Set @SqlStr = 'select count(*) from KyDictionary '+@Filter
	
	Execute Sp_ExecuteSql @SqlStr
end
GO

-- ----------------------------
-- Procedure structure for Up_Dictionary_Set
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Dictionary_Set]
GO
CREATE PROCEDURE [dbo].[Up_Dictionary_Set]
@Type int,
@Id int,
@ParentId int,
@DicName nvarchar(50),
@Sort int,
@Identity int=0 output --return the identity when add
AS
	if @Type=1--Add
		begin
			insert into KyDictionary values(@ParentId,@DicName,@Sort)
			select @Identity=Scope_Identity()	
		end
	if @Type=2--update
		begin
			update KyDictionary set ParentId=@ParentId,DicName=@DicName,Sort=@Sort where ID=@Id	
		end
	if @Type=3--delete
		begin
			delete from KyDictionary where ID=@Id
		end
GO

-- ----------------------------
-- Procedure structure for Up_DownLoad_GetAddressPath
-- ----------------------------
DROP PROCEDURE [dbo].[Up_DownLoad_GetAddressPath]
GO
CREATE Proc [dbo].[Up_DownLoad_GetAddressPath]
@serverid int,
@addressid int
as
	select c.downloadserverdir,a.addressPath,a.downloaddataid,c.isopened from kydownloadaddress a left join kydownloadserverType b on a.downloadserverid=b.typeid left join kydownloadserverdata c on b.typeid =c.typeid
	where isnull(downloadserverdataid,-1)=@serverid and addressid=@addressid



GO

-- ----------------------------
-- Procedure structure for Up_DownLoad_GetDownCount
-- ----------------------------
DROP PROCEDURE [dbo].[Up_DownLoad_GetDownCount]
GO
create proc [dbo].[Up_DownLoad_GetDownCount]
@id int,
@type int
as
if(@type=1)
	select downloaddownnum from kydownloaddata where [id] = @id
else if(@type=2)
	select downloaddownmonthnum from kydownloaddata where [id] = @id
else if(@type=3)
	select downloaddownweeknum from kydownloaddata where [id] = @id
else
	select downloaddowndaynum from kydownloaddata where [id] = @id 

GO

-- ----------------------------
-- Procedure structure for Up_DownLoad_GetList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_DownLoad_GetList]
GO

CREATE  Procedure [dbo].[Up_DownLoad_GetList]
@SortName Nvarchar(20)='',
@Keyword Nvarchar(50)='',
@ChannelId Int=-1,
@ColumnId nvarchar(500)='-1',

@SoftStatus varchar(50)='-10',
@IsRecommend int=-1,
@IsTop int=-1,
@UserCateId int=-1,

@CurrPage Int=1,
@PageSize int=20,
@UserType int=-1,
@RecordCount int=0 output

As
Declare @WhereStr nvarchar(2000);

Set @WhereStr = '';
if(@SortName!='')
Begin
	Set @WhereStr = @WhereStr+@SortName+' Like ''%'+@Keyword+'%'''+' And';  
End

if(@ChannelId!=-1)
Begin
	Set @WhereStr = @WhereStr+' a.ChId ='+Convert(Nvarchar(15),@ChannelId)+' And';  
End

if(@ColumnId!='-1')
Begin
	Set @WhereStr = @WhereStr+' a.ColId in('+@ColumnId+') And';  
End

if(@SoftStatus!='-10')
Begin
	Set @WhereStr = @WhereStr+' SoftStatus in('+@SoftStatus+') And';  
End


if(@IsRecommend!=-1)
Begin
	Set @WhereStr = @WhereStr+' SoftIsCommand ='+Convert(Nvarchar(15),@IsRecommend)+' And';  
End

If(@IsTop != -1)
Begin
	Set @WhereStr = @WhereStr+' SoftIsTop='+Convert(Nvarchar(15),@IsTop)+' And';  
End

if(@UserCateId!=-1)
begin
	set @WhereStr = @WhereStr+' a.UserCateId ='+convert(nvarchar(15),@UserCateId)+' and ';
end

--投稿
--if(@UserType!=-1)
--begin

	if(@UserType=0)
	begin	
		Set @WhereStr = @WhereStr+ ' UserType=0 and '
	end
	else if(@UserType=-1)
	begin
		set @whereStr = @WhereStr+ ' SoftStatus!=-1 and '
	end
--end

Set @WhereStr = @WhereStr+' a.SoftIsDel=0';





Declare @SqlStr Nvarchar(2000)
if(@CurrPage=1)
	Set @SqlStr = 'Select Top '+Convert(Nvarchar(15),@PageSize)+' a.*,b.colname  From KyDownLoadData a inner join KyColumn b on a.colid=b.colid Where '+@WhereStr+' 

Order By a.ID Desc'
else
	Set @SqlStr = 'Select Top '+Convert(Nvarchar(15),@PageSize)+' a.*,b.colname  From KyDownLoadData a inner join KyColumn b on a.colid=b.colid Where '+@WhereStr+' And 

a.ID <(Select Min(ID) From(Select Top '+Convert(Nvarchar(15),(@CurrPage-1)*@PageSize)+' ID From KyDownLoadData a Where '+@WhereStr+' Order By ID Desc)O) order By a.ID Desc'

Execute Sp_ExecuteSql @SqlStr

Set @SqlStr =' Select @TRecord =Count(a.ID) from KyDownLoadData a inner join KyColumn b on a.colid=b.colid Where '+@WhereStr


Declare @Parm nvarchar(50)
Set @Parm = '@TRecord int output';

Exec Sp_ExecuteSql @SqlStr,@Parm,@TRecord=@RecordCount output;
print @RecordCount
return

GO

-- ----------------------------
-- Procedure structure for Up_DownLoad_IsAllowDeleteType
-- ----------------------------
DROP PROCEDURE [dbo].[Up_DownLoad_IsAllowDeleteType]
GO

CREATE proc [dbo].[Up_DownLoad_IsAllowDeleteType]
@TypeId int
as
select a.[TypeId] from KyDownLoadServerType a inner join KyDownLoadServerData b  on a.[TypeId]=b.TypeId where a.[TypeId]=@TypeId
GO

-- ----------------------------
-- Procedure structure for Up_DownLoad_SetDownCount
-- ----------------------------
DROP PROCEDURE [dbo].[Up_DownLoad_SetDownCount]
GO
create proc [dbo].[Up_DownLoad_SetDownCount]
@id int
as
update kydownloaddata set downloaddownnum=downloaddownnum+1,downloaddownmonthnum=downloaddownmonthnum+1,downloaddownweeknum=downloaddownweeknum+1,downloaddowndaynum=downloaddowndaynum+1
where [id]=@id

GO

-- ----------------------------
-- Procedure structure for Up_DownLoadAddress_GetGroupAddresList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_DownLoadAddress_GetGroupAddresList]
GO
CREATE PROCEDURE [dbo].[Up_DownLoadAddress_GetGroupAddresList] 
@addresnum int,
@downloadserverid int
AS
select * from kydownloadaddress a left join KyDownLoadServerType b on downloadserverid=b.typeid left join KyDownLoadServerData c on b.typeid=c.typeid
where  a.downloaddataid=@addresnum and a.downloadserverid=@downloadserverid
GO

-- ----------------------------
-- Procedure structure for Up_DownLoadAddress_GetInfoBySoftId
-- ----------------------------
DROP PROCEDURE [dbo].[Up_DownLoadAddress_GetInfoBySoftId]
GO
--          drop proc Up_DownLoadAddress_GetAddressInfoBySoftId

create proc [dbo].[Up_DownLoadAddress_GetInfoBySoftId]
@SoftId int
as
select * from KydownloadAddress where DownLoadDataId=@SoftId



GO

-- ----------------------------
-- Procedure structure for Up_DownLoadAddress_Set
-- ----------------------------
DROP PROCEDURE [dbo].[Up_DownLoadAddress_Set]
GO
--          drop proc Up_DownLoadAddress_Set

CREATE PROCEDURE [dbo].[Up_DownLoadAddress_Set]
@AddressId int output,
@DownLoadDataId int ,
@AddressNum int ,
@DownLoadServerID int ,
@AddressName nvarchar(100) ,
@AddressPath nvarchar(100)  
 AS 
if(@AddressId=0)
begin
	INSERT INTO KyDownLoadAddress(
	[DownLoadDataId],[AddressNum],[DownLoadServerID],[AddressName],[AddressPath]
	)VALUES(
	@DownLoadDataId,@AddressNum,@DownLoadServerID,@AddressName,@AddressPath
	)
	SET @AddressId=Scope_identity()
end
else
begin
	UPDATE KyDownLoadAddress SET 
	[DownLoadDataId] = @DownLoadDataId,[AddressNum] = @AddressNum,[DownLoadServerID] = @DownLoadServerID,[AddressName] = @AddressName,[AddressPath] = @AddressPath
	WHERE [AddressId] = @AddressId
end



GO

-- ----------------------------
-- Procedure structure for Up_DownLoadData_ClearDownCount
-- ----------------------------
DROP PROCEDURE [dbo].[Up_DownLoadData_ClearDownCount]
GO
Create proc [dbo].[Up_DownLoadData_ClearDownCount]
as
update [kydownloaddata] set downloaddownmonthnum=0,monthcounttime=getdate() where DateDiff(month,monthcounttime,getdate())!=0 
update [kydownloaddata] set downloaddownweeknum=0,weekcounttime=getdate() where DateDiff(week,weekcounttime,getdate())!=0
update [kydownloaddata] set downloaddowndaynum=0,daycounttime=getdate() where DateDiff(day,daycounttime,getdate())!=0

GO

-- ----------------------------
-- Procedure structure for Up_DownLoadData_Delete
-- ----------------------------
DROP PROCEDURE [dbo].[Up_DownLoadData_Delete]
GO
--          drop proc Up_DownLoadData_Delete

create proc [dbo].[Up_DownLoadData_Delete]
@IDstr nvarchar(2000),
@Option varchar(50)
as

Declare @SqlStr nvarchar(2000)

--彻底删除
if(@Option='Delete')
begin
	Set @SqlStr = 'Delete from KyDownLoadData Where Id in('+@IDstr+')'
end

--还原
if(@Option='Recycle')
begin
	Set @SqlStr = 'update KyDownLoadData set SoftIsDel=0 Where Id in('+@IDstr+')'
end

--删除到回收站
if(@Option='DeletedToRecycle')
begin
	Set @SqlStr = 'update KyDownLoadData set SoftIsDel=1 Where Id in('+@IDstr+')'
end
exec sp_executesql @SqlStr


GO

-- ----------------------------
-- Procedure structure for Up_DownLoadData_GetDataById
-- ----------------------------
DROP PROCEDURE [dbo].[Up_DownLoadData_GetDataById]
GO

CREATE PROCEDURE [dbo].[Up_DownLoadData_GetDataById]


@Id int
 AS 
	SELECT  * FROM KyDownLoadData
	 WHERE [Id] = @Id
GO

-- ----------------------------
-- Procedure structure for Up_DownLoadData_Set
-- ----------------------------
DROP PROCEDURE [dbo].[Up_DownLoadData_Set]
GO
CREATE PROCEDURE [dbo].[Up_DownLoadData_Set]
@Id int output,
@ColId int ,
@Title nvarchar(200) ,
@TitleColor nvarchar(6)='' ,
@TitleFontType int ,
@TitleType int ,
@TitleImgPath varchar(255) ='' ,
@UId int ,
@UName nvarchar(20) ='' ,
@UserType int ,
@AdminUId int ,
@AdminUName nvarchar(20) ='' ,
@Status int ,
@HitCount int ,
@AddTime datetime ,
@UpdateTime datetime ,
@TemplatePath varchar(255)='' ,
@PageType int ,
@IsCreated bit ,
@UserCateId int ,
@PointCount int ,
@ChargeType int ,
@ChargeHourCount int ,
@ChargeViewCount int ,
@IsOpened int ,
@GroupIdStr varchar(200) ='' ,
@IsDeleted bit ,
@IsRecommend bit ,
@IsTop bit ,
@IsFocus bit ,
@IsSideShow bit ,
@TagIdStr varchar(300) ='' ,
@TagNameStr nvarchar(300) ='' ,
@SpecialIdStr varchar(200) ='' ,
@Content nvarchar(500) ,
@Edition nvarchar(50) ,
@PlayAddress nvarchar(100) ='' ,
@DownLoadDownNum int ,
@DownLoadDownMonthNum int ,
@DownLoadDownWeekNum int ,
@DownLoadDownDayNum int ,
@DownLoadOS nvarchar(100) ='' ,
@DownLoadServerDataId int,
@Language nvarchar(50) ='' ,
@WarrantType nvarchar(50) ='' ,
@DownLoadSize nvarchar(50) ='' ,
@RegAddress nvarchar(100) ='' ,
@Plugin nvarchar(20) ='' ,
@DownLoadStarLevel nvarchar(50) ='' ,
@DownLoadDisplePwd nvarchar(50) ='',
@DownLoadType nvarchar(50) ='',
@IsAllowComment bit
 AS
if(@Id=0)
begin
	INSERT INTO KyDownLoadData(
	[ColId],[Title],[TitleColor],[TitleFontType],[TitleType],[TitleImgPath],[UId],[UName],[UserType],[AdminUId],[AdminUName],[Status],[HitCount],[AddTime],[UpdateTime],[TemplatePath],[PageType],[IsCreated],[UserCateId],[PointCount],[ChargeType],[ChargeHourCount],[ChargeViewCount],[IsOpened],[GroupIdStr],[IsDeleted],[IsRecommend],[IsTop],[IsFocus],[IsSideShow],[TagIdStr],[TagNameStr],[SpecialIdStr],[Content],[Edition],[PlayAddress],[DownLoadDownNum],[DownLoadDownMonthNum],[DownLoadDownWeekNum],[DownLoadDownDayNum],[DownLoadOS],[DownLoadServerDataId],[Language],[WarrantType],[DownLoadSize],[RegAddress],[Plugin],[DownLoadStarLevel],[DownLoadDisplePwd],[DownLoadType],[IsAllowComment]
	)VALUES(
	@ColId,@Title,@TitleColor,@TitleFontType,@TitleType,@TitleImgPath,@UId,@UName,@UserType,@AdminUId,@AdminUName,@Status,@HitCount,@AddTime,@UpdateTime,@TemplatePath,@PageType,@IsCreated,@UserCateId,@PointCount,@ChargeType,@ChargeHourCount,@ChargeViewCount,@IsOpened,@GroupIdStr,@IsDeleted,@IsRecommend,@IsTop,@IsFocus,@IsSideShow,@TagIdStr,@TagNameStr,@SpecialIdStr,@Content,@Edition,@PlayAddress,@DownLoadDownNum,@DownLoadDownMonthNum,@DownLoadDownWeekNum,@DownLoadDownDayNum,@DownLoadOS,@DownLoadServerDataId,@Language,@WarrantType,@DownLoadSize,@RegAddress,@Plugin,@DownLoadStarLevel,@DownLoadDisplePwd,@DownLoadType,@IsAllowComment
	)
	SET @ID = scope_identity()
end
else
begin
	UPDATE KyDownLoadData SET 
	[ColId] = @ColId,[Title] = @Title,[TitleColor] = @TitleColor,[TitleFontType] = @TitleFontType,[TitleType] = @TitleType,[TitleImgPath] = @TitleImgPath,[HitCount] = @HitCount,[UpdateTime] = @UpdateTime,[TemplatePath] = @TemplatePath,[PageType] = @PageType,[PointCount] = @PointCount,[ChargeType] = @ChargeType,[ChargeHourCount] = @ChargeHourCount,[ChargeViewCount] = @ChargeViewCount,[IsOpened] = @IsOpened,[GroupIdStr] = @GroupIdStr,[IsRecommend] = @IsRecommend,[IsTop] = @IsTop,[IsFocus] = @IsFocus,[IsSideShow]=@IsSideShow,[TagIdStr] = @TagIdStr,[TagNameStr] = @TagNameStr,[SpecialIdStr] = @SpecialIdStr,[Content] = @Content,[Edition] = @Edition,[PlayAddress] = @PlayAddress,[DownLoadDownNum] = @DownLoadDownNum,[DownLoadDownMonthNum] = @DownLoadDownMonthNum,[DownLoadDownWeekNum] = @DownLoadDownWeekNum,[DownLoadDownDayNum] = @DownLoadDownDayNum,[DownLoadOS] = @DownLoadOS,[DownLoadServerDataId] = @DownLoadServerDataId,[Language] = @Language,[WarrantType] = @WarrantType,[DownLoadSize] = @DownLoadSize,[RegAddress] = @RegAddress,[Plugin] = @Plugin,[DownLoadStarLevel] = @DownLoadStarLevel,[DownLoadDisplePwd] = @DownLoadDisplePwd,[DownLoadType]=@DownLoadType,[IsAllowComment]=@IsAllowComment
	WHERE [Id] = @Id
end
GO

-- ----------------------------
-- Procedure structure for Up_DownLoadServerData_Delete
-- ----------------------------
DROP PROCEDURE [dbo].[Up_DownLoadServerData_Delete]
GO
--          drop proc Up_DownLoadServerData_Delete

create proc [dbo].[Up_DownLoadServerData_Delete]
@DownLoadServerDataId int
 AS 
	DELETE KyDownLoadServerData
	 WHERE [DownLoadServerDataId] = @DownLoadServerDataId


GO

-- ----------------------------
-- Procedure structure for Up_DownLoadserverData_GetInfo
-- ----------------------------
DROP PROCEDURE [dbo].[Up_DownLoadserverData_GetInfo]
GO
--          drop proc Up_DownLoadserverData_GetInfo

CREATE proc [dbo].[Up_DownLoadserverData_GetInfo]
@DownLoadServerDataId int
 AS 
	SELECT 
	[DownLoadServerDataId],[TypeId],[DownLoadServerName],[DownLoadServerDir],[IsOpened],[IsOuter],[UnionId],[DayDownNum],[AllDownNum],[AddTime]
	 FROM KyDownLoadServerData
	 WHERE [DownLoadServerDataId] = @DownLoadServerDataId

GO

-- ----------------------------
-- Procedure structure for Up_DownLoadServerData_GetList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_DownLoadServerData_GetList]
GO
--          drop proc Up_DownLoadServerData_GetList

CREATE PROCEDURE [dbo].[Up_DownLoadServerData_GetList]
@TypeId Int
 AS 
	SELECT 
	[DownLoadServerDataId],D.[TypeId],[DownLoadServerName],[DownLoadServerDir],[IsOpened],[IsOuter],[UnionId],[DayDownNum],[AllDownNum],[AddTime],T.[TypeName],T.[TypeId]
	 FROM KyDownLoadServerData D join KyDownLoadServerType T on D.TypeId=T.[TypeId] where D.TypeId=@TypeId

GO

-- ----------------------------
-- Procedure structure for Up_DownLoadServerData_Set
-- ----------------------------
DROP PROCEDURE [dbo].[Up_DownLoadServerData_Set]
GO
--          drop proc Up_DownLoadServerData_Set

CREATE PROCEDURE [dbo].[Up_DownLoadServerData_Set]
@DownLoadServerDataId int=0,
@TypeId int ,
@DownLoadServerName nvarchar(100) ,
@DownLoadServerDir nvarchar(100) ,
@IsOpened bit ,
@IsOuter int ,
@UnionId text='' ,
@DayDownNum int=0 ,
@AllDownNum int=0 ,
@AddTime datetime
 AS 
if(@DownLoadServerDataId=0)
begin
	INSERT INTO KyDownLoadServerData(
	[TypeId],[DownLoadServerName],[DownLoadServerDir],[IsOpened],[IsOuter],[UnionId],[DayDownNum],[AllDownNum],[AddTime]
	)VALUES(
	@TypeId,@DownLoadServerName,@DownLoadServerDir,@IsOpened,@IsOuter,@UnionId,@DayDownNum,@AllDownNum,@AddTime
	)
	Set @DownLoadServerDataId=Scope_identity()
end
else
begin
	UPDATE KyDownLoadServerData SET 
	[TypeId] = @TypeId,[DownLoadServerName] = @DownLoadServerName,[DownLoadServerDir] = @DownLoadServerDir,[IsOpened] = @IsOpened,[IsOuter] = @IsOuter,[UnionId] = @UnionId,[DayDownNum] = @DayDownNum,[AllDownNum] = @AllDownNum,[AddTime] = @AddTime
	WHERE [DownLoadServerDataId] = @DownLoadServerDataId
end


GO

-- ----------------------------
-- Procedure structure for Up_DownLoadServerData_SetIsOpened
-- ----------------------------
DROP PROCEDURE [dbo].[Up_DownLoadServerData_SetIsOpened]
GO
create proc [dbo].[Up_DownLoadServerData_SetIsOpened]
@DownServerId int,
@IsOpened bit
as 
update KyDownLoadServerData set IsOpened=@IsOpened where DownLoadServerDataId=@DownServerId



GO

-- ----------------------------
-- Procedure structure for Up_DownLoadServerType_Delete
-- ----------------------------
DROP PROCEDURE [dbo].[Up_DownLoadServerType_Delete]
GO
--          drop proc Up_DownLoadServerType_Delete

CREATE proc [dbo].[Up_DownLoadServerType_Delete]
@TypeId int
as 
delete from KyDownLoadServerType where TypeId=@TypeId



GO

-- ----------------------------
-- Procedure structure for Up_DownLoadServerType_GetInfo
-- ----------------------------
DROP PROCEDURE [dbo].[Up_DownLoadServerType_GetInfo]
GO
CREATE proc [dbo].[Up_DownLoadServerType_GetInfo]
@TypeId int
as
select * from KyDownLoadServerType where typeid=@TypeId


GO

-- ----------------------------
-- Procedure structure for UP_DownLoadServerType_GetList
-- ----------------------------
DROP PROCEDURE [dbo].[UP_DownLoadServerType_GetList]
GO

CREATE PROCEDURE [dbo].[UP_DownLoadServerType_GetList]
 AS 
	SELECT *  FROM KyDownLoadServerType
GO

-- ----------------------------
-- Procedure structure for Up_DownLoadServerType_Set
-- ----------------------------
DROP PROCEDURE [dbo].[Up_DownLoadServerType_Set]
GO
--          drop proc Up_DownLoadServerType_Set

CREATE PROCEDURE [dbo].[Up_DownLoadServerType_Set]
@TypeId int output,
@TypeName nvarchar(100)
 AS 
if(@TypeId=0)
begin
	INSERT INTO KyDownLoadServerType(
	[TypeName]
	)VALUES(
	@TypeName
	)
end
else
begin
	UPDATE KyDownLoadServerType SET 
	[TypeName] = @TypeName
	WHERE [TypeId] = @TypeId
end


GO

-- ----------------------------
-- Procedure structure for Up_Enterprise_Delete
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Enterprise_Delete]
GO
CREATE PROCEDURE [dbo].[Up_Enterprise_Delete]
@IdStr nvarchar(1000),
@UserId int
 AS 
declare @sqlstr nvarchar(4000)
set @sqlstr = 'delete kyenterprise where [id] in('+@idstr+') and userid=@temp_userid'
declare @param nvarchar(400)
set @param='@temp_userid int '
execute sp_executesql @sqlstr,@param,@temp_userid=@userid


GO

-- ----------------------------
-- Procedure structure for Up_Enterprise_GetById
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Enterprise_GetById]
GO
CREATE PROCEDURE [dbo].[Up_Enterprise_GetById]
@Id int,
@UserId int
 AS 
	SELECT * FROM KyEnterprise
	 WHERE [Id] = @Id and UserId=@UserId

GO

-- ----------------------------
-- Procedure structure for Up_Enterprise_GetByUserId
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Enterprise_GetByUserId]
GO
CREATE Proc [dbo].[Up_Enterprise_GetByUserId]
@UserId int,
@PageIndex int=1,
@PageSize int=10,
@RecordCount int=0 output
AS
declare @sqlstr Nvarchar(4000)
if(@PageIndex=1)
	set @sqlstr =N'select top '+Convert(Nvarchar(15),@PageSize)+' * from KyEnterprise where UserId='+Convert(Nvarchar(15),@UserId)+' order by Id desc'
else
	set @sqlstr =N'select top '+Convert(Nvarchar(15),@PageSize)+' * from KyEnterprise where UserId='+Convert(Nvarchar(15),@UserId)+' 
	and id<(select min(o.id) from(select top '+Convert(Nvarchar(15),(@PageIndex-1)*@PageSize)+' id from KyEnterprise where
	 UserId='+Convert(Nvarchar(15),@UserId)+' order by Id desc)o) order by Id desc'
execute sp_executesql @sqlstr
--print @sqlstr
set @sqlstr='select count(Id) from KyEnterprise where UserId='+Convert(Nvarchar(15),@UserId)
execute sp_executesql @sqlstr
--print @sqlstr




GO

-- ----------------------------
-- Procedure structure for Up_EnterPrise_Set
-- ----------------------------
DROP PROCEDURE [dbo].[Up_EnterPrise_Set]
GO
CREATE PROCEDURE [dbo].[Up_EnterPrise_Set]
@Id int output,
@UserId int ,
@Title nvarchar(200) ,
@Conetent text ,
@AddTime nvarchar(50) ,
@TypeId int
 AS 
if(@Id=0)
begin
	INSERT INTO KyEnterprise(
	[UserId],[Title],[Conetent],[AddTime],[TypeId]
	)VALUES(
	@UserId,@Title,@Conetent,@AddTime,@TypeId
	)
	SET @Id = scope_identity()
end
else
begin
	UPDATE  KyEnterprise set [Title]=@Title,[Conetent]=@Conetent,[TypeId]=@TypeId where Id=@Id
end
GO

-- ----------------------------
-- Procedure structure for Up_Feedback_Add
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Feedback_Add]
GO

CREATE PROCEDURE [dbo].[Up_Feedback_Add] 
@ParentId int,
@title nvarchar(100) ,
@author nvarchar(20),
@reward int,
@scoring int,
@categoryId int,
@content ntext,
@state int,
@replyDate datetime,
@EndDate datetime,
@IP nvarchar(15)
 AS 

	set Xact_Abort on
	begin tran
	if @ParentId=0--新增一个主题
		begin 
			INSERT INTO KyFeedback(
			[ParentId],[title],[author],[reward],[scoring],[categoryId],[content],[state],[replyDate],[EndDate],[IP]
			)VALUES(
			@ParentId,@title,@author,@reward,@scoring,@categoryId,@content,@state,@replyDate,@EndDate,@IP
			)	
			
				
		end
	else--新增一个回复
		begin
			INSERT INTO KyFeedback(
			[ParentId],[author],[scoring],[content],[replyDate],[IP]
			)VALUES(
			@ParentId,@author,@scoring,@content,@replyDate,@IP
			)
		end
		commit tran
	


GO

-- ----------------------------
-- Procedure structure for Up_Feedback_Count
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Feedback_Count]
GO
CREATE PROCEDURE [dbo].[Up_Feedback_Count]
as
 
select count(id) as total from KyFeedback where ParentId=0

select count(id) as finished from KyFeedback where parentId=0 and state=1 or state=2

select Count(id) as answing from KyFeedback where parentId=0 and state=0

GO

-- ----------------------------
-- Procedure structure for Up_Feedback_Delete
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Feedback_Delete]
GO

CREATE PROCEDURE [dbo].[Up_Feedback_Delete] 
	@FeedbackId int
AS
	set Xact_Abort on
	begin tran
		delete from KyFeedback where [ID]=@FeedbackId
		if exists(select Id from KyFeedback where parentId=@FeedbackId)
			delete from KyFeedback where parentId=@FeedbackId
	commit tran


GO

-- ----------------------------
-- Procedure structure for Up_Feedback_GetFeedback
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Feedback_GetFeedback]
GO

CREATE PROCEDURE [dbo].[Up_Feedback_GetFeedback]
@FeedbackID int,
@Type int,
@author nvarchar(20)--此问答的发起者
AS

if @Type=1 -- select data
	begin

	select * from KyFeedback where Id=@FeedbackID
	
	select * from KyFeedback where parentId=@FeedbackID
	
	end
	
if @Type = 2 --select distinct replyers

	begin
		select author,Id from KyFeedback where parentId=@FeedbackID and author !=@author
	end
	
if @Type =3 --select top 10 highest scoring replyer
	begin
		
select top 10 author,scoring,sum(scoring) as [Sum] from KyFeedback 
where scoring>0 
group by author,scoring 
order by scoring desc 
	end
	
	


GO

-- ----------------------------
-- Procedure structure for Up_Feedback_GetList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Feedback_GetList]
GO

CREATE PROCEDURE [dbo].[Up_Feedback_GetList] 
@PageSize int=20,
@PageIndex int=1,
@WhereStr nvarchar(200)
AS
	declare @SqlStr nvarchar(2000)
	declare @fff nvarchar(200)
	if(@WhereStr ='')
	begin
	 set @WhereStr=' where '
	 set @fff=''
	end 
else
	begin
		set @fff=' where '+@WhereStr
		set @WhereStr=' where '+@WhereStr+' and '		
	end
	
	if(@PageIndex=1)
		set @SqlStr='select top '+Convert(nvarchar(10),@PageSize)+' * from KyFeedback '+@fff+' order by [ID] desc'
	else
		set @SqlStr='select top '+Convert(nvarchar(10),@PageSize)+' * from KyFeedback  '+@WhereStr+
		' [ID] <(select MIN(ID) from (select top '+Convert(nvarchar(10),(@PageIndex-1)*@PageSize)+' * from KyFeedback'+@fff+' order by [ID] desc)F) order by [ID] desc'


--print @SqlStr
Execute Sp_ExecuteSql @SqlStr


Set @SqlStr =' Select Count([ID]) from KyFeedback '+@fff

Execute Sp_ExecuteSql @SqlStr


GO

-- ----------------------------
-- Procedure structure for Up_Feedback_UpdateState
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Feedback_UpdateState]
GO

CREATE PROCEDURE [dbo].[Up_Feedback_UpdateState] 
@Id int,
@Type int,
@Value nvarchar(20)
AS

	if @Type=0 -- update state
		begin
		UPDATE KyFeedback SET State=@Value WHERE [Id]=@Id
		end
	if @Type = 1 -- update category
		begin
		UPDATE KyFeedback SET categoryId=@Value WHERE [Id]=@Id
		end
		
	if @Type=2 --update scoring
		begin
		update KyFeedback set scoring=@Value where [Id]=@Id
		end


GO

-- ----------------------------
-- Procedure structure for Up_Group_Delete
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Group_Delete]
GO

Create proc [dbo].[Up_Group_Delete]  
@GroupId int
as  
Declare @IsSystem int
Set @IsSystem = (Select IsSystem From KyPowerGroup Where PowerId=@GroupId)
If(@IsSystem=1)
Begin
Select 0;
Return;
End
Delete KyPowerGroup  
where PowerId = @GroupId
Select 1;


GO

-- ----------------------------
-- Procedure structure for Up_Group_GetAdminGroupUserCount
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Group_GetAdminGroupUserCount]
GO

CREATE Procedure [dbo].[Up_Group_GetAdminGroupUserCount]
@GroupId Int
As
Select Count(UserId) From KyAdmin a Join KyPowerGroup b On a.GroupId=b.PowerId where a.GroupId=@GroupId



GO

-- ----------------------------
-- Procedure structure for Up_HireInfo_Get
-- ----------------------------
DROP PROCEDURE [dbo].[Up_HireInfo_Get]
GO
CREATE PROCEDURE [dbo].[Up_HireInfo_Get]
@Type int,
@PageSize int=20,
@PageIndex int=1,
@WhereStr nvarchar(2000)

as
	declare @SqlStr nvarchar(2000)
	declare @Filter nvarchar(2000)
	if(@WhereStr ='')
	begin
	 set @WhereStr=' where '
	 set @Filter=''
	end 
else
	begin
		set @Filter=' where '+@WhereStr
		set @WhereStr=' where '+@WhereStr+' and '		
	end
	
if(@Type=1)--get single
begin
	Set @SqlStr = N'select Ky_User_Personal.[Sex],[Address],[Phone],[TrueName],[Geographical],[qq],[Email],[Picture],
		Ky_U_Job.[Drection],[Type],Ky_U_Job.[Industry],[work],[Posts],[city],Ky_U_Job.[Area],[Times],[more],[Money],[Types]
		,Birthday,Height,Degree,experience
			from Ky_User_Personal join Ky_U_Job on Ky_User_Personal.UId=Ky_U_Job.Uid '+@Filter
	Execute Sp_ExecuteSql @SqlStr
end

if(@Type=2)--get list
begin
	if(@PageIndex=1)
		begin
					Set @SqlStr = N'Select Top '+Convert(Nvarchar(10),@PageSize)+' * from KyHireInfo '+@Filter +' Order By [Id] Desc'
		end
	else
		begin
				Set @SqlStr = N'Select Top '+Convert(Nvarchar(10),@PageSize)+' * FROM KyHireInfo '+@WhereStr+' [Id]<(Select Min(Id) From(Select Top '+Convert(Nvarchar(10),(@PageIndex-1)*@PageSize)+' * from KyHireInfo  '+@Filter+' Order By [Id] Desc)O) order By [Id] Desc'
		end	
		
	Execute Sp_ExecuteSql @SqlStr
	
	Set @SqlStr = 'select count(*) from KyHireInfo '+@Filter
	
	Execute Sp_ExecuteSql @SqlStr
end
GO

-- ----------------------------
-- Procedure structure for Up_HireInfo_Set
-- ----------------------------
DROP PROCEDURE [dbo].[Up_HireInfo_Set]
GO
CREATE PROCEDURE [dbo].[Up_HireInfo_Set]
@Type int=1,
@Id int=0,
@UserId int,
@UserName nvarchar(20),
@UnitId int,
@UnitName nvarchar(100),
@UserType int,
@Status int,
@AddTime datetime,
@JobId int
as
if @Type=1  -- insert
	begin
		if exists(select * from  KyHireInfo where UId=@UserId and JobId=@JobId and UserType=@UserType)
	 		return
		else
			insert into KyHireInfo values(@UserId,@UserName,@UnitId,@UnitName,@UserType,@Status,@AddTime,@JobId)
	end
else if @Type=2  --Update
	begin
		update KyHireInfo set Status=@Status where [Id]=@Id
	end
else if @Type=3  --delete
	begin
		delete from KyHireInfo where [Id]=@Id
	end
GO

-- ----------------------------
-- Procedure structure for Up_Image_Add
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Image_Add]
GO
CREATE PROCEDURE [dbo].[Up_Image_Add]
@ColId int ,
@Title nvarchar(200) ,
@TitleColor nvarchar(12) ,
@TitleFontType int ,
@TitleType int ,
@TitleImgPath varchar(255) ,
@UId int ,
@UName nvarchar(40) ,
@UserType int ,
@AdminUId int ,
@AdminUName char(10) ,
@Status int ,
@HitCount int ,
@AddTime datetime ,
@UpdateTime datetime ,
@TemplatePath varchar(255) ,
@PageType int ,
@IsCreated bit ,
@UserCateId int ,
@PointCount int ,
@ChargeType int ,
@ChargeHourCount int ,
@ChargeViewCount int ,
@IsOpened int ,
@GroupIdStr varchar(200) ,
@IsDeleted bit ,
@IsRecommend bit ,
@IsTop bit ,
@IsFocus bit ,
@IsSideShow bit ,
@TagIdStr varchar(300) ,
@IsAllowComment bit ,
@TagNameStr nvarchar(600) ,
@SpecialIdStr varchar(200) ,
@Content ntext ,
@ImgPath ntext ,
@Identity int=0 output,
@ChId int
 AS 
	INSERT INTO KyImage(
	[ChId],[ColId],[Title],[TitleColor],[TitleFontType],[TitleType],[TitleImgPath],[UId],[UName],[UserType],[AdminUId],[AdminUName],[Status],[HitCount],[AddTime],[UpdateTime],[TemplatePath],[PageType],[IsCreated],[UserCateId],[PointCount],[ChargeType],[ChargeHourCount],[ChargeViewCount],[IsOpened],[GroupIdStr],[IsDeleted],[IsRecommend],[IsTop],[IsFocus],[IsSideShow],[TagIdStr],[IsAllowComment],[TagNameStr],[SpecialIdStr],[Content],[ImgPath]
	)VALUES(
	@ChId,@ColId,@Title,@TitleColor,@TitleFontType,@TitleType,@TitleImgPath,@UId,@UName,@UserType,@AdminUId,@AdminUName,@Status,@HitCount,@AddTime,@UpdateTime,@TemplatePath,@PageType,@IsCreated,@UserCateId,@PointCount,@ChargeType,@ChargeHourCount,@ChargeViewCount,@IsOpened,@GroupIdStr,@IsDeleted,@IsRecommend,@IsTop,@IsFocus,@IsSideShow,@TagIdStr,@IsAllowComment,@TagNameStr,@SpecialIdStr,@Content,@ImgPath
	)
	
	select @Identity=scope_identity()
GO

-- ----------------------------
-- Procedure structure for Up_Image_Update
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Image_Update]
GO
CREATE PROCEDURE [dbo].[Up_Image_Update]
@Id int,
@ColId int,
@Title nvarchar(200),
@TitleColor nvarchar(12),
@TitleFontType int,
@TitleType int,
@TitleImgPath varchar(255),
@UId int,
@UName nvarchar(40),
@UserType int,
@AdminUId int,
@AdminUName char(10),
@Status int,
@HitCount int,
@AddTime datetime,
@UpdateTime datetime,
@TemplatePath varchar(255),
@PageType int,
@IsCreated bit,
@UserCateId int,
@PointCount int,
@ChargeType int,
@ChargeHourCount int,
@ChargeViewCount int,
@IsOpened int,
@GroupIdStr varchar(200),
@IsDeleted bit,
@IsRecommend bit,
@IsTop bit,
@IsFocus bit,
@IsSideShow bit,
@TagIdStr varchar(300),
@IsAllowComment bit,
@TagNameStr nvarchar(600),
@SpecialIdStr varchar(200),
@Content ntext,
@ImgPath ntext,
@ChId int
 AS 
	UPDATE KyImage SET 
	[ChId]=@ChId,[ColId] = @ColId,[Title] = @Title,[TitleColor] = @TitleColor,[TitleFontType] = @TitleFontType,[TitleType] = @TitleType,[TitleImgPath] = @TitleImgPath,[UId] = @UId,[UName] = @UName,[UserType] = @UserType,[AdminUId] = @AdminUId,[AdminUName] = @AdminUName,[Status] = @Status,[HitCount] = @HitCount,[AddTime] = @AddTime,[UpdateTime] = @UpdateTime,[TemplatePath] = @TemplatePath,[PageType] = @PageType,[IsCreated] = @IsCreated,[UserCateId] = @UserCateId,[PointCount] = @PointCount,[ChargeType] = @ChargeType,[ChargeHourCount] = @ChargeHourCount,[ChargeViewCount] = @ChargeViewCount,[IsOpened] = @IsOpened,[GroupIdStr] = @GroupIdStr,[IsDeleted] = @IsDeleted,[IsRecommend] = @IsRecommend,[IsTop] = @IsTop,[IsFocus] = @IsFocus,[IsSideShow] = @IsSideShow,[TagIdStr] = @TagIdStr,[IsAllowComment] = @IsAllowComment,[TagNameStr] = @TagNameStr,[SpecialIdStr] = @SpecialIdStr,[Content] = @Content,[ImgPath] = @ImgPath
	WHERE [Id] = @Id
GO

-- ----------------------------
-- Procedure structure for Up_Info_AddHitCount
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Info_AddHitCount]
GO
Create Procedure [dbo].[Up_Info_AddHitCount]
@tablename nvarchar(50),
@id int
as
declare @sqlstr nvarchar(2000)
set @sqlstr = 'update ['+@tablename+'] set hitcount=hitcount+1 where id='+Convert(nvarchar(15),@id)
execute sp_executesql @sqlstr

GO

-- ----------------------------
-- Procedure structure for Up_Info_Auditing
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Info_Auditing]
GO
Create Procedure [dbo].[Up_Info_Auditing]
@tablename nvarchar(50),
@id int,  
@status int,  
@adminid int,
@adminname nvarchar(20)  
As  
declare @sqlstr nvarchar(2000)
set @sqlstr = 'update ['+@tablename+'] set [status]=@tstatus,[adminuname]=@tadminname,[adminuid]=@tadminid where id=@tid and status in(0,1,2)'
declare @param nvarchar(1000) 
set @param ='@tid int,@tstatus int,@tadminid int,@tadminname nvarchar(20)'
execute sp_executesql @sqlstr,@param,@tid=@id,@tstatus=@status,@tadminid=@adminid,@tadminname=@adminname

GO

-- ----------------------------
-- Procedure structure for Up_Info_Cancel
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Info_Cancel]
GO
CREATE Procedure [dbo].[Up_Info_Cancel]  
@tablename nvarchar(50)  ,
@id int
As  
declare @sqlstr nvarchar(2000)
set @sqlstr = 'update ['+@tablename+'] set [status]=-2 where id=@tid';
declare @param nvarchar(50)
set @param = '@tid int'
execute sp_executesql @sqlstr,@param,@tid=@id
GO

-- ----------------------------
-- Procedure structure for Up_Info_CompleteDeleteInfo
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Info_CompleteDeleteInfo]
GO
CREATE proc [dbo].[Up_Info_CompleteDeleteInfo]
@tablename nvarchar(50),
@id int
as
declare @sqlstr nvarchar(2000)
declare @param nvarchar(200)
set @param='@tid int'
set @sqlstr = 'delete from ['+@tablename+'] where [id]=@tid'
execute sp_executesql @sqlstr,@param,@tid=@id


GO

-- ----------------------------
-- Procedure structure for Up_Info_DeleteToRecycle
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Info_DeleteToRecycle]
GO
CREATE Procedure [dbo].[Up_Info_DeleteToRecycle]
@idstr nvarchar(2000),
@tablename nvarchar(50)
As
declare @sqlstr nvarchar(2000)
set @sqlstr = N'update ['+@tablename+'] set isdeleted=1 where [id] in ('+@idstr+')';
execute sp_executesql @sqlstr



GO

-- ----------------------------
-- Procedure structure for Up_Info_GetHitCount
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Info_GetHitCount]
GO
Create Procedure [dbo].[Up_Info_GetHitCount]
@tablename nvarchar(50),
@id int
as
declare @sqlstr nvarchar(2000)
set @sqlstr = 'select hitcount from ['+@tablename+'] where id='+Convert(nvarchar(15),@id)
execute sp_executesql @sqlstr

GO

-- ----------------------------
-- Procedure structure for Up_Info_GetInfo
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Info_GetInfo]
GO
CREATE Procedure [dbo].[Up_Info_GetInfo]    
@tablename nvarchar(50),    
@id int    
as    
declare @sqlstr nvarchar(2000)    
set @sqlstr='select * from ['+@tablename+'] where [id]=@tid';   
declare @param nvarchar(200) 
set @param='@tid int'
execute sp_executesql @sqlstr,@param,@tid=@id  

  



GO

-- ----------------------------
-- Procedure structure for Up_Info_GetInfoCount
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Info_GetInfoCount]
GO
CREATE procedure [dbo].[Up_Info_GetInfoCount]
@tablename nvarchar(50),
@wherestr nvarchar(2000)
as
declare @sqlstr nvarchar(4000)
if(@wherestr='')
begin
	set @sqlstr = 'select count([id]) from ['+@tablename+']'
end
else
begin
	set @sqlstr = 'select count([id]) from ['+@tablename+'] where '+@wherestr
end
execute sp_executesql @sqlstr
GO

-- ----------------------------
-- Procedure structure for Up_Info_GetInfoList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Info_GetInfoList]
GO
CREATE  Procedure [dbo].[Up_Info_GetInfoList]
@tableName Nvarchar(50)='',
@fieldName Nvarchar(20)='',
@keyword Nvarchar(50)='',
@chid int,
@colidstr nvarchar(500)='',
@status varchar(50)='-99',
@property varchar(50)='',
@propertytype varchar(10)='=',
@propertyvalue varchar(50)='',
@usertype int=-1,
@pageindex int=1,
@pagesize int=20,
@recordcount int=0 output
as
declare @wherestr nvarchar(2000)
set @wherestr = '';
if(@tablename='')
	return;
if(@fieldname!='')
	set @wherestr = @wherestr+' i.'+@fieldname+' like ''%'+@keyword+'%'' and ';
if(@chid!=0)
	set @wherestr = @wherestr+' co.chid='+convert(nvarchar(15),@chid)+' and ';
if(@colidstr!='0')
	set @wherestr = @wherestr+' i.colId in('+@colidstr+') and ';  	
if(@status!='-99')
	set @wherestr = @wherestr+' i.status in('+@status+') and ';  
if(@property!='' and @propertytype!='' and @propertyvalue!='')
	set @wherestr = @wherestr+' i.'+@property+@propertytype+@propertyvalue+' and ';
if(@usertype!=-1)
	set @wherestr = @wherestr+ ' i.usertype='+convert(nvarchar(15),@usertype)+' and '
set @wherestr = @wherestr+' i.status!=-1 and i.isdeleted=0'
declare @selectfield nvarchar(500)
set @selectfield = ' co.colname,i.[id],i.title,i.titletype,i.colid,i.uname,i.usertype,i.hitcount,i.issideshow,i.istop,i.isrecommend,i.isfocus,i.status,i.iscreated '
declare @selecttable nvarchar(500)
set @selecttable = @tablename+' i join kycolumn co on i.colid=co.colid join kychannel ch on ch.chid=co.chid ' 
declare @sqlstr Nvarchar(4000)
if(@pageindex=1)
	set @sqlstr = 'select Top '+Convert(Nvarchar(15),@pagesize)+@selectfield +' from '+@selecttable+' where '+@wherestr+' order by i.[id] desc';
else
	set @sqlstr = 'select Top '+Convert(Nvarchar(15),@PageSize)+@selectfield+' from '+@selecttable+' where '+@wherestr+' and i.[id] <(select min(O.[id]) from(select top '+Convert(Nvarchar(15),(@pageindex-1)*@pagesize)+' i.[id] from '+@selecttable+' where '+@wherestr+' order by i.[id] desc)O) order By i.[id] desc'
execute sp_executesql @sqlstr
set @sqlstr =' select count(i.[id]) from '+@selecttable+' where '+@wherestr
execute sp_executesql @sqlstr;
GO

-- ----------------------------
-- Procedure structure for Up_Info_GetRecycleInfoList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Info_GetRecycleInfoList]
GO
CREATE PROCEDURE [dbo].[Up_Info_GetRecycleInfoList]
@tablename nvarchar(50) ,
@type int,
@pageindex Int=1,
@pagesize int=20
as
declare @sqlstr nvarchar(2000)
declare @countstr nvarchar(2000)
if(@type=1)
begin
	set @sqlstr = ' select chid as id,chname,description,addtime from kychannel where isdeleted=1'
	set @countstr = 'select count(*) from kychannel where isdeleted=1'
end
else if(@type=2)
begin
	set @sqlstr = ' select colid as id,colname,co.description,co.chid,colparentid,chname from kycolumn co join kychannel ch on co.chid=ch.chid where co.isdeleted=1'
 	set @countstr = 'select count(*) from kycolumn co join kychannel ch on co.chid=ch.chid where co.isdeleted=1'
end
else if(@type=3)
begin
	if(@pageindex=1)
		set @sqlstr = 'select top '+convert(nvarchar(15),@pagesize)+' id,specialcname,specialdomain,specialremark,specialaddtime,parentid from kyspecial where isdeleted=1 order by id desc'
	else	
		set @sqlstr = 'select top '+convert(nvarchar(15),@pagesize)+' id,specialcname,specialdomain,specialremark,specialaddtime,parentid from kyspecial where isdeleted=1 and id <(select min(id) from(select top '+convert(nvarchar(15),(@pageindex-1)*@pagesize)+' id from kyspecial where isdeleted=1 order by id desc)o) order by id desc'
	set @countstr = 'select count(*) from kyspecial where isdeleted=1'
end
else if(@type=4)
begin
	if(@tablename='')
	return;
	if(@pageindex=1)
		set @sqlstr = 'select top '+convert(nvarchar(15),@pagesize)+' co.colname,i.[id],i.colid,i.title,i.addtime from ['+@tablename+'] i join kycolumn co on i.colid=co.colid where i.[isdeleted]=1 order by id desc'
	else
		set @sqlstr = 'select top '+convert(nvarchar(15),@pagesize)+' co.colname,i.[id],i.colid,i.title,i.addtime from ['+@tablename+'] i join kycolumn co on i.colid=co.colid where i.[isdeleted]=1 and i.[id] <(select min(id) from(select top '+convert(nvarchar(15),(@pageindex-1)*@pagesize)+' id from ['+@tablename+'] i join kycolumn co on i.colid=co.colid  where i.isdeleted=1 order by id desc)o) order by id desc'
	set @countstr = 'select count(*) from ['+@tablename+'] i join kycolumn co on i.colid=co.colid where i.isdeleted=1'
end
execute sp_executesql @sqlstr
execute sp_executesql @countstr
GO

-- ----------------------------
-- Procedure structure for Up_Info_GetUserInfo
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Info_GetUserInfo]
GO
CREATE Procedure [dbo].[Up_Info_GetUserInfo]    
@tablename nvarchar(50),    
@UserId int    
as    
declare @sqlstr nvarchar(2000)    
set @sqlstr='select * from ['+@tablename+'] where [UId]=@tid';   
declare @param nvarchar(200) 
set @param='@tid int'
execute sp_executesql @sqlstr,@param,@tid=@UserId
GO

-- ----------------------------
-- Procedure structure for Up_Info_MassMoveInfo
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Info_MassMoveInfo]
GO
CREATE procedure [dbo].[Up_Info_MassMoveInfo]
@tablename nvarchar(20),
@idstr varchar(2000),
@colid int,
@targetcolid int
as
if(@tablename='')
	return;
declare @sqlstr nvarchar(4000)
declare @wherestr nvarchar(400)
if(@idstr='')
	set @wherestr = ' where colid=@tcolid'
else
	set @wherestr = ' where [id] in('+@idstr+')'
set @sqlstr = 'update ['+@tablename+'] set colid=@ttargetcolid '+@wherestr
declare @param nvarchar(400)
set @param = '@ttargetcolid int,@tcolid int'
execute sp_executesql @sqlstr,@param,@ttargetcolid=@targetcolid,@tcolid=@colid
GO

-- ----------------------------
-- Procedure structure for Up_Info_MassSetInfo
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Info_MassSetInfo]
GO
CREATE procedure [dbo].[Up_Info_MassSetInfo]
@tablename nvarchar(50),
@idstr varchar(2000),
@colid int,
@tagflag bit,
@tagidstr nvarchar(300),
@tagnamestr nvarchar(300),
@topflag bit,
@istop bit,
@recommendflag bit,
@isrecommend bit,
@focusflag bit,
@isfocus bit,
@templatepathflag bit,
@templatepath varchar(255),
@hitcountflag bit,
@hitcount int,
@isopenedflag bit,
@isopened int,
@groupidstrflag bit,
@groupidstr varchar(1000),
@pointcountflag bit,
@pointcount int,
@chargetypeflag bit,
@chargetype int,
@chargehourcountflag bit,
@chargehourcount int,
@chargeviewcountflag bit,
@chargeviewcount int,
@pagetypeflag bit,
@pagetype int
as
if(@tablename='')
	return;
declare @sqlstr nvarchar(4000)
declare @param nvarchar(4000)
declare @wherestr nvarchar(2000)
set @wherestr=''
declare @setstr nvarchar(4000)
set @setstr = ''
declare @char varchar(1)
set @char=''

if(@idstr='')
	set @wherestr = ' where i.colid=@tcolid ';
else 
	set @wherestr = ' where i.[id] in('+@idstr+')'
if(@tagflag=1)
begin
	set @setstr = @setstr+@char+'i.tagidstr=@ttagidstr,i.tagnamestr=@ttagnamestr'
	set @char = ','
end
if(@topflag=1)
begin
	set @setstr = @setstr+@char+'i.istop=@tistop'
	set @char=','
end
if(@recommendflag=1)
begin
	set @setstr = @setstr+@char+'i.isrecommend=@tisrecommend'
	set @char=','
end
if(@focusflag=1)
begin
	set @setstr = @setstr+@char+'i.isfocus=@tisfocus'
	set @char=','
end
if(@templatepathflag=1)
begin
	set @setstr = @setstr+@char+'i.templatepath=@ttemplatepath'
	set @char=','
end
if(@hitcountflag=1)
begin
	set @setstr = @setstr+@char+'i.hitcount=@thitcount'
	set @char=','
end
if(@isopenedflag=1)
begin
	set @setstr = @setstr+@char+'i.isopened=@tisopened'
	set @char=','
end
if(@groupidstrflag=1)
begin
	set @setstr = @setstr+@char+'i.groupidstr=@tgroupidstr'
	set @char=','
end
if(@pointcountflag=1)
begin
	set @setstr = @setstr+@char+'i.pointcount=@tpointcount'
	set @char=','
end
if(@chargetypeflag=1)
begin
	set @setstr=@setstr+@char+'i.chargetype=@tchargetype'
	set @char=','
end
if(@chargehourcountflag=1)
begin
	set @setstr = @setstr+@char+'i.chargehourcount=@tchargehourcount'
	set @char=','
end
if(@chargeviewcountflag=1)
begin
	set @setstr = @setstr+@char+'i.chargeviewcount=@tchargeviewcount'
	set @char=','
end
if(@pagetypeflag=1)
begin
	set @setstr = @setstr+@char+'i.pagetype=@tpagetype'
end
if(@setstr='')
	return;
set @sqlstr='update i set '+@setstr+ ' from ['+@tablename+' ] i '+@wherestr
set @param = '@ttagidstr nvarchar(300),@ttagnamestr nvarchar(300),@tistop bit,@tisrecommend bit,@tisfocus bit,@ttemplatepath varchar(255),@thitcount int,@tisopened int,@tgroupidstr varchar(1000),@tpointcount int,@tchargetype int,@tchargehourcount int,@tchargeviewcount int,@tpagetype int,@tcolid int'
execute sp_executesql @sqlstr,@param,@ttagidstr=@tagidstr,@ttagnamestr=@tagnamestr,@tistop=@istop,@tisrecommend=@isrecommend,@tisfocus=@isfocus,@ttemplatepath=@templatepath,@thitcount=@hitcount,@tisopened=@isopened,@tgroupidstr=@groupidstr,@tpointcount=@pointcount,@tchargetype=@chargetype,@tchargehourcount=@chargehourcount,@tchargeviewcount=@chargeviewcount,@tpagetype=@pagetype,@tcolid=@colid
GO

-- ----------------------------
-- Procedure structure for Up_Info_SetInfoSpecial
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Info_SetInfoSpecial]
GO
Create procedure [dbo].[Up_Info_SetInfoSpecial]
@tablename nvarchar(50),
@id int,
@specialidstr varchar(500)
as
declare @sqlstr nvarchar(2000)
set @sqlstr = 'update ['+@tablename+'] set [specialidstr]=@tspecialidstr where [id]=@tid'
declare @param nvarchar(2000)
set @param = '@tspecialidstr varchar(5000),@tid int'
execute sp_executesql @sqlstr,@param,@tspecialidstr=@specialidstr,@tid=@id

GO

-- ----------------------------
-- Procedure structure for Up_Info_SetProperty
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Info_SetProperty]
GO
Create Procedure [dbo].[Up_Info_SetProperty]
@tablename nvarchar(50),
@property nvarchar(50),
@propertyvalue nvarchar(50),
@id int
as
declare @sqlstr nvarchar(2000)
set @sqlstr = 'update '+@tablename+' set ['+@property+']='+@propertyvalue+' where [id]='+Convert(nvarchar(15),@id);
exec sp_executesql @sqlstr

GO

-- ----------------------------
-- Procedure structure for Up_Info_UpdateIsCreated
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Info_UpdateIsCreated]
GO
CREATE Procedure [dbo].[Up_Info_UpdateIsCreated]
@tablename nvarchar(50),
@id int
as
declare @sqlstr nvarchar(2000)
set @sqlstr = 'update ['+@tablename+'] set iscreated=1 where [id]='+convert(nvarchar(15),@id)
execute sp_executesql @sqlstr

GO

-- ----------------------------
-- Procedure structure for Up_Info_User_DeleteInfo
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Info_User_DeleteInfo]
GO
create Procedure [dbo].[Up_Info_User_DeleteInfo]
@idstr nvarchar(2000),  
@tablename nvarchar(50),  
@uid int  
As  
declare @sqlstr nvarchar(2000)  
set @sqlstr = 'delete from ['+@tablename+'] where [id] in ('+@idstr+') and [uId]=@tuid and usertype=0 and status=-1';  
declare @param nvarchar(200)  
set @param = '@tuid int'  
execute sp_executesql @sqlstr,@param,@tuid=@uid  


GO

-- ----------------------------
-- Procedure structure for Up_Info_User_GetInfoList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Info_User_GetInfoList]
GO
CREATE Procedure [dbo].[Up_Info_User_GetInfoList]
@tableName Nvarchar(50)='',
@uid int,
@fieldName Nvarchar(20)='',
@keyword Nvarchar(50)='',
@chid int,
@colidstr nvarchar(500)='',
@status varchar(50)='-99',
@property varchar(50)='',
@propertytype varchar(10)='=',
@propertyvalue varchar(50)='',
@usercateid int=-1,
@pageindex int=1,
@pagesize int=20,
@recordcount int=0 output
as
if(@tablename='')
	return;
declare @wherestr nvarchar(2000)
set @wherestr = ' i.uid='+convert(nvarchar(15),@uid)+' and usertype=0 and ';

if(@fieldname!='')
	set @wherestr = @wherestr+' i.'+@fieldname+' like ''%'+@keyword+'%'' and ';
if(@chid!=0)
	set @wherestr = @wherestr+' co.chid='+convert(nvarchar(15),@chid)+' and ';
if(@colidstr!='0')
	set @wherestr = @wherestr+' i.colId in('+@colidstr+') and ';  	
if(@status!='-99')
	set @wherestr = @wherestr+' i.status in('+@status+') and ';  
if(@property!='' and @propertyType!='' and @propertyvalue!='')
	set @wherestr = @wherestr+' i.'+@property+@propertyType+@propertyvalue+' and ';
if(@usercateid!=-1)
	set @wherestr = @wherestr+ ' i.usercateid='+convert(nvarchar(15),@usercateid)+' and '
set @wherestr = @wherestr+' i.isdeleted=0 '
declare @selectfield nvarchar(500)
set @selectfield = ' ch.chid,ch.modeltype,ch.minihitcount,co.colname,i.[id],i.title,i.titletype,i.colid,i.uname,i.usertype,i.hitcount,i.issideshow,i.istop,i.isrecommend,i.isfocus,i.status,i.addtime '
declare @selecttable nvarchar(500)
set @selecttable = @tablename+' i join kycolumn co on i.colid=co.colid join kychannel ch on ch.chid=co.chid ' 
declare @sqlstr Nvarchar(4000)
if(@pageindex=1)
	set @sqlstr = 'select Top '+Convert(Nvarchar(15),@pagesize)+@selectfield +' from '+@selecttable+' where '+@wherestr+' order by i.[id] desc';
else
	set @sqlstr = 'select Top '+Convert(Nvarchar(15),@PageSize)+@selectfield+' from '+@selecttable+' where '+@wherestr+' and i.[id] <(select min(O.[id]) from(select top '+Convert(Nvarchar(15),(@pageindex-1)*@pagesize)+' i.[id] from '+@selecttable+' where '+@wherestr+' order by i.[id] desc)O) order By i.[id] desc'
execute sp_executesql @sqlstr
set @sqlstr =' select count(i.[id]) from '+@selecttable+' where '+@wherestr
execute sp_executesql @sqlstr;
GO

-- ----------------------------
-- Procedure structure for Up_Info_User_IsExistsInfo
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Info_User_IsExistsInfo]
GO
CREATE Procedure [dbo].[Up_Info_User_IsExistsInfo]
@tableName nvarchar(50),
@UId int
as
declare @sqlstr nvarchar(2000)
	set @sqlstr='if exists(select 1 from '+@tableName+' where status=3 and isdeleted=0 and UId='+Convert(Nvarchar(15),@UId)+') select 1 else select 0'
execute sp_executesql @sqlstr
GO

-- ----------------------------
-- Procedure structure for Up_Info_User_Publish
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Info_User_Publish]
GO
CREATE proc [dbo].[Up_Info_User_Publish]
@tablename nvarchar(50),
@id int,
@uId int
as 
declare @sqlstr nvarchar(2000)
set @sqlstr = 'update ['+@tablename+'] set status=0 where [id]=@tid and [uid]=@tuid and usertype=0 and status=-1'
declare @param nvarchar(200)
set @param = '@tid int,@tuid int'
execute sp_executesql @sqlstr,@param,@tid=@id,@tuid=@uid
GO

-- ----------------------------
-- Procedure structure for Up_InfoModel_GetTextType
-- ----------------------------
DROP PROCEDURE [dbo].[Up_InfoModel_GetTextType]
GO
CREATE PROCEDURE [dbo].[Up_InfoModel_GetTextType]
@ModelId int
AS
	select ModelId,[Name],Type from [KyModelField] where [ModelId]=@ModelId and [Type]='MultipleHtmlType'
	RETURN
GO

-- ----------------------------
-- Procedure structure for Up_KyCount_AddDayCount
-- ----------------------------
DROP PROCEDURE [dbo].[Up_KyCount_AddDayCount]
GO

Create Procedure [dbo].[Up_KyCount_AddDayCount]
@CurrHour varchar(2),
@CurrDay varchar(10)
As
Declare @SqlStr nvarchar(2000)
If Exists(Select * From KyCountDay Where Flag=@CurrDay)

	Set @SqlStr = N'Update KyCountDay Set ['+@CurrHour +'] = ['+@CurrHour+']+1  Where Flag='''+@CurrDay+'''';

Else
	Set @SqlStr = N'Insert Into  KyCountDay (['+@CurrHour+'],Flag)values(1,'''+@CurrDay+''')';

	Execute Sp_ExecuteSql @SqlStr

Set @SqlStr = N'Update KyCountDay Set ['+@CurrHour +'] = ['+@CurrHour+']+1 Where Flag=''Total''';
Execute Sp_ExecuteSql @SqlStr


GO

-- ----------------------------
-- Procedure structure for Up_KyCount_AddMonthCount
-- ----------------------------
DROP PROCEDURE [dbo].[Up_KyCount_AddMonthCount]
GO

Create Procedure [dbo].[Up_KyCount_AddMonthCount]
@CurrDay varchar(2),
@CurrMonth varchar(7)
As
Declare @SqlStr nvarchar(2000)
If Exists(Select * From KyCountMonth Where Flag=@CurrMonth)

	Set @SqlStr = N'Update KyCountMonth Set ['+@CurrDay +'] = ['+@CurrDay+']+1  Where Flag='''+@CurrMonth+'''';

Else
	Set @SqlStr = N'Insert Into  KyCountMonth (['+@CurrDay+'],Flag)values(1,'''+@CurrMonth+''')';

	Execute Sp_ExecuteSql @SqlStr

Set @SqlStr = N'Update KyCountMonth Set ['+@CurrDay +'] = ['+@CurrDay+']+1 Where Flag=''Total''';
Execute Sp_ExecuteSql @SqlStr


GO

-- ----------------------------
-- Procedure structure for Up_KyCount_AddWeekCount
-- ----------------------------
DROP PROCEDURE [dbo].[Up_KyCount_AddWeekCount]
GO

CREATE Procedure [dbo].[Up_KyCount_AddWeekCount]
@CurrDate varchar(10),
@CurrWeekDay varchar(1)
As
Declare @SqlStr nvarchar(2000)
declare @param nvarchar(400)
if not exists(select * from kycountweek where flag<>'total')
begin
	set @sqlstr = 'insert into kycountweek([1],[2],[3],[4],[5],[6],[7],flag)values(0,0,0,0,0,0,0,@tCurrDate)'
	set @param = '@tcurrdate nvarchar(10)'
	Execute Sp_ExecuteSql @SqlStr,@param,@tcurrdate=@currdate
end

If(@CurrDate!='' And Not Exists(Select * From KyCountWeek Where Flag=@CurrDate))
Begin
	Set @SqlStr = N'Update KyCountWeek Set [1]=0,[2]=0,[3]=0,[4]=0,[5]=0,[6]=0,[7]=0,Flag='''+@CurrDate+''' Where Flag<>''Total'''
           Execute Sp_ExecuteSql @SqlStr
End

Set @SqlStr = N'Update KyCountWeek Set ['+@CurrWeekDay+']=['+@CurrWeekDay+']+1'
Execute Sp_ExecuteSql @SqlStr
GO

-- ----------------------------
-- Procedure structure for Up_KyCount_AddYearCount
-- ----------------------------
DROP PROCEDURE [dbo].[Up_KyCount_AddYearCount]
GO

CREATE Procedure [dbo].[Up_KyCount_AddYearCount]
@CurrMonth varchar(2),
@CurrYear varchar(4)
As
Declare @SqlStr nvarchar(2000)
If Exists(Select * From KyCountYear Where Flag=@CurrYear)

	Set @SqlStr = N'Update KyCountYear Set ['+@CurrMonth +'] = ['+@CurrMonth+']+1  Where Flag='''+@CurrYear+'''';

Else
	Set @SqlStr = N'Insert Into  KyCountYear (['+@CurrMonth+'],Flag)values(1,'''+@CurrYear+''')';

	Execute Sp_ExecuteSql @SqlStr

Set @SqlStr = N'Update KyCountYear Set ['+@CurrMonth +'] = ['+@CurrMonth+']+1 Where Flag=''Total''';
Execute Sp_ExecuteSql @SqlStr


GO

-- ----------------------------
-- Procedure structure for UP_KyShopBrand_Delete
-- ----------------------------
DROP PROCEDURE [dbo].[UP_KyShopBrand_Delete]
GO
CREATE PROCEDURE [dbo].[UP_KyShopBrand_Delete]
@IdStr nvarchar(1000)
AS 
	delete kyshopBrand where BrandId in (@IdStr)

GO

-- ----------------------------
-- Procedure structure for UP_KyShopBrand_GetList
-- ----------------------------
DROP PROCEDURE [dbo].[UP_KyShopBrand_GetList]
GO
CREATE PROCEDURE [dbo].[UP_KyShopBrand_GetList]
@PageIndex int,
@PageSize int,
@RecordCount int=0 output,
@ProducerType int,
@Filter nvarchar(4000)
as
declare @sqlstr nvarchar(4000)
if(@PageIndex=1)
	set @sqlstr=N'select top '+Convert(nvarchar(15),@PageSize)+' * from kyshopprocuder where @FileTer order by procuderid desc'
else
	set @sqlstr=N'select top '+Convert(nvarchar(15),@PageSize)+' * from kyshopprocuder where @Fileter and 
id<(select min(o,id) from (select top '+Convert(nvarchar(15),(@PageIndex-1)*@PageSize)+' id from kyshopprocuder
 where @Filter order by procuderid desc)o) order by procuderid desc'
execute sp_executesql @sqlstr

GO

-- ----------------------------
-- Procedure structure for UP_KyShopBrand_GetModel
-- ----------------------------
DROP PROCEDURE [dbo].[UP_KyShopBrand_GetModel]
GO
CREATE PROCEDURE [dbo].[UP_KyShopBrand_GetModel]
@Id int
 AS 
	SELECT * FROM KyShopBrand WHERE [BrandId] = @Id

GO

-- ----------------------------
-- Procedure structure for UP_KyShopProcuder_GetList
-- ----------------------------
DROP PROCEDURE [dbo].[UP_KyShopProcuder_GetList]
GO
CREATE PROCEDURE [dbo].[UP_KyShopProcuder_GetList]
@PageIndex int,
@PageSize int,
@RecordCount int=0 output,
@ProducerType int,
@Filter nvarchar(4000)
as
declare @sqlstr nvarchar(4000)
if(@PageIndex=1)
	set @sqlstr=N'select top '+Convert(nvarchar(15),@PageSize)+' * from kyshopprocuder where @FileTer order by procuderid desc'
else
	set @sqlstr=N'select top '+Convert(nvarchar(15),@PageSize)+' * from kyshopprocuder where @Fileter and 
id<(select min(o,id) from (select top '+Convert(nvarchar(15),(@PageIndex-1)*@PageSize)+' id from kyshopprocuder
 where @Filter order by procuderid desc)o) order by procuderid desc'
execute sp_executesql @sqlstr

GO

-- ----------------------------
-- Procedure structure for UP_KyShopProducer_Delete
-- ----------------------------
DROP PROCEDURE [dbo].[UP_KyShopProducer_Delete]
GO
CREATE PROCEDURE [dbo].[UP_KyShopProducer_Delete]
@IdStr nvarchar(1000)
AS 
	delete kyshopprocuder where ProcuderId in (@IdStr)

GO

-- ----------------------------
-- Procedure structure for UP_KyShopProducer_GetModel
-- ----------------------------
DROP PROCEDURE [dbo].[UP_KyShopProducer_GetModel]
GO
CREATE PROCEDURE [dbo].[UP_KyShopProducer_GetModel]
@Id int
 AS 
	SELECT * FROM KyShopProducer WHERE [ProducerId] = @Id

GO

-- ----------------------------
-- Procedure structure for Up_KyShopProducer_Set
-- ----------------------------
DROP PROCEDURE [dbo].[Up_KyShopProducer_Set]
GO
CREATE PROCEDURE [dbo].[Up_KyShopProducer_Set]
@ProducerId int output,
@ProducerType int ,
@ProducerName nvarchar(200) ,
@ProducerShortName nvarchar(50) ,
@ProducerPhoto nvarchar(255) ,
@AddTime datetime ,
@Address nvarchar(255) ,
@Postcode nvarchar(10) ,
@Phone nvarchar(50) ,
@Fax nvarchar(50) ,
@Email nvarchar(50) ,
@Homepage nvarchar(50) ,
@ProducerIntro ntext ,
@LastUpdateTime datetime ,
@IsPassed bit ,
@IsTop bit ,
@IsRecommend bit ,
@HitCount int 
 AS 
if(@ProducerId=0)
begin
	INSERT INTO KyShopProducer(
	[ProducerType],[ProducerName],[ProducerShortName],[ProducerPhoto],[AddTime],[Address],[Postcode],[Phone],[Fax],[Email],[Homepage],[ProducerIntro],[IsPassed],[IsTop],[IsRecommend],[HitCount]
	)VALUES(
	@ProducerType,@ProducerName,@ProducerShortName,@ProducerPhoto,@AddTime,@Address,@Postcode,@Phone,@Fax,@Email,@Homepage,@ProducerIntro,@IsPassed,@IsTop,@IsRecommend,@HitCount
	)
	SET @ProducerId = scope_identity()
end
else
	UPDATE KyShopProducer SET 
	[ProducerType] = @ProducerType,[ProducerName] = @ProducerName,[ProducerShortName] = @ProducerShortName,[ProducerPhoto] = @ProducerPhoto,[Address] = @Address,[Postcode] = @Postcode,[Phone] = @Phone,[Fax] = @Fax,[Email] = @Email,[Homepage] = @Homepage,[ProducerIntro] = @ProducerIntro,[LastUpdateTime] = @LastUpdateTime,[IsPassed] = @IsPassed,[IsTop] = @IsTop,[IsRecommend] = @IsRecommend,[HitCount] = @HitCount
	WHERE [ProducerId] = @ProducerId


GO

-- ----------------------------
-- Procedure structure for Up_LabelContent_ConByName
-- ----------------------------
DROP PROCEDURE [dbo].[Up_LabelContent_ConByName]
GO

CREATE PROCEDURE [dbo].[Up_LabelContent_ConByName] 
@Name Nvarchar(50)
AS
SELECT Content FROM KyLabelContent Where Name=@Name


GO

-- ----------------------------
-- Procedure structure for Up_LabelContent_Delete
-- ----------------------------
DROP PROCEDURE [dbo].[Up_LabelContent_Delete]
GO

CREATE PROCEDURE [dbo].[Up_LabelContent_Delete]  
@LabelCategoryID Nvarchar(500)  
 AS   
Declare @SqlStr Nvarchar(2000)
Set @SqlStr = N' DELETE KyLabelContent WHERE [LabelCategoryID] in ('+@LabelCategoryID+')'
Execute Sp_ExecuteSql @SqlStr

GO

-- ----------------------------
-- Procedure structure for Up_LabelContent_GetContent
-- ----------------------------
DROP PROCEDURE [dbo].[Up_LabelContent_GetContent]
GO

CREATE PROCEDURE [dbo].[Up_LabelContent_GetContent] 

@LabelCategoryID int
AS

SELECT Content FROM KyLabelContent WHERE LabelCategoryID=@LabelCategoryID


GO

-- ----------------------------
-- Procedure structure for Up_LabelContent_GetInfo
-- ----------------------------
DROP PROCEDURE [dbo].[Up_LabelContent_GetInfo]
GO

CREATE PROCEDURE [dbo].[Up_LabelContent_GetInfo]
@LabelCategoryID int
 AS 
	SELECT 
	[LabelCategoryID],[Name],[Content],[LbCategoryId],[ModeType],[AnomalyStyle]
	 FROM KyLabelContent
	 WHERE [LabelCategoryID] = @LabelCategoryID
GO

-- ----------------------------
-- Procedure structure for Up_LabelContent_GetLbcategoryIdList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_LabelContent_GetLbcategoryIdList]
GO

CREATE proc [dbo].[Up_LabelContent_GetLbcategoryIdList]
@LbCategoryId Int,
@CursorPage Int,
@PageSize Int,
@RecordCount Int output
As
Declare @SqlStr Nvarchar(2000);
if(@CursorPage=1)
	Set @SqlStr=N'Select Top '+Convert(Nvarchar(15),@PageSize)+' * from KyLabelContent Where LbCategoryId='+Convert(Nvarchar(50),@LbCategoryId)+' Order By LabelCategoryID Desc'
else
	Set @SqlStr=N'Select Top '+Convert(Nvarchar(15),@PageSize)+' * from KyLabelContent Where LbCategoryId='+Convert(Nvarchar(50),@LbCategoryId)+'and LabelCategoryID<(Select min(LabelCategoryID) From(Select Top '+Convert(Nvarchar(15),(@CursorPage-1)*@PageSize)+' LabelCategoryID From KyLabelContent Where LbCategoryId='+Convert(Nvarchar(50),@LbCategoryId)+' Order By LabelCategoryID Desc)O)Order By LabelCategoryID Desc'
Execute SP_ExecuteSql @SqlStr

Set @SqlStr = N'Select @TRecordCount=Count(LabelCategoryID) From KyLabelContent Where LbCategoryId='+Convert(Nvarchar(50),@LbCategoryId);
Declare @Param Nvarchar(50)
Set @Param = N'@TRecordCount int output'
Execute SP_ExecuteSql @SqlStr,@Param,@TRecordCount=@RecordCount output



GO

-- ----------------------------
-- Procedure structure for Up_LabelContent_GetLbcategoryNameList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_LabelContent_GetLbcategoryNameList]
GO
CREATE proc [dbo].[Up_LabelContent_GetLbcategoryNameList]
@labelName Nvarchar(200),
@CursorPage Int,
@PageSize Int,
@RecordCount Int output
As
Declare @SqlStr Nvarchar(2000);
if(@CursorPage=1)
	Set @SqlStr=N'Select Top '+Convert(Nvarchar(15),@PageSize)+' * from KyLabelContent Where [Name] like @tlabelName Order By LabelCategoryID Desc'
else
	Set @SqlStr=N'Select Top '+Convert(Nvarchar(15),@PageSize)+' * from KyLabelContent Where [Name] like @tlabelName and LabelCategoryID<(Select min(LabelCategoryID) From(Select Top '+Convert(Nvarchar(15),(@CursorPage-1)*@PageSize)+' LabelCategoryID From KyLabelContent Where [Name] like @tlabelName Order By LabelCategoryID Desc)O)Order By LabelCategoryID Desc'
Declare @paramlb nvarchar(500)
set @paramlb=N'@tlabelName Nvarchar(200)'
Execute Sp_executeSql @SqlStr,@paramlb,@tlabelName=@labelName

set @RecordCount=(select Count(LabelCategoryID) From KyLabelContent Where [Name]  like @labelName)
GO

-- ----------------------------
-- Procedure structure for Up_LabelContent_GetList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_LabelContent_GetList]
GO

CREATE PROCEDURE [dbo].[Up_LabelContent_GetList] 
AS
Select [Name],Content from [KyLabelContent] order by LabelCategoryID desc
GO

-- ----------------------------
-- Procedure structure for Up_LabelContent_Set
-- ----------------------------
DROP PROCEDURE [dbo].[Up_LabelContent_Set]
GO

--用途：增加与修改一条记录 
--项目名称：CodematicDemo
--说明：
--时间：2007-8-2 9:50:39
------------------------------------
CREATE PROCEDURE [dbo].[Up_LabelContent_Set]
@LabelCategoryID int,
@Name nvarchar(100) ,
@Content text ,
@LbCategoryId int ,
@ModeType int,
@AnomalyStyle text
 AS 
if(@LabelCategoryID<=0)
	Begin
		INSERT INTO KyLabelContent([Name],[Content],[LbCategoryId],[ModeType],[AnomalyStyle]) VALUES (@Name,@Content,@LbCategoryId,@ModeType,@AnomalyStyle)
	End
Else
	Begin
		UPDATE KyLabelContent SET [Name] = @Name,[Content] = @Content,[LbCategoryId] = @LbCategoryId,[ModeType] = @ModeType,[AnomalyStyle]=@AnomalyStyle
		WHERE [LabelCategoryID] = @LabelCategoryID	
	End
GO

-- ----------------------------
-- Procedure structure for Up_LbCategory_Add
-- ----------------------------
DROP PROCEDURE [dbo].[Up_LbCategory_Add]
GO

CREATE PROCEDURE [dbo].[Up_LbCategory_Add]
@LbCategoryID int output,
@Name nvarchar(100) ,
@ParentID int ,
@Desc nvarchar(200) 
 AS 
	INSERT INTO KyLbCategory(
	[Name],[ParentID],[Desc]
	)VALUES(
	@Name,@ParentID,@Desc
	)
SET @LbCategoryID = @@IDENTITY
GO

-- ----------------------------
-- Procedure structure for Up_LbCategory_Delete
-- ----------------------------
DROP PROCEDURE [dbo].[Up_LbCategory_Delete]
GO

------------------------------------
--用途：删除一条记录 
--项目名称：CodematicDemo
--说明：
--时间：2007-7-31 14:16:02
------------------------------------
CREATE PROCEDURE [dbo].[Up_LbCategory_Delete]
@LbCategoryID int
 AS 
	DELETE KyLbCategory
	 WHERE [LbCategoryID] = @LbCategoryID or ParentID=@LbCategoryID

GO

-- ----------------------------
-- Procedure structure for Up_LbCategory_GetIdData
-- ----------------------------
DROP PROCEDURE [dbo].[Up_LbCategory_GetIdData]
GO

--用途：得到实体对象的详细信息 
--项目名称：CodematicDemo
--说明：
--时间：2007-7-31 14:54:28
------------------------------------
CREATE PROCEDURE [dbo].[Up_LbCategory_GetIdData]
@LbCategoryID int
 AS 
	SELECT 
	[Name],[ParentID],[Desc]
	 FROM KyLbCategory
	 WHERE [LbCategoryID] = @LbCategoryID

GO

-- ----------------------------
-- Procedure structure for Up_LbCategory_GetParentIDList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_LbCategory_GetParentIDList]
GO

CREATE PROCEDURE [dbo].[Up_LbCategory_GetParentIDList]
@ParentID int
 AS 
	SELECT 
	[LbCategoryID],[Name],[ParentID],[Desc]
	 FROM KyLbCategory
	 WHERE [ParentID] = @ParentID

GO

-- ----------------------------
-- Procedure structure for Up_LbCategory_ID
-- ----------------------------
DROP PROCEDURE [dbo].[Up_LbCategory_ID]
GO

CREATE PROCEDURE [dbo].[Up_LbCategory_ID] 
AS
Select * FROM KyLbCategory
GO

-- ----------------------------
-- Procedure structure for Up_LbCategory_Update
-- ----------------------------
DROP PROCEDURE [dbo].[Up_LbCategory_Update]
GO

CREATE PROCEDURE [dbo].[Up_LbCategory_Update]
@LbCategoryID int,
@Name nvarchar(100),
@ParentID int,
@Desc nvarchar(200)
 AS 
	UPDATE KyLbCategory SET 
	[Name] = @Name,[ParentID] = @ParentID,[Desc] = @Desc
	WHERE [LbCategoryID] = @LbCategoryID

GO

-- ----------------------------
-- Procedure structure for Up_LbContent_DeleteLbCategoryId
-- ----------------------------
DROP PROCEDURE [dbo].[Up_LbContent_DeleteLbCategoryId]
GO
CREATE PROCEDURE [dbo].[Up_LbContent_DeleteLbCategoryId] 
@lbCategoryID int
AS
delete from KyLabelContent where LbCategoryId =@lbCategoryID
GO

-- ----------------------------
-- Procedure structure for Up_Link_Add
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Link_Add]
GO
CREATE PROCEDURE [dbo].[Up_Link_Add]
@LinkType int ,
@LinkCategory nvarchar(40) ,
@SiteName nvarchar(100) ,
@SiteUrl varchar(255) ,
@SiteLogo varchar(255) ,
@OwnerName nvarchar(100) ,
@Email nvarchar(100) ,
@Description nvarchar(400) ,
@AddTime datetime ,
@Status int ,
@IsDisable bit
 AS 
	INSERT INTO KyLink(
	[LinkType],[LinkCategory],[SiteName],[SiteUrl],[SiteLogo],[OwnerName],[Email],[Description],[AddTime],[Status],[IsDisable]
	)VALUES(
	@LinkType,@LinkCategory,@SiteName,@SiteUrl,@SiteLogo,@OwnerName,@Email,@Description,@AddTime,@Status,@IsDisable
	)
GO

-- ----------------------------
-- Procedure structure for Up_Link_GetList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Link_GetList]
GO


CREATE PROCEDURE [dbo].[Up_Link_GetList]
(
@PageSize int=20,
@PageIndex int=1,
@WhereString nvarchar(200)
)
AS
	
begin
DECLARE @SqlStr nvarchar(2000)
DECLARE @Filter nvarchar(200)

 
if(@WhereString ='')
	begin
	 set @WhereString=' where '
	 set @Filter=''
	end 
else
	begin
		set @Filter=' where '+@WhereString
		set @WhereString=' where '+@WhereString +' and '		
	end
	

	if(@PageIndex=1)
		Set @SqlStr = N'Select Top '+Convert(Nvarchar(10),@PageSize)+' * FROM KyLink '+@Filter +' Order By LinkId Desc'
	else
		Set @SqlStr = N'Select Top '+Convert(Nvarchar(10),@PageSize)+' * FROM KyLink '+@WhereString+' LinkId<(Select Min(LinkId) From(Select Top '+Convert(Nvarchar(10),(@PageIndex-1)*@PageSize)+' * from KyLink  '+@Filter+' Order By LinkId Desc)L) order By LinkId Desc'

end

print @SqlStr
Execute Sp_ExecuteSql @SqlStr

Set @SqlStr =' Select Count(LinkId) as Total  from KyLink '+@Filter

Exec Sp_ExecuteSql @SqlStr
GO

-- ----------------------------
-- Procedure structure for Up_Link_GetModel
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Link_GetModel]
GO
CREATE PROCEDURE [dbo].[Up_Link_GetModel]
@LinkId int
 AS 
	SELECT 
	[LinkId],[LinkType],[LinkCategory],[SiteName],[SiteUrl],[SiteLogo],[OwnerName],[Email],[Description],[AddTime],[Status],[IsDisable]
	 FROM KyLink
	 WHERE [LinkId] = @LinkId
GO

-- ----------------------------
-- Procedure structure for Up_Link_Set
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Link_Set]
GO
CREATE PROCEDURE [dbo].[Up_Link_Set]
@LinkId int,
@Type int
 AS 

if(@Type=1)--删除
begin
	DELETE KyLink
	 WHERE [LinkId] = @LinkId
end

if(@Type=2)--通过审核
begin
	Update KyLink set Status=2 where LinkId=@LinkId
end

if(@Type=3)--停用
begin
	Update KyLink set IsDisable=1 where LinkId=@LinkId
end

if(@Type=4)--启用
begin
	Update KyLink Set IsDisable=0 where LinkId=@LinkId
end
GO

-- ----------------------------
-- Procedure structure for Up_Link_Update
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Link_Update]
GO
CREATE PROCEDURE [dbo].[Up_Link_Update]
@LinkId int,
@LinkType int,
@LinkCategory nvarchar(40),
@SiteName nvarchar(100),
@SiteUrl varchar(255),
@SiteLogo varchar(255),
@OwnerName nvarchar(100),
@Email nvarchar(100),
@Description nvarchar(400),
@AddTime datetime,
@Status int,
@IsDisable bit
 AS 
	UPDATE KyLink SET 
	[LinkType] = @LinkType,[LinkCategory] = @LinkCategory,[SiteName] = @SiteName,[SiteUrl] = @SiteUrl,[SiteLogo] = @SiteLogo,[OwnerName] = @OwnerName,[Email] = @Email,[Description] = @Description,[AddTime] = @AddTime,[Status] = @Status,[IsDisable]=@IsDisable
	WHERE [LinkId] = @LinkId
GO

-- ----------------------------
-- Procedure structure for Up_Log_Add
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Log_Add]
GO

CREATE Procedure [dbo].[Up_Log_Add]
@LogType int,
@UserName Nvarchar(20),
@UserId Int,
@Description Nvarchar(100),
@IpAddress Varchar(15),
@LogTime DateTime
As
Insert Into KyLog(LogType,UserName,UserId,Description,IpAddress,LogTime)
Values(@LogType,@UserName,@UserId,@Description,@IpAddress,@LogTime)


GO

-- ----------------------------
-- Procedure structure for Up_Log_Delete
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Log_Delete]
GO

Create Procedure [dbo].[Up_Log_Delete]
@LogTime DateTime
As
Delete From KyLog Where LogTime<@LogTime


GO

-- ----------------------------
-- Procedure structure for Up_Log_GetList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Log_GetList]
GO

CREATE Procedure [dbo].[Up_Log_GetList]
@LogType Int,
@UserName Nvarchar(20),
@StartTime Varchar(10),
@EndTime Varchar(10),
@CurrPage Int,
@PageSize Int,
@RecordCount Int Output
As
Declare @SqlStr Nvarchar(2000);
Declare @WhereStr Nvarchar(500);
Set @WhereStr = '';
If(@LogType!=0) 
	Set @WhereStr = @WhereStr + N' LogType='+Convert(Nvarchar(5),@LogType)+' And ';
If(@UserName!='')
	Set @WhereStr = @WhereStr + N' UserName='''+@UserName+''' And ';
if(@StartTime!=' 'And @EndTime!='')
	Set @WhereStr = @WhereStr + N' LogTime >= '''+@StartTime+''' And LogTime< '''+@EndTime +''' And '
If(@StartTime!='' And @EndTime='')
	Set @WhereStr = @WhereStr + N' LogTime >= '''+@StartTime+''' And '
If(@StartTime='' And @EndTime!='')
	Set @WhereStr = @WhereStr + N' LogTime < '''+@EndTime+''' And '
Set @WhereStr = @WhereStr + N' 1=1 '
If(@CurrPage=1)
	Set @SqlStr = N'Select Top '+Convert(Nvarchar(15),@PageSize)+' * From KyLog Where '+@WhereStr+' Order By LogId Desc ';
Else
	Set @SqlStr = N'Select Top '+Convert(Nvarchar(15),@PageSize)+' * From KyLog Where LogId <(Select Min(LogId) From(Select Top '+Convert(Nvarchar(15),(@CurrPage-1)*@PageSize)+' LogId From KyLog Where '+@WhereStr+' Order By LogId Desc)O) And '+@WhereStr+' Order By LogId Desc'
Execute SP_ExecuteSql @SqlStr
Set @SqlStr = N'Select @TRecordCount=Count(LogId) From KyLog Where '+@WhereStr;
Declare @Param Nvarchar(50)
Set @Param = N'@TRecordCount int output'
Execute SP_ExecuteSql @SqlStr,@Param,@TRecordCount=@RecordCount output




GO

-- ----------------------------
-- Procedure structure for Up_Model_AddTable
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Model_AddTable]
GO
CREATE Procedure [dbo].[Up_Model_AddTable]
@TableName nvarchar(50)  
As  
Declare @sqlstr nvarchar(4000)  
set @sqlstr=N'  
CREATE TABLE [dbo].['+@TableName+']   
(  
[Id] [int] IDENTITY (1, 1) PRIMARY Key NOT NULL,  
[ColId] [int] NOT NULL ,  
[Title] [nvarchar] (200)  COLLATE Chinese_PRC_CI_AS NULL DEFAULT(''''),  
[TitleColor] [nvarchar] (6) COLLATE Chinese_PRC_CI_AS NULL DEFAULT(''''),  
[TitleFontType] [int]   NULL DEFAULT (0),  
[TitleType] [int]   NULL DEFAULT (0),  
[TitleImgPath] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL DEFAULT (''''),  
[UId] [int] NOT NULL ,  
[UName] [nvarchar] (20) COLLATE Chinese_PRC_CI_AS NOT NULL ,  
[UserType] [int] NOT NULL ,  
[AdminUId] [int] NULL ,  
[AdminUName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL DEFAULT (''''),  
[Status] [int]  NULL DEFAULT (0),  
[HitCount] [int]  NULL DEFAULT (0),  
[AddTime] [datetime] NOT NULL ,  
[UpdateTime] [datetime] NOT NULL ,  
[TemplatePath] [varchar] (255) COLLATE Chinese_PRC_CI_AS NOT NULL DEFAULT ('''') ,  
[PageType] [int] NULL DEFAULT (1) ,  
[IsCreated] [bit]  NULL DEFAULT (0),  
[UserCateId] [int]  NULL DEFAULT (0),  
[PointCount] [int]  NULL DEFAULT (0),  
[ChargeType] [int]  NULL DEFAULT (1),  
[ChargeHourCount] [int]  NULL DEFAULT (0),  
[ChargeViewCount] [int] NULL DEFAULT (0) ,  
[IsOpened] [int]  NULL DEFAULT (2),  
[GroupIdStr] [varchar] (200)  COLLATE Chinese_PRC_CI_AS NULL DEFAULT (''''),  
[IsDeleted] [bit] NULL DEFAULT (0) ,  
[IsRecommend] [bit]  NULL DEFAULT (0),  
[IsTop] [bit]  NULL DEFAULT (0),  
[IsFocus] [bit]  NULL DEFAULT (0),  
[IsSideShow] [bit] NULL DEFAULT (0) ,  
[TagIdStr] [varchar] (300)  COLLATE Chinese_PRC_CI_AS NULL DEFAULT (''''),  
[TagNameStr] [nvarchar] (300)  COLLATE Chinese_PRC_CI_AS NULL DEFAULT (''''),  
[IsAllowComment] [bit]  NULL DEFAULT (0),  
[SpecialIdStr] [varchar] (200)  COLLATE Chinese_PRC_CI_AS NULL DEFAULT ('''') )  
CREATE  INDEX [IX_'+@TableName+'_ColId] ON ['+@TableName+']([ColId]) ON [PRIMARY]  
CREATE  INDEX [IX_'+@TableName+'_AddTime] ON ['+@TableName+']([AddTime]) ON [PRIMARY]  
CREATE  INDEX [IX_'+@TableName+'_SpecialIdStr] ON ['+@TableName+']([SpecialIdStr]) ON [PRIMARY]  
CREATE  INDEX [IX_'+@TableName+'_TagIdStr] ON ['+@TableName+']([TagIdStr]) ON [PRIMARY]'  
exec sp_executesql @sqlstr  

GO

-- ----------------------------
-- Procedure structure for Up_Model_CheckExistsChannel
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Model_CheckExistsChannel]
GO
Create Procedure [dbo].[Up_Model_CheckExistsChannel]
@modelid int
as
if exists(select * from kychannel where modeltype=@modelid)
select 1
else
select 0

GO

-- ----------------------------
-- Procedure structure for Up_Model_CheckTableValidate
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Model_CheckTableValidate]
GO
CREATE Procedure [dbo].[Up_Model_CheckTableValidate]
@TableName nvarchar(50)
As
If exists (select * from sysobjects where xtype='U' and name=@TableName)
select 0
Else
select 1


GO

-- ----------------------------
-- Procedure structure for Up_Model_CheckUploadPathValidate
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Model_CheckUploadPathValidate]
GO
CREATE Procedure [dbo].[Up_Model_CheckUploadPathValidate]
@UploadPath nvarchar(50)
As
If exists (select * From KyModel where UploadPath=@UploadPath)
select 0
Else
select 1

GO

-- ----------------------------
-- Procedure structure for Up_Model_Delete
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Model_Delete]
GO
CREATE Procedure [dbo].[Up_Model_Delete]
@modelid int
As
declare @tablename nvarchar(50)
set @tablename=''
set @tablename=(select tablename from kymodel where modelid=@modelid)
declare @sqlstr nvarchar(1000)
declare @param nvarchar(100);
set @param='@tmodelid int'
if(@tablename!='')
begin
	set @sqlstr = N'delete from kymodel where modelid=@tmodelid'
	exec sp_executesql @sqlstr,@param,@tmodelid=@modelid
	set @sqlstr = N'drop table ['+@tablename+']'
	exec sp_executesql @sqlstr
	set @sqlstr = N'delete from kymodelfield where modelId=@tmodelid'
  	exec sp_executesql @sqlstr,@param,@tmodelid=@modelid
end

GO

-- ----------------------------
-- Procedure structure for Up_Model_GetInfo
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Model_GetInfo]
GO
create procedure [dbo].[Up_Model_GetInfo]
@modelid int
As
select * from KyModel where modelid=@modelid

GO

-- ----------------------------
-- Procedure structure for Up_Model_GetList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Model_GetList]
GO
Create Procedure [dbo].[Up_Model_GetList]
As
select * from KyModel

GO

-- ----------------------------
-- Procedure structure for Up_Model_ModelHtml
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Model_ModelHtml]
GO
CREATE PROCEDURE [dbo].[Up_Model_ModelHtml]
@ModelHtml ntext,
@ModelId int
AS
	update [KyModel] set ModelHtml=@ModelHtml where ModelId=@ModelId
	RETURN

GO

-- ----------------------------
-- Procedure structure for Up_Model_Out
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Model_Out]
GO
CREATE PROCEDURE [dbo].[Up_Model_Out]
@InModelId nvarchar(2000)
 AS
 Declare @SqlStr Nvarchar(2000);  
 set @SqlStr=N'select * from [KyModel] where ModelId in('+@InModelId+')';
 Execute Sp_ExecuteSql @SqlStr
GO

-- ----------------------------
-- Procedure structure for Up_Model_Set
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Model_Set]
GO
CREATE Procedure [dbo].[Up_Model_Set]  
@ModelId int,  
@ModelName nvarchar(20),  
@ModelDesc nvarchar(200),  
@TableName nvarchar(50),  
@UploadPath varchar(50),  
@UploadSize int,
@ModelHtml ntext,
@IsHtml bit
As  
If(@ModelId=0)  
Begin  
 insert into kymodel (modelname,modeldesc,tablename,uploadpath,uploadsize,ModelHtml,IsHtml)  
 values(@modelname,@modeldesc,@tablename,@uploadpath,@uploadsize,@ModelHtml,@IsHtml)  
 select scope_identity()  
End  
Else  
Begin  
 update kymodel set modelname=@modelname,modeldesc=@modeldesc,uploadpath=@uploadpath,uploadsize=@uploadsize,IsHtml=@IsHtml 
 where modelid=@modelid  
 select @modelid  
End
GO

-- ----------------------------
-- Procedure structure for Up_ModelField_Add
-- ----------------------------
DROP PROCEDURE [dbo].[Up_ModelField_Add]
GO
CREATE PROCEDURE [dbo].[Up_ModelField_Add]
@ModelId int,
@Name nvarchar(100) ,
@Alias nvarchar(300) ,
@Description nvarchar(400) ,
@IsNotNull bit ,
@IsSearchForm bit ,
@Type nvarchar(100) ,
@Content ntext ,
@AddDate datetime 
 AS
	Declare @OrderId int; 
	set @OrderId=(select Max(OrderId) from [KyModelField] where ModelId=@ModelId)
	
	if @OrderId is null
		set @OrderId=0
	else
		set @OrderId=@OrderId+1
	
	INSERT INTO [KyModelField]([ModelId],[Name],[Alias],[Description],[IsNotNull],[IsSearchForm],[Type],[Content],[AddDate],[OrderId]) VALUES(@ModelId,@Name,@Alias,@Description,@IsNotNull,@IsSearchForm,@Type,@Content,@AddDate,@OrderId)
	
	RETURN
GO

-- ----------------------------
-- Procedure structure for Up_ModelField_AddField
-- ----------------------------
DROP PROCEDURE [dbo].[Up_ModelField_AddField]
GO
CREATE PROCEDURE [dbo].[Up_ModelField_AddField]
@TableName nvarchar(50),
@FieldName nvarchar(50),
@FieldType nvarchar(50),
@DefaultValue nvarchar(150)
AS
	declare @sqlstr nvarchar(1000)
	
	if(@FieldType='nvarchar')
		set @sqlstr = 'ALTER TABLE ['+@TableName+'] ADD ['+@FieldName+'] nvarchar(100) DEFAULT ('''+@DefaultValue+''')'
	else if(@FieldType='varchar')
		set @sqlstr = 'ALTER TABLE ['+@TableName+'] ADD ['+@FieldName+'] varchar(100)'
	else if(@FieldType='ntext')
		set @sqlstr = 'ALTER TABLE ['+@TableName+'] ADD ['+@FieldName+'] ntext'
	else if(@FieldType='int')
		set @sqlstr = 'ALTER TABLE ['+@TableName+'] ADD ['+@FieldName+'] int'
	else if(@FieldType='bit')
		set @sqlstr = 'ALTER TABLE ['+@TableName+'] ADD ['+@FieldName+'] bit'
	else if(@FieldType='char')
		set @sqlstr = 'ALTER TABLE ['+@TableName+'] ADD ['+@FieldName+'] char(10)'
	else if(@FieldType='datetime')
		set @sqlstr = 'ALTER TABLE ['+@TableName+'] ADD ['+@FieldName+'] datetime'
	else if(@FieldType='decimal')
		set @sqlstr = 'ALTER TABLE ['+@TableName+'] ADD ['+@FieldName+'] decimal(8)'
	else if(@FieldType='money')
		set @sqlstr = 'ALTER TABLE ['+@TableName+'] ADD ['+@FieldName+'] money'
	else if(@FieldType='nchar')
		set @sqlstr = 'ALTER TABLE ['+@TableName+'] ADD ['+@FieldName+'] nchar(10)'
	else if(@FieldType='text')
		set @sqlstr = 'ALTER TABLE ['+@TableName+'] ADD ['+@FieldName+'] text'
	else if(@FieldType='float')
		set @sqlstr = 'ALTER TABLE ['+@TableName+'] ADD ['+@FieldName+'] float(8)'
execute sp_executesql @sqlstr
GO

-- ----------------------------
-- Procedure structure for Up_ModelField_Del
-- ----------------------------
DROP PROCEDURE [dbo].[Up_ModelField_Del]
GO
CREATE PROCEDURE [dbo].[Up_ModelField_Del]
	@FieldId int
AS
	/* SET NOCOUNT ON */ 
	delete from [KyModelField] where FieldId=@FieldId
	RETURN

GO

-- ----------------------------
-- Procedure structure for Up_ModelField_DelField
-- ----------------------------
DROP PROCEDURE [dbo].[Up_ModelField_DelField]
GO
CREATE PROCEDURE [dbo].[Up_ModelField_DelField]
	@TableName nvarchar(50),
	@FieldName nvarchar(50)
AS 
	Declare @Name nvarchar(50)
	declare @sqlstr nvarchar(500)
	
	select @Name=b.name from syscolumns a,sysobjects b where a.id=object_id(@TableName) and b.id=a.cdefault and a.name=@FieldName and b.name like 'DF%'

	set @sqlstr = 'ALTER TABLE ['+@TableName+'] drop constraint ['+@Name+']'
	execute sp_executesql @sqlstr
	
	set @sqlstr = 'ALTER TABLE ['+@TableName+'] DROP COLUMN ['+@FieldName+']'
	execute sp_executesql @sqlstr
	RETURN

GO

-- ----------------------------
-- Procedure structure for Up_ModelField_GetAllTable
-- ----------------------------
DROP PROCEDURE [dbo].[Up_ModelField_GetAllTable]
GO
CREATE PROCEDURE [dbo].[Up_ModelField_GetAllTable]
AS
	select name from [sysobjects] where xtype='U' order by name
GO

-- ----------------------------
-- Procedure structure for Up_ModelField_GetList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_ModelField_GetList]
GO
CREATE PROCEDURE [dbo].[Up_ModelField_GetList] 
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
	@ModelId int
AS
	/* SET NOCOUNT ON */ 
	select * from [KyModelField] where ModelId=@ModelId order by OrderId
	RETURN
GO

-- ----------------------------
-- Procedure structure for Up_ModelField_GetModel
-- ----------------------------
DROP PROCEDURE [dbo].[Up_ModelField_GetModel]
GO
CREATE PROCEDURE [dbo].[Up_ModelField_GetModel]
	@FieldId int
AS
	/* SET NOCOUNT ON */ 
	select * from [KyModelField] where FieldId=@FieldId
	RETURN

GO

-- ----------------------------
-- Procedure structure for Up_ModelField_GetSearchField
-- ----------------------------
DROP PROCEDURE [dbo].[Up_ModelField_GetSearchField]
GO
create proc [dbo].[Up_ModelField_GetSearchField]
@modelid int
as
select * from kymodelfield where modelid=@modelid and issearchform=1

GO

-- ----------------------------
-- Procedure structure for Up_ModelField_GetTableAllField
-- ----------------------------
DROP PROCEDURE [dbo].[Up_ModelField_GetTableAllField]
GO
CREATE PROCEDURE [dbo].[Up_ModelField_GetTableAllField]
	@TableName nvarchar(50)
AS
	select a.name from syscolumns a,sysobjects b where a.id=b.id and b.name=@TableName order by a.colid
	RETURN
GO

-- ----------------------------
-- Procedure structure for Up_ModelField_GetTableAllFieldAndType
-- ----------------------------
DROP PROCEDURE [dbo].[Up_ModelField_GetTableAllFieldAndType]
GO
CREATE PROCEDURE [dbo].[Up_ModelField_GetTableAllFieldAndType]
	@TableName nvarchar(50)
AS
	select COLUMN_NAME,DATA_TYPE from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME=@TableName
	RETURN
GO

-- ----------------------------
-- Procedure structure for Up_ModelField_InModelId
-- ----------------------------
DROP PROCEDURE [dbo].[Up_ModelField_InModelId]
GO
CREATE PROCEDURE [dbo].[Up_ModelField_InModelId]
@InModelId nvarchar(2000)
AS
	Declare @SqlStr Nvarchar(2000);  
 set @SqlStr=N'select * from [KyModelField] where ModelId in('+@InModelId+')';
 Execute Sp_ExecuteSql @SqlStr
	RETURN
GO

-- ----------------------------
-- Procedure structure for Up_ModelField_IsNotField
-- ----------------------------
DROP PROCEDURE [dbo].[Up_ModelField_IsNotField]
GO
CREATE PROCEDURE [dbo].[Up_ModelField_IsNotField]
	@TableName nvarchar(50),
	@FieldName nvarchar(50)
AS 
	select * from syscolumns a,sysobjects b where a.id=b.id and a.name=@FieldName and b.name=@TableName
	RETURN

GO

-- ----------------------------
-- Procedure structure for Up_ModelField_MoveField
-- ----------------------------
DROP PROCEDURE [dbo].[Up_ModelField_MoveField]
GO
CREATE PROCEDURE [dbo].[Up_ModelField_MoveField]
	@ModelId int,
	@FieldId int,
	@MoveType nvarchar(20)
AS
	Declare @OrderId int;
	Declare @NewFieldId int;
	Declare @NewOrderId int;
	
	if @MoveType='UpMove'
	begin	
		declare @MinOrderId int;
		set @MinOrderId=(select min(OrderId) from [KyModelField] where ModelId=@ModelId)
		
		set @OrderId=(select OrderId from [KyModelField] where ModelId=@ModelId and FieldId=@FieldId)
		
		if @OrderId!=@MinOrderId
		begin
			set @NewFieldId=(select top 1 FieldId from [KyModelField] where ModelId=@ModelId and OrderId<@OrderId order by OrderId desc)
			set @NewOrderId=(select OrderId from [KyModelField] where ModelId=@ModelId and FieldId=@NewFieldId)
			
			update [KyModelField] set OrderId=@OrderId where FieldId=@NewFieldId and ModelId=@ModelId
			update [KyModelField] set OrderId=@NewOrderId where FieldId=@FieldId and ModelId=@ModelId
		end
	end
	
	if @MoveType='DownMove'
	begin
		declare @MaxOrderId int;
		set @MaxOrderId=(select max(OrderId) from [KyModelField] where ModelId=@ModelId)
		
		set @OrderId=(select OrderId from [KyModelField] where ModelId=@ModelId and FieldId=@FieldId)
		
		if @OrderId!=@MaxOrderId
		begin
			set @NewFieldId=(select top 1 FieldId from [KyModelField] where ModelId=@ModelId and OrderId>@OrderId order by OrderId)
			set @NewOrderId=(select OrderId from [KyModelField] where ModelId=@ModelId and FieldId=@NewFieldId)
			
			update [KyModelField] set OrderId=@OrderId where FieldId=@NewFieldId and ModelId=@ModelId
			update [KyModelField] set OrderId=@NewOrderId where FieldId=@FieldId and ModelId=@ModelId
		end
	end
	RETURN

GO

-- ----------------------------
-- Procedure structure for Up_ModelField_SelectPropertyTrue
-- ----------------------------
DROP PROCEDURE [dbo].[Up_ModelField_SelectPropertyTrue]
GO
CREATE PROCEDURE [dbo].[Up_ModelField_SelectPropertyTrue]

@ModelId nvarchar(50)
 AS
	select * from [KyModelField] where ModelId=@ModelId and Type='RadioType' and Content like '%Property=True%' order by OrderId
	
RETURN
GO

-- ----------------------------
-- Procedure structure for Up_ModelField_Update
-- ----------------------------
DROP PROCEDURE [dbo].[Up_ModelField_Update]
GO
CREATE PROCEDURE [dbo].[Up_ModelField_Update]
@FieldId int,
@ModelId int,
@Alias nvarchar(300),
@Description nvarchar(400),
@IsNotNull bit,
@IsSearchForm bit,
@Content ntext,
@AddDate datetime
AS
	UPDATE KyModelField SET [Alias] = @Alias,[Description] = @Description,[IsNotNull] = @IsNotNull,[IsSearchForm] = @IsSearchForm,[Content] = @Content,[AddDate] = @AddDate WHERE [FieldId] = @FieldId and ModelId=@ModelId
	RETURN
GO

-- ----------------------------
-- Procedure structure for Up_ModelField_UpdateFieldDefault
-- ----------------------------
DROP PROCEDURE [dbo].[Up_ModelField_UpdateFieldDefault]
GO
CREATE PROCEDURE [dbo].[Up_ModelField_UpdateFieldDefault]
	@TableName nvarchar(50),
	@FieldName nvarchar(50),
	@DefaultValue nvarchar(50)
AS
	Declare @Name nvarchar(50)
	declare @sqlstr nvarchar(1000)
	
	select @Name=b.name from syscolumns a,sysobjects b where a.id=object_id(@TableName) and b.id=a.cdefault and a.name=@FieldName and b.name like 'DF%'

	set @sqlstr = 'ALTER TABLE ['+@TableName+'] drop constraint ['+@Name+']'
	execute sp_executesql @sqlstr
	
	set @sqlstr='alter table ['+@TableName+'] add default ('''+@DefaultValue+''') for ['+@FieldName+']'
	execute sp_executesql @sqlstr

	RETURN

GO

-- ----------------------------
-- Procedure structure for UP_Notice
-- ----------------------------
DROP PROCEDURE [dbo].[UP_Notice]
GO

CREATE PROCEDURE [dbo].[UP_Notice]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
	@NoticeId int=0,
	@Title nvarchar(300)=" " ,
	@Content ntext=" " ,
	@UserId int=0 ,
	@UserName nvarchar(100)=" " ,
	@OverdueDate datetime=" " ,
	@IsPriority int=0 ,
	@IsState nvarchar(20)=" " ,
	@AddDate datetime=" ",
	@TypeId int=0 
AS
	/* SET NOCOUNT ON */ 
	
	/* 新增一条记录 */
	if @TypeId=1
	begin
		INSERT INTO KyNotice([Title],[Content],[UserId],[UserName],[OverdueDate],[IsPriority],[IsState],[AddDate])VALUES(@Title,@Content,@UserId,@UserName,@OverdueDate,@IsPriority,@IsState,@AddDate)
	end
	
	/* 更新一条记录 */
	if @TypeId=2
	begin
		UPDATE KyNotice SET [Title] = @Title,[Content] = @Content,[UserId] = @UserId,[UserName] = @UserName,[OverdueDate] = @OverdueDate,[IsPriority] = @IsPriority,[IsState] = @IsState,[AddDate] = @AddDate WHERE [NoticeId] = @NoticeId
	end
	
	/* 删除一条记录 */
	if @TypeId=3
	begin
		DELETE KyNotice WHERE [NoticeId] = @NoticeId
	end
	
	/* 显示一条记录 */
	if @TypeId=4
	begin
		SELECT [NoticeId],[Title],[Content],[UserId],[UserName],[OverdueDate],[IsPriority],[IsState],[AddDate] FROM KyNotice where NoticeId = @NoticeId 
	end
	
	
	/* 更新状态 */
	if @TypeId=5
	begin
		UPDATE KyNotice SET [IsState] = @IsState WHERE [NoticeId] = @NoticeId
	end
	
	RETURN

GO

-- ----------------------------
-- Procedure structure for Up_Notice_GetTop
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Notice_GetTop]
GO

CREATE PROCEDURE [dbo].[Up_Notice_GetTop]

	@Top Int
AS

	Declare @SqlStr Nvarchar(2000);  

		set @SqlStr=N'Select Top '+Convert(Nvarchar(15),@Top)+' * from [KyNotice]  where datediff(day,OverdueDate,getdate())<=0 and IsState=''审核通过'' order by IsPriority desc,NoticeId desc'

	Execute Sp_ExecuteSql @SqlStr
	RETURN
GO

-- ----------------------------
-- Procedure structure for Up_PowerColumn_Update
-- ----------------------------
DROP PROCEDURE [dbo].[Up_PowerColumn_Update]
GO

CREATE PROCEDURE [dbo].[Up_PowerColumn_Update]

	@id int
AS

	select * from [KyPowerColumn] where  PCId=@id
	RETURN
GO

-- ----------------------------
-- Procedure structure for Up_PowerGroup
-- ----------------------------
DROP PROCEDURE [dbo].[Up_PowerGroup]
GO

CREATE PROCEDURE [dbo].[Up_PowerGroup]

	@PowerId int=0,
	@PowerName nvarchar(50)=" ",
	@PowerColumn ntext=" ",
	@PowerChannel ntext=" ",
	@PowerAuditing ntext=" ",
	@PowerModel nvarchar(50)=" ",
	@PowerContent nvarchar(500)=" ",
	@AddDate datetime="2007-8-20",
	@TypeId int=0
AS
	/* SET NOCOUNT ON */
	
	/*列表 */
	if @TypeId=1
	begin
		select * from [KyPowerGroup] where PowerModel='否' order by PowerId desc
	end	
	
	/* 选择一条记录 */
	if @TypeId=2
	begin
		select * from [KyPowerGroup] where PowerId=@PowerId 
	end
	
	/* 更新一条记录 */
	if @TypeId=3
	begin
		update [KyPowerGroup] set PowerName=@PowerName,PowerColumn=@PowerColumn,PowerChannel=@PowerChannel,PowerAuditing=@PowerAuditing,PowerModel=@PowerModel,PowerContent=@PowerContent where PowerId=@PowerId   
	end
	
	/* 删除一条记录 */
	if @TypeId=4
	begin
		delete [KyPowerGroup] where PowerId=@PowerId
	end
	
	/* 插入一条记录 */
	if @TypeId=5
	begin
		insert into [KyPowerGroup] (PowerName,PowerColumn,PowerChannel,PowerAuditing,PowerModel,PowerContent,AddDate) values(@PowerName,@PowerColumn,@PowerChannel,@PowerAuditing,@PowerModel,@PowerContent,@AddDate)
	end
	
	/* 列出栏目表内容 */
	if @TypeId=6
	begin
		select * from [KyPowerColumn] order by PCId asc
	end
	
	/* 列出角色模型 */
	if @TypeId=7
	begin
		select PowerId,PowerName from [KyPowerGroup] where PowerModel='是' order by PowerId
	end
	RETURN

GO

-- ----------------------------
-- Procedure structure for Up_Recycle_Restore
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Recycle_Restore]
GO
CREATE PROCEDURE [dbo].[Up_Recycle_Restore]
@TableName varchar(50),
@Type int,
@Id int
AS

declare @SqlStr nvarchar(2000)
declare @Filed nvarchar(200)

if(@Type=1)--频道
	begin
	set @SqlStr='update KyChannel set [IsDeleted]=0 where ChId='+Convert(nvarchar(10),@Id)
	end
if (@Type=2)--栏目
	begin
	set @SqlStr='update KyColumn set [IsDeleted]=0 where ColId='+Convert(nvarchar(10),@Id)
	end
if(@Type=3)--专题
	begin
	set @SqlStr='update KySpecial set [IsDeleted]=0 where [Id]='+Convert(nvarchar(10),@Id)
	end
if(@Type=4)--内容
	begin
	if(@TableName='')
	return;
	set @SqlStr='update '+@TableName+' set [IsDeleted]=0 where [Id]='+Convert(nvarchar(10),@Id)
	end


execute sp_executesql @SqlStr
GO

-- ----------------------------
-- Procedure structure for Up_Report_Add
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Report_Add]
GO

Create Procedure [dbo].[Up_Report_Add]
@Content nvarchar(500),
@Url varchar(255),
@UserId int,
@UserName nvarchar(20),
@IsComplete int,
@AddTime datetime
As
insert into KyReport([Content],[Url],[UserId],[UserName],[IsComplete],[AddTime])
values(@Content,@Url,@UserId,@UserName,@IsComplete,@AddTime)



GO

-- ----------------------------
-- Procedure structure for Up_Report_Delete
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Report_Delete]
GO

Create Procedure [dbo].[Up_Report_Delete]
@ReportId int
as
Delete From  KyReport  Where ReportId=@ReportId


GO

-- ----------------------------
-- Procedure structure for Up_Report_GetList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Report_GetList]
GO

CREATE Procedure [dbo].[Up_Report_GetList]
@PageIndex Int,
@PageSize Int,
@WhereStr Nvarchar(1000)
As
Declare @SqlStr Nvarchar(2000)
If(@PageIndex=1)
	Set @SqlStr = N'Select Top '+Convert(nvarchar(15),@PageSize)+' * From KyReport Where '+@WhereStr + ' Order By ReportId Desc'  ;
Else
	Set @SqlStr = N'Select Top '+Convert(nvarchar(15),@PageSize)+' * From KyReport Where ReportId Not In(Select Top '+Convert(nvarchar(15),(@PageIndex-1)*@PageSize)+' ReportId From KyReport Where '+@WhereStr+') And '+@WhereStr+' Order By ReportId Desc'
Execute Sp_ExecuteSql @SqlStr
Set @SqlStr = N'Select Count(ReportId) From KyReport Where '+@WhereStr
Execute Sp_ExecuteSql @SqlStr



GO

-- ----------------------------
-- Procedure structure for Up_Report_SetStatus
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Report_SetStatus]
GO

CREATE Procedure [dbo].[Up_Report_SetStatus]
@ReportId int,
@Status int
as
Update KyReport Set IsComplete=@Status Where ReportId=@ReportId And IsComplete=0

GO

-- ----------------------------
-- Procedure structure for Up_Review_Add
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Review_Add]
GO
CREATE PROCEDURE [dbo].[Up_Review_Add]   
@ModelType int ,  
@InfoId int ,  
@ReviewTitle nvarchar(200) ,  
@IsArgue bit ,  
@IsSquare tinyint ,  
@BrarNum int ,  
@FightNum int ,  
@IsElite bit ,  
@ReviewContent ntext ,  
@ReviewTime datetime ,  
@UserNum nvarchar(36) ,  
@ReviewIP nvarchar(40) ,  
@IsCheck bit   
 AS   
INSERT INTO KyReview([ModelType],[InfoId],[ReviewTitle],[IsArgue],[IsSquare],[BrarNum],[FightNum],[IsElite],[ReviewContent],[ReviewTime],[UserNum],[ReviewIP],[IsCheck]  
)VALUES(@ModelType,@InfoId,@ReviewTitle,@IsArgue,@IsSquare,@BrarNum,@FightNum,@IsElite,@ReviewContent,@ReviewTime,@UserNum,@ReviewIP,@IsCheck ) 

GO

-- ----------------------------
-- Procedure structure for Up_Review_GetManageList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Review_GetManageList]
GO
CREATE procedure [dbo].[Up_Review_GetManageList]  
@tablename nvarchar(20),  
@modeltype int,  
@ischeck bit,  
@pageindex int,  
@pagesize int  
as  
if(@tablename='')  
return;  
declare @sqlstr nvarchar(2000)  
declare @param nvarchar(200)  
declare @selecttable nvarchar(500)  
set @selecttable = ' ['+@tablename+'] i join kyreview re on re.modeltype=@tmodeltype and i.[id]=re.infoid '  
set @param = '@tischeck bit,@tmodeltype int'  
if(@pageindex=1)  
 set @sqlstr = 'select distinct top '+convert(nvarchar(15),@pagesize)+' i.[id],i.title from '+@selecttable+ ' where re.ischeck=@tischeck order by i.[id] desc'  
else  
 set @sqlstr = 'select distinct top '+convert(nvarchar(15),@pagesize)+' i.[id],i.title from '+@selecttable+ ' where i.[id]<(select min(o.[id]) from(select distinct top '+convert(nvarchar(15),(@pageindex-1)*@pagesize)+' i.[id] from '+@selecttable+' where 
re.ischeck=@tischeck order by i.[id] desc )o) and re.ischeck=@tischeck order by i.[id] desc'  
execute sp_executesql @sqlstr,@param,@tischeck=@ischeck,@tmodeltype=@modeltype  
set @sqlstr = 'select count(*) as tatal from (select distinct i.[id] from '+@selecttable+' where re.ischeck=@tischeck)c'  
execute sp_executesql @sqlstr,@param,@tischeck=@ischeck,@tmodeltype=@modeltype 

GO

-- ----------------------------
-- Procedure structure for Up_Review_GetMoreList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Review_GetMoreList]
GO
CREATE PROCEDURE [dbo].[Up_Review_GetMoreList]  
@pageindex Int,    
@pagesize Int,   
@wherestr nvarchar(500)  
as  
declare @sqlstr nvarchar(2000);    
 if(@pageindex=1)  
  	set @sqlStr='select top '+convert(nvarchar(15),@pagesize)+' a.*,b.logname from kyreview a left join kyusers b on a.usernum=b.userid '+@wherestr+' order by [id] desc';  
 else   
  	set @sqlstr='select top '+convert(nvarchar(15),@pagesize)+' a.*,b.logname from kyreview a left join kyusers b on a.usernum=b.userid '+@whereStr+' and id not in(select top '+convert(nvarchar(15),(@pageindex-1)*@pagesize)+' id from kyreview a left join kyusers b on a.usernum=b.userid '+@wherestr+' order by [id] desc) order by [id] desc';   
  
execute sp_executesql @sqlstr    
set @sqlstr = 'select count(id) from kyreview '+@wherestr;  
execute sp_executesql @sqlstr

GO

-- ----------------------------
-- Procedure structure for Up_Review_GetTop5List
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Review_GetTop5List]
GO
CREATE PROCEDURE [dbo].[Up_Review_GetTop5List]       
@ModelType int,      
@InfoId int,      
@IsCheck bit      
AS      
Select top 5 [Id],UserNum,InfoId,ReviewContent,ReviewTime,b.logname From KyReview a left join KyUsers b on a.usernum=b.userId     
Where ModelType=@ModelType and InfoId=@InfoId and IsCheck=@IsCheck      
Order By [Id] Desc    

GO

-- ----------------------------
-- Procedure structure for Up_Review_Oper
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Review_Oper]
GO
CREATE proc [dbo].[Up_Review_Oper]  
@id int=0,  
@infoid int=0,  
@modeltype int=1,  
@typeid int,  
@ischeck bit=1  
as  
if(@typeid=1)  
begin  
 delete from kyreview where [id]=@id  
end  
else if(@typeid=2)  
begin  
 delete from kyreview where infoid=@infoid and modeltype=@modeltype  
end  
else if(@typeid=3)  
begin   
 update kyreview set ischeck=@ischeck where [id]=@id  
end  
else if(@typeid=4)  
begin  
 select * from kyreview where [id]=@id  
end  

GO

-- ----------------------------
-- Procedure structure for Up_Rss_GetInfoList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Rss_GetInfoList]
GO
CREATE procedure [dbo].[Up_Rss_GetInfoList]  
@tablename nvarchar(50),  
@chid int,  
@colid nvarchar(3000)  
as  
declare @fieldstr nvarchar(1000)  
set @fieldstr = ' i.*,m.modelid,m.tablename,m.uploadpath,ch.chid,ch.typename,ch.chname,ch.dirName,ch.infosorttype,ch.filenametype,ch.isstatictype,colisopened=co.isopened,co.colName,co.coldirname '  
declare @tablestr nvarchar(400)  
set @tablestr = ' ['+@tableName+'] as i join kycolumn co on i.colid=co.colid join kychannel ch on co.chid=ch.chid join kymodel m on ch.modeltype=m.modelid '  
declare @wherestr nvarchar(3000)  
set @wherestr = ''  
if(@chid!=0)  
 set @wherestr = @wherestr+' co.chid=@tchid and '  
if(@colid!='0')  
 set @wherestr = @wherestr+' i.colid in('+@colid+') and '  
set @wherestr=@wherestr+'  i.status=3 and i.isdeleted=0 '  
declare @sqlstr nvarchar(1000)  
set @sqlstr = 'select top 100 '+@fieldstr+'from'+@tablestr+'where'+@wherestr+' order by i.[id] desc'  
declare @param nvarchar(500)  
set @param = '@tchid int'  
execute sp_executesql @sqlstr,@param,@tchid=@chid

GO

-- ----------------------------
-- Procedure structure for Up_SinglePage_Add
-- ----------------------------
DROP PROCEDURE [dbo].[Up_SinglePage_Add]
GO
CREATE PROCEDURE [dbo].[Up_SinglePage_Add]
@Name nvarchar(200) ,
@FolderPath nvarchar(100) ,
@FileName nvarchar(200) ,
@FileExtend nvarchar(100) ,
@TemplatePath nvarchar(300) ,
@Content nvarchar(400) ,
@AddTime datetime 
 AS
INSERT INTO [KySinglePage]([Name],[FolderPath],[FileName],[FileExtend],[TemplatePath],[Content],[AddTime])VALUES(@Name,@FolderPath,@FileName,@FileExtend,@TemplatePath,@Content,@AddTime)
select scope_identity()
GO

-- ----------------------------
-- Procedure structure for Up_SinglePage_Del
-- ----------------------------
DROP PROCEDURE [dbo].[Up_SinglePage_Del]
GO
CREATE PROCEDURE [dbo].[Up_SinglePage_Del]
@SingleId int
 AS
	DELETE KySinglePage WHERE [SingleId] = @SingleId
GO

-- ----------------------------
-- Procedure structure for Up_SinglePage_GetList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_SinglePage_GetList]
GO
CREATE PROCEDURE [dbo].[Up_SinglePage_GetList]
@CurrPage Int,  
@PageSize Int
 AS
	Declare @SqlStr Nvarchar(2000);  
	If(@CurrPage=1)
		set @SqlStr=N'Select Top '+Convert(Nvarchar(15),@PageSize)+' * from [KySinglePage] order by SingleId desc';
	Else
		set @SqlStr=N'Select Top '+Convert(Nvarchar(15),@PageSize)+' * from [KySinglePage] where SingleId Not in(select Top '+Convert(Nvarchar(15),(@CurrPage-1)*@PageSize)+' SingleId from [KySinglePage] order by SingleId desc) order by SingleId desc'; 

	Execute Sp_ExecuteSql @SqlStr  
	Set @SqlStr = N'Select Count(SingleId) From [KySinglePage]';
	Execute Sp_ExecuteSql @SqlStr
GO

-- ----------------------------
-- Procedure structure for Up_SinglePage_GetModel
-- ----------------------------
DROP PROCEDURE [dbo].[Up_SinglePage_GetModel]
GO
CREATE PROCEDURE [dbo].[Up_SinglePage_GetModel]
@SingleId int
 AS
SELECT [SingleId],[Name],[FolderPath],[FileName],[FileExtend],[TemplatePath],[Content],[AddTime] FROM [KySinglePage] WHERE [SingleId] = @SingleId
GO

-- ----------------------------
-- Procedure structure for Up_SinglePage_Update
-- ----------------------------
DROP PROCEDURE [dbo].[Up_SinglePage_Update]
GO
CREATE PROCEDURE [dbo].[Up_SinglePage_Update]
@SingleId int,
@Name nvarchar(200),
@FolderPath nvarchar(100),
@FileName nvarchar(200),
@FileExtend nvarchar(100),
@TemplatePath nvarchar(300),
@Content nvarchar(400),
@AddTime datetime
 AS
	UPDATE KySinglePage SET [Name] = @Name,[FolderPath] = @FolderPath,[FileName] = @FileName,[FileExtend] = @FileExtend,[TemplatePath] = @TemplatePath,[Content] = @Content,[AddTime] = @AddTime WHERE [SingleId] = @SingleId
GO

-- ----------------------------
-- Procedure structure for Up_Site_Count
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Site_Count]
GO

--------------------
--站点访问统计
--------------------
CREATE PROCEDURE [dbo].[Up_Site_Count]
@Type varchar(10),
@Filter varchar(15)
AS

if @Type='Year'
	begin
		select * from KyCountYear where Flag=@Filter
	end
if @Type='Month'
	begin
		select * from KyCountMonth where Flag=@Filter
	end
if @Type='Week'
	begin
		select * from KyCountWeek where Flag=@Filter
	end
if @Type='Day'
	begin
		select * from KyCountDay where Flag=@Filter
	end
	
	


GO

-- ----------------------------
-- Procedure structure for up_Special_Add
-- ----------------------------
DROP PROCEDURE [dbo].[up_Special_Add]
GO

CREATE PROCEDURE [dbo].[up_Special_Add]
@ParentID int ,
@SiteID int ,
@SpecialCName nvarchar(30) ,
@SpecialEName nvarchar(20) ,
@SpecialDomain nvarchar(100) ,
@SpecialRemark nvarchar(200) ,
@IsLock bit ,
@IsCommand bit ,
@SpecialAddTime datetime ,
@MetaKeyWord nvarchar(200) ,
@MetaRemark nvarchar(200) ,
@SpecialTemplet nvarchar(200) ,
@SpecialItemNum int ,
@SpecialContent ntext ,
@SaveDirType nvarchar(200) ,
@Extension varchar(50),
@PicSavePath nvarchar(200),
@IsDeleted bit
 AS 
	INSERT INTO KySpecial(
	[ParentID],[SiteID],[SpecialCName],[SpecialEName],[SpecialDomain],[SpecialRemark],[IsLock],[IsCommand],[SpecialAddTime],[MetaKeyWord]
	,[MetaRemark],[SpecialTemplet],[SpecialItemNum],[SpecialContent],[SaveDirType],IsDeleted,Extension,PicSavePath
	)VALUES(
	@ParentID,@SiteID,@SpecialCName,@SpecialEName,@SpecialDomain,@SpecialRemark,@IsLock,@IsCommand,@SpecialAddTime,@MetaKeyWord,@MetaRemark
	,@SpecialTemplet,@SpecialItemNum,@SpecialContent,@SaveDirType,@IsDeleted,@Extension,@PicSavePath
	)
GO

-- ----------------------------
-- Procedure structure for Up_Special_CompleteDelete
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Special_CompleteDelete]
GO
CREATE proc [dbo].[Up_Special_CompleteDelete]
@specialid int
as
delete from kyspecial where id=@specialid
delete from kyspecial where parentid=@specialid
GO

-- ----------------------------
-- Procedure structure for up_Special_Delete
-- ----------------------------
DROP PROCEDURE [dbo].[up_Special_Delete]
GO

CREATE PROCEDURE [dbo].[up_Special_Delete]
@ID int
 AS 

set Xact_Abort on
BEGIN

update KySpecial set [IsDeleted]=1 where [ID]=@ID
if exists(select [ID] from KySpecial where ParentId = @ID)
	update KySpecial set [IsDeleted]=1 where ParentId = @ID

END

GO

-- ----------------------------
-- Procedure structure for Up_Special_GetAll
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Special_GetAll]
GO

CREATE PROCEDURE [dbo].[Up_Special_GetAll] 
AS
Select * From KySpecial

GO

-- ----------------------------
-- Procedure structure for Up_Special_GetChSpecialList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Special_GetChSpecialList]
GO
CREATE procedure [dbo].[Up_Special_GetChSpecialList]
@chid int
as
select * from kyspecial where (siteid=@chid or siteid=0)  and isdeleted=0

GO

-- ----------------------------
-- Procedure structure for up_Special_GetSpecial
-- ----------------------------
DROP PROCEDURE [dbo].[up_Special_GetSpecial]
GO

CREATE PROCEDURE [dbo].[up_Special_GetSpecial]
(
@ID int
)
AS
	SELECT * FROM KySpecial WHERE [ID]=@ID

GO

-- ----------------------------
-- Procedure structure for up_Special_GetSpecials
-- ----------------------------
DROP PROCEDURE [dbo].[up_Special_GetSpecials]
GO


CREATE PROCEDURE [dbo].[up_Special_GetSpecials]

(
@SelectType int,
@ParentId int
)
AS

if @SelectType = 0
	begin
	SELECT KySpecial.*,KyChannel.ChName FROM KySpecial LEFT JOIN KyChannel ON KySpecial.SiteID=KyChannel.ChId where KySpecial.parentId=0 and KySpecial.IsDeleted=0 order by KySpecial.SiteID--获取所有的父专题
	end
if @SelectType = 1
	begin
	SELECT KySpecial.*,KyChannel.ChName FROM KySpecial LEFT JOIN KyChannel ON KySpecial.SiteID=KyChannel.ChId where parentId=@ParentId and KySpecial.IsDeleted=0 order by KySpecial.SiteID--获取指定父专题的子专题
	end
if @SelectType = 2
begin
	select KySpecial.* from KySpecial Left Join KyChannel ON KySpecial.SiteID=KyChannel.ChId where KySpecial.IsLock=0 and KySpecial.IsDeleted=0  order by ID
end

GO

-- ----------------------------
-- Procedure structure for up_Special_Update
-- ----------------------------
DROP PROCEDURE [dbo].[up_Special_Update]
GO

CREATE PROCEDURE [dbo].[up_Special_Update] 
@ID int,
@ParentID int,
@SiteID int,
@SpecialCName nvarchar(30),
@SpecialDomain nvarchar(100),
@SpecialRemark nvarchar(200),
@IsLock bit,
@IsCommand bit,
@SpecialAddTime datetime,
@MetaKeyWord nvarchar(200),
@MetaRemark nvarchar(200),
@SpecialTemplet nvarchar(200),
@SpecialItemNum int,
@SpecialContent ntext,
@SaveDirType nvarchar(200),
@Extension varchar(50),
@PicSavePath nvarchar(200)
 AS 
	UPDATE KySpecial SET 
	[ParentID] = @ParentID,[SiteID] = @SiteID,[SpecialCName] = @SpecialCName,[SpecialDomain] = @SpecialDomain,[SpecialRemark] = @SpecialRemark
	,[IsLock] = @IsLock,[IsCommand] = @IsCommand,[SpecialAddTime] = @SpecialAddTime,[MetaKeyWord] = @MetaKeyWord,[MetaRemark] = @MetaRemark
	,[SpecialTemplet] = @SpecialTemplet,[SpecialItemNum] = @SpecialItemNum,[SpecialContent] = @SpecialContent
	,[SaveDirType] = @SaveDirType,Extension=@Extension,PicSavePath=@PicSavePath
	WHERE [ID] = @ID

GO

-- ----------------------------
-- Procedure structure for Up_Style_Add
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Style_Add]
GO

CREATE PROCEDURE [dbo].[Up_Style_Add]
@StyleCategoryId int ,
@Name nvarchar(100) ,
@Content text ,
@Type int 
 AS 
	INSERT INTO KyStyle(
	[StyleCategoryId],[Name],[Content],[Type]
	)VALUES(
	@StyleCategoryId,@Name,@Content,@Type
	)

GO

-- ----------------------------
-- Procedure structure for Up_Style_AddSearchStyle
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Style_AddSearchStyle]
GO
CREATE PROCEDURE [dbo].[Up_Style_AddSearchStyle] 
@modelId int,
@content ntext
AS
Insert into KyListStyleContent (ModelId,Content)values(@modelid,@content)
GO

-- ----------------------------
-- Procedure structure for Up_Style_ConById
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Style_ConById]
GO

CREATE PROCEDURE [dbo].[Up_Style_ConById] 
@StyleID int
AS
Select Content From KyStyle Where StyleID=@StyleID

GO

-- ----------------------------
-- Procedure structure for Up_Style_Delete
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Style_Delete]
GO

CREATE PROCEDURE [dbo].[Up_Style_Delete] 
@StyleId int
AS
DELETE FROM KyStyle WHERE StyleId=@StyleId


GO

-- ----------------------------
-- Procedure structure for Up_Style_DeleteAndStyleCategoryId
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Style_DeleteAndStyleCategoryId]
GO

CREATE PROCEDURE [dbo].[Up_Style_DeleteAndStyleCategoryId] 
@StyleCategoryID int
AS
Delete  from KyStyle WHERE StyleCategoryID=@StyleCategoryID

GO

-- ----------------------------
-- Procedure structure for Up_Style_GetAll
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Style_GetAll]
GO
CREATE PROCEDURE [dbo].[Up_Style_GetAll]
AS
SELECT StyleID,[Name] FROM KyStyle where [Type]<>0 ORDER BY StyleID Desc
GO

-- ----------------------------
-- Procedure structure for Up_Style_GetByModelId
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Style_GetByModelId]
GO
CREATE PROCEDURE [dbo].[Up_Style_GetByModelId] 
@type int
AS
SELECT StyleID,[Name] FROM KyStyle where [Type]=@type ORDER BY StyleID Desc
GO

-- ----------------------------
-- Procedure structure for Up_Style_GetHasRows
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Style_GetHasRows]
GO

CREATE PROCEDURE [dbo].[Up_Style_GetHasRows] 
@Name Nvarchar(200)
AS
Select [Name] From KyStyle Where [Name]=@Name


GO

-- ----------------------------
-- Procedure structure for UP_Style_GetId
-- ----------------------------
DROP PROCEDURE [dbo].[UP_Style_GetId]
GO

CREATE PROCEDURE [dbo].[UP_Style_GetId]
@StyleId int
 AS 
	SELECT 
	[StyleCategoryId],[Name],[Content],[Type]
	 FROM KyStyle WHERE StyleId=@StyleId

GO

-- ----------------------------
-- Procedure structure for Up_Style_GetList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Style_GetList]
GO

CREATE PROCEDURE [dbo].[Up_Style_GetList]
@StyleCategoryId int
AS
SELECT StyleID,[Name],Content,Type FROM kyStyle WHERE StyleCategoryId=@StyleCategoryId

GO

-- ----------------------------
-- Procedure structure for Up_Style_GetSearchStyle
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Style_GetSearchStyle]
GO
create proc [dbo].[Up_Style_GetSearchStyle]
@modelid int
as
select * from KyListStyleContent where modelid=@modelid

GO

-- ----------------------------
-- Procedure structure for Up_Style_StyleIDGetStylegoryId
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Style_StyleIDGetStylegoryId]
GO

CREATE PROCEDURE [dbo].[Up_Style_StyleIDGetStylegoryId]
@StyleID int
 AS 
	SELECT 
	[StyleID],[StyleCategoryId]
	 FROM KyStyle
	 WHERE [StyleID] = @StyleID

GO

-- ----------------------------
-- Procedure structure for UP_Style_Update
-- ----------------------------
DROP PROCEDURE [dbo].[UP_Style_Update]
GO

CREATE PROCEDURE [dbo].[UP_Style_Update]
@StyleID int,
@StyleCategoryId int,
@Name nvarchar(100),
@Content text,
@Type int
 AS 
	UPDATE KyStyle SET 
	[StyleCategoryId] = @StyleCategoryId,[Name] = @Name,[Content] = @Content,[Type] = @Type
	WHERE [StyleID] = @StyleID

GO

-- ----------------------------
-- Procedure structure for Up_Style_UpdateSearchStyle
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Style_UpdateSearchStyle]
GO
CREATE PROCEDURE [dbo].[Up_Style_UpdateSearchStyle] 
@modelId int,
@content ntext
AS
update KyListStyleContent set Content=@content where ModelId=@modelId
GO

-- ----------------------------
-- Procedure structure for Up_StyleCategory_Add
-- ----------------------------
DROP PROCEDURE [dbo].[Up_StyleCategory_Add]
GO

CREATE PROCEDURE [dbo].[Up_StyleCategory_Add]
@Name nvarchar(100) ,
@ParentID int ,
@Desc nvarchar(200) 
 AS 
	INSERT INTO KyStyleCategory(
	[Name],[ParentID],[Desc]
	)VALUES(
	@Name,@ParentID,@Desc
	)

GO

-- ----------------------------
-- Procedure structure for Up_StyleCategory_Delete
-- ----------------------------
DROP PROCEDURE [dbo].[Up_StyleCategory_Delete]
GO

CREATE PROCEDURE [dbo].[Up_StyleCategory_Delete] 
@StyleCategoryID int
AS
Delete From KyStyleCategory where StyleCategoryID=@StyleCategoryID or ParentID=@StyleCategoryID


GO

-- ----------------------------
-- Procedure structure for Up_StyleCategory_GetIdData
-- ----------------------------
DROP PROCEDURE [dbo].[Up_StyleCategory_GetIdData]
GO

CREATE PROCEDURE [dbo].[Up_StyleCategory_GetIdData] 
@StyleCategoryId int
AS
SELECT ParentId,[NAME],[DESC] FROM KyStyleCategory WHERE StyleCategoryId=@StyleCategoryId

GO

-- ----------------------------
-- Procedure structure for UP_StyleCategory_GetList
-- ----------------------------
DROP PROCEDURE [dbo].[UP_StyleCategory_GetList]
GO

CREATE PROCEDURE [dbo].[UP_StyleCategory_GetList]
@ParentID int
 AS 
	SELECT 
	[StyleCategoryID],[Name],[ParentID],[Desc]
	 FROM KyStyleCategory
	 WHERE ParentID=@ParentID

GO

-- ----------------------------
-- Procedure structure for Up_StyleCategory_Update
-- ----------------------------
DROP PROCEDURE [dbo].[Up_StyleCategory_Update]
GO

CREATE PROCEDURE [dbo].[Up_StyleCategory_Update] 
@StyleCategoryId int,
@ParentId int,
@Name nvarchar(50),
@Desc nvarchar(100)
AS
UPDATE KyStyleCategory set ParentId=@ParentId,[Name]=@Name,[Desc]=@Desc WHERE StyleCategoryId=@StyleCategoryId

GO

-- ----------------------------
-- Procedure structure for Up_StyleCategoryid
-- ----------------------------
DROP PROCEDURE [dbo].[Up_StyleCategoryid]
GO

CREATE PROCEDURE [dbo].[Up_StyleCategoryid] 
AS
Select StyleCategoryID,[Name],ParentID FROM KyStyleCategory

GO

-- ----------------------------
-- Procedure structure for Up_StyleContent_GetLbcategoryNameList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_StyleContent_GetLbcategoryNameList]
GO
CREATE proc [dbo].[Up_StyleContent_GetLbcategoryNameList]
@labelName Nvarchar(200),
@CursorPage Int,
@PageSize Int,
@RecordCount Int output
As
Declare @SqlStr Nvarchar(2000);
if(@CursorPage=1)
	Set @SqlStr=N'Select Top '+Convert(Nvarchar(15),@PageSize)+' * from KyStyle Where [Name] like @tlabelName Order By StyleID Desc'
else
	Set @SqlStr=N'Select Top '+Convert(Nvarchar(15),@PageSize)+' * from KyStyle Where [Name] like @tlabelName and StyleID<(Select min(StyleID) From(Select Top '+Convert(Nvarchar(15),(@CursorPage-1)*@PageSize)+' StyleID From KyStyle Where [Name] like @tlabelName Order By StyleID Desc)O)Order By StyleID Desc'
Declare @paramlb nvarchar(500)
set @paramlb=N'@tlabelName Nvarchar(200)'
Execute Sp_executeSql @SqlStr,@paramlb,@tlabelName=@labelName

set @RecordCount=(select Count(StyleID) From KyStyle Where [Name]  like @labelName)
GO

-- ----------------------------
-- Procedure structure for Up_Superior_Add
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Superior_Add]
GO
CREATE PROCEDURE [dbo].[Up_Superior_Add]
@Name nvarchar(400) ,
@StartCode nvarchar(1000) ,
@EndCode nvarchar(1000) 
 AS 
	INSERT INTO KySuperior(
	[Name],[StartCode],[EndCode]
	)VALUES(
	@Name,@StartCode,@EndCode
	)
GO

-- ----------------------------
-- Procedure structure for Up_Superior_Delete
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Superior_Delete]
GO
CREATE PROCEDURE [dbo].[Up_Superior_Delete]
@id int
 AS 
	DELETE KySuperior
	 WHERE [id] = @id
GO

-- ----------------------------
-- Procedure structure for Up_Superior_GetIdBySuperiorl
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Superior_GetIdBySuperiorl]
GO
CREATE PROCEDURE [dbo].[Up_Superior_GetIdBySuperiorl]
@id int
 AS 
	SELECT 
	[id],[Name],[StartCode],[EndCode]
	 FROM KySuperior
	 WHERE [id] = @id
GO

-- ----------------------------
-- Procedure structure for Up_Superior_GetList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Superior_GetList]
GO
CREATE PROCEDURE [dbo].[Up_Superior_GetList]
 AS 
	SELECT 
	[id],[Name],[StartCode],[EndCode]
	 FROM KySuperior ORDER BY [ID] DESC
GO

-- ----------------------------
-- Procedure structure for Up_Superior_Update
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Superior_Update]
GO
CREATE PROCEDURE [dbo].[Up_Superior_Update]
@id int,
@Name nvarchar(400),
@StartCode nvarchar(1000),
@EndCode nvarchar(1000)
 AS 
	UPDATE KySuperior SET 
	[Name] = @Name,[StartCode] = @StartCode,[EndCode] = @EndCode
	WHERE [id] = @id
GO

-- ----------------------------
-- Procedure structure for Up_SuperLabel_Add
-- ----------------------------
DROP PROCEDURE [dbo].[Up_SuperLabel_Add]
GO
CREATE PROCEDURE [dbo].[Up_SuperLabel_Add]
@Name nvarchar(100) ,
@LbCategoryName nvarchar(100) ,
@LbCategoryId int ,
@DataBaseType int ,
@SuperDes nvarchar(1000) ,
@IsUnlockPage bit ,
@HostTable nvarchar(100) ,
@GuestTable nvarchar(100) ,
@SqlStr nvarchar(1000) ,
@Content ntext,
@AddTime datetime,
@PageSize int,
@NumColumns int,
@IsHtml bit,
@DataBaseConn nvarchar(300)=" "
AS
	INSERT INTO [KySuperLabel]([Name],[LbCategoryName],[LbCategoryId],[DataBaseType],[SuperDes],[IsUnlockPage],[HostTable],[GuestTable],[SqlStr],[Content],[AddTime],[PageSize],[NumColumns],[IsHtml],[DataBaseConn])VALUES(@Name,@LbCategoryName,@LbCategoryId,@DataBaseType,@SuperDes,@IsUnlockPage,@HostTable,@GuestTable,@SqlStr,@Content,@AddTime,@PageSize,@NumColumns,@IsHtml,@DataBaseConn)
	RETURN
GO

-- ----------------------------
-- Procedure structure for Up_SuperLabel_CheckName
-- ----------------------------
DROP PROCEDURE [dbo].[Up_SuperLabel_CheckName]
GO
CREATE PROCEDURE [dbo].[Up_SuperLabel_CheckName]
@Name nvarchar(100)
AS
	if exists(select * from [KySuperLabel] where Name=@Name)
	select 1
	else
	select 0
	RETURN
GO

-- ----------------------------
-- Procedure structure for Up_SuperLabel_Delete
-- ----------------------------
DROP PROCEDURE [dbo].[Up_SuperLabel_Delete]
GO
CREATE PROCEDURE [dbo].[Up_SuperLabel_Delete]
@SuperId int
AS
	DELETE [KySuperLabel] WHERE [SuperId] = @SuperId
	RETURN

GO

-- ----------------------------
-- Procedure structure for Up_SuperLabel_GetList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_SuperLabel_GetList]
GO
CREATE PROCEDURE [dbo].[Up_SuperLabel_GetList]
@CurrPage Int,  
@PageSize Int
AS
	Declare @SqlStr Nvarchar(2000);  
	If(@CurrPage=1)
		set @SqlStr=N'Select Top '+Convert(Nvarchar(15),@PageSize)+' * from [KySuperLabel] order by SuperId desc';
	Else
		set @SqlStr=N'Select Top '+Convert(Nvarchar(15),@PageSize)+' * from [KySuperLabel] where SuperId Not in(select Top '+Convert(Nvarchar(15),(@CurrPage-1)*@PageSize)+' SuperId from [KySuperLabel] order by SuperId desc) order by SuperId desc'; 

	Execute Sp_ExecuteSql @SqlStr  
	Set @SqlStr = N'Select Count(SuperId) From [KySuperLabel]';
	Execute Sp_ExecuteSql @SqlStr 
	RETURN
GO

-- ----------------------------
-- Procedure structure for Up_SuperLabel_GetModel
-- ----------------------------
DROP PROCEDURE [dbo].[Up_SuperLabel_GetModel]
GO
CREATE PROCEDURE [dbo].[Up_SuperLabel_GetModel]
@SuperId int
AS
	SELECT [SuperId],[Name],[LbCategoryName],[LbCategoryId],[DataBaseType],[SuperDes],[IsUnlockPage],[HostTable],[GuestTable],[SqlStr],[Content],[AddTime],[PageSize],[NumColumns],[IsHtml],[DataBaseConn] FROM [KySuperLabel] WHERE [SuperId] = @SuperId
	RETURN
GO

-- ----------------------------
-- Procedure structure for Up_SuperLabel_GetSuperId
-- ----------------------------
DROP PROCEDURE [dbo].[Up_SuperLabel_GetSuperId]
GO
CREATE PROCEDURE [dbo].[Up_SuperLabel_GetSuperId]  
@Name nvarchar(150)  
 AS  
 Declare @SuperId int;   
 set @SuperId=(select top 1 SuperId from [KySuperLabel] where [Name]=@Name order by SuperId desc)  
   
 if @SuperId is null  
  select 0  
 else  
  select @SuperId
GO

-- ----------------------------
-- Procedure structure for Up_SuperLabel_IsModelTable
-- ----------------------------
DROP PROCEDURE [dbo].[Up_SuperLabel_IsModelTable]
GO
CREATE PROCEDURE [dbo].[Up_SuperLabel_IsModelTable]
@TableName nvarchar(100)
 AS
if exists(select * from [KyModel] where TableName=@TableName)
select 1
else
select 0
GO

-- ----------------------------
-- Procedure structure for Up_SuperLabel_Out
-- ----------------------------
DROP PROCEDURE [dbo].[Up_SuperLabel_Out]
GO
CREATE PROCEDURE [dbo].[Up_SuperLabel_Out]
@InSuperId nvarchar(2000)
 AS
 Declare @SqlStr Nvarchar(2000);  
 set @SqlStr=N'select * from [KySuperLabel] where SuperId in('+@InSuperId+')';
 Execute Sp_ExecuteSql @SqlStr  
GO

-- ----------------------------
-- Procedure structure for Up_SuperLabel_Update
-- ----------------------------
DROP PROCEDURE [dbo].[Up_SuperLabel_Update]
GO
CREATE PROCEDURE [dbo].[Up_SuperLabel_Update]
@SuperId int,
@Name nvarchar(100),
@LbCategoryName nvarchar(100),
@LbCategoryId int,
@DataBaseType int,
@SuperDes nvarchar(1000),
@IsUnlockPage bit,
@HostTable nvarchar(100) ,
@GuestTable nvarchar(100) ,
@SqlStr nvarchar(1000),
@Content ntext,
@AddTime datetime,
@PageSize int,
@NumColumns int,
@IsHtml bit,
@DataBaseConn nvarchar(300)=" "
AS
	UPDATE [KySuperLabel] SET [Name] = @Name,[LbCategoryName] = @LbCategoryName,[LbCategoryId] = @LbCategoryId,[DataBaseType] = @DataBaseType,[SuperDes] = @SuperDes,[IsUnlockPage] = @IsUnlockPage,[HostTable] = @HostTable,[GuestTable] = @GuestTable,[SqlStr] = @SqlStr,[Content] = @Content,[AddTime] = @AddTime,PageSize=@PageSize,NumColumns=@NumColumns,IsHtml=@IsHtml,DataBaseConn=@DataBaseConn WHERE [SuperId] = @SuperId
	RETURN
GO

-- ----------------------------
-- Procedure structure for Up_Tag_Add
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Tag_Add]
GO

CREATE Procedure [dbo].[Up_Tag_Add]
@Name Nvarchar(20),
@TagCategoryId Int,
@ModelType Int,
@UserId Int,
@UserName nvarchar(20)
As
If Exists(Select * From KyTag Where Name=@Name)
return 
Insert Into KyTag([Name],TagCategoryId,ModelType,UserId,UserName)
Values(@Name,@TagCategoryId,@ModelType,@UserId,@UserName)

GO

-- ----------------------------
-- Procedure structure for Up_Tag_AddTagStr
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Tag_AddTagStr]
GO
CREATE procedure [dbo].[Up_Tag_AddTagStr]
@tagstr nvarchar(300),
@modeltype int,
@uid int,
@uname nvarchar(20)
as
if(@tagstr='')
	select '',''
else
	set @tagstr=@tagstr+'|'
declare @tb table([name] nvarchar(20))
declare @index int
declare @name nvarchar(20)
while(@tagstr<>'')
begin
set @index = charindex('|',@tagstr)
set @name = substring(@tagstr,1,@index-1)
set @tagstr = substring(@tagstr,@index+1,len(@tagstr)-@index)
insert into @tb values(@name)
end

declare @returnidstr nvarchar(300)
declare @char nvarchar(1)
set @returnidstr = ''
set @char = '';

declare @returnid nvarchar(15)
declare @returnnamestr nvarchar(300)
set @returnnamestr = ''
declare cur cursor fast_forward for(select [name] from @tb)
open cur
fetch next from cur into @name
while(@@fetch_status=0)
begin
	if exists(select * from kytag where [name]=@name)
	begin
		set @returnid = (select tagid from kytag where [name]=@name)
		set @returnidstr= @returnidstr+@char+@returnid
		set @returnnamestr = @returnnamestr+@char+@name
		set @char = '|'
	end
	else
	begin
		if(@name!='')
		begin
		insert into kytag([name],tagcategoryid,modeltype,userid,username)
		values(@name,0,@modeltype,@uid,@uname)
		set @returnid = scope_identity()
		set @returnidstr= @returnidstr+@char+@returnid
		set @returnnamestr = @returnnamestr+@char+@name
		set @char = '|'
		end
	end
	fetch next from cur into @name
  end
close cur
deallocate cur
select @returnidstr,@returnnamestr
GO

-- ----------------------------
-- Procedure structure for Up_Tag_Clear
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Tag_Clear]
GO
Create proc [dbo].[Up_Tag_Clear]  
as  
update [kytag] set daysearchcount=0,yesterdaysearchcount=daysearchcount,counttime=getdate() where datediff(day,counttime,getdate())!=0

GO

-- ----------------------------
-- Procedure structure for Up_Tag_Delete
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Tag_Delete]
GO

Create Procedure [dbo].[Up_Tag_Delete]
@SearchCount Int
As
Delete From KyTag Where TotalSearchCount<@SearchCount


GO

-- ----------------------------
-- Procedure structure for Up_Tag_GetList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Tag_GetList]
GO
CREATE Procedure [dbo].[Up_Tag_GetList]
@currpage int,
@pagesize int,
@recordcount int output
As
declare @sqlstr nvarchar(4000)
declare @selectfield nvarchar(1000)
declare @selecttable nvarchar(1000)
declare @order nvarchar(500)
set @selectfield =  ' a.tagid,tagname=a.name,tagcategoryname=isnull(b.name,''无类别''),a.modeltype,a.yesterdaysearchcount,a.daysearchcount,a.totalsearchcount,a.username,a.userid,c.modelname '
set @selecttable =' kytag a left join kytagcategory b on a.tagcategoryid=b.tagcategoryid join kymodel c on a.modeltype=c.modelid '
set @order = ' order by totalsearchcount desc, tagid desc '
if(@currpage=1)
	set @sqlstr = 'select top '+convert(nvarchar(15),@pagesize)+@selectfield+'from'+@selecttable+@order
else
	set @sqlstr = 'select top '+convert(nvarchar(15),@pagesize)+@selectfield+'from'+@selecttable+'where a.tagid not in(select top '+convert(nvarchar(15),(@currpage-1)*@pagesize)+' a.tagid from '+@selecttable+@order+')'+@order
execute sp_executesql @sqlstr
set @recordcount = (select count(tagid) From kytag )


GO

-- ----------------------------
-- Procedure structure for Up_Tag_SetSearchCount
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Tag_SetSearchCount]
GO
CREATE proc [dbo].[Up_Tag_SetSearchCount]
@tagName nvarchar(20),
@modeltype int
as
update kytag set daysearchcount=daysearchcount+1,totalsearchcount=totalsearchcount+1 where [name]=@tagname and modeltype=@modeltype

GO

-- ----------------------------
-- Procedure structure for Up_TagCategory_GetList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_TagCategory_GetList]
GO

Create Procedure [dbo].[Up_TagCategory_GetList]
As
Select * From KyTagCategory


GO

-- ----------------------------
-- Procedure structure for Up_TagCategory_Set
-- ----------------------------
DROP PROCEDURE [dbo].[Up_TagCategory_Set]
GO

Create Procedure [dbo].[Up_TagCategory_Set]
@TagCategoryId int,
@Name nvarchar(20),
@Desc nvarchar(100)

As
If (@TagCategoryId<=0)
Begin
	Insert Into KyTagCategory([Name],[Desc])values(@Name,@Desc);
End
Else
Begin
	Update KyTagCategory Set [Name]=@Name , [Desc]=@Desc Where TagCategoryId=@TagCategoryId
End


GO

-- ----------------------------
-- Procedure structure for Up_TagCateogry_Delete
-- ----------------------------
DROP PROCEDURE [dbo].[Up_TagCateogry_Delete]
GO

CREATE Procedure [dbo].[Up_TagCateogry_Delete]
@TagCategoryId int
As
Set Xact_Abort On

Begin Tran
Update KyTag Set TagCategoryId=0 Where TagCategoryId=@TagCategoryId
Delete From KyTagCategory Where TagCategoryId=@TagCategoryId
Commit Tran



GO

-- ----------------------------
-- Procedure structure for Up_TagNotice_GetList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_TagNotice_GetList]
GO

CREATE PROCEDURE [dbo].[Up_TagNotice_GetList]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
	@CurrPage Int,  
	@PageSize Int, 
	@WhereStr nvarchar(1000)
AS
	/* SET NOCOUNT ON */ 
	Declare @SqlStr Nvarchar(2000);  
	If(@CurrPage=1)
		set @SqlStr=N'Select Top '+Convert(Nvarchar(15),@PageSize)+' * from [KyNotice] '+Convert(Nvarchar(100),@WhereStr)+' order by IsPriority desc,NoticeId desc';
	Else
		set @SqlStr=N'Select Top '+Convert(Nvarchar(15),@PageSize)+' * from [KyNotice] '+Convert(Nvarchar(100),@WhereStr)+' and NoticeId Not in(select Top '+Convert(Nvarchar(15),(@CurrPage-1)*@PageSize)+' NoticeId from [KyNotice] '+Convert(Nvarchar(100),@WhereStr)+' order by IsPriority desc,NoticeId desc) order by IsPriority desc,NoticeId desc'; 

	Execute Sp_ExecuteSql @SqlStr  
	
	Set @SqlStr = N'Select Count(NoticeId) From [KyNotice] '+@WhereStr;
	Execute Sp_ExecuteSql @SqlStr

	RETURN

GO

-- ----------------------------
-- Procedure structure for Up_UpdateMoney
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UpdateMoney]
GO

CREATE PROCEDURE [dbo].[Up_UpdateMoney]

	@Value decimal,
	@UserID int,
	@TypeId int
AS

	if @TypeId=1
	begin
		update [KyUsers] set YellowBoy=YellowBoy+@Value where UserID=@UserID
	end
	
	/*更新积分*/
	if @TypeId=2
	begin
		update [KyUsers] set Integral=Integral+@Value where UserID=@UserID
	end
	
	/*更新有效期*/
	if @TypeId=3
	begin
		update [KyUsers] set ExpireTime=DATEADD([day], @Value, ExpireTime) where UserID=@UserID
	end
	RETURN
GO

-- ----------------------------
-- Procedure structure for Up_User_AddFriend
-- ----------------------------
DROP PROCEDURE [dbo].[Up_User_AddFriend]
GO

CREATE proc [dbo].[Up_User_AddFriend]
@UserId int,
@FriendName nvarchar(20),
@FriendGroupId int,
@Flag int=0 output

as

	declare @FriendId int
	if exists(select [UserID] from KyUsers where LogName=@FriendName)
		begin
			select @FriendId=UserId from KyUsers where LogName=@FriendName
			if exists(select * from KyUserFriend where UserId=@UserId and FriendId=@FriendId)
				begin set @Flag=1 end--你已经添加了这个好友了
			else
				begin
				insert into KyUserFriend values(@UserId,@FriendId,@FriendGroupId)
				set @Flag=3--添加成功
				end
	
		end
	else
		set @Flag=2--请求的好友不存在


GO

-- ----------------------------
-- Procedure structure for up_User_Changepwd
-- ----------------------------
DROP PROCEDURE [dbo].[up_User_Changepwd]
GO

CREATE PROCEDURE [dbo].[up_User_Changepwd]
(
@LogName nvarchar(20),
@newPwd nvarchar(200)
)
AS
	UPDATE KyUsers SET UserPwd=@newPwd WHERE LogName=@LogName

GO

-- ----------------------------
-- Procedure structure for Up_User_CheckMultiIdentity
-- ----------------------------
DROP PROCEDURE [dbo].[Up_User_CheckMultiIdentity]
GO

CREATE PROCEDURE [dbo].[Up_User_CheckMultiIdentity] 
@input nvarchar(500),
@tableName nvarchar(100),
@filedName nvarchar(100),
@output int=0 output
AS
	declare @SqlStr nvarchar(2000)
	--set @sql='declare @count output;select @count=count(*) from '+@tableName+' where '+@filedName+'='+@input
	Set @SqlStr =' Select @TRecord =Count(*) from '+@tableName+' where '+@filedName+'='''+@input+''''

Declare @Parm nvarchar(50)
Set @Parm = '@TRecord int output';
Exec Sp_ExecuteSql @SqlStr,@Parm,@TRecord=@output output;

GO

-- ----------------------------
-- Procedure structure for up_User_DeleteFriend
-- ----------------------------
DROP PROCEDURE [dbo].[up_User_DeleteFriend]
GO

CREATE PROCEDURE [dbo].[up_User_DeleteFriend] 
@Id int
AS
	DELETE FROM KyUserFriend WHERE	 [ID]=@Id

GO

-- ----------------------------
-- Procedure structure for Up_User_GetAllInfo
-- ----------------------------
DROP PROCEDURE [dbo].[Up_User_GetAllInfo]
GO
CREATE procedure [dbo].[Up_User_GetAllInfo]
@userId int 
as
declare @tableName nvarchar(30)
declare @spaceTypeId int
select @tableName = [tablename],@spacetypeid=[spacetypeid] from [kyusers] u join [kyusergroupmodel] m on u.[typeid]=m.[id] where [userid]=@userid
--set @tableName = (select [tablename] from [kyusers] u join [kyusergroupmodel] m on u.[typeid]=m.[id] where [userid]=@userid)

declare @sqlstr nvarchar(4000)
	set @sqlstr = 'select u.*,e.*,g.[usergroupname],'+convert(nvarchar(15),@spacetypeid)+' as spacetypeid from [kyusers] u join ['+@tablename+'] e on u.[userid]=e.[uid] join [kyusergroup] g on u.[groupid]=g.[usergroupid] where u.[userid]=@t_userid'
declare @param nvarchar(200)
	set @param='@t_userid int'
execute sp_executesql @sqlstr,@param,@t_userid=@userid
GO

-- ----------------------------
-- Procedure structure for Up_User_GetUserCount
-- ----------------------------
DROP PROCEDURE [dbo].[Up_User_GetUserCount]
GO
CREATE proc [dbo].[Up_User_GetUserCount]  
@typeid int ,
@groupid int
as  
declare @wherestr nvarchar(2000)
declare @wherestr2 nvarchar(10)
set @wherestr2 = ' where '
declare @char nvarchar(10)
set @char = ''
set @wherestr = '';
declare @sqlstr nvarchar(4000)
if(@typeid!=0)  
begin
	
	set @wherestr=@wherestr+@wherestr2+@char+' [typeid]=@t_typeid '
	set @char = ' and '
	set @wherestr2 = '';
end
if(@groupid!=0)
begin
	set @wherestr=@wherestr+@wherestr2+@char+' [groupid]=@t_groupid '
end
set @sqlstr = 'select count([userid]) from [kyusers] '+@wherestr
declare @param nvarchar(400)
set @param = '@t_typeid int,@t_groupid int'
execute sp_executesql @sqlstr,@param,@t_typeid=@typeid,@t_groupid=@groupid
GO

-- ----------------------------
-- Procedure structure for Up_User_ListGroupMember
-- ----------------------------
DROP PROCEDURE [dbo].[Up_User_ListGroupMember]
GO

CREATE PROCEDURE [dbo].[Up_User_ListGroupMember] 
@WhereStr nvarchar(2000),
@PageSize int=20,
@PageIndex int=0,
@Total int=0 output
AS
	Declare @SqlStr nvarchar(2000)
	DECLARE @fff nvarchar(100)
	
	if(@WhereStr ='')
	begin
	 set @WhereStr=' where '
	 set @fff=''
	end 
else
	begin
		set @fff=' where '+@WhereStr
		set @WhereStr=' where '+@WhereStr+' and '		
	end
	
	if @PageIndex = 1
		set @SqlStr=N'select top '+Convert(nvarchar(10),@PageSize)+' FriendId,[ID],LogName from KyUserFriend inner join KyUsers on KyUserFriend.FriendId=KyUsers.UserId'+@fff+' order by [ID] desc'
		
	else
		set @SqlStr=N'select top '+Convert(nvarchar(10),@PageSize)+' FriendId,[ID],LogName from KyUserFriend inner join KyUsers on KyUserFriend.FriendId=KyUsers.UserId'+@WhereStr+' 
		ID <(select MIN(ID) from (select top '+Convert(nvarchar(10),(@PageIndex-1)*@PageSize)+' * from KyUserFriend '+@fff+' order by [ID] desc)F) order by [ID] desc'

		
print @SqlStr

Execute Sp_ExecuteSql @SqlStr


Set @SqlStr =' Select @Count =Count([ID]) from KyUserFriend'+@fff


Declare @Parm nvarchar(50)
Set @Parm = '@Count int output';
Exec Sp_ExecuteSql @SqlStr,@Parm,@Count=@Total output
GO

-- ----------------------------
-- Procedure structure for up_User_Login
-- ----------------------------
DROP PROCEDURE [dbo].[up_User_Login]
GO

CREATE PROCEDURE [dbo].[up_User_Login]
(
@LogName nvarchar(20),
@Pwd nvarchar(200)
)
AS
	SELECT UserID FROM KyUsers WHERE LogName=@LogName AND UserPwd=@Pwd

GO

-- ----------------------------
-- Procedure structure for Up_User_Recharge
-- ----------------------------
DROP PROCEDURE [dbo].[Up_User_Recharge]
GO
CREATE PROCEDURE [dbo].[Up_User_Recharge]
(
@UserId int,
@CardAccount varchar(15),
@CardPwd varchar(200),
@Flag int output
)
AS

Set Xact_Abort ON
begin tran
if exists(select [ID] from KyCard where CardAccount=@CardAccount and Password=@CardPwd)
	begin
		declare @Type int
		declare @Point int
		declare @date datetime
		declare @day int
		declare @IsUsed bit
		declare @expireTime datetime
		
		select @Type=Type from KyCard where CardAccount=@CardAccount
		select @Point=CardPoint from KyCard where CardAccount=@CardAccount
		select @date=OverdueDate  from KyCard where CardAccount=@CardAccount
		select @day=CardDay  from KyCard where CardAccount=@CardAccount
		select @IsUsed=IsUsed   from KyCard where CardAccount=@CardAccount
		select @expireTime=ExpireTime from KyUsers where UserId=@UserId
				
		if(@IsUsed=0)
			begin
			if(@date>getDate())
				begin
					if(@Type=1)
					begin
						update KyCard set OverdueDate=DateAdd(dd,@day,OverdueDate),IsUsed=1,UserId=@UserId where CardAccount=@CardAccount
						if(@expireTime>=getDate())
							update	KyUsers set ExpireTime=DateAdd(dd,@day,@expireTime) where UserId=@UserId
						else
							update	KyUsers set ExpireTime=DateAdd(dd,@day,getDate()) where UserId=@UserId
						insert into KyRechargeRecord values(@UserId,@CardAccount,@Point,@day,getDate())
						set @Flag=1
					end
					if(@Type=0)
					begin
						update KyUsers set YellowBoy=YellowBoy+@Point where UserId=@UserId
						update KyCard set IsUsed=1,UserId=@UserId  where CardAccount=@CardAccount
						insert into KyRechargeRecord values(@UserId,@CardAccount,@Point,@day,getDate())
						set @Flag=1
					end
				end
			else
				set @Flag=3
			end
		else
				set @Flag=2
	end
	

else
	 set @Flag=4
	 
	 commit tran
GO

-- ----------------------------
-- Procedure structure for Up_User_RechargeRecord
-- ----------------------------
DROP PROCEDURE [dbo].[Up_User_RechargeRecord]
GO

CREATE PROCEDURE [dbo].[Up_User_RechargeRecord]
@UserId int,
@PageSize int=20,
@PageIndex int=1,
@PageCount int=0 output
AS

	declare @SqlStr nvarchar(2000)
	if(@PageIndex=1)
		set @SqlStr='select top '+Convert(nvarchar(10),@PageSize) +' * from KyRechargeRecord where [UserId]='+Convert(nvarchar(20),@UserId) +' order by [ID] desc'
	else
		set @SqlStr='select top '+Convert(nvarchar(10),@PageSize) +' * from KyRechargeRecord where [ID]<(select MIN([ID]) from (select top '+Convert(nvarchar(10),(@PageSize * (@PageIndex-1)))+' * from KyRechargeRecord where [UserId]='+Convert(nvarchar(20),@UserId)+' order by [ID] desc)R) order by [ID] desc'
	
--print @SqlStr

	Execute Sp_ExecuteSql @SqlStr


Set @SqlStr =' Select @Total =Count([ID]) from KyRechargeRecord where UserId='+Convert(nvarchar(20),@UserId)


Declare @Parm nvarchar(50)
Set @Parm = '@Total int output';
Exec Sp_ExecuteSql @SqlStr,@Parm,@Total=@PageCount output

GO

-- ----------------------------
-- Procedure structure for up_User_SetFriend
-- ----------------------------
DROP PROCEDURE [dbo].[up_User_SetFriend]
GO

CREATE PROCEDURE [dbo].[up_User_SetFriend]
(
@Id int,
@IsDisable int
)
AS
	UPDATE KyUserFriend SET FriendGroupId=@IsDisable WHERE [ID]=@Id


GO

-- ----------------------------
-- Procedure structure for Up_User_SetFriendGroup
-- ----------------------------
DROP PROCEDURE [dbo].[Up_User_SetFriendGroup]
GO

CREATE PROCEDURE [dbo].[Up_User_SetFriendGroup] 

@GroupName nvarchar(50),
@IsUserId int,
@GroupId int,
@Type varchar(20)


AS
	if @Type='Add'
		begin
		insert into KyUserFriendGroup values(@GroupName,@IsUserId)
		end
	if @Type='ListGroup'
		begin
		select * from KyUserFriendGroup where IsUserId=@IsUserId or IsUserId=0
		end
	if @Type='Delete'
		begin
		delete from KyUserFriendGroup where FriendGroupId=@GroupId
		delete from KyUserFriend where FriendGroupId=@GroupId
		end
	if @Type='Update'
		begin
		update KyUserFriendGroup set FriendGroupName=@GroupName where FriendGroupId=@GroupId
		end
	if @Type='CountMember'
		begin
		select count(FriendId) from KyuserFriend where FriendGroupId=@GroupId and UserId=@IsUserId
		end

GO

-- ----------------------------
-- Procedure structure for Up_User_UpdateRegCode
-- ----------------------------
DROP PROCEDURE [dbo].[Up_User_UpdateRegCode]
GO
CREATE PROCEDURE [dbo].[Up_User_UpdateRegCode]
@UserId int,
@NewCode varchar(50)
AS
	UPDATE KyUsers Set ConfirmRegCode=@NewCode where UserId=@UserId
GO

-- ----------------------------
-- Procedure structure for Up_UserAlbum_Delete
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserAlbum_Delete]
GO
CREATE proc [dbo].[Up_UserAlbum_Delete]
@Id int,
@UserId int
as
	delete KyUserAlbum where Id=@Id and userId=@UserId
	delete KyUserPhoto where AlbumId=@Id and userId=@UserId
GO

-- ----------------------------
-- Procedure structure for Up_UserAlbum_GetById
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserAlbum_GetById]
GO
CREATE PROCEDURE [dbo].[Up_UserAlbum_GetById]
@Id int,
@UserId int
 AS 
	SELECT 
	[Id],[AlbumName],[AlbumCate],[AlbumDescription],[ImgCount],[Logo],[IsOpened],[AlbumPassword],[AddTime],[UserId],[UserName]
	 FROM KyUserAlbum
	 WHERE [Id] = @Id and UserId=@UserId
GO

-- ----------------------------
-- Procedure structure for Up_UserAlbum_GetByUserId
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserAlbum_GetByUserId]
GO
CREATE Proc [dbo].[Up_UserAlbum_GetByUserId]
@UserId int,
@PageIndex int=1,
@PageSize int=10,
@RecordCount int=0 output
AS
declare @sqlstr Nvarchar(4000)
if(@PageIndex=1)
	set @sqlstr =N'select top '+Convert(Nvarchar(15),@PageSize)+' * from KyUserAlbum where UserId='+Convert(Nvarchar(15),@UserId)+' order by Id desc'
else
	set @sqlstr =N'select top '+Convert(Nvarchar(15),@PageSize)+' * from KyUserAlbum where UserId='+Convert(Nvarchar(15),@UserId)+' 
	and id<(select min(o.id) from(select top '+Convert(Nvarchar(15),(@PageIndex-1)*@PageSize)+' id from KyUserAlbum where
	 UserId='+Convert(Nvarchar(15),@UserId)+' order by Id desc)o) order by Id desc'
execute sp_executesql @sqlstr
--print @sqlstr
set @sqlstr='select count(Id) from KyUserAlbum where UserId='+Convert(Nvarchar(15),@UserId)
execute sp_executesql @sqlstr
--print @sqlstr



GO

-- ----------------------------
-- Procedure structure for Up_UserAlbum_Set
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserAlbum_Set]
GO
CREATE PROCEDURE [dbo].[Up_UserAlbum_Set]
@Id int output,
@AlbumName nvarchar(50) ,
@AlbumCate nvarchar(50) ,
@AlbumDescription nvarchar(500) ,
@ImgCount int ,
@Logo nvarchar(50) ,
@IsOpened int ,
@AlbumPassword nvarchar(50),
@AddTime nvarchar(50) ,
@UserId int ,
@UserName nvarchar(50) 
 AS 
if(@Id=0)
begin
	INSERT INTO KyUserAlbum(
	[AlbumName],[AlbumCate],[AlbumDescription],[ImgCount],[Logo],[IsOpened],[AlbumPassword],[AddTime],[UserId],[UserName]
	)VALUES(
	@AlbumName,@AlbumCate,@AlbumDescription,0,@Logo,@IsOpened,@AlbumPassword,@AddTime,@UserId,@UserName
	)
set @Id=scope_identity()
end
else
begin
	UPDATE KyUserAlbum SET 
	[AlbumName] = @AlbumName,[AlbumCate] = @AlbumCate,[AlbumDescription] = @AlbumDescription,[Logo] = @Logo,[IsOpened] = @IsOpened,[AlbumPassword] = @AlbumPassword,[UserId] = @UserId,[UserName] = @UserName
	WHERE [Id] = @Id
end
GO

-- ----------------------------
-- Procedure structure for Up_UserCate_Delete
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserCate_Delete]
GO

create proc [dbo].[Up_UserCate_Delete]
@UserCateId int 
as 
	Delete from KyUserCate where UserCateId=@UserCateId


GO

-- ----------------------------
-- Procedure structure for Up_UserCate_GetById
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserCate_GetById]
GO

CREATE PROCEDURE [dbo].[Up_UserCate_GetById]
@UserCateId int
as 
select * from KyUserCate where UserCateId=@UserCateId

GO

-- ----------------------------
-- Procedure structure for Up_UserCate_GetByUser
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserCate_GetByUser]
GO

CREATE proc [dbo].[Up_UserCate_GetByUser]
@UserId int,
@CateType int=-1,
@KeyWord nvarchar(500)=''
as 

declare @WhereStr nvarchar(2000)
set @Wherestr='';

if(@CateType!=-1)
begin
	set @WhereStr=@WhereStr+'a.CateType='+Convert(nvarchar(15),@CateType)+' and ';
end
if(@KeyWord!='')
begin
	set @WhereStr=@WhereStr+'a.CateName Like ''%'+@KeyWord+'%'''+' And ';  
end

set @WhereStr=@WhereStr+'a.UserId='+convert(nvarchar(15),@UserId)

declare @SqlStr nvarchar(2000)
set @SqlStr='select a.*,b.LogName from KyUserCate a inner join KyUsers b on a.UserId = b.UserID where '+@WhereStr
execute sp_executesql @SqlStr
print @sqlstr
return



GO

-- ----------------------------
-- Procedure structure for Up_UserCate_GetCountByUserId
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserCate_GetCountByUserId]
GO

CREATE proc [dbo].[Up_UserCate_GetCountByUserId]
@UserId int
as
select count(userCateId) from KyUserCate where UserId=@UserId
GO

-- ----------------------------
-- Procedure structure for Up_UserCate_GetList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserCate_GetList]
GO
CREATE proc [dbo].[Up_UserCate_GetList] 
@userid int,
@modeltype int 
as  
if(@modeltype=0)
select a.*,c.modelname from kyusercate a inner join kyusers b on a.userid = b.userid inner join kymodel c on a.modeltype=c.modelid
where a.userid=@userid 
else
select a.*,c.modelname from kyusercate a inner join kyusers b on a.userid = b.userid inner join kymodel c on a.modeltype=c.modelid
where a.userid=@userid and a.modeltype=@modeltype
  


GO

-- ----------------------------
-- Procedure structure for Up_UserCate_Set
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserCate_Set]
GO

CREATE PROCEDURE [dbo].[Up_UserCate_Set]
@UserCateId int output,
@UserId int ,
@CateName varchar(50) ,
@CateType int ,
@Discription text 
 AS
if(@UserCateId=0)
begin
	INSERT INTO KyUserCate(
	[UserId],[CateName],[ModelType],[Discription]
	)VALUES(
	@UserId,@CateName,@CateType,@Discription
	)
	set @UserCateId=Scope_identity()
end 
else
begin
	UPDATE KyUserCate SET 
	[UserId] = @UserId,[CateName] = @CateName,[ModelType] = @CateType,[Discription] = @Discription
	WHERE [UserCateId] = @UserCateId
end
GO

-- ----------------------------
-- Procedure structure for Up_UserFavorite
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserFavorite]
GO

CREATE PROCEDURE [dbo].[Up_UserFavorite]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
	@id int=0,
	@UserId int=0 ,
	@Title nvarchar(100)=" " ,
	@Url nvarchar(1000)=" " ,
	@AddDate datetime=" ",
	@TypeId int=0 
AS
	/* SET NOCOUNT ON */ 
	
	/*新增*/
	if @TypeId=1
	begin
		INSERT INTO KyUserFavorite([UserId],[Title],[Url],[AddDate])VALUES(@UserId,@Title,@Url,@AddDate)
	end
	/*删除*/
	if @TypeId=2
	begin
		DELETE KyUserFavorite WHERE [id] = @id
	end
	RETURN


GO

-- ----------------------------
-- Procedure structure for Up_UserFavorite_GetList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserFavorite_GetList]
GO

CREATE PROCEDURE [dbo].[Up_UserFavorite_GetList] 
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
	@CurrPage Int,  
	@PageSize Int, 
	@WhereStr nvarchar(100)
AS
	/* SET NOCOUNT ON */ 
	Declare @SqlStr Nvarchar(2000);  
	If(@CurrPage=1)
		set @SqlStr=N'Select Top '+Convert(Nvarchar(15),@PageSize)+' * from [KyUserFavorite] '+Convert(Nvarchar(100),@WhereStr)+' order by Id desc';
	Else
		set @SqlStr=N'Select Top '+Convert(Nvarchar(15),@PageSize)+' * from [KyUserFavorite] '+Convert(Nvarchar(100),@WhereStr)+' and Id Not in(select Top '+Convert(Nvarchar(15),(@CurrPage-1)*@PageSize)+' Id from [KyUserFavorite] '+Convert(Nvarchar(100),@WhereStr)+' order by Id desc) order by Id desc'; 

	Execute Sp_ExecuteSql @SqlStr  
	Set @SqlStr = N'Select Count(Id) From [KyUserFavorite] '+@WhereStr;
	Execute Sp_ExecuteSql @SqlStr 
	RETURN


GO

-- ----------------------------
-- Procedure structure for Up_UserGroup
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserGroup]
GO

CREATE PROCEDURE [dbo].[Up_UserGroup]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
	@UserGroupId int=0 ,
	@UserGroupName nvarchar(100)=" " ,
	@UserGroupContent nvarchar(1000)=" "  ,
	@TypeId int=0 ,
	@GroupPower ntext=" "  ,
	@ColumnPower ntext=" "  ,
	@IsSystem int=0 ,
	@AddDate datetime=" ",
	@Up_Id int=0
AS
	/* SET NOCOUNT ON */ 
	
	/*新增*/
	if(@Up_Id=1)
	begin
		INSERT INTO KyUserGroup([UserGroupName],[UserGroupContent],[TypeId],[GroupPower],[ColumnPower],[IsSystem],[AddDate])VALUES(@UserGroupName,@UserGroupContent,@TypeId,@GroupPower,@ColumnPower,@IsSystem,@AddDate)
	end
	
	/*修改*/
	if(@Up_Id=2)
	begin
		UPDATE KyUserGroup SET [UserGroupName] = @UserGroupName,[UserGroupContent] = @UserGroupContent,[GroupPower] = @GroupPower,[ColumnPower] = @ColumnPower,[AddDate] = @AddDate WHERE [UserGroupId] = @UserGroupId
	end
	
	/*删除*/
	if(@Up_Id=3)
	begin
		DELETE KyUserGroup WHERE [UserGroupId] = @UserGroupId
	end
	
	/*得到实体对象的详细信息*/
	if(@Up_Id=4)
	begin
		SELECT [UserGroupId],[UserGroupName],[UserGroupContent],[TypeId],[GroupPower],[ColumnPower],[IsSystem],[AddDate] FROM KyUserGroup WHERE [UserGroupId] = @UserGroupId
	end
	RETURN


GO

-- ----------------------------
-- Procedure structure for Up_UserGroup_GetList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserGroup_GetList]
GO
CREATE PROCEDURE [dbo].[Up_UserGroup_GetList]
	@CurrPage Int,  
	@PageSize Int, 
	@WhereStr nvarchar(100)
AS
	Declare @SqlStr Nvarchar(2000);  
	If(@CurrPage=1)
		set @SqlStr=N'Select Top '+Convert(Nvarchar(15),@PageSize)+' * from [KyUserGroup] '+Convert(Nvarchar(100),@WhereStr)+' order by UserGroupId desc';
	Else
		set @SqlStr=N'Select Top '+Convert(Nvarchar(15),@PageSize)+' * from [KyUserGroup] '+Convert(Nvarchar(100),@WhereStr)+' and UserGroupId Not in(select Top '+Convert(Nvarchar(15),(@CurrPage-1)*@PageSize)+' UserGroupId from [KyUserGroup] '+Convert(Nvarchar(100),@WhereStr)+' order by UserGroupId desc) order by UserGroupId desc'; 

	Execute Sp_ExecuteSql @SqlStr  
	Set @SqlStr = N'Select Count(UserGroupId) From [KyUserGroup] '+@WhereStr;
	Execute Sp_ExecuteSql @SqlStr 
	RETURN
GO

-- ----------------------------
-- Procedure structure for Up_UserGroup_GetNameAndId
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserGroup_GetNameAndId]
GO

create procedure [dbo].[Up_UserGroup_GetNameAndId]
	@TypeId int
as
select UserGroupId,UserGroupName
from KyUserGroup
where TypeId = @TypeId


GO

-- ----------------------------
-- Procedure structure for Up_UserGroup_ManageList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserGroup_ManageList]
GO

CREATE PROCEDURE [dbo].[Up_UserGroup_ManageList]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
	@StrWhere nvarchar(1000)
AS
	/* SET NOCOUNT ON */ 
	Declare @SqlStr Nvarchar(2000); 
	
	Set @SqlStr = N'Select * From [KyUserGroup] '+@StrWhere;
	Execute Sp_ExecuteSql @SqlStr 
	RETURN


GO

-- ----------------------------
-- Procedure structure for Up_UserGroupModel_Add
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserGroupModel_Add]
GO

CREATE PROCEDURE [dbo].[Up_UserGroupModel_Add]
@Name nvarchar(100) ,
@TableName nvarchar(200) ,
@Content nvarchar(1000) ,
@ModelHtml ntext ,
@AddTime datetime,
@IsValidate bit,
@UserGroupId int,
@IsHtml bit,
@SpaceTypeId int
 AS 
	INSERT INTO KyUserGroupModel([Name],[TableName],[Content],[ModelHtml],[AddTime],[IsValidate],[UserGroupId],[IsHtml],[SpaceTypeId])VALUES(@Name,@TableName,@Content,@ModelHtml,@AddTime,@IsValidate,@UserGroupId,@IsHtml,@SpaceTypeId)
	select scope_identity()

GO

-- ----------------------------
-- Procedure structure for Up_UserGroupModel_AddTable
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserGroupModel_AddTable]
GO
CREATE PROCEDURE [dbo].[Up_UserGroupModel_AddTable]
 @TableName nvarchar(50)  
AS  
 Declare @sqlstr nvarchar(500)  
set @sqlstr=N'  
CREATE TABLE [dbo].['+@TableName+']   
(  
[Id] [int] IDENTITY (1, 1) PRIMARY Key NOT NULL,  
[UId] [int] NULL ,  
[AddTime] [datetime] NULL,  
[UpdateTime] [datetime] NULL)  
CREATE  INDEX [IX_'+@TableName+'_UId] ON ['+@TableName+']([UId]) ON [PRIMARY]'  
exec sp_executesql @sqlstr  

GO

-- ----------------------------
-- Procedure structure for Up_UserGroupModel_Delete
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserGroupModel_Delete]
GO
CREATE PROCEDURE [dbo].[Up_UserGroupModel_Delete]
	@Id int
AS	
	declare @tablename nvarchar(50)
	set @tablename=''
	set @tablename=(select TableName from [KyUserGroupModel] where [Id] = @Id)
	declare @sqlstr nvarchar(500)
	if(@tablename!='')
	begin
		set @sqlstr = N'delete from [KyUserGroupModel] where [Id]='+convert(nvarchar(15),@Id)
		exec sp_executesql @sqlstr
		
		set @sqlstr = N'drop table ['+@tablename+']'
		exec sp_executesql @sqlstr
	end
RETURN
GO

-- ----------------------------
-- Procedure structure for Up_UserGroupModel_GetAll
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserGroupModel_GetAll]
GO

CREATE PROCEDURE [dbo].[Up_UserGroupModel_GetAll]
 AS 
	SELECT [Id],[Name],[TableName],[Content],[ModelHtml],[AddTime],[IsValidate],[UserGroupId],[IsHtml],[SpaceTypeId] FROM [KyUserGroupModel]  order by Id desc

GO

-- ----------------------------
-- Procedure structure for Up_UserGroupModel_GetModel
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserGroupModel_GetModel]
GO

CREATE PROCEDURE [dbo].[Up_UserGroupModel_GetModel]
@Id int
 AS 
	SELECT [Id],[Name],[TableName],[Content],[ModelHtml],[AddTime],[IsValidate],[UserGroupId],[IsHtml],[SpaceTypeId] FROM KyUserGroupModel WHERE [Id] = @Id

GO

-- ----------------------------
-- Procedure structure for Up_UserGroupModel_GetTextType
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserGroupModel_GetTextType]
GO
CREATE PROCEDURE [dbo].[Up_UserGroupModel_GetTextType]
@ModelId int
AS
	select ModelId,[Name],Type from [KyUserGroupModelField] where [ModelId]=@ModelId and [Type]='MultipleHtmlType'
	RETURN
GO

-- ----------------------------
-- Procedure structure for Up_UserGroupModel_ModelHtml
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserGroupModel_ModelHtml]
GO

CREATE PROCEDURE [dbo].[Up_UserGroupModel_ModelHtml]
@ModelHtml ntext,
@Id int
AS
	update [KyUserGroupModel] set ModelHtml=@ModelHtml where [Id]=@Id
	RETURN


GO

-- ----------------------------
-- Procedure structure for Up_UserGroupModel_Update
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserGroupModel_Update]
GO

CREATE PROCEDURE [dbo].[Up_UserGroupModel_Update]
@Id int,
@Name nvarchar(100),
@TableName nvarchar(200),
@Content nvarchar(1000),
@AddTime datetime,
@IsValidate bit,
@IsHtml bit,
@SpaceTypeId int
 AS 
	UPDATE [KyUserGroupModel] SET [Name] = @Name,[TableName] = @TableName,[Content] = @Content,[AddTime] = @AddTime,[IsValidate]=@IsValidate,[IsHtml]=@IsHtml,[SpaceTypeId]=@SpaceTypeId WHERE [Id] = @Id

GO

-- ----------------------------
-- Procedure structure for Up_UserGroupModel_UpdateUserGroupId
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserGroupModel_UpdateUserGroupId]
GO
CREATE PROCEDURE [dbo].[Up_UserGroupModel_UpdateUserGroupId]
@Id int,
@UserGroupId int
 AS
	update [KyUserGroupModel] set UserGroupId=@UserGroupId where [Id]=@Id
GO

-- ----------------------------
-- Procedure structure for Up_UserGroupModelField_Add
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserGroupModelField_Add]
GO
CREATE PROCEDURE [dbo].[Up_UserGroupModelField_Add]
@ModelId int,
@Name nvarchar(100) ,
@Alias nvarchar(300) ,
@Description nvarchar(400) ,
@IsNotNull bit ,
@IsSearchForm bit ,
@Type nvarchar(100) ,
@Content ntext ,
@IsList bit ,
@IsUserInsert bit ,
@AddDate datetime
AS
	Declare @OrderId int; 
	set @OrderId=(select Max(OrderId) from [KyUserGroupModelField] where ModelId=@ModelId)
	
	if @OrderId is null
		set @OrderId=0
	else
		set @OrderId=@OrderId+1
	
	INSERT INTO [KyUserGroupModelField]([ModelId],[Name],[Alias],[Description],[IsNotNull],[IsSearchForm],[Type],[Content],[AddDate],[OrderId],[IsList],[IsUserInsert]) VALUES(@ModelId,@Name,@Alias,@Description,@IsNotNull,@IsSearchForm,@Type,@Content,@AddDate,@OrderId,@IsList,@IsUserInsert)
	RETURN
GO

-- ----------------------------
-- Procedure structure for Up_UserGroupModelField_Del
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserGroupModelField_Del]
GO
CREATE PROCEDURE [dbo].[Up_UserGroupModelField_Del]
	@FieldId int
AS
	delete from [KyUserGroupModelField] where FieldId=@FieldId
	RETURN
GO

-- ----------------------------
-- Procedure structure for Up_UserGroupModelField_GetIsUserList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserGroupModelField_GetIsUserList]
GO
CREATE PROCEDURE [dbo].[Up_UserGroupModelField_GetIsUserList]
	@ModelId int
AS
	select * from [KyUserGroupModelField] where ModelId=@ModelId and IsUserInsert=1 order by OrderId
	RETURN
GO

-- ----------------------------
-- Procedure structure for Up_UserGroupModelField_GetList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserGroupModelField_GetList]
GO
CREATE PROCEDURE [dbo].[Up_UserGroupModelField_GetList]
	@ModelId int
AS
	select * from [KyUserGroupModelField] where ModelId=@ModelId order by OrderId
	RETURN
GO

-- ----------------------------
-- Procedure structure for Up_UserGroupModelField_GetModel
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserGroupModelField_GetModel]
GO
CREATE PROCEDURE [dbo].[Up_UserGroupModelField_GetModel]
	@FieldId int=0,
	@ModelId int=0,
	@Name nvarchar(50)=" ",
	@TypeId int
AS
	if @TypeId=1
		select * from [KyUserGroupModelField] where FieldId=@FieldId
	else
		select * from [KyUserGroupModelField] where ModelId=@ModelId and [Name]=@Name
	RETURN
GO

-- ----------------------------
-- Procedure structure for Up_UserGroupModelField_GetTitleList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserGroupModelField_GetTitleList]
GO
CREATE PROCEDURE [dbo].[Up_UserGroupModelField_GetTitleList]
	@ModelId int
AS
	select * from [KyUserGroupModelField] where IsList=1 and ModelId=@ModelId order by OrderId
	RETURN
GO

-- ----------------------------
-- Procedure structure for Up_UserGroupModelField_MoveField
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserGroupModelField_MoveField]
GO
CREATE PROCEDURE [dbo].[Up_UserGroupModelField_MoveField]
	@ModelId int,
	@FieldId int,
	@MoveType nvarchar(20)
AS
	Declare @OrderId int;
	Declare @NewFieldId int;
	Declare @NewOrderId int;
	
	if @MoveType='UpMove'
	begin	
		declare @MinOrderId int;
		set @MinOrderId=(select min(OrderId) from [KyUserGroupModelField] where ModelId=@ModelId)
		
		set @OrderId=(select OrderId from [KyUserGroupModelField] where ModelId=@ModelId and FieldId=@FieldId)
		
		if @OrderId!=@MinOrderId
		begin
			set @NewFieldId=(select top 1 FieldId from [KyUserGroupModelField] where ModelId=@ModelId and OrderId<@OrderId order by OrderId desc)
			set @NewOrderId=(select OrderId from [KyUserGroupModelField] where ModelId=@ModelId and FieldId=@NewFieldId)
			
			update [KyUserGroupModelField] set OrderId=@OrderId where FieldId=@NewFieldId and ModelId=@ModelId
			update [KyUserGroupModelField] set OrderId=@NewOrderId where FieldId=@FieldId and ModelId=@ModelId
		end
	end
	
	if @MoveType='DownMove'
	begin
		declare @MaxOrderId int;
		set @MaxOrderId=(select max(OrderId) from [KyUserGroupModelField] where ModelId=@ModelId)
		
		set @OrderId=(select OrderId from [KyUserGroupModelField] where ModelId=@ModelId and FieldId=@FieldId)
		
		if @OrderId!=@MaxOrderId
		begin
			set @NewFieldId=(select top 1 FieldId from [KyUserGroupModelField] where ModelId=@ModelId and OrderId>@OrderId order by OrderId)
			set @NewOrderId=(select OrderId from [KyUserGroupModelField] where ModelId=@ModelId and FieldId=@NewFieldId)
			
			update [KyUserGroupModelField] set OrderId=@OrderId where FieldId=@NewFieldId and ModelId=@ModelId
			update [KyUserGroupModelField] set OrderId=@NewOrderId where FieldId=@FieldId and ModelId=@ModelId
		end
	end
	RETURN
GO

-- ----------------------------
-- Procedure structure for Up_UserGroupModelField_SelectPropertyTrue
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserGroupModelField_SelectPropertyTrue]
GO
CREATE PROCEDURE [dbo].[Up_UserGroupModelField_SelectPropertyTrue]
	@ModelId nvarchar(50)
AS
	select * from [KyUserGroupModelField] where ModelId=@ModelId and Type='RadioType' and Content like '%Property=True%' order by OrderId
	RETURN
GO

-- ----------------------------
-- Procedure structure for Up_UserGroupModelField_Update
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserGroupModelField_Update]
GO
CREATE PROCEDURE [dbo].[Up_UserGroupModelField_Update]
@FieldId int,
@ModelId int,
@Alias nvarchar(300),
@Description nvarchar(400),
@IsNotNull bit,
@IsSearchForm bit,
@Content ntext,
@IsList bit ,
@IsUserInsert bit ,
@AddDate datetime
AS
	UPDATE [KyUserGroupModelField] SET [Alias] = @Alias,[Description] = @Description,[IsNotNull] = @IsNotNull,[IsSearchForm] = @IsSearchForm,[Content] = @Content,[IsList]=@IsList,[IsUserInsert]=@IsUserInsert,[AddDate] = @AddDate WHERE [FieldId] = @FieldId and ModelId=@ModelId
	RETURN
GO

-- ----------------------------
-- Procedure structure for Up_UserLog_Add
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserLog_Add]
GO

Create Procedure [dbo].[Up_UserLog_Add]
@UserId int,
@UserName nvarchar(20),
@Description nvarchar(1000),
@InfoId int,
@ModelType int,
@Point int,
@AddTime DateTime
AS

Insert Into KyUserLog([UserId],[UserName],[Description],[InfoId],[ModelType],[Point],[AddTime])
Values(@UserId,@UserName,@Description,@InfoId,@ModelType,@Point,@AddTime)


GO

-- ----------------------------
-- Procedure structure for Up_UserLog_CheckIsPay
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserLog_CheckIsPay]
GO

CREATE Procedure [dbo].[Up_UserLog_CheckIsPay]
@CheckPayType int,
@ModelType int,
@InfoId int,
@UserId int,
@HourCount int,
@ViewCount int
As
If(@CheckPayType=6)
Begin
	Select 0;
	return;
End


Declare @PrePayTime DateTime;
Declare @PreViewCount int


If Not Exists(Select Id From KyUserLog Where UserId=@UserId And ModelType=@ModelType And InfoId=@InfoId)
Begin
	Select 0;
	return;
End

If(@CheckPayType=1)
Begin
	Select 1;
	return;
End

If(@CheckPayType=2)
Begin
	If(@HourCount<=0)
	Begin
		Select 1;
		return;
	End
	Else
	Begin
		Set @PrePayTime = (Select Top 1 AddTime From KyUserLog Where UserId=@UserId And ModelType=@ModelType And InfoId=@InfoId Order By Id Desc)
		If(DateDiff(hour,@PrePayTime,GetDate())<@HourCount)
		Begin
				Select 1;
				return;
		End
		Else
		Begin
				Select 0;
				return;
		End
	End
	
End

If(@CheckPayType=3)
Begin
	If(@ViewCount<=0)
	Begin
		Select 1;
		return;
	End
	Else
	Begin
		Set @PrePayTime = (Select Top 1 AddTime From KyUserLog Where UserId=@UserId And ModelType=@ModelType And InfoId=@InfoId Order By Id Desc)
		Set @PreViewCount = (Select Count(Id) From KyViewLog Where UserId=@UserId And ModelType=@ModelType And InfoId =@InfoId And AddTime>=@PrePayTime)
		If(@PreViewCount<@ViewCount)
		Begin
			Select 1;
			return;
		End
		Else
		Begin
			Select 0;
			return;
		End
	End
End

If(@CheckPayType=4)
Begin
	If(@ViewCount<=0 or @HourCount<=0)
	Begin
		Select 1;
		return;
	End
	Else
	Begin
		Set @PrePayTime = (Select Top 1 AddTime From KyUserLog Where UserId=@UserId And ModelType=@ModelType And InfoId=@InfoId Order By Id Desc)
		Set @PreViewCount = (Select Count(Id) From KyViewLog Where UserId=@UserId And ModelType=@ModelType And InfoId =@InfoId And AddTime>=@PrePayTime)
		If(DateDiff(hour,@PrePayTime,GetDate())<@HourCount Or @PreViewCount<@ViewCount)
		Begin
			Select 1;
			return;
		End
		Else
		Begin
			Select 0;
			return;
		End
	End
End

If(@CheckPayType=5)
Begin
	If(@ViewCount<=0 And @HourCount<=0)
	Begin
		Select 1;
		return;
	End
	Else
	Begin
		Set @PrePayTime = (Select Top 1 AddTime From KyUserLog Where UserId=@UserId And ModelType=@ModelType And InfoId=@InfoId Order By Id Desc)
		Set @PreViewCount = (Select Count(Id) From KyViewLog Where UserId=@UserId And ModelType=@ModelType And InfoId =@InfoId And AddTime>=@PrePayTime)

		If((DateDiff(hour,@PrePayTime,GetDate())<@HourCount Or @HourCount<=0) And (@PreViewCount<@ViewCount Or @ViewCount<=0))
		Begin
			Select 1;
			return;
		End
		Else
		Begin
			Select 0;
			return;
		End

	End
End




GO

-- ----------------------------
-- Procedure structure for Up_UserLog_ListLog
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserLog_ListLog]
GO

CREATE PROCEDURE [dbo].[Up_UserLog_ListLog] 
@WhereStr nvarchar(200),
@PageSize int=20,
@PageIndex int=1,
@Total int=0 output
AS
	declare @SqlStr nvarchar(2000)
		
	if @PageIndex=1
		set @SqlStr='select top '+Convert(nvarchar(10),@PageSize)+' * from KyUserLog where '+@WhereStr
	else
		set @SqlStr='select top '+Convert(nvarchar(10),@PageSize)+' * from KyUserLog where '+@WhereStr
			+' and [ID]<(select MIN([ID]) from (select top '+Convert(nvarchar(10),(@PageIndex-1)*@PageSize)
			+' * from KyUserLog where '+@WhereStr+' order by [ID] desc)L) order by [ID] desc'

print @SqlStr
Execute Sp_ExecuteSql @SqlStr


Set @SqlStr =' Select @TRecord =Count([ID]) from KyUserLog where '+@WhereStr


Declare @Parm nvarchar(50)
Set @Parm = '@TRecord int output';
Exec Sp_ExecuteSql @SqlStr,@Parm,@TRecord=@Total output;


GO

-- ----------------------------
-- Procedure structure for Up_UserLog_ReducePoint
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserLog_ReducePoint]
GO

Create Procedure [dbo].[Up_UserLog_ReducePoint]
@UserId int,
@Point int
As
Declare @CurrPoint int
Set @CurrPoint=(Select YellowBoy From KyUsers Where UserId=@UserId)
If(@CurrPoint<@Point)
	Select 0;
Else
Begin
	Update KyUsers Set YellowBoy=YellowBoy-@Point Where UserId=@UserId
	Select 1
End


GO

-- ----------------------------
-- Procedure structure for Up_UserMessage_Delete
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserMessage_Delete]
GO
CREATE PROCEDURE [dbo].[Up_UserMessage_Delete]
@IdStr nvarchar(1000),
@UserId int
 AS 
declare @sqlstr nvarchar(4000)
set @sqlstr = 'delete kyusermessage where [id] in('+@idstr+') and userid=@temp_userid'
declare @param nvarchar(400)
set @param='@temp_userid int '
execute sp_executesql @sqlstr,@param,@temp_userid=@userid

GO

-- ----------------------------
-- Procedure structure for Up_UserMessage_GetById
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserMessage_GetById]
GO
CREATE proc [dbo].[Up_UserMessage_GetById]
@Id int,
@UserId int
as 
select * from KyUserMessage where [id]=@Id and UserId=@UserId
GO

-- ----------------------------
-- Procedure structure for Up_UserMessage_GetByUserId
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserMessage_GetByUserId]
GO
CREATE Proc [dbo].[Up_UserMessage_GetByUserId]
@UserId int,
@PageIndex int=1,
@PageSize int=10,
@RecordCount int=0 output
AS
declare @sqlstr Nvarchar(4000)
if(@PageIndex=1)
	set @sqlstr =N'select top '+Convert(Nvarchar(15),@PageSize)+' * from KyUserMessage where UserId='+Convert(Nvarchar(15),@UserId)+' order by Id desc'
else
	set @sqlstr =N'select top '+Convert(Nvarchar(15),@PageSize)+' * from KyUserMessage where UserId='+Convert(Nvarchar(15),@UserId)+' 
	and id<(select min(o.id) from(select top '+Convert(Nvarchar(15),(@PageIndex-1)*@PageSize)+' id from KyUserMessage where
	 UserId='+Convert(Nvarchar(15),@UserId)+' order by Id desc)o) order by Id desc'
execute sp_executesql @sqlstr
--print @sqlstr
set @sqlstr='select count(Id) from KyUserMessage where UserId='+Convert(Nvarchar(15),@UserId)
execute sp_executesql @sqlstr
--print @sqlstr
GO

-- ----------------------------
-- Procedure structure for Up_UserMessage_Resume
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserMessage_Resume]
GO
CREATE PROCEDURE [dbo].[Up_UserMessage_Resume]
@Id int,
@UserId int,
@ResumeContent text,
@ResumeTime nvarchar(100)
 AS 
	update KyUserMessage set IsResume=1,[ResumeContent]=@ResumeContent,[ResumeTime]=@ResumeTime where [Id]=@Id and UserId=@UserId
GO

-- ----------------------------
-- Procedure structure for Up_UserMessage_Set
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserMessage_Set]
GO
CREATE PROCEDURE [dbo].[Up_UserMessage_Set]
@Id int,
@Title nvarchar(100) ,
@Content text ,
@UserId int ,
@AnounName nvarchar(50) ,
@HomePage nvarchar(100) ,
@IsPrivacy bit,
@IsResume bit ,
@ResumeContent text ,
@PostTime nvarchar(100) 
 AS 
if(@Id=0)
begin
	INSERT INTO KyUserMessage(
	[Title],[Content],[UserId],[AnounName],[HomePage],[IsPrivacy],[IsResume],[ResumeContent],[PostTime]
	)VALUES(
	@Title,@Content,@UserId,@AnounName,@HomePage,@IsPrivacy,@IsResume,@ResumeContent,@PostTime
	)
end
--else
--begin
	--UPDATE KyUserMessage SET [IsResume]=@IsResume,[ResumeContent]=@ResumeContent WHERE UserId=@UserId
--end
GO

-- ----------------------------
-- Procedure structure for Up_UserPhoto_Delete
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserPhoto_Delete]
GO
CREATE proc [dbo].[Up_UserPhoto_Delete]
@PhotoIdStr nvarchar(1000),
@UserId int,
@Count int
as
declare @SqlStr nvarchar(4000)
	set @SqlStr=N'update kyUserAlbum set KyUserAlbum.imgcount=imgcount-'+Convert(Nvarchar(15),@Count)+' from 
	 KyUserPhoto inner join kyuseralbum on kyuseralbum.Id=KyuserPhoto.AlbumId
	 where kyUserAlbum.UserId='+Convert(Nvarchar(15),@UserId)+' and photoid in('+@PhotoIdStr+')'
execute sp_executesql @SqlStr

	set @SqlStr=N'delete KyUserPhoto where PhotoId in ('+@PhotoIdStr+') and UserId='+Convert(Nvarchar(15),@UserId)+''
execute sp_executesql @SqlStr

GO

-- ----------------------------
-- Procedure structure for Up_UserPhoto_GetById
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserPhoto_GetById]
GO
CREATE Proc [dbo].[Up_UserPhoto_GetById]
@AlbumId int,
@UserId int,
@PageIndex int=1,
@PageSize int=10,
@RecordCount int=0 output
AS
declare @sqlstr Nvarchar(4000)
if(@PageIndex=1)
	set @sqlstr =N'select top '+Convert(Nvarchar(15),@PageSize)+' p.*,a.AlbumName from KyUserPhoto as p join KyUserAlbum as a on p.AlbumId=a.Id where
  		 p.UserId='+Convert(Nvarchar(15),@UserId)+' and P.Albumid='+Convert(Nvarchar(15),@AlbumId)+' order by PhotoId desc'
else
	set @sqlstr =N'select top '+Convert(Nvarchar(15),@PageSize)+' p.*,a.AlbumName from KyUserPhoto as p join KyUserAlbum as a on p.AlbumId=a.Id where
		 p.UserId='+Convert(Nvarchar(15),@UserId)+' and P.Albumid='+Convert(Nvarchar(15),@AlbumId)+' and PhotoId<(select min(o.PhotoId) from(select top '+Convert(Nvarchar(15),(@PageIndex-1)*@PageSize)+' PhotoId from KyUserPhoto as p where
	 p.UserId='+Convert(Nvarchar(15),@UserId)+' and P.Albumid='+Convert(Nvarchar(15),@AlbumId)+' order by PhotoId desc)o) order by PhotoId desc'
execute sp_executesql @sqlstr
--print @sqlstr
set @sqlstr='select count(Photoid) from KyUserPhoto where UserId='+Convert(Nvarchar(15),@UserId)+ ' and AlbumId= '+Convert(Nvarchar(15),@AlbumId)
execute sp_executesql @sqlstr
--print @sqlstr


GO

-- ----------------------------
-- Procedure structure for Up_UserPhoto_GetByPhotoId
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserPhoto_GetByPhotoId]
GO
CREATE PROCEDURE [dbo].[Up_UserPhoto_GetByPhotoId]
@PhotoId int
 AS 
	SELECT *
	 FROM KyUserPhoto  where PhotoId=@PhotoId

GO

-- ----------------------------
-- Procedure structure for Up_UserPhoto_Set
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserPhoto_Set]
GO
CREATE PROCEDURE [dbo].[Up_UserPhoto_Set]
@PhotoId int output,
@AlbumId int ,
@FileName nvarchar(50) ,
@FilePath nvarchar(100) ,
@Description nvarchar(500) ,
@PostTime nvarchar(50) ,
@UserId int ,
@UserName nvarchar(50),
@VisitNum int,
@FileSize int
 AS 
if(@PhotoId=0)
begin
	INSERT INTO KyUserPhoto(
	[AlbumId],[FileName],[FilePath],[Description],[PostTime],[UserId],[UserName],[VisitNum],[FileSize]
	)VALUES(
	@AlbumId,@FileName,@FilePath,@Description,@PostTime,@UserId,@UserName,@VisitNum,@FileSize
	)
	SET @PhotoId =SCOPE_Identity()
	update kyuseralbum set imgcount=imgcount+1 from kyuseralbum a join kyuserphoto b on a.id=b.albumid where photoid=@PhotoId
	
end
else
begin
	UPDATE KyUserPhoto SET 
	[FileName]=@FileName,[FilePath]=@FilePath,[Description]=@Description,[PostTime]=@PostTime,[UserName]=@UserName,[FileSize]=@FileSize,[VisitNum]=@VisitNum
	WHERE  [PhotoId]=@PhotoId AND [UserId]=@UserId
end
GO

-- ----------------------------
-- Procedure structure for Up_Users_Add
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Users_Add]
GO
CREATE procedure [dbo].[Up_Users_Add]
@logname nvarchar(20),
@userpwd nvarchar(200),
@typeid int,
@email varchar(100),
@islock bit,
@groupid int,
@question nvarchar(50),
@answer nvarchar(50),
@integral int,
@secret tinyint,  
@confirmCode nvarchar(50),
@status int
as
	insert into kyusers([logname],[userpwd],[typeid],[email],[islock],[groupid],[question],[answer],[integral],[secret],[confirmregcode],[status])
	values(@logname,@userpwd,@typeid,@email,@islock,@groupid,@question,@answer,@integral,@secret,@confirmcode,@status)
	select scope_identity()

GO

-- ----------------------------
-- Procedure structure for Up_Users_Delete
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Users_Delete]
GO


CREATE procedure [dbo].[Up_Users_Delete]
	@UserID int
as
	set Xact_Abort on
		begin tran
			Delete from KyUsers Where UserID=@UserId
			Delete from KyUserFavorite where UserId=@UserId
			Delete from KyUserCate where UserId=@UserId
			Delete from KyUserFriend where FriendId=@UserId
		commit tran
			
			



GO

-- ----------------------------
-- Procedure structure for up_Users_GetUser
-- ----------------------------
DROP PROCEDURE [dbo].[up_Users_GetUser]
GO


CREATE  PROCEDURE [dbo].[up_Users_GetUser]
@Identity nvarchar(20),
@Type int
AS
	if(@Type=1)--按ID查找
		select * from KyUsers where UserId=@Identity
	if(@Type=0)--按LogName查找
		SELECT * FROM KyUsers WHERE LogName=@Identity
GO

-- ----------------------------
-- Procedure structure for Up_Users_GetUserList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Users_GetUserList]
GO
CREATE procedure [dbo].[Up_Users_GetUserList]
@groupid int,
@nologintype int,
@logname nvarchar(20),
@typeid int,
@islock int,
@order nvarchar(50),
@pageindex int,
@pagesize int
as
declare @wherestr nvarchar(4000)
set @wherestr = '';
if(@groupid>0)
begin
	set @wherestr=@wherestr+' a.[groupid]=@t_groupid and ';
end
if(@nologintype>0)
begin
	declare @nologintime datetime
	if(@nologintype=1)
    begin
		set @nologintime = dateadd(month,-3,getdate());
    end
	else if(@nologintype=2)
	begin
		set @nologintime = dateadd(month,-6,getdate())
	end
	else
	begin
		set @nologintime = dateadd(month,-12,getdate())
	end
	set @wherestr=@wherestr+' a.[lastlogintime]<@t_nologintime and '
end
if(@logname!='')
begin
	set @wherestr=@wherestr+' a.[logname] like @t_logname and '
end
if(@islock!=-1)
begin
	set @wherestr=@wherestr+' a.[islock]=@t_islock and '
end
if(@typeid>0)
begin
	set @wherestr = @wherestr+ ' a.typeid=@t_typeid '
end
else
begin
	set @wherestr = @wherestr +' 1=1 '
end
declare @sqlstr nvarchar(4000)
declare @param nvarchar(2000)
set @param='@t_groupid int,@t_nologintime datetime,@t_logname nvarchar(50),@t_islock bit,@t_typeid int'
if(@pageindex=1)
	set @sqlstr = 'select top '+convert(nvarchar(15),@pagesize)+' * from [kyusers] a join [kyusergroup] b on a.groupid=b.usergroupid where '+@wherestr+' order by a.['+@order+'] desc'
else
	set @sqlstr = 'select top '+convert(nvarchar(15),@pagesize)+' * from [kyusers] a join [kyusergroup] b on a.groupid=b.usergroupid where '+@wherestr+' and a.[userid] not in(select top '+convert(nvarchar(15),(@pageindex-1)*@pagesize)+' a.[userid] from [kyusers] a join [kyusergroup] b on a.groupid=b.usergroupid where '+@wherestr+' order by a.['+@order+'] desc) order by a.['+@order+'] desc'
execute sp_executesql @sqlstr,@param,@t_groupid=@groupid,@t_nologintime=@nologintime,@t_logname=@logname,@t_islock=@islock,@t_typeid=@typeid
set @sqlstr = 'select count(a.[userid]) from kyusers a join [kyusergroup] b on a.groupid=b.usergroupid where '+@wherestr
execute sp_executesql @sqlstr,@param,@t_groupid=@groupid,@t_nologintime=@nologintime,@t_logname=@logname,@t_islock=@islock,@t_typeid=@typeid
GO

-- ----------------------------
-- Procedure structure for Up_Users_Login_Error
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Users_Login_Error]
GO
create proc [dbo].[Up_Users_Login_Error]
@userid int
as
update [kyusers] set [errornum]=[errornum]+1 where [userid]=@userid
GO

-- ----------------------------
-- Procedure structure for Up_Users_Login_OnErrorNum
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Users_Login_OnErrorNum]
GO
create proc [dbo].[Up_Users_Login_OnErrorNum]
@userid int,
@errortime datetime
as
update [kyusers] set [errortime]=@errortime where [userid]=@userid
GO

-- ----------------------------
-- Procedure structure for Up_Users_Login_Success
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Users_Login_Success]
GO
CREATE proc [dbo].[Up_Users_Login_Success]
@userid int,
@lastloginip nvarchar(20),
@lastlogintime datetime
as
update [kyusers] set [loginnum]=[loginnum]+1,[lastloginip]=@lastloginip,[lastlogintime]=@lastlogintime,[errornum]=0 where [userid]=@userid
GO

-- ----------------------------
-- Procedure structure for Up_Users_ModifyOtherBasicInfo
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Users_ModifyOtherBasicInfo]
GO
create proc [dbo].[Up_Users_ModifyOtherBasicInfo]
@userid int,
@email varchar(100),
@groupid int,
@secret int
as
update [kyusers] set [email]=@email,[groupid]=@groupid,[secret]=@secret where [userid]=@userid
GO

-- ----------------------------
-- Procedure structure for Up_Users_ModifyPwd
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Users_ModifyPwd]
GO
CREATE procedure [dbo].[Up_Users_ModifyPwd]
@userid int,
@pwd nvarchar(200)
as
update [kyusers] set [userpwd]=@pwd where userid=@userid
GO

-- ----------------------------
-- Procedure structure for Up_Users_ModifyQuestion
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Users_ModifyQuestion]
GO
create proc [dbo].[Up_Users_ModifyQuestion]
@userid int,
@question nvarchar(50),
@answer nvarchar(50)
as
update [kyusers] set [question]=@question ,[answer]=@answer where userid=@userid
GO

-- ----------------------------
-- Procedure structure for Up_Users_SetLockStatus
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Users_SetLockStatus]
GO
create proc [dbo].[Up_Users_SetLockStatus]
@userid int,
@lockstatus bit
as
update [kyusers] set [islock]=@lockstatus where [userid]=@userid
GO

-- ----------------------------
-- Procedure structure for Up_Users_SetStatus
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Users_SetStatus]
GO
create proc [dbo].[Up_Users_SetStatus]
@userid int,
@status int
as
update [kyusers] set [status]=@status where [userid]=@userid
GO

-- ----------------------------
-- Procedure structure for Up_UserSpace_GetById
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserSpace_GetById]
GO
CREATE PROCEDURE [dbo].[Up_UserSpace_GetById]
@Id int
 AS 
	SELECT *  FROM KyUserSpace
	 WHERE [UserId] = @Id
GO

-- ----------------------------
-- Procedure structure for Up_UserSpace_GetPrevPower
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserSpace_GetPrevPower]
GO
create proc [dbo].[Up_UserSpace_GetPrevPower]
@userId int
as
select PrevPower from kyuserspace where UserId=@userId

GO

-- ----------------------------
-- Procedure structure for Up_UserSpace_Set
-- ----------------------------
DROP PROCEDURE [dbo].[Up_UserSpace_Set]
GO
CREATE PROCEDURE [dbo].[Up_UserSpace_Set]
@Id int output,
@SpaceName nvarchar(50),
@SpaceDescription nvarchar(500),
@PrevPower int,
@Password nvarchar(50) ,
@AddTime nvarchar(50),
@UserId int,
@UserName nvarchar(50),
@TemplateId int,
@UserType int
 AS
if(@Id=0) 
begin
	INSERT INTO KyUserSpace(
	[SpaceName],[SpaceDescription],[PrevPower],[Password],[AddTime],[UserId],[UserName],[TemplateId],[UserType]
	)VALUES(
	@SpaceName,@SpaceDescription,@PrevPower,@Password,@AddTime,@UserId,@UserName,@TemplateId,@UserType
	)
Set @Id=Scope_identity()
end
else
begin
	UPDATE KyUserSpace SET 
	[SpaceName] = @SpaceName,[SpaceDescription] = @SpaceDescription,[PrevPower] = @PrevPower,[Password] = @Password,[UserId] = @UserId,[UserName] = @UserName,[TemplateId]=@TemplateId,[UserType]=@UserType
	WHERE [Id] = @Id
end
GO

-- ----------------------------
-- Procedure structure for Up_ViewLog_Add
-- ----------------------------
DROP PROCEDURE [dbo].[Up_ViewLog_Add]
GO

Create Procedure [dbo].[Up_ViewLog_Add]
@UserId int,
@UserName nvarchar(20),
@ModelType int,
@InfoId int,
@AddTime DateTime
As

Insert Into KyViewLog([UserId],[UserName],[ModelType],[InfoId],[AddTime])
Values(@UserId,@UserName,@ModelType,@InfoId,@AddTime)



GO

-- ----------------------------
-- Procedure structure for Up_ViewLog_GetViewCount
-- ----------------------------
DROP PROCEDURE [dbo].[Up_ViewLog_GetViewCount]
GO

CREATE Procedure [dbo].[Up_ViewLog_GetViewCount]  
@UserId int,  
@Date varchar(10)  
As  
 Select Count(Id) From KyViewLog Where Convert(varchar(10),AddTime,120)=@Date

GO

-- ----------------------------
-- Procedure structure for Up_Vote_Add
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Vote_Add]
GO

CREATE PROCEDURE [dbo].[Up_Vote_Add]
@SubjectId int ,
@VoteTitle nvarchar(100) ,
@DisplayType int ,
@IsMore bit ,
@ModelType int ,
@ItemTitle1 nvarchar(100) ,
@ItemNum1 int ,
@ItemTitle2 nvarchar(100) ,
@ItemNum2 int ,
@ItemTitle3 nvarchar(100) ,
@ItemNum3 int ,
@ItemTitle4 nvarchar(100) ,
@ItemNum4 int ,
@ItemTitle5 nvarchar(100) ,
@ItemNum5 int ,
@ItemTitle6 nvarchar(100) ,
@ItemNum6 int 
 AS 
	INSERT INTO KyVote(
	[SubjectId],[VoteTitle],[DisplayType],[IsMore],[ModelType],[ItemTitle1],[ItemNum1],[ItemTitle2],[ItemNum2],[ItemTitle3],[ItemNum3],[ItemTitle4],[ItemNum4],[ItemTitle5],[ItemNum5],[ItemTitle6],[ItemNum6]
	)VALUES(
	@SubjectId,@VoteTitle,@DisplayType,@IsMore,@ModelType,@ItemTitle1,@ItemNum1,@ItemTitle2,@ItemNum2,@ItemTitle3,@ItemNum3,@ItemTitle4,@ItemNum4,@ItemTitle5,@ItemNum5,@ItemTitle6,@ItemNum6
	)


GO

-- ----------------------------
-- Procedure structure for Up_Vote_GetVoteIdByInfo
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Vote_GetVoteIdByInfo]
GO

CREATE PROCEDURE [dbo].[Up_Vote_GetVoteIdByInfo] 
@voteId int
AS
Select * from KyVote Where  voteId=@voteId


GO

-- ----------------------------
-- Procedure structure for Up_Vote_Update
-- ----------------------------
DROP PROCEDURE [dbo].[Up_Vote_Update]
GO

CREATE PROCEDURE [dbo].[Up_Vote_Update]

@VoteId int,
@VoteTitle nvarchar(100),
@IsMore bit,
@ItemTitle1 nvarchar(100),
@ItemNum1 int,
@ItemTitle2 nvarchar(100),
@ItemNum2 int,
@ItemTitle3 nvarchar(100),
@ItemNum3 int,
@ItemTitle4 nvarchar(100),
@ItemNum4 int,
@ItemTitle5 nvarchar(100),
@ItemNum5 int,
@ItemTitle6 nvarchar(100),
@ItemNum6 int
 AS 
	UPDATE KyVote SET 
	[VoteTitle] = @VoteTitle,[IsMore] = @IsMore,[ItemTitle1] = @ItemTitle1,[ItemNum1] = @ItemNum1,[ItemTitle2] = @ItemTitle2,[ItemNum2] = @ItemNum2,[ItemTitle3] = @ItemTitle3,[ItemNum3] = @ItemNum3,[ItemTitle4] = @ItemTitle4,[ItemNum4] = @ItemNum4,[ItemTitle5] = @ItemTitle5,[ItemNum5] = @ItemNum5,[ItemTitle6] = @ItemTitle6,[ItemNum6] = @ItemNum6
	WHERE [VoteId] = @VoteId

GO

-- ----------------------------
-- Procedure structure for Up_VoteCategory_Get
-- ----------------------------
DROP PROCEDURE [dbo].[Up_VoteCategory_Get]
GO

CREATE PROCEDURE [dbo].[Up_VoteCategory_Get] 
@Id int=0,
@Type int
AS
	if @Type=1
		begin
			select * from KyVoteCategory where CategoryId=@Id
		end
		
	if @Type=2
		begin
			select * from KyVoteCategory
		end


GO

-- ----------------------------
-- Procedure structure for Up_VoteCategory_Set
-- ----------------------------
DROP PROCEDURE [dbo].[Up_VoteCategory_Set]
GO

CREATE PROCEDURE [dbo].[Up_VoteCategory_Set]
@CategoryId int=0,
@Name nvarchar(200)='NULL',
@Type int
AS
	if @Type=1
		begin
			insert into KyVoteCategory values(@Name)
		end
		
	if @Type=2
		begin
			update KyVoteCategory set [Name]=@Name where CategoryId=@CategoryId
		end
		
	if @Type=3
		begin
			delete  KyVoteCategory where CategoryId=@CategoryId
		end
		


GO

-- ----------------------------
-- Procedure structure for Up_VoteSubject_Add
-- ----------------------------
DROP PROCEDURE [dbo].[Up_VoteSubject_Add]
GO

CREATE PROCEDURE [dbo].[Up_VoteSubject_Add]
@Subject nvarchar(200),
@StartDate datetime,
@EndDate datetime,
@RequireLogin bit,
@CategoryId int,
@Identity int output
AS
	INSERT INTO KyVoteSubject VALUES(@Subject,@StartDate,@EndDate,@RequireLogin,@CategoryId)
	
	SELECT @Identity=SCOPE_IDENTITY()


GO

-- ----------------------------
-- Procedure structure for Up_VoteSubject_Delete
-- ----------------------------
DROP PROCEDURE [dbo].[Up_VoteSubject_Delete]
GO

CREATE PROCEDURE [dbo].[Up_VoteSubject_Delete]
@SubjectId int
AS
	set XACT_ABORT  on
	
	begin tran
		delete from KyVoteSubject where VoteSubjectId=@SubjectId
		delete from KyVote where subjectId=@SubjectId
	commit tran

GO

-- ----------------------------
-- Procedure structure for Up_VoteSubject_Get
-- ----------------------------
DROP PROCEDURE [dbo].[Up_VoteSubject_Get]
GO

--如果Type为2,则忽略除@SubjectID之外的所有参数
--如果Type为1,则忽略@SubjectId 参数
--
CREATE PROCEDURE [dbo].[Up_VoteSubject_Get]
@SubjectId int=0,
@Type int,
@PageSize int=20,
@PageIndex int=1,
@WhereStr varchar(100)='',
@Total int=0 output

as
begin
DECLARE @SqlStr nvarchar(2000)
declare @fff nvarchar(200)
if @WhereStr != ''
	begin
	set @fff=' where '+@WhereStr +' and'
	set @WhereStr=' where '+@WhereStr
	end
if @WhereStr =''
	set @fff=' where '
 

	if @Type=1--获取所有投票
		if @PageIndex=1
			begin
				Set @SqlStr = N'Select Top '+Convert(Nvarchar(10),@PageSize)+' KyVoteSubject.* ,KyVoteCategory.Name as CategoryName FROM KyVoteSubject left join KyVoteCategory on KyVoteSubject.CategoryId=KyVoteCategory.CategoryId  '+@WhereStr +' Order By VoteSubjectID Desc'
			end
		else
			Set @SqlStr = N'Select Top '+Convert(Nvarchar(10),@PageSize)+' KyVoteSubject.*,KyVoteCategory.Name as CategoryName from KyVoteSubject left join KyVoteCategory on KyVoteSubject.CategoryId=KyVoteCategory.CategoryId '+@fff+' VoteSubjectID<(Select Min(VoteSubjectID) From(Select Top '+Convert(Nvarchar(10),(@PageIndex-1)*@PageSize)+' KyVoteSubject.* from KyVoteSubject Order By VoteSubjectID Desc)O) order By VoteSubjectID Desc'

	if @Type=2--获取指定的投票
		select KyVote.*,KyVoteSubject.* from KyVote join KyVoteSubject on KyVote.SubjectId=KyVoteSubject.VoteSubjectId where VoteSubjectId=@SubjectId
end

Execute Sp_ExecuteSql @SqlStr


Set @SqlStr =' Select @TRecord =Count(VoteSubjectID) from KyVoteSubject '+@WhereStr


Declare @Parm nvarchar(50)
Set @Parm = '@TRecord int output';
Exec Sp_ExecuteSql @SqlStr,@Parm,@TRecord=@Total output;

GO

-- ----------------------------
-- Procedure structure for Up_VoteSubject_GetAll
-- ----------------------------
DROP PROCEDURE [dbo].[Up_VoteSubject_GetAll]
GO

CREATE PROCEDURE [dbo].[Up_VoteSubject_GetAll] AS
Select VoteSubjectId,Subject,EndDate,RequireLogin From KyVoteSubject Order By VoteSubjectId Desc
GO

-- ----------------------------
-- Procedure structure for Up_VoteSubject_Update
-- ----------------------------
DROP PROCEDURE [dbo].[Up_VoteSubject_Update]
GO

CREATE PROCEDURE [dbo].[Up_VoteSubject_Update]
@VoteSubjectId int,
@Subject nvarchar(200),
@StartDate datetime,
@EndDate datetime,
@RequireLogin bit,
@CategoryId int
 AS 
	UPDATE KyVoteSubject SET 
	[Subject] = @Subject,[StartDate] = @StartDate,[EndDate] = @EndDate,[RequireLogin] = @RequireLogin,[CategoryId] = @CategoryId
	WHERE [VoteSubjectId] = @VoteSubjectId


GO

-- ----------------------------
-- Procedure structure for Up_WebMessage
-- ----------------------------
DROP PROCEDURE [dbo].[Up_WebMessage]
GO
CREATE PROCEDURE [dbo].[Up_WebMessage]
	@WMId int=0,
	@ReceiverId int=0,
	@ReceiverName nvarchar(50)=" ",
	@SendId int=0,
	@SendName nvarchar(50)=" ",
	@Title nvarchar(150)=" ",
	@Content ntext=" ",
	@IsSend int=0,
	@IsRead int=0,
	@ReceiverDel int=0,
	@SendDel int=0,
	@ReceiverRecycleDel int=0,
	@SendRecycleDel int=0,
	@AllUser int=0,
	@UserGroupId int=0,
	@AddDate DateTime=" ",
	@OverdueDate DateTime=" ",
	@WhereStr nvarchar(100)=" "
AS
	insert into [KyWebMessage](ReceiverId,ReceiverName,SendId,SendName,Title,Content,IsSend,IsRead,ReceiverDel,SendDel,AllUser,UserGroupId,OverdueDate,AddDate) values(@ReceiverId,@ReceiverName,@SendId,@SendName,@Title,@Content,@IsSend,@IsRead,@ReceiverDel,@SendDel,@AllUser,@UserGroupId,@OverdueDate,@AddDate)	
	RETURN
GO

-- ----------------------------
-- Procedure structure for Up_WebMessage_GetList
-- ----------------------------
DROP PROCEDURE [dbo].[Up_WebMessage_GetList]
GO

CREATE PROCEDURE [dbo].[Up_WebMessage_GetList]

	@CurrPage Int,  
	@PageSize Int, 
	@WhereStr nvarchar(100)
AS
	Declare @SqlStr Nvarchar(2000);  
	If(@CurrPage=1)
		set @SqlStr=N'Select Top '+Convert(Nvarchar(15),@PageSize)+' * from [KyWebMessage] '+Convert(Nvarchar(100),@WhereStr)+' order by WMId desc';
	Else
		set @SqlStr=N'Select Top '+Convert(Nvarchar(15),@PageSize)+' * from [KyWebMessage] '+Convert(Nvarchar(100),@WhereStr)+' and WMId Not in(select Top '+Convert(Nvarchar(15),(@CurrPage-1)*@PageSize)+' WMId from [KyWebMessage] '+Convert(Nvarchar(100),@WhereStr)+' order by WMId desc) order by WMId desc'; 
	Execute Sp_ExecuteSql @SqlStr  
	Set @SqlStr = N'Select Count(WMId) From [KyWebMessage] '+@WhereStr;
	Execute Sp_ExecuteSql @SqlStr 
	
	RETURN
GO

-- ----------------------------
-- Indexes structure for table dtproperties
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table dtproperties
-- ----------------------------
ALTER TABLE [dbo].[dtproperties] ADD PRIMARY KEY ([id], [property])
GO

-- ----------------------------
-- Indexes structure for table Ky_User_Business
-- ----------------------------
CREATE INDEX [IX_Ky_User_Business_UId] ON [dbo].[Ky_User_Business]
([UId] ASC) 
GO

-- ----------------------------
-- Primary Key structure for table Ky_User_Business
-- ----------------------------
ALTER TABLE [dbo].[Ky_User_Business] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table Ky_User_Personal
-- ----------------------------
CREATE INDEX [IX_Ky_User_Personal_UId] ON [dbo].[Ky_User_Personal]
([UId] ASC) 
GO

-- ----------------------------
-- Primary Key structure for table Ky_User_Personal
-- ----------------------------
ALTER TABLE [dbo].[Ky_User_Personal] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table KyAd
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyAd
-- ----------------------------
ALTER TABLE [dbo].[KyAd] ADD PRIMARY KEY ([AdId])
GO

-- ----------------------------
-- Indexes structure for table KyAdCategory
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyAdCategory
-- ----------------------------
ALTER TABLE [dbo].[KyAdCategory] ADD PRIMARY KEY ([AdCategoryId])
GO

-- ----------------------------
-- Indexes structure for table KyAdmin
-- ----------------------------
CREATE UNIQUE INDEX [idx_1] ON [dbo].[KyAdmin]
([LoginName] ASC) 
WITH (IGNORE_DUP_KEY = ON)
GO

-- ----------------------------
-- Primary Key structure for table KyAdmin
-- ----------------------------
ALTER TABLE [dbo].[KyAdmin] ADD PRIMARY KEY ([UserId])
GO

-- ----------------------------
-- Indexes structure for table KyAnomaly
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyAnomaly
-- ----------------------------
ALTER TABLE [dbo].[KyAnomaly] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table KyArticle
-- ----------------------------
CREATE INDEX [IX_KyArticle_ColId] ON [dbo].[KyArticle]
([ColId] ASC) 
GO
CREATE INDEX [IX_KyArticle_AddTime] ON [dbo].[KyArticle]
([AddTime] ASC) 
GO
CREATE INDEX [IX_KyArticle_ExpireTime] ON [dbo].[KyArticle]
([ExpireTime] ASC) 
GO
CREATE INDEX [IX_KyArticle_SpecialIdStr] ON [dbo].[KyArticle]
([SpecialIdStr] ASC) 
GO
CREATE INDEX [IX_KyArticle_TagIdStr] ON [dbo].[KyArticle]
([TagIdStr] ASC) 
GO

-- ----------------------------
-- Primary Key structure for table KyArticle
-- ----------------------------
ALTER TABLE [dbo].[KyArticle] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table KyCard
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyCard
-- ----------------------------
ALTER TABLE [dbo].[KyCard] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table KyChannel
-- ----------------------------
CREATE INDEX [IX_KyChannel_ModelType] ON [dbo].[KyChannel]
([ModelType] ASC) 
GO

-- ----------------------------
-- Primary Key structure for table KyChannel
-- ----------------------------
ALTER TABLE [dbo].[KyChannel] ADD PRIMARY KEY ([ChId])
GO

-- ----------------------------
-- Indexes structure for table KyCollection
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyCollection
-- ----------------------------
ALTER TABLE [dbo].[KyCollection] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table KyCollectionAddress
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyCollectionAddress
-- ----------------------------
ALTER TABLE [dbo].[KyCollectionAddress] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table KyColumn
-- ----------------------------
CREATE INDEX [IX_KyColumn_chid] ON [dbo].[KyColumn]
([ChId] ASC) 
GO

-- ----------------------------
-- Primary Key structure for table KyColumn
-- ----------------------------
ALTER TABLE [dbo].[KyColumn] ADD PRIMARY KEY ([ColId])
GO

-- ----------------------------
-- Indexes structure for table KyComment
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyComment
-- ----------------------------
ALTER TABLE [dbo].[KyComment] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table KyController
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyController
-- ----------------------------
ALTER TABLE [dbo].[KyController] ADD PRIMARY KEY ([ControllerId])
GO

-- ----------------------------
-- Indexes structure for table KyCustomForm
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyCustomForm
-- ----------------------------
ALTER TABLE [dbo].[KyCustomForm] ADD PRIMARY KEY ([CustomFormId])
GO

-- ----------------------------
-- Indexes structure for table KyCustomFormField
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyCustomFormField
-- ----------------------------
ALTER TABLE [dbo].[KyCustomFormField] ADD PRIMARY KEY ([FieldId])
GO

-- ----------------------------
-- Indexes structure for table KyDictionary
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyDictionary
-- ----------------------------
ALTER TABLE [dbo].[KyDictionary] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table KyDig
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyDig
-- ----------------------------
ALTER TABLE [dbo].[KyDig] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table KyDownLoadAddress
-- ----------------------------
CREATE INDEX [DownLoadServerID] ON [dbo].[KyDownLoadAddress]
([DownLoadServerID] ASC) 
GO

-- ----------------------------
-- Primary Key structure for table KyDownLoadAddress
-- ----------------------------
ALTER TABLE [dbo].[KyDownLoadAddress] ADD PRIMARY KEY ([AddressId])
GO

-- ----------------------------
-- Indexes structure for table KyDownLoadData
-- ----------------------------
CREATE INDEX [IX_KyDownLoadData_ColId] ON [dbo].[KyDownLoadData]
([ColId] ASC) 
GO
CREATE INDEX [IX_KyDownLoadData_AddTime] ON [dbo].[KyDownLoadData]
([AddTime] ASC) 
GO
CREATE INDEX [IX_KyDownLoadData_SpecialIdStr] ON [dbo].[KyDownLoadData]
([SpecialIdStr] ASC) 
GO
CREATE INDEX [IX_KyDownLoadData_TagIdStr] ON [dbo].[KyDownLoadData]
([TagIdStr] ASC) 
GO

-- ----------------------------
-- Primary Key structure for table KyDownLoadData
-- ----------------------------
ALTER TABLE [dbo].[KyDownLoadData] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table KyDownLoadServerData
-- ----------------------------
CREATE INDEX [TypeId] ON [dbo].[KyDownLoadServerData]
([DownLoadServerDataId] ASC) 
GO

-- ----------------------------
-- Primary Key structure for table KyDownLoadServerData
-- ----------------------------
ALTER TABLE [dbo].[KyDownLoadServerData] ADD PRIMARY KEY ([DownLoadServerDataId])
GO

-- ----------------------------
-- Indexes structure for table KyDownLoadServerType
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyDownLoadServerType
-- ----------------------------
ALTER TABLE [dbo].[KyDownLoadServerType] ADD PRIMARY KEY ([TypeId])
GO

-- ----------------------------
-- Indexes structure for table KyEnterprise
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyEnterprise
-- ----------------------------
ALTER TABLE [dbo].[KyEnterprise] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table KyExpireArticle
-- ----------------------------
CREATE UNIQUE INDEX [IX_KyExpirtArticle] ON [dbo].[KyExpireArticle]
([Id] ASC) 
WITH (IGNORE_DUP_KEY = ON)
GO
CREATE INDEX [IX_KyExpirtArticle_ExpirtTime] ON [dbo].[KyExpireArticle]
([ExpireTime] ASC) 
GO

-- ----------------------------
-- Indexes structure for table KyFeedback
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyFeedback
-- ----------------------------
ALTER TABLE [dbo].[KyFeedback] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table KyImage
-- ----------------------------
CREATE INDEX [IX_KyImage_AddTime] ON [dbo].[KyImage]
([AddTime] ASC) 
GO
CREATE INDEX [IX_KyImage_SpecialIdStr] ON [dbo].[KyImage]
([SpecialIdStr] ASC) 
GO
CREATE INDEX [IX_KyImage_TagIdStr] ON [dbo].[KyImage]
([TagIdStr] ASC) 
GO
CREATE INDEX [IX_KyImage_ColId] ON [dbo].[KyImage]
([ColId] ASC) 
GO

-- ----------------------------
-- Primary Key structure for table KyImage
-- ----------------------------
ALTER TABLE [dbo].[KyImage] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table KyLabelContent
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyLabelContent
-- ----------------------------
ALTER TABLE [dbo].[KyLabelContent] ADD PRIMARY KEY ([LabelCategoryID])
GO

-- ----------------------------
-- Indexes structure for table KyLbCategory
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyLbCategory
-- ----------------------------
ALTER TABLE [dbo].[KyLbCategory] ADD PRIMARY KEY ([LbCategoryID])
GO

-- ----------------------------
-- Indexes structure for table KyLink
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyLink
-- ----------------------------
ALTER TABLE [dbo].[KyLink] ADD PRIMARY KEY ([LinkId])
GO

-- ----------------------------
-- Indexes structure for table KyListStyleContent
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyListStyleContent
-- ----------------------------
ALTER TABLE [dbo].[KyListStyleContent] ADD PRIMARY KEY ([ModelId])
GO

-- ----------------------------
-- Indexes structure for table KyLog
-- ----------------------------
CREATE INDEX [idx_1] ON [dbo].[KyLog]
([LogTime] ASC, [UserId] ASC) 
GO

-- ----------------------------
-- Primary Key structure for table KyLog
-- ----------------------------
ALTER TABLE [dbo].[KyLog] ADD PRIMARY KEY ([LogId])
GO

-- ----------------------------
-- Indexes structure for table KyModel
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyModel
-- ----------------------------
ALTER TABLE [dbo].[KyModel] ADD PRIMARY KEY ([ModelId])
GO

-- ----------------------------
-- Indexes structure for table KyModelField
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyModelField
-- ----------------------------
ALTER TABLE [dbo].[KyModelField] ADD PRIMARY KEY ([FieldId])
GO

-- ----------------------------
-- Indexes structure for table KyNotice
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyNotice
-- ----------------------------
ALTER TABLE [dbo].[KyNotice] ADD PRIMARY KEY ([NoticeId])
GO

-- ----------------------------
-- Indexes structure for table KyPowerColumn
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyPowerColumn
-- ----------------------------
ALTER TABLE [dbo].[KyPowerColumn] ADD PRIMARY KEY ([PCId])
GO

-- ----------------------------
-- Indexes structure for table KyPowerGroup
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyPowerGroup
-- ----------------------------
ALTER TABLE [dbo].[KyPowerGroup] ADD PRIMARY KEY ([PowerId])
GO

-- ----------------------------
-- Indexes structure for table KyRechargeRecord
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyRechargeRecord
-- ----------------------------
ALTER TABLE [dbo].[KyRechargeRecord] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table KyReport
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyReport
-- ----------------------------
ALTER TABLE [dbo].[KyReport] ADD PRIMARY KEY ([ReportId])
GO

-- ----------------------------
-- Indexes structure for table KyReview
-- ----------------------------
CREATE INDEX [IX_KyReview] ON [dbo].[KyReview]
([ModelType] ASC) 
GO

-- ----------------------------
-- Primary Key structure for table KyReview
-- ----------------------------
ALTER TABLE [dbo].[KyReview] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table KySinglePage
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KySinglePage
-- ----------------------------
ALTER TABLE [dbo].[KySinglePage] ADD PRIMARY KEY ([SingleId])
GO

-- ----------------------------
-- Indexes structure for table KyStyle
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyStyle
-- ----------------------------
ALTER TABLE [dbo].[KyStyle] ADD PRIMARY KEY ([StyleID])
GO

-- ----------------------------
-- Indexes structure for table KyStyleCategory
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyStyleCategory
-- ----------------------------
ALTER TABLE [dbo].[KyStyleCategory] ADD PRIMARY KEY ([StyleCategoryID])
GO

-- ----------------------------
-- Indexes structure for table KySuperior
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KySuperior
-- ----------------------------
ALTER TABLE [dbo].[KySuperior] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table KySuperLabel
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KySuperLabel
-- ----------------------------
ALTER TABLE [dbo].[KySuperLabel] ADD PRIMARY KEY ([SuperId])
GO

-- ----------------------------
-- Indexes structure for table KyTag
-- ----------------------------
CREATE INDEX [IX_KyTag] ON [dbo].[KyTag]
([TotalSearchCount] DESC, [TagId] DESC) 
GO

-- ----------------------------
-- Primary Key structure for table KyTag
-- ----------------------------
ALTER TABLE [dbo].[KyTag] ADD PRIMARY KEY ([TagId])
GO

-- ----------------------------
-- Indexes structure for table KyTagCategory
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyTagCategory
-- ----------------------------
ALTER TABLE [dbo].[KyTagCategory] ADD PRIMARY KEY ([TagCategoryId])
GO

-- ----------------------------
-- Indexes structure for table KyUserAlbum
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyUserAlbum
-- ----------------------------
ALTER TABLE [dbo].[KyUserAlbum] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table KyUserCate
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyUserCate
-- ----------------------------
ALTER TABLE [dbo].[KyUserCate] ADD PRIMARY KEY ([UserCateId])
GO

-- ----------------------------
-- Indexes structure for table KyUserFavorite
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyUserFavorite
-- ----------------------------
ALTER TABLE [dbo].[KyUserFavorite] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table KyUserFriend
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyUserFriend
-- ----------------------------
ALTER TABLE [dbo].[KyUserFriend] ADD PRIMARY KEY ([UserId], [FriendId])
GO

-- ----------------------------
-- Indexes structure for table KyUserFriendGroup
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyUserFriendGroup
-- ----------------------------
ALTER TABLE [dbo].[KyUserFriendGroup] ADD PRIMARY KEY ([FriendGroupId])
GO

-- ----------------------------
-- Indexes structure for table KyUserGroup
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyUserGroup
-- ----------------------------
ALTER TABLE [dbo].[KyUserGroup] ADD PRIMARY KEY ([UserGroupId])
GO

-- ----------------------------
-- Indexes structure for table KyUserGroupModel
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyUserGroupModel
-- ----------------------------
ALTER TABLE [dbo].[KyUserGroupModel] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table KyUserGroupModelField
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyUserGroupModelField
-- ----------------------------
ALTER TABLE [dbo].[KyUserGroupModelField] ADD PRIMARY KEY ([FieldId])
GO

-- ----------------------------
-- Indexes structure for table KyUserMessage
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyUserMessage
-- ----------------------------
ALTER TABLE [dbo].[KyUserMessage] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table KyUserPhoto
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyUserPhoto
-- ----------------------------
ALTER TABLE [dbo].[KyUserPhoto] ADD PRIMARY KEY ([PhotoId])
GO

-- ----------------------------
-- Indexes structure for table KyUsers
-- ----------------------------
CREATE UNIQUE INDEX [idx_1] ON [dbo].[KyUsers]
([LogName] ASC) 
WITH (IGNORE_DUP_KEY = ON)
GO

-- ----------------------------
-- Primary Key structure for table KyUsers
-- ----------------------------
ALTER TABLE [dbo].[KyUsers] ADD PRIMARY KEY ([UserID])
GO

-- ----------------------------
-- Indexes structure for table KyUserSpace
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyUserSpace
-- ----------------------------
ALTER TABLE [dbo].[KyUserSpace] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table KyViewLog
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyViewLog
-- ----------------------------
ALTER TABLE [dbo].[KyViewLog] ADD PRIMARY KEY ([Id])
GO

-- ----------------------------
-- Indexes structure for table KyVote
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyVote
-- ----------------------------
ALTER TABLE [dbo].[KyVote] ADD PRIMARY KEY ([VoteId])
GO

-- ----------------------------
-- Indexes structure for table KyVoteCategory
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyVoteCategory
-- ----------------------------
ALTER TABLE [dbo].[KyVoteCategory] ADD PRIMARY KEY ([CategoryId])
GO

-- ----------------------------
-- Indexes structure for table KyVoteSubject
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyVoteSubject
-- ----------------------------
ALTER TABLE [dbo].[KyVoteSubject] ADD PRIMARY KEY ([VoteSubjectId])
GO

-- ----------------------------
-- Indexes structure for table KyWebMessage
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table KyWebMessage
-- ----------------------------
ALTER TABLE [dbo].[KyWebMessage] ADD PRIMARY KEY ([WMId])
GO
