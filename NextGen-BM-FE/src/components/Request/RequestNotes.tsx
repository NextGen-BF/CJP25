import { Paper, Typography, Box, Divider } from "@mui/material";
import { FC } from "react";
import { useSelector } from "react-redux";
import { RootState, useAppDispatch } from "../../redux/store";

const RequestNotes: FC = () => {
  const dispatch = useAppDispatch();
  const modalState = useSelector(
    (state: RootState) => state.modalStateReducer.value,
  );

  return (
    <div>
      {modalState.selectedRow?.notes && (
        <Box>
          <Divider>
            <Typography variant="h5">Notes:</Typography>
          </Divider>
          {modalState.selectedRow?.notes.map((note) => (
            <Paper style={{ padding: "20px 20px", marginTop: 10 }}>
              <Box>
                <Typography
                  variant="h6"
                  style={{ margin: 0, textAlign: "left" }}
                >
                  {modalState.selectedRow?.userFullName}
                </Typography>
                <Typography variant="subtitle2" style={{ textAlign: "left" }}>
                  {note.noteText}
                </Typography>
              </Box>
              <Typography
                variant="caption"
                style={{ textAlign: "left", bottom: "5%", color: "gray" }}
              >
                {note.createDate.toString()}
              </Typography>
            </Paper>
          ))}
        </Box>
      )}
    </div>
  );
};

export default RequestNotes;
