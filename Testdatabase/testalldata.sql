ALTER TABLE InforMember drop CONSTRAINT fk_id;
ALTER TABLE VtuberMember drop CONSTRAINT fk_id;
ALTER TABLE VideoMember drop CONSTRAINT fk_htk_id_video ;
ALTER TABLE VideoMember drop CONSTRAINT fk_htk_id_member;


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

CREATE TABLE VideoMember (
    idvideo int,
    idmember int,
	CONSTRAINT fk_htk_id_video   FOREIGN KEY (idvideo)   REFERENCES video (id)    ON DELETE CASCADE ON UPDATE CASCADE ,
	CONSTRAINT fk_htk_id_member   FOREIGN KEY (idmember)   REFERENCES VtuberMember (id)    ON DELETE CASCADE ON UPDATE CASCADE ,
);
INSERT INTO VideoMember (idvideo, idmember) VALUES
('1','2'),
('1','1'),
('1','3'),
('2','2'),
('2','1'),
('3','3'),
('3','2')



CREATE TABLE InforMember (
    id int,
    birthday date,
	debut date,
	height int,
	illustrator nvarchar(50),
	dream nvarchar(50),
	fname nvarchar(50),
	hashtag nvarchar(50),
	openwords nvarchar(50),
	introduction nvarchar(500),
	youtube nvarchar(500) ,
	x nvarchar(500),
	CONSTRAINT fk_id
	FOREIGN KEY (id)
	REFERENCES VtuberMember (id) ON DELETE CASCADE ON UPDATE CASCADE

);
INSERT INTO InforMember (id,birthday, debut, height, illustrator, dream, fname, hashtag, openwords, introduction, youtube, x) VALUES
(1,'0001-01-12', '2019-07-17', 153, N'憂姫はぐれ', N'全世界野うさぎ計画', N'野うさぎ同盟', N'ぺこらいぶ',  N'こんぺこ！こんぺこ！こんぺこー！兎田ぺこらぺこ～！どうも〜どうも〜', N'寂しがり屋なうさ耳の女の子。にんじんをこよなく愛し、いつでも食べられるように持ち歩いている。','channel/UC1DCedRgGHBdm81E1llLhOQ?sub_confirmation=1','usadapekora'),
(2,'0001-06-20', '2020-09-13', 141, N'甘城なつき', N'全世界野うさぎ計画', N'chumbuds'   , N'gawrgura' ,  N'ドーモ！！サメデス！！今日はもうサメのこと、考えた？'              , N'海底つまらんすぎてワロタ」って言いながら地上にやってきたアトランティスの末裔。 彼女がお気に入りで着ている服は（サメの被りモノも含めて）日本で買った。本人曰く暇な時は海洋生物と会話するのが好き。','channel/UCoSrY_IQQVpmIRZ9Xf-y93g?sub_confirmation=1','gawrgura'),
(3,'0001-11-21', '2023-07-31', 175, N'EB十', '', ''   , '' , N'嗚呼、やはり良い響きですね――アイドルソングというものは', N'歌をこよなく愛する『音の魔人』。
その愛は魔力となって歌に宿り、世界を狂わしかねないものとなった。彼女の歌声を恐れた神々により長らく封じ込められていたが、その間も人々に歌を届けたいという願いは消えることがなかった。
封印の最中にジャパニーズオタクカルチャーと出会ったことで、今はアイドルソングやペンライトに興味津々。案外、封印生活も悪いことばかりではなかったようだ。','channel/UC_sFNM0z0MWm9A6WlKPuMMg','nerissa_en')

