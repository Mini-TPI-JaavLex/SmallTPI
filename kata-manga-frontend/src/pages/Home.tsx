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

Un Backend, Frontend et une Base de données doivent être créés pendant ce projet et le tout doit être conteneurisé à l’aide de Docker. Permettant de build le projet et le lancer avec une (ou deux) commandes seulement.

Au niveau du Backend, des accesseurs doivent être créés pour chaque entité de la base de données permettant de pouvoir effectuer des actions CRUD sur chacune de celles-ci. Celui-ci doit également avoir un Swagger intégré afin de pouvoir administrer et tester les accesseurs créés.

Pour le Frontend, 4 pages doivent être créées. Une page d'accueil présentant le projet, une page manga affichant un tableau avec comme données la liste des 100 mangas citée précédemment. Une page de détail d’un manga en spécifique, montrant toutes les informations disponible sur le manga sélectionné. Et une page API, qui redirigera sur le Swagger de notre Backend.
"
				/>
				<HomeCard
					title="Mise en oeuvre"
					description="La réalisation de ce projet se prouve plus complexe que prévu, ceci est principalement dû aux choix de technologies qui ont été fait pour la réalisation de ce Mini-TPI. Beaucoup de retards se sont créés au début du projet avec la réalisation du Backend, créant un risque de non-finition du projet dans les délais convenus. "
				/>
				<HomeCard
					title="Résultats"
					description="Le projet résulte au final en un succès, permettant la finition du projet un demi-jour à l’avance sur le planning initial. Les points requis du cahier des charges ont été respecté et le projet est désormais fonctionnel sur le répertoire Github de mon Mini-TPI"
				/>
			</Box>
		</Box>
	);
}
