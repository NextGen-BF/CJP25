export interface RepairRequest {
  requestId: number;
  userId: number;
  requestDescription: string;
  status: string;
  dateOpened: Date;
  dateSettled: Date | null;
  notes: RequestNotes[] | null;
}

export interface RequestNotes {
  noteId: number;
  createdBy: number;
  createDate: Date;
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
  role: string | null; //Will change to enum/int after roles are created in db
  startDate: Date;
}
