# SmallTPI

---

## Description du projet

KataManga est un projet spécialement conçu pour l'entraînement des apprentis aux TPI.

Mon projet consistera d’un Backend en .NET C# avec comme outil d'administration et de test d'API: Swagger, une base de donnée en MySQL avec comme outil d'administration: PHPMyAdmin, d’un Frontend en React Typecript avec Tailwind CSS pour le style des pages et Material-UI pour les composants de base, le tout sera conteneurisé à l’aide de Docker.

Le site répertorie une liste des 100 animes les plus populaires sur MyAnimeList. Il y sera possible de voir ces mangas en question et d’en afficher les détails.

Ceci sera possible à l’aide d’une base de données, dont la structure et les données auront été générées à l’aide du dump SQL fourni dans le GitHub du cahier des charges de KataManga.

Le Backend-API, qui fera la liaison entre le frontend et la base de donnée sera capable d’effectuer des actions CRUD sur chaque entité de la base de données générée. C’est aussi le Backend qui va envoyer les données au frontend de notre site web pour les afficher.

## Comment puis-je déployer ce projet ?

### Pré-requis

1. Avoir `git` installé sur sa machine
1. Avoir docker et la commande `docker-compose` installé sur sa machine

#### Étape 1

Clonez ce repository sur votre machine à l'aide de cette commande:

```bash
# SSH
git clone git@github.com:Mini-TPI-JaavLex/SmallTPI.git

# OU ALORS

# HTTPS
git clone https://github.com/Mini-TPI-JaavLex/SmallTPI.git
```

puis naviguez dans le répértoire du code que vous venez de cloner

```bash
cd SmallTPI/
```

#### Étape 2

Pour builder et lancer le projet

```bash
docker compose up
```

#### Étape 3

Ouvrez votre navigateur et visitez:

- [le Frontend](http://localhost:3000)
- [l'API](http://localhost:7227)
