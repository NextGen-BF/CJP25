import {
  createRequest,
  RepairRequest,
  UserBuildingRequests,
} from "../models/requests";

//TODO: Fix hardcoded values
export function transformRequest(
  request: createRequest,
): RepairRequest | UserBuildingRequests | null {
  if (request.requestType == "Repair") {
    return {
      requestId: 0,
      userId: request.userId,
      requestDescription: request.description || "",
      status: {
        statusId: 7,
        title: "In review",
      },
      dateOpened: request.startDate.toISOString().split("T")[0],
      dateSettled: null,
      notes: null,
      buildingId: request.buildingId,
    };
  } else if (request.requestType == "Building Property Link") {
    return {
      userBuildingsId: 0,
      userId: request.userId,
      buildingId: request.buildingId,
      approved: false,
      roleId: request.roleId,
      startDate: request.startDate,
      endDate: null,
    };
  }

  return null;
}
