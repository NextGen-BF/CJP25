import { configureStore } from "@reduxjs/toolkit";
import loginReducer from "./slices/loginSlice";
import buildingReducer from "./slices/buildingSlice"
import signupReducer from "./slices/signupSlice";
import { useDispatch } from "react-redux";
import reducer from "./slices/loginSlice";
import  navigationReducer  from "./slices/navigationSlice";

export const store =  configureStore({
    reducer: {
        loginReducer: loginReducer,
        buildingReducer: buildingReducer,
        signupReducer: signupReducer,
        navigationReducer: navigationReducer

    },
})


export const useAppDispatch: () => typeof store.dispatch = useDispatch;
export type RootState = ReturnType<typeof store.getState>;
