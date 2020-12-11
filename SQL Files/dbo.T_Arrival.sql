CREATE TABLE [dbo].[T_Arrival] (
    [ArID]        INT            IDENTITY (1, 1) NOT NULL,
    [SoID]        INT            NOT NULL,
    [EmID]        INT            NOT NULL,
    [ClID]        INT            NOT NULL,
    [OrID]        INT            NOT NULL,
    [ArDate]      DATETIME       NULL,
    [ArStateFlag] INT            NULL,
    [ArFlag]      INT            NOT NULL,
    [ArHidden]    NVARCHAR (MAX) NULL,
    [Armemo]      NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.T_Arrival] PRIMARY KEY CLUSTERED ([ArID] ASC), 
    CONSTRAINT [FK_dbo.M_Employee] FOREIGN KEY ([EmID]) REFERENCES [M_Employee]([EmID]), 
);

