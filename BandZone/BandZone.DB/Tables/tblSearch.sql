﻿CREATE TABLE [dbo].[tblSearch]
(
	[SearchId] INT NOT NULL PRIMARY KEY, 
    [SearchDate] DATETIME NULL, 
    [SearchLevel] VARCHAR(200) NULL, 
    [SearchLogger] VARCHAR(200) NULL, 
    [SearchQuery] VARCHAR(2000) NULL, 
    [SearchTable] VARCHAR(2000) NULL
)
