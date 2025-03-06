import { FC, useEffect } from "react";
import { RootState, useAppDispatch } from "../../redux/store";
import { useSelector } from "react-redux";
import { getUserById } from "../../redux/services/loginService";
import { Card, ListItem, MenuItem, Paper, Stack } from "@mui/material";
import { profileLabelsConstants } from "../../constants/profileConstants";
import { profilePageStyles } from "./MyAccountPageStyles";

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
      <h1>{profileLabelsConstants.title}</h1>
      <Stack>
        <MenuItem>
          {`${profileLabelsConstants.fullName} ${user.firstName} ${user.lastName}`}
        </MenuItem>
        <MenuItem>
          {`${profileLabelsConstants.email} ${user.email}`}
        </MenuItem>
        <MenuItem>
          {`${profileLabelsConstants.allRoles} ${user.role??"None"}`}
        </MenuItem>
        <MenuItem>
          {`${profileLabelsConstants.dateCreated} ${user.properties??"None"}`}
        </MenuItem>
      </Stack>
    </Paper>
  );
};
export default MyAccountPage;
