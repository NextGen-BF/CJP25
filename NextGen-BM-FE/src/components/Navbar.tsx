import { FC } from "react";
import { Link, NavLink } from "react-router-dom";
import { Breadcrumbs, Button, Drawer, Menu, MenuItem, MenuList } from "@mui/material";


const Navbar: FC = () => {
  return (
    <Drawer
    sx={{
      flexShrink: 0,
      boxSizing:'border-box',
      width:'30%'
    }}
    variant="permanent">
      <NavLink to="/">Home</NavLink>
      <NavLink to="/login">Log in</NavLink>
      <Button>Requests</Button>
      <MenuList>
          <MenuItem>
            <NavLink to="/create/request">Create Request</NavLink>
          </MenuItem>
          <MenuItem>
            <NavLink to="/requests">Requests List</NavLink>
          </MenuItem>
          <MenuItem>
            <NavLink to="/request">Request Details</NavLink>
          </MenuItem>
      </MenuList>
      <Button>Payments</Button>
      <MenuList>
        <MenuItem>
          <NavLink to="/payment">Payment</NavLink>
          <NavLink to="/property/fees">property Fees</NavLink>
        </MenuItem>
      </MenuList>
      <Button>Properties</Button>
      <MenuList>
        <MenuItem>
          <NavLink to="/properties">properties List</NavLink>
        </MenuItem>
        <MenuItem>
          <NavLink to="/property">property Details</NavLink>
        </MenuItem>
        <MenuItem>
          <NavLink to="/create/property">Create property</NavLink>
        </MenuItem>
        <MenuItem>
          <NavLink to="/property/residents">property Residents</NavLink>
        </MenuItem>
        <MenuItem>
        </MenuItem>
      </MenuList>
      <NavLink to="/signup">Sign up</NavLink>
      <NavLink to="/recover">Recover Account</NavLink>
      <NavLink to="/account">My Account</NavLink>
      <Button>Building</Button>
      <MenuList>
        <MenuItem>
          <NavLink to="/building">Building Details</NavLink>
        </MenuItem>
        <MenuItem>
          <NavLink to="/create/building">Create Building</NavLink>
        </MenuItem>
        <MenuItem>
          <NavLink to="/buildings">Buildings List</NavLink>
        </MenuItem>
        <MenuItem>
          <NavLink to="/building/expenses">Building Expenses</NavLink>
        </MenuItem>
      </MenuList>
      <Breadcrumbs>
      </Breadcrumbs>  
    </Drawer>
  );
};
export default Navbar;
