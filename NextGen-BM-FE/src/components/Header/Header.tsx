import { FC } from "react";
import { NavLink } from "react-router-dom";
import { AppBar } from "@mui/material";
import { headerStyles } from "./HeaderStyles.ts";
import "./header.scss"

export const Header: FC = () => {
    return (
        <AppBar sx={headerStyles.appBarStyles}>
            <NavLink className={'header-link'} to="/">Home</NavLink>
            <span className={'header-link'}>Title</span>
            <NavLink className={'header-link'} to="/login">Log in</NavLink>
        </AppBar>
    );
};