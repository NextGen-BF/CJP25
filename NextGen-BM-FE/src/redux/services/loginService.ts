import { createAsyncThunk } from "@reduxjs/toolkit";
import axios, { AxiosError } from "axios";
import { apiURL } from "../../api/shared";

interface loginCredential {
    email: string,
    password: string,
}

export const loginCall = createAsyncThunk("auth/login", async (credentials: loginCredential, thunkAPI) => {
    return await axios.post(`${apiURL}/auth/login`, credentials
    ).then(function (response) {
        return response.data
    }).catch((err: Error | AxiosError) => {
        if (axios.isAxiosError(err)) {
            return thunkAPI.rejectWithValue(err.response?.data)
        }
        return thunkAPI.rejectWithValue(err);
    });
})