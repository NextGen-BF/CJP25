import { createAsyncThunk } from "@reduxjs/toolkit";
import axios, { AxiosError } from "axios";
import { apiURL } from "../../api/shared";

export const uploadFile = createAsyncThunk(
  "documents/upload",
  async (
    data: { files: FormData; requestId: number; requestType: string },
    thunkAPI,
  ) => {
    data.files.append("requestType", data.requestType);
    return await axios
      .post(`${apiURL}/request/document/upload/${data.requestId}`, data.files, {
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
