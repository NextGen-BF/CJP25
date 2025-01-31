import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { signupCall } from "../services/signupService";
import { getMessageForSignupError } from "../../utils/signupResponseError";

interface SignUpState {
  requestResultMessage: string;
}

const initialState: SignUpState = {
  requestResultMessage: "",
};

const signupSlice = createSlice({
  name: "Sign Up",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(signupCall.fulfilled, (state) => {
        state.requestResultMessage = "Successful";
      })
      .addCase(signupCall.rejected, (state, action: PayloadAction<any>) => {
        state.requestResultMessage = getMessageForSignupError(action.payload);
      });
  },
});

export const signUp = signupSlice.actions;
export default signupSlice.reducer;
