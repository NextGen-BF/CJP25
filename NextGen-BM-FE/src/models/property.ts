export interface Property{
    propertyId: number;
    propertyNumber: number;
    buildingId: number;
    size: number;
    floor: number;
    sizeOfIdealParts: number;
    entranceIsExternal: boolean;
    propertyExpenses: PropertyExpense[];
    payments: PropertyPayments[];
    residentHistory: ResidentHistory[];
}

export interface ResidentHistory{
    firstName: string;
    lastName: string;
    residentTypeId: number;
    enterDate: Date;
    leaveDate: Date;
}

export interface PropertyPayments{
    paymentId: number;
    amountOwed: number;
    dateOpened: Date;
    dueDate: Date;
    status: string;
    paymentMethod: string;
}

export interface PropertyExpense{
    propertyExpenseId: number;
    propertyExpenseTemplateId: number;
    responsibleRoleId: number;
    price:number;
    startDate: Date;
    endDate: Date;
    Description: string;
}