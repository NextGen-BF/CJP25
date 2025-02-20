import {
  Button,
} from "@mui/material";
import { FC, useEffect, useState } from "react";
import "./propertyFeesPage.scss";
import { PropertyPayments } from "../../models/property";
import { DataGrid } from "@mui/x-data-grid";
import { NavLink } from "react-router-dom";
import { RootState, useAppDispatch } from "../../redux/store";
import { getPropertyPaymentsByUserId } from "../../redux/services/expenseService";
import { useSelector } from "react-redux";

const PropertyFeesPage: FC = () => {
  const userId = useSelector((state: RootState) => state.loginReducer.value.userId)
  const dispatch = useAppDispatch();
  const formatDate = (date: Date): string => {
    return date.toISOString().split("T")[0];
  };

  const columns = [
    {
      field: "amountOwed",
      headerName: "Amount",
      flex: 1,
    },
    {
      field: "dateOpened",
      headerName: "Date Opened",
      flex: 1,
      valueFormatter: (value: Date) => {
        return value ? formatDate(value) : "";
      },
    },
    {
      field: "dueDate",
      headerName: "Due Date",
      flex: 1,
      valueFormatter: (value: Date) => {
        return value ? formatDate(value) : "";
      },
    },
    {
      field: "status",
      headerName: "Status",
      flex: 1,
    },
    {
      field: "paymentMethod",
      headerName: "Payment Method",
      flex: 1,
    },
  ];

  const [propertyPayments, setPropertyPayments] = useState<PropertyPayments[]>(
    [],
  );

  useEffect(() => {
    const fetchPropertyPayments = async () => {
      try {
        const result = await dispatch(
          getPropertyPaymentsByUserId(userId), 
        ).unwrap();

        setPropertyPayments(result);
      } catch (error) {
        console.error("Failed to fetch property payments:", error);
      }
    };

    fetchPropertyPayments();
  }, [dispatch]);


  return (
    <>
      <h1>Apartment Fees Page</h1>

      <div className="button-container">
        <Button
          component={NavLink}
          to="/create/propertypayments"
          variant="contained"
          sx={{ width: "10%", textDecoration: "none", color: "white" }}
        >
          Create
        </Button>
      </div>

      <DataGrid
        rows={propertyPayments}
        columns={columns}
        getRowId={(row) => row.paymentId}
      />
    </>
  );
};
export default PropertyFeesPage;
