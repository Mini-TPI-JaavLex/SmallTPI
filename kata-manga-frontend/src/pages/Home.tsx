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
				<HomeCard title="Description du projet" description="" />
				<HomeCard title="En quoi ça consiste ?" description="" />
				<HomeCard title="Où puis-je trouver les informations ?" description="" />
			</Box>
		</Box>
	);
}
