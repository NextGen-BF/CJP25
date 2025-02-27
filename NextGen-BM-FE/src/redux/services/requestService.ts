import { createAsyncThunk } from "@reduxjs/toolkit";
import axios, { AxiosError } from "axios";
import { apiURL } from "../../api/shared";
import {
  RepairRequest,
  RequestNotes,
  UserBuildingRequests,
} from "../../models/requests";
import axiosInstance from "./interceptors/authorizationInterceptors";

export const createRepairRequest = createAsyncThunk(
  "request/repair/new",
  async (request: RepairRequest, thunkAPI) => {
    return await axiosInstance
      .post(`${apiURL}/request/repair/new`, request, {
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

export const createUserBuildingRequest = createAsyncThunk(
  "request/building/new",
  async (request: UserBuildingRequests, thunkAPI) => {
    return await axiosInstance
      .post(`${apiURL}/request/user/building/new`, request, {
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

export const postRequestNote = createAsyncThunk(
  "request/note/new",
  async (note: RequestNotes, thunkAPI) => {
    return await axiosInstance
      .post(`${apiURL}/request/note/new`, note, {
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

export const getAllRequestsForUser = createAsyncThunk(
  "requests/userId",
  async (userId: number, thunkAPI) => {
    return await axiosInstance
      .get(`${apiURL}/request/user/${userId}`, {
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
