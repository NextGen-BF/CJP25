import { Button, TextField } from "@mui/material";
import { FC, useState } from "react";
import { Address, Building } from "../../../models/building";
import { RootState, useAppDispatch } from "../../../redux/store";
import { createBuilding } from "../../../redux/services/buildingService";
import { createBuildingConstants } from "../../../constants/constants";
import "./createBuilding.scss";
import EditableTable from "../../../components/EditableTable";
import { useSelector } from "react-redux";

const CreateBuildingPage: FC = () => {
  const dispatch = useAppDispatch();
  const buildingProperties = useSelector((state: RootState) => state.propertyReducer.value)

  const [address, setAddress] = useState<Address>({
    addressId: 0,
    streetName: "",
    streetNumber: 0,
    entrance: "",
    district: "",
    city: "",
    postalCode: "",
    country: "",
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
    buildingProperties: null,
  });

  const handleAddressChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>,
  ) => {
    const { name, value } = e.target;
    setAddress((previousData) => ({ ...previousData, [name]: value }));
    setFormData((previousData) => ({ ...previousData, buildingAddress: address }));
  };

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>,
  ) => {
    const { name, value } = e.target;
    //TODO: Add Validation for negative numbers
    setFormData((previousData) => ({ ...previousData, [name]: value }));
  };

  const handleCreateBuildingSubmission = (
    event: React.FormEvent<HTMLFormElement>,
  ) => {
    event.preventDefault();
    formData.buildingProperties = buildingProperties;
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
        <EditableTable />
      </div>
    </div>
  );
};
export default CreateBuildingPage;
