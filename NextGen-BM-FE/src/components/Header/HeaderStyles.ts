import { SxProps } from "@mui/material";
import { navbarStyles } from "../Navbar/NavbarStyles";

export const headerStyles:{[key:string]:SxProps}={
    appBarStyles:{
        position: 'sticky',
        width: '100%',
        display: 'flex',
        flexDirection: 'row',
        alignItems: 'center',
        justifyContent: 'space-between',
        textAlign: 'center',
        height: '3rem',
    }
};
