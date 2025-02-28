import { FC, useEffect, useState } from "react";
import { RootState, useAppDispatch } from "../../redux/store";
import { SubmitHandler, useForm } from "react-hook-form";
import {
  Property,
  PropertyExpense,
  PropertyPayments,
} from "../../models/property";
import {
  createPropertyPayment,
  getPropertyExpensesByBuildingId,
} from "../../redux/services/expenseService";
import { setSnackbar } from "../../redux/slices/snackbarSlice";
import {
  ErrorSnackbarConstants,
  SucessSnackbarConstants,
} from "../../constants/snackbarConstants";
import { createPropertyPaymentConstants } from "../../constants/constants";
import {
  Button,
  FormControl,
  InputLabel,
  MenuItem,
  Select,
  SelectChangeEvent,
  TextField,
} from "@mui/material";
import { requiredErrors, valueErrors } from "../../constants/ErrorConstants";
import { formatDate } from "../../utils/globalFunctions";
import { Building } from "../../models/building";
import { useSelector } from "react-redux";
import { getBuildingsByUserId } from "../../redux/services/buildingService";

const CreatePropertyPaymentsPage: FC = () => {
  const dispatch = useAppDispatch();

  const userId = useSelector(
    (state: RootState) => state.loginReducer.value.userId,
  );

  useEffect(() => {
    if (userId) dispatch(getBuildingsByUserId(userId));
  }, [dispatch, userId]);

  const buildings: Building[] = useSelector(
    (state: RootState) => state.buildingReducer.value,
  );
  const buildingList = buildings
    ? buildings.map((building) => (
        <MenuItem key={building.buildingId} value={building.buildingId}>
          {building.alias}
        </MenuItem>
      ))
    : [];

  const [selectedBuilding, setSelectedBuilding] = useState<number | "">("");
  const [buildingProperties, setBuildingProperties] = useState<Property[]>([]);
  const [selectedProperty, setSelectedProperty] = useState<number | "">("");
  const [propertyExpenses, setPropertyExpenses] = useState<PropertyExpense[]>(
    [],
  );
  const [selectedExpense, setSelectedExpense] = useState<number>(0);
  const [expensesLoaded, setExpensesLoaded] = useState<boolean>(false);

  useEffect(() => {
    if (selectedBuilding !== "") {
      setExpensesLoaded(false);
      dispatch(getPropertyExpensesByBuildingId(selectedBuilding))
        .then((response) => {
          setPropertyExpenses(response.payload);
          setExpensesLoaded(true);
        })
        .catch(() => {
          setPropertyExpenses([]);
        });
    }
  }, [selectedBuilding, dispatch]);

  const handleBuildingChange = (event: SelectChangeEvent<number>) => {
    const buildingId = Number(event.target.value);
    setSelectedBuilding(buildingId);

    const selectedBuildingWithProperties = buildings.find(
      (building) => building.buildingId === buildingId,
    );
    if (selectedBuildingWithProperties) {
      setBuildingProperties(
        selectedBuildingWithProperties.buildingProperties ?? [],
      );
    } else {
      setBuildingProperties([]);
    }
  };

  const handlePropertyChange = (event: SelectChangeEvent<number>) => {
    setSelectedProperty(Number(event.target.value));
  };

  const {
    register,
    handleSubmit,
    watch,
    formState: { errors, isSubmitting },
  } = useForm<PropertyPayments>();

  const dateOpened = watch("dateOpened");

  const onSubmit: SubmitHandler<PropertyPayments> = async (data) => {
    data.propertyId = buildingProperties.find(p => p.propertyId == selectedProperty)?.propertyId || 0;
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
          <FormControl fullWidth>
            <InputLabel id="building-select-label">Building</InputLabel>
            <Select
              labelId="building-select-label"
              value={selectedBuilding}
              onChange={handleBuildingChange}
            >
              {buildingList}
            </Select>
          </FormControl>

          {selectedBuilding !== "" && buildingProperties.length > 0 && (
            <FormControl fullWidth>
              <InputLabel id="property-select-label">Property</InputLabel>
              <Select
                labelId="property-select-label"
                value={selectedProperty}
                onChange={handlePropertyChange}
              >
                {buildingProperties.map((property) => (
                  <MenuItem
                    key={property.propertyId}
                    value={property.propertyId}
                  >
                    {property.propertyNumber}
                  </MenuItem>
                ))}
              </Select>
            </FormControl>
          )}

          {selectedBuilding !== "" && propertyExpenses.length > 0 && (
            <FormControl fullWidth>
              <InputLabel id="property-expense-select-label">Property Expense</InputLabel>
              <Select
                labelId="property-expense-select-label"
                value={selectedExpense}
                onChange={(e) => setSelectedExpense(e.target.value as number)}
              >
                {propertyExpenses.map((propertyExpense) => (
                  <MenuItem
                    key={propertyExpense.propertyExpenseId}
                    value={propertyExpense.propertyExpenseId}
                  >
                    {propertyExpense.description}
                  </MenuItem>
                ))}
              </Select>
            </FormControl>
          )}

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
          {selectedBuilding && expensesLoaded && propertyExpenses.length === 0 && (<div className="error-message">{valueErrors.noExpenses}</div>)}
          <Button fullWidth type="submit" disabled={propertyExpenses.length === 0 || isSubmitting}>
            {createPropertyPaymentConstants.create}
          </Button>
        </form>
      </div>
    </>
  );
};

export default CreatePropertyPaymentsPage;
