import { FC } from "react";
import { NavLink, useLocation } from "react-router-dom";
import { AppBar, Button, IconButton } from "@mui/material";
import { headerStyles } from "./HeaderStyles.ts";
import "./header.scss"
import { RootState, store, useAppDispatch } from "../../redux/store.ts";
import { pageTitles } from "../../constants/pageTitlesConstant.ts";
import { toggleDrawer } from "../../redux/slices/navigationSlice.ts";
import { useDispatch, useSelector } from "react-redux";
import MenuIcon from '@mui/icons-material/Menu';
import { logout } from "../../redux/slices/loginSlice.ts";

export const Header: FC = () => {
    const userToken = useSelector((state:RootState)=>state.loginReducer.value);
    const location = useLocation().pathname;
    const drawerOpen = useSelector((state:RootState)=>state.navigationReducer.open);
    const dispatch=useAppDispatch();
    const toggle = ()=> dispatch(toggleDrawer());
    return (
        <AppBar sx={headerStyles.appBarStyles}>
            <div className="home-menu-button">
                <IconButton  onClick={()=>toggle()} sx={{color:'white'}}><MenuIcon /></IconButton>
                <NavLink className={'header-link'} to="/">Home</NavLink>
            </div>
            <span className={'header-link'}>{pageTitles[location]}</span>
            {/* todo: put logout here */}
            {userToken.token?<NavLink className={'header-link'} onClick={() => dispatch(logout())} to="/login">Log Out</NavLink>:<NavLink className={'header-link'} to="/login">Log in</NavLink>}
        </AppBar>
    );
};