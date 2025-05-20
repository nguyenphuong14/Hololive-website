CREATE TABLE Adminpage (
    namepage nvarchar(500),
	functions nvarchar(500),
    img nvarchar(500),
);
INSERT INTO Adminpage (namepage, functions, img) VALUES
('member','create','CreateMember'),
('member','update','UpdateMember'),
('member','delete','DeleteMember'),
('video','create','CreateVideo'),
('video','update','UpdateVideo'),
('video','delete','DeleteVideo')