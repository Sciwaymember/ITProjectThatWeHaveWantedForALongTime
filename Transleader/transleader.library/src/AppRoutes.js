import BookVariantPage from "./components/BookVariantPage";
import HomePage from "./components/HomePage";

const AppRoutes = [
  {
    index: true,
    element: <HomePage />
  },
  {
    path: '/book/:bookID',
    element: <BookVariantPage/>
  }
];

export default AppRoutes;
