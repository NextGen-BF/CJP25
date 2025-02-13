import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { Property } from "../../models/property";
import { getProperty } from "../services/propertyService";

interface PropertyState {
    value: Property[],
    current: number
}

const initialState: PropertyState = {
    value: [{
        propertyId: 0,
        propertyNumber: 0,
        buildingId: 0,
        size: 0,
        floor: 1,
        sizeOfIdealParts: 0,
        entranceIsExternal: false,
        payments: null,
        residentHistory: null
    }],
    current: 0
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
            state.value = state.value.filter(property => property.propertyId != action.payload.propertyId)
            state.value = [...state.value, action.payload]
        }
    },
    extraReducers: (builder)=> {
        builder.addCase(getProperty.fulfilled, (state, action: PayloadAction<Property>) => {
                state.value = [...state.value]
                state.value = state.value.filter(property => property.propertyId != action.payload.propertyId)
                state.value = [...state.value, action.payload]
                state.current = action.payload.propertyId
              })
    }
})

export const { addProperty, removeProperty, updateProperty } = propertySlice.actions;

export default propertySlice.reducer;