import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { Property } from "../../models/property";

interface PropertyState{
    value: Property[]
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
    }]
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
        },
        updateProperty: (state, action: PayloadAction<Property>) => {
            state.value = [...state.value]
            state.value = state.value.filter(property => property.propertyId != action.payload.propertyId)
            state.value = [...state.value, action.payload]
        }
    },
})

export const { addProperty, removeProperty, updateProperty} = propertySlice.actions;

export default propertySlice.reducer;