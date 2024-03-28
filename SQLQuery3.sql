CREATE TABLE [dbo].[UserRegistration] (
    [UserID]       INT           IDENTITY (101, 1) NOT NULL,
    [FirstName]    VARCHAR (20)  NULL,
    [LastName]     VARCHAR (20)  NULL,
    [EmailID]      VARCHAR (50)  NULL,
    [PhoneNumber]  VARCHAR (10)  NULL,
    [Password]     VARCHAR (50)  NOT NULL,
    [Education]    VARCHAR (20)  NULL,
    [Created_By]   VARCHAR (20)  NULL,
    [Updated_By]   VARCHAR (20)  NULL,
    [Created_Date] DATETIME2 (0) NULL,
    [Updated_Date] DATETIME2 (0) NULL,
    [Role]         VARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC)
);
