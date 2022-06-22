import { Button } from '@mui/material';
import { Link } from 'react-router-dom';

type ButtonLinkProps = {
	path: string;
	text: string;
};

export default function ButtonLink({ path, text }: ButtonLinkProps) {
	return (
		<Button color="secondary">
			<Link to={path}>{text}</Link>
		</Button>
	);
}
