import { createAsyncThunk } from "@reduxjs/toolkit";
import axios, { AxiosError } from "axios";
import { apiURL } from "../../api/shared";
import { PropertyExpense } from "../../models/property";

export const createPropertyExpense = createAsyncThunk(
  "expense/new",
  async (data: PropertyExpense, thunkAPI) => {
    return await axios
      .post(`${apiURL}/expense/new`, data)
      .then(function (response) {
        return {
          data: response.data,
          status: response.status,
          statusText: response.statusText,
        };
      })
      .catch((err: Error | AxiosError) => {
        if (axios.isAxiosError(err))
          return thunkAPI.rejectWithValue(err.response?.data);
        return thunkAPI.rejectWithValue(err);
      });
  },
);
