export interface RepairRequest{
    requestId: number;
    userId: number;
    requestDescription: string;
    status: string;
    dateOpened: Date;
    dateSettled: Date;
    notes: RequestNotes[];
}

export interface RequestNotes{
    noteId: number;
    createdBy: number;
    createDate: Date;
    noteText: string;
}