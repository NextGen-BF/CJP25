import { FC } from "react";
import { Button, FormControl, InputLabel, MenuItem, Select, TextField } from "@mui/material";
import "./createPropertyExpense.scss";
import "../Buildings/Create/createBuilding.scss";
import { PropertyExpense } from "../../models/property";
import { useAppDispatch } from "../../redux/store";
import { createPropertyExpenseConstants } from "../../constants/constants";
import { createPropertyExpense } from "../../redux/services/expenseService";
import { SubmitHandler, useForm } from "react-hook-form";
import "../../style/shared.scss";

const CreatePropertyExpense: FC = () => {
  const dispatch = useAppDispatch();
  const { register, handleSubmit, formState: { errors, isSubmitting } } = useForm<PropertyExpense>();

  const onSubmit: SubmitHandler<PropertyExpense> = async (data) => {
    await dispatch(createPropertyExpense(data))
  }

  return (
    <>
      <h1>{createPropertyExpenseConstants.title}</h1>
      <div className="text-field-container">
        <form
          className="create-propertyExpense-form"
          onSubmit={handleSubmit(onSubmit)}
        >
          <FormControl fullWidth required>
            <InputLabel id="role-label">{createPropertyExpenseConstants.role}</InputLabel>
            <Select
              labelId="role-label"
              id="role-select"
              label="Category"
              {...register("responsibleRole", {
                required: "Responsible role is required!"
              })}
            >
              <MenuItem value="owner">{createPropertyExpenseConstants.role_owner}</MenuItem>
              <MenuItem value="tenant">{createPropertyExpenseConstants.role_tenant}</MenuItem>
            </Select>
            {errors.responsibleRole && (
              <div className="error-message">{errors.responsibleRole.message}</div>
            )}
          </FormControl>
          <TextField
            {...register("Description", {
              required: "Description is required"
            })}
            label="Description"
            type="text"
            variant="outlined"
            size="medium"
            fullWidth
          />
          {errors.Description && (
            <div className="error-message">{errors.Description.message}</div>
          )}
          <TextField
            {...register("startDate", {
              required: "Start date is required"
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
              required: "End Date is required",
              validate: (value) => {
                if (value.getMonth == new Date(Date.now()).getMonth && value.getFullYear() == new Date(Date.now()).getFullYear())
                  return "End date cannot be in the current month!"
              }
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
              required: "Price is required!",
              validate: (value) => {
                if (value.toString().includes("-"))
                  return "Price cannot be negative!"
              }
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
