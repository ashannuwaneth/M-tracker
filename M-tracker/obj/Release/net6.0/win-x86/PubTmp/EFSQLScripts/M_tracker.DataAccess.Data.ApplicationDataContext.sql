IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    CREATE TABLE [ExpensesTypes] (
        [Id] int NOT NULL IDENTITY,
        [Type] nvarchar(max) NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [ImageUrl] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_ExpensesTypes] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    CREATE TABLE [GroupUsers] (
        [Id] int NOT NULL IDENTITY,
        [CreatedDate] datetime2 NOT NULL,
        [IsActive] bit NOT NULL,
        [IsAdmin] bit NOT NULL,
        CONSTRAINT [PK_GroupUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(128) NOT NULL,
        [ProviderKey] nvarchar(128) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(128) NOT NULL,
        [Name] nvarchar(128) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    CREATE TABLE [GroupTypes] (
        [Id] int NOT NULL IDENTITY,
        [Type] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_GroupTypes] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_GroupTypes_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    CREATE TABLE [IncomeMethods] (
        [Id] int NOT NULL IDENTITY,
        [IncomeMethods] nvarchar(max) NOT NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_IncomeMethods] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_IncomeMethods_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    CREATE TABLE [IncomeTypes] (
        [Id] int NOT NULL IDENTITY,
        [IncomeTypes] nvarchar(max) NOT NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_IncomeTypes] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_IncomeTypes_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    CREATE TABLE [GroupExpensesManages] (
        [Id] int NOT NULL IDENTITY,
        [Description] nvarchar(max) NOT NULL,
        [Amount] float NOT NULL,
        [ExpensesDate] nvarchar(max) NOT NULL,
        [GroupTypeId] int NOT NULL,
        [ExpensesTypeId] int NOT NULL,
        [UserId] nvarchar(450) NULL,
        [IsProceed] bit NOT NULL,
        CONSTRAINT [PK_GroupExpensesManages] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_GroupExpensesManages_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]),
        CONSTRAINT [FK_GroupExpensesManages_ExpensesTypes_ExpensesTypeId] FOREIGN KEY ([ExpensesTypeId]) REFERENCES [ExpensesTypes] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_GroupExpensesManages_GroupTypes_GroupTypeId] FOREIGN KEY ([GroupTypeId]) REFERENCES [GroupTypes] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    CREATE TABLE [GroupTotals] (
        [Id] int NOT NULL IDENTITY,
        [SubmitDate] datetime2 NOT NULL,
        [Amount] float NOT NULL,
        [DueAmount] float NOT NULL,
        [TotalAmount] float NOT NULL,
        [ProcessDate] nvarchar(max) NOT NULL,
        [IsProceed] bit NOT NULL,
        [GroupTypeId] int NOT NULL,
        [UserId] nvarchar(450) NULL,
        CONSTRAINT [PK_GroupTotals] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_GroupTotals_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]),
        CONSTRAINT [FK_GroupTotals_GroupTypes_GroupTypeId] FOREIGN KEY ([GroupTypeId]) REFERENCES [GroupTypes] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    CREATE TABLE [GroupTypeUsers] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NULL,
        [GroupId] int NULL,
        [GroupTypeId] int NOT NULL,
        CONSTRAINT [PK_GroupTypeUsers] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_GroupTypeUsers_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]),
        CONSTRAINT [FK_GroupTypeUsers_GroupTypes_GroupTypeId] FOREIGN KEY ([GroupTypeId]) REFERENCES [GroupTypes] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_GroupTypeUsers_GroupUsers_GroupId] FOREIGN KEY ([GroupId]) REFERENCES [GroupUsers] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    CREATE TABLE [Incomes] (
        [Id] int NOT NULL IDENTITY,
        [Amount] float NOT NULL,
        [IncomeDate] datetime2 NOT NULL,
        [UserId] nvarchar(450) NULL,
        [IncomeTypeId] int NOT NULL,
        [IncomeMethodId] int NOT NULL,
        CONSTRAINT [PK_Incomes] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Incomes_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]),
        CONSTRAINT [FK_Incomes_IncomeMethods_IncomeMethodId] FOREIGN KEY ([IncomeMethodId]) REFERENCES [IncomeMethods] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Incomes_IncomeTypes_IncomeTypeId] FOREIGN KEY ([IncomeTypeId]) REFERENCES [IncomeTypes] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    CREATE INDEX [IX_GroupExpensesManages_ExpensesTypeId] ON [GroupExpensesManages] ([ExpensesTypeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    CREATE INDEX [IX_GroupExpensesManages_GroupTypeId] ON [GroupExpensesManages] ([GroupTypeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    CREATE INDEX [IX_GroupExpensesManages_UserId] ON [GroupExpensesManages] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    CREATE INDEX [IX_GroupTotals_GroupTypeId] ON [GroupTotals] ([GroupTypeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    CREATE INDEX [IX_GroupTotals_UserId] ON [GroupTotals] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    CREATE INDEX [IX_GroupTypes_UserId] ON [GroupTypes] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    CREATE INDEX [IX_GroupTypeUsers_GroupId] ON [GroupTypeUsers] ([GroupId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    CREATE INDEX [IX_GroupTypeUsers_GroupTypeId] ON [GroupTypeUsers] ([GroupTypeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    CREATE INDEX [IX_GroupTypeUsers_UserId] ON [GroupTypeUsers] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    CREATE INDEX [IX_IncomeMethods_UserId] ON [IncomeMethods] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    CREATE INDEX [IX_Incomes_IncomeMethodId] ON [Incomes] ([IncomeMethodId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    CREATE INDEX [IX_Incomes_IncomeTypeId] ON [Incomes] ([IncomeTypeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    CREATE INDEX [IX_Incomes_UserId] ON [Incomes] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    CREATE INDEX [IX_IncomeTypes_UserId] ON [IncomeTypes] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220508153623_Add_tables')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220508153623_Add_tables', N'6.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220511032811_add_new_col')
BEGIN
    CREATE TABLE [Expenses] (
        [Id] int NOT NULL IDENTITY,
        [Amount] float NOT NULL,
        [ExpensesDate] datetime2 NOT NULL,
        [UserId] nvarchar(450) NULL,
        [ExpensesTypeId] int NOT NULL,
        [IncomeMethodId] int NOT NULL,
        CONSTRAINT [PK_Expenses] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Expenses_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]),
        CONSTRAINT [FK_Expenses_ExpensesTypes_ExpensesTypeId] FOREIGN KEY ([ExpensesTypeId]) REFERENCES [ExpensesTypes] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Expenses_IncomeMethods_IncomeMethodId] FOREIGN KEY ([IncomeMethodId]) REFERENCES [IncomeMethods] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220511032811_add_new_col')
BEGIN
    CREATE INDEX [IX_Expenses_ExpensesTypeId] ON [Expenses] ([ExpensesTypeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220511032811_add_new_col')
BEGIN
    CREATE INDEX [IX_Expenses_IncomeMethodId] ON [Expenses] ([IncomeMethodId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220511032811_add_new_col')
BEGIN
    CREATE INDEX [IX_Expenses_UserId] ON [Expenses] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220511032811_add_new_col')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220511032811_add_new_col', N'6.0.3');
END;
GO

COMMIT;
GO

