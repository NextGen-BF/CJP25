import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { Building } from "../../models/building";
import { createBuilding } from "../services/buildingService";

interface BuildingsState {
  value: Building[];
}

const initialState: BuildingsState = {
  value: [],
};

const buildingSlice = createSlice({
  name: "Building",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder.addCase(createBuilding.fulfilled, (state, action: PayloadAction<Building>) => {
      state.value.push(action.payload);
    })
  },
});

export default buildingSlice.reducer;
