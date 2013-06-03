CREATE TABLE WeddingProject
(
Id UNIQUEIDENTIFIER,
Name nvarchar(128) NOT NULL,
PlannedDate DateTime,
Venue nvarchar(512),
PRIMARY KEY (Id)
);

CREATE TABLE Toast
(
Id UNIQUEIDENTIFIER,
WeddingProjectId UNIQUEIDENTIFIER NOT NULL,
IndexNumber int NOT NULL,
Description nvarchar(1024),
PRIMARY KEY (Id),
foreign key ( WeddingProjectId ) references WeddingProject (Id)
);

CREATE TABLE VisitorBelongSides
(
Id INT,
Name nvarchar(10) NOT NULL,
PRIMARY KEY (Id)
);

INSERT into VisitorBelongSides (Id, Name) 
SELECT 1, 'Groom'
UNION ALL
SELECT 2, 'Bride'
;

CREATE TABLE VisitorRoles
(
Id INT,
Name nvarchar(10) NOT NULL,
PRIMARY KEY (Id)
);

INSERT into VisitorRoles (Id, Name) 
SELECT 1, 'Groom'
UNION ALL
SELECT 2, 'Bride'
UNION ALL
SELECT 3, 'Witness'
UNION ALL
SELECT 4, 'Parent'
;

CREATE TABLE Visitor
(
Id UNIQUEIDENTIFIER,
WeddingProjectId UNIQUEIDENTIFIER NOT NULL,
Name nvarchar (128) NOT NULL,
FullName nvarchar(128),
VisitorBelongSideId INT NULL,
VisitorRoleId INT NULL,
Description nvarchar(1024),
PhoneNumber nvarchar (32) NULL,
Email nvarchar(64) NULL,
PRIMARY KEY (Id),
FOREIGN KEY ( VisitorBelongSideId ) references VisitorBelongSides (Id),
FOREIGN KEY ( VisitorRoleId ) references VisitorRoles (Id),
FOREIGN KEY ( WeddingProjectId ) references WeddingProject (Id)
);

CREATE TABLE ToastToVisitor
(
ToastId UNIQUEIDENTIFIER NOT NULL,
VisitorId UNIQUEIDENTIFIER NOT NULL,
PRIMARY KEY (ToastId, VisitorId),
foreign key ( ToastId ) references Toast (Id),
foreign key ( VisitorId ) references Visitor (Id)
);

CREATE TABLE CounterpartyRoles
(
Id INT,
Name nvarchar(20) NOT NULL,
PRIMARY KEY (Id)
);

INSERT into CounterpartyRoles (Id, Name) 
SELECT 1, 'Photo'
UNION ALL
SELECT 2, 'Video'
UNION ALL
SELECT 3, 'Floristics'
UNION ALL
SELECT 4, 'MasterOfCeremonies'
UNION ALL
SELECT 5, 'Music'
UNION ALL
SELECT 6, 'Visagist'
UNION ALL
SELECT 7, 'Restaurant'
UNION ALL
SELECT 8, 'Transport'
UNION ALL
SELECT 9, 'Decorator'
;

CREATE TABLE Counterparty
(
Id UNIQUEIDENTIFIER,
CounterpartyRoleId UNIQUEIDENTIFIER NULL,
CounterpartyRoleDescription nvarchar(128) NULL,
Name nvarchar(256) NOT NULL,
ContactPerson nvarchar(256) NULL,
PhoneNumber nvarchar (32) NULL,
Email nvarchar(64) NULL,
PRIMARY KEY (Id)
);

CREATE TABLE CounterpartyToWeddingProject
(
CounterpartyId UNIQUEIDENTIFIER NOT NULL,
WeddingProjectId UNIQUEIDENTIFIER NOT NULL,
Summary nvarchar(2048) NULL,
Cost money NULL,
AlreadyPayed money NULL,
PRIMARY KEY (CounterpartyId, WeddingProjectId),
foreign key ( CounterpartyId ) references Counterparty (Id),
foreign key ( WeddingProjectId ) references WeddingProject (Id)
);
