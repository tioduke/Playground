CREATE TABLE CUSTOMER
(
	ID           INTEGER      NOT NULL PRIMARY KEY AUTOINCREMENT,
	CODE         VARCHAR(8)   NOT NULL,
	NAME         VARCHAR(20)  NOT NULL,
	NAS          VARCHAR(9)   NOT NULL,
	AMOUNT       NUMBER(10,2) NULL,
	BIRTH_DATE   DATETIME     NULL,
	OTHER_DATE   DATETIME     NULL
);
Insert into CUSTOMER
   (ID, CODE, NAME, NAS, AMOUNT, BIRTH_DATE, OTHER_DATE)
 Values
   (1, 'A', 'Asterix', '111111111', 10.2, '1933-01-01', '2017-04-01');
Insert into CUSTOMER
   (ID, CODE, NAME, NAS, AMOUNT, BIRTH_DATE, OTHER_DATE)
 Values
   (2, 'B', 'Panoramix', '222222222', 23.14, '1920-02-01', '2017-04-02');
Insert into CUSTOMER
   (ID, CODE, NAME, NAS, AMOUNT, BIRTH_DATE, OTHER_DATE)
 Values
   (3, 'A', 'Obelix', '333333333', 11.14, '1934-02-03', '2017-04-01');