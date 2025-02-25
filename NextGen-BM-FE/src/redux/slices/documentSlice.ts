import { createSlice, PayloadAction } from "@reduxjs/toolkit";

interface DocumentState {
  value: File[];
}

const initialState: DocumentState = {
  value: [],
};

const documentSlice = createSlice({
  name: "Document",
  initialState,
  reducers: {
    addDocument: (state, action: PayloadAction<File>) => {
      state.value = [...state.value, action.payload];
    },
    removeDocument: (state, action: PayloadAction<File>) => {
      state.value = state.value.filter(
        (file) => file.name != action.payload.name,
      );
    },
  },
});

export const { addDocument, removeDocument } = documentSlice.actions;
export default documentSlice.reducer;
