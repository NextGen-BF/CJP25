export interface Building {
    buildingId :number,
    address: Address,
    alias: string | null,
    floorNum: number,
    totalBuildingSize: number,
    dateBuilt: Date,
    numOfElevators: number,
    buildingExpenses: BuildingExpense[]
}

interface Address {
    streetNumber: string,
    entance: string,
    district: string,
    city: string,
    postalCode: string,
    Country: string,
}

interface BuildingExpense{
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
