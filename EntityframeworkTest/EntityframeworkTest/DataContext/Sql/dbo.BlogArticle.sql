CREATE TABLE [dbo].[BlogArticle] (
    [ArticleNo] INT NOT NULL,
    [ParentNo]  INT NULL,
    [WriteUser] varchar(50) NOT NULL,
    [Content ] NTEXT NULL, 
    PRIMARY KEY CLUSTERED ([ArticleNo] ASC), 
    CONSTRAINT [FK_BlogArticle_ToTable] FOREIGN KEY ([WriteUser]) REFERENCES [BlogUsers]([UserId]),
	CONSTRAINT [FK_BlogArticle_ToParentArticle] FOREIGN KEY ([ParentNo]) REFERENCES [BlogArticle]([ArticleNo])
);