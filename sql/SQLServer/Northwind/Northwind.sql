
-- https://base64.guru/converter/decode/file

SELECT (SELECT Picture AS '*' FOR XML PATH(''))
FROM Categories

SELECT (SELECT Photo AS '*' FOR XML PATH(''))
FROM Employees

/*
-- SELECT CategoryId,CategoryName FROM Categories ORDER BY 1
1	Beverages
2	Condiments
3	Confections
4	Dairy Products
5	Grains/Cereals
6	Meat/Poultry
7	Produce
8	Seafood
*/
/*
UPDATE Categories SET Picture = (SELECT BulkColumn FROM OPENROWSET(BULK N'C:\Git\microsoft.png', SINGLE_BLOB) AS image) WHERE CategoryId = 1
UPDATE Categories SET Picture = (SELECT BulkColumn FROM OPENROWSET(BULK N'C:\Git\microsoft.png', SINGLE_BLOB) AS image) WHERE CategoryId = 2
UPDATE Categories SET Picture = (SELECT BulkColumn FROM OPENROWSET(BULK N'C:\Git\microsoft.png', SINGLE_BLOB) AS image) WHERE CategoryId = 3
UPDATE Categories SET Picture = (SELECT BulkColumn FROM OPENROWSET(BULK N'C:\Git\microsoft.png', SINGLE_BLOB) AS image) WHERE CategoryId = 4
UPDATE Categories SET Picture = (SELECT BulkColumn FROM OPENROWSET(BULK N'C:\Git\microsoft.png', SINGLE_BLOB) AS image) WHERE CategoryId = 5
UPDATE Categories SET Picture = (SELECT BulkColumn FROM OPENROWSET(BULK N'C:\Git\microsoft.png', SINGLE_BLOB) AS image) WHERE CategoryId = 6
UPDATE Categories SET Picture = (SELECT BulkColumn FROM OPENROWSET(BULK N'C:\Git\microsoft.png', SINGLE_BLOB) AS image) WHERE CategoryId = 7
UPDATE Categories SET Picture = (SELECT BulkColumn FROM OPENROWSET(BULK N'C:\Git\microsoft.png', SINGLE_BLOB) AS image) WHERE CategoryId = 8
*/

/*
UPDATE Employees SET Photo = (SELECT BulkColumn FROM OPENROWSET(BULK N'C:\Git\microsoft.png', SINGLE_BLOB) AS image)
*/