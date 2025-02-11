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

export const getAllBuildings = createAsyncThunk("building/user/id", async (userId: string) => {
    console.log(userId)
    return await axios.get(`${apiURL}/building/user/${userId}`, {
        headers: {
            Authorization: `Bearer ${localStorage.getItem("JWT-BM")}`
        }
    })
        .then(function (response) {
            return response.data;
        })
        .catch((err: Error | AxiosError) => {
            if (axios.isAxiosError(err))
                return err.response;
            return err;
        })
})