import {
  Modal,
  TextField,
  Box,
  Typography,
  Button,
  MenuItem,
  Paper,
} from "@mui/material";
import { FC, useEffect, useState } from "react";
import { useSelector } from "react-redux";
import { RootState, useAppDispatch } from "../../redux/store";
import { setSelectedRow } from "../../redux/slices/modalSlice";
import { RequestRow, RequestStatus } from "../../models/requests";
import { useForm } from "react-hook-form";
import RequestNotes from "./RequestNotes";
import UploadedFilesList from "./UploadedFilesList";
import { postRequestNote } from "../../redux/services/requestService";

const style = {
  position: "absolute",
  top: "50%",
  left: "50%",
  transform: "translate(-50%, -50%)",
  width: "50%",
  height: "50%",
  bgcolor: "background.paper",
  border: "2px solid #000",
  boxShadow: 24,
  p: 4,
};

const textFieldStyle = {
  flex: "1 1 50%",
  minWidth: "25%",
};

const RequestModal: FC = () => {
  const user = useSelector((state: RootState) => state.loginReducer.value);
  const dispatch = useAppDispatch();
  const [disabledState, setDisabledState] = useState<boolean>(true);
  const [newNoteText, setNewNoteText] = useState<string>("");
  const statusEnum = Object.values<RequestStatus>(RequestStatus);
  const modalState = useSelector(
    (state: RootState) => state.modalStateReducer.value,
  );
  const {
    register,
    handleSubmit,
    reset,
    formState: { isSubmitting },
  } = useForm<RequestRow>();

  const handleModalClose = () => {
    dispatch(setSelectedRow({ selectedRow: null, isOpened: false }));
  };

  const setState = () => {
    
    setDisabledState(true);
  }

  useEffect(() => {
    if (modalState.selectedRow) {
      reset(modalState.selectedRow);
    }
  }, [modalState.selectedRow, reset]);

  return (
    <div>
      <Modal
        open={modalState.isOpened}
        onClose={() => handleModalClose()}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
      >
        <div>
          <Box
            sx={{
              ...style,
              display: "flex",
              flexWrap: "wrap",
              gap: 2,
              overflowY: "scroll",
            }}
          >
            <Box sx={{ ...textFieldStyle, textAlign: "center" }}>
              <Typography variant="h3">
                {modalState.selectedRow?.requestTitle}
              </Typography>
            </Box>
            <Box sx={textFieldStyle}>
              <TextField
                fullWidth
                multiline
                disabled
                label="Request Description"
                minRows={5}
                value={modalState.selectedRow?.requestDescription}
                // For some reason requestDescription is being sent instead of description?? And this works??
              />
            </Box>
            <Box sx={textFieldStyle}>
              <TextField
                fullWidth
                disabled
                label="Building"
                size="small"
                value={modalState.selectedRow?.buildingAlias}
              />
            </Box>
            <Box sx={textFieldStyle}>
              <TextField
                {...register("status")}
                fullWidth
                disabled={disabledState}
                label="Status"
                size="small"
                value={modalState.selectedRow?.status}
                select
              >
                {statusEnum.map((status) => (
                  <MenuItem value={status.toString()}>{status}</MenuItem>
                ))}
              </TextField>
            </Box>
            <Box sx={textFieldStyle}>
              <TextField
                fullWidth
                disabled
                label="User Name"
                size="small"
                value={modalState.selectedRow?.userFullName}
              />
            </Box>
            <Box sx={textFieldStyle}>
              <TextField
                fullWidth
                size="small"
                disabled
                label="Request Type"
                value={modalState.selectedRow?.requestType}
              />
            </Box>
            <Box sx={textFieldStyle}>
              <TextField
                fullWidth
                size="small"
                disabled
                label="Date Created"
                value={modalState.selectedRow?.dateCreated}
              />
            </Box>
            <div className="anchored-container">
              <Button fullWidth onClick={() => setDisabledState(false)}>
                Edit
              </Button>
              <Button
                disabled={isSubmitting}
                fullWidth
                onClick={() => setDisabledState(true)}
              >
                Save
              </Button>
            </div>
            <Box sx={textFieldStyle}>
              {Array.isArray(modalState.selectedRow?.notes) &&
                modalState.selectedRow.notes.length > 0 && <RequestNotes />}
              <Paper style={{ marginTop: 10 }}>
                <TextField
                  multiline
                  minRows={5}
                  fullWidth
                  label="Add new note"
                  placeholder="Note..."
                  value={newNoteText}
                  onChange={(e) => setNewNoteText(e.target.value)}
                ></TextField>
                <Button
                  fullWidth
                  onClick={() =>
                    dispatch(
                      postRequestNote({
                        noteId: 0,
                        createdBy: user.userId,
                        createDate: new Date().toISOString().split("T")[0],
                        requestId: modalState.selectedRow?.id ?? 0,
                        noteText: newNoteText,
                      }),
                    )
                  }
                >
                  Post
                </Button>
              </Paper>
            </Box>
            <Box sx={textFieldStyle}>
              <UploadedFilesList />
            </Box>
          </Box>
        </div>
      </Modal>
    </div>
  );
};

export default RequestModal;
