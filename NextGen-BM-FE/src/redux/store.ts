import { configureStore } from "@reduxjs/toolkit";
import loginReducer from "./slices/loginSlice";
import signupReducer from "./slices/signupSlice";
import googleLoginSlice from "./slices/googleLoginSlice";
import { useDispatch } from "react-redux";

export const store = configureStore({
  reducer: {
    loginReducer: loginReducer,
    signupReducer: signupReducer,
    googleLoginSlice: googleLoginSlice,
  },
});

export const useAppDispatch: () => typeof store.dispatch = useDispatch;
export type RootState = ReturnType<typeof store.getState>;
