
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/20/2016 18:44:07
-- Generated from EDMX file: D:\shit\high up here\Computer Games\Computer Games\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [computer games];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Championship1_Championship]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Championship1] DROP CONSTRAINT [FK_Championship1_Championship];
GO
IF OBJECT_ID(N'[dbo].[FK_Championship1_Games]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Championship1] DROP CONSTRAINT [FK_Championship1_Games];
GO
IF OBJECT_ID(N'[dbo].[FK_City_Country]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[City] DROP CONSTRAINT [FK_City_Country];
GO
IF OBJECT_ID(N'[dbo].[FK_Coaches_Country]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Coaches] DROP CONSTRAINT [FK_Coaches_Country];
GO
IF OBJECT_ID(N'[dbo].[FK_CoachTrain_Coaches]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CoachTrain] DROP CONSTRAINT [FK_CoachTrain_Coaches];
GO
IF OBJECT_ID(N'[dbo].[FK_CoachTrain_Teams]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CoachTrain] DROP CONSTRAINT [FK_CoachTrain_Teams];
GO
IF OBJECT_ID(N'[dbo].[FK_Competition1_Competition]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Competition1] DROP CONSTRAINT [FK_Competition1_Competition];
GO
IF OBJECT_ID(N'[dbo].[FK_Competition1_Games]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Competition1] DROP CONSTRAINT [FK_Competition1_Games];
GO
IF OBJECT_ID(N'[dbo].[FK_CompetitionsGamers_Competition1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CompetitionsGamers] DROP CONSTRAINT [FK_CompetitionsGamers_Competition1];
GO
IF OBJECT_ID(N'[dbo].[FK_CompetitionsGamers_CompetitionsGamers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CompetitionsGamers] DROP CONSTRAINT [FK_CompetitionsGamers_CompetitionsGamers];
GO
IF OBJECT_ID(N'[dbo].[FK_CompetitionsGamers_Player]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CompetitionsGamers] DROP CONSTRAINT [FK_CompetitionsGamers_Player];
GO
IF OBJECT_ID(N'[dbo].[FK_CompetitionsGamers_Prizes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CompetitionsGamers] DROP CONSTRAINT [FK_CompetitionsGamers_Prizes];
GO
IF OBJECT_ID(N'[dbo].[FK_CompetitionsTeams_Competition1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CompetitionsTeams] DROP CONSTRAINT [FK_CompetitionsTeams_Competition1];
GO
IF OBJECT_ID(N'[dbo].[FK_CompetitionsTeams_Teams]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CompetitionsTeams] DROP CONSTRAINT [FK_CompetitionsTeams_Teams];
GO
IF OBJECT_ID(N'[dbo].[FK_CompetitionsTeams_TeamsPrizes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CompetitionsTeams] DROP CONSTRAINT [FK_CompetitionsTeams_TeamsPrizes];
GO
IF OBJECT_ID(N'[dbo].[FK_GamerStuding_Player]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GamerStuding] DROP CONSTRAINT [FK_GamerStuding_Player];
GO
IF OBJECT_ID(N'[dbo].[FK_GamerStuding_Schools]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GamerStuding] DROP CONSTRAINT [FK_GamerStuding_Schools];
GO
IF OBJECT_ID(N'[dbo].[FK_Player_City]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Player] DROP CONSTRAINT [FK_Player_City];
GO
IF OBJECT_ID(N'[dbo].[FK_Results_Championship1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Results] DROP CONSTRAINT [FK_Results_Championship1];
GO
IF OBJECT_ID(N'[dbo].[FK_Results_Iron]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Results] DROP CONSTRAINT [FK_Results_Iron];
GO
IF OBJECT_ID(N'[dbo].[FK_Results_Iron1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Results] DROP CONSTRAINT [FK_Results_Iron1];
GO
IF OBJECT_ID(N'[dbo].[FK_Results_Stages]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Results] DROP CONSTRAINT [FK_Results_Stages];
GO
IF OBJECT_ID(N'[dbo].[FK_Results_Teams]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Results] DROP CONSTRAINT [FK_Results_Teams];
GO
IF OBJECT_ID(N'[dbo].[FK_Results_Teams1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Results] DROP CONSTRAINT [FK_Results_Teams1];
GO
IF OBJECT_ID(N'[dbo].[FK_Results_Teams2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Results] DROP CONSTRAINT [FK_Results_Teams2];
GO
IF OBJECT_ID(N'[dbo].[FK_Teams_City]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Teams] DROP CONSTRAINT [FK_Teams_City];
GO
IF OBJECT_ID(N'[dbo].[FK_TeamsGamers_Player]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TeamsGamers] DROP CONSTRAINT [FK_TeamsGamers_Player];
GO
IF OBJECT_ID(N'[dbo].[FK_TeamsGamers_Teams]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TeamsGamers] DROP CONSTRAINT [FK_TeamsGamers_Teams];
GO
IF OBJECT_ID(N'[dbo].[FK_TeamsPlay_Competition1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TeamsPlay] DROP CONSTRAINT [FK_TeamsPlay_Competition1];
GO
IF OBJECT_ID(N'[dbo].[FK_TeamsPlay_Teams]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TeamsPlay] DROP CONSTRAINT [FK_TeamsPlay_Teams];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Championship]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Championship];
GO
IF OBJECT_ID(N'[dbo].[Championship1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Championship1];
GO
IF OBJECT_ID(N'[dbo].[City]', 'U') IS NOT NULL
    DROP TABLE [dbo].[City];
GO
IF OBJECT_ID(N'[dbo].[Coaches]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Coaches];
GO
IF OBJECT_ID(N'[dbo].[CoachTrain]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CoachTrain];
GO
IF OBJECT_ID(N'[dbo].[Competition]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Competition];
GO
IF OBJECT_ID(N'[dbo].[Competition1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Competition1];
GO
IF OBJECT_ID(N'[dbo].[CompetitionsGamers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CompetitionsGamers];
GO
IF OBJECT_ID(N'[dbo].[CompetitionsTeams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CompetitionsTeams];
GO
IF OBJECT_ID(N'[dbo].[Country]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Country];
GO
IF OBJECT_ID(N'[dbo].[GamerStuding]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GamerStuding];
GO
IF OBJECT_ID(N'[dbo].[Games]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Games];
GO
IF OBJECT_ID(N'[dbo].[Iron]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Iron];
GO
IF OBJECT_ID(N'[dbo].[Nominations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Nominations];
GO
IF OBJECT_ID(N'[dbo].[People]', 'U') IS NOT NULL
    DROP TABLE [dbo].[People];
GO
IF OBJECT_ID(N'[dbo].[Player]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Player];
GO
IF OBJECT_ID(N'[dbo].[Prizes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Prizes];
GO
IF OBJECT_ID(N'[dbo].[Results]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Results];
GO
IF OBJECT_ID(N'[dbo].[Schools]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Schools];
GO
IF OBJECT_ID(N'[dbo].[Stages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Stages];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Teams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Teams];
GO
IF OBJECT_ID(N'[dbo].[TeamsGamers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TeamsGamers];
GO
IF OBJECT_ID(N'[dbo].[TeamsPlay]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TeamsPlay];
GO
IF OBJECT_ID(N'[dbo].[TeamsPrizes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TeamsPrizes];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Championship'
CREATE TABLE [dbo].[Championship] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [NameOfCS] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Championship1'
CREATE TABLE [dbo].[Championship1] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [YearOfStart] int  NOT NULL,
    [PrizeFond] bigint  NOT NULL,
    [GamesID] int  NOT NULL,
    [NameOfChampionshipID] int  NULL
);
GO

-- Creating table 'City'
CREATE TABLE [dbo].[City] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [CountryID] int  NOT NULL
);
GO

-- Creating table 'Coaches'
CREATE TABLE [dbo].[Coaches] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(50)  NOT NULL,
    [SecondName] nvarchar(50)  NOT NULL,
    [CountryID] int  NOT NULL
);
GO

-- Creating table 'CoachTrain'
CREATE TABLE [dbo].[CoachTrain] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CoachID] int  NOT NULL,
    [TeamID] int  NOT NULL,
    [DateBegin] datetime  NOT NULL,
    [DateEnd] datetime  NOT NULL
);
GO

-- Creating table 'Competition'
CREATE TABLE [dbo].[Competition] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Competition1'
CREATE TABLE [dbo].[Competition1] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CompetitionID] int  NOT NULL,
    [Date] datetime  NOT NULL,
    [GameID] int  NOT NULL
);
GO

-- Creating table 'CompetitionsGamers'
CREATE TABLE [dbo].[CompetitionsGamers] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [GamerID] int  NOT NULL,
    [CompetitionID] int  NOT NULL,
    [Date] datetime  NOT NULL,
    [PrizeID] int  NULL
);
GO

-- Creating table 'CompetitionsTeams'
CREATE TABLE [dbo].[CompetitionsTeams] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TeamID] int  NOT NULL,
    [CompetiionID] int  NOT NULL,
    [Date] datetime  NOT NULL,
    [TPrizeID] int  NULL
);
GO

-- Creating table 'Country'
CREATE TABLE [dbo].[Country] (
    [CountryID] int IDENTITY(1,1) NOT NULL,
    [CountryName] varchar(max)  NOT NULL
);
GO

-- Creating table 'GamerStuding'
CREATE TABLE [dbo].[GamerStuding] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [GamerID] int  NOT NULL,
    [SchoolID] int  NOT NULL,
    [StudingBegin] int  NULL,
    [StudingEnd] int  NULL,
    [StudyBegin] int  NULL,
    [StudyEnd] int  NULL
);
GO

-- Creating table 'Games'
CREATE TABLE [dbo].[Games] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [GameName] nvarchar(50)  NOT NULL,
    [ReleaseYear] int  NOT NULL,
    [Versions] nvarchar(50)  NOT NULL,
    [ComputersThatSupport] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Iron'
CREATE TABLE [dbo].[Iron] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [IronName] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Nominations'
CREATE TABLE [dbo].[Nominations] (
    [ID] int  NOT NULL,
    [NominationName] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'People'
CREATE TABLE [dbo].[People] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(50)  NOT NULL,
    [SecondName] nvarchar(50)  NOT NULL,
    [Photo] nvarchar(50)  NOT NULL,
    [City_id] int  NOT NULL
);
GO

-- Creating table 'Player'
CREATE TABLE [dbo].[Player] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Birthday] datetime  NOT NULL,
    [CityID] int  NOT NULL,
    [FirstName] nvarchar(50)  NULL,
    [SecondName] nvarchar(50)  NULL,
    [ThirdName] nvarchar(50)  NULL,
    [Photo] nvarchar(50)  NULL
);
GO

-- Creating table 'Prizes'
CREATE TABLE [dbo].[Prizes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Prize] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Results'
CREATE TABLE [dbo].[Results] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CS_id] int  NOT NULL,
    [Team_id1] int  NOT NULL,
    [Team_id2] int  NOT NULL,
    [Iron_id1] int  NOT NULL,
    [Iron_id2] int  NOT NULL,
    [StageID] int  NULL,
    [WinnerID] int  NULL
);
GO

-- Creating table 'Schools'
CREATE TABLE [dbo].[Schools] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [SchoolName] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Stages'
CREATE TABLE [dbo].[Stages] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [StageName] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Teams'
CREATE TABLE [dbo].[Teams] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TeamName] nvarchar(50)  NOT NULL,
    [CityID] int  NOT NULL,
    [President] nvarchar(50)  NULL
);
GO

-- Creating table 'TeamsGamers'
CREATE TABLE [dbo].[TeamsGamers] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [GamerID] int  NOT NULL,
    [TeamID] int  NOT NULL,
    [PlayBegin] int  NULL,
    [PlayEnd] int  NULL
);
GO

-- Creating table 'TeamsPlay'
CREATE TABLE [dbo].[TeamsPlay] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TeamID] int  NOT NULL,
    [CompetitionID] int  NOT NULL,
    [Date] datetime  NOT NULL,
    [Prize] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'TeamsPrizes'
CREATE TABLE [dbo].[TeamsPrizes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [PrizeName] nvarchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [ID] in table 'Championship'
ALTER TABLE [dbo].[Championship]
ADD CONSTRAINT [PK_Championship]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Championship1'
ALTER TABLE [dbo].[Championship1]
ADD CONSTRAINT [PK_Championship1]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'City'
ALTER TABLE [dbo].[City]
ADD CONSTRAINT [PK_City]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Coaches'
ALTER TABLE [dbo].[Coaches]
ADD CONSTRAINT [PK_Coaches]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'CoachTrain'
ALTER TABLE [dbo].[CoachTrain]
ADD CONSTRAINT [PK_CoachTrain]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Competition'
ALTER TABLE [dbo].[Competition]
ADD CONSTRAINT [PK_Competition]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Competition1'
ALTER TABLE [dbo].[Competition1]
ADD CONSTRAINT [PK_Competition1]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'CompetitionsGamers'
ALTER TABLE [dbo].[CompetitionsGamers]
ADD CONSTRAINT [PK_CompetitionsGamers]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'CompetitionsTeams'
ALTER TABLE [dbo].[CompetitionsTeams]
ADD CONSTRAINT [PK_CompetitionsTeams]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [CountryID] in table 'Country'
ALTER TABLE [dbo].[Country]
ADD CONSTRAINT [PK_Country]
    PRIMARY KEY CLUSTERED ([CountryID] ASC);
GO

-- Creating primary key on [ID] in table 'GamerStuding'
ALTER TABLE [dbo].[GamerStuding]
ADD CONSTRAINT [PK_GamerStuding]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Games'
ALTER TABLE [dbo].[Games]
ADD CONSTRAINT [PK_Games]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Iron'
ALTER TABLE [dbo].[Iron]
ADD CONSTRAINT [PK_Iron]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Nominations'
ALTER TABLE [dbo].[Nominations]
ADD CONSTRAINT [PK_Nominations]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'People'
ALTER TABLE [dbo].[People]
ADD CONSTRAINT [PK_People]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Player'
ALTER TABLE [dbo].[Player]
ADD CONSTRAINT [PK_Player]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Prizes'
ALTER TABLE [dbo].[Prizes]
ADD CONSTRAINT [PK_Prizes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Results'
ALTER TABLE [dbo].[Results]
ADD CONSTRAINT [PK_Results]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Schools'
ALTER TABLE [dbo].[Schools]
ADD CONSTRAINT [PK_Schools]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Stages'
ALTER TABLE [dbo].[Stages]
ADD CONSTRAINT [PK_Stages]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Teams'
ALTER TABLE [dbo].[Teams]
ADD CONSTRAINT [PK_Teams]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TeamsGamers'
ALTER TABLE [dbo].[TeamsGamers]
ADD CONSTRAINT [PK_TeamsGamers]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TeamsPlay'
ALTER TABLE [dbo].[TeamsPlay]
ADD CONSTRAINT [PK_TeamsPlay]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TeamsPrizes'
ALTER TABLE [dbo].[TeamsPrizes]
ADD CONSTRAINT [PK_TeamsPrizes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [NameOfChampionshipID] in table 'Championship1'
ALTER TABLE [dbo].[Championship1]
ADD CONSTRAINT [FK_Championship1_Championship]
    FOREIGN KEY ([NameOfChampionshipID])
    REFERENCES [dbo].[Championship]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Championship1_Championship'
CREATE INDEX [IX_FK_Championship1_Championship]
ON [dbo].[Championship1]
    ([NameOfChampionshipID]);
GO

-- Creating foreign key on [GamesID] in table 'Championship1'
ALTER TABLE [dbo].[Championship1]
ADD CONSTRAINT [FK_Championship1_Games]
    FOREIGN KEY ([GamesID])
    REFERENCES [dbo].[Games]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Championship1_Games'
CREATE INDEX [IX_FK_Championship1_Games]
ON [dbo].[Championship1]
    ([GamesID]);
GO

-- Creating foreign key on [CS_id] in table 'Results'
ALTER TABLE [dbo].[Results]
ADD CONSTRAINT [FK_Results_Championship1]
    FOREIGN KEY ([CS_id])
    REFERENCES [dbo].[Championship1]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Results_Championship1'
CREATE INDEX [IX_FK_Results_Championship1]
ON [dbo].[Results]
    ([CS_id]);
GO

-- Creating foreign key on [CountryID] in table 'City'
ALTER TABLE [dbo].[City]
ADD CONSTRAINT [FK_City_Country]
    FOREIGN KEY ([CountryID])
    REFERENCES [dbo].[Country]
        ([CountryID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_City_Country'
CREATE INDEX [IX_FK_City_Country]
ON [dbo].[City]
    ([CountryID]);
GO

-- Creating foreign key on [CityID] in table 'Player'
ALTER TABLE [dbo].[Player]
ADD CONSTRAINT [FK_Player_City]
    FOREIGN KEY ([CityID])
    REFERENCES [dbo].[City]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Player_City'
CREATE INDEX [IX_FK_Player_City]
ON [dbo].[Player]
    ([CityID]);
GO

-- Creating foreign key on [CityID] in table 'Teams'
ALTER TABLE [dbo].[Teams]
ADD CONSTRAINT [FK_Teams_City]
    FOREIGN KEY ([CityID])
    REFERENCES [dbo].[City]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Teams_City'
CREATE INDEX [IX_FK_Teams_City]
ON [dbo].[Teams]
    ([CityID]);
GO

-- Creating foreign key on [CountryID] in table 'Coaches'
ALTER TABLE [dbo].[Coaches]
ADD CONSTRAINT [FK_Coaches_Country]
    FOREIGN KEY ([CountryID])
    REFERENCES [dbo].[Country]
        ([CountryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Coaches_Country'
CREATE INDEX [IX_FK_Coaches_Country]
ON [dbo].[Coaches]
    ([CountryID]);
GO

-- Creating foreign key on [CoachID] in table 'CoachTrain'
ALTER TABLE [dbo].[CoachTrain]
ADD CONSTRAINT [FK_CoachTrain_Coaches]
    FOREIGN KEY ([CoachID])
    REFERENCES [dbo].[Coaches]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CoachTrain_Coaches'
CREATE INDEX [IX_FK_CoachTrain_Coaches]
ON [dbo].[CoachTrain]
    ([CoachID]);
GO

-- Creating foreign key on [TeamID] in table 'CoachTrain'
ALTER TABLE [dbo].[CoachTrain]
ADD CONSTRAINT [FK_CoachTrain_Teams]
    FOREIGN KEY ([TeamID])
    REFERENCES [dbo].[Teams]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CoachTrain_Teams'
CREATE INDEX [IX_FK_CoachTrain_Teams]
ON [dbo].[CoachTrain]
    ([TeamID]);
GO

-- Creating foreign key on [CompetitionID] in table 'Competition1'
ALTER TABLE [dbo].[Competition1]
ADD CONSTRAINT [FK_Competition1_Competition]
    FOREIGN KEY ([CompetitionID])
    REFERENCES [dbo].[Competition]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Competition1_Competition'
CREATE INDEX [IX_FK_Competition1_Competition]
ON [dbo].[Competition1]
    ([CompetitionID]);
GO

-- Creating foreign key on [GameID] in table 'Competition1'
ALTER TABLE [dbo].[Competition1]
ADD CONSTRAINT [FK_Competition1_Games]
    FOREIGN KEY ([GameID])
    REFERENCES [dbo].[Games]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Competition1_Games'
CREATE INDEX [IX_FK_Competition1_Games]
ON [dbo].[Competition1]
    ([GameID]);
GO

-- Creating foreign key on [CompetitionID] in table 'CompetitionsGamers'
ALTER TABLE [dbo].[CompetitionsGamers]
ADD CONSTRAINT [FK_CompetitionsGamers_Competition1]
    FOREIGN KEY ([CompetitionID])
    REFERENCES [dbo].[Competition1]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompetitionsGamers_Competition1'
CREATE INDEX [IX_FK_CompetitionsGamers_Competition1]
ON [dbo].[CompetitionsGamers]
    ([CompetitionID]);
GO

-- Creating foreign key on [CompetiionID] in table 'CompetitionsTeams'
ALTER TABLE [dbo].[CompetitionsTeams]
ADD CONSTRAINT [FK_CompetitionsTeams_Competition1]
    FOREIGN KEY ([CompetiionID])
    REFERENCES [dbo].[Competition1]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompetitionsTeams_Competition1'
CREATE INDEX [IX_FK_CompetitionsTeams_Competition1]
ON [dbo].[CompetitionsTeams]
    ([CompetiionID]);
GO

-- Creating foreign key on [CompetitionID] in table 'TeamsPlay'
ALTER TABLE [dbo].[TeamsPlay]
ADD CONSTRAINT [FK_TeamsPlay_Competition1]
    FOREIGN KEY ([CompetitionID])
    REFERENCES [dbo].[Competition1]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamsPlay_Competition1'
CREATE INDEX [IX_FK_TeamsPlay_Competition1]
ON [dbo].[TeamsPlay]
    ([CompetitionID]);
GO

-- Creating foreign key on [ID] in table 'CompetitionsGamers'
ALTER TABLE [dbo].[CompetitionsGamers]
ADD CONSTRAINT [FK_CompetitionsGamers_CompetitionsGamers]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[CompetitionsGamers]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [GamerID] in table 'CompetitionsGamers'
ALTER TABLE [dbo].[CompetitionsGamers]
ADD CONSTRAINT [FK_CompetitionsGamers_Player]
    FOREIGN KEY ([GamerID])
    REFERENCES [dbo].[Player]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompetitionsGamers_Player'
CREATE INDEX [IX_FK_CompetitionsGamers_Player]
ON [dbo].[CompetitionsGamers]
    ([GamerID]);
GO

-- Creating foreign key on [PrizeID] in table 'CompetitionsGamers'
ALTER TABLE [dbo].[CompetitionsGamers]
ADD CONSTRAINT [FK_CompetitionsGamers_Prizes]
    FOREIGN KEY ([PrizeID])
    REFERENCES [dbo].[Prizes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompetitionsGamers_Prizes'
CREATE INDEX [IX_FK_CompetitionsGamers_Prizes]
ON [dbo].[CompetitionsGamers]
    ([PrizeID]);
GO

-- Creating foreign key on [TeamID] in table 'CompetitionsTeams'
ALTER TABLE [dbo].[CompetitionsTeams]
ADD CONSTRAINT [FK_CompetitionsTeams_Teams]
    FOREIGN KEY ([TeamID])
    REFERENCES [dbo].[Teams]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompetitionsTeams_Teams'
CREATE INDEX [IX_FK_CompetitionsTeams_Teams]
ON [dbo].[CompetitionsTeams]
    ([TeamID]);
GO

-- Creating foreign key on [TPrizeID] in table 'CompetitionsTeams'
ALTER TABLE [dbo].[CompetitionsTeams]
ADD CONSTRAINT [FK_CompetitionsTeams_TeamsPrizes]
    FOREIGN KEY ([TPrizeID])
    REFERENCES [dbo].[TeamsPrizes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompetitionsTeams_TeamsPrizes'
CREATE INDEX [IX_FK_CompetitionsTeams_TeamsPrizes]
ON [dbo].[CompetitionsTeams]
    ([TPrizeID]);
GO

-- Creating foreign key on [GamerID] in table 'GamerStuding'
ALTER TABLE [dbo].[GamerStuding]
ADD CONSTRAINT [FK_GamerStuding_Player]
    FOREIGN KEY ([GamerID])
    REFERENCES [dbo].[Player]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GamerStuding_Player'
CREATE INDEX [IX_FK_GamerStuding_Player]
ON [dbo].[GamerStuding]
    ([GamerID]);
GO

-- Creating foreign key on [SchoolID] in table 'GamerStuding'
ALTER TABLE [dbo].[GamerStuding]
ADD CONSTRAINT [FK_GamerStuding_Schools]
    FOREIGN KEY ([SchoolID])
    REFERENCES [dbo].[Schools]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GamerStuding_Schools'
CREATE INDEX [IX_FK_GamerStuding_Schools]
ON [dbo].[GamerStuding]
    ([SchoolID]);
GO

-- Creating foreign key on [Iron_id1] in table 'Results'
ALTER TABLE [dbo].[Results]
ADD CONSTRAINT [FK_Results_Iron]
    FOREIGN KEY ([Iron_id1])
    REFERENCES [dbo].[Iron]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Results_Iron'
CREATE INDEX [IX_FK_Results_Iron]
ON [dbo].[Results]
    ([Iron_id1]);
GO

-- Creating foreign key on [Iron_id2] in table 'Results'
ALTER TABLE [dbo].[Results]
ADD CONSTRAINT [FK_Results_Iron1]
    FOREIGN KEY ([Iron_id2])
    REFERENCES [dbo].[Iron]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Results_Iron1'
CREATE INDEX [IX_FK_Results_Iron1]
ON [dbo].[Results]
    ([Iron_id2]);
GO

-- Creating foreign key on [GamerID] in table 'TeamsGamers'
ALTER TABLE [dbo].[TeamsGamers]
ADD CONSTRAINT [FK_TeamsGamers_Player]
    FOREIGN KEY ([GamerID])
    REFERENCES [dbo].[Player]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamsGamers_Player'
CREATE INDEX [IX_FK_TeamsGamers_Player]
ON [dbo].[TeamsGamers]
    ([GamerID]);
GO

-- Creating foreign key on [StageID] in table 'Results'
ALTER TABLE [dbo].[Results]
ADD CONSTRAINT [FK_Results_Stages]
    FOREIGN KEY ([StageID])
    REFERENCES [dbo].[Stages]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Results_Stages'
CREATE INDEX [IX_FK_Results_Stages]
ON [dbo].[Results]
    ([StageID]);
GO

-- Creating foreign key on [Team_id1] in table 'Results'
ALTER TABLE [dbo].[Results]
ADD CONSTRAINT [FK_Results_Teams]
    FOREIGN KEY ([Team_id1])
    REFERENCES [dbo].[Teams]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Results_Teams'
CREATE INDEX [IX_FK_Results_Teams]
ON [dbo].[Results]
    ([Team_id1]);
GO

-- Creating foreign key on [Team_id2] in table 'Results'
ALTER TABLE [dbo].[Results]
ADD CONSTRAINT [FK_Results_Teams1]
    FOREIGN KEY ([Team_id2])
    REFERENCES [dbo].[Teams]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Results_Teams1'
CREATE INDEX [IX_FK_Results_Teams1]
ON [dbo].[Results]
    ([Team_id2]);
GO

-- Creating foreign key on [WinnerID] in table 'Results'
ALTER TABLE [dbo].[Results]
ADD CONSTRAINT [FK_Results_Teams2]
    FOREIGN KEY ([WinnerID])
    REFERENCES [dbo].[Teams]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Results_Teams2'
CREATE INDEX [IX_FK_Results_Teams2]
ON [dbo].[Results]
    ([WinnerID]);
GO

-- Creating foreign key on [TeamID] in table 'TeamsGamers'
ALTER TABLE [dbo].[TeamsGamers]
ADD CONSTRAINT [FK_TeamsGamers_Teams]
    FOREIGN KEY ([TeamID])
    REFERENCES [dbo].[Teams]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamsGamers_Teams'
CREATE INDEX [IX_FK_TeamsGamers_Teams]
ON [dbo].[TeamsGamers]
    ([TeamID]);
GO

-- Creating foreign key on [TeamID] in table 'TeamsPlay'
ALTER TABLE [dbo].[TeamsPlay]
ADD CONSTRAINT [FK_TeamsPlay_Teams]
    FOREIGN KEY ([TeamID])
    REFERENCES [dbo].[Teams]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamsPlay_Teams'
CREATE INDEX [IX_FK_TeamsPlay_Teams]
ON [dbo].[TeamsPlay]
    ([TeamID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------