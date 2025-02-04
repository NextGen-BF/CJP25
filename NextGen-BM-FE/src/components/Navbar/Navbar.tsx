import { FC } from "react";
import { NavLink } from "react-router-dom";
import { Accordion, AccordionDetails, AccordionSummary, Breadcrumbs, Button, Drawer, Menu, MenuItem, MenuList } from "@mui/material";
import { navbarStyles } from "./NavbarStyles.ts";
import { navbarMenuProps } from "../../constants/navbarMenuConstants.ts";
import { NavigationSubMenu } from "./NavigationSubMenu.tsx";


const Navbar: FC = () => {
  const drawerMenus=navbarMenuProps.map(props=>
    <NavigationSubMenu groupTitle={props.groupTitle} groupLinks={props.groupLinks}/>
  );
  return (
    <Drawer
    sx={navbarStyles.drawerStyles}
    variant="permanent"
    PaperProps={{
      sx: navbarStyles.paperProps
    }}>
      {drawerMenus}
      <Button sx={{marginTop: "auto"}}>
        <NavLink to="/account">Profile</NavLink>
      </Button>
    </Drawer>
  );
};
export default Navbar;
