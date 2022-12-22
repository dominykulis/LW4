create schema IF NOT EXISTS Car;

DROP TABLE IF EXISTS Car.models;
DROP TABLE IF EXISTS Car.manufacturers;

create table Car.manufacturers(
    ID serial not null,
    primary key (ID),
    Name varchar(30),
    Director varchar(30),
    Main_Base varchar(30),
    Founded int
);

insert into Car.manufacturers(Name, Director, Main_Base, Founded)
values('Ford', 'Jim Farley', 'Dearborn, Michigan, USA', 1903),
('Mazda Motor Corporation', 'Akira Marumoto', 'Fuchu, Hiroshima, Japan', 1920),
('Honda Motor Company', 'Toshihiro Mibe', 'Minato City, Tokyo, Japan', 1948),
('Tesla', 'Elon Musk' , 'Austin, Texas, United States', 2003);

select * from Car.manufacturers;



create table Car.models(
    ID serial not null,
    primary key (ID),
    Name varchar(30),
    Horsepower int,
    Weight int,
    Acceleration varchar(30),
    manufacturer_ID int,
    constraint fk_manufacturer_ID
    foreign key(manufacturer_ID)
    references Car.manufacturers(ID)
);

insert into Car.models(Name,Horsepower,Weight,Acceleration,manufacturer_ID)
values ('Model S', 1020, 2162, '2.1 s 0-100 km/h', 4),
('MAZDA MX-5', 132, 1066, '8.3 s 0-100 km/h', 2),
('RAPTOR', 288, 2478, '7.9s 0-100 km/h',1),
('CIVIC HYBRID', 143, 1499, '8.1s 0-100 km/h',3);

select * from Car.models