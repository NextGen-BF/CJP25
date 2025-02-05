import { FC } from "react";
import { NavLink } from "react-router-dom";

const PropertyFeesPage: FC = () => {
  return (
    <>
      <h1>Apartment Fees Page</h1>
      <button><NavLink to="/create/propertyexpense">Create Property Expense</NavLink></button>
    </>
  );
};
export default PropertyFeesPage;
