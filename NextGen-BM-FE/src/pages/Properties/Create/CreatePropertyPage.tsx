import { FC } from "react";
import { useForm, SubmitHandler, Controller, Control } from "react-hook-form";
import { Property, PropertyType } from "../../../models/property";
import { RootState, useAppDispatch } from "../../../redux/store";
import { createProperty, getPropertyTypes } from "../../../redux/services/propertyService";
import TextField from "@mui/material/TextField";
import { Button, MenuItem } from "@mui/material";
import { Building } from "../../../models/building";
import { getAllBuildings } from "../../../redux/services/buildingService";
import { useSelector } from "react-redux";
import "./createPropertyPage.scss";
import { CreatePropertyInput } from "./CreatePropertyControlledInput";
import { createPropertyPageStyles } from "./CreatePropertyPageStyles";
import { setSnackbar } from "../../../redux/slices/snackbarSlice";
import { ErrorSnackbarConstants, SucessSnackbarConstants } from "../../../constants/snackbarConstants.ts";

const textFieldInputProps = [
  {
    name: "propertyNumber",
    label: "Property Number",
    type: "number",
    required: true,
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
  },
];

const CreatePropertyPage: FC = () => {
  const dispatch = useAppDispatch();
  const { control, handleSubmit } = useForm<Property>();
  const onSubmit: SubmitHandler<Property> = async (data) => {
    data.propertyType = propertyTypes.find((type)=>type.typeId==data.propertyType.typeId)??{typeId:0, title:"", description:""}
    console.log(data);
    try {
      await dispatch(createProperty(data)).unwrap();
      dispatch(
        setSnackbar({
          snackbarOpen: true,
          snackbarType: "success",
          snackbarMessage: SucessSnackbarConstants.createPropertySucess,
        }),
      );
    } catch (error) {
      dispatch(
        setSnackbar({
          snackbarOpen: true,
          snackbarType: "error",
          snackbarMessage: ErrorSnackbarConstants.createPropertyError,
        }),
      );
    }
  };

  const buildings: Building[] = useSelector(
    (state: RootState) => state.buildingReducer.value,
  );
  const propertyTypes: PropertyType[] = useSelector(
    (state: RootState) => state.propertyReducer.types,
  );
  const buildingList = buildings
    ? buildings.map((building) => (
        <MenuItem value={building.buildingId}>{building.alias}</MenuItem>
      ))
    : [];
  const typeList = propertyTypes.map((type) =>(
    <MenuItem value={type.typeId}>{type.title}</MenuItem>
  ));
  const textInputFields = textFieldInputProps.map((props) => (
    <CreatePropertyInput
      name={props.name}
      label={props.label}
      type={props.type}
      required={props.required}
      control={control as unknown as Control}
    />
  ));

  return (
    <div>
      <h1>Add a new property</h1>

      <form className="create-property-form" onSubmit={handleSubmit(onSubmit)}>
      <Controller
          name="propertyType.typeId"
          control={control}
          render={({ field }) => (
            <TextField
              {...field}
              sx={createPropertyPageStyles.inputStyles}
              select
              required={true}
              label="Type"
              size="small"
              onFocus={() => dispatch(getPropertyTypes())}
            >
              {typeList}
            </TextField>
          )}
        />
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
              onFocus={() => dispatch(getAllBuildings())}
            >
              {buildingList}
            </TextField>
          )}
        />
        <Button
          sx={createPropertyPageStyles.inputStyles}
          type="submit"
          variant="contained"
        >
          Create Property
        </Button>
      </form>
    </div>
  );
};
export default CreatePropertyPage;
