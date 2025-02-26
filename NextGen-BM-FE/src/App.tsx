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
import ProtectedRoute from "./pages/ProtectedRoute";
import { useSelector } from "react-redux";
import { RootState } from "./redux/store";

const App: FC = () => {
  const userId = useSelector((state: RootState) => state.loginReducer.value.userId);
  
  const router = createBrowserRouter(
    createRoutesFromElements(
      <Route path="/" element={<MainLayout />}>
        <Route index element={<HomePage />} />
        <Route path="/login" element={<LoginPage />} />
        <Route path="/create/request" element={<ProtectedRoute element={<CreateRequestPage />} userId={userId} />} />
        <Route path="/requests" element={<ProtectedRoute element={<RequestsListPage />} userId={userId} />} />
        <Route path="/request" element={<ProtectedRoute element={<RequestPage />} userId={userId} />} />
        <Route path="/create/property" element={<ProtectedRoute element={<CreatePropertyPage />} userId={userId} />} />
        <Route path="/properties" element={<ProtectedRoute element={<PropertyListPage />} userId={userId} />} />
        <Route path="/property/:id?" element={<ProtectedRoute element={<PropertyPage />} userId={userId} />} />
        <Route path="/property/residents" element={<ProtectedRoute element={<PropertyResidentsPage /> } userId={userId} />} />
        <Route path="/signup" element={<SignupPage />} />
        <Route path="/account" element={<ProtectedRoute element={<MyAccountPage />} userId={userId} />} />
        <Route path="/recover" element={<ProtectedRoute element={<AccountRecoveryPage />} userId={userId} />} />
        <Route path="/create/building" element={<ProtectedRoute element={<CreateBuildingPage />} userId={userId} />} />
        <Route path="/buildings" element={<ProtectedRoute element={<BuildingsListPage />} userId={userId} />} />
        <Route path="/building/:id?" element={<ProtectedRoute element={<BuildingPage />} userId={userId} />} />
        <Route path="/building/expenses" element={<ProtectedRoute element={<BuildingExpensesPage />} userId={userId} />} />
        <Route path="/property/fees" element={<ProtectedRoute element={<PropertyFeesPage />} userId={userId} />} />
        <Route
          path="/create/propertypayments"
          element={<ProtectedRoute element={<CreatePropertyPaymentsPage />} userId={userId} />}
        />
        <Route
          path="/create/propertyexpense"
          element={<ProtectedRoute element={<CreatePropertyExpensePage />} userId={userId} />}
        />
        <Route path="/payment" element={<ProtectedRoute element={<PaymentPage />} userId={userId} />} />
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
