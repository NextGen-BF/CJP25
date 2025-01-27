import { Building } from "../models/building.ts"
import { request } from "./shared.ts"
import { apiURL } from "./shared.ts"


export async function GetAllBuildings() {
    return await request<Building>(`${apiURL}/building/all`, {
        method: "GET",
    })
}

export async function GetBuildingByID(id: number): Promise<Building> {
    return await request<Building>(`${apiURL}/building/${id}`, {
        method: "GET",
    });
}

export async function CreateBuilding(building: Building): Promise<void> {
    return await request<void>(`${apiURL}/building/new`, {
        method: "POST",
        body: JSON.stringify(building),
    });
}

export async function UpdateBuilding(building: Building): Promise<void> {
    return await request<void>(`${apiURL}/building/update`, {
        method: "POST",
        body: JSON.stringify(building),
    });
}

export async function DeleteBuilding(id: number): Promise<void> {
    return await request<void>(`${apiURL}/building/${id}`, {
        method: "POST",
        body: JSON.stringify(id),
    });
}