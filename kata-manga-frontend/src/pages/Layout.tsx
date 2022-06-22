import { Box, Container } from '@mui/material';
import { PropsWithChildren } from 'react';
import AppFooter from '../components/layout/AppFooter';
import AppNavbar from '../components/layout/AppNavbar';

export default function Layout({ children }: PropsWithChildren) {
	return (
		<Container
			maxWidth={false}
			sx={{ height: 1, display: 'flex', flexDirection: 'column', gap: 2, p: 1 }}
		>
			<Box
				display="flex"
				justifyContent="center"
				my={1}
				position="fixed"
				top={0}
				right={0}
				left={0}
				marginTop={-0.5}
			>
				<AppNavbar />
			</Box>
			<Box sx={{ flex: 1, mt: 6, height: '100%' }}>{children}</Box>
			<Box
				display="flex"
				justifyContent="center"
				my={1}
				position="fixed"
				bottom={0}
				right={0}
				left={0}
				marginBottom={-0.5}
			>
				<AppFooter />
			</Box>
		</Container>
	);
}
