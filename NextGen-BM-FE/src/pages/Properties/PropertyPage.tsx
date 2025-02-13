import { FC, useEffect, useState } from "react";
import { NavLink, useParams } from "react-router-dom";
import { RootState, useAppDispatch } from "../../redux/store";
import { Property } from "../../models/property";
import { deleteProperty, deletePropertyResident, getProperty, updateProperty } from "../../redux/services/propertyService";
import { Accordion, AccordionDetails, AccordionSummary, Box, Button, Card, MenuItem, Stack, TextField } from "@mui/material";
import { useForm, Controller, SubmitHandler } from "react-hook-form"
import { useSelector } from "react-redux";

const PropertyPage: FC = () => {
  const dispatch=useAppDispatch();
  const propertyId=parseInt(useParams().id??"");
  const property=useSelector((state: RootState) => state.propertyReducer.value.find(p=>p.propertyId===state.propertyReducer.current));
  const [editToggle, setEditToggle]=useState<boolean>(false);
  useEffect(() => {
    dispatch(getProperty(propertyId));
  }, []);
  const { control, handleSubmit } = useForm<Property>();
  const onSubmit:SubmitHandler<Property> = (newData)=>{
    console.log(property);
    setEditToggle(false);
    newData.propertyId=property?.propertyId??0;
    newData.buildingId=property?.buildingId??0;
    dispatch(updateProperty(newData));
  }
  if (property==null) return (
    <h1>Can't access this property</h1>
  );
  const residentHistoryList=property.residentHistory?.map(resident=>
    <Stack direction={"row"} justifyContent={"space-between"}>
      <MenuItem>Name: {resident.firstName} {resident.lastName}</MenuItem>
      <MenuItem>Enter Date: {resident.enterDate.toString()}</MenuItem>
      <MenuItem>Leave Date: {resident.leaveDate.toString()}</MenuItem>
      <Button variant="contained" onClick={()=>dispatch(deletePropertyResident(resident.propertyResidentsId))}>Delete</Button>
    </Stack>
  );
  return (
  <div>
    <h1>Property Dashboard</h1>
    <Card>
      <form onSubmit={handleSubmit(onSubmit)}>
        <Button component={NavLink} to={`/building/${property.buildingId}`}>Building Page</Button>
        <MenuItem>Number:{!editToggle?property.propertyNumber:
          <Controller
          name="propertyNumber"
          control={control}
          render={({ field }) =>(
            <TextField
              {...field}
              type="number"
              defaultValue={property.propertyNumber}
              variant="standard"
              size="small"/>)}
          />}
        </MenuItem>
        <MenuItem>Floor: {!editToggle?property.floor:
          <Controller
          name="floor"
          control={control}
          render={({ field }) =>(
            <TextField
              {...field}
              type="number"
              defaultValue={property.floor}
              variant="standard"
              size="small"/>)}
          />}
        </MenuItem>
        <MenuItem>Size: {!editToggle?property.size:
          <Controller
          name="size"
          control={control}
          render={({ field }) =>(
            <TextField
              {...field}
              type="number"
              defaultValue={property.size}
              variant="standard"
              size="small"/>)}
          />}
        sq. m</MenuItem>
        <MenuItem>Size of ideal parts: {!editToggle?property.sizeOfIdealParts:
          <Controller
          name="sizeOfIdealParts"
          control={control}
          render={({ field }) =>(
            <TextField
              {...field}
              type="number"
              defaultValue={property.sizeOfIdealParts}
              variant="standard"
              size="small"/>)}
          />}
        %</MenuItem>
        <MenuItem>External Entrance: {!editToggle?(property.entranceIsExternal?"Yes":"No"):
          <Controller
          name="entranceIsExternal"
          control={control}
          render={({ field }) =>(
            <TextField
              {...field}
              type="checkbox"
              defaultValue={property.entranceIsExternal}
              variant="standard"
              size="small"/>)}
          />}
        </MenuItem>
        {editToggle?<Button type="submit">Save changes</Button>:""}
        <Accordion>
          <AccordionSummary>
            Resident History
          </AccordionSummary>
          <AccordionDetails>
            {residentHistoryList}
          </AccordionDetails>
        </Accordion>
        <Button component={NavLink} to="/property/fees">Fees</Button>
      </form>
      <Button variant="contained" onClick={()=>setEditToggle(!editToggle)}>
        Edit
      </Button>
      <Button variant="contained" onClick={()=>dispatch(deleteProperty(propertyId))}>
        Delete
      </Button>
    </Card>
  </div>
  );
};
export default PropertyPage;
