CREATE TABLE [Owners] (
    [OwnerID] int NOT NULL IDENTITY,
    [OwnerName] nvarchar(max) NULL,
    [NetWorth] int NOT NULL,
    CONSTRAINT [PK_Owners] PRIMARY KEY ([OwnerID])
);
GO


CREATE TABLE [Players] (
    [PlayerID] int NOT NULL IDENTITY,
    [PlayerName] nvarchar(max) NULL,
    [AgentID] int NULL,
    [Age] int NOT NULL,
    [Salary] int NOT NULL,
    [ContractLength] int NOT NULL,
    [OwnerID] int NULL,
    [DateOfBirth] datetime2 NOT NULL,
    CONSTRAINT [PK_Players] PRIMARY KEY ([PlayerID]),
    CONSTRAINT [FK_Players_Owners_OwnerID] FOREIGN KEY ([OwnerID]) REFERENCES [Owners] ([OwnerID]) ON DELETE NO ACTION
);
GO


CREATE TABLE [Scouts] (
    [ScoutID] int NOT NULL IDENTITY,
    [ScoutName] nvarchar(max) NULL,
    [PlayerID] int NOT NULL,
    [CountryBased] nvarchar(max) NULL,
    [StaffAmount] int NULL,
    CONSTRAINT [PK_Scouts] PRIMARY KEY ([ScoutID]),
    CONSTRAINT [FK_Scouts_Players_PlayerID] FOREIGN KEY ([PlayerID]) REFERENCES [Players] ([PlayerID]) ON DELETE CASCADE
);
GO


CREATE TABLE [HeadStaffs] (
    [HeadStaffID] int NOT NULL IDENTITY,
    [OwnerID] int NULL,
    [StaffName] nvarchar(max) NULL,
    [StaffRole] nvarchar(max) NULL,
    [ScoutID] int NULL,
    CONSTRAINT [PK_HeadStaffs] PRIMARY KEY ([HeadStaffID]),
    CONSTRAINT [FK_HeadStaffs_Owners_OwnerID] FOREIGN KEY ([OwnerID]) REFERENCES [Owners] ([OwnerID]) ON DELETE NO ACTION,
    CONSTRAINT [FK_HeadStaffs_Scouts_ScoutID] FOREIGN KEY ([ScoutID]) REFERENCES [Scouts] ([ScoutID]) ON DELETE NO ACTION
);
GO


CREATE TABLE [Agents] (
    [AgentID] int NOT NULL IDENTITY,
    [AgentName] nvarchar(25) NOT NULL,
    [HeadStaffID] int NULL,
    [AgentFee] int NULL,
    [PercentOwned] int NULL,
    CONSTRAINT [PK_Agents] PRIMARY KEY ([AgentID]),
    CONSTRAINT [FK_Agents_HeadStaffs_HeadStaffID] FOREIGN KEY ([HeadStaffID]) REFERENCES [HeadStaffs] ([HeadStaffID]) ON DELETE NO ACTION
);
GO


IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'AgentID', N'AgentFee', N'AgentName', N'HeadStaffID', N'PercentOwned') AND [object_id] = OBJECT_ID(N'[Agents]'))
    SET IDENTITY_INSERT [Agents] ON;
INSERT INTO [Agents] ([AgentID], [AgentFee], [AgentName], [HeadStaffID], [PercentOwned])
VALUES (1, 30, N'Mino Railo', NULL, 5);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'AgentID', N'AgentFee', N'AgentName', N'HeadStaffID', N'PercentOwned') AND [object_id] = OBJECT_ID(N'[Agents]'))
    SET IDENTITY_INSERT [Agents] OFF;
GO


IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'AgentID', N'AgentFee', N'AgentName', N'HeadStaffID', N'PercentOwned') AND [object_id] = OBJECT_ID(N'[Agents]'))
    SET IDENTITY_INSERT [Agents] ON;
INSERT INTO [Agents] ([AgentID], [AgentFee], [AgentName], [HeadStaffID], [PercentOwned])
VALUES (2, 25, N'Mendes', NULL, 10);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'AgentID', N'AgentFee', N'AgentName', N'HeadStaffID', N'PercentOwned') AND [object_id] = OBJECT_ID(N'[Agents]'))
    SET IDENTITY_INSERT [Agents] OFF;
GO


IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PlayerID', N'Age', N'AgentID', N'ContractLength', N'DateOfBirth', N'OwnerID', N'PlayerName', N'Salary') AND [object_id] = OBJECT_ID(N'[Players]'))
    SET IDENTITY_INSERT [Players] ON;
INSERT INTO [Players] ([PlayerID], [Age], [AgentID], [ContractLength], [DateOfBirth], [OwnerID], [PlayerName], [Salary])
VALUES (2, 26, 1, 3, '0001-01-01T00:00:00.0000000', NULL, N'Pogba', 300000);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PlayerID', N'Age', N'AgentID', N'ContractLength', N'DateOfBirth', N'OwnerID', N'PlayerName', N'Salary') AND [object_id] = OBJECT_ID(N'[Players]'))
    SET IDENTITY_INSERT [Players] OFF;
GO


IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PlayerID', N'Age', N'AgentID', N'ContractLength', N'DateOfBirth', N'OwnerID', N'PlayerName', N'Salary') AND [object_id] = OBJECT_ID(N'[Players]'))
    SET IDENTITY_INSERT [Players] ON;
INSERT INTO [Players] ([PlayerID], [Age], [AgentID], [ContractLength], [DateOfBirth], [OwnerID], [PlayerName], [Salary])
VALUES (1, 25, 2, 5, '0001-01-01T00:00:00.0000000', NULL, N'Neymar', 450000);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PlayerID', N'Age', N'AgentID', N'ContractLength', N'DateOfBirth', N'OwnerID', N'PlayerName', N'Salary') AND [object_id] = OBJECT_ID(N'[Players]'))
    SET IDENTITY_INSERT [Players] OFF;
GO


CREATE INDEX [IX_Agents_HeadStaffID] ON [Agents] ([HeadStaffID]);
GO


CREATE INDEX [IX_HeadStaffs_OwnerID] ON [HeadStaffs] ([OwnerID]);
GO


CREATE INDEX [IX_HeadStaffs_ScoutID] ON [HeadStaffs] ([ScoutID]);
GO


CREATE INDEX [IX_Players_AgentID] ON [Players] ([AgentID]);
GO


CREATE INDEX [IX_Players_OwnerID] ON [Players] ([OwnerID]);
GO


CREATE INDEX [IX_Scouts_PlayerID] ON [Scouts] ([PlayerID]);
GO


ALTER TABLE [Players] ADD CONSTRAINT [FK_Players_Agents_AgentID] FOREIGN KEY ([AgentID]) REFERENCES [Agents] ([AgentID]) ON DELETE NO ACTION;
GO


