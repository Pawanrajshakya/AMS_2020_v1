IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
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
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
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
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [Description] nvarchar(max) NOT NULL,
    [SortId] int NOT NULL,
    CONSTRAINT [PK_Groups] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Menus] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
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
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
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
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
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
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
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
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [Name] nvarchar(max) NULL,
    [BusinessId] int NOT NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Clients_Businesses_BusinessId] FOREIGN KEY ([BusinessId]) REFERENCES [Businesses] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AccountTypes] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [Description] nvarchar(max) NULL,
    [SortId] int NOT NULL,
    [GroupId] int NOT NULL,
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
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
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
    CONSTRAINT [PK_Account] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Account_AccountTypes_AccountTypeId] FOREIGN KEY ([AccountTypeId]) REFERENCES [AccountTypes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Account_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Clients] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Account_Relationships_RelationshipId] FOREIGN KEY ([RelationshipId]) REFERENCES [Relationships] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [TransactionTypes] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
    [IsVisible] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NULL,
    [Description] nvarchar(max) NULL,
    [AccountId] int NOT NULL,
    CONSTRAINT [PK_TransactionTypes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TransactionTypes_Account_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [Account] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Transactions] (
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastModifiedBy] int NOT NULL,
    [LastModifiedDate] datetime2 NOT NULL,
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
VALUES (1, N'Address 1', N'Address 2', 0, '2020-08-20T13:43:28.2909976-04:00', NULL, 1, 1, 0, '2020-08-20T13:43:28.2909976-04:00', N'Business Name', N'zz', N'zzzzz');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address1', N'Address2', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Name', N'State', N'ZipCode') AND [object_id] = OBJECT_ID(N'[Businesses]'))
    SET IDENTITY_INSERT [Businesses] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'SortId') AND [object_id] = OBJECT_ID(N'[Groups]'))
    SET IDENTITY_INSERT [Groups] ON;
INSERT INTO [Groups] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [SortId])
VALUES (1, 0, '2020-08-20T13:43:28.2943417-04:00', N'External Group', 1, 1, 0, '2020-08-20T13:43:28.2943417-04:00', 0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'SortId') AND [object_id] = OBJECT_ID(N'[Groups]'))
    SET IDENTITY_INSERT [Groups] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'SortId') AND [object_id] = OBJECT_ID(N'[Groups]'))
    SET IDENTITY_INSERT [Groups] ON;
INSERT INTO [Groups] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [SortId])
VALUES (2, 0, '2020-08-20T13:43:28.2943417-04:00', N'Internal Group', 1, 1, 0, '2020-08-20T13:43:28.2943417-04:00', 0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'SortId') AND [object_id] = OBJECT_ID(N'[Groups]'))
    SET IDENTITY_INSERT [Groups] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'SortId') AND [object_id] = OBJECT_ID(N'[Groups]'))
    SET IDENTITY_INSERT [Groups] ON;
INSERT INTO [Groups] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [SortId])
VALUES (3, 0, '2020-08-20T13:43:28.2943417-04:00', N'Other Group', 1, 1, 0, '2020-08-20T13:43:28.2943417-04:00', 0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'SortId') AND [object_id] = OBJECT_ID(N'[Groups]'))
    SET IDENTITY_INSERT [Groups] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] ON;
INSERT INTO [Menus] ([Id], [CreatedBy], [CreatedDate], [IconName], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [Link], [MainMenuId], [SortId], [Title], [UserRoles])
VALUES (10, 0, '2020-08-20T13:43:28.2952180-04:00', NULL, 1, 1, 0, '2020-08-20T13:43:28.2952180-04:00', N'user', 6, 2, N'User', N'1');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] ON;
INSERT INTO [Menus] ([Id], [CreatedBy], [CreatedDate], [IconName], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [Link], [MainMenuId], [SortId], [Title], [UserRoles])
VALUES (9, 0, '2020-08-20T13:43:28.2952180-04:00', NULL, 1, 1, 0, '2020-08-20T13:43:28.2952180-04:00', N'role', 6, 1, N'Role', N'1');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] ON;
INSERT INTO [Menus] ([Id], [CreatedBy], [CreatedDate], [IconName], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [Link], [MainMenuId], [SortId], [Title], [UserRoles])
VALUES (8, 0, '2020-08-20T13:43:28.2952180-04:00', NULL, 1, 1, 0, '2020-08-20T13:43:28.2952180-04:00', N'menu', 5, 1, N'Menu', N'1');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] ON;
INSERT INTO [Menus] ([Id], [CreatedBy], [CreatedDate], [IconName], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [Link], [MainMenuId], [SortId], [Title], [UserRoles])
VALUES (6, 0, '2020-08-20T13:43:28.2952180-04:00', NULL, 1, 1, 0, '2020-08-20T13:43:28.2952180-04:00', N'setting', 0, 6, N'Setting', N'1');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] ON;
INSERT INTO [Menus] ([Id], [CreatedBy], [CreatedDate], [IconName], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [Link], [MainMenuId], [SortId], [Title], [UserRoles])
VALUES (7, 0, '2020-08-20T13:43:28.2952180-04:00', NULL, 1, 1, 0, '2020-08-20T13:43:28.2952180-04:00', N'tool', 0, 7, N'Tools', N'1');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] ON;
INSERT INTO [Menus] ([Id], [CreatedBy], [CreatedDate], [IconName], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [Link], [MainMenuId], [SortId], [Title], [UserRoles])
VALUES (4, 0, '2020-08-20T13:43:28.2952180-04:00', NULL, 1, 1, 0, '2020-08-20T13:43:28.2952180-04:00', N'report', 0, 4, N'Reports', N'1,2,3');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] ON;
INSERT INTO [Menus] ([Id], [CreatedBy], [CreatedDate], [IconName], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [Link], [MainMenuId], [SortId], [Title], [UserRoles])
VALUES (3, 0, '2020-08-20T13:43:28.2952180-04:00', NULL, 1, 1, 0, '2020-08-20T13:43:28.2952180-04:00', N'transaction', 0, 3, N'Transaction', N'1,2,3');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] ON;
INSERT INTO [Menus] ([Id], [CreatedBy], [CreatedDate], [IconName], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [Link], [MainMenuId], [SortId], [Title], [UserRoles])
VALUES (2, 0, '2020-08-20T13:43:28.2952180-04:00', NULL, 1, 1, 0, '2020-08-20T13:43:28.2952180-04:00', N'account', 0, 2, N'Account', N'1,2,3');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] ON;
INSERT INTO [Menus] ([Id], [CreatedBy], [CreatedDate], [IconName], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [Link], [MainMenuId], [SortId], [Title], [UserRoles])
VALUES (1, 0, '2020-08-20T13:43:28.2943417-04:00', NULL, 1, 1, 0, '2020-08-20T13:43:28.2943417-04:00', N'home', 0, 1, N'Home', N'1,2,3');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] ON;
INSERT INTO [Menus] ([Id], [CreatedBy], [CreatedDate], [IconName], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [Link], [MainMenuId], [SortId], [Title], [UserRoles])
VALUES (5, 0, '2020-08-20T13:43:28.2952180-04:00', NULL, 1, 1, 0, '2020-08-20T13:43:28.2952180-04:00', N'code', 0, 5, N'Code System', N'1');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'IconName', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'Link', N'MainMenuId', N'SortId', N'Title', N'UserRoles') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] ON;
INSERT INTO [Relationships] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (10, 0, '2020-08-20T13:43:28.2952180-04:00', N'sister – a girl or woman who has the same parents as another person', 1, 1, 0, '2020-08-20T13:43:28.2952180-04:00');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] ON;
INSERT INTO [Relationships] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (16, 0, '2020-08-20T13:43:28.2952180-04:00', N'Other', 1, 1, 0, '2020-08-20T13:43:28.2952180-04:00');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] ON;
INSERT INTO [Relationships] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (15, 0, '2020-08-20T13:43:28.2952180-04:00', N'grandmother – somebody’s parent’s mother', 1, 1, 0, '2020-08-20T13:43:28.2952180-04:00');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] ON;
INSERT INTO [Relationships] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (14, 0, '2020-08-20T13:43:28.2952180-04:00', N'grandfather – somebody’s parent’s father', 1, 1, 0, '2020-08-20T13:43:28.2952180-04:00');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] ON;
INSERT INTO [Relationships] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (13, 0, '2020-08-20T13:43:28.2952180-04:00', N'younger brother / sister – brother / sister who is younger than you', 1, 1, 0, '2020-08-20T13:43:28.2952180-04:00');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] ON;
INSERT INTO [Relationships] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (12, 0, '2020-08-20T13:43:28.2952180-04:00', N'elder brother/ sister – a brother/ sister who is older than you', 1, 1, 0, '2020-08-20T13:43:28.2952180-04:00');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] ON;
INSERT INTO [Relationships] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (11, 0, '2020-08-20T13:43:28.2952180-04:00', N'sibling – a brother or sister', 1, 1, 0, '2020-08-20T13:43:28.2952180-04:00');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] ON;
INSERT INTO [Relationships] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (9, 0, '2020-08-20T13:43:28.2952180-04:00', N'brother – a boy or man who has the same parents as another person', 1, 1, 0, '2020-08-20T13:43:28.2952180-04:00');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] ON;
INSERT INTO [Relationships] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (3, 0, '2020-08-20T13:43:28.2952180-04:00', N'parent – somebody’s father or mother', 1, 1, 0, '2020-08-20T13:43:28.2952180-04:00');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] ON;
INSERT INTO [Relationships] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (7, 0, '2020-08-20T13:43:28.2952180-04:00', N'wife – the woman who a man is married to', 1, 1, 0, '2020-08-20T13:43:28.2952180-04:00');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] ON;
INSERT INTO [Relationships] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (6, 0, '2020-08-20T13:43:28.2952180-04:00', N'husband – the man who a woman is married to', 1, 1, 0, '2020-08-20T13:43:28.2952180-04:00');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] ON;
INSERT INTO [Relationships] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (5, 0, '2020-08-20T13:43:28.2952180-04:00', N'daughter – somebody’s female child', 1, 1, 0, '2020-08-20T13:43:28.2952180-04:00');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] ON;
INSERT INTO [Relationships] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (4, 0, '2020-08-20T13:43:28.2952180-04:00', N'son – somebody’s male child', 1, 1, 0, '2020-08-20T13:43:28.2952180-04:00');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] ON;
INSERT INTO [Relationships] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (2, 0, '2020-08-20T13:43:28.2952180-04:00', N'mother – somebody’s female parent', 1, 1, 0, '2020-08-20T13:43:28.2952180-04:00');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] ON;
INSERT INTO [Relationships] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (1, 0, '2020-08-20T13:43:28.2952180-04:00', N'father – somebody’s male parent', 1, 1, 0, '2020-08-20T13:43:28.2952180-04:00');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] ON;
INSERT INTO [Relationships] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (8, 0, '2020-08-20T13:43:28.2952180-04:00', N'spouse – somebody married to another person; husband or wife', 1, 1, 0, '2020-08-20T13:43:28.2952180-04:00');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Relationships]'))
    SET IDENTITY_INSERT [Relationships] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Roles]'))
    SET IDENTITY_INSERT [Roles] ON;
INSERT INTO [Roles] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (2, 0, '2020-08-20T13:43:28.2856069-04:00', N'User', 1, 1, 0, '2020-08-20T13:43:28.2856069-04:00');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Roles]'))
    SET IDENTITY_INSERT [Roles] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Roles]'))
    SET IDENTITY_INSERT [Roles] ON;
INSERT INTO [Roles] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (1, 0, '2020-08-20T13:43:28.2849644-04:00', N'Admin', 1, 1, 0, '2020-08-20T13:43:28.2856069-04:00');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Roles]'))
    SET IDENTITY_INSERT [Roles] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Roles]'))
    SET IDENTITY_INSERT [Roles] ON;
INSERT INTO [Roles] ([Id], [CreatedBy], [CreatedDate], [Description], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate])
VALUES (3, 0, '2020-08-20T13:43:28.2856069-04:00', N'Viewer', 1, 1, 0, '2020-08-20T13:43:28.2856069-04:00');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate') AND [object_id] = OBJECT_ID(N'[Roles]'))
    SET IDENTITY_INSERT [Roles] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] ON;
INSERT INTO [AccountTypes] ([Id], [CreatedBy], [CreatedDate], [Description], [GroupId], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [SortId])
VALUES (1, 0, '2020-08-20T13:43:28.2952180-04:00', N'Normal Account Type', 1, 1, 1, 0, '2020-08-20T13:43:28.2952180-04:00', 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] ON;
INSERT INTO [AccountTypes] ([Id], [CreatedBy], [CreatedDate], [Description], [GroupId], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [SortId])
VALUES (2, 0, '2020-08-20T13:43:28.2952180-04:00', N'Cash Account Type', 2, 1, 1, 0, '2020-08-20T13:43:28.2952180-04:00', 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] ON;
INSERT INTO [AccountTypes] ([Id], [CreatedBy], [CreatedDate], [Description], [GroupId], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [SortId])
VALUES (3, 0, '2020-08-20T13:43:28.2952180-04:00', N'Bank Account Type', 2, 1, 1, 0, '2020-08-20T13:43:28.2952180-04:00', 3);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] ON;
INSERT INTO [AccountTypes] ([Id], [CreatedBy], [CreatedDate], [Description], [GroupId], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [SortId])
VALUES (4, 0, '2020-08-20T13:43:28.2952180-04:00', N'Income Account Type', 2, 1, 1, 0, '2020-08-20T13:43:28.2952180-04:00', 4);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] ON;
INSERT INTO [AccountTypes] ([Id], [CreatedBy], [CreatedDate], [Description], [GroupId], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [SortId])
VALUES (5, 0, '2020-08-20T13:43:28.2952180-04:00', N'Expense Account Type', 2, 1, 1, 0, '2020-08-20T13:43:28.2952180-04:00', 5);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] ON;
INSERT INTO [AccountTypes] ([Id], [CreatedBy], [CreatedDate], [Description], [GroupId], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [SortId])
VALUES (6, 0, '2020-08-20T13:43:28.2952180-04:00', N'Payable Account Type', 2, 1, 1, 0, '2020-08-20T13:43:28.2952180-04:00', 6);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] ON;
INSERT INTO [AccountTypes] ([Id], [CreatedBy], [CreatedDate], [Description], [GroupId], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [SortId])
VALUES (7, 0, '2020-08-20T13:43:28.2952180-04:00', N'Receivable Account Type', 2, 1, 1, 0, '2020-08-20T13:43:28.2952180-04:00', 7);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] ON;
INSERT INTO [AccountTypes] ([Id], [CreatedBy], [CreatedDate], [Description], [GroupId], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [SortId])
VALUES (8, 0, '2020-08-20T13:43:28.2952180-04:00', N'Assets Account Type', 2, 1, 1, 0, '2020-08-20T13:43:28.2952180-04:00', 8);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] ON;
INSERT INTO [AccountTypes] ([Id], [CreatedBy], [CreatedDate], [Description], [GroupId], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [SortId])
VALUES (9, 0, '2020-08-20T13:43:28.2952180-04:00', N'Liabilities Account Type', 2, 1, 1, 0, '2020-08-20T13:43:28.2952180-04:00', 9);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] ON;
INSERT INTO [AccountTypes] ([Id], [CreatedBy], [CreatedDate], [Description], [GroupId], [IsActive], [IsVisible], [LastModifiedBy], [LastModifiedDate], [SortId])
VALUES (10, 0, '2020-08-20T13:43:28.2952180-04:00', N'Other Account Type', 3, 1, 1, 0, '2020-08-20T13:43:28.2952180-04:00', 10);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Description', N'GroupId', N'IsActive', N'IsVisible', N'LastModifiedBy', N'LastModifiedDate', N'SortId') AND [object_id] = OBJECT_ID(N'[AccountTypes]'))
    SET IDENTITY_INSERT [AccountTypes] OFF;

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

CREATE INDEX [IX_Transactions_AccountId] ON [Transactions] ([AccountId]);

GO

CREATE INDEX [IX_Transactions_TransactionTypeId] ON [Transactions] ([TransactionTypeId]);

GO

CREATE INDEX [IX_TransactionTypes_AccountId] ON [TransactionTypes] ([AccountId]);

GO

CREATE INDEX [IX_UserRole_RoleId] ON [UserRole] ([RoleId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200820174329_inital_create', N'2.2.6-servicing-10079');

GO

