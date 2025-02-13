import { createAsyncThunk } from "@reduxjs/toolkit";
import axios, { AxiosError } from "axios";
import { apiURL } from "../../api/shared";
import { Building } from "../../models/building";

export const createBuilding = createAsyncThunk("building/new", async (building: Building) => {
    return await axios.post(`${apiURL}/building/new`, building, {
        headers: {
            Authorization: `Bearer ${localStorage.getItem("JWT-BM")}`
        }
    })
        .then(function (response) {
            return response.data;
        }).catch((err: Error | AxiosError) => {
            if (axios.isAxiosError(err))
                return err.response;
            return err;
        })
})

export const getBuildingsByUserId = createAsyncThunk("building/user/id", async (userId: string, thunkAPI) => {
    return await axios.get(`${apiURL}/building/user/${userId}`, {
        headers: {
            Authorization: `Bearer ${localStorage.getItem("JWT-BM")}`
        }
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

interface UserBuildingDeleteData {
    userId: string,
    buildingId: number
}

export const deleteUserBuildingLink = createAsyncThunk("building/delete/user/id", async (data: UserBuildingDeleteData, thunkAPI) => {
    return await axios.post(`${apiURL}/building/delete/user/${data.userId}`, JSON.stringify(data.buildingId), {
        headers: {
            Authorization: `Bearer ${localStorage.getItem("JWT-BM")}`,
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
    return await axios.get(`${apiURL}/building/all`, {headers: {
        Authorization: `Bearer ${localStorage.getItem("JWT-BM")}`
    }})
    .then(function(response){
        return response.data;
    }).catch((err: Error | AxiosError) => {
        if(axios.isAxiosError(err))
            return Promise.reject(err.response);
        return Promise.reject(err);
    })
})