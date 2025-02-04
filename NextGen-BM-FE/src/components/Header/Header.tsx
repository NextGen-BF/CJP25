import { FC } from "react";
import { NavLink } from "react-router-dom";
import { AppBar } from "@mui/material";
import { headerStyles } from "./HeaderStyles";

export const Header: FC = () => {
    return (
        <AppBar sx={headerStyles.appBarStyles}>
            <NavLink to="/">Home</NavLink>
            <span>Title</span>
            <NavLink to="/login">Log in</NavLink>
        </AppBar>
    );
};