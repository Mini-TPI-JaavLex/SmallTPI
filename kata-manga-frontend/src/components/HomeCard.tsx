import { Typography } from '@mui/material';
import { Box } from '@mui/system';

type HomeCardProps = {
	title: string;
	description: string;
};

export default function HomeCard({ title, description }: HomeCardProps) {
	return (
		<Box display="flex" flexDirection="column">
			<Typography variant="subtitle1" fontWeight="bold">
				{title}
			</Typography>
			<Typography variant="body1" fontWeight="bold">
				{description}
			</Typography>
		</Box>
	);
}
