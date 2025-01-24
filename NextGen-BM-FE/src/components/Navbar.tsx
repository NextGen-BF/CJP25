import { FC } from "react";
import { NavLink } from "react-router-dom";

const Navbar: FC = () => {
  return (
    <nav>
      <ul>
        <li>
          <NavLink to="/">Home</NavLink>
        </li>
        <li>
          <NavLink to="/login">Log in</NavLink>
        </li>
        <li>
          <NavLink to="/create/apartment">Create Apartment</NavLink>
        </li>
        <li>
          <NavLink to="/apartments">Apartments List</NavLink>
        </li>
        <li>
          <NavLink to="/apartment">Apartment Details</NavLink>
        </li>
        <li>
          <NavLink to="/apartment/residents">Apartment Residents</NavLink>
        </li>
      </ul>
    </nav>
  );
};
export default Navbar;
