import { Box, Typography } from '@mui/material';
import HomeCard from '../components/HomeCard';

export default function Home() {
	return (
		<Box
			width="100%"
			height="100%"
			display="flex"
			flexDirection="column"
			justifyContent="center"
			alignItems="center"
			gap={2}
		>
			<Typography variant="h4">Bienvenue sur Kata Manga</Typography>
			<Box display="flex" flexWrap="wrap" flexDirection="row" gap={6}>
				<HomeCard
					title="Situation initiale"
					description="Ce Mini-TPI est destiné à la création d’une page web affichant les 100 mangas les plus populaires du site MyAnimeList grâce à un fichier de dump MySQL généré par l’API de ce site. 

					Un backend, frontend et une base de données doivent être créés pendant ce projet et le tout doit être conteneurisé à l’aide de Docker. Ceci permet de builder le projet et de le lancer avec une (ou deux) commandes seulement.
					
					Au niveau du backend, des accesseurs doivent être créés pour chaque entité de la base de données permettant de pouvoir effectuer des actions CRUD sur chacune de celles-ci. Celui-ci doit également avoir un Swagger intégré afin de pouvoir administrer et tester les accesseurs créés.
					
					Pour le Frontend, 4 pages doivent être créées. Une page d'accueil présentant le projet, une page manga affichant un tableau avec comme données la liste des 100 mangas citée précédemment. Une page de détail d’un manga en spécifique, montrant toutes les informations disponibles sur le manga sélectionné. Et une page API, qui redirigera sur le Swagger de notre backend.					
"
				/>
				<HomeCard
					title="Mise en oeuvre"
					description="La réalisation de ce projet s’est révélée plus complexe que prévu, ceci est principalement dû aux choix de technologies qui ont été fait pour la réalisation de ce Mini-TPI. Beaucoup de retards se sont créés au début du projet avec la réalisation du backend, créant un risque de non-finition du projet dans les délais convenus. 

					Ce retard a cependant été rattrapé, et il y a eu même une avance prise sur le projet."
				/>
				<HomeCard
					title="Résultats"
					description="Le projet résulte au final en un succès, permettant la finition du projet pratique un demi-jour à l’avance sur le planning initial. Les points requis du cahier des charges ont été respectés et le projet est désormais fonctionnel sur le répertoire GitHub de mon Mini-TPI."
				/>
			</Box>
		</Box>
	);
}
