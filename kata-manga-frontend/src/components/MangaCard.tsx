/* eslint-disable jsx-a11y/alt-text */
import { Typography } from '@mui/material';
import { Box } from '@mui/system';

type MangaCardProps = {
	imageUrl?: string;
	title?: string;
	volumes?: number;
	chapters?: number;
	status?: string;
	published?: string;
	genres?: string;
	authors?: string;
	magazines?: string;
	synopsis?: string;
};

export default function MangaCard({
	imageUrl,
	title,
	volumes,
	chapters,
	status,
	published,
	genres,
	authors,
	magazines,
	synopsis,
}: MangaCardProps) {
	return (
		<Box
			display="flex"
			flexDirection="row"
			justifyContent="center"
			alignItems="center"
			gap={8}
		>
			<Box maxWidth="300px">
				<img src={imageUrl} width="100%" />
			</Box>
			<Box
				display="flex"
				flexDirection="column"
				justifyContent="start"
				alignItems="start"
				maxWidth="600px"
				flexWrap="wrap"
			>
				<Typography variant="h4">{title}</Typography>
				<Typography component="span">
					<Typography variant="subtitle1" fontWeight="bold">
						Volumes: {volumes}
					</Typography>
				</Typography>
				<Typography component="span">
					<Typography variant="subtitle1" fontWeight="bold">
						Chapters: {chapters}
					</Typography>
				</Typography>
				<Typography component="span">
					<Typography variant="subtitle1" fontWeight="bold">
						Status: {status}
					</Typography>
				</Typography>
				<Typography component="span">
					<Typography variant="subtitle1" fontWeight="bold">
						Published: {published}
					</Typography>
				</Typography>
				<Typography component="span">
					<Typography variant="subtitle1" fontWeight="bold">
						Genres: {genres}
					</Typography>
				</Typography>
				<Typography component="span">
					<Typography variant="subtitle1" fontWeight="bold">
						Authors: {authors}
					</Typography>
				</Typography>
				<Typography component="span">
					<Typography variant="subtitle1" fontWeight="bold">
						Magazines: {magazines}
					</Typography>
				</Typography>
				<Typography component="span">
					<Typography variant="h4" fontWeight="bold">
						Synopsis
					</Typography>
					<Typography
						variant="body1"
						fontWeight="bold"
						maxWidth="600px"
						style={{ wordWrap: 'break-word' }}
					>
						{synopsis}
					</Typography>
				</Typography>
			</Box>
		</Box>
	);
}
