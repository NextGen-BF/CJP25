import {
  Box,
  Button,
  IconButton,
  InputAdornment,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  TextField,
  Typography,
} from "@mui/material";
import SearchIcon from "@mui/icons-material/Search";
import { FC, useState } from "react";
import "./propertyFeesPage.scss";
import { PropertyExpense, PropertyPayments } from "../../models/property";
import Paper from "@mui/material/Paper";
import { DataGrid } from "@mui/x-data-grid";
import { NavLink } from "react-router-dom";

const PropertyFeesPage: FC = () => {
  const formatDate = (date: Date): string => {
    return date.toISOString().split("T")[0];
  };

  const propertyPaymentsMockData: PropertyPayments[] = [
    {
      paymentId: 1,
      amountOwed: 234.55,
      dateOpened: new Date("2024-12-20"),
      dueDate: new Date("2025-01-11"),
      status: "paid",
      paymentMethod: "master card",
    },
    {
      paymentId: 2,
      amountOwed: 120.9,
      dateOpened: new Date("2025-01-20"),
      dueDate: new Date("2025-03-11"),
      status: "not paid",
      paymentMethod: "master card",
    },
    {
      paymentId: 3,
      amountOwed: 70.9,
      dateOpened: new Date("2025-01-29"),
      dueDate: new Date("2025-03-01"),
      status: "not paid",
      paymentMethod: "visa card",
    },
  ];

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
  const propertyExpensesMockData: PropertyExpense[] = [
    {
      propertyExpenseId: 1,
      propertyExpenseTemplateId: 1,
      responsibleRole: "owner",
      price: 222.4,
      startDate: new Date("2024-12-20"),
      endDate: new Date("2025-01-11"),
      Description: "electricity bill",
    },
    {
      propertyExpenseId: 2,
      propertyExpenseTemplateId: 1,
      responsibleRole: "tenant",
      price: 52.55,
      startDate: new Date("2025-01-29"),
      endDate: new Date("2025-03-01"),
      Description: "water bill",
    },
    {
      propertyExpenseId: 3,
      propertyExpenseTemplateId: 1,
      responsibleRole: "tenant",
      price: 22.0,
      startDate: new Date("2025-01-02"),
      endDate: new Date("2025-03-12"),
      Description: "monthly rent",
    },
  ];

  const [propertyExpenses, setPropertyExpenses] = useState<PropertyExpense[]>(
    propertyExpensesMockData,
  );

  const [propertyPayments, setPropertyPayments] = useState<PropertyPayments[]>(
    propertyPaymentsMockData,
  );

  const [searchInput, setSearchInput] = useState<string>("");

  const handleSearch = () => {
    if (searchInput !== "") {
      const filteredPropertyExpenses = propertyExpenses.filter(
        (propertyExpense) => {
          if (
            propertyExpense.Description.toLowerCase().includes(
              searchInput.toLowerCase(),
            )
          ) {
            return propertyExpense;
          }
        },
      );
      setPropertyExpenses(filteredPropertyExpenses);
    } else {
      setPropertyExpenses(propertyExpensesMockData);
      return;
    }
  };

  return (
    <>
      <h1>Apartment Fees Page</h1>

      <DataGrid
        rows={propertyPayments}
        columns={columns}
        getRowId={(row) => row.paymentId}
      />

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
                  <IconButton>
                    <SearchIcon onClick={handleSearch} />
                  </IconButton>
                </InputAdornment>
              ),
            },
          }}
        />
      </Box>

      <TableContainer component={Paper}>
        <Table sx={{ width: "100%" }} size="small" aria-label="a dense table">
          <TableHead sx={{ "& .MuiTableCell-root": { fontWeight: "bold" } }}>
            <TableRow>
              <TableCell align="center">Description</TableCell>
              <TableCell align="center">Start Date</TableCell>
              <TableCell align="center">End Date</TableCell>
              <TableCell align="center">Price</TableCell>
              <TableCell align="center">Role</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {propertyExpenses.map((propertyExpense) => (
              <TableRow hover key={propertyExpense.propertyExpenseId}>
                <TableCell align="center">
                  {propertyExpense.Description}
                </TableCell>
                <TableCell align="center">
                  {formatDate(propertyExpense.startDate)}
                </TableCell>
                <TableCell align="center">
                  {formatDate(propertyExpense.endDate)}
                </TableCell>
                <TableCell align="center">{propertyExpense.price}</TableCell>
                <TableCell align="center">
                  {propertyExpense.responsibleRole}
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </>
  );
};
export default PropertyFeesPage;
