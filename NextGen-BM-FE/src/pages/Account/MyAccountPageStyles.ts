import { SxProps } from "@mui/material";

export const profilePageStyles : {[key:string]:SxProps} = {
    profileCardStyles: {
        display:'flex',
        flexDirection:'column',
        alignItems:'center',
        justifyContent:'space-between',
        width: '40%',
        boxSizing: 'border-box',
        margin: '5em auto',
        padding: '1em'
    },
    fieldsContainerStyles: {
        width: '60%',
        fontFamily: 'Arial, Helvetica, sans-serif'
    },
    fieldStyles: {
        width: 'full',
        display: 'flex',
        flexDirection: 'row',
        justifyContent:'space-between'
    }
}