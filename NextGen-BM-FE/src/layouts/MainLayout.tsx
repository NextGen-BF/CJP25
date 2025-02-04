import { FC } from "react";
import Navbar from "../components/Navbar/Navbar.tsx";
import { Outlet } from "react-router-dom";
import { Box } from "@mui/material";
import { Header } from "../components/Header/Header.tsx";
import { mainLayoutStyles } from "./MainLayoutStyles.ts";

const MainLayout: FC = () => {
  return (
    <Box sx={mainLayoutStyles.mainContainerStyle}>
      <Navbar />
      <Box sx={mainLayoutStyles.contentContainerStyle}>
        <Header />
        <Outlet />
      </Box>
    </Box>
  );
};
export default MainLayout;