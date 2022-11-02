import BookVariantPage from "./components/BookVariantPage";
import HomePage from "./components/HomePage";

const AppRoutes = [
  {
    index: true,
    element: <HomePage />
  },

  {
    path: '/book/*',
    element: <BookVariantPage/>
  }
];

export default AppRoutes;
