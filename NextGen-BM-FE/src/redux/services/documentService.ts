import aws from "aws-sdk";
import { createAsyncThunk } from "@reduxjs/toolkit";

const bucketName = import.meta.env.VITE_BUCKET_NAME;

const bucket = new aws.S3({
  region: import.meta.env.VITE_BUCKET_REGION,
  accessKeyId: import.meta.env.VITE_BUCKET_ACCESS_KEY,
  secretAccessKey: import.meta.env.VITE_BUCKET_SECRET_KEY,
});

export const uploadFile = createAsyncThunk

