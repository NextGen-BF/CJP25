import { FC } from "react";
import Navbar from "../components/Navbar";
import { Outlet } from "react-router-dom";

export const MainLayout: FC = () => {
  return (
    <>
      <Navbar />
      <Outlet />
    </>
  );
};
