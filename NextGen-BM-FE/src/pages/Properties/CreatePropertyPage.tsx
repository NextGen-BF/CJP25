import { FC } from "react";
import { useForm, SubmitHandler, Controller } from "react-hook-form";
import { Property } from "../../models/property";
import { RootState, useAppDispatch } from "../../redux/store";
import { createProperty } from "../../redux/services/propertyService";
import TextField from "@mui/material/TextField";
import { Button, MenuItem, Select } from "@mui/material";
import { Building } from "../../models/building";
import { Search } from "@mui/icons-material";
import { getAllBuildings } from "../../redux/services/buildingService";
import { useSelector } from "react-redux";

const CreatePropertyPage: FC = () => {
  const dispatch = useAppDispatch();
  const {control, handleSubmit} = useForm<Property>();
  const onSubmit: SubmitHandler<Property> = (data) => {console.log(data); dispatch(createProperty(data))};
  
  const buildings:Building[]=useSelector((state: RootState) => state.buildingReducer.value);
  const buildingList=buildings?buildings.map(building=>
    <MenuItem value={building.buildingId}>{building.alias}</MenuItem>
  ):[];

  return (
    <div>
      <h1>Create Property Page</h1>
      <form onSubmit={handleSubmit(onSubmit)}>
        <Controller
          name="propertyNumber"
          control={control}
          render={({ field }) => (
            <TextField
            {...field}
            required={true}
            label="Property Number"
            type="number"
            variant="outlined"
            size="small"
            fullWidth
            />
          )}
        />
        <Controller
          name="floor"
          control={control}
          render={({ field }) => (
            <TextField
            {...field}
            required={true}
            label="Floor"
            type="number"
            variant="outlined"
            size="small"
            fullWidth
            />
          )}
        />
        <Controller
          name="size"
          control={control}
          render={({ field }) => (
            <TextField
            {...field}
            label="Size"
            type="number"
            variant="outlined"
            size="small"
            fullWidth
            />
          )}
        />
        <Controller
          name="sizeOfIdealParts"
          control={control}
          render={({ field }) => (
            <TextField
            {...field}
            required={true}
            label="Size of ideal parts"
            type="number"
            variant="outlined"
            size="small"
            fullWidth
            />
          )}
        />
        <Controller
          name="entranceIsExternal"
          control={control}
          render={({ field }) => (
            <TextField
            {...field}
            label="External entrance"
            type="checkbox"
            size="small"
            fullWidth
            />
          )}
        />
        <Controller
          name="buildingId"
          control={control}
          render={({ field }) => (
            <Select
            {...field}
            required={true}
            label="Building"
            size="small"
            fullWidth
            onOpen={()=>dispatch(getAllBuildings())}
            >
              {buildingList}
            </Select>
          )}
        />
        <Button type="submit">
          Create Property
        </Button>
      </form>
    </div>
  );
};
export default CreatePropertyPage;
