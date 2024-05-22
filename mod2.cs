������ 2 
���� ����������� ER-��������� ��� ���� ������ ����� ������ �� ������ ������������:

� ������� ������� Visual Studio �� ������� ��� ������ SQL Server ���� ������� ���� ������ User_009:

� ������� ���������� SQL-������� ���� ������� ������� �Role�(����):
CREATE TABLE[dbo].[Role] (
    [Id]       INT IDENTITY(1, 1) NOT NULL,
    [RoleName] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
� ������� ���������� SQL-������� ���� ������� ������� �User�(������������):
CREATE TABLE[dbo].[User] (
    [Id]       INT IDENTITY(1, 1) NOT NULL,
    [Name]     NVARCHAR (70) NOT NULL,
    [Login]    NVARCHAR (70) NOT NULL,
    [Password] NVARCHAR (70) NOT NULL,
    [RoleId]   INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT[FK_User_ToRole] FOREIGN KEY([RoleId]) REFERENCES[dbo].[Role]([Id])
);
� ������� ���������� SQL-������� ���� ������� ������� �Defect�(��� �������������):
CREATE TABLE[dbo].[Defect] (
    [Id]         INT IDENTITY(1, 1) NOT NULL,
    [DefectName] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
� ������� ���������� SQL-������� ���� ������� ������� �Device�(������������):
CREATE TABLE[dbo].[Device] (
    [Id]         INT IDENTITY(1, 1) NOT NULL,
    [DeviceName] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
� ������� ���������� SQL-������� ���� ������� ������� �Invoice�(������):
CREATE TABLE[dbo].[Invoice] (
    [Id]                INT IDENTITY(1, 1) NOT NULL,
    [ClintName]         NVARCHAR (MAX) NOT NULL,
    [ClientEmail]       NVARCHAR (MAX) NOT NULL,
    [DeviceId]          INT            NOT NULL,
    [SerialNumber]      NVARCHAR (MAX) NOT NULL,
    [DefectId]          INT            NOT NULL,
    [DefectDescription] NVARCHAR (MAX) NOT NULL,
    [ExecutorId]        INT            NULL,
    [ExecutorComment]   INT            NULL,
    [CreationDate]      DATE           NOT NULL,
    [FinishDate]        DATE           NOT NULL,
    [Status]            NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT[FK_Invoice_ToDevice] FOREIGN KEY(DeviceId) REFERENCES[Device](Id), 
    CONSTRAINT[FK_Invoice_ToDefect] FOREIGN KEY(DefectId) REFERENCES[Defect](Id), 
    CONSTRAINT[FK_Invoice_ToUser] FOREIGN KEY(ExecutorId) REFERENCES[User](Id)
);
���� ������ ���� ��������� �������:


� ����� �������� �� ����� ���:



��� ��������� ������� ����������� �������������: 
����� ������������� ������� ��������� ������������� � ��������� ������ � ��� � ���� ������.
���� ������� ������ ������������� �������������� � �������������:



���� ����������� ������� �� ������ �  �������:
������� �� ��������� ID ������ ������������, ��������, ������ � �����������:
SELECT Id FROM Device
SELECT Id FROM Defect
SELECT Id FROM [User] WHERE RoleId = 2
SELECT Id FROM Invoice

������ �� �������������� ������:
UPDATE Invoice SET ExecutorId = {executorId}, DefectDescription = '{defectDescription}' Where Id = { invoiceId }

������ �� ��������� ������ ���� ������:
Select* FROM Invoice

������ �� ���������� ������:
INSERT INTO Invoice (ClientName, ClientEmail, DeviceId, SerialNumber, DefectId, DefectDescription, CreationDate, FinishDate, Status) VALUES (@ClientName, @ClientEmail, @DeviceId, @SerialNumber, @DefectId, @DefectDescription, @CreationDate, @FinishDate, '� ��������')
������ �� �������� ������ � ������:
UPDATE Invoice SET Status = '� ������'  Where Id = {invoiceId}

������ �� ���������� ������:
UPDATE Invoice SET Status = '���������', ExecutorComment = '{executorComment}' Where Id = {invoiceId}

