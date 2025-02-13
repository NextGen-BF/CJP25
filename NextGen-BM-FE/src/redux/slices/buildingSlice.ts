import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { Building } from "../../models/building";
import { createBuilding, deleteUserBuildingLink, getBuildingsByUserId } from "../services/buildingService";

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
    }),
      builder.addCase(getBuildingsByUserId.fulfilled, (state, action: PayloadAction<Building[]>) => {
        state.value = action.payload;
      }),
      builder.addCase(deleteUserBuildingLink.fulfilled, (state, action: PayloadAction<number>) => {
        console.log(action.payload)
        state.value = state.value.filter(buildings => buildings.buildingId !== action.payload);
      })
  },
});

export default buildingSlice.reducer;
