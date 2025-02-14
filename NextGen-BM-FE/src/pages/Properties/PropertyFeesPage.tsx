import {
  Box,
  Button,
  IconButton,
  InputAdornment,
  TextField,
  Typography,
} from "@mui/material";
import SearchIcon from "@mui/icons-material/Search";
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
          getPropertyPaymentsByUserId(Number(userId)), // userId is type string but the function expects it to be int
        ).unwrap();

        setPropertyPayments(result);
      } catch (error) {
        console.error("Failed to fetch property payments:", error);
      }
    };

    fetchPropertyPayments();
  }, [dispatch]);

  const [searchInput, setSearchInput] = useState<string>("");

  const handleSearch = () => {
    if (searchInput !== "") {
      const filteredPropertyPayments = propertyPayments.filter(
        (propertyPayment) =>
          propertyPayment.paymentMethod
            .toLowerCase()
            .includes(searchInput.toLowerCase()),
      );
      setPropertyPayments(filteredPropertyPayments);
    } else {
      setPropertyPayments(propertyPayments);
      return;
    }
  };

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
      <Box
        sx={{
          display: "flex",
          alignItems: "center",
          backgroundColor: "#f0f0f0",
          padding: "1rem",
          marginBottom: "3rem",
          borderRadius: "1rem",
          width: "50%",
        }}
      >
        <Typography
          variant="body1"
          sx={{
            flexGrow: 1, // This takes up available space, pushing the search input to the right
            textAlign: "center", // Centers the "Filter" text within its space
            whiteSpace: "nowrap",
          }}
        >
          Filter
        </Typography>
        <TextField
          name="search"
          label="Search"
          type="text"
          variant="outlined"
          size="small"
          onChange={(e) => setSearchInput(e.target.value)}
          onKeyDown={(e) => {
            if (e.key === "Enter") handleSearch();
          }}
          slotProps={{
            input: {
              startAdornment: (
                <InputAdornment position="start">
                  <IconButton onClick={handleSearch}>
                    <SearchIcon />
                  </IconButton>
                </InputAdornment>
              ),
            },
          }}
        />
      </Box>

      <DataGrid
        rows={propertyPayments}
        columns={columns}
        getRowId={(row) => row.paymentId}
      />
    </>
  );
};
export default PropertyFeesPage;
