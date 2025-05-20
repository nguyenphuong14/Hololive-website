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
