import { Button, TextField } from "@mui/material";
import { FC } from "react";
import { Building } from "../../../models/building";
import { RootState, useAppDispatch } from "../../../redux/store";
import { createBuildingConstants } from "../../../constants/constants";
import "./createBuilding.scss";
import "../../../style/shared.scss"
import EditableTable from "../../../components/EditableTable";
import { useSelector } from "react-redux";
import { SubmitHandler, useForm } from "react-hook-form"
import { createBuilding } from "../../../redux/services/buildingService";

const CreateBuildingPage: FC = () => {
  const dispatch = useAppDispatch();
  const buildingProperties = useSelector((state: RootState) => state.propertyReducer.value)

  const { register, handleSubmit, formState: { errors, isSubmitting } } = useForm<Building>({
    defaultValues: {
      dateBuilt: new Date(Date.now())
    }
  });

  const onSubmit: SubmitHandler<Building> = async (data) => {
    data.buildingProperties = buildingProperties;
    await dispatch(createBuilding(data));

  }

  return (
    <div>
      <div className="text-field-container">
        <form
          className="create-building-form"
          onSubmit={handleSubmit(onSubmit)}
        >
          <h1 className="create-building-header">
            {createBuildingConstants.createHeader}
          </h1>
          <TextField
            {...register("alias", {
              required: "Alias is required",
              minLength: {
                value: 3,
                message: "Alias must be at least 3 characters long"
              }
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
              required: "Number of building floors is required",
              validate: (value) => {
                if (value.toString().includes("-")) {
                  return "Number of floors cannot be negative!"
                }
                if (value == 0) {
                  return "Building cannot have 0 floors!"
                }
              }
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
              required: "Total Building Size is required",
              validate: (value) => {
                if (value.toString().includes("-")) {
                  return "Building size cannot be negative!"
                }
              }
            })}
            label="Building Size"
            type="text"
            variant="outlined"
            size="small"
            fullWidth
          />
          {errors.totalBuildingSize && (
            <div className="error-message">{errors.totalBuildingSize.message}</div>
          )}
          <TextField
            {...register("dateBuilt", {
              required: "Date built is required",
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
              required: "Number of Elevators is required!",
              validate: (value) => {
                if (value.toString().includes("-")) {
                  return "Number of elevators cannot be negative!"
                }
              }
            })}
            label="Amount of Elevators"
            type="number"
            variant="outlined"
            size="small"
            fullWidth
          />
          {errors.numOfElevators && (
            <div className="error-message">{errors.numOfElevators.message}</div>
          )}
          <TextField
            {...register("buildingAddress.streetName", {
              required: "Street Name is required!",
            })}
            label="Street Name"
            type="text"
            variant="outlined"
            size="small"
            fullWidth
          />
          {errors.buildingAddress?.streetName && (
            <div className="error-message">{errors.buildingAddress.streetName.message}</div>
          )}
          <TextField
            {...register("buildingAddress.streetNumber", {
              required: "Street Number is required!",
              validate: (value) => {
                if (value.toString().includes("-")) {
                  return "Street number cannot be negative!"
                }
              }
            })}
            label="Street Number"
            type="text"
            variant="outlined"
            size="small"
            fullWidth
          />
          {errors.buildingAddress?.streetNumber && (
            <div className="error-message">{errors.buildingAddress.streetNumber.message}</div>
          )}
          <TextField
            {...register("buildingAddress.district", {
              required: "District is required!",
            })}
            label="District"
            type="text"
            variant="outlined"
            size="small"
            fullWidth
          />
          {errors.buildingAddress?.district && (
            <div className="error-message">{errors.buildingAddress.district.message}</div>
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
              required: "City is required!"
            })}
            label="City"
            type="text"
            variant="outlined"
            size="small"
            fullWidth
          />
          {errors.buildingAddress?.city && (
            <div className="error-message">{errors.buildingAddress?.city.message}</div>
          )}
          <TextField
            {...register("buildingAddress.postalCode", {
              required: "Postal Code is required!",
            })}
            label="Postal Code"
            type="text"
            variant="outlined"
            size="small"
            fullWidth
          />
          {errors.buildingAddress?.postalCode && (
            <div className="error-message">{errors.buildingAddress.postalCode.message}</div>
          )}
          <TextField
            {...register("buildingAddress.country", {
              required: "Country is required!",
            })}
            label="Country"
            type="text"
            variant="outlined"
            size="small"
            fullWidth
          />
          {errors.buildingAddress?.country && (
            <div className="error-message">{errors.buildingAddress.country.message}</div>
          )}
          <Button fullWidth type="submit" disabled={isSubmitting}>
            {createBuildingConstants.create}
          </Button>
        </form>
      </div>
      <div className="property-table">
        <EditableTable />
      </div>
    </div>
  );
};
export default CreateBuildingPage;
