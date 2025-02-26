import { createAsyncThunk } from "@reduxjs/toolkit";
import axios, { AxiosError } from "axios";
import { apiURL } from "../../api/shared";
import { Building } from "../../models/building";
import axiosInstance from "./interceptors/authorizationInterceptors";

export const createBuilding = createAsyncThunk("building/new", async (building: Building, thunkAPI) => {
    return await axiosInstance.post(`${apiURL}/building/new`, building)
        .then(function (response) {
            return response.data;
        }).catch((err: Error | AxiosError) => {
            if (axios.isAxiosError(err)) {
                return thunkAPI.rejectWithValue(err.response?.data)
            }
            return thunkAPI.rejectWithValue(err);
        });
})

export const getBuildingsByUserId = createAsyncThunk("building/user/id", async (userId: number, thunkAPI) => {
    return await axiosInstance.get(`${apiURL}/building/user/${userId}`)
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

interface UserBuildingDeleteData {
    userId: number,
    buildingId: number
}

export const deleteUserBuildingLink = createAsyncThunk("building/delete/user/id", async (data: UserBuildingDeleteData, thunkAPI) => {
    return await axiosInstance.post(`${apiURL}/building/delete/user/${data.userId}`, JSON.stringify(data.buildingId), {
        headers: {
            "Content-Type": "application/json",
        }
    })
        .then(function () {
            return data.buildingId;
        })
        .catch((err: Error | AxiosError) => {
            if (axios.isAxiosError(err)) {
                return thunkAPI.rejectWithValue(err.response?.data)
            }
            return thunkAPI.rejectWithValue(err);
        });
}) 

export const getAllBuildings=createAsyncThunk("building/all", async()=> {
    return await axiosInstance.get(`${apiURL}/building/all`)
    .then(function(response){
        return response.data;
    }).catch((err: Error | AxiosError) => {
        if(axios.isAxiosError(err))
            return Promise.reject(err.response);
        return Promise.reject(err);
    })
})