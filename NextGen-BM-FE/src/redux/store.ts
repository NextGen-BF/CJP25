import { configureStore } from "@reduxjs/toolkit";
import loginReducer from "./slices/loginSlice";
import { TypedUseSelectorHook, useDispatch } from "react-redux";

export const store =  configureStore({
    reducer: {
        loginReducer: loginReducer,
    },
})

export const useAppDispatch: () => typeof store.dispatch=useDispatch;
export type RootState = ReturnType<typeof store.getState>;
// export const useAppSelector:TypedUseSelectorHook<>