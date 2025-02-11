import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { loginCall } from "../services/loginService";
import { jwtDecode } from "jwt-decode"

interface LoginState {
    value: {
        token: string,
        userId: string,
    }
}

const initialState: LoginState = {
    value: {
        token: localStorage.getItem("JWT-BM") ?? "",
        userId: ""
    }
};

const loginSlice = createSlice({
    name: "Login",
    initialState,
    reducers: {
        logout: (state) => {
            localStorage.removeItem("JWT-BM")
            state.value = {
                token: "",
                userId: ""
            }
        }
    },
    extraReducers: (builder) => {
        builder.addCase(loginCall.fulfilled, (state, action: PayloadAction<{ token: string }>) => {
            const user = jwtDecode(action.payload.token)
            state.value = {
                token: action.payload.token,
                userId: user.sub ?? ""
            }
            console.log(state.value.userId)
            localStorage.setItem("JWT-BM", action.payload.token)
        })
    }
})

export const { logout } = loginSlice.actions;

export default loginSlice.reducer;

