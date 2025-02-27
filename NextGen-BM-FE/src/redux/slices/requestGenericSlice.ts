import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { RequestRow } from "../../models/requests";
import { getAllRequestsForUser } from "../services/requestService";

interface requestsGenericState {
  value: RequestRow[];
}

const initialState: requestsGenericState = {
  value: [],
};

const requestsGenericSlice = createSlice({
  name: "Generic request slice",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder.addCase(
      getAllRequestsForUser.fulfilled,
      (state, action: PayloadAction<RequestRow[]>) => {
        state.value = action.payload;
      },
    );
  },
});

export default requestsGenericSlice.reducer;
