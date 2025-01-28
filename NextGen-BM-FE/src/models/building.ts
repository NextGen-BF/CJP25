import { Property } from "./property"

export interface Building {
    buildingId :number,
    address: Address,
    alias: string | null,
    floorNum: number,
    totalBuildingSize: number,
    dateBuilt: Date,
    numOfElevators: number,
    buildingExpenses: BuildingExpense[]
    properties: Property[];
}

interface Address {
    streetNumber: string,
    entance: string,
    district: string,
    city: string,
    postalCode: string,
    Country: string,
}

export interface BuildingExpense{
    buildingExpenseId: number,
    title: string,
    totalAmount: number,
    supplier: string,
    dateOpened: Date,
    dueDate: Date,
    paymentDate: Date,
    description: string,
    isTemplate: boolean,
    repeatPeriod: number,
    invoiceUrl: string | null,
}
