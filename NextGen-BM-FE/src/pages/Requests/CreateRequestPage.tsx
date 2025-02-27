import { FC, useEffect } from "react";
import { createRequest } from "../../models/requests";
import { SubmitHandler, useForm } from "react-hook-form";
import { Button, MenuItem, TextField } from "@mui/material";
import "./createRequestPage.scss";
import FileUploadButton from "../../components/Request/FileUploadButton";
import { useSelector } from "react-redux";
import { RootState, useAppDispatch } from "../../redux/store";
import { fileTypeConstants } from "../../constants/constants";
import {
  getAllBuildings,
  getBuildingsByUserId,
} from "../../redux/services/buildingService";
import { transformRequest } from "../../utils/requestConverter";
import { useNavigate } from "react-router-dom";
import { createRepairRequest } from "../../redux/services/requestService";
import { uploadFile } from "../../redux/services/documentService";
import UploadedFilesList from "../../components/Request/UploadedFilesList";

const CreateRequestPage: FC = () => {
  const navigate = useNavigate();
  const documents = useSelector((state: RootState) => state.documentReducer);
  const dispatch = useAppDispatch();
  const user = useSelector((state: RootState) => state.loginReducer.value);
  const {
    register,
    handleSubmit,
    watch,
    formState: { errors, isSubmitting },
  } = useForm<createRequest>({
    defaultValues: {
      userId: user.userId,
      startDate: new Date(),
    },
  });
  const selectedRequestType = watch("requestType");
  const requestTypes = ["Building Property Link", "Repair"];
  const buildings = useSelector(
    (state: RootState) => state.buildingReducer.value,
  );

  useEffect(() => {
    if (!user.isLoggedIn) navigate("/login");
    if (selectedRequestType === "Repair") {
      dispatch(getBuildingsByUserId(user.userId));
    } else {
      dispatch(getAllBuildings());
    }
  }, [selectedRequestType, user]);

  //TODO: Add toast notifs here
  const onSubmit: SubmitHandler<createRequest> = async (data) => {
    try {
      if (data.requestType == "Repair") {
        const repairRequest = transformRequest(data);
        let files = new FormData();
        if (repairRequest && "requestId" in repairRequest) {
          documents.value.forEach((doc) => {
            files.append("files", doc);
          });
          var request = await dispatch(
            createRepairRequest(repairRequest),
          ).unwrap();
          await dispatch(
            uploadFile({
              files: files,
              requestId: request.requestId,
              requestType: data.requestType,
            }),
          ).unwrap();
        }
      } else {
        const buildingRequest = transformRequest(data);
        console.log(buildingRequest);
      }
    } catch (error) {}
  };

  return (
    <div>
      <form onSubmit={handleSubmit(onSubmit)}>
        <div className="container">
          <TextField
            label="Request Title"
            {...register("requestTitle", {
              required: "Request Title is required!",
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
          >
            {buildings.map((building) => (
              <MenuItem value={building.buildingId}>{building.alias}</MenuItem>
            ))}
          </TextField>
          {selectedRequestType == "Building Property Link" && (
            <>
              {/* TODO: Add actual roles */}
              <TextField label="Role within building" className="form-field" />
              <TextField
                label="Property request is about"
                className="form-field"
              />
            </>
          )}
        </div>
        <div>
          {errors.requestTitle && (
            <p className="error-message">{errors.requestType?.message}</p>
          )}
        </div>
        {selectedRequestType == "Repair" && (
          <>
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
          </>
        )}
        <div className="container">
          {errors.description && (
            <span className="error-message">{errors.description.message}</span>
          )}
        </div>
        <UploadedFilesList />
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
