import { TextField } from "@mui/material";
import { FC } from "react";
import { Control, Controller, FieldValues, RegisterOptions } from "react-hook-form";
import { createPropertyPageStyles } from "./CreatePropertyPageStyles";
import { Property } from "../../../models/property";

export interface InputProps{
    name: string,
    label: string,
    type: string,
    required: boolean,
    rules: Object,
    control: Control
}

export const CreatePropertyInput: FC<InputProps> = (props)=>{
    return (
        <Controller
          name={props.name}
          control={props.control}
          rules={props.rules}
          render={({ field, fieldState: { error }}) => (
            <TextField
            {...field}
            sx={createPropertyPageStyles.inputStyles}
            required={props.required}
            label={props.label}
            type={props.type}
            variant="outlined"
            size="small"
            error={error!==undefined}
            />
          )}
        />
    )
}