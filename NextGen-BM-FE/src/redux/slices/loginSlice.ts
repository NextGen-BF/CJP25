import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { loginCall } from "../services/loginService";
import { jwtDecode } from "jwt-decode"

interface LoginState {
    value: {
        token: string,
        userId: number,
    }
}

function getToken() {
    const token = localStorage.getItem("JWT-BM")
    return token ?? "";
}

const initialState: LoginState = {
    value: {
        token: getToken(),
        userId: 0
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
                userId: 0
            }
        }
    },
    extraReducers: (builder) => {
        builder.addCase(loginCall.fulfilled, (state, action: PayloadAction<{ token: string }>) => {
            let token = action.payload.token;
            if (action.payload.token.length < 1) {
                token = getToken();
            }
            const user = jwtDecode(token)
            const userIdToNum = parseInt(user.sub ?? "0")
            state.value = {
                token: token,
                userId: userIdToNum
            }
            localStorage.setItem("JWT-BM", action.payload.token)
        })
    }
})

export const { logout } = loginSlice.actions;

export default loginSlice.reducer;

