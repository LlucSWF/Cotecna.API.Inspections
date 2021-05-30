CREATE TABLE [dbo].[InspectorInfo]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Surnames] NVARCHAR(100) NULL, 
    [NIF] NCHAR(9) NOT NULL
)
