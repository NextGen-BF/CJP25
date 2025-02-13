import { FC, useEffect, useState } from "react";
import { NavLink, useParams } from "react-router-dom";
import { useAppDispatch } from "../../redux/store";
import { Property } from "../../models/property";
import { deleteProperty, getProperty } from "../../redux/services/propertyService";
import { Accordion, AccordionDetails, AccordionSummary, Box, Button, Card, MenuItem, Stack } from "@mui/material";

const PropertyPage: FC = () => {
  const propertyId=parseInt(useParams().id??"");
  const dispatch=useAppDispatch();
  const [property, setProperty]=useState<Property>({
    propertyId: 0,
    propertyNumber: 0,
    buildingId: 0,
    size: 0,
    floor: 0,
    sizeOfIdealParts: 0,
    entranceIsExternal: false,
    propertyExpenses: null,
    payments: null,
    residentHistory: null
  });
  useEffect(() => {
    getProperty(propertyId).then(setProperty)
  }, []);
  const residentHistoryList=property.residentHistory?.map(resident=>
    <Stack direction={"row"} justifyContent={"space-between"}>
      <MenuItem>Name: {resident.firstName} {resident.lastName}</MenuItem>
      <MenuItem>Enter Date: {resident.enterDate.toString()}</MenuItem>
      <MenuItem>Leave Date: {resident.leaveDate.toString()}</MenuItem>
    </Stack>
  );
  return (
  <div>
    <h1>Property Dashboard</h1>
    <Card>
      <Box>
        <Button component={NavLink} to={`/building/${property.buildingId}`}>Building</Button>
        <MenuItem>Number: {property.propertyNumber}</MenuItem>
        <MenuItem>Floor: {property.floor}</MenuItem>
        <MenuItem>Size: {property.size} sq. m</MenuItem>
        <MenuItem>Size of ideal parts: {property.sizeOfIdealParts}%</MenuItem>
        <MenuItem>External Entrance: {property.entranceIsExternal?"Yes":"No"}</MenuItem>
        <Accordion>
          <AccordionSummary>
            Resident History
          </AccordionSummary>
          <AccordionDetails>
            {residentHistoryList}
          </AccordionDetails>
        </Accordion>
        <Button component={NavLink} to="/property/fees">Fees</Button>
      </Box>
      <Button>
        Edit
      </Button>
      <Button onClick={()=>dispatch(deleteProperty(propertyId))}>
        Delete
      </Button>
    </Card>
  </div>
  );
};
export default PropertyPage;
