
import { Colocviu } from './components/Colocviu'
import { Home } from "./components/Home";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/colocviu',
    element: <Colocviu />
  },
  {
  }
];

export default AppRoutes;
