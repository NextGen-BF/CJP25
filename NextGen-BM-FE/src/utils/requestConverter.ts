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
      requestTitle: request.requestTitle,
      userId: request.userId,
      requestDescription: request.description || "",
      status: {
        statusId: 20,
        title: "In Review",
      },
      dateOpened: request.startDate.toISOString().split("T")[0],
      dateSettled: null,
      notes: null,
      buildingId: request.buildingId,
      files: null,
    };
  } else if (request.requestType == "Building Property Link") {
    return {
      userBuildingsId: 0,
      requestTitle: request.requestTitle,
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
