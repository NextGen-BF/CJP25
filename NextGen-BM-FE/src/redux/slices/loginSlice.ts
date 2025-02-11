import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { loginCall } from "../services/loginService";

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
        logout: (state) => {
            localStorage.removeItem("JWT-BM")
            state.value = ""
        }
    },
    extraReducers: (builder) => {
        builder.addCase(loginCall.fulfilled, (state, action: PayloadAction<{token: string}>) => {
            state.value = action.payload.token;
            localStorage.setItem("JWT-BM", action.payload.token)
        })
    }
})

export const { logout } = loginSlice.actions;

export default loginSlice.reducer;