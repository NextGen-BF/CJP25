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
          <NavLink to="/create/request">Create Request</NavLink>
        </li>
        <li>
          <NavLink to="/requests">Requests List</NavLink>
        </li>
        <li>
          <NavLink to="/request">Request Details</NavLink>
        </li>
      </ul>
    </nav>
  );
};
export default Navbar;
