import { createAsyncThunk } from "@reduxjs/toolkit";
import axios, { AxiosError } from "axios";
import { apiURL } from "../../api/shared";
import { PropertyExpense } from "../../models/property";
import { PropertyPayments } from "../../models/property";
import axiosInstance from "./interceptors/authorizationInterceptors";

export const getPropertyPaymentsByPropertyId = createAsyncThunk(
  "expense/getPropertyPaymentsByPropertyId",
  async (propertyId: number, thunkAPI) => {
    return await axiosInstance
      .get(`${apiURL}/expense/property/${propertyId}`)
      .then(function (response) {
        return response.data;
      })
      .catch((err: Error | AxiosError) => {
        if (axios.isAxiosError(err)) {
          return thunkAPI.rejectWithValue(err.response?.data);
        }
        return thunkAPI.rejectWithValue(err);
      });
  },
);

export const getPropertyPaymentsByBuildingId = createAsyncThunk(
  "expense/getPropertyPaymentsByBuildingId",
  async (buildingId: number, thunkAPI) => {
    return await axios
      .get(`${apiURL}/expense/building/${buildingId}`, {
        headers: {
          Authorization: `Bearer ${localStorage.getItem("JWT-BM")}`,
        },
      })
      .then(function (response) {
        return response.data;
      })
      .catch((err: Error | AxiosError) => {
        if (axios.isAxiosError(err)) {
          return thunkAPI.rejectWithValue(err.response?.data);
        }
        return thunkAPI.rejectWithValue(err);
      });
  },
);

export const getPropertyExpensesByBuildingId = createAsyncThunk(
  "expense/getPropertyExpensesByBuildingId",
  async (buildingId: number, thunkAPI) => {
    return await axios
      .get(`${apiURL}/expense/propertyexpense/${buildingId}`, {
        headers: {
          Authorization: `Bearer ${localStorage.getItem("JWT-BM")}`,
        },
      })
      .then(function (response) {
        return response.data;
      })
      .catch((err: Error | AxiosError) => {
        if (axios.isAxiosError(err)) {
          return thunkAPI.rejectWithValue(err.response?.data);
        }
        return thunkAPI.rejectWithValue(err);
      });
  },
);

export const getPropertyPaymentsByUserId = createAsyncThunk(
  "expense/getPropertyPaymentsByUserId",
  async (userId: number, thunkAPI) => {
    return await axios
      .get(`${apiURL}/expense/user/${userId}`, {
        headers: {
          Authorization: `Bearer ${localStorage.getItem("JWT-BM")}`,
        },
      })
      .then(function (response) {
        return response.data;
      })
      .catch((err: Error | AxiosError) => {
        if (axios.isAxiosError(err)) {
          return thunkAPI.rejectWithValue(err.response?.data);
        }
        return thunkAPI.rejectWithValue(err);
      });
  },
);

export const createPropertyExpense = createAsyncThunk(
  "expense/new",
  async (expense: PropertyExpense, thunkAPI) => {
    return await axios
      .post(`${apiURL}/expense/new`, expense, {
        headers: {
          Authorization: `Bearer ${localStorage.getItem("JWT-BM")}`,
        },
      })
      .then(function (response) {
        return response.data;
      })
      .catch((err: Error | AxiosError) => {
        if (axios.isAxiosError(err))
          return thunkAPI.rejectWithValue(err.response?.data);
        return thunkAPI.rejectWithValue(err);
      });
  },
);

export const createPropertyPayment = createAsyncThunk(
  `${apiURL}/expense/create/propertypayment`,
  async (payment: PropertyPayments, thunkAPI) => {
    return await axios
      .post(`${apiURL}/expense/create/propertypayment`, payment, {
        headers: {
          Authorization: `Bearer ${localStorage.getItem("JWT-BM")}`,
        },
      })
      .then(function (response) {
        return response.data;
      })
      .catch((err: Error | AxiosError) => {
        if (axios.isAxiosError(err))
          return thunkAPI.rejectWithValue(err.response?.data);
        return thunkAPI.rejectWithValue(err);
      });
  },
);
