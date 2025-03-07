import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { loginCall } from "../services/loginService";
import { jwtDecode, JwtHeader } from "jwt-decode";
import { loginWithGoogleCall } from "../services/googleLoginService";

interface LoginState {
  value: {
    token: string;
    userId: number;
    isLoggedIn: boolean;
    role: string;
  };
}

function getLoginState() {
  const token = localStorage.getItem("JWT-BM") ?? "";
  if (token.length > 0) {
    const user = jwtDecode(token);
    const jwtHeader = jwtDecode<JwtHeader>(token);
    return {
      token: token,
      userId: parseInt(user.sub ?? "0"),
      isLoggedIn: true,
      role: jwtHeader.typ?.toLowerCase() ?? "",
    };
  }
  return { token: "", userId: 0, isLoggedIn: false, role: "tenant" };
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
        role: "",
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
        const jwtHeader = jwtDecode<JwtHeader>(token);
        state.value = {
          token: token,
          userId: parseInt(user.sub ?? "0"),
          isLoggedIn: true,
          role: jwtHeader.typ?.toLowerCase() ?? "",
        };
        localStorage.setItem("JWT-BM", action.payload.token);
      },
    );
    builder.addCase(
      loginWithGoogleCall.fulfilled,
      (state, action: PayloadAction<{ token: string }>) => {
        let token = action.payload.token;
        if (action.payload.token.length < 1) {
          token = getLoginState().token;
        }
        const user = jwtDecode(token);
        const jwtHeader = jwtDecode<JwtHeader>(token);
        state.value = {
          token: token,
          userId: parseInt(user.sub ?? "0"),
          isLoggedIn: true,
          role: jwtHeader.typ?.toLowerCase() ?? "",
        };
        localStorage.setItem("JWT-BM", action.payload.token);
      },
    );
  },
});

export const { logout } = loginSlice.actions;

export default loginSlice.reducer;
