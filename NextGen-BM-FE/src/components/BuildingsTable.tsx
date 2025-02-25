import { FC, useEffect } from "react";
import { RootState, useAppDispatch } from "../redux/store";
import { useSelector } from "react-redux";
import { deleteUserBuildingLink, getBuildingsByUserId } from "../redux/services/buildingService";
import { Accordion, AccordionDetails, AccordionSummary, Button, Divider, TextField } from "@mui/material";
import { DataGrid, GridColDef, GridToolbar } from "@mui/x-data-grid";
import "./scss/buildingTable.scss";
import { useNavigate } from "react-router-dom";
import { PropertyType } from "../models/property";

const BuildingsTable: FC = () => {
  const dispatch = useAppDispatch();
  const userId = useSelector((state: RootState) => state.loginReducer.value.userId)
  const navigate = useNavigate();


  useEffect(() => {
    if (userId)
      dispatch(getBuildingsByUserId(userId));
  }, [dispatch, userId]);

  const allBuildings = useSelector((state: RootState) => state.buildingReducer.value);

  const pageSizeOptions = [5, 10, 25, 50, 100]
  const propertyColumns: GridColDef[] = [
    {
      field: "propertyNumber",
      headerName: "Property Number",
      width: 150,
    },
    {
      field: "size",
      headerName: "Size (in m2)",
      width: 120,
      type: "number",
    },
    {
      field: "floor",
      headerName: "Floor",
      width: 120,
      type: "number",
    },
    {
      field: "sizeOfIdealParts",
      headerName: "Ideal Parts (in %)",
      width: 180,
      type: "number",
    },
    {
      field: "entranceIsExternal",
      headerName: "External Entrance",
      width: 180,
      type: "boolean",
    },
    {
      field: "propertyType",
      headerName: "Property Type",
      width: 150,
      valueGetter: (propertyType:PropertyType) => propertyType?.title
    }
  ]

  const expensesColumns: GridColDef[] = [
    {
      field: "title",
      headerName: "Title",
      width: 180,
      type: "string",
    },
    {
      field: "totalAmount",
      headerName: "Amount Owed",
      width: 180,
      type: "number",
    },
    {
      field: "supplier",
      headerName: "Supplier",
      width: 180,
      type: "string",
    },
    {
      field: "dateOpened",
      headerName: "Date Opened",
      width: 180,
      type: "string",
    },
    {
      field: "dueDate",
      headerName: "Due Date",
      width: 180,
      type: "string",
    },
    {
      field: "paymentDate",
      headerName: "Date Paid",
      width: 180,
      type: "string",
    },
    {
      field: "description",
      headerName: "Description",
      width: 180,
      type: "string",
    },
  ]

  //Temp solution, will use modal later to get confirmation.
  const handleDelete = async (buildingId: number, alias: string) => {
    if (confirm("Are you sure you want to delete link with building: " + alias)) {
      dispatch(deleteUserBuildingLink({ userId, buildingId }))
    } else alert(`Building link with ${alias ?? buildingId} was NOT deleted`);
  };

  if (allBuildings.length < 1) {
    return (
      <div>No buildings found for your user. Register a building here:
        <div>
          <Button onClick={() => { navigate("/create/building") }}>Register a building</Button>
        </div>
      </div>
    )
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
              <h2>
                Building Information:
              </h2>
              <div className="text-field-container">
                <TextField value={building.dateBuilt} label="Date Built" disabled />
                <TextField value={building.floorNum} label="Number of Floors" disabled />
                <TextField value={building.numOfElevators} label="Number of Elevators" disabled />
                <TextField value={building.totalBuildingSize} label="Total Building Size(in m2)" disabled />
                <TextField value={building.buildingAddress.country} label="Building Country" disabled />
                <TextField value={building.buildingAddress.city} label="Building City" disabled />
                <TextField value={`${building.buildingAddress.streetName},${building.buildingAddress.streetNumber}, ${building.buildingAddress.district}`} label="Building Address" disabled />
              </div>
              <h2>
                Properties:
              </h2>
              <div>
                <DataGrid
                  rows={building.buildingProperties ?? []}
                  getRowId={(row) => row.propertyId}
                  columns={propertyColumns}
                  pageSizeOptions={pageSizeOptions}
                  slots={{ toolbar: GridToolbar }}
                />
              </div>
              <h2>
                Expenses:
              </h2>
              <div>
                <DataGrid
                  rows={building.buildingExpenses ?? []}
                  getRowId={(row) => row.buildingExpenseId}
                  columns={expensesColumns}
                  pageSizeOptions={pageSizeOptions}
                  slots={{ toolbar: GridToolbar }}
                />
              </div>
              <div>
                <Button onClick={() => { handleDelete(building.buildingId, building.alias ?? "") }}>Remove from user</Button>
              </div>
            </AccordionDetails>
          </Accordion>
          <Divider />
        </div>
      ))}
    </>
  )
}
export default BuildingsTable;