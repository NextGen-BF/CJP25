export interface RepairRequest {
  requestId: number;
  userId: number;
  requestDescription: string;
  status: {
    statusId: number;
    title: string;
  };
  dateOpened: Date | string;
  dateSettled: Date | null;
  notes: RequestNotes[] | null;
  buildingId: number;
  files: FormData | null;
}

export interface RequestNotes {
  noteId: number;
  createdBy: number;
  createDate: Date | string;
  requestId: number;
  noteText: string;
}

export interface UserBuildingRequests {
  userBuildingsId: number;
  userId: number;
  buildingId: number;
  approved: boolean;
  roleId: number | null;
  startDate: Date;
  endDate: Date | null;
}

export interface createRequest {
  requestTitle: string;
  requestType: string;
  buildingId: number;
  userId: number;
  propertyId: number | null;
  description: string | null;
  roleId: number | null; //Will change to enum/int after roles are created in db
  startDate: Date;
}

export interface RequestRow {
  id: number;
  requestTitle: string;
  buildingAlias: string;
  requestType: string;
  userName: string;
  description: string;
  status: string;
  dateCreated: Date;
  notes: RequestNotes[];
}

export enum RequestStatus {
  approved = "Approved",
  denied = "Denied",
  pending = "Pending",
}
