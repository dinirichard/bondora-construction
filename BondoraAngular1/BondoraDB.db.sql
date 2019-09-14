BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "Prod_Invc" (
	"Invoice_Id"	INTEGER NOT NULL,
	"Prod_Id"	INTEGER NOT NULL,
	FOREIGN KEY("Invoice_Id") REFERENCES "Invoice"("Id"),
	FOREIGN KEY("Prod_Id") REFERENCES "Inventory"("Id")
);
CREATE TABLE IF NOT EXISTS "Invoice" (
	"Id"	INTEGER NOT NULL,
	"TotalPrice"	INTEGER NOT NULL,
	"BonusPoints"	INTEGER NOT NULL,
	"PurchaseDate"	TEXT NOT NULL,
	"UserId"	INTEGER NOT NULL,
	PRIMARY KEY("Id")
);
CREATE TABLE IF NOT EXISTS "Inventory" (
	"Id"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	"Name"	TEXT NOT NULL,
	"Type"	TEXT NOT NULL,
	"RentDays"	INTEGER DEFAULT 0
);
CREATE TABLE IF NOT EXISTS "Prices" (
	"Id"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	"Class"	TEXT NOT NULL,
	"Amount"	INTEGER NOT NULL DEFAULT 0
);
CREATE TABLE IF NOT EXISTS "Users" (
	"Id"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	"FirstName"	TEXT NOT NULL,
	"LastName"	TEXT NOT NULL,
	"Address"	TEXT,
	"Email"	TEXT NOT NULL UNIQUE,
	"AuthUserId"	TEXT
);
INSERT INTO "Prod_Invc" ("Invoice_Id","Prod_Id") VALUES (1,1);
INSERT INTO "Prod_Invc" ("Invoice_Id","Prod_Id") VALUES (1,2);
INSERT INTO "Prod_Invc" ("Invoice_Id","Prod_Id") VALUES (1,4);
INSERT INTO "Prod_Invc" ("Invoice_Id","Prod_Id") VALUES (2,2);
INSERT INTO "Invoice" ("Id","TotalPrice","BonusPoints","PurchaseDate","UserId") VALUES (1,500,2,'Monday',1);
INSERT INTO "Invoice" ("Id","TotalPrice","BonusPoints","PurchaseDate","UserId") VALUES (2,140,0,'Monday',2);
INSERT INTO "Inventory" ("Id","Name","Type","RentDays") VALUES (1,'Caterpillar bulldozer','Heavy
',NULL);
INSERT INTO "Inventory" ("Id","Name","Type","RentDays") VALUES (2,'KamAZ truck','Regular',NULL);
INSERT INTO "Inventory" ("Id","Name","Type","RentDays") VALUES (3,'Komatsu crane','Heavy',NULL);
INSERT INTO "Inventory" ("Id","Name","Type","RentDays") VALUES (4,'Volvo steamroller','Regular',NULL);
INSERT INTO "Inventory" ("Id","Name","Type","RentDays") VALUES (5,'Bosch jackhammer','Specialized',NULL);
INSERT INTO "Prices" ("Id","Class","Amount") VALUES (1,'One-time rental fee',100);
INSERT INTO "Prices" ("Id","Class","Amount") VALUES (2,'Premium daily fee',40);
INSERT INTO "Prices" ("Id","Class","Amount") VALUES (3,'Regular daily fee',60);
INSERT INTO "Users" ("Id","FirstName","LastName","Address","Email","AuthUserId") VALUES (1,'Mary','Jane','Somewhere in Tartu','mary@jane.com',NULL);
INSERT INTO "Users" ("Id","FirstName","LastName","Address","Email","AuthUserId") VALUES (2,'Tayo','Manual','Illorin','manual@fifa.com',NULL);
COMMIT;
