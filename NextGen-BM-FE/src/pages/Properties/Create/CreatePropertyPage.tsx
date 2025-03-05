import { FC } from "react";
import { useForm, SubmitHandler, Controller, Control } from "react-hook-form";
import { Property } from "../../../models/property";
import { RootState, useAppDispatch } from "../../../redux/store";
import { createProperty } from "../../../redux/services/propertyService";
import TextField from "@mui/material/TextField";
import { Button, MenuItem, Paper, Typography } from "@mui/material";
import { Building } from "../../../models/building";
import { getAllBuildings } from "../../../redux/services/buildingService";
import { useSelector } from "react-redux";
import "./createPropertyPage.scss";
import { CreatePropertyInput } from "./CreatePropertyControlledInput";
import { createPropertyPageStyles } from "./CreatePropertyPageStyles";
import { setSnackbar } from "../../../redux/slices/snackbarSlice";
import {
  ErrorSnackbarConstants,
  SucessSnackbarConstants,
} from "../../../constants/snackbarConstants.ts";

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
  const buildingList = buildings
    ? buildings.map((building) => (
        <MenuItem value={building.buildingId}>{building.alias}</MenuItem>
      ))
    : [];
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
      <Paper className="paper-container">
        <Typography variant="h4" style={{ textAlign: "center" }}>
          Add a new property
        </Typography>
        <form onSubmit={handleSubmit(onSubmit)}>
          <div className="container">
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
          </div>
        </form>
      </Paper>
    </div>
  );
};
export default CreatePropertyPage;
