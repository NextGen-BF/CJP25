import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { loginCall } from "../services/loginService";
import { jwtDecode } from "jwt-decode";

interface LoginState {
  value: {
    token: string;
    userId: number;
    isLoggedIn: boolean;
  };
}

function getLoginState() {
  const token = localStorage.getItem("JWT-BM") ?? "";
  if (token.length > 0) {
    const user = jwtDecode(token);
    return {
      token: token,
      userId: parseInt(user.sub ?? "0"),
      isLoggedIn: true,
    };
  }
  return { token: "", userId: 0, isLoggedIn: false };
}

const initialState: LoginState = {
  value: getLoginState(),
};

const loginSlice = createSlice({
  name: "Login",
  initialState,
  reducers: {
    logout: (state) => {
      localStorage.removeItem("JWT-BM");
      state.value = {
        token: "",
        userId: 0,
        isLoggedIn: false,
      };
    },
  },
  extraReducers: (builder) => {
    builder.addCase(
      loginCall.fulfilled,
      (state, action: PayloadAction<{ token: string }>) => {
        let token = action.payload.token;
        if (action.payload.token.length < 1) {
          token = getLoginState().token;
        }
        console.log(action.payload);
        const user = jwtDecode(token);
        state.value = {
          token: token,
          userId: parseInt(user.sub ?? "0"),
          isLoggedIn: true,
        };
        console.log(state.value);
        localStorage.setItem("JWT-BM", action.payload.token);
      },
    );
  },
});

export const { logout } = loginSlice.actions;

export default loginSlice.reducer;
