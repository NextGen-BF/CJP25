import { configureStore } from "@reduxjs/toolkit";
import loginReducer from "./slices/loginSlice";
import buildingReducer from "./slices/buildingSlice";
import signupReducer from "./slices/signupSlice";
import googleLoginSlice from "./slices/googleLoginSlice";
import { useDispatch } from "react-redux";
import navigationReducer from "./slices/navigationSlice";
import propertyReducer from "./slices/propertySlice";
import documentReducer from "./slices/documentSlice";

export const store = configureStore({
  reducer: {
    loginReducer: loginReducer,
    buildingReducer: buildingReducer,
    signupReducer: signupReducer,
    propertyReducer: propertyReducer,
    googleLoginSlice: googleLoginSlice,
    navigationReducer: navigationReducer,
    documentReducer: documentReducer,
  },
});

export const useAppDispatch: () => typeof store.dispatch = useDispatch;
export type RootState = ReturnType<typeof store.getState>;
