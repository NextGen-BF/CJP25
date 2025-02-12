import { FC, useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { useAppDispatch } from "../../redux/store";
import { Property } from "../../models/property";
import { getProperty } from "../../redux/services/propertyService";
import { Box, Button, Card, MenuItem } from "@mui/material";

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
    <MenuItem>{resident.enterDate.toString()}</MenuItem>
  );
  return (
  <div>
    <h1>Property Dashboard</h1>
    <Card>
      <Box>
        <MenuItem>Number: {property.propertyNumber}</MenuItem>
        <MenuItem>Floor: {property.floor}</MenuItem>
        <MenuItem>Size: {property.size}</MenuItem>
        <MenuItem>Size of ideal parts: {property.sizeOfIdealParts}%</MenuItem>
        <MenuItem>External Entrance: {property.entranceIsExternal?"Yes":"No"}</MenuItem>
        {residentHistoryList}
      </Box>
      <Button>
        Edit
      </Button>
      <Button>
        Delete
      </Button>
    </Card>
  </div>
  );
};
export default PropertyPage;
