import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { RepairRequest } from "../../models/requests";
import { createRepairRequest } from "../services/requestService";

interface repairRequestState {
  value: RepairRequest[];
}

const initialState: repairRequestState = {
  value: [],
};

const repairRequestSlice = createSlice({
  name: "Repair Requests",
  initialState,
  reducers: {
    addRequest: (state, action: PayloadAction<RepairRequest>) => {
      state.value = [...state.value, action.payload];
    },
    removeRequest: (state, action: PayloadAction<RepairRequest>) => {
      state.value = state.value.filter(
        (request) => request.requestId != action.payload.requestId,
      );
    },
    updateRequest: (state, action: PayloadAction<RepairRequest>) => {
      state.value = [...state.value];
      state.value = state.value.filter(
        (request) => request.requestId != action.payload.requestId,
      );
      state.value = [...state.value, action.payload];
    },
  },
  extraReducers: (builder) => {
    builder.addCase(
      createRepairRequest.fulfilled,
      (state, action: PayloadAction<RepairRequest>) => {
        addRequest(action.payload);
      },
    );
  },
});

export const { addRequest, removeRequest, updateRequest } =
  repairRequestSlice.actions;
export default repairRequestSlice.reducer;
