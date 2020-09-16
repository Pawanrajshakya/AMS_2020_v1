﻿IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [AccountHistories] (
    [Id] int NOT NULL IDENTITY,
    [AccountNo] nvarchar(max) NULL,
    [ClientId] int NOT NULL,
    [Name] nvarchar(max) NULL,
    [Balance] decimal(18,2) NOT NULL,
    [AccountTypeId] int NOT NULL,
    [IsMain] bit NOT NULL,
    [FirstName] nvarchar(255) NULL,
    [MiddleName] nvarchar(50) NULL,
    [LastName] nvarchar(255) NULL,
    [Phone] nvarchar(12) NULL,
    [Email] nvarchar(55) NULL,
    [Address1] nvarchar(255) NULL,
    [Address2] nvarchar(255) NULL,
    [State] nvarchar(2) NULL,
    [ZipCode] nvarchar(20) NULL,
    [RelationshipId] int NOT NULL,
    [SortId] int NOT NULL,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] varbinary(max) NULL,
    CONSTRAINT [PK_AccountHistories] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Businesses] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [Name] nvarchar(255) NULL,
    [Address1] nvarchar(255) NULL,
    [Address2] nvarchar(255) NULL,
    [State] nvarchar(2) NULL,
    [ZipCode] nvarchar(5) NULL,
    [Description] nvarchar(255) NULL,
    CONSTRAINT [PK_Businesses] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Groups] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [Description] nvarchar(max) NOT NULL,
    [SortId] int NOT NULL,
    CONSTRAINT [PK_Groups] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Images] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [ReferneceType] nvarchar(1) NOT NULL,
    [ReferenceId] int NOT NULL,
    [Blob] varbinary(max) NULL,
    [ImageType] nvarchar(5) NULL,
    [Size] int NOT NULL,
    [Comment] nvarchar(400) NULL,
    CONSTRAINT [PK_Images] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Menus] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [Title] nvarchar(max) NOT NULL,
    [Link] nvarchar(max) NULL,
    [IconName] nvarchar(max) NULL,
    [MainMenuId] int NOT NULL,
    [SortId] int NOT NULL,
    [UserRoles] nvarchar(max) NULL,
    CONSTRAINT [PK_Menus] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Relationships] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [Description] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Relationships] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Roles] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [UserActivities] (
    [Id] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [DateRequested] datetime2 NOT NULL,
    [ControllerName] nvarchar(max) NULL,
    [ActionName] nvarchar(max) NULL,
    [Comment] nvarchar(max) NULL,
    CONSTRAINT [PK_UserActivities] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [UserHistories] (
    [Id] int NOT NULL IDENTITY,
    [Username] nvarchar(max) NULL,
    [PasswordHash] varbinary(max) NULL,
    [PasswordSalt] varbinary(max) NULL,
    [Name] nvarchar(max) NULL,
    [Phone] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [UserRole] nvarchar(max) NULL,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] varbinary(max) NULL,
    [PasswordChangedCount] int NOT NULL,
    [LastPasswordChangedOn] datetime2 NOT NULL,
    CONSTRAINT [PK_UserHistories] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [UserName] nvarchar(max) NULL,
    [PasswordHash] varbinary(max) NULL,
    [PasswordSalt] varbinary(max) NULL,
    [Name] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Phone] nvarchar(max) NULL,
    [PasswordChangedCount] int NOT NULL,
    [LastPasswordChangedOn] datetime2 NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Clients] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [Name] nvarchar(max) NULL,
    [BusinessId] int NOT NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Clients_Businesses_BusinessId] FOREIGN KEY ([BusinessId]) REFERENCES [Businesses] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Controls] (
    [Id] int NOT NULL IDENTITY,
    [BusinessId] int NOT NULL,
    [CurrentDate] datetime2 NOT NULL,
    [AccountNoLength] int NOT NULL,
    [ReportFolderName] nvarchar(max) NULL,
    CONSTRAINT [PK_Controls] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Controls_Businesses_BusinessId] FOREIGN KEY ([BusinessId]) REFERENCES [Businesses] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AccountTypes] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [Description] nvarchar(max) NULL,
    [SortId] int NOT NULL,
    [GroupId] int NOT NULL,
    [ShortName] nvarchar(max) NULL,
    CONSTRAINT [PK_AccountTypes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AccountTypes_Groups_GroupId] FOREIGN KEY ([GroupId]) REFERENCES [Groups] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [UserRole] (
    [RoleId] int NOT NULL,
    [UserId] int NOT NULL,
    CONSTRAINT [PK_UserRole] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_UserRole_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserRole_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Account] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [AccountNo] nvarchar(max) NULL,
    [ClientId] int NOT NULL,
    [Balance] decimal(18,2) NOT NULL,
    [AccountTypeId] int NOT NULL,
    [FirstName] nvarchar(255) NULL,
    [MiddleName] nvarchar(50) NULL,
    [LastName] nvarchar(255) NULL,
    [Phone] nvarchar(12) NULL,
    [Email] nvarchar(55) NULL,
    [Address1] nvarchar(255) NULL,
    [Address2] nvarchar(255) NULL,
    [State] nvarchar(2) NULL,
    [ZipCode] nvarchar(20) NULL,
    [IsMain] bit NOT NULL,
    [RelationshipId] int NULL,
    [SortId] int NOT NULL,
    [Description] nvarchar(max) NULL,
    [Note] nvarchar(max) NULL,
    CONSTRAINT [PK_Account] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Account_AccountTypes_AccountTypeId] FOREIGN KEY ([AccountTypeId]) REFERENCES [AccountTypes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Account_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Clients] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Account_Relationships_RelationshipId] FOREIGN KEY ([RelationshipId]) REFERENCES [Relationships] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [TransactionTypes] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [Description] nvarchar(max) NULL,
    [AccountId] int NOT NULL,
    [ShortName] nvarchar(max) NULL,
    CONSTRAINT [PK_TransactionTypes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TransactionTypes_Account_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [Account] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Transactions] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [TransactionDate] datetime2 NOT NULL,
    [Amount] decimal(18,2) NOT NULL,
    [Description1] nvarchar(255) NULL,
    [Description2] nvarchar(255) NULL,
    [TransactionTypeId] int NOT NULL,
    [AccountId] int NOT NULL,
    CONSTRAINT [PK_Transactions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Transactions_Account_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [Account] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Transactions_TransactionTypes_TransactionTypeId] FOREIGN KEY ([TransactionTypeId]) REFERENCES [TransactionTypes] ([Id]) ON DELETE CASCADE
);

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address1', N'Address2', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Name', N'State', N'ZipCode') AND [object_id] = OBJECT_ID(N'[Businesses]'))
    SET IDENTITY_INSERT [Businesses] ON;
INSERT INTO [Businesses] ([Id], [Address1], [Address2], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [Name], [State], [ZipCode])
VALUES (1, N'Address 1', N'Address 2', 0, NULL, NULL, 0, 0, 0, NULL, N'Your Business Name', N'zz', N'zzzzz');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address1', N'Address2', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Name', N'State', N'ZipCode') AND [object_id] = OBJECT_ID(N'[Businesses]'))
    SET IDENTITY_INSERT [Businesses] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'SortId') AND [object_id] = OBJECT_ID(N'[Groups]'))
    SET IDENTITY_INSERT [Groups] ON;
INSERT INTO [Groups] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [SortId])
VALUES (1, 0, NULL, N'External Group', 0, 0, 0, NULL, 0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'SortId') AND [object_id] = OBJECT_ID(N'[Groups]'))
    SET IDENTITY_INSERT [Groups] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'SortId') AND [object_id] = OBJECT_ID(N'[Groups]'))
    SET IDENTITY_INSERT [Groups] ON;
INSERT INTO [Groups] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [SortId])
VALUES (2, 0, NULL, N'Internal Group', 0, 0, 0, NULL, 0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'SortId') AND [object_id] = OBJECT_ID(N'[Groups]'))
    SET IDENTITY_INSERT [Groups] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'SortId') AND [object_id] = OBJECT_ID(N'[Groups]'))
    SET IDENTITY_INSERT [Groups] ON;
INSERT INTO [Groups] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [SortId])
VALUES (3, 0, NULL, N'Other Group', 0, 0, 0, NULL, 0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'SortId') AND [object_id] = OBJECT_ID(N'[Groups]'))
    SET IDENTITY_INSERT [Groups] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] ON;
INSERT INTO [Menus] ([Id], [CreatedBy], [CreatedDate], [IconName], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [Link], [MainMenuId], [SortId], [Title], [UserRoles])
VALUES (10, 0, NULL, NULL, 0, 0, 0, NULL, N'user', 6, 2, N'User', N'1');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] ON;
INSERT INTO [Menus] ([Id], [CreatedBy], [CreatedDate], [IconName], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [Link], [MainMenuId], [SortId], [Title], [UserRoles])
VALUES (9, 0, NULL, NULL, 0, 0, 0, NULL, N'role', 6, 1, N'Role', N'1');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] ON;
INSERT INTO [Menus] ([Id], [CreatedBy], [CreatedDate], [IconName], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [Link], [MainMenuId], [SortId], [Title], [UserRoles])
VALUES (8, 0, NULL, NULL, 0, 0, 0, NULL, N'menu', 5, 1, N'Menu', N'1');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] ON;
INSERT INTO [Menus] ([Id], [CreatedBy], [CreatedDate], [IconName], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [Link], [MainMenuId], [SortId], [Title], [UserRoles])
VALUES (6, 0, NULL, NULL, 0, 0, 0, NULL, N'setting', 0, 6, N'Setting', N'1');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] ON;
INSERT INTO [Menus] ([Id], [CreatedBy], [CreatedDate], [IconName], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [Link], [MainMenuId], [SortId], [Title], [UserRoles])
VALUES (7, 0, NULL, NULL, 0, 0, 0, NULL, N'tool', 0, 7, N'Tools', N'1');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] ON;
INSERT INTO [Menus] ([Id], [CreatedBy], [CreatedDate], [IconName], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [Link], [MainMenuId], [SortId], [Title], [UserRoles])
VALUES (4, 0, NULL, NULL, 0, 0, 0, NULL, N'report', 0, 4, N'Reports', N'1,2,3');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] ON;
INSERT INTO [Menus] ([Id], [CreatedBy], [CreatedDate], [IconName], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [Link], [MainMenuId], [SortId], [Title], [UserRoles])
VALUES (3, 0, NULL, NULL, 0, 0, 0, NULL, N'transaction', 0, 3, N'Transaction', N'1,2,3');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] ON;
INSERT INTO [Menus] ([Id], [CreatedBy], [CreatedDate], [IconName], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [Link], [MainMenuId], [SortId], [Title], [UserRoles])
VALUES (2, 0, NULL, NULL, 0, 0, 0, NULL, N'account', 0, 2, N'Account', N'1,2,3');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] ON;
INSERT INTO [Menus] ([Id], [CreatedBy], [CreatedDate], [IconName], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [Link], [MainMenuId], [SortId], [Title], [UserRoles])
VALUES (1, 0, NULL, NULL, 0, 0, 0, NULL, N'home', 0, 1, N'Home', N'1,2,3');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] ON;
INSERT INTO [Menus] ([Id], [CreatedBy], [CreatedDate], [IconName], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [Link], [MainMenuId], [SortId], [Title], [UserRoles])
VALUES (5, 0, NULL, NULL, 0, 0, 0, NULL, N'code', 0, 5, N'Code System', N'1');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] ON;
INSERT INTO [Relationships] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (11, 0, NULL, N'sibling – a brother or sister', 0, 0, 0, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] ON;
INSERT INTO [Relationships] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (17, 0, NULL, N'Other', 0, 0, 0, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] ON;
INSERT INTO [Relationships] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (16, 0, NULL, N'father – somebody’s male parent', 0, 0, 0, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] ON;
INSERT INTO [Relationships] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (15, 0, NULL, N'grandmother – somebody’s parent’s mother', 0, 0, 0, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] ON;
INSERT INTO [Relationships] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (14, 0, NULL, N'grandfather – somebody’s parent’s father', 0, 0, 0, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] ON;
INSERT INTO [Relationships] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (13, 0, NULL, N'younger brother / sister – brother / sister who is younger than you', 0, 0, 0, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] ON;
INSERT INTO [Relationships] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (12, 0, NULL, N'elder brother/ sister – a brother/ sister who is older than you', 0, 0, 0, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] ON;
INSERT INTO [Relationships] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (10, 0, NULL, N'sister – a girl or woman who has the same parents as another person', 0, 0, 0, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] ON;
INSERT INTO [Relationships] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (3, 0, NULL, N'parent – somebody’s father or mother', 0, 0, 0, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] ON;
INSERT INTO [Relationships] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (8, 0, NULL, N'spouse – somebody married to another person; husband or wife', 0, 0, 0, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] ON;
INSERT INTO [Relationships] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (7, 0, NULL, N'wife – the woman who a man is married to', 0, 0, 0, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] ON;
INSERT INTO [Relationships] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (6, 0, NULL, N'husband – the man who a woman is married to', 0, 0, 0, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] ON;
INSERT INTO [Relationships] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (5, 0, NULL, N'daughter – somebody’s female child', 0, 0, 0, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] ON;
INSERT INTO [Relationships] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (4, 0, NULL, N'son – somebody’s male child', 0, 0, 0, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] ON;
INSERT INTO [Relationships] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (2, 0, NULL, N'mother – somebody’s female parent', 0, 0, 0, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] ON;
INSERT INTO [Relationships] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (1, 0, NULL, N'NA – Not Applicable', 0, 0, 0, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] ON;
INSERT INTO [Relationships] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (9, 0, NULL, N'brother – a boy or man who has the same parents as another person', 0, 0, 0, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Roles]'))
    SET IDENTITY_INSERT [Roles] ON;
INSERT INTO [Roles] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (2, 0, NULL, N'User', 0, 0, 0, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Roles]'))
    SET IDENTITY_INSERT [Roles] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Roles]'))
    SET IDENTITY_INSERT [Roles] ON;
INSERT INTO [Roles] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (1, 0, NULL, N'Admin', 0, 0, 0, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Roles]'))
    SET IDENTITY_INSERT [Roles] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Roles]'))
    SET IDENTITY_INSERT [Roles] ON;
INSERT INTO [Roles] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (3, 0, NULL, N'Viewer', 0, 0, 0, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Roles]'))
    SET IDENTITY_INSERT [Roles] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'ShortName', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] ON;
INSERT INTO [AccountTypes] ([Id], [CreatedBy], [CreatedDate], [Description], [GroupId], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [ShortName], [SortId])
VALUES (1, 0, NULL, N'Normal Account', 1, 0, 0, 0, NULL, N'NA', 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'ShortName', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'ShortName', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] ON;
INSERT INTO [AccountTypes] ([Id], [CreatedBy], [CreatedDate], [Description], [GroupId], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [ShortName], [SortId])
VALUES (2, 0, NULL, N'Cash Account', 2, 0, 0, 0, NULL, N'CA', 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'ShortName', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'ShortName', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] ON;
INSERT INTO [AccountTypes] ([Id], [CreatedBy], [CreatedDate], [Description], [GroupId], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [ShortName], [SortId])
VALUES (3, 0, NULL, N'Bank Account', 2, 0, 0, 0, NULL, N'BA', 3);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'ShortName', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'ShortName', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] ON;
INSERT INTO [AccountTypes] ([Id], [CreatedBy], [CreatedDate], [Description], [GroupId], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [ShortName], [SortId])
VALUES (4, 0, NULL, N'Income Account', 2, 0, 0, 0, NULL, N'IA', 4);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'ShortName', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'ShortName', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] ON;
INSERT INTO [AccountTypes] ([Id], [CreatedBy], [CreatedDate], [Description], [GroupId], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [ShortName], [SortId])
VALUES (5, 0, NULL, N'Expense Account', 2, 0, 0, 0, NULL, N'EA', 5);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'ShortName', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'ShortName', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] ON;
INSERT INTO [AccountTypes] ([Id], [CreatedBy], [CreatedDate], [Description], [GroupId], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [ShortName], [SortId])
VALUES (6, 0, NULL, N'Payable Account', 2, 0, 0, 0, NULL, N'PA', 6);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'ShortName', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'ShortName', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] ON;
INSERT INTO [AccountTypes] ([Id], [CreatedBy], [CreatedDate], [Description], [GroupId], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [ShortName], [SortId])
VALUES (7, 0, NULL, N'Receivable Account', 2, 0, 0, 0, NULL, N'RA', 7);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'ShortName', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'ShortName', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] ON;
INSERT INTO [AccountTypes] ([Id], [CreatedBy], [CreatedDate], [Description], [GroupId], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [ShortName], [SortId])
VALUES (8, 0, NULL, N'Assets Account', 2, 0, 0, 0, NULL, N'AA', 8);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'ShortName', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'ShortName', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] ON;
INSERT INTO [AccountTypes] ([Id], [CreatedBy], [CreatedDate], [Description], [GroupId], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [ShortName], [SortId])
VALUES (9, 0, NULL, N'Liabilities Account', 2, 0, 0, 0, NULL, N'LA', 9);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'ShortName', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'ShortName', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] ON;
INSERT INTO [AccountTypes] ([Id], [CreatedBy], [CreatedDate], [Description], [GroupId], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [ShortName], [SortId])
VALUES (10, 0, NULL, N'Other Account', 3, 0, 0, 0, NULL, N'OA', 10);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'ShortName', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BusinessId', N'CreatedBy', N'CreatedDate', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Name') AND [object_id] = OBJECT_ID(N'[Clients]'))
    SET IDENTITY_INSERT [Clients] ON;
INSERT INTO [Clients] ([Id], [BusinessId], [CreatedBy], [CreatedDate], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [Name])
VALUES (1, 1, 0, NULL, 0, 0, 0, NULL, N'Internal Client');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BusinessId', N'CreatedBy', N'CreatedDate', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Name') AND [object_id] = OBJECT_ID(N'[Clients]'))
    SET IDENTITY_INSERT [Clients] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BusinessId', N'CreatedBy', N'CreatedDate', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Name') AND [object_id] = OBJECT_ID(N'[Clients]'))
    SET IDENTITY_INSERT [Clients] ON;
INSERT INTO [Clients] ([Id], [BusinessId], [CreatedBy], [CreatedDate], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [Name])
VALUES (2, 1, 0, NULL, 0, 0, 0, NULL, N'Default Client');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BusinessId', N'CreatedBy', N'CreatedDate', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Name') AND [object_id] = OBJECT_ID(N'[Clients]'))
    SET IDENTITY_INSERT [Clients] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccountNoLength', N'BusinessId', N'CurrentDate', N'ReportFolderName') AND [object_id] = OBJECT_ID(N'[Controls]'))
    SET IDENTITY_INSERT [Controls] ON;
INSERT INTO [Controls] ([Id], [AccountNoLength], [BusinessId], [CurrentDate], [ReportFolderName])
VALUES (1, 20, 1, '2020-08-31T00:00:00.0000000-04:00', N'Reports\');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccountNoLength', N'BusinessId', N'CurrentDate', N'ReportFolderName') AND [object_id] = OBJECT_ID(N'[Controls]'))
    SET IDENTITY_INSERT [Controls] OFF;

GO

CREATE INDEX [IX_Account_AccountTypeId] ON [Account] ([AccountTypeId]);

GO

CREATE INDEX [IX_Account_ClientId] ON [Account] ([ClientId]);

GO

CREATE INDEX [IX_Account_RelationshipId] ON [Account] ([RelationshipId]);

GO

CREATE INDEX [IX_AccountTypes_GroupId] ON [AccountTypes] ([GroupId]);

GO

CREATE INDEX [IX_Clients_BusinessId] ON [Clients] ([BusinessId]);

GO

CREATE INDEX [IX_Controls_BusinessId] ON [Controls] ([BusinessId]);

GO

CREATE INDEX [IX_Transactions_AccountId] ON [Transactions] ([AccountId]);

GO

CREATE INDEX [IX_Transactions_TransactionTypeId] ON [Transactions] ([TransactionTypeId]);

GO

CREATE INDEX [IX_TransactionTypes_AccountId] ON [TransactionTypes] ([AccountId]);

GO

CREATE INDEX [IX_UserRole_RoleId] ON [UserRole] ([RoleId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200831201510_Inital_Database', N'2.2.6-servicing-10079');

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Account]') AND [c].[name] = N'LastName');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Account] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Account] ALTER COLUMN [LastName] nvarchar(255) NOT NULL;

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Account]') AND [c].[name] = N'FirstName');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Account] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Account] ALTER COLUMN [FirstName] nvarchar(255) NOT NULL;

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Account]') AND [c].[name] = N'AccountNo');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Account] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Account] ALTER COLUMN [AccountNo] nvarchar(max) NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200831201816_Inital_Database_1', N'2.2.6-servicing-10079');

GO

