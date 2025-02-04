import { Accordion, AccordionDetails, AccordionSummary, Button, MenuItem, MenuList } from "@mui/material";
import { FC } from "react";
import { NavLink } from "react-router-dom";

export interface navSubMenuProps{
    groupTitle: string,
    groupLinks: {
        link:string,
        title:string
    }[]
}

export const NavigationSubMenu: FC<navSubMenuProps> = (props)=>{
    const links=props.groupLinks.map(groupLink=>
        <MenuItem>
              <NavLink to={groupLink.link}>{groupLink.title}</NavLink>
        </MenuItem>
    );
    return (
        <Accordion>
        <AccordionSummary>
          <Button>{props.groupTitle}</Button>
        </AccordionSummary>
        <AccordionDetails>
          <MenuList>
            {links}
          </MenuList>
        </AccordionDetails>  
      </Accordion>  
    )
};