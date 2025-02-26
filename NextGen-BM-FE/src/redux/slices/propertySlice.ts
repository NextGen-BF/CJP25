import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { Property } from "../../models/property";
import { deleteProperty, getProperties, getProperty } from "../services/propertyService";

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
        resetProperties: () => initialState,
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
    extraReducers: (builder)=> {
        builder.addCase(getProperty.fulfilled, (state, action: PayloadAction<Property>) => {
                state.value = [...state.value]
                state.value = state.value.filter(property => property.propertyId != action.payload.propertyId)
                state.value = [...state.value, action.payload]
                state.current = action.payload.propertyId
              }),
        builder.addCase(getProperties.fulfilled, (state, action: PayloadAction<Property[]>) => {
            state.value = action.payload       
            }),
        builder.addCase(deleteProperty.fulfilled, (state, action: PayloadAction<number>) => {
            state.value = state.value.filter(property => property.propertyId != action.payload)       
            })   
    }
})

export const { addProperty, removeProperty, updateProperty, resetProperties } = propertySlice.actions;

export default propertySlice.reducer;