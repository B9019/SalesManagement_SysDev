CREATE TABLE [dbo].[M_Product] (
    [PrID]          INT            IDENTITY (1, 1) NOT NULL,
    [MaID]          INT            NOT NULL,
    [PrName]        NVARCHAR (50)  NOT NULL,
    [Price]         INT            NOT NULL,
    [PrJCode]       NVARCHAR (13)  NULL,
    [PrSafetyStock] INT            NOT NULL,
    [ScID]          INT            NOT NULL,
    [PrModelNumber] INT            NOT NULL,
    [PrColor]       NVARCHAR (20)  NOT NULL,
    [PrReleaseDate] DATETIME       NOT NULL,
    [PrFlag]        INT            NOT NULL,
    [PrHidden]      NVARCHAR (MAX) NULL,
    [PrMemo]        NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.M_Product] PRIMARY KEY CLUSTERED ([PrID] ASC), 
    CONSTRAINT [FK_dbo.M_Maker] FOREIGN KEY ([MaID]) REFERENCES [M_Maker]([MaID]), 
    CONSTRAINT [FK_dbo.M_SmallClassification] FOREIGN KEY ([ScID]) REFERENCES [M_SmallClassification]([ScID])
);

