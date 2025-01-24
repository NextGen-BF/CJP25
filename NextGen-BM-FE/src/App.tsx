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

const App: FC = () => {
  const router = createBrowserRouter(
    createRoutesFromElements(
      <Route path="/" element={<MainLayout />}>
        <Route index element={<HomePage />} />
        <Route path="/login" element={<LoginPage />} />
        <Route path="/create/request" element={<CreateRequestPage />} />
        <Route path="/requests" element={<RequestsListPage />} />
        <Route path="/request" element={<RequestPage />} />
      </Route>,
    ),
  );
  return <RouterProvider router={router} />;
};

export default App;
