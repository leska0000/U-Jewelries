CREATE TABLE [dbo].[Purchase] (
    [Id]              INT        NOT NULL,
    [product_id]      INT        NOT NULL REFERENCES Product(Id),
    [costumer_id]     INT        NOT NULL REFERENCES Costumer(auto_Id),
    [amount]          FLOAT (53) NULL,
    [costumer_person] NCHAR (10) NULL,
    [purchase_date]   DATE       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

