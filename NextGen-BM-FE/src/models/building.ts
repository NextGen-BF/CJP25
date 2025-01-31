import { Property } from "./property"

export interface Building {
    buildingId :number,
    buildingAddress: Address,
    alias: string | null,
    floorNum: number,
    totalBuildingSize: number,
    dateBuilt: Date,
    numOfElevators: number,
    buildingExpenses: BuildingExpense[] | null;
    buildingProperties: Property[] | null;
}

export interface Address {
    streetName: string,
    streetNumber: string,
    entrance: string,
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
