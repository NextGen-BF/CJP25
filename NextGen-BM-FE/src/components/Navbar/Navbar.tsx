import { FC } from "react";
import { NavLink } from "react-router-dom";
import { Button, Drawer } from "@mui/material";
import { navbarStyles } from "./NavbarStyles.ts";
import { navbarMenuProps } from "../../constants/navbarMenuConstants.ts";
import { NavigationSubMenu } from "./NavigationSubMenu.tsx";
import { RootState } from "../../redux/store.ts";
import "./navbar.scss";
import { useSelector } from "react-redux";

const Navbar: FC = () => {
  const drawerMenus = navbarMenuProps.map((props) => (
    <NavigationSubMenu
      key={props.groupTitle}
      groupTitle={props.groupTitle}
      groupLinks={props.groupLinks}
    />
  ));
  const drawerOpen = useSelector(
    (state: RootState) => state.navigationReducer.open,
  );
  return (
      <Drawer
        sx={navbarStyles.drawerStyles}
        variant="persistent"
        open={drawerOpen}
        PaperProps={{
          sx: navbarStyles.paperProps,
        }}
      >
        {drawerMenus}
        <Button sx={{ marginTop: "auto" }} component={NavLink} to="/account" className={"submenu-link"}>
            Profile
        </Button>
      </Drawer>
  );
};
export default Navbar;
