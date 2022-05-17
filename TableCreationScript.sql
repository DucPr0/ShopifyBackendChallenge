DROP TABLE IF EXISTS Inventory
CREATE TABLE Inventory (
	id uniqueidentifier PRIMARY KEY DEFAULT newsequentialid(),
	name varchar(100),
  country varchar(100)
)