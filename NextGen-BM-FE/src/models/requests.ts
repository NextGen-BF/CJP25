export interface RepairRequest{
    requestId: number;
    userId: string;
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
    userId: string;
    buildingId: number;
    approved: boolean;
    role: string;
    startDate: Date;
    endDate: Date;
}