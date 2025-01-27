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
          <NavLink to="/signup">Sign up</NavLink>
        </li>
        <li>
          <NavLink to="/recover">Recover Account</NavLink>
        </li>
        <li>
          <NavLink to="/account">My Account</NavLink>
        </li>
      </ul>
    </nav>
  );
};
export default Navbar;
