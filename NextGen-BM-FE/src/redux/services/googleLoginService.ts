import { createAsyncThunk } from "@reduxjs/toolkit";
import axios, { AxiosError } from "axios";
import { apiURL } from "../../api/shared";

export interface GoogleLoginCredentials {
  credential?: string;
  clientId?: string;
}

export const loginWithGoogleCall = createAsyncThunk(
  "loginWithGoogle",
  async (payload: GoogleLoginCredentials, thunkAPI) => {
    return await axios
      .post(`${apiURL}/Google/get-google-jwt`, payload)
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
