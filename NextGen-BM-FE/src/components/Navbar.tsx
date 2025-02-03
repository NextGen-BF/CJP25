import { FC } from "react";
import { Link, NavLink } from "react-router-dom";
import { Accordion, AccordionDetails, AccordionSummary, Breadcrumbs, Button, Drawer, Menu, MenuItem, MenuList } from "@mui/material";
import { navbarStyles } from "./NavbarStyles";


const Navbar: FC = () => {
  return (
    <Drawer
    sx={navbarStyles.drawerStyles}
    variant="permanent"
    PaperProps={{
      sx: navbarStyles.paperProps
    }}>
      <Accordion>
        <AccordionSummary>
          <Button>Requests</Button>
        </AccordionSummary>
        <AccordionDetails>
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
        </AccordionDetails>  
      </Accordion>  
      <Accordion>
        <AccordionSummary>
          <Button>Payments</Button>
        </AccordionSummary>
        <AccordionDetails>
          <MenuList>
            <MenuItem>
              <NavLink to="/payment">Payment</NavLink>
            </MenuItem>
            <MenuItem>
              <NavLink to="/property/fees">property Fees</NavLink>
            </MenuItem>
          </MenuList>
        </AccordionDetails>
      </Accordion>  
      <Accordion>
        <AccordionSummary>
          <Button>Properties</Button>
        </AccordionSummary>
        <AccordionDetails> 
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
        </AccordionDetails> 
      </Accordion>
      <Accordion>
        <AccordionSummary> 
          <Button>Building</Button>
        </AccordionSummary>   
        <AccordionDetails>  
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
        </AccordionDetails> 
      </Accordion>
      <NavLink to="/signup">Sign up</NavLink>
      <NavLink to="/recover">Recover Account</NavLink>
      <Button>
        <NavLink to="/account">Profile</NavLink>
      </Button>
      <Breadcrumbs>
      </Breadcrumbs>  
    </Drawer>
  );
};
export default Navbar;
