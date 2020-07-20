CREATE TABLE [dbo].[Product] (
    [Id]          INT        NOT NULL,
    [name]        CHAR (50)  NULL,
    [price]       FLOAT (53) NOT NULL,
    [cost]        FLOAT (53) NULL,
    [amount]      INT        NOT NULL,
    [is_active]   BIT        NULL,
    [category_id] INT        NULL,
    [img_url]     CHAR (250) NULL,
    FOREIGN KEY ([category_id]) REFERENCES [dbo].[Category] ([Id]),
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

