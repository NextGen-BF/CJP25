import { Button, Paper, TextField, Typography } from "@mui/material";
import { FC, useEffect } from "react";
import { Building } from "../../../models/building";
import { RootState, useAppDispatch } from "../../../redux/store";
import { createBuildingConstants } from "../../../constants/constants";
import "./createBuilding.scss";
import "../../../style/shared.scss";
import EditableTable from "../../../components/EditableTable";
import { useSelector } from "react-redux";
import { SubmitHandler, useForm } from "react-hook-form";
import { createBuilding } from "../../../redux/services/buildingService";
import { requiredErrors, valueErrors } from "../../../constants/ErrorConstants";
import { setSnackbar } from "../../../redux/slices/snackbarSlice";
import {
  ErrorSnackbarConstants,
  SucessSnackbarConstants,
} from "../../../constants/snackbarConstants.ts";
import { useNavigate } from "react-router-dom";
import { resetProperties } from "../../../redux/slices/propertySlice";

const CreateBuildingPage: FC = () => {
  const user = useSelector((state: RootState) => state.loginReducer.value);
  const dispatch = useAppDispatch();
  const navigate = useNavigate();

  useEffect(() => {
    dispatch(resetProperties());
  }, []);
  const buildingProperties = useSelector(
    (state: RootState) => state.propertyReducer.value,
  );

  const {
    register,
    handleSubmit,
    reset,
    formState: { errors, isSubmitting, isSubmitSuccessful },
  } = useForm<Building>({
    defaultValues: {
      dateBuilt: new Date(Date.now()),
    },
  });

  useEffect(() => {
    if (!user.isLoggedIn) navigate("/login");

    if (isSubmitSuccessful) reset();
  }, [user, isSubmitSuccessful]);

  const onSubmit: SubmitHandler<Building> = async (data) => {
    data.buildingProperties = buildingProperties;
    data.userBuildings = [
      {
        userBuildingsId: 0,
        userId: user.userId,
        roleId: null,
        buildingId: 0,
        startDate: data.dateBuilt,
        endDate: null,
        approved: true,
        requestTitle: "",
      },
    ];
    try {
      await dispatch(createBuilding(data)).unwrap();
      dispatch(
        setSnackbar({
          snackbarOpen: true,
          snackbarType: "success",
          snackbarMessage: SucessSnackbarConstants.createBuildingSuccess,
        }),
      );
      setTimeout(() => {
        navigate("/buildings");
      }, 3000);
    } catch (error) {
      dispatch(
        setSnackbar({
          snackbarOpen: true,
          snackbarType: "error",
          snackbarMessage: ErrorSnackbarConstants.createBuildingError,
        }),
      );
    }
  };

  return (
    <div>
      <Paper className="paper-container" style={{ width: "50%" }}>
        <div className="container">
          <form
            className="create-building-form"
            onSubmit={handleSubmit(onSubmit)}
          >
            <Typography variant="h4" style={{ textAlign: "center" }}>
              {createBuildingConstants.createHeader}
            </Typography>
            <TextField
              {...register("alias", {
                required: requiredErrors.alias,
                minLength: {
                  value: 3,
                  message: valueErrors.aliasMinCharacter,
                },
              })}
              label="Building Alias"
              type="text"
              variant="outlined"
              size="small"
              fullWidth
            />
            {errors.alias && (
              <div className="error-message">{errors.alias.message}</div>
            )}
            <TextField
              {...register("floorNum", {
                required: requiredErrors.floorNum,
                validate: (value) =>
                  value <= 0 ? valueErrors.floorNumNegative : true,
              })}
              label="Number of Building Floors"
              type="number"
              variant="outlined"
              size="small"
              fullWidth
            />
            {errors.floorNum && (
              <div className="error-message">{errors.floorNum.message}</div>
            )}
            <TextField
              {...register("totalBuildingSize", {
                required: requiredErrors.totalBuildingSize,
                validate: (value) =>
                  value <= 0 ? valueErrors.buildingSizeNegative : true,
              })}
              label="Building Size"
              type="text"
              variant="outlined"
              size="small"
              fullWidth
            />
            {errors.totalBuildingSize && (
              <div className="error-message">
                {errors.totalBuildingSize.message}
              </div>
            )}
            <TextField
              {...register("dateBuilt", {
                required: requiredErrors.dateBuilt,
              })}
              slotProps={{ inputLabel: { shrink: true } }}
              label="Date Built"
              type="date"
              variant="outlined"
              size="small"
              fullWidth
            />
            {errors.dateBuilt && (
              <div className="error-message">{errors.dateBuilt.message}</div>
            )}
            <TextField
              {...register("numOfElevators", {
                required: requiredErrors.numOfElevators,
                validate: (value) =>
                  value < 0 ? valueErrors.numOfElevatorsNegative : true,
              })}
              label="Amount of Elevators"
              type="number"
              variant="outlined"
              size="small"
              fullWidth
            />
            {errors.numOfElevators && (
              <div className="error-message">
                {errors.numOfElevators.message}
              </div>
            )}
            <TextField
              {...register("buildingAddress.streetName", {
                required: requiredErrors.streetName,
              })}
              label="Street Name"
              type="text"
              variant="outlined"
              size="small"
              fullWidth
            />
            {errors.buildingAddress?.streetName && (
              <div className="error-message">
                {errors.buildingAddress.streetName.message}
              </div>
            )}
            <TextField
              {...register("buildingAddress.streetNumber", {
                required: requiredErrors.streetNumber,
                validate: (value) =>
                  value <= 0 ? valueErrors.streetNumberNegative : true,
              })}
              label="Street Number"
              type="text"
              variant="outlined"
              size="small"
              fullWidth
            />
            {errors.buildingAddress?.streetNumber && (
              <div className="error-message">
                {errors.buildingAddress.streetNumber.message}
              </div>
            )}
            <TextField
              {...register("buildingAddress.district", {
                required: requiredErrors.district,
              })}
              label="District"
              type="text"
              variant="outlined"
              size="small"
              fullWidth
            />
            {errors.buildingAddress?.district && (
              <div className="error-message">
                {errors.buildingAddress.district.message}
              </div>
            )}
            <TextField
              {...register("buildingAddress.entrance")}
              label="Entrance"
              type="text"
              variant="outlined"
              size="small"
              fullWidth
            />
            <TextField
              {...register("buildingAddress.city", {
                required: requiredErrors.city,
              })}
              label="City"
              type="text"
              variant="outlined"
              size="small"
              fullWidth
            />
            {errors.buildingAddress?.city && (
              <div className="error-message">
                {errors.buildingAddress?.city.message}
              </div>
            )}
            <TextField
              {...register("buildingAddress.postalCode", {
                required: requiredErrors.postalCode,
              })}
              label="Postal Code"
              type="text"
              variant="outlined"
              size="small"
              fullWidth
            />
            {errors.buildingAddress?.postalCode && (
              <div className="error-message">
                {errors.buildingAddress.postalCode.message}
              </div>
            )}
            <TextField
              {...register("buildingAddress.country", {
                required: requiredErrors.country,
              })}
              label="Country"
              type="text"
              variant="outlined"
              size="small"
              fullWidth
            />
            {errors.buildingAddress?.country && (
              <div className="error-message">
                {errors.buildingAddress.country.message}
              </div>
            )}
            <div style={{ width: "100%" }}>
              <EditableTable />
            </div>
            <Button fullWidth type="submit" disabled={isSubmitting}>
              {createBuildingConstants.create}
            </Button>
          </form>
        </div>
      </Paper>
    </div>
  );
};
export default CreateBuildingPage;
