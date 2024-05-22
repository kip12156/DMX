ПРОГРАММНОЕ ОБЕСПЕЧЕНИЕ «ТЕХНОСЕРВИС — УЧЕТ ЗАЯВОК НА РЕМОНТ ОБОРУДОВАНИЯ»

РУКОВОДСТВО СИСТЕМНОГО ПРОГРАММИСТА



























Аннотация
Данное программное обеспечение предназначено для учета заявок на ремонт оборудования.

Инструкция по настройке
Необходимо установить SQL Server и добавить в нем пользователя User_010, от его имени необходимо создать базу данных User_010, и создат ьв сней следующие таблицы при помощи запросов:
CREATE TABLE [dbo].[Role] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [RoleName] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[User] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (70) NOT NULL,
    [Login]    NVARCHAR (70) NOT NULL,
    [Password] NVARCHAR (70) NOT NULL,
    [RoleId]   INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_User_ToRole] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([Id])
);

CREATE TABLE [dbo].[Defect] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [DefectName] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Device] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [DeviceName] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Invoice] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
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
    CONSTRAINT [FK_Invoice_ToDevice] FOREIGN KEY (DeviceId) REFERENCES [Device](Id), 
    CONSTRAINT [FK_Invoice_ToDefect] FOREIGN KEY (DefectId) REFERENCES [Defect](Id), 
    CONSTRAINT [FK_Invoice_ToUser] FOREIGN KEY (ExecutorId) REFERENCES [User](Id)
);

Инструкция по запуску
необходимо запустить файла «Учет заявок на ремонт оборудования.exe”, расположенный в папке «Учет заявок на ремонт оборудования».
Для авторизации с ролью пользоватлея необходимо ввести логин «admin” и  пароль «admin»
Для авторизации с ролью исполнителя необходимо ввести логин «executor1” и  пароль «executor1»
Для авторизации с ролью менеджера необходимо ввести логин «manager” и  пароль «manager»

