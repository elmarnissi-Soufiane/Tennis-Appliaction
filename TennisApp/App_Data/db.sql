use master
go

create database Tennis
go

use Tennis
go


create table Joueur (
		Nom varchar(20) primary key,
		Prenom varchar(20),
		Age int,
		Nationalite varchar(20)) 
Go
create table Tournoi(
		NomTournoi varchar(20)primary key, 
		DateTournoi datetime
)
Go
create table Rencontre (
		NomGagnant varchar(20)foreign key references Joueur(Nom),
		NomPerdant varchar(20)foreign key references Joueur(Nom), 
		NomTournoi varchar(20)foreign key references Tournoi(NomTournoi), 
		DateTournoi datetime, 
		Score varchar(20),
		Constraint PkJoueur primary key (NomGagnant,NomPerdant,NomTournoi,DateTournoi)
)
Go

create table Sponsor(
		Nom varchar(20) primary key, 
		Adresse varchar(20), 
		ChiffreAffaires varchar(20))

Go
create table Gain(
		NomJoueur varchar(20) foreign key references Joueur(Nom), 
		Annee datetime, 
		Prime int, 
		NomSponsor varchar(20) foreign key references  Sponsor(Nom),
		Constraint PKGain primary key (NomJoueur,Annee,NomSponsor)
)

Go
create table Subvention(
		NomTournoi varchar(20) foreign key references Tournoi(NomTournoi), 
		Annee datetime, 
		NomSponsor varchar(20) foreign key references Sponsor(Nom), 
		Montant int,
		primary key(NomTournoi,Annee,NomSponsor)
)

----------- isnertion  : ------------
Use TENNIS
GO
-- Joueur(Nom,Prenom,Age,Nationalite)


-- hommes
insert into joueur values('Safin','Marat',31, 'Russie');
insert into joueur values('Agassi','Andre',41, 'USA');
insert into joueur values('Arthurs','Wayne',40, 'Australie');
insert into joueur values('Johansson','Thomas',37, 'Suede');            
insert into joueur values('Henman','Tim',36, 'Angleterre');
insert into joueur values('Haas','Tommy',33, 'Allemagne');
insert into joueur values('Hewitt','Lleyton',30, 'Australie');
insert into joueur values('Novak','Jiri',31, 'Tchequie');
insert into joueur values('Moya','Carlos',35, 'Espagne');
insert into joueur values('Costa','Albert',36, 'Espagne');

insert into joueur values('Nadal','Rafael',24, 'Espagne');
insert into joueur values('Djokovic','Novak',23, 'Serbie');
insert into joueur values('Federer','Rodger',29, 'Suisse');
insert into joueur values('Murray','Andy',23, 'Angleterre');
insert into joueur values('Soderling','Robin',26, 'Suede');
insert into joueur values('Davydenko','Nikolay',29, 'Russie');
insert into joueur values('Berdych','Tomas',25, 'Tchequie');
insert into joueur values('Verdasco','Fernando',26, 'Espagne');
insert into joueur values('Youzhny','Mikhail',28, 'Russie');
insert into joueur values('Ferrer','David',28, 'Espagne');
insert into joueur values('Roddick','Andy',28, 'USA');
insert into joueur values('Tsonga','Jo-Wilfried',25, 'France');
insert into joueur values('Melzer','Jurgen',29, 'Autriche');
insert into joueur values('Cilic','Marin',25, 'Croatie');
insert into joueur values('Montfils','Gael',24, 'France');
insert into joueur values('Grosjean','Sebastien',33, 'France');  
insert into joueur values('Clement','Arnaud',33, 'France'); 
-- femmes
insert into joueur values('Williams','Serena',29, 'USA');
insert into joueur values('Wozniacki','Caroline',20, 'Danemark');
insert into joueur values('Zvonareva','Vera',26, 'Russie');
insert into joueur values('Clijsters','Kim',27, 'Belgique');
insert into joueur values('Jankovic','Jelena',25, 'Serbie');
insert into joueur values('Stosur','Samantha',26, 'Australie');
insert into joueur values('Schiavone','Francesca',30, 'Italie');
insert into joueur values('Radwanska', 'Agnieszka',21, 'Pologne');
insert into joueur values('Dementieva','Elena',29, 'Russie');
insert into joueur values('Azarenka', 'Victoria',21, 'Bielo-Russie');
insert into joueur values('Hingis','Martina',33, 'Suisse');
insert into joueur values('Dokic','Jelena',29, 'Yougoslavie');
insert into joueur values('Mauresmo','Amelie',32, 'France');
insert into joueur values('Schett','Barbara',35, 'Autriche');
insert into joueur values('Li','Na',28, 'Chine');
insert into joueur values('Kuznetsova','Svetlana',25, 'Russie');
insert into joueur values('Bartoli','Marion',26, 'France');
insert into joueur values('Sharapova', 'Maria',23, 'Russie');
insert into joueur values('Henin', 'Justine',28, 'Belgique');
insert into joueur values('Davenport','Lindsay',34, 'USA');


Insert into Tournoi Values('RG','4/07/10')
Insert into Tournoi Values('W','4/08/10')
Insert into Tournoi Values('USOPEN','4/12/10')

-- Rencontre(NomGagnant,NomPerdant,LieuTournoi,DateTournoi,Score)
-- W pour Winbledon, RG pour Roland Garros

insert into Rencontre values ('Clement', 'Grosjean','RG', '28/5/2002','6/3-6/4-6/2');
insert into Rencontre values ('Grosjean', 'Clement','W', '29/6/2002','7/6-6/4-6/0');
insert into Rencontre values ('Roddick', 'Nadal','W', '29/6/2005','7/6-7/6-6/7-6/0');
insert into Rencontre values ('Hewitt', 'Clement','W', '2/7/2002','6/3-6/4-6/2');
insert into Rencontre values ('Davenport', 'Mauresmo','RG', '30/5/2004','7/6-4/6-6/0');
insert into Rencontre values ('Davenport', 'Sharapova','RG', '6/2/2004','6/2-6/0');
insert into Rencontre values ('Sharapova', 'Davenport','W', '1/7/2005','7/6-6/0');
insert into Rencontre values ('Schiavone', 'Stosur','RG', '5/5/2010','6/4-7/6');
insert into Rencontre values ('Stosur', 'Jankovic','RG', '3/7/2010','6/1-6/2');
insert into Rencontre values ('Schiavone', 'Dementieva','RG', '3/6/2010','7/6-abandon');
insert into Rencontre values ('Schiavone', 'Wozniaki','RG', '1/7/10','6/2-6/3');
insert into Rencontre values ('Nadal', 'Berdych','W', '4/7/2010','6/3-7/5 6/4');
insert into Rencontre values ('Berdych', 'Djokovic','W', '2/7/2010','6/3-7/6-6/3');
insert into Rencontre values ('Nadal', 'Murray','W', '2/7/2010','6/4-7/6-6/4');
insert into Rencontre values ('Williams', 'Svonareva','W', '3/7/2010','6/3-6/2');
insert into Rencontre values ('Berdych', 'Federer','W', '30/07/2010','6/4-3/6-6/1-6/4');
insert into Rencontre values ('Murray', 'Tsonga','W', '30/6/2010','6/7-7/6-6/2-6/2');
insert into Rencontre values ('Zvonareva', 'Clijsters','W', '29/7/2010','3/6-6/4-6/2');
insert into Rencontre values ('Clijsters', 'Zvonareva','USOPEN', '12/9/2010','6/2-6/1');
insert into Rencontre values ('Nadal', 'Djokovic','USOPEN', '13/9/2010','6/4-5/7-6/4-6/2');


go
-- Sponsor(Nom,Adresse,ChiffreAffaires) CA en MEuros
insert into Sponsor values ('Perrier','Vergese',4);
insert into Sponsor values ('BNP Paribas','Paris',10);
insert into Sponsor values ('IBM','New-York',40);
insert into Sponsor values ('Peugeot','Sochaux',9);
insert into Sponsor values ('Philips','Berlin',30);
insert into Sponsor values ('Orange','Paris',0);
insert into Sponsor values ('Lacoste','Paris',3);
insert into Sponsor values ('Whirlpool','New York',50);
insert into Sponsor values ('Rollex','Londres',30);
go
-- Gain(NomJoueur,Annee,Montant,NomSponsor)
insert into Gain values ('Mauresmo','2004',200000,'Whirlpool');
insert into Gain values ('Davenport','2004',400000,'Whirlpool');
insert into Gain values ('Sharapova','2004',300000,'Whirlpool');
insert into Gain values ('Grosjean','2002',200000,'Peugeot');
insert into Gain values ('Clement','2002',300000,'Peugeot');
insert into Gain values ('Clement','2002',200000,'IBM');
insert into Gain values ('Grosjean','2002',300000,'IBM');
insert into Gain values ('Hewitt','2002',300000,'IBM');
insert into Gain values ('Nadal','2005',200000,'Perrier');
insert into Gain values ('Roddick','2005',300000,'Perrier');
insert into Gain values ('Sharapova','2005',100000,'Perrier');
insert into Gain values ('Davenport','2005',50000,'Perrier');
insert into Gain values ('Schiavone','2010',200000,'Whirlpool');
insert into Gain values ('Clijsters','2010',400000,'Whirlpool');
insert into Gain values ('Sharapova','2010',30000,'Whirlpool');
insert into Gain values ('Dementieva','2010',200000,'Peugeot');
insert into Gain values ('Nadal','2010',300000,'Peugeot');
insert into Gain values ('Federer','2010',200000,'Rollex');
insert into Gain values ('Berdych','2010',300000,'IBM');
insert into Gain values ('Djokovic','2010',300000,'IBM');
insert into Gain values ('Nadal','2010',200000,'Perrier');
insert into Gain values ('Roddick','2010',300000,'Perrier');
insert into Gain values ('Svonareva','2010',100000,'Perrier');
insert into Gain values ('Williams','2010',50000,'Lacoste');
insert into Gain values ('Williams','2008',50000,'Rollex');


go
-- Subvention(NomTournoi,Annee,Montant,NomSponsor)

insert into Subvention values ('W','2009','Rollex',1000000);
insert into Subvention values ('W','2010','Rollex',1000000);
insert into Subvention values ('RG','2008','Rollex',500000);
insert into Subvention values ('RG','2008','IBM',500000);
insert into Subvention values ('RG','2008','Peugeot',500000);
insert into Subvention values ('RG','2008','Perrier',500000);
insert into Subvention values ('RG','2010','IBM',1000000);
insert into Subvention values ('RG','2010','Peugeot',900000);
insert into Subvention values ('RG','2010','Perrier',800000);

select * from Joueur
select * from Tournoi
select * from Sponsor

select * from Rencontre
select * from Subvention
select * from Gain


SELECT Joueur.Nom, Joueur.Prenom, Rencontre.Score, Rencontre.DateTournoi
FROM Joueur
INNER JOIN Rencontre 
ON Joueur.Nom = Rencontre.NomGagnant OR Joueur.Nom = Rencontre.NomPerdant
WHERE Rencontre.NomTournoi = 'w' AND Rencontre.DateTournoi = '29/06/2005'
ORDER BY Rencontre.Score DESC;


select * from Joueur as j 
inner join Rencontre as r 
on
j.Nom = r.NomPerdant
inner join Tournoi as t
on r.NomTournoi = t.NomTournoi
where r.NomGagnant = j.Nom and r.DateTournoi = t.DateTournoi


SELECT TOP 10
    j1.Nom AS NomJoueur,
    j1.Prenom AS PrenomJoueur,
    SUM(CASE WHEN r.NomGagnant = j1.Nom THEN 1 ELSE 0 END) AS Victoires,
    SUM(CASE WHEN r.NomPerdant = j1.Nom THEN 1 ELSE 0 END) AS Defaites,
    SUM(CASE WHEN r.NomGagnant = j1.Nom THEN r.Score ELSE -r.Score END) AS ScoreTotal
FROM Rencontre r
INNER JOIN Joueur j1 ON r.NomGagnant = j1.Nom
INNER JOIN Joueur j2 ON r.NomPerdant = j2.Nom
GROUP BY j1.Nom, j1.Prenom
ORDER BY ScoreTotal DESC;

SELECT TOP 1 NomGagnant, MAX(Score) as TopScore
FROM Rencontre
GROUP BY NomGagnant
ORDER BY MAX(Score) DESC


select * from Rencontre as r 
inner join Joueur as j1 
on r.DateTournoi = j1.Nom 
inner join Joueur as j2