import { PropertyExpense } from "../models/property.ts"
import { BuildingExpense } from "../models/building.ts";
import { request, apiURL } from "./shared.ts"

export async function GetExpenseByUserId(id: number): Promise<PropertyExpense[]> {
    return await request<PropertyExpense[]>(`${apiURL}/expense/user/${id}`, {
        method: "GET",
    });
}

export async function GetPropertyExpenseById(id: number): Promise<PropertyExpense[]> {
    return await request<PropertyExpense[]>(`${apiURL}/expense/property/${id}`, {
        method: "GET",
    });
}

export async function GetBuildingExpenseById(id: number): Promise<BuildingExpense[]> {
    return await request<BuildingExpense[]>(`${apiURL}/expense/${id}`, {
        method: "GET",
    });
}

export async function CreatePropertyExpense(propertyExpense: PropertyExpense): Promise<void> {
    return await request<void>(`${apiURL}/expense/new`, {
        method: "POST",
        body: JSON.stringify(propertyExpense),
    });
}

export async function LinkExpenseToProperties(propertyIds: number[], expenseId: number): Promise<void> {
    return await request<void>(`${apiURL}/expense/link/property${expenseId}`, {
        method: "POST",
        body: JSON.stringify(propertyIds),
    });
}

export async function UpdatePropertyExpense(propertyExpense: PropertyExpense): Promise<void> {
    return await request<void>(`${apiURL}/expense/update`, {
        method: "POST",
        body: JSON.stringify(propertyExpense),
    });
}

export async function DeletePropertyExpense(id: number): Promise<void> {
    return await request<void>(`${apiURL}/expense/delete/${id}`, {
        method: "POST",
        body: JSON.stringify(id),
    });
}