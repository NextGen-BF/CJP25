import { FC } from "react";
import { useForm, SubmitHandler, Controller, Control } from "react-hook-form";
import { Property, PropertyType } from "../../../models/property";
import { RootState, useAppDispatch } from "../../../redux/store";
import { createProperty, getPropertyTypes } from "../../../redux/services/propertyService";
import TextField from "@mui/material/TextField";
import { Button, MenuItem } from "@mui/material";
import { Building } from "../../../models/building";
import { getBuildingsByUserId } from "../../../redux/services/buildingService";
import { useSelector } from "react-redux";
import "./createPropertyPage.scss";
import { CreatePropertyInput } from "./CreatePropertyControlledInput";
import { createPropertyPageStyles } from "./CreatePropertyPageStyles";
import { setSnackbar } from "../../../redux/slices/snackbarSlice";
import { ErrorSnackbarConstants, SucessSnackbarConstants } from "../../../constants/snackbarConstants.ts";
import { createPropertyPageConstants, propertyFormConstants } from "../../../constants/createPropertyConstants.ts";

const textFieldInputProps =(building:Building|undefined, type:PropertyType)=> [
  {
    name: "propertyNumber",
    label: "Property Number",
    type: "number",
    required: true,
    rules:{
      validate: (value:number)=>{
        console.log(building, type);
        return !(building?.buildingProperties?.find(p=>p.propertyNumber==value&&p.propertyType.typeId==type.typeId)) || "Number already in use"
      }
    }, 
  },
  {
    name: "floor",
    label: "Floor",
    type: "number",
    required: true,
    rules:{
      validate: (value:number)=>{
        return building?.floorNum as number > value || "Invalid floor number"
      }
    }
  },
  {
    name: "size",
    label: "Size",
    type: "number",
    required: true,
    rules:{
      min: {value: 0, message: "oops"}
    }
  },
  {
    name: "sizeOfIdealParts",
    label: "Size of ideal parts",
    type: "number",
    required: true,
    rules:{
      min:0,
      max:100
    }
  },
];

const CreatePropertyPage: FC = () => {
  const dispatch = useAppDispatch();
  const { getValues, control, handleSubmit, formState:{errors} } = useForm<Property>({mode: "onChange"});
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
  const userId: number = useSelector(
    (state: RootState) => state.loginReducer.value.userId,
  );
  const buildingList = buildings
    ? buildings.map((building) => (
        <MenuItem value={building.buildingId}>{building.alias}</MenuItem>
      ))
    : [];
  const typeList = propertyTypes.map((type) =>(
    <MenuItem value={type.typeId}>{type.title}</MenuItem>
  ));
  const textInputFields = textFieldInputProps(buildings.find(b=>b.buildingId===getValues().buildingId),
                                              getValues().propertyType).map((props) => (
    <>
      <CreatePropertyInput
        name={props.name}
        label={props.label}
        type={props.type}
        required={props.required}
        rules={props.rules}
        control={control as unknown as Control}
      />
      {(errors as any)[props.name] && (
            <div className="error-message">
              {(errors as any)[props.name].message}
            </div>
          )}
    </>
  ));

  return (
    <div>
      <h1>{createPropertyPageConstants.pageTitle}</h1>

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
              onFocus={() => dispatch(getBuildingsByUserId(userId))}
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
          {propertyFormConstants.submitButton}
        </Button>
      </form>
    </div>
  );
};
export default CreatePropertyPage;
