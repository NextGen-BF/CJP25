import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { Building } from "../../models/building";
import { createBuilding } from "../services/buildingService";

interface BuildingsState {
  value: Building[];
}

const initialState: BuildingsState = {
  value: [{
    buildingId: 0,
    buildingAddress: {
      streetName: "",
      streetNumber: "",
      entrance: "",
      district: "",
      city: "",
      postalCode: "",
      Country: "",
    },
    alias: null,
    floorNum: 0,
    totalBuildingSize: 0,
    dateBuilt: new Date(Date.now()),
    numOfElevators: 0,
    buildingExpenses: null,
    buildingProperties: null,
  }],
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
