import { Paper, Typography, Box, Divider } from "@mui/material";
import { FC, useEffect, useState } from "react";
import { useSelector } from "react-redux";
import { RootState, useAppDispatch } from "../../redux/store";
import { getUserById } from "../../redux/services/loginService";

interface userNames {
  noteId: number;
  userName: string;
}

const RequestNotes: FC = () => {
  const dispatch = useAppDispatch();
  const modalState = useSelector(
    (state: RootState) => state.modalStateReducer.value,
  );
  const [userNames, setUserNames] = useState<Record<number, string>>({});

  const getUserName = async (userId: number, noteId: number) => {
    const user = await dispatch(getUserById(userId));
    if (getUserById.fulfilled.match(user)) {
      const userNames = user.payload.firstName + " " + user.payload.lastName;
      setUserNames((prevRecords) => ({
        ...prevRecords,
        [noteId]: userNames,
      }));
    }
  };

  useEffect(() => {
    modalState.selectedRow?.notes.forEach((note) => {
      if (note.createdBy && !userNames[note.noteId]) {
        getUserName(note.createdBy, note.noteId);
      }
    });
  }, [modalState.selectedRow?.notes]);

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
                  {userNames[note.noteId]}
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
