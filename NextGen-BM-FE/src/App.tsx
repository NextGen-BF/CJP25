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
import SignupPage from "./pages/SignupPage";
import MyAccountPage from "./pages/MyAccountPage";
import AccountRecoveryPage from "./pages/AccountRecoveryPage";
import CreateBuildingPage from "./pages/CreateBuildingPage";
import BuildingsListPage from "./pages/BuildingListPage";
import BuildingPage from "./pages/BuildingPage";

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
        <Route path="/signup" element={<SignupPage />} />
        <Route path="/account" element={<MyAccountPage />} />
        <Route path="/recover" element={<AccountRecoveryPage />} />
        <Route path="/create/building" element={<CreateBuildingPage />} />
        <Route path="/buildings" element={<BuildingsListPage />} />
        <Route path="/building" element={<BuildingPage />} />
      </Route>,
    ),
  );
  return <RouterProvider router={router} />;
};

export default App;
