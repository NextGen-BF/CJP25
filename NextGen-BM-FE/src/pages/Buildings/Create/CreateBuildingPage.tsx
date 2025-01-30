import { Button, TextField } from "@mui/material";
import { FC, useState } from "react";
import { Address, Building } from "../../../models/building";
import { useAppDispatch } from "../../../redux/store";
import { createBuilding } from "../../../redux/services/buildingService";
import "./createBuilding.scss"

const CreateBuildingPage: FC = () => {
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
    buildingProperties: null,
  });

  const handleAddressChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>,
  ) => {
    const { name, value } = e.target;
    setAddress((previousData) => ({ ...previousData, [name]: value }));
    setFormData((previousData)=> ({ ...previousData, address: address }));
  };

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>,
  ) => {
    const { name, value } = e.target;
    setFormData((previousData) => ({ ...previousData, [name]: value }));
  };

  const submit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    dispatch(createBuilding(formData));
  }


  return (
    <div className="text-field-container">
      <form className="create-building-form" onSubmit={(e) => submit(e)}>
        <h1 className="create-building-header">Create a Building</h1>
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
          Create
        </Button>
      </form>
    </div>
  );
};
export default CreateBuildingPage;
