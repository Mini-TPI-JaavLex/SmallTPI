/* eslint-disable no-unused-labels */
/* eslint-disable no-label-var */
/* eslint-disable no-labels */
/* eslint-disable @typescript-eslint/no-unused-expressions */
import { Tooltip } from '@mui/material';
import { Box } from '@mui/system';
import { DataGrid, GridColDef, GridToolbar } from '@mui/x-data-grid';
import { useEffect, useState } from 'react';

type overviewType = {
	id: any;
	rank: any;
	title: any;
	status: any;
	startDate: any;
	authors: any;
	genres: any;
	magazines: any;
};

const cellRenderer = (params: any) => (
	<Tooltip title={params.value}>
		<span>{params.value}</span>
	</Tooltip>
);

const columns: GridColDef[] = [
	{
		field: 'rank',
		headerName: 'Rank',
		flex: 1,
		renderCell: cellRenderer,
	},
	{ field: 'title', headerName: 'Title', flex: 1, renderCell: cellRenderer },
	{ field: 'status', headerName: 'Status', flex: 1, renderCell: cellRenderer },
	{
		field: 'startDate',
		headerName: 'Release Date',
		flex: 1,
		renderCell: cellRenderer,
	},
	{ field: 'authors', headerName: 'Authors', flex: 1, renderCell: cellRenderer },
	{ field: 'genres', headerName: 'Genres', flex: 1, renderCell: cellRenderer },
	{
		field: 'magazines',
		headerName: 'Magazines',
		flex: 1,
		renderCell: cellRenderer,
	},
];

export default function Mangas() {
	const [data, setData] = useState<overviewType[]>([]);
	const formatData = (data: any) => {
		return data.map((i: overviewType) => ({
			id: i.id,
			rank: i.rank,
			title: i.title,
			status: i.status,
			startDate: i.startDate,
			authors: i.authors
				.map(
					(a: { firstName: any; lastName: any }) => `${a.firstName} ${a.lastName}`
				)
				.join(', '),
			genres: i.genres.map((g: { name: any }) => g.name).join(', '),
			magazines: i.magazines.map((m: { name: any }) => m.name).join(', '),
		}));
	};

	useEffect(() => {
		fetch(`http://localhost:5225/api/Manga/overview`)
			.then(response => {
				if (!response.ok) {
					throw new Error(`This is an HTTP error: The status is ${response.status}`);
				}
				return response.json();
			})
			.then(actualData => {
				console.log(formatData(actualData));
				return setData(formatData(actualData));
			})
			.catch(err => {
				console.log(err.message);
			});
	}, []);

	return (
		<Box>
			<Box>
				<DataGrid
					disableSelectionOnClick={true}
					rows={data}
					columns={columns}
					pageSize={5}
					autoHeight
					components={{
						Toolbar: GridToolbar,
					}}
					onRowClick={(e: any) => {
						// eslint-disable-next-line no-restricted-globals
						location.replace(`/mangadetail/${e.row.id}`);
					}}
				/>
			</Box>
		</Box>
	);
}
