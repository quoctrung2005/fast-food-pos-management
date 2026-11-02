use PosFastFoods
create table RoleEmployee(
	IdRole int identity(1,1) primary key not null,
	NameRole varchar(100)
)
create table Employee(
	IdEmployee int identity(1, 1) primary key not null,
	NameEmployee nvarchar(250),
	BirthDay datetime2(7),
	Gender bit,
	Address nvarchar(250),
	Email nvarchar(200),
	Password varchar(100),
	IdRole int,
	foreign key (IdRole) references RoleEmployee(IdRole)
);
insert into Employee values ('Cao Nam', '2001-11-20', 1, N'Tăng nhơn phú A, Hồ Chí Minh', 'caonam@gmail.com', 'caonam', 1);
insert into Employee values ('Kieu', '2001-01-13', 1, N'Tăng nhơn phú A, Hồ Chí Minh', 'kieu@gmail.com', 'kieu', 2);

create table TypeProduct(
	IdTypeProduct int identity(1, 1) primary key not null,
	NameType varchar(50),
	IdEmployee int,
	foreign key (IdEmployee) references Employee(IdEmployee)
);

create table Product(
	IdProduct int identity(1, 1) primary key not null,
	NameProduct varchar(100),
	PriceProduct money,
	Decriptions varchar(150),
	Images varbinary(Max),
	IsActive bit,
	IdTypeProduct int not null,
	IdEmployee int,
	foreign key (IdEmployee) references Employee(IdEmployee),
	foreign key (IdTypeProduct) references TypeProduct(IdTypeProduct)
);

create table Orders(
	IdOrder int identity(1,1) primary key not null,
	quantity int,
	Total money,
	CreateDate datetime2(7),
	IdEmployee int,
	foreign key (IdEmployee) references Employee(IdEmployee)
);

create table OrderDetail(
	IdProduct int,
	IdOrder int,
	quantity int,
	PRIMARY KEY (IdProduct, IdOrder),
	foreign key (IdProduct) references Product(IdProduct),
	foreign key (IdOrder) references Orders(IdOrder)
);

insert into TypeProduct values ('Food', 2);
insert into TypeProduct values ('Drink', 2);
insert into TypeProduct values ('Snack', 2);
insert into TypeProduct values ('Dessert', 2);
insert into TypeProduct values ('Combo', 2);

insert into RoleEmployee values ('Admin');
insert into RoleEmployee values ('Employee');