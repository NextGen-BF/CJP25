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
      status: "Pending",
      dateOpened: request.startDate,
      dateSettled: null,
      notes: null,
    };
  } else if (request.requestType == "Building Property Link") {
    return {
      userBuildingsId: 0,
      userId: request.userId,
      buildingId: request.buildingId,
      approved: false,
      role: request.role || "",
      startDate: request.startDate,
      endDate: null,
    };
  }

  return null;
}
