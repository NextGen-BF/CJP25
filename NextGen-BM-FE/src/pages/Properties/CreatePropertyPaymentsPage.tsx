import { FC } from "react";
import { useAppDispatch } from "../../redux/store";
import { SubmitHandler, useForm } from "react-hook-form";
import { PropertyPayments } from "../../models/property";
import { createPropertyPayment } from "../../redux/services/expenseService";
import { setSnackbar } from "../../redux/slices/snackbarSlice";
import {
  ErrorSnackbarConstants,
  SucessSnackbarConstants,
} from "../../constants/snackbarConstants";
import { createPropertyPaymentConstants } from "../../constants/constants";
import { Button, TextField } from "@mui/material";
import { requiredErrors, valueErrors } from "../../constants/ErrorConstants";
import { formatDate } from "../../utils/globalFunctions";

const CreatePropertyPaymentsPage: FC = () => {
  const dispatch = useAppDispatch();

  const {
    register,
    handleSubmit,
    watch,
    formState: { errors, isSubmitting },
  } = useForm<PropertyPayments>();

  const dateOpened = watch("dateOpened");

  const onSubmit: SubmitHandler<PropertyPayments> = async (data) => {
    try {
      await dispatch(createPropertyPayment(data)).unwrap();
      dispatch(
        setSnackbar({
          snackbarOpen: true,
          snackbarType: "success",
          snackbarMessage:
            SucessSnackbarConstants.createPropertyPaymentsSuccess,
        }),
      );
    } catch (error) {
      dispatch(
        setSnackbar({
          snackbarOpen: true,
          snackbarType: "error",
          snackbarMessage: ErrorSnackbarConstants.createPropertyPaymentsError,
        }),
      );
    }
  };

  return (
    <>
      <h1>{createPropertyPaymentConstants.title}</h1>
      <div className="text-field-container">
        <form
          className="create-propertyExpense-form"
          onSubmit={handleSubmit(onSubmit)}
        >
          <TextField
            {...register("amountOwed", {
              required: requiredErrors.amountOwed,
              validate: (value) =>
                value <= 0 ? valueErrors.amountOwedNegative : true,
            })}
            label="Amount"
            type="text"
            variant="outlined"
            size="small"
            fullWidth
            slotProps={{
              input: {
                endAdornment: <span>лв.</span>, 
              },
            }}
          />
          {errors.amountOwed && (
            <div className="error-message">{errors.amountOwed.message}</div>
          )}

          <TextField
            {...register("dateOpened", {
              required: requiredErrors.dateOpened,
            })}
            slotProps={{ inputLabel: { shrink: true } }}
            label="Date Opened"
            defaultValue={formatDate(new Date())}
            type="date"
            variant="outlined"
            size="small"
            fullWidth
          />
          {errors.dateOpened && (
            <div className="error-message">{errors.dateOpened.message}</div>
          )}

          <TextField
            {...register("dueDate", {
              required: requiredErrors.dueDate,
              validate: (value) => {
                if (new Date(value) < new Date(dateOpened)) {
                  return valueErrors.dueDateBeforeDateOpened;
                }
              },
            })}
            slotProps={{ inputLabel: { shrink: true } }}
            label="Due Date"
            type="date"
            variant="outlined"
            size="small"
            fullWidth
          />
          {errors.dueDate && (
            <div className="error-message">{errors.dueDate.message}</div>
          )}
          <Button fullWidth type="submit" disabled={isSubmitting}>
            {createPropertyPaymentConstants.create}
          </Button>
        </form>
      </div>
    </>
  );
};

export default CreatePropertyPaymentsPage;
