import { createSlice, PayloadAction } from "@reduxjs/toolkit"
import { User } from "../../models/user"
import { getUserById } from "../services/loginService"

interface PropertyState {
    value: User
}

const initialState: PropertyState = {
    value: {
        userId: 0,
        firstName: "",
        lastName: "",
        role: "",
        properties: [],
        email: "",
        dateCreated: new Date()
    }
}

const accountSlice = createSlice({
    name: "Property",
    initialState,
    reducers: {},
    extraReducers: (builder)=> {
        builder.addCase(getUserById.fulfilled, (state, action: PayloadAction<User>) => {
                state.value=action.payload;
              })
    }
})

export default accountSlice.reducer;