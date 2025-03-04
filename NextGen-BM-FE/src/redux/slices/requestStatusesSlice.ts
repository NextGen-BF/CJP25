import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { RequestStatus } from "../../models/requests";
import { getRequestStatuses } from "../services/requestService";

interface requestStatusSliceState {
  value: RequestStatus[];
}

const initialState: requestStatusSliceState = {
  value: [],
};

const requestStatusSlice = createSlice({
  name: "requestStatusSlice",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder.addCase(
      getRequestStatuses.fulfilled,
      (state, action: PayloadAction<RequestStatus[]>) => {
        state.value = action.payload;
      },
    );
  },
});

export default requestStatusSlice.reducer;
