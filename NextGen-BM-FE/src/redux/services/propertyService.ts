import { createAsyncThunk } from "@reduxjs/toolkit";
import { Property } from "../../models/property";
import axios, { AxiosError } from "axios";
import { apiURL } from "../../api/shared";
import axiosInstance from "./interceptors/authorizationInterceptors";

export const createProperty = createAsyncThunk('/property/new', async(property:Property)=>{
    return await axiosInstance.post(`${apiURL}/property/new`, property)
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
export const getProperty = createAsyncThunk("property", async(propertyId:number, thunkAPI)=>{
    return await axiosInstance.get(`${apiURL}/property/${propertyId}`)
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
    return await axiosInstance.delete(`${apiURL}/property/delete/${propertyId}`)
        .then(
            function(response){
                return propertyId;
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
    return await axiosInstance.delete(`${apiURL}/property/resident/delete/${propertyId}`)
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
    return await axiosInstance.put(`${apiURL}/property/update`, property)
        .then(
            function(response){
                //returns request data because response doesn't return updated now
                return property;
            }
        )
        .catch((err: Error | AxiosError) => {
            if(axios.isAxiosError(err))
                return thunkAPI.rejectWithValue(err.response);
            return thunkAPI.rejectWithValue(err);
        })
    }
);
export const getProperties = createAsyncThunk("properties", async(_, thunkAPI)=>{
    return await axiosInstance.get(`${apiURL}/property/all`)
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

export const getPropertyTypes = createAsyncThunk("property/type/all", async (_, thunkAPI) => {
    return await axiosInstance.get(`${apiURL}/property/type/all`)
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