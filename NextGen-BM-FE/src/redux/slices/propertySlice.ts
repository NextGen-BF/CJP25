import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { Property } from "../../models/property";
import { createProperty } from "../services/propertyService";

interface PropertyState{
    value:Property[]
}

const initialState:PropertyState = {
    value:[
        {
            propertyId: 0,
            propertyNumber: 0,
            buildingId: 0,
            size: 0,
            floor: 0,
            sizeOfIdealParts: 0,
            entranceIsExternal: false,
            propertyExpenses: null,
            payments: null,
            residentHistory: null
        }
    ]
}

const propertySlice=createSlice({
    name: "Property",
    initialState: initialState,
    reducers: {},
    extraReducers: (builder)=>{
        builder.addCase(createProperty.fulfilled, (state, action:PayloadAction<Property>)=>{
            state.value.push(action.payload)
        })
    }
});

export default propertySlice.reducer;