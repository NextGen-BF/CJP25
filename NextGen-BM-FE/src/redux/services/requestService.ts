import { createAsyncThunk } from "@reduxjs/toolkit";
import axios, { AxiosError } from "axios";
import { apiURL } from "../../api/shared";
import {
  RepairRequest,
  RequestNotes,
  RequestStatus,
  UserBuildingRequests,
} from "../../models/requests";
import axiosInstance from "./interceptors/authorizationInterceptors";

export const createRepairRequest = createAsyncThunk(
  "request/repair/new",
  async (request: RepairRequest, thunkAPI) => {
    return await axiosInstance
      .post(`${apiURL}/request/repair/new`, request)
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
      .post(`${apiURL}/request/user/building/new`, request)
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
      .post(`${apiURL}/request/note/new`, note)
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
      .get(`${apiURL}/request/user/${userId}`)
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

export const getRequestStatuses = createAsyncThunk<RequestStatus[]>(
  "request/status/get",
  async (_, thunkAPI) => {
    return await axiosInstance
      .get<RequestStatus[]>(`${apiURL}/request/status`)
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

interface setStatusInput {
  requestId: number;
  statusId: number;
  requestType: string;
}

export const setRequestStatus = createAsyncThunk(
  "request/status/set",
  async (statusInput: setStatusInput, thunkAPI) => {
    return await axiosInstance
      .post(
        `${apiURL}/request/status/set/${statusInput.requestId}/${statusInput.statusId}`,
        JSON.stringify(statusInput.requestType),
        {
          headers: {
            "Content-Type": "application/json",
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
