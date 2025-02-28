import { DataGrid, GridColDef, GridToolbar } from "@mui/x-data-grid";
import { FC } from "react";
import "../scss/requestsTable.scss";
import { editableTableConstants } from "../../constants/constants";
import RequestModal from "./RequestModal";
import { RootState, useAppDispatch } from "../../redux/store";
import { setSelectedRow } from "../../redux/slices/modalSlice";
import { useSelector } from "react-redux";
import { getAllRequestsForUser } from "../../redux/services/requestService";

const RequestTable: FC = () => {
  const dispatch = useAppDispatch();
  const user = useSelector((state: RootState) => state.loginReducer.value);

  const request = useSelector(
    (state: RootState) => state.requestGenericReducer.value,
  );

  if (request.length == 0) dispatch(getAllRequestsForUser(user.userId));

  const handleRowClick = (id: number) => {
    dispatch(setSelectedRow({ selectedRow: request[id - 1], isOpened: true }));
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
      field: "userFullName",
      headerName: "Name of user",
      flex: 1,
    },
    {
      field: "dateCreated",
      headerName: "Date Created",
      flex: 1,
    },
    {
      field: "status",
      headerName: "Status",
      flex: 1,
    },
  ];

  // Add a custom auto-incrementing ID
  const requestsWithCustomId = request.map((row, index) => ({
    ...row,
    customId: index + 1, // Auto-incrementing ID
  }));

  return (
    <div>
      <div className="table-container">
        <DataGrid
          rows={requestsWithCustomId}
          getRowId={(row) => row.customId}
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
