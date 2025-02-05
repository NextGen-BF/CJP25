import { SxProps, useTheme } from "@mui/material";

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
        boxSizing: 'border-box',
        padding: '1em',
        zIndex:1400
    }
};
