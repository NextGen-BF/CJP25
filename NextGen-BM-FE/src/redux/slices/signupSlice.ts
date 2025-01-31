import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { signupCall } from "../services/signupService";
import { getMessageForSignupError } from "../../utils/signupResponseError";

interface SignUpState {
  signupResultMessage: string;
}

const initialState: SignUpState = {
  signupResultMessage: "",
};

const signupSlice = createSlice({
  name: "Sign Up",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(signupCall.fulfilled, (state) => {
        state.signupResultMessage = "Successful";
      })
      .addCase(signupCall.rejected, (state, action: PayloadAction<any>) => {
        state.signupResultMessage = getMessageForSignupError(action.payload);
      });
  },
});

export const signUp = signupSlice.actions;
export default signupSlice.reducer;
