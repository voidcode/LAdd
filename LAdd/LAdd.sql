create database LAdd;
create table Links (
	linkid integer primary key AUTOINCREMENT,
	title char(50) not null,
	link text not null,
	flag int
);
create table FlagTypes (
	flagid integer primary key AUTOINCREMENT,
	title char(50),
	num int
);

INSERT INTO FlagTypes (title, num) VALUES ("Research", 1);
INSERT INTO FlagTypes (title, num) VALUES ("ToBay", 2);

INSERT INTO Links 
(title, link, flag) 
VALUES 
("Dr.dk", "https://dr.dk", 1), 
("Google.dk", "https://google.dk", 1);