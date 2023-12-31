create database rh


create table departement(
    idDepartement int IDENTITY(1,1) primary key,
    nomDepartement varchar(30)
);

create table demande(
    idDemande int IDENTITY(1,1) primary key,
    dateDemande datetime,
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
    idEmp int IDENTITY(1,1)primary key,
    nom varchar(30),
    prenom varchar(30),
    dtn date,
    idDept int,
    idPoste int,
    salaire double precision,
    foreign key (idDept) references departement(idDepartement),
    foreign key (idPoste) references poste(idPoste),
);
-- Donnes --
INSERT INTO departement (idDepartement, nomDepartement) VALUES
(1, 'R63





essources Humaines'),
(2, 'Finance'),
(3, 'Informatique');

-- Insertion de données de test dans la table poste
INSERT INTO poste (idPoste, nomPoste) VALUES
(1, 'Manager'),
(2, 'Développeur'),
(3, 'Comptable');

INSERT INTO employes (nom,prenom,dtn,idDept, idPoste, salaire) VALUES
('Jean', 'Paul', '1995-12-03', 1, 1, 60000.00),
(2, 3, 45000.00),
(3, 2, 55000.00);  x
create table posteDepartement(
    idPoste int, 
    idDepartement int, 
    foreign key (idPoste) references Poste(idPoste),
    foreign key (idDepartement) references departement (idDepartement)
);

insert into posteDepartement (idposte, idDepartement) values 
(2, 3)
(3, 2);


create table posteeffectif(
    idPosteEffectif int IDENTITY(1,1) primary key,
    idDemande int,
    effectif int,
    datefinpostule DATETIME,
    idposte int,
    foreign key (idposte) references poste(idposte),
    foreign key (idDemande) references demande(idDemande)
 );

 
 create table question(
    idQuestion int IDENTITY(1,1) primary key,
    question text
 );

create table reponse(
    idReponse int IDENTITY(1,1) primary key,
    idQuestion  int references question (idQuestion),
    reponse text,
    valeur      int 
);

create table questionreponse(
    idQuestion int,
    idReponse int,
    valeur int,
    foreign key (idQuestion) references question(idQuestion),
    foreign key (idReponse) references reponse(idReponse)
);

create table quiz(
    idQuiz int IDENTITY(1,1) primary key,
    idPoste int,
    idQuestion int,
    foreign key (idPoste) references poste(idPoste),
    foreign key (idQuestion) references question(idQuestion)
);

create table cursus(
    idCursus int IDENTITY(1,1) primary key,
    nomCursus   varchar(25)
);

-- create table cursusniveau(
--     idCursusNiveau IDENTITY(1,1) primary key,
--     idCursus    int references cursus (idCursus),
--     niveau      double precision,
--     coefficient double precision,
--     idPoste     int references poste (idPoste)
-- );

-- create table experience(){
    
-- }

-- create table cv(

-- );


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

