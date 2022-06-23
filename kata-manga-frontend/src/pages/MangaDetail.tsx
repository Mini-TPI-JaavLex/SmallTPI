import { Box } from '@mui/system';
import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import MangaCard from '../components/MangaCard';

type specificType = {
	id?: any;
	rank?: any;
	title?: any;
	status?: any;
	startDate?: any;
	synopsis?: any;
	imageUrl?: any;
	numChapters?: any;
	numVolumes?: any;
	authors?: any;
	genres?: any;
	magazines?: any;
};

export default function MangaDetail() {
	const { id } = useParams();
	const [data, setData] = useState<specificType>();

	useEffect(() => {
		fetch(`http://localhost:5225/api/Manga/specific/${id}`)
			.then(response => {
				if (!response.ok) {
					throw new Error(`This is an HTTP error: The status is ${response.status}`);
				}
				return response.json();
			})
			.then(actualData => {
				console.log(actualData);
				return setData(actualData);
			})
			.catch(err => {
				console.log(err.message);
			});
	}, []);
	return (
		<Box>
			<MangaCard
				imageUrl={data != undefined && data.imageUrl}
				title={data != undefined && data.title}
				volumes={data != undefined && data.numVolumes}
				chapters={data != undefined && data.numChapters}
				status={data != undefined && data.status}
				published={data != undefined && data.startDate}
				genres={
					data != undefined &&
					data.genres.map((g: { name: any }) => g.name).join(', ')
				}
				authors={
					data != undefined &&
					data.authors
						.map(
							(a: { firstName: any; lastName: any }) =>
								`${a.firstName} ${a.lastName}`
						)
						.join(', ')
				}
				magazines={
					data != undefined &&
					data.magazines.map((g: { name: any }) => g.name).join(', ')
				}
				synopsis={data != undefined && data.synopsis}
			/>
		</Box>
	);
}
