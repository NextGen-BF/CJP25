import { TextField } from "@mui/material";
import { FC } from "react";
import { Control, Controller} from "react-hook-form";
import { createPropertyPageStyles } from "./CreatePropertyPageStyles";

export interface InputProps{
    name: string,
    label: string,
    type: string,
    required: boolean,
    control: Control
}

export const CreatePropertyInput: FC<InputProps> = (props)=>{
    return (
        <Controller
          name={props.name}
          control={props.control}
          render={({ field }) => (
            <TextField
            {...field}
            sx={createPropertyPageStyles.inputStyles}
            required={props.required}
            label={props.label}
            type={props.type}
            variant="outlined"
            size="small"
            />
          )}
        />
    )
}