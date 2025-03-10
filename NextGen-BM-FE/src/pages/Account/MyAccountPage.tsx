import { FC, useEffect } from "react";
import { RootState, useAppDispatch } from "../../redux/store";
import { useSelector } from "react-redux";
import { getUserById } from "../../redux/services/loginService";
import { Card, InputLabel, List, ListItem, MenuItem, Paper, Stack, StepLabel, TextField } from "@mui/material";
import { profileLabelsConstants } from "../../constants/profileConstants";
import { profilePageStyles } from "./MyAccountPageStyles";
import "../../style/shared.scss";

const MyAccountPage: FC = () => {
  const dispatch= useAppDispatch();
  const currentUserId=useSelector((state: RootState) => state.loginReducer.value.userId);
  
  const user=useSelector((state: RootState) => state.accountReducer.value);
  useEffect(() => {
    dispatch(getUserById(currentUserId));
  }, []);
  return (
    <Paper
      sx={profilePageStyles.profileCardStyles}>
      <h1 className="page-title">{profileLabelsConstants.title}</h1>
      <List
        sx={profilePageStyles.fieldsContainerStyles}>
        <ListItem
          sx={profilePageStyles.fieldStyles}>
          <InputLabel>{profileLabelsConstants.fullName}</InputLabel>
          <TextField 
            value={`${user.firstName} ${user.lastName}`}
            variant="standard"
            disabled/>
        </ListItem>
        <ListItem
          sx={profilePageStyles.fieldStyles}>
          <InputLabel>{profileLabelsConstants.email}</InputLabel>
          <TextField 
            value={user.email}
            variant="standard"
            disabled/>
        </ListItem>
        {/* should display a list of all available roles instead when implemented on the backend */}
        <ListItem
          sx={profilePageStyles.fieldStyles}>
          <InputLabel>{profileLabelsConstants.allRoles}</InputLabel>
          <TextField 
            value={user.role??"None"}
            variant="standard"
            disabled/>
        </ListItem>
        <ListItem
          sx={profilePageStyles.fieldStyles}>
          <InputLabel>{profileLabelsConstants.dateCreated}</InputLabel>
          <TextField 
            value={user.dateCreated??"None"}
            variant="standard"
            disabled/>
        </ListItem>
      </List>
    </Paper>
  );
};
export default MyAccountPage;
