import { FC, useEffect } from "react";
import { RootState, useAppDispatch } from "../../redux/store";
import { deleteProperty, getProperties } from "../../redux/services/propertyService";
import { useSelector } from "react-redux";
import { Accordion, AccordionDetails, AccordionSummary, Button, MenuItem, Stack } from "@mui/material";
import { NavLink } from "react-router-dom";
import { propertyCardButtonConstants, propertyLabelConstants } from "../../constants/propertyPageConstants";

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
          <MenuItem>{`${propertyLabelConstants.propertyNumber} ${property.propertyNumber}, ${propertyLabelConstants.floor} ${property.floor}`}</MenuItem>
          <MenuItem>{`${propertyLabelConstants.floor} ${property.size} ${propertyLabelConstants.sizeUnit}`}</MenuItem>
          <MenuItem>{`${propertyLabelConstants.sizeOfIdealParts} ${property.sizeOfIdealParts}${propertyLabelConstants.sizeOfIdealPartsUnit}`}</MenuItem>
          <MenuItem>{`${propertyLabelConstants.entranceIsExternal} ${property.entranceIsExternal?propertyLabelConstants.externalEntanceTrue:propertyLabelConstants.externalEntanceFalse}`}</MenuItem>
        </Stack>
      </AccordionSummary>
      <AccordionDetails>
        <Button component={NavLink} to={`/property/${property.propertyId}`}>{propertyCardButtonConstants.propertyButton}</Button>
        <Button component={NavLink} to={`/building/${property.buildingId}`}>{propertyCardButtonConstants.deleteButton}</Button>
        <Button onClick={()=>dispatch(deleteProperty(property.propertyId))}>{propertyCardButtonConstants.buildingButton}</Button>
      </AccordionDetails>
    </Accordion>
  );
  return (
    <>
      <h1>Apartments List Page</h1>
      {propertiesList}
      <Button variant="contained" component={NavLink} to="/create/property">{propertyCardButtonConstants.addButton}</Button>
    </>
  );
};
export default PropertyListPage;
