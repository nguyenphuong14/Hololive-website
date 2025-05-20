ALTER TABLE InforMember drop CONSTRAINT fk_id;
ALTER TABLE VtuberMember drop CONSTRAINT fk_id;
ALTER TABLE VideoMember drop CONSTRAINT fk_htk_id_video ;
ALTER TABLE VideoMember drop CONSTRAINT fk_htk_id_member;