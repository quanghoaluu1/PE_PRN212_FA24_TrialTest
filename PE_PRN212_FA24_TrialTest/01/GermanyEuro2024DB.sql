USE master
GO

CREATE DATABASE GermanyEuro2024DB
GO

USE GermanyEuro2024DB
GO

CREATE TABLE UEFAAccount (
  AccountID int primary key,
  AccountPassword nvarchar(60) not null,
  AccountEmail nvarchar(80) unique, 
  AccountDescription nvarchar(240) not null,
  Role int
)
GO

INSERT INTO UEFAAccount VALUES(551 ,N'@5','admin@uefa.com', N'System Admin', 1);
INSERT INTO UEFAAccount VALUES(552 ,N'@5','staff@uefa.com', N'Staff', 2);
INSERT INTO UEFAAccount VALUES(553 ,N'@5','manager@uefa.com', N'Project Manager', 3);
INSERT INTO UEFAAccount VALUES(554 ,N'@5','member1@uefa.com', N'Member', 4);
GO


CREATE TABLE FootballTeam (
  FootballTeamID nvarchar(30) primary key,
  TeamTitle nvarchar(100) not null,
  Country nvarchar(50) not null, 
  ManagerName nvarchar(100) not null
)
GO

INSERT INTO FootballTeam VALUES(N'TE001123', N'Germany National Football Team', N'Germany', N'Julian Nagelsmann')
GO
INSERT INTO FootballTeam VALUES(N'TE001124', N'Scotland National Football Team', N'Scotland', N'Steve Clarke')
GO
INSERT INTO FootballTeam VALUES(N'TE001125', N'Hungary National Football Team', N'Hungary', N'Marco Rossi ')
GO
INSERT INTO FootballTeam VALUES(N'TE001126', N'Switzerland National Football Team', N'Switzerland', N'Murat Yakin')
GO
INSERT INTO FootballTeam VALUES(N'TE001127', N'Italy National Football Team', N'Italy', N'Luciano Spalletti')
GO
INSERT INTO FootballTeam VALUES(N'TE001128', N'England National Football Team', N'England', N'Gareth Southgate')
GO


CREATE TABLE FootballPlayer (
  PlayerID nvarchar(30) PRIMARY KEY,
  PlayerName nvarchar(100) not null,
  Achievements nvarchar(250) not null, 
  Birthday Datetime,
  OriginCountry nvarchar(100) not null,
  Award nvarchar(250) not null, 
  FootballTeamID nvarchar(30) FOREIGN KEY references FootballTeam(FootballTeamID) on delete cascade on update cascade,
)
GO

INSERT INTO FootballPlayer VALUES(N'PL00441', N'Manuel Neuer', N'Highly accomplished goalkeeper, FIFA World Cup winner in 2014', CAST(N'1986-3-27' AS DateTime), N'Germany', N'N/A', N'TE001123')
GO
INSERT INTO FootballPlayer VALUES(N'PL00442', N'Marc-Andre ter Stegen', N'DFB-Pokal, UEFA Champions League, Spanish La Liga titles with FC Barcelona', CAST(N'1992-4-30' AS DateTime), N'Germany', N'N/A', N'TE001123')
GO
INSERT INTO FootballPlayer VALUES(N'PL00443', N'Joshua Kimmich', N'Multiple Bundesliga titles with Bayern Munich, DFB-Pokal, UEFA Champions League', CAST(N'1995-2-8' AS DateTime), N'Germany', N'N/A', N'TE001123')
GO
INSERT INTO FootballPlayer VALUES(N'PL00444', N'Toni Kroos', N'FIFA World Cup, UEFA European Championship, UEFA Champions League, Spanish La Liga titles', CAST(N'1990-1-4' AS DateTime), N'Germany', N'N/A', N'TE001123')
GO
INSERT INTO FootballPlayer VALUES(N'PL00445', N'Kai Havertz', N'UEFA Europa League winner with Chelsea, FIFA Confederations Cup winner with Germany', CAST(N'1999-6-11' AS DateTime), N'Germany', N'N/A', N'TE001123')
GO
INSERT INTO FootballPlayer VALUES(N'PL00446', N'Angus Gunn', N'Notable performances in club matches', CAST(N'1994-9-27' AS DateTime), N'Scotland', N'N/A', N'TE001124')
GO
INSERT INTO FootballPlayer VALUES(N'PL00447', N'Andy Robertson', N'Professional career at Liverpool', CAST(N'2000-3-7' AS DateTime), N'Scotland', N'N/A', N'TE001124')
GO
INSERT INTO FootballPlayer VALUES(N'PL00448', N'Kieran Tierney', N'Key player for Scotland and Real Sociedad', CAST(N'1988-10-25' AS DateTime), N'Scotland', N'N/A', N'TE001124')
GO
INSERT INTO FootballPlayer VALUES(N'PL00449', N'Billy Gilmour', N'Rising talent with Brighton.', CAST(N'2002-10-5' AS DateTime), N'Scotland', N'N/A', N'TE001124')
GO



