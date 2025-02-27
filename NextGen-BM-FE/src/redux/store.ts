import { configureStore } from "@reduxjs/toolkit";
import { useDispatch } from "react-redux";
import loginReducer from "./slices/loginSlice";
import buildingReducer from "./slices/buildingSlice";
import signupReducer from "./slices/signupSlice";
import googleLoginSlice from "./slices/googleLoginSlice";
import navigationReducer from "./slices/navigationSlice";
import propertyReducer from "./slices/propertySlice";
import documentReducer from "./slices/documentSlice";
import repairRequestReducer from "./slices/repairRequestSlice";
import snackbarReducer from "./slices/snackbarSlice";
import modalStateReducer from "./slices/modalSlice";
import requestGenericReducer from "./slices/requestGenericSlice";

export const store = configureStore({
  reducer: {
    loginReducer: loginReducer,
    buildingReducer: buildingReducer,
    signupReducer: signupReducer,
    propertyReducer: propertyReducer,
    googleLoginSlice: googleLoginSlice,
    navigationReducer: navigationReducer,
    documentReducer: documentReducer,
    repairRequestReducer: repairRequestReducer,
    snackBarReducer: snackbarReducer,
    modalStateReducer: modalStateReducer,
    requestGenericReducer: requestGenericReducer,
  },
});

export const useAppDispatch: () => typeof store.dispatch = useDispatch;
export type RootState = ReturnType<typeof store.getState>;
