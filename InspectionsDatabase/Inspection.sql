CREATE TABLE [dbo].[Inspection]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Rating] DECIMAL(2, 2) NULL, 
    [ScheduledDate] DATETIME NOT NULL, 
    [InspectorId] INT NOT NULL
    FOREIGN KEY (InspectorId) REFERENCES InspectorInfo(Id)
)
