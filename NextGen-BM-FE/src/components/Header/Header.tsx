import { FC } from "react";
import { NavLink, useLocation } from "react-router-dom";
import { AppBar, Button } from "@mui/material";
import { headerStyles } from "./HeaderStyles.ts";
import "./header.scss"
import { store } from "../../redux/store.ts";
import { pageTitles } from "../../constants/pageTitlesConstant.ts";

export const Header: FC = () => {
    const userToken = store.getState().loginReducer.value;
    const location=useLocation().pathname;
    return (
        <AppBar sx={headerStyles.appBarStyles}>
            <Button>0</Button>
            <NavLink className={'header-link'} to="/">Home</NavLink>
            <span className={'header-link'}>{pageTitles[location]}</span>
            {/* todo: put logout here */}
            {userToken.accessToken?"":<NavLink className={'header-link'} to="/login">Log in</NavLink>}
        </AppBar>
    );
};