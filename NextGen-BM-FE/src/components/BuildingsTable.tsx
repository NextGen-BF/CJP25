import { FC, useEffect } from "react";
import { RootState, useAppDispatch } from "../redux/store";
import { useSelector } from "react-redux";
import { getAllBuildings } from "../redux/services/buildingService";
import { Accordion, AccordionDetails, AccordionSummary } from "@mui/material";
import { DataGrid, GridColDef } from "@mui/x-data-grid";

const BuildingsTable: FC = () => {
  const dispatch = useAppDispatch();
  const userId = useSelector((state: RootState) => state.loginReducer.value.userId)

  const allBuildings = useSelector((state: RootState) => state.buildingReducer.value);
  useEffect(() => {
    dispatch(getAllBuildings(userId));
  }, [dispatch]);

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

  return (
    <>
      {allBuildings.map((building) => (
        <div>
          <Accordion>
            <AccordionSummary>
              <h2 key={building.buildingId}>{building.alias}</h2>
            </AccordionSummary>
            <AccordionDetails>
              Properties:
              <div>
                <DataGrid
                  rows={building.buildingProperties ?? []}
                  getRowId={(row) => row.propertyNumber}
                  columns={propertyColumns}
                  pageSizeOptions={pageSizeOptions}
                />
              </div>
              Expenses:
              <div>
                <DataGrid
                  rows={building.buildingExpenses ?? []}
                  getRowId={(row) => row.buildingExpenseId}
                  columns={expensesColumns}
                  pageSizeOptions={pageSizeOptions} />
              </div>
            </AccordionDetails>
          </Accordion>
        </div>
      ))}
    </>
  )
}
export default BuildingsTable;