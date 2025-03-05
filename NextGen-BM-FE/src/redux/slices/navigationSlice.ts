import { createSlice } from "@reduxjs/toolkit";

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
        },
        closeDrawer(state){
            state.open = false;
        },
    }
});

export const { toggleDrawer, closeDrawer } = navigationSlice.actions;
const navigationReducer = navigationSlice.reducer;
export default navigationReducer;