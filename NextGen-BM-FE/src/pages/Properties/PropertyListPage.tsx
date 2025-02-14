import { FC, useEffect } from "react";
import { RootState, useAppDispatch } from "../../redux/store";
import { deleteProperty, deletePropertyResident, getProperties } from "../../redux/services/propertyService";
import { useSelector } from "react-redux";
import { Accordion, AccordionDetails, AccordionSummary, Button, MenuItem, Stack } from "@mui/material";
import { NavLink } from "react-router-dom";

const PropertyListPage: FC = () => {
  const dispatch=useAppDispatch();
  useEffect(() => {
      dispatch(getProperties());
    }, []);
  //should show user's managed properties when userids get fixed later
  const properties=useSelector((state: RootState) => state.propertyReducer.value);
  const propertiesList=properties.map((property)=>
    <Accordion>
      <AccordionSummary>
        <Stack direction={"row"} justifyContent={"space-between"}>
          <MenuItem>Number {property.propertyNumber}, Floor {property.floor}</MenuItem>
          <MenuItem>Size: {property.size} sq. m</MenuItem>
          <MenuItem>Ideal Parts: {property.sizeOfIdealParts}%</MenuItem>
          <MenuItem>External entrance: {property.entranceIsExternal?"Yes":"No"}</MenuItem>
        </Stack>
      </AccordionSummary>
      <AccordionDetails>
        <Button component={NavLink} to={`/property/${property.propertyId}`}>Property Page</Button>
        <Button component={NavLink} to={`/building/${property.buildingId}`}>Building Page</Button>
        <Button onClick={()=>dispatch(deleteProperty(property.propertyId))}>Delete</Button>
      </AccordionDetails>
    </Accordion>
  );
  return (
    <>
      <h1>Apartments List Page</h1>
      {propertiesList}
      <Button variant="contained" component={NavLink} to="/create/property">Add New</Button>
    </>
  );
};
export default PropertyListPage;
