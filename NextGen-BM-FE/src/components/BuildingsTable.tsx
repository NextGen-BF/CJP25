import { FC, useEffect } from "react";
import { RootState, useAppDispatch } from "../redux/store";
import { useSelector } from "react-redux";
import {
  deleteUserBuildingLink,
  getBuildingsByUserId,
} from "../redux/services/buildingService";
import {
  Accordion,
  AccordionDetails,
  AccordionSummary,
  Button,
  Divider,
  TextField,
} from "@mui/material";
import { DataGrid, GridColDef, GridToolbar } from "@mui/x-data-grid";
import "./scss/buildingTable.scss";
import { useNavigate } from "react-router-dom";
import { buildingConstants } from "../constants/buildingConstants";
import { editableTableConstants } from "../constants/constants";

const BuildingsTable: FC = () => {
  const dispatch = useAppDispatch();
  const userId = useSelector(
    (state: RootState) => state.loginReducer.value.userId,
  );
  const navigate = useNavigate();

  useEffect(() => {
    if (userId) dispatch(getBuildingsByUserId(userId));
  }, [dispatch, userId]);

  const allBuildings = useSelector(
    (state: RootState) => state.buildingReducer.value,
  );

  const propertyColumns: GridColDef[] = [
    {
      field: "propertyNumber",
      headerName: "Property Number",
      flex: 1,
    },
    {
      field: "size",
      headerName: "Size (in m2)",
      flex: 1,
      type: "number",
    },
    {
      field: "floor",
      headerName: "Floor",
      flex: 1,
      type: "number",
    },
    {
      field: "sizeOfIdealParts",
      headerName: "Ideal Parts (in %)",
      flex: 1,
      type: "number",
    },
    {
      field: "entranceIsExternal",
      headerName: "External Entrance",
      flex: 1,
      type: "boolean",
    },
  ];

  const expensesColumns: GridColDef[] = [
    {
      field: "title",
      headerName: "Title",
      flex: 1,
      type: "string",
    },
    {
      field: "totalAmount",
      headerName: "Amount Owed",
      flex: 1,
      type: "number",
    },
    {
      field: "supplier",
      headerName: "Supplier",
      flex: 1,
      type: "string",
    },
    {
      field: "dateOpened",
      headerName: "Date Opened",
      flex: 1,
      type: "string",
    },
    {
      field: "dueDate",
      headerName: "Due Date",
      flex: 1,
      type: "string",
    },
    {
      field: "paymentDate",
      headerName: "Date Paid",
      flex: 1,
      type: "string",
    },
    {
      field: "description",
      headerName: "Description",
      flex: 1,
      type: "string",
    },
  ];

  //Temp solution, will use modal later to get confirmation.
  const handleDelete = async (buildingId: number, alias: string) => {
    if (
      confirm("Are you sure you want to delete link with building: " + alias)
    ) {
      dispatch(deleteUserBuildingLink({ userId, buildingId }));
    } else alert(`Building link with ${alias ?? buildingId} was NOT deleted`);
  };

  if (allBuildings.length < 1) {
    return (
      <div>
        {buildingConstants.noBuildingsFoundMessage}
        <div>
          <Button
            onClick={() => {
              navigate("/create/building");
            }}
          >
            {buildingConstants.registerBuilding}
          </Button>
        </div>
      </div>
    );
  }

  return (
    <>
      {allBuildings.map((building) => (
        <div key={building.buildingId}>
          <Accordion>
            <AccordionSummary>
              <h1 key={building.buildingId}>{building.alias}</h1>
            </AccordionSummary>
            <AccordionDetails>
              <h2>{buildingConstants.buildingInfo}</h2>
              <div className="text-field-container">
                <TextField
                  value={building.dateBuilt}
                  label="Date Built"
                  disabled
                />
                <TextField
                  value={building.floorNum}
                  label="Number of Floors"
                  disabled
                />
                <TextField
                  value={building.numOfElevators}
                  label="Number of Elevators"
                  disabled
                />
                <TextField
                  value={building.totalBuildingSize}
                  label="Total Building Size(in m2)"
                  disabled
                />
                <TextField
                  value={building.buildingAddress.country}
                  label="Building Country"
                  disabled
                />
                <TextField
                  value={building.buildingAddress.city}
                  label="Building City"
                  disabled
                />
                <TextField
                  value={`${building.buildingAddress.streetName},${building.buildingAddress.streetNumber}, ${building.buildingAddress.district}`}
                  label="Building Address"
                  disabled
                />
              </div>
              <h2>{buildingConstants.properties}</h2>
              <div>
                <DataGrid
                  rows={building.buildingProperties ?? []}
                  getRowId={(row) => row.propertyId}
                  columns={propertyColumns}
                  pageSizeOptions={editableTableConstants.pageSizeOptions}
                  slots={{ toolbar: GridToolbar }}
                />
              </div>
              <h2>{buildingConstants.expenses}</h2>
              <div>
                <DataGrid
                  rows={building.buildingExpenses ?? []}
                  getRowId={(row) => row.buildingExpenseId}
                  columns={expensesColumns}
                  pageSizeOptions={editableTableConstants.pageSizeOptions}
                  slots={{ toolbar: GridToolbar }}
                />
              </div>
              <div>
                <Button
                  onClick={() => {
                    handleDelete(building.buildingId, building.alias ?? "");
                  }}
                >
                  {buildingConstants.remove}
                </Button>
              </div>
            </AccordionDetails>
          </Accordion>
          <Divider />
        </div>
      ))}
    </>
  );
};
export default BuildingsTable;
