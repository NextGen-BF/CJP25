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
import BuildingExpensesPage from "./pages/BuildingExpensesPage";
import ApartmentFeesPage from "./pages/ApartmentFeesPage";
import PaymentPage from "./pages/PaymentPage";

const App: FC = () => {
  const router = createBrowserRouter(
    createRoutesFromElements(
      <Route path="/" element={<MainLayout />}>
        <Route index element={<HomePage />} />
        <Route path="/login" element={<LoginPage />} />
        <Route path="/building/expenses" element={<BuildingExpensesPage />} />
        <Route path="/apartment/fees" element={<ApartmentFeesPage />} />
        <Route path="/payment" element={<PaymentPage />} />
      </Route>,
    ),
  );
  return <RouterProvider router={router} />;
};

export default App;
