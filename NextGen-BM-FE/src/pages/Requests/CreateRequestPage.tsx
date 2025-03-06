import { FC, useEffect } from "react";
import { createRequest } from "../../models/requests";
import { SubmitHandler, useForm } from "react-hook-form";
import { Button, MenuItem, Paper, TextField, Typography } from "@mui/material";
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
import { setSnackbar } from "../../redux/slices/snackbarSlice";
import {
  ErrorSnackbarConstants,
  SucessSnackbarConstants,
} from "../../constants/snackbarConstants";
import Overlay from "../Overlay";

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

  const onSubmit: SubmitHandler<createRequest> = async (data) => {
    try {
      let files = new FormData();
      documents.value.forEach((doc) => {
        files.append("files", doc);
      });
      if (data.requestType == "Repair") {
        const repairRequest = transformRequest(data);
        if (repairRequest && "requestId" in repairRequest) {
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
          dispatch(
            setSnackbar({
              snackbarOpen: true,
              snackbarType: "success",
              snackbarMessage: SucessSnackbarConstants.createRequestSuccess,
            }),
          );
        }
      } else {
        const buildingRequest = transformRequest(data);
        //TODO: Implement property requests.
      }
    } catch (error) {
      dispatch(
        setSnackbar({
          snackbarOpen: true,
          snackbarType: "error",
          snackbarMessage: ErrorSnackbarConstants.createRequestError,
        }),
      );
    }
  };

  return (
    <div>
      <form onSubmit={handleSubmit(onSubmit)}>
        <Paper className="paper-container">
          <Typography variant="h4" style={{ textAlign: "center" }}>
            Create a request:
          </Typography>
          <div style={{ display: "flex", margin: "auto" }}>
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
                  <MenuItem value={building.buildingId}>
                    {building.alias}
                  </MenuItem>
                ))}
              </TextField>
              {selectedRequestType == "Building Property Link" && (
                <>
                  {/* TODO: Add actual roles */}
                  <TextField
                    label="Role within building"
                    className="form-field"
                  />
                  <TextField
                    label="Property request is about"
                    className="form-field"
                  />
                </>
              )}
              {selectedRequestType == "Repair" && (
                <>
                  <div>
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
              <div>
                {errors.description && (
                  <span className="error-message">
                    {errors.description.message}
                  </span>
                )}
              </div>
            </div>
            <div>
              {errors.requestTitle && (
                <p className="error-message">{errors.requestType?.message}</p>
              )}
            </div>
          </div>
          <UploadedFilesList />
          <div className="anchored-container">
            <FileUploadButton />
            <Button type="submit" className="button" disabled={isSubmitting}>
              {fileTypeConstants.submit}
            </Button>
          </div>
        </Paper>
      </form>
      {isSubmitting && <Overlay />}
    </div>
  );
};
export default CreateRequestPage;
