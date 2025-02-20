import {
  createBrowserRouter,
  createRoutesFromElements,
  Route,
  RouterProvider,
} from "react-router-dom";
import MainLayout from "./layouts/MainLayout";
import LoginPage from "./pages/Account/Log In/LoginPage";
import HomePage from "./pages/HomePage";
import { FC } from "react";
import CreateRequestPage from "./pages/Requests/CreateRequestPage";
import RequestsListPage from "./pages/Requests/RequestsListPage";
import RequestPage from "./pages/Requests/RequestPage";
import BuildingExpensesPage from "./pages/Buildings/BuildingExpensesPage";
import PropertyFeesPage from "./pages/Properties/PropertyFeesPage";
import PaymentPage from "./pages/Payments/PaymentPage";
import CreatePropertyPage from "./pages/Properties/Create/CreatePropertyPage";
import PropertyListPage from "./pages/Properties/PropertyListPage";
import PropertyPage from "./pages/Properties/PropertyPage";
import PropertyResidentsPage from "./pages/Properties/PropertyResidentsPage";
import SignupPage from "./pages/Account/Sign Up/SignupPage";
import MyAccountPage from "./pages/Account/MyAccountPage";
import AccountRecoveryPage from "./pages/Account/AccountRecoveryPage";
import CreateBuildingPage from "./pages/Buildings/Create/CreateBuildingPage";
import BuildingsListPage from "./pages/Buildings/BuildingListPage";
import BuildingPage from "./pages/Buildings/BuildingPage";
import CreatePropertyPaymentsPage from "./pages/Properties/CreatePropertyPaymentsPage";
import CreatePropertyExpensePage from "./pages/Properties/CreatePropertyExpensePage";
import Snackbar from "./pages/Snackbar";

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
        <Route
          path="/create/propertypayments"
          element={<CreatePropertyPaymentsPage />}
        />
        <Route
          path="/create/propertyexpense"
          element={<CreatePropertyExpensePage />}
        />
        <Route path="/payment" element={<PaymentPage />} />
      </Route>,
    ),
  );
  return (
    <>
      <Snackbar />
      <RouterProvider router={router} />;
    </>
  );
};

export default App;
