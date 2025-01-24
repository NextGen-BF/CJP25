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
          <NavLink to="/building/expenses">Building Expenses</NavLink>
        </li>
        <li>
          <NavLink to="/apartment/fees">Apartment Fees</NavLink>
        </li>
        <li>
          <NavLink to="/payment">Payment</NavLink>
        </li>
      </ul>
    </nav>
  );
};
export default Navbar;
