import { FC, useState } from "react";
import { createRequest } from "../../models/requests";
import { SubmitHandler, useForm } from "react-hook-form";
import { Building } from "../../models/building";
import { Button, MenuItem, TextField } from "@mui/material";
import "./createRequestPage.scss";
import FileUploadButton from "../../components/FileUploadButton";

const CreateRequestPage: FC = () => {
  const [buildings, setBuilding] = useState<Building[]>([]);
  const {
    register,
    handleSubmit,
    watch,
    formState: { errors, isSubmitting },
  } = useForm<createRequest>({
    defaultValues: {},
  });

  const onSubmit: SubmitHandler<createRequest> = async (data) => {
    console.log(selectedRequestType);
    console.log(data);
  };
  const selectedRequestType = watch("requestType");
  const requestTypes = ["Building Property Link", "Repair"];

  return (
    <div>
      <form onSubmit={handleSubmit(onSubmit)}>
        <div className="container">
          <TextField
            label="Request Title"
            {...register("requestTitle", {
              required: true,
            })}
            className="form-field"
          />
          <TextField
            label="Request Type"
            {...register("requestType")}
            className="form-field"
            select
          >
            {requestTypes.map((index) => (
              <MenuItem value={index}>{index}</MenuItem>
            ))}
          </TextField>
          <TextField
            {...register("buildingId")}
            className="form-field"
            select
            label="Request Building"
          ></TextField>
        </div>
        {selectedRequestType == "Building Property Link" && (
          <div className="container">
            <TextField label="Role within building" className="form-field" />
            <TextField
              label="Property request is about"
              className="form-field"
            />
          </div>
        )}
        {selectedRequestType == "Repair" && (
          <div className="container">
            <TextField
              {...register("description", {
                validate: (value) =>
                  selectedRequestType == "Repair" && value == ""
                    ? "Description field is required!"
                    : true,
              })}
              multiline
              minRows={3}
              className="form-field"
              label="Description"
            />
          </div>
        )}
        <div className="container"></div>
        <div className="anchored-container">
          <FileUploadButton />
          <Button type="submit" className="button" disabled={isSubmitting}>
            Submit request
          </Button>
        </div>
      </form>
    </div>
  );
};
export default CreateRequestPage;
