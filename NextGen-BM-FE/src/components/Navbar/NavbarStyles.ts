import { SxProps } from "@mui/material";
import { headerStyles } from "../Header/HeaderStyles";

export const navbarStyles:{[key:string]:SxProps}={
    drawerStyles:{
        flexShrink:1,
        boxSizing:'border-box',
        width: '20rem'
    },
    paperProps:{
        //keyof typeof here so ts won't complain
        boxSizing:'border-box',
        paddingTop: headerStyles.appBarStyles!['height' as keyof typeof headerStyles.appBarStyles],
        //this shouldn't be hard-coded
        width: '20rem'
    }
}