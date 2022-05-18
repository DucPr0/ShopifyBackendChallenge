DROP TABLE IF EXISTS Inventory
CREATE TABLE Inventory (
  id int PRIMARY KEY IDENTITY(1, 1),
  name varchar(100),
  country varchar(50),
  isDeleted bit,
  deleteReason varchar(1000),
  deleteTime datetime
)