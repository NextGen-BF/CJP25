import { createAsyncThunk } from "@reduxjs/toolkit";
import axios, { AxiosError } from "axios";
import { apiURL } from "../../api/shared";

interface signupData {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  phoneNumber: string;
}

export const signupCall = createAsyncThunk(
  "account/register",
  async (data: signupData) => {
    return axios
      .post(`${apiURL}/account/register`, data)
      .then(function (response) {
        return response;
      })
      .catch((err: Error | AxiosError) => {
        if (axios.isAxiosError(err)) {
          return err.response;
        }
        console.log("axios")
        return err;
      });
  },
);
