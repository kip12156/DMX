Модуль 2 
Была разработана ER-диаграмма для базы данных учета заявок на ремонт оборудования:

С помощью средств Visual Studio на сервере баз данных SQL Server была создана база данных User_009:

С помощью следующего SQL-запроса была создана таблица «Role»(роль):
CREATE TABLE[dbo].[Role] (
    [Id]       INT IDENTITY(1, 1) NOT NULL,
    [RoleName] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
С помощью следующего SQL-запроса была создана таблица «User»(пользователь):
CREATE TABLE[dbo].[User] (
    [Id]       INT IDENTITY(1, 1) NOT NULL,
    [Name]     NVARCHAR (70) NOT NULL,
    [Login]    NVARCHAR (70) NOT NULL,
    [Password] NVARCHAR (70) NOT NULL,
    [RoleId]   INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT[FK_User_ToRole] FOREIGN KEY([RoleId]) REFERENCES[dbo].[Role]([Id])
);
С помощью следующего SQL-запроса была создана таблица «Defect»(тип неисправности):
CREATE TABLE[dbo].[Defect] (
    [Id]         INT IDENTITY(1, 1) NOT NULL,
    [DefectName] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
С помощью следующего SQL-запроса была создана таблица «Device»(оборудование):
CREATE TABLE[dbo].[Device] (
    [Id]         INT IDENTITY(1, 1) NOT NULL,
    [DeviceName] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
С помощью следующего SQL-запроса была создана таблица «Invoice»(заявка):
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
База данных была заполнена данными:


В итоге создания БД имеет вид:



Был определен принцип регистрации пользователей: 
новых пользователей создает системный администратор и добавляет записи о них в базу данных.
Были созданы группы пользователей «Пользователь» и «Исполнитель»:



были разработаны запросы на работу с  данными:
Запросы на получение ID таблиц оборудования, дефектов, заявок и иполнитлеей:
SELECT Id FROM Device
SELECT Id FROM Defect
SELECT Id FROM [User] WHERE RoleId = 2
SELECT Id FROM Invoice

Запрос на редактирование заявки:
UPDATE Invoice SET ExecutorId = {executorId}, DefectDescription = '{defectDescription}' Where Id = { invoiceId }

Запрос на получение спсика всех заявок:
Select* FROM Invoice

Запрос на добавление заявки:
INSERT INTO Invoice (ClientName, ClientEmail, DeviceId, SerialNumber, DefectId, DefectDescription, CreationDate, FinishDate, Status) VALUES (@ClientName, @ClientEmail, @DeviceId, @SerialNumber, @DefectId, @DefectDescription, @CreationDate, @FinishDate, 'В ожидании')
Запрос на принятие заявки в работу:
UPDATE Invoice SET Status = 'В работе'  Where Id = {invoiceId}

Запрос на завершение заявки:
UPDATE Invoice SET Status = 'Выполнено', ExecutorComment = '{executorComment}' Where Id = {invoiceId}

