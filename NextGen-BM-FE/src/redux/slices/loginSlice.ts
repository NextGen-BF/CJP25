import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { loginCall } from "../services/loginService";
import { AuthToken } from "../../models/user";

interface LoginState {
    value: string
}

const initialState: LoginState = {
    value: localStorage.getItem("JWT-BM") ?? ""
};

const loginSlice = createSlice({
    name: "Login",
    initialState,
    reducers: {
        logout: () => {
            localStorage.removeItem("JWT-BM")
        }
    },
    extraReducers: (builder) => {
        builder.addCase(loginCall.fulfilled, (state, action: PayloadAction<AuthToken>) => {
            state.value = action.payload.accessToken;
            localStorage.setItem("JWT-BM", action.payload.accessToken)
        })
    }
})

export const { logout } = loginSlice.actions;

export default loginSlice.reducer;