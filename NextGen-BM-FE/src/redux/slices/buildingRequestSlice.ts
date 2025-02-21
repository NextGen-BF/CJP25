import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { UserBuildingRequests } from "../../models/requests";
import { createUserBuildingRequest } from "../services/requestService";

interface UserBuildingRequestsState {
  value: UserBuildingRequests[];
}

const initialState: UserBuildingRequestsState = {
  value: [],
};

const UserBuildingRequestsSlice = createSlice({
  name: "Repair Requests",
  initialState,
  reducers: {
    addRequest: (state, action: PayloadAction<UserBuildingRequests>) => {
      state.value = [...state.value, action.payload];
    },
    removeRequest: (state, action: PayloadAction<UserBuildingRequests>) => {
      state.value = state.value.filter(
        (request) => request.userBuildingsId != action.payload.userBuildingsId,
      );
    },
    updateRequest: (state, action: PayloadAction<UserBuildingRequests>) => {
      state.value = [...state.value];
      state.value = state.value.filter(
        (request) => request.userBuildingsId != action.payload.userBuildingsId,
      );
      state.value = [...state.value, action.payload];
    },
  },
  extraReducers: (builder) => {
    builder.addCase(
      createUserBuildingRequest.fulfilled,
      (_state, action: PayloadAction<UserBuildingRequests>) => {
        addRequest(action.payload);
      },
    );
  },
});

export const { addRequest, removeRequest, updateRequest } =
  UserBuildingRequestsSlice.actions;
export default UserBuildingRequestsSlice.reducer;
