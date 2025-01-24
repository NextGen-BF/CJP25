import {
  createBrowserRouter,
  createRoutesFromElements,
  Route,
  RouterProvider,
} from "react-router-dom";
import MainLayout from "./layouts/MainLayout";
import LoginPage from "./pages/LoginPage";
import HomePage from "./pages/HomePage";
import { FC } from "react";
import CreateApartmentPage from "./pages/CreateApartmentPage";
import ApartmentsListPage from "./pages/ApartmentsListPage";
import ApartmentPage from "./pages/ApartmentPage";
import ApartmentResidentsPage from "./pages/ApartmentResidentsPage";

const App: FC = () => {
  const router = createBrowserRouter(
    createRoutesFromElements(
      <Route path="/" element={<MainLayout />}>
        <Route index element={<HomePage />} />
        <Route path="/login" element={<LoginPage />} />
        <Route path="/create/apartment" element={<CreateApartmentPage />} />
        <Route path="/apartments" element={<ApartmentsListPage />} />
        <Route path="/apartment" element={<ApartmentPage />} />
        <Route path="/apartment/residents" element={<ApartmentResidentsPage />} />
      </Route>,
    ),
  );
  return <RouterProvider router={router} />;
};

export default App;
