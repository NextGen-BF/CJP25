import { createSlice } from "@reduxjs/toolkit";
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
        propertyExpenses: [{
            propertyExpenseId: 0,
            propertyExpenseTemplateId: 0,
            responsibleRoleId: 0,
            price:0,
            startDate: new Date(Date.now()),
            endDate: new Date(Date.now()),
            Description: "",
        }],
        payments: [{
            paymentId: 0,
            amountOwed: 0,
            dateOpened: new Date(Date.now()),
            dueDate: new Date(Date.now()),
            status: "",
            paymentMethod: "",
        }],
        residentHistory: [{
            firstName: "",
            lastName: "",
            residentTypeId: 0,
            enterDate: new Date(Date.now()),
            leaveDate: new Date(Date.now()),
        }]
    }]
}

const propertySlice = createSlice({
    name: "Property",
    initialState,
    reducers: {
        addProperty: (state, action) => {
            state.value.push(action.payload)
        },
        removeProperty: (state, action) => {
            const index = state.value.findIndex(action.payload);
            state.value.splice(index, 1);
        }
    },
})

export const { addProperty, removeProperty} = propertySlice.actions;

export default propertySlice.reducer;