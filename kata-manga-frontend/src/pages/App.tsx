import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Home from './Home';
import Layout from './Layout';
import MangaDetail from './MangaDetail';
import Mangas from './Mangas';

function App() {
	return (
		<BrowserRouter>
			<Routes>
				<Route path="/" element={<Layout />}>
					<Route index element={<Home />} />
					<Route path="mangas" element={<Mangas />} />
					<Route path="mangadetail/:id" element={<MangaDetail />} />
				</Route>
			</Routes>
		</BrowserRouter>
	);
}

export default App;
