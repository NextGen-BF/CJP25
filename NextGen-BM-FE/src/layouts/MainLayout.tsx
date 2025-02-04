import { FC } from "react";
import Navbar from "../components/Navbar/Navbar.tsx";
import { Outlet } from "react-router-dom";
import { Box } from "@mui/material";
import { Header } from "../components/Header/Header.tsx";

const MainLayout: FC = () => {
  return (
    <Box sx={{ display: 'flex', flexDirection:'row', flexWrap: 'wrap'}}>
      <Navbar />
      <Box sx={{ display: 'flex', flexDirection:'column', flexWrap: 'wrap', width:'70%', margin:0}}>
        <Header />
        <Outlet />
      </Box>
    </Box>
  );
};
export default MainLayout;