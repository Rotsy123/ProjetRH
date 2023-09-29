create database rh
create table departement(
    idDepartement int IDENTITY(1,1) primary key,
    nomDepartement varchar(30)
);

create table demande(
    idDemande int IDENTITY(1,1) primary key,
    dateDemande date,
    heureTravaux datetime,
    hommeJour double precision,
    idDepartement int,
    foreign key (idDepartement) references departement(idDepartement)
);

create table poste(
    idPoste int IDENTITY(1,1) primary key,
    nomPoste varchar(30),
    effectif int,
    idDemande int,
    dateFinPostule datetime,
    foreign key (idDemande) references demande(idDemande)
);
create table employes(
    idEmp int IDENTITY(1,1)int primary key,
    idDept int,
    idPoste int,
    salaire double precision,
    foreign key (idDepartement) references departement(idDepartement),
    foreign key (idPPoste) references poste(idPoste),
);


-- create table critere(
--     idCritere int primary key,
--     nomCritere varchar(30)
-- );

-- create table annonce(
--     idAnnonce int,
--     idCritere int,
--     coefficient int,
--     idPoste int,
--     foreign key (idCritere) references critere(idCritere),
--     foreign key (idPoste) references poste(idPoste)
-- ); 

-- create table candidat(
--     idCandidat int primary key,
--     nomCandidat varchar(30), 
--     retenu int,
--     datePostule datetime
-- );

-- create table notecritere(
--     idCandidat int, 
--     idCritere int,
--     note double precision,
--     foreign key (idCandidat) references candidat(idCandidat)
--     foreign key (idCritere) references critere(idCritere)
-- );

-- create table teste(
--     idTeste int,
--     idPoste int,
--     questions

-- );

-- create table notetest(
--     idCandidat int, 
--     idTeste int,
--     note double precision,
--     foreign key (idCandidat) references candidat(idCandidat)
-- );