import { createAsyncThunk } from "@reduxjs/toolkit";
import axios, { AxiosError } from "axios";
import { apiURL } from "../../api/shared";

export const getPropertyPaymentsByPropertyId = createAsyncThunk(
  "expense/getPropertyPaymentsByPropertyId",
  async (propertyId) => {
    return await axios
      .get(`${apiURL}/expense/property/${propertyId}`, {
        headers: {
          Authorization: `Bearer ${localStorage.getItem("JWT-BM")}`,
        },
      })
      .then(function (response) {
        return response.data;
      })
      .catch((err: Error | AxiosError) => {
        if (axios.isAxiosError(err)) return err.response;
        return err;
      });
  },
);

export const getPropertyPaymentsByBuildingId = createAsyncThunk(
    "expense/getPropertyPaymentsByBuildingId",
    async (buildingId) => {
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
          if (axios.isAxiosError(err)) return err.response;
          return err;
        });
    },
  );

  export const getPropertyPaymentsByUserId = createAsyncThunk(
    "expense/getPropertyPaymentsByUserId",
    async (userId) => {
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
          if (axios.isAxiosError(err)) return err.response;
          return err;
        });
    },
  );