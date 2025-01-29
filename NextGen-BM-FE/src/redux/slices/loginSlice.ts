import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { loginCall } from "../services/loginService";
import { AuthToken } from "../../models/user";

interface LoginState {
    value: AuthToken
}

const initialState: LoginState = {
    value: {
        tokenType: "",
        accessToken: "",
        expiresIn: 0,
        refreshToken: "",
    }
};

const loginSlice = createSlice({
    name: "Login",
    initialState,
    reducers: {
        login: (state, action) => {
            state.value.accessToken = action.payload
        },
        logout: (state) => {
            state.value.accessToken = ""
        }
    },
    extraReducers: (builder) => {
        builder.addCase(loginCall.fulfilled, (state, action: PayloadAction<AuthToken>) => {
            state.value = action.payload;
        })
    }
})

export const { login, logout } = loginSlice.actions;

export default loginSlice.reducer;