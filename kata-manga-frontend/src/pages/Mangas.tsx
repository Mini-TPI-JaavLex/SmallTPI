import { Box } from '@mui/system';
import { DataGrid, GridColDef, GridRowsProp, GridToolbar } from '@mui/x-data-grid';

const mockData: GridRowsProp = [
	{
		id: 1,
		rank: '1',
		title: 'One Piece',
		author: 'Eiichiro Oda',
		genre: 'Action',
		magazine: 'One Piece',
		start_date: '1999-12-31',
		status: 'Ongoing',
	},
	{
		id: 1,
		rank: '1',
		title: 'One Piece',
		author: 'Eiichiro Oda',
		genre: 'Action',
		magazine: 'One Piece',
		start_date: '1999-12-31',
		status: 'Ongoing',
	},
	{
		id: 1,
		rank: '1',
		title: 'One Piece',
		author: 'Eiichiro Oda',
		genre: 'Action',
		magazine: 'One Piece',
		start_date: '1999-12-31',
		status: 'Ongoing',
	},
	{
		id: 1,
		rank: '1',
		title: 'One Piece',
		author: 'Eiichiro Oda',
		genre: 'Action',
		magazine: 'One Piece',
		start_date: '1999-12-31',
		status: 'Ongoing',
	},
	{
		id: 1,
		rank: '1',
		title: 'One Piece',
		author: 'Eiichiro Oda',
		genre: 'Action',
		magazine: 'One Piece',
		start_date: '1999-12-31',
		status: 'Ongoing',
	},
	{
		id: 1,
		rank: '1',
		title: 'One Piece',
		author: 'Eiichiro Oda',
		genre: 'Action',
		magazine: 'One Piece',
		start_date: '1999-12-31',
		status: 'Ongoing',
	},
];

const columns: GridColDef[] = [
	{ field: 'rank', headerName: 'Rank', width: 130 },
	{ field: 'title', headerName: 'Title', width: 130 },
	{ field: 'author', headerName: 'Author', width: 130 },
	{ field: 'genre', headerName: 'Genre', width: 130 },
	{ field: 'magazine', headerName: 'Magazine', width: 130 },
	{ field: 'start_date', headerName: 'Release Date', width: 130 },
	{ field: 'status', headerName: 'Status', width: 130 },
];

export default function Mangas() {
	return (
		<Box>
			<Box>
				<DataGrid
					disableSelectionOnClick={true}
					rows={mockData}
					columns={columns}
					pageSize={5}
					autoHeight
					components={{
						Toolbar: GridToolbar,
					}}
				/>
			</Box>
		</Box>
	);
}
