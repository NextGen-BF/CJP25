import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { Property } from "../../models/property";

interface PropertyState {
    value: Property[]
}

const initialState: PropertyState = {
    value: []
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
})

export const { addProperty, removeProperty, updateProperty } = propertySlice.actions;

export default propertySlice.reducer;