import "./utils/init.ts";
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
import CreatePropertyPaymentsPage from "./pages/Properties/CreatePropertyPaymentsPage";
import CreatePropertyExpensePage from "./pages/Properties/CreatePropertyExpensePage";
import Snackbar from "./pages/Snackbar";
import ProtectedRoute from "./pages/ProtectedRoute";
import { useSelector } from "react-redux";
import { RootState } from "./redux/store";
import ForbiddenPage from "./pages/403ForbiddenPage.tsx";

const App: FC = () => {
  const userId = useSelector(
    (state: RootState) => state.loginReducer.value.userId,
  );
  
  const userRole = useSelector(
    (state: RootState) => state.loginReducer.value.role,
  );

  const router = createBrowserRouter(
    createRoutesFromElements(
      <Route path="/" element={<MainLayout />}>
        <Route index element={<HomePage />} />
        <Route path="/login" element={<LoginPage />} />
        <Route
          path="/create/request"
          element={
            <ProtectedRoute
              element={<CreateRequestPage />}
              userId={userId}
              userRole={userRole}
            />
          }
        />
        <Route
          path="/requests"
          element={
            <ProtectedRoute
              element={<RequestsListPage />}
              userId={userId}
              userRole={userRole}
            />
          }
        />
        <Route
          path="/create/property"
          element={
            <ProtectedRoute
              element={<CreatePropertyPage />}
              userId={userId}
              userRole={userRole}
              requiredRole="super"
            />
          }
        />
        <Route
          path="/properties"
          element={
            <ProtectedRoute
              element={<PropertyListPage />}
              userId={userId}
              userRole={userRole}
            />
          }
        />
        <Route
          path="/property/:id?"
          element={
            <ProtectedRoute
              element={<PropertyPage />}
              userId={userId}
              userRole={userRole}
            />
          }
        />
        <Route
          path="/property/residents"
          element={
            <ProtectedRoute
              element={<PropertyResidentsPage />}
              userId={userId}
              userRole={userRole}
            />
          }
        />
        <Route path="/signup" element={<SignupPage />} />
        <Route
          path="/account"
          element={
            <ProtectedRoute
              element={<MyAccountPage />}
              userId={userId}
              userRole={userRole}
            />
          }
        />
        <Route
          path="/recover"
          element={
            <ProtectedRoute
              element={<AccountRecoveryPage />}
              userId={userId}
              userRole={userRole}
            />
          }
        />
        <Route
          path="/create/building"
          element={
            <ProtectedRoute
              element={<CreateBuildingPage />}
              userId={userId}
              userRole={userRole}
              requiredRole="super"
            />
          }
        />
        <Route
          path="/buildings"
          element={
            <ProtectedRoute
              element={<BuildingsListPage />}
              userId={userId}
              userRole={userRole}
            />
          }
        />
        <Route
          path="/building/expenses"
          element={
            <ProtectedRoute
              element={<BuildingExpensesPage />}
              userId={userId}
              userRole={userRole}
              requiredRole="super"
            />
          }
        />
        <Route
          path="/property/fees"
          element={
            <ProtectedRoute
              element={<PropertyFeesPage />}
              userId={userId}
              userRole={userRole}
            />
          }
        />
        <Route
          path="/create/propertypayments"
          element={
            <ProtectedRoute
              element={<CreatePropertyPaymentsPage />}
              userId={userId}
              userRole={userRole}
              requiredRole="super"
            />
          }
        />
        <Route
          path="/create/propertyexpense"
          element={
            <ProtectedRoute
              element={<CreatePropertyExpensePage />}
              userId={userId}
              userRole={userRole}
              requiredRole="super"
            />
          }
        />
        <Route
          path="/payment"
          element={
            <ProtectedRoute
              element={<PaymentPage />}
              userId={userId}
              userRole={userRole}
            />
          }
        />
        <Route path="/forbidden" element={<ForbiddenPage />} />
      </Route>,
    ),
  );
  return (
    <>
      <Snackbar />
      <RouterProvider router={router} />
    </>
  );
};

export default App;
