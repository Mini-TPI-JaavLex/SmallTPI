import { Box } from '@mui/system';
import { Link } from 'react-router-dom';
import logo from '../../images/manga-logo.png';
import ButtonLink from '../global/ButtonLink';

export default function AppNavbar() {
	return (
		<Box
			width="100%"
			display="flex"
			flexDirection="row"
			alignItems="center"
			bgcolor="#EFEFF0"
			gap={6}
			paddingX={2}
		>
			<Box>
				<img src={logo} width="100px" />
			</Box>
			<Box display="flex" flexDirection="row" gap={4}>
				<ButtonLink path="/" text="Home" />
				<ButtonLink path="/mangas" text="Mangas" />
				<ButtonLink path="/api" text="API" />
			</Box>
		</Box>
	);
}
