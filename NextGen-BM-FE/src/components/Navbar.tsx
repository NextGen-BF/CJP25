import React from "react"
import { NavLink } from "react-router-dom"

export const Navbar = () => {
    return (
        <nav>
            <ul>
                <li>
                    <NavLink to='/'>Home</NavLink>
                </li>
                <li>
                    <NavLink to='/login'>Log in</NavLink>
                </li>
            </ul>
        </nav>
    )
}