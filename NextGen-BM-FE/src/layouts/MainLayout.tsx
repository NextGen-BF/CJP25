import { FC } from "react";
import Navbar from "../components/Navbar/Navbar.tsx";
import { Outlet } from "react-router-dom";
import { Box } from "@mui/material";
import { Header } from "../components/Header/Header.tsx";
import { mainLayoutStyles } from "./MainLayoutStyles.ts";
import { useSelector } from "react-redux";
import { RootState } from "../redux/store.ts";

const MainLayout: FC = () => {
  const drawerOpen = useSelector(
    (state: RootState) => state.navigationReducer.open,
  );
  const DRAWER_WIDTH = "20rem";

  return (
    <Box sx={mainLayoutStyles.mainContainerStyle}>
      <Navbar />

      <Box
        sx={{
          ...mainLayoutStyles.contentContainerStyle,
          transition: "margin 0.3s ease-in-out, width 0.3s ease-in-out",
          marginLeft: drawerOpen ? DRAWER_WIDTH : "0",
          width: drawerOpen ? `calc(100% - ${DRAWER_WIDTH})` : "100%",
          flexGrow: 1, 
        }}
      >
        
        <Header/>
        <Outlet />
      </Box>
    </Box>
  );
};
export default MainLayout;
