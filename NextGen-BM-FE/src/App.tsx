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
import PropertyFeesPage from "./pages/Properties/PropertyFeesPage";
import PaymentPage from "./pages/PaymentPage";
import SignupPage from "./pages/SignupPage";
import MyAccountPage from "./pages/MyAccountPage";
import AccountRecoveryPage from "./pages/AccountRecoveryPage";
import CreatePropertyPage from "./pages/Properties/CreatePropertyPage";
import PropertyListPage from "./pages/Properties/PropertyListPage";
import PropertyPage from "./pages/Properties/PropertyPage";
import PropertyResidentsPage from "./pages/Properties/PropertyResidentsPage";
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
        <Route path="/create/property" element={<CreatePropertyPage />} />
        <Route path="/properties" element={<PropertyListPage />} />
        <Route path="/property" element={<PropertyPage />} />
        <Route path="/property/residents" element={<PropertyResidentsPage />} />
        <Route path="/signup" element={<SignupPage />} />
        <Route path="/account" element={<MyAccountPage />} />
        <Route path="/recover" element={<AccountRecoveryPage />} />
        <Route path="/create/building" element={<CreateBuildingPage />} />
        <Route path="/buildings" element={<BuildingsListPage />} />
        <Route path="/building" element={<BuildingPage />} />
        <Route path="/building/expenses" element={<BuildingExpensesPage />} />
        <Route path="/property/fees" element={<PropertyFeesPage />} />
        <Route path="/payment" element={<PaymentPage />} />
      </Route>,
    ),
  );
  return <RouterProvider router={router} />;
};

export default App;
