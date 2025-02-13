import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { loginWithGoogleCall } from "../services/googleLoginService";

export interface GoogleJWTToken {
  scope: "";
  prn: "";
  hostedDomain: "";
  email: "";
  emailVerified: boolean;
  name: "";
  givenName: "";
  familyName: "";
  picture: "";
  locale: "";
}

interface GoogleLoginState {
  value: GoogleJWTToken;
}

const initialState: GoogleLoginState = {
  value: {
    scope: "",
    prn: "",
    hostedDomain: "",
    email: "",
    emailVerified: false,
    name: "",
    givenName: "",
    familyName: "",
    picture: "",
    locale: "",
  },
};

const googleLoginSlice = createSlice({
  name: "Google Login",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder.addCase(
      loginWithGoogleCall.fulfilled,
      (state, action: PayloadAction<GoogleJWTToken>) => {
        state.value = action.payload;
      },
    );
  },
});

export const loginWithGoogle = googleLoginSlice.actions;
export default googleLoginSlice.reducer;
