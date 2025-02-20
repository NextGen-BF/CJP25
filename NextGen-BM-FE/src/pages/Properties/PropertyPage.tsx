import { FC, useEffect, useState } from "react";
import { NavLink, useParams } from "react-router-dom";
import { RootState, useAppDispatch } from "../../redux/store";
import { Property } from "../../models/property";
import { deleteProperty, deletePropertyResident, getProperty, updateProperty } from "../../redux/services/propertyService";
import { Accordion, AccordionDetails, AccordionSummary, Button, Card, MenuItem, Stack, TextField } from "@mui/material";
import { useForm, Controller, SubmitHandler } from "react-hook-form"
import { useSelector } from "react-redux";
import { propertyCardButtonConstants, propertyLabelConstants, propertyPagesTitles, residentListConstants } from "../../constants/propertyPageConstants";

const PropertyPage: FC = () => {
  const dispatch=useAppDispatch();
  const propertyId=parseInt(useParams().id??"");
  const property=useSelector((state: RootState) => state.propertyReducer.value.find(p=>p.propertyId===state.propertyReducer.current));
  
  const [editToggle, setEditToggle]=useState<boolean>(false);
  useEffect(() => {
    dispatch(getProperty(propertyId));
  }, []);
  
  const { control, handleSubmit } = useForm<Property>({
    values:property
  });
  const onSubmit:SubmitHandler<Property> = (newData)=>{
    setEditToggle(false);
    dispatch(updateProperty(newData));
  }
  if (property==null) return (
    <h1>{propertyPagesTitles.badRequest}</h1>
  );
  const residentHistoryList=property.residentHistory?.map(resident=>
    <Stack direction={"row"} justifyContent={"space-between"}>
      <MenuItem>{`${residentListConstants.name} ${resident.firstName} ${resident.lastName}`}</MenuItem>
      <MenuItem>{`${residentListConstants.enterDate} ${resident.enterDate.toString()}`}</MenuItem>
      <MenuItem>{`${residentListConstants.leaveDate} ${resident.leaveDate.toString()}`}</MenuItem>
      <Button variant="contained" onClick={()=>dispatch(deletePropertyResident(resident.propertyResidentsId))}>{propertyCardButtonConstants.deleteButton}</Button>
    </Stack>
  );
  return (
  <div>
    <h1>{propertyPagesTitles.propertyDashboard}</h1>
    <Card>
      <form onSubmit={handleSubmit(onSubmit)}>
        <Button component={NavLink} to={`/building/${property.buildingId}`}>{propertyCardButtonConstants.buildingButton}</Button>
        <MenuItem>{`${propertyLabelConstants.propertyNumber} `}{!editToggle?property.propertyNumber:
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
        <MenuItem>{`${propertyLabelConstants.floor} `}{!editToggle?property.floor:
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
        <MenuItem>{`${propertyLabelConstants.size} `}{!editToggle?property.size:
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
        {` ${propertyLabelConstants.sizeUnit}`}</MenuItem>
        <MenuItem>{`${propertyLabelConstants.sizeOfIdealParts} `}{!editToggle?property.sizeOfIdealParts:
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
        {`${propertyLabelConstants.sizeOfIdealPartsUnit}`}</MenuItem>
        <MenuItem>{`${propertyLabelConstants.entranceIsExternal} `}{!editToggle?(property.entranceIsExternal?
                                                                                propertyLabelConstants.externalEntanceTrue
                                                                                :propertyLabelConstants.externalEntanceFalse):
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
        {editToggle?<Button type="submit">{propertyCardButtonConstants.saveButton}</Button>:""}
        <Accordion>
          <AccordionSummary>
            {residentListConstants.title}
          </AccordionSummary>
          <AccordionDetails>
            {residentHistoryList}
          </AccordionDetails>
        </Accordion>
        <Button component={NavLink} to="/property/fees">{propertyCardButtonConstants.feesButton}</Button>
      </form>
      <Button variant="contained" onClick={()=>setEditToggle(!editToggle)}>
        {propertyCardButtonConstants.toggleButton}
      </Button>
      <Button variant="contained" onClick={()=>dispatch(deleteProperty(propertyId))}>
      {propertyCardButtonConstants.deleteButton}
      </Button>
    </Card>
  </div>
  );
};
export default PropertyPage;
