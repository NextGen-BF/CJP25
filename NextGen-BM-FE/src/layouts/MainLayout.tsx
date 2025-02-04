import { FC } from "react";
import Navbar from "../components/Navbar/Navbar.tsx";
import { Outlet } from "react-router-dom";
import { Box } from "@mui/material";
import { Header } from "../components/Header/Header.tsx";

const MainLayout: FC = () => {
  return (
    <Box sx={{ display: 'flex', flexWrap: 'wrap' }}>
      <Header />
      <Navbar />
      <Outlet />
    </Box>
  );
};
export default MainLayout;