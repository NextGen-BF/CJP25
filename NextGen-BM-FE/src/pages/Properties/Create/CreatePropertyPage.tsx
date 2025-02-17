import { FC } from "react";
import { useForm, SubmitHandler, Controller, Control, FieldValues } from "react-hook-form";
import { Property } from "../../../models/property";
import { RootState, useAppDispatch } from "../../../redux/store";
import { createProperty } from "../../../redux/services/propertyService";
import TextField from "@mui/material/TextField";
import { Button, InputLabel, MenuItem, Select } from "@mui/material";
import { Building } from "../../../models/building";
import { getAllBuildings } from "../../../redux/services/buildingService";
import { useSelector } from "react-redux";
import "./createPropertyPage.scss";
import { CreatePropertyInput } from "./CreatePropertyControlledInput";
import { createPropertyPageStyles } from "./CreatePropertyPageStyles";

const textFieldInputProps=[
  {
    name: "propertyNumber",
    label: "Property Number",
    type: "number",
    required: true
  },
  {
    name: "floor",
    label: "Floor",
    type: "number",
    required: true,
  },
  {
    name: "size",
    label: "Size",
    type: "number",
    required: true,
  },
  {
    name: "sizeOfIdealParts",
    label: "Size of ideal parts",
    type: "number",
    required: true,
  }
]

const CreatePropertyPage: FC = () => {
  const dispatch = useAppDispatch();
  const {control, handleSubmit} = useForm<Property>();
  const onSubmit: SubmitHandler<Property> = (data) => dispatch(createProperty(data));
  
  const buildings:Building[]=useSelector((state: RootState) => state.buildingReducer.value);
  const buildingList=buildings?buildings.map(building=>
    <MenuItem value={building.buildingId}>{building.alias}</MenuItem>
  ):[];
  const textInputFields=textFieldInputProps.map(props=>
    <CreatePropertyInput name={props.name} label={props.label} type={props.type} required={props.required} control={control as unknown as Control}/>
  );

  return (
    <div>
      <h1>Add a new property</h1>
      
      <form className="create-property-form" onSubmit={handleSubmit(onSubmit)}>
        {textInputFields}
        <Controller
          name="entranceIsExternal"
          control={control}
          render={({ field }) => (
            <TextField
            {...field}
            sx={createPropertyPageStyles.inputStyles}
            label="External entrance"
            variant="standard"
            type="checkbox"
            defaultValue={false}
            size="small"
            />
          )}
        />
        <Controller
          name="buildingId"
          control={control}
          render={({ field }) => (
            <TextField
            {...field}
            sx={createPropertyPageStyles.inputStyles}
            select
            required={true}
            label="Building"
            size="small"
            //should eventually only return the manager's buildings
            onFocus={()=>dispatch(getAllBuildings())}
            >
              {buildingList}
            </TextField>
          )}
        />
        <Button sx={createPropertyPageStyles.inputStyles} type="submit" variant="contained">
          Create Property
        </Button>
      </form>
    </div>
  );
};
export default CreatePropertyPage;
