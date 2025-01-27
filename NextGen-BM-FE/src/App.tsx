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
import CreateRequestPage from "./pages/CreateRequestPage";
import RequestsListPage from "./pages/RequestsListPage";
import RequestPage from "./pages/RequestPage";
import BuildingExpensesPage from "./pages/BuildingExpensesPage";
import ApartmentFeesPage from "./pages/ApartmentFeesPage";
import PaymentPage from "./pages/PaymentPage";
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
        <Route path="/create/request" element={<CreateRequestPage />} />
        <Route path="/requests" element={<RequestsListPage />} />
        <Route path="/request" element={<RequestPage />} />
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
        <Route path="/building/expenses" element={<BuildingExpensesPage />} />
        <Route path="/apartment/fees" element={<ApartmentFeesPage />} />
        <Route path="/payment" element={<PaymentPage />} />
      </Route>,
    ),
  );
  return <RouterProvider router={router} />;
};

export default App;
