import { createAsyncThunk } from "@reduxjs/toolkit";
import axios, { AxiosError } from "axios";
import { apiURL } from "../../api/shared";
import { CodeResponse } from "@react-oauth/google";

export const loginWithGoogleCall = createAsyncThunk(
  "loginWithGoogle",
  async (payload: string, thunkAPI) => {
    return await axios
      .post(`${apiURL}/Google/get-google-jwt`, payload, {
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json;charset=utf-8",
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

export const getJWTTokenFromTokenResponse = createAsyncThunk(
  "getGoogleJWTFromCodeResponse",
  async (payload: CodeResponse, thunkAPI) => {
    return await axios
      .post(
        `${import.meta.env.VITE_GOOGLE_API_URL}/token`,
        {
          client_id: import.meta.env.VITE_GOOGLE_CLIENT_ID,
          client_secret: import.meta.env.VITE_GOOGLE_CLIENT_SECRET,
          redirect_uri: "postmessage",
          grant_type: "authorization_code",
          code: payload.code,
        },
        {
          headers: {
            "Content-Type": "application/x-www-form-urlencoded",
          },
        },
      )
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
