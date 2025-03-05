import React from "react";
import { useDispatch, useSelector } from "react-redux";
import { RootState } from "../redux/store"; // Import RootState type
import { setSnackbar, SnackbarType } from "../redux/slices/snackbarSlice";
import Snackbar from "@mui/material/Snackbar";
import Alert from "@mui/material/Alert";

const CustomSnackbar: React.FC = () => {
  const dispatch = useDispatch();

  const snackbarOpen = useSelector(
    (state: RootState) => state.snackBarReducer.snackbarOpen,
  );
  const snackbarType = useSelector(
    (state: RootState) => state.snackBarReducer.snackbarType,
  ) as SnackbarType;
  const snackbarMessage = useSelector(
    (state: RootState) => state.snackBarReducer.snackbarMessage,
  );

  const handleClose = (
    _event?: React.SyntheticEvent | Event,
    reason?: string,
  ) => {
    if (reason === "clickaway") {
      return;
    }
    dispatch(
      setSnackbar({ snackbarOpen: false, snackbarType, snackbarMessage }),
    );
  };

  return (
    <div>
      <Snackbar
        open={snackbarOpen}
        anchorOrigin={{ vertical: "top", horizontal: "right" }}
        sx={{
          transform: "translateY(4vh)", 
        }}
        autoHideDuration={5000}
        onClose={handleClose}
      >
        <Alert
          elevation={6}
          variant="filled"
          onClose={handleClose}
          severity={snackbarType}
        >
          {snackbarMessage}
        </Alert>
      </Snackbar>
    </div>
  );
};

export default CustomSnackbar;
