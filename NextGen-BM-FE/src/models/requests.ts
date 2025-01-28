export interface RepairRequest{
    requestId: number;
    userId: number;
    requestDescription: string;
    status: string;
    dateOpened: Date;
    dateSettled: Date;
    notes: RequestNotes[] | null;
}

export interface RequestNotes{
    noteId: number;
    createdBy: number;
    createDate: Date;
    noteText: string;
}

export interface UserBuildingRequests{
    userBuildingsId: number;
    userId: number;
    buildingId: number;
    approved: boolean;
    role: string;
    startDate: Date;
    endDate: Date;
}