import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { signupCall } from "../services/signupService";
import { AxiosResponse } from "axios";
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
    builder.addCase(
      signupCall.fulfilled,
      (state, action: PayloadAction<AxiosResponse>) => {
        if (action.payload.status === 200) {
          state.requestResultMessage = "Successful";
        } else {
          state.requestResultMessage = getMessageForSignupError(action.payload);
        }
      },
    );
  },
});

export const signUp = signupSlice.actions;
export default signupSlice.reducer;
