
CREATE TABLE VtuberMember (
    id int NOT NULL PRIMARY KEY,
    region nvarchar(50),
    gen nvarchar(50),
	memberstatus int default 0,
	en_name varchar(50),
	jp_name nvarchar(50),
	heart int default 0
);

INSERT INTO VtuberMember (id,region, gen, en_name,jp_name)
VALUES (1,'jp', N'3stgen', 'Usada Pekora', N'兎田ぺこら'),
(2,'en',  'English', 'Gawr Gura', N'がうる・ぐら'),
(3,'en', 'Advent', 'Nerissa Ravencroft', N'ネリッサ・レイヴンクロフト');
