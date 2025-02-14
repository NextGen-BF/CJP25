import { createSlice, PayloadAction } from "@reduxjs/toolkit";

interface NavigationState {
    open:boolean
};

const initialState:NavigationState={
    open:false
};

const navigationSlice=createSlice({
    name: 'Navigation',
    initialState: initialState,
    reducers:{
        toggleDrawer(state){
            state.open=!state.open;
        }
    }
});

export const { toggleDrawer } = navigationSlice.actions;
const navigationReducer = navigationSlice.reducer;
export default navigationReducer;