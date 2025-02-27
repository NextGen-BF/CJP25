import { FC } from "react";
import {
  Button,
  FormControl,
  InputLabel,
  MenuItem,
  Select,
  TextField,
} from "@mui/material";
import "./createPropertyExpense.scss";
import "../Buildings/Create/createBuilding.scss";
import { PropertyExpense } from "../../models/property";
import { useAppDispatch } from "../../redux/store";
import { createPropertyExpenseConstants } from "../../constants/constants";
import { createPropertyExpense } from "../../redux/services/expenseService";
import { SubmitHandler, useForm } from "react-hook-form";
import "../../style/shared.scss";
import { requiredErrors, valueErrors } from "../../constants/ErrorConstants";
import { setSnackbar } from "../../redux/slices/snackbarSlice";
import {
  ErrorSnackbarConstants,
  SucessSnackbarConstants,
} from "../../constants/snackbarConstants";

const CreatePropertyExpense: FC = () => {
  const dispatch = useAppDispatch();
  const {
    register,
    handleSubmit,
    watch,
    formState: { errors, isSubmitting },
  } = useForm<PropertyExpense>();

  const startDate = watch("startDate");

  const onSubmit: SubmitHandler<PropertyExpense> = async (data) => {
    try {
      await dispatch(createPropertyExpense(data)).unwrap();
      dispatch(
        setSnackbar({
          snackbarOpen: true,
          snackbarType: "success",
          snackbarMessage: SucessSnackbarConstants.createPropertyExpenseSuccess,
        }),
      );
    } catch (error) {
      dispatch(
        setSnackbar({
          snackbarOpen: true,
          snackbarType: "error",
          snackbarMessage: ErrorSnackbarConstants.createPropertyExpenseError,
        }),
      );
    }
  };

  return (
    <>
      <h1>{createPropertyExpenseConstants.title}</h1>
      <div className="text-field-container">
        <form
          className="create-propertyExpense-form"
          onSubmit={handleSubmit(onSubmit)}
        >
          <FormControl fullWidth required>
            <InputLabel id="role-label">
              {createPropertyExpenseConstants.role}
            </InputLabel>
            <Select
              labelId="role-label"
              id="role-select"
              label="Category"
              {...register("responsibleRole", {
                required: requiredErrors.responsibleRole,
              })}
            >
              <MenuItem value="owner">
                {createPropertyExpenseConstants.role_owner}
              </MenuItem>
              <MenuItem value="tenant">
                {createPropertyExpenseConstants.role_tenant}
              </MenuItem>
            </Select>
            {errors.responsibleRole && (
              <div className="error-message">
                {errors.responsibleRole.message}
              </div>
            )}
          </FormControl>
          <TextField
            {...register("description", {
              required: requiredErrors.description,
            })}
            label="Description"
            type="text"
            variant="outlined"
            size="medium"
            fullWidth
          />
          {errors.description && (
            <div className="error-message">{errors.description.message}</div>
          )}
          <TextField
            {...register("startDate", {
              required: requiredErrors.startDate,
            })}
            slotProps={{ inputLabel: { shrink: true } }}
            label="Start Date"
            type="date"
            variant="outlined"
            size="small"
            fullWidth
          />
          {errors.startDate && (
            <div className="error-message">{errors.startDate.message}</div>
          )}
          <TextField
            {...register("endDate", {
              required: requiredErrors.endDate,
              validate: (value) => {
                if (
                  value.getMonth == new Date(Date.now()).getMonth &&
                  value.getFullYear() == new Date(Date.now()).getFullYear()
                ) {
                  return valueErrors.endDateCurrentMonth;
                }
                if (new Date(value) < new Date(startDate)) {
                  return valueErrors.endDateBeforeStartDate;
                }
              },
            })}
            slotProps={{ inputLabel: { shrink: true } }}
            label="End Date"
            type="date"
            variant="outlined"
            size="small"
            fullWidth
          />
          {errors.endDate && (
            <div className="error-message">{errors.endDate.message}</div>
          )}
          <TextField
            {...register("price", {
              required: requiredErrors.price,
              validate: (value) =>
                value <= 0 ? valueErrors.priceNegative : true,
            })}
            label="Price"
            type="text"
            variant="outlined"
            size="small"
            fullWidth
          />
          {errors.price && (
            <div className="error-message">{errors.price.message}</div>
          )}
          <Button fullWidth type="submit" disabled={isSubmitting}>
            {createPropertyExpenseConstants.create}
          </Button>
        </form>
      </div>
    </>
  );
};

export default CreatePropertyExpense;
