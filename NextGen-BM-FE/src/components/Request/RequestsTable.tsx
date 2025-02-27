import { DataGrid, GridColDef, GridToolbar } from "@mui/x-data-grid";
import { FC } from "react";
import "../scss/requestsTable.scss";
import { editableTableConstants } from "../../constants/constants";
import { RequestRow } from "../../models/requests";
import RequestModal from "./RequestModal";
import { useAppDispatch } from "../../redux/store";
import { setSelectedRow } from "../../redux/slices/modalSlice";

const RequestTable: FC = () => {
  const dispatch = useAppDispatch();

  const request: RequestRow[] = [
    {
      id: 0,
      requestTitle: "Test",
      buildingAlias: "Test",
      requestType: "Repair",
      userName: "Kiril Test",
      description: "Description...",
      status: "Pending",
      dateCreated: new Date(Date.now()),
      notes: [
        {
          noteId: 0,
          requestId: 0,
          createdBy: 1,
          createDate: new Date(Date.now()),
          noteText: "Bazinga bazinga",
        },
        {
          noteId: 1,
          requestId: 0,
          createdBy: 2,
          createDate: new Date(Date.now()),
          noteText: "Bazinga because bazinga is bazinga",
        },
      ],
    },
  ];

  const handleRowClick = (id: number) => {
    console.log("Test");
    console.log(request[id]);
    dispatch(setSelectedRow({ selectedRow: request[id], isOpened: true }));
  };

  const requestColumns: GridColDef[] = [
    {
      field: "requestTitle",
      headerName: "Request Title",
      flex: 1,
    },
    {
      field: "buildingAlias",
      headerName: "Building",
      flex: 1,
    },
    {
      field: "requestType",
      headerName: "Request Type",
      flex: 1,
    },
    {
      field: "userName",
      headerName: "Name of user",
      flex: 1,
    },
    {
      field: "dateOpened",
      headerName: "Date Created",
      flex: 1,
    },
    {
      field: "status.title",
      headerName: "Status",
      flex: 1,
    },
  ];

  return (
    <div>
      <div className="table-container">
        <DataGrid
          rows={request}
          getRowId={(row) => row.id}
          columns={requestColumns}
          pageSizeOptions={editableTableConstants.pageSizeOptions}
          slots={{ toolbar: GridToolbar }}
          onRowClick={(row) => handleRowClick(row.id as number)}
        />
      </div>
      <div>
        <RequestModal />
      </div>
    </div>
  );
};

export default RequestTable;
