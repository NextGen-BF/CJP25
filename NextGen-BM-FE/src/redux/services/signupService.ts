import { createAsyncThunk } from "@reduxjs/toolkit";
import axios, { AxiosError } from "axios";
import { apiURL } from "../../api/shared";

interface UserSignupData {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  phoneNumber: string;
}

export const signupCall = createAsyncThunk(
  "account/register",
  async (data: UserSignupData, thunkAPI) => {
    return axios
      .post(`${apiURL}/account/register`, data)
      .then(function (response) {
        return {
          data: response.data,
          status: response.status,
          statusText: response.statusText,
        };
      })
      .catch((err: Error | AxiosError) => {
        if (axios.isAxiosError(err)) {
          return thunkAPI.rejectWithValue(err.response?.data)
        }
        return thunkAPI.rejectWithValue(err);
      });
  },
);
