import { Button } from "@mui/material";
import { FC } from "react";
import { NavLink } from "react-router-dom";

const PropertyFeesPage: FC = () => {
  return (
    <>
      <h1>Apartment Fees Page</h1>
      <Button variant="contained"><NavLink style={{ textDecoration: 'none', color: 'white' }} to="/create/propertyexpense">Create Property Expense</NavLink></Button>
    </>
  );
};
export default PropertyFeesPage;
