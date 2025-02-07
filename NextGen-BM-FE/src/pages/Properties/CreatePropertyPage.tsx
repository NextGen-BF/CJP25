import { FC } from "react";
import { useForm, SubmitHandler, Controller } from "react-hook-form";
import { Property } from "../../models/property";
import { useAppDispatch } from "../../redux/store";
import { createProperty } from "../../redux/services/propertyService";
import TextField from "@mui/material/TextField";
import { Button } from "@mui/material";

const CreatePropertyPage: FC = () => {
  const dispatch = useAppDispatch();
  const {control, handleSubmit} = useForm<Property>();
  const onSubmit: SubmitHandler<Property> = (data) => {console.log(data); dispatch(createProperty(data))};

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
        <Button type="submit">
          Create Property
        </Button>
      </form>
    </div>
  );
};
export default CreatePropertyPage;
