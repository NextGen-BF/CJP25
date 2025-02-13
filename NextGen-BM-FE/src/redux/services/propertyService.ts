import { createAsyncThunk } from "@reduxjs/toolkit";
import axios, { AxiosError } from "axios";
import { apiURL } from "../../api/shared";
import { Property } from "../../models/property";

export const getProperty = createAsyncThunk("property", async(propertyId:number, thunkAPI)=>{
    return await axios.get(`${apiURL}/property/${propertyId}`, {
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
                return thunkAPI.rejectWithValue(err.response);
            return thunkAPI.rejectWithValue(err);
        })
    }
);
export const deleteProperty = createAsyncThunk("property/delete", async(propertyId:number, thunkAPI)=>{
    return await axios.delete(`${apiURL}/property/delete/${propertyId}`, {
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
                return thunkAPI.rejectWithValue(err.response);
            return thunkAPI.rejectWithValue(err);
        })
    }
);
export const deletePropertyResident = createAsyncThunk("property/resident/delete", async(propertyId:number, thunkAPI)=>{
    return await axios.delete(`${apiURL}/property/resident/delete/${propertyId}`, {
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
                return thunkAPI.rejectWithValue(err.response);
            return thunkAPI.rejectWithValue(err);
        })
    }
);
export const updateProperty = createAsyncThunk("property/update", async(property:Property, thunkAPI)=>{
    return await axios.put(`${apiURL}/property/update`, property, {
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
                return thunkAPI.rejectWithValue(err.response);
            return thunkAPI.rejectWithValue(err);
        })
    }
);