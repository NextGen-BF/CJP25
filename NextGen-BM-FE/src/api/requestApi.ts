import { RepairRequest, RequestNotes, UserBuildingRequests } from "../models/requests.ts"
import { request, apiURL } from "./shared.ts"

export async function GetRepairRequestByBuildingId(id: number): Promise<RepairRequest> {
    return await request<RepairRequest>(`${apiURL}/request/building/repair/${id}`, {
        method: "GET",
    });
}

export async function GetRepairRequestById(id: number): Promise<RepairRequest> {
    return await request<RepairRequest>(`${apiURL}/request/repair/${id}`, {
        method: "GET",
    });
}

export async function GetUserBuildingRequests(id: number): Promise<UserBuildingRequests> {
    return await request<UserBuildingRequests>(`${apiURL}/request/user/building/${id}`, {
        method: "GET",
    });
}

export async function CreateRepairRequest(repairRequest: RepairRequest): Promise<void> {
    return await request<void>(`${apiURL}/request/repair/new`, {
        method: "POST",
        body: JSON.stringify(repairRequest),
    });
}

export async function CreateUserBuildingRequest(userBuildingRequest: UserBuildingRequests ): Promise<void> {
    return await request<void>(`${apiURL}/request/user/building/new`, {
        method: "POST",
        body: JSON.stringify(userBuildingRequest),
    });
}

export async function CreateRepairRequestNote(requestNotes: RequestNotes): Promise<void> {
    return await request<void>(`${apiURL}/request/note/new`, {
        method: "POST",
        body: JSON.stringify(requestNotes),
    });
}

export async function UpdateRepairRequest(repairRequest: RepairRequest): Promise<void> {
    return await request<void>(`${apiURL}/request/repair/update`, {
        method: "POST",
        body: JSON.stringify(repairRequest),
    });
}

export async function UpdateRequestNotes(requestNotes: RequestNotes): Promise<void> {
    return await request<void>(`${apiURL}/request/note/update`, {
        method: "POST",
        body: JSON.stringify(requestNotes),
    });
}

export async function DeleteRepairRequest(id: number): Promise<void> {
    return await request<void>(`${apiURL}/request/repair/delete/${id}`, {
        method: "POST",
        body: JSON.stringify(id),
    });
}

export async function DeleteRequestNote(id: number): Promise<void> {
    return await request<void>(`${apiURL}/request/note/delete/${id}`, {
        method: "POST",
        body: JSON.stringify(id),
    });
}