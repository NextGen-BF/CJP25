export interface Property{
    propertyId: number;
    propertyNumber: number;
    buildingId: number;
    size: number;
    floor: number;
    sizeOfIdealParts: number;
    entranceIsExternal: boolean;
    payments: PropertyPayments[] | null;
    residentHistory: ResidentHistory[] | null;
}

export interface ResidentHistory{
    propertyResidentsId: number;
    firstName: string;
    lastName: string;
    residentTypeId: number;
    enterDate: Date;
    leaveDate: Date;
}

export interface PropertyPayments{
    paymentId: number;
    propertyId: number;
    amountOwed: number;
    dateOpened: Date;
    dueDate: Date;
    status?: string;
    paymentMethod?: string;
}

export interface PropertyExpense{
    propertyExpenseId: number;
    propertyExpenseTemplateId: number;
    responsibleRole: string;
    price:number;
    startDate: Date;
    endDate: Date;
    description: string;
}