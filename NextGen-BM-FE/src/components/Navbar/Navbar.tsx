import { FC, useState } from "react";
import { NavLink } from "react-router-dom";
import { Accordion, AccordionDetails, AccordionSummary, Breadcrumbs, Button, Drawer, Menu, MenuItem, MenuList } from "@mui/material";
import { navbarStyles } from "./NavbarStyles.ts";
import { navbarMenuProps } from "../../constants/navbarMenuConstants.ts";
import { NavigationSubMenu } from "./NavigationSubMenu.tsx";
import { RootState, store } from "../../redux/store.ts";
import "./navbar.scss";
import { useSelector } from "react-redux";


const Navbar: FC = () => {
  const drawerMenus=navbarMenuProps.map(props=>
    <NavigationSubMenu groupTitle={props.groupTitle} groupLinks={props.groupLinks}/>
  );
  const drawerOpen=useSelector((state:RootState)=>state.navigationReducer.open);
  return (
    <Drawer
    sx={navbarStyles.drawerStyles}
    variant='persistent'
    open={drawerOpen}
    PaperProps={{
      sx: navbarStyles.paperProps
    }}>
      {drawerMenus}
      <Button sx={{marginTop:'auto'}}>
        <NavLink className={'submenu-link'} to="/account">Profile</NavLink>
      </Button>
    </Drawer>
  );
};
export default Navbar;
