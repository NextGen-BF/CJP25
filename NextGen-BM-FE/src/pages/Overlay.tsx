import { Backdrop, CircularProgress } from "@mui/material";
import { FC } from "react";

const Overlay: FC = () => {
  return (
    <div>
      <Backdrop
        open={true}
        sx={(theme) => ({ color: '#fff', zIndex: theme.zIndex.drawer + 1 })}
      >
        <CircularProgress color="inherit" />
      </Backdrop>
    </div>
  )
}

export default Overlay;
