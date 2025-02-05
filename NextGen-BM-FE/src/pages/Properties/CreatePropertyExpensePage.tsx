import { FC, useState } from "react";
import { Button, FormControl, InputLabel, MenuItem, Select, SelectChangeEvent, TextField } from "@mui/material";
import "./createPropertyExpense.scss";
import "../Buildings/Create/createBuilding.scss";
import { PropertyExpense } from "../../models/property";
import { useAppDispatch } from "../../redux/store";
import { createPropertyExpenseconstants } from "../../constants/constants";
import { createPropertyExpense } from "../../redux/services/expenseService";

const CreatePropertyExpense: FC = () => {
  const dispatch = useAppDispatch();

  const [formData, setFormData] = useState<PropertyExpense>({
    propertyExpenseId: 0,
    propertyExpenseTemplateId: 0,
    responsibleRole: "",
    price: 0.0,
    startDate: new Date(),
    endDate: new Date(),
    Description: "",
  });

  const handleRoleChange = (e: SelectChangeEvent<string>) => {
    const { value } = e.target;
    setFormData((previousData) => ({ ...previousData, responsibleRole: value }));
  };

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>,
  ) => {
    const { name, value } = e.target;
    setFormData((previousData) => ({ ...previousData, [name]: value }));
  };

  const handleCreatePropertyExpenseSubmission = (
    event: React.FormEvent<HTMLFormElement>,
  ) => {
    event.preventDefault();
    console.log(formData);
    dispatch(createPropertyExpense(formData));
  };

  return (
    <>
      <h1>Create Property Expense</h1>
      <div className="text-field-container">
        <form
          className="create-propertyExpense-form"
          onSubmit={(e) => handleCreatePropertyExpenseSubmission(e)}
        >
          <FormControl fullWidth required>
            <InputLabel id="role-label">Role</InputLabel>
            <Select
              labelId="role-label"
              id="role-select"
              value={formData.responsibleRole}
              onChange={(e) => handleRoleChange(e)}
              label="Category"
            >
              <MenuItem value="owner">Owner</MenuItem>
              <MenuItem value="tenant">Tenant</MenuItem>
            </Select>
          </FormControl>
          <TextField
            name="Description"
            label="Description"
            type="text"
            variant="outlined"
            size="medium"
            fullWidth
            onChange={(e) => handleChange(e)}
          />
          <TextField
            name="startDate"
            slotProps={{ inputLabel: { shrink: true } }}
            label="Start Date"
            type="date"
            variant="outlined"
            size="small"
            fullWidth
            onChange={(e) => handleChange(e)}
          />
          <TextField
            name="endDate"
            slotProps={{ inputLabel: { shrink: true } }}
            label="End Date"
            type="date"
            variant="outlined"
            size="small"
            fullWidth
            onChange={(e) => handleChange(e)}
          />
          <TextField
            name="price"
            label="Price"
            type="text"
            variant="outlined"
            size="small"
            fullWidth
            onChange={(e) => handleChange(e)}
          />
          <Button fullWidth type="submit">
            {createPropertyExpenseconstants.create}
          </Button>
        </form>
      </div>
    </>
  );
};

export default CreatePropertyExpense;
