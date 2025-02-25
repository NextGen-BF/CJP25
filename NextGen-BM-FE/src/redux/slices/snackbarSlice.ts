import { createSlice, PayloadAction } from "@reduxjs/toolkit";

export type SnackbarType = "success" | "info" | "warning" | "error";

export interface SnackbarState {
  snackbarOpen: boolean;
  snackbarType: SnackbarType;
  snackbarMessage: string;
}

const initialState: SnackbarState = {
  snackbarOpen: false,
  snackbarType: "success",
  snackbarMessage: "",
};

const snackbarSlice = createSlice({
  name: "snackbar",
  initialState,
  reducers: {
    setSnackbar: (state, action: PayloadAction<SnackbarState>) => {
      return { ...state, ...action.payload };
    },
    closeSnackbar: (state) => {
      state.snackbarOpen = false;
    },
  },
});

export const { setSnackbar, closeSnackbar } = snackbarSlice.actions;
export default snackbarSlice.reducer;
