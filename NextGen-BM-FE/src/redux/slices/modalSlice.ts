import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { RequestRow } from "../../models/requests";

interface modalState {
  value: {
    selectedRow: RequestRow | null;
    isOpened: boolean;
  };
}

const initialState: modalState = {
  value: {
    selectedRow: null,
    isOpened: false,
  },
};

const modalStateSlice = createSlice({
  name: "Modal State",
  initialState,
  reducers: {
    setSelectedRow: (
      state,
      action: PayloadAction<{
        selectedRow: RequestRow | null;
        isOpened: boolean;
      }>,
    ) => {
      state.value = action.payload;
    },
  },
});

export const { setSelectedRow } = modalStateSlice.actions;
export default modalStateSlice.reducer;
