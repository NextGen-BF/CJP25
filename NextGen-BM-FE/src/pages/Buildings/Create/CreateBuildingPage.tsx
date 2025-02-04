import { Box, Button, TextField } from "@mui/material";
import { FC, useState } from "react";
import { Address, Building } from "../../../models/building";
import { useAppDispatch } from "../../../redux/store";
import { createBuilding } from "../../../redux/services/buildingService";
import { createBuildingConstants } from "../../../constants/constants";
import "./createBuilding.scss";
import { DataGrid, GridColDef } from "@mui/x-data-grid";
import { Property } from "../../../models/property";

const CreateBuildingPage: FC = () => {
  const [rows, setRows] = useState<Property[]>([{
        propertyId: 0,
        propertyNumber: 1,
        buildingId: 1,
        size: 1,
        floor: 1,
        sizeOfIdealParts: 1,
        entranceIsExternal: false,
        propertyExpenses: null,
        payments: null,
        residentHistory: null
  }]);
  const columns: GridColDef<(typeof rows)[number]>[] = [
    {field: "id", headerName: "ID", width: 70},
    { field: "propertyNumber", headerName: "Property Number", width: 150, type:'number', editable: true },
    { field: "size", headerName: "Property Size", width: 150, editable: true, type: 'number'},
    { field: "floor", headerName: "Property Floor", width: 150, editable: true, type:'number' },
    { field: "sizeOfIdealParts", headerName: "Ideal Parts", width: 150, editable: true, type: 'number' },
    {field: "entranceIsExternal", headerName: "External Entrance", width: 150,editable: true, type: 'boolean'},
  ];
  const dispatch = useAppDispatch();
  const [address, setAddress] = useState<Address>({
    streetName: "",
    streetNumber: "",
    entrance: "",
    district: "",
    city: "",
    postalCode: "",
    Country: "",
  });
  const [formData, setFormData] = useState<Building>({
    buildingId: 0,
    buildingAddress: address,
    alias: "",
    floorNum: 1,
    totalBuildingSize: 10.0,
    dateBuilt: new Date(),
    numOfElevators: 1,
    buildingExpenses: null,
    buildingProperties: rows,
  });

  const handleAddressChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>,
  ) => {
    const { name, value } = e.target;
    setAddress((previousData) => ({ ...previousData, [name]: value }));
    setFormData((previousData) => ({ ...previousData, address: address }));
  };

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>,
  ) => {
    const { name, value } = e.target;
    setFormData((previousData) => ({ ...previousData, [name]: value }));
  };

  const handlePropertyChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>,
  ) => {
    const { name, value } = e.target;
    setRows((previousData) => ({ ...previousData, [name]: value }));
    console.log(rows)
    setFormData((previousData) => ({ ...previousData, [name]: value }));
  };

  const handleCreateBuildingSubmission = (
    event: React.FormEvent<HTMLFormElement>,
  ) => {
    event.preventDefault();
    dispatch(createBuilding(formData));
  };

  return (
    <div>
      <div className="text-field-container">
        <form
          className="create-building-form"
          onSubmit={(e) => handleCreateBuildingSubmission(e)}
        >
          <h1 className="create-building-header">
            {createBuildingConstants.createHeader}
          </h1>
          <TextField
            name="alias"
            label="Building Alias"
            type="text"
            variant="outlined"
            size="small"
            fullWidth
            onChange={(e) => handleChange(e)}
          />
          <TextField
            name="floorNum"
            label="Amount of Building Floors"
            type="number"
            variant="outlined"
            size="small"
            fullWidth
            onChange={(e) => handleChange(e)}
          />
          <TextField
            name="totalBuildingSize"
            label="Building Size"
            type="text"
            variant="outlined"
            size="small"
            fullWidth
            onChange={(e) => handleChange(e)}
          />
          <TextField
            name="dateBuilt"
            slotProps={{ inputLabel: { shrink: true } }}
            label="Date Built"
            type="date"
            variant="outlined"
            size="small"
            fullWidth
            onChange={(e) => handleChange(e)}
          />
          <TextField
            name="numOfElevators"
            label="Amount of Elevators"
            type="number"
            variant="outlined"
            size="small"
            fullWidth
            onChange={(e) => handleChange(e)}
          />
          <TextField
            name="streetNumber"
            label="Street Number"
            type="text"
            variant="outlined"
            size="small"
            fullWidth
            onChange={(e) => handleAddressChange(e)}
          />
          <TextField
            name="streetName"
            label="Street Name"
            type="text"
            variant="outlined"
            size="small"
            fullWidth
            onChange={(e) => handleAddressChange(e)}
          />
          <TextField
            name="district"
            label="District"
            type="text"
            variant="outlined"
            size="small"
            fullWidth
            onChange={(e) => handleAddressChange(e)}
          />
          <TextField
            name="entrance"
            label="Entrance"
            type="text"
            variant="outlined"
            size="small"
            fullWidth
            onChange={(e) => handleAddressChange(e)}
          />
          <TextField
            name="city"
            label="City"
            type="text"
            variant="outlined"
            size="small"
            fullWidth
            onChange={(e) => handleAddressChange(e)}
          />
          <TextField
            name="postalCode"
            label="Postal Code"
            type="text"
            variant="outlined"
            size="small"
            fullWidth
            onChange={(e) => handleAddressChange(e)}
          />
          <TextField
            name="Country"
            label="Country"
            type="text"
            variant="outlined"
            size="small"
            fullWidth
            onChange={(e) => handleAddressChange(e)}
          />
          <Button fullWidth type="submit">
            {createBuildingConstants.create}
          </Button>
        </form>
      </div>
      <div className="property-table">
        <TextField
          name="propertyNumber"
          label="Property Number"
          type="text"
          variant="outlined"
          size="small"
          fullWidth
          onChange={(e) => handlePropertyChange(e)}
        />
        <Box>
          <DataGrid
            rows={rows}
            columns={columns}
            getRowId={(row) => row.propertyId}
            initialState={{
              pagination: {
                paginationModel: {
                  pageSize: 5,
                },
              },
            }}
            pageSizeOptions={[5]}
            checkboxSelection
          />
        </Box>
      </div>
    </div>
  );
};
export default CreateBuildingPage;
