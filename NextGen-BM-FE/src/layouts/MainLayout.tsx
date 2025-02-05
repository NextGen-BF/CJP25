import { FC } from "react";
import Navbar from "../components/Navbar";
import { Outlet } from "react-router-dom";
import { Button } from "@mui/material";
import { useAppDispatch } from "../redux/store";
import { logout } from "../redux/slices/loginSlice";
import { logOut } from "../constants/constants";

const MainLayout: FC = () => {
  const dispatch = useAppDispatch();
  return (
    <>
      <Button onClick={() => dispatch(logout())}>
        {logOut.logout}
      </Button>
      <Navbar />
      <Outlet />
    </>
  );
};
export default MainLayout;