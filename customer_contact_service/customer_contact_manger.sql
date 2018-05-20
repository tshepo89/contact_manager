create database customer_manager_db
go

use customer_manager_db
go

create table customer(
	id int primary key identity,
	name nvarchar(30),
	latitude nvarchar(25),
	longitude nvarchar(25)
)
go

use customer_manager_db
go
insert into customer values('Tshepo', '789798222','3353588889')

delete customer 
where name = 'Tshepo'

use customer_manager_db
go
select *
from customer

create table customer_contact(
	id int primary key identity,
	name nvarchar(30),
	email nvarchar(50),
	contact_number nvarchar(15),
	customer_id int,
	FOREIGN KEY (customer_id) REFERENCES customer(id)
)
go

select *
from customer_contact

drop table customer, customer_contact
