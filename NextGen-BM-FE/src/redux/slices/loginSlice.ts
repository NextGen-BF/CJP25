import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { loginCall } from "../services/loginService";
import { jwtDecode } from "jwt-decode"

interface LoginState {
    value: {
        token: string,
        userId: string,
    }
}

function getToken() {
    const token = localStorage.getItem("JWT-BM")
    return token ?? "";
}

const initialState: LoginState = {
    value: {
        token: getToken(),
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
            let token = action.payload.token;
            if (action.payload.token.length < 1) {
                token = getToken();
            }
            const user = jwtDecode(token)
            state.value = {
                token: token,
                userId: user.sub ?? ""
            }
            console.log(state.value.userId)
            localStorage.setItem("JWT-BM", action.payload.token)
        })
    }
})

export const { logout } = loginSlice.actions;

export default loginSlice.reducer;

