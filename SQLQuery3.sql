create table Athletes(Age int, Nationality varchar(max), Wins int, Podiums int)
alter table Athletes
add [Name] varchar(max)

insert into Athletes(Age, Nationality, Wins, Podiums, [Name]) values(25, 'USA', 87, 135, 'Mikaela Shiffrin')
insert into Athletes(Age, Nationality, Wins, Podiums, [Name]) values(29, 'France', 35, 112, 'Alexis Pinturault')