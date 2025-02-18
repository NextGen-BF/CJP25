import { createAsyncThunk } from "@reduxjs/toolkit";
import axios, { AxiosError } from "axios";
import { apiURL } from "../../api/shared";
import { CodeResponse, TokenResponse } from "@react-oauth/google";
// import { OAuth2Client } from "google-auth-library";

// const oAuth2Client = new OAuth2Client(
//   import.meta.env.VITE_GOOGLE_CLIENT_ID,
//   import.meta.env.VITE_GOOGLE_CLIENT_SECRET,
//   "postmessage",
// );

export interface GoogleLoginCredentials {
  credential?: string;
  clientId?: string;
}

export const loginWithGoogleCall = createAsyncThunk(
  "loginWithGoogle",
  async (payload: GoogleLoginCredentials, thunkAPI) => {
    return await axios
      .post(`${apiURL}/Google/get-google-jwt`, payload.credential, {
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
    console.log(payload.code);
    console.log(import.meta.env.VITE_GOOGLE_CLIENT_ID);
    return await axios
      .post(
        `https://oauth2.googleapis.com/token`,
        {
          client_id: import.meta.env.VITE_GOOGLE_CLIENT_ID,
          client_secret: import.meta.env.VITE_GOOGLE_CLIENT_SECRET,
          redirect_uri: "http://localhost:5173/",
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
        console.log(response.data);
        return response.data;
      })
      .catch((err: Error | AxiosError) => {
        if (axios.isAxiosError(err)) {
          console.log(err.response?.data);
          return thunkAPI.rejectWithValue(err.response?.data);
        }
        return thunkAPI.rejectWithValue(err);
      });
  },
);
