import { SxProps } from "@mui/material";

export const mainLayoutStyles:{[key:string]:SxProps}={
    mainContainerStyle:{
        display: 'flex',
        flexDirection:'row',
        flexWrap: 'wrap'
    },
    contentContainerStyle:{
        display: 'flex',
        flexDirection:'column',
        flexWrap: 'wrap',
        width:"100%"
    }
};