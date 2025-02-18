import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { loginCall } from "../services/loginService";
import { jwtDecode } from "jwt-decode";

interface LoginState {
  value: {
    token: string;
    userId: string;
  };
}

function getLoginState() {
  const token = localStorage.getItem("JWT-BM") ?? "";
  if (token.length > 0) {
    const user = jwtDecode(token);
    return { token: token, userId: user.sub ?? "" };
  }
  return { token: "", userId: "" };
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
        userId: "",
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
        const user = jwtDecode(token);
        state.value = {
          token: token,
          userId: user.sub ?? "",
        };
        localStorage.setItem("JWT-BM", action.payload.token);
      },
    );
  },
});

export const { logout } = loginSlice.actions;

export default loginSlice.reducer;
