import { FC } from "react";
import { createRequest } from "../../models/requests";
import { SubmitHandler, useForm } from "react-hook-form";
import { Button, Divider, MenuItem, TextField } from "@mui/material";
import "./createRequestPage.scss";
import FileUploadButton from "../../components/FileUploadButton";
import { useSelector } from "react-redux";
import { RootState, useAppDispatch } from "../../redux/store";
import { removeDocument } from "../../redux/slices/documentSlice";
import { fileTypeConstants } from "../../constants/constants";

const CreateRequestPage: FC = () => {
  const documents = useSelector((state: RootState) => state.documentReducer);
  const dispatch = useAppDispatch();
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
        {documents.value.map((file) => (
          <>
            <div className="container">
              {file.type.includes("image") && (
                <img
                  src={URL.createObjectURL(file)}
                  className="image"
                  width="300px"
                />
              )}
              {file.type.includes("pdf") && (
                <object data={URL.createObjectURL(file)} />
              )}
              <p>
                {fileTypeConstants.fileName} {file.name}
              </p>
              <Button onClick={() => dispatch(removeDocument(file))}>X</Button>
            </div>
            <Divider />
          </>
        ))}
        <div className="container"></div>
        <div className="anchored-container">
          <FileUploadButton />
          <Button type="submit" className="button" disabled={isSubmitting}>
            {fileTypeConstants.submit}
          </Button>
        </div>
      </form>
    </div>
  );
};
export default CreateRequestPage;
