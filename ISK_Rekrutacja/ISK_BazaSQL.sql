create database ISK_2;

use ISK_2;

create table Client(
	Id Uniqueidentifier primary key default NEWID(),
	FirstName nvarchar(50),
	LastName nvarchar(50),
	Age int
)

insert into dbo.Client (FirstName, LastName, Age) values('Ola','Nowak',12);
insert into dbo.Client (FirstName, LastName, Age) values('Kinga','Polak',31);
insert into dbo.Client (FirstName, LastName, Age) values('Artur','Mietczyñski',39);

