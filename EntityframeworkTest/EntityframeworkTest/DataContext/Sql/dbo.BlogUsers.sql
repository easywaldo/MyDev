CREATE TABLE [dbo].[BlogUsers] (
    [UserId]      VARCHAR (50)  NOT NULL,
    [UserName]    VARCHAR (200) NOT NULL,
    [BlogUrl] VARCHAR (50)  NOT NULL, 
    CONSTRAINT [PK_BlogUsers] PRIMARY KEY ([UserId])
);