import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { Property } from "../../models/property";
import { getProperties, getProperty, updateProperty } from "../services/propertyService";

interface PropertyState {
    value: Property[],
    current: number|undefined
}

const initialState: PropertyState = {
    value: [],
    current: undefined
}

const propertySlice = createSlice({
    name: "Property",
    initialState,
    reducers: {
        addProperty: (state, action: PayloadAction<Property>) => {
            state.value = [...state.value, action.payload]
        },
        removeProperty: (state, action: PayloadAction<Property>) => {
            state.value = state.value.filter(property => property.propertyId != action.payload.propertyId)
        }
    },
    extraReducers: (builder)=> {
        builder.addCase(getProperty.fulfilled, (state, action: PayloadAction<Property>) => {
                state.value = [...state.value]
                state.value = state.value.filter(property => property.propertyId != action.payload.propertyId)
                state.value = [...state.value, action.payload]
                state.current = action.payload.propertyId
              }),
        builder.addCase(updateProperty.fulfilled, (state, action: PayloadAction<Property>) => {
                state.value = [...state.value]
                state.value = state.value.filter(property => property.propertyId != action.payload.propertyId)
                state.value = [...state.value, action.payload]
        })
        builder.addCase(getProperties.fulfilled, (state, action: PayloadAction<Property[]>) => {
            state.value = action.payload
    })
    }
})

export const { addProperty, removeProperty } = propertySlice.actions;

export default propertySlice.reducer;