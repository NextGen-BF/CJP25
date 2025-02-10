import { createAsyncThunk } from "@reduxjs/toolkit";
import axios, { AxiosError } from "axios";
import { apiURL } from "../../api/shared";
import { PropertyExpense } from "../../models/property";

export const createPropertyExpense=createAsyncThunk("expense/new", async(expense: PropertyExpense)=> {
  return await axios.post(`${apiURL}/expense/new`, expense, {headers: {
      Authorization: `Bearer ${localStorage.getItem("JWT-BM")}`
  }})
  .then(function(response){
      return response.data;
  }).catch((err: Error | AxiosError) => {
      if(axios.isAxiosError(err))
          return err.response
      return err;
  })
})
