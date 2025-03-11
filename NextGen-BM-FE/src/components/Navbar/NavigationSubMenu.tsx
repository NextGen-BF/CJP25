import {
  Accordion,
  AccordionDetails,
  AccordionSummary,
  Button,
  MenuItem,
  MenuList,
} from "@mui/material";
import { FC } from "react";
import { NavLink } from "react-router-dom";
import "./navbar.scss";
import { useSelector } from "react-redux";
import { RootState } from "../../redux/store";

export interface navSubMenuProps {
  groupTitle: string;
  groupLinks: {
    link: string;
    title: string;
    role?: string;
  }[];
}

export const NavigationSubMenu: FC<navSubMenuProps> = (props) => {
  const userRole = useSelector(
    (state: RootState) => state.loginReducer.value.role,
  );

  const links = props.groupLinks.map((groupLink) => (
    <MenuItem
      key={groupLink.title}
      sx={{
        display:
          userRole !== "super" && groupLink.role === "super" ? "none" : "block",
      }}
      component={NavLink}
      className={"submenu-link"}
      to={groupLink.link}
    >
      {groupLink.title}
    </MenuItem>
  ));
  return (
    <Accordion>
      <AccordionSummary>
        <Button>{props.groupTitle}</Button>
      </AccordionSummary>
      <AccordionDetails>
        <MenuList>{links}</MenuList>
      </AccordionDetails>
    </Accordion>
  );
};
