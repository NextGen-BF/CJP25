import { createAsyncThunk } from "@reduxjs/toolkit";
import { Property } from "../../models/property";
import axios, { AxiosError } from "axios";
import { apiURL } from "../../api/shared";

export const createProperty = createAsyncThunk('/property/new', async(property:Property)=>{
    return await axios.post(`${apiURL}/property/new`, property, {
        headers: 
            {Authorization: `Bearer ${localStorage.getItem('JWT-BM')}`}
        })
        .then(
            function(response){
                return response.data;
            }
        )
        .catch((err: Error | AxiosError) => {
            if(axios.isAxiosError(err))
                return Promise.reject(err.response);
            return Promise.reject(err);
        })
    }
);

export const getPropertyTypes = createAsyncThunk("property/type/all", async (_, thunkAPI) => {
    return await axios.get(`${apiURL}/property/type/all`, {
        headers: 
            {Authorization: `Bearer ${localStorage.getItem('JWT-BM')}`}
        })
        .then(function (response) {
            return response.data;
        })
        .catch((err: Error | AxiosError) => {
            if (axios.isAxiosError(err)) {
                return thunkAPI.rejectWithValue(err.response?.data)
            }
            return thunkAPI.rejectWithValue(err);
        });
})