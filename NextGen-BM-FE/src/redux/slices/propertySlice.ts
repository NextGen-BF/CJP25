import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { Property, PropertyType } from "../../models/property";
import { getPropertyTypes } from "../services/propertyService";

interface PropertyState {
    value: Property[],
    types: PropertyType[]
}

const initialState: PropertyState = {
    value: [],
    types: []
}

const propertySlice = createSlice({
    name: "Property",
    initialState,
    reducers: {
        addProperty: (state, action: PayloadAction<Property>) => {
            state.value = [...state.value, action.payload]
        },
        removeProperty: (state, action: PayloadAction<Property>) => {
            state.value = state.value.filter(property => property.propertyNumber != action.payload.propertyNumber)
        },
        updateProperty: (state, action: PayloadAction<Property>) => {
            state.value = [...state.value]
            state.value = state.value.filter(property => property.propertyNumber != action.payload.propertyNumber)
            state.value = [...state.value, action.payload]
        }
    },
    extraReducers: (builder) => {
        builder.addCase(getPropertyTypes.fulfilled, (state, action: PayloadAction<PropertyType[]>) => {
            state.types=action.payload;
            })
        }
    }
)


export const { addProperty, removeProperty, updateProperty } = propertySlice.actions;

export default propertySlice.reducer;