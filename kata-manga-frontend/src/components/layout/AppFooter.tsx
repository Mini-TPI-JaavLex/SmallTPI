import { Box } from '@mui/system';

export default function AppFooter() {
	return (
		<Box
			width="100%"
			display="flex"
			flexDirection="row"
			justifyContent="center"
			alignItems="center"
			bgcolor="#EFEFF0"
			gap={0.5}
			padding={2}
		>
			<Box>KataManga v0.1.0</Box> -{' '}
			<a href="https://github.com/Mini-TPI-JaavLex/">sources</a>
		</Box>
	);
}
