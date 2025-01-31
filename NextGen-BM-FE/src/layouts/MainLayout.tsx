import { FC } from "react";
import Navbar from "../components/Navbar";
import { Outlet } from "react-router-dom";
import { Box } from "@mui/material";

const MainLayout: FC = () => {
  return (
    <Box sx={{ display: 'flex' }}>
      <Navbar />
      <Outlet />
    </Box>
  );
};
export default MainLayout;