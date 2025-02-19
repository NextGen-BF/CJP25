import { Property } from "../models/property.ts"
import { request, apiURL } from "./shared.ts"


export async function GetAllProperties() {
    return await request<Property>(`${apiURL}/property/all`, {
        method: "GET",
    })
}

export async function GetPropertyById(id: number): Promise<Property> {
    return await request<Property>(`${apiURL}/property/${id}`, {
        method: "GET",
    });
}

export async function GetPropertyByBuildingId(id: number): Promise<Property> {
    return await request<Property>(`${apiURL}/property/building/${id}`, {
        method: "GET",
    });
}

export async function GetPropertyByUserId(id: number): Promise<Property> {
    return await request<Property>(`${apiURL}/property/user/${id}`, {
        method: "GET",
    });
}

export async function CreateProperty(property: Property): Promise<void> {
    return await request<void>(`${apiURL}/property/new`, {
        method: "POST",
        body: JSON.stringify(property),
    });
}

export async function UpdateProperty(property: Property): Promise<void> {
    return await request<void>(`${apiURL}/property/update`, {
        method: "POST",
        body: JSON.stringify(property),
    });
}

export async function DeleteProperty(id: number): Promise<void> {
    return await request<void>(`${apiURL}/property/${id}`, {
        method: "POST",
        body: JSON.stringify(id),
    });
}