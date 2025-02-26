import './App.css';
import HomePage from './Pages/HomePage';

import Layout from './Components/Layout';
import {
  createBrowserRouter,
  RouterProvider,
} from "react-router";
import AboutPage from './Pages/AboutPage';
import Error404 from './Pages/Error404';
import AddListing from './Pages/AddListing';

const browserRouter = createBrowserRouter(
  [{
    element: <Layout />, 
    errorElement: <Error404/>,
    children: [
      {path:'/', element: <HomePage />},
      {path: 'about', element: <AboutPage />},
      {path: 'addListing', element: <AddListing />}
    ]
  }]
)

function App() {
  return (
      <RouterProvider router={browserRouter} />
  );
}

export default App;
