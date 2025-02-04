import { FC } from "react";
import { NavLink } from "react-router-dom";
import { AppBar } from "@mui/material";
import { headerStyles } from "./HeaderStyles.ts";
import "./header.scss"
import { store } from "../../redux/store.ts";

export const Header: FC = () => {
    const userToken = store.getState().loginReducer.value;
    return (
        <AppBar sx={headerStyles.appBarStyles}>
            <NavLink className={'header-link'} to="/">Home</NavLink>
            <span className={'header-link'}>Title</span>
            {/* todo: put logout here */}
            {userToken.accessToken?"":<NavLink className={'header-link'} to="/login">Log in</NavLink>}
        </AppBar>
    );
};