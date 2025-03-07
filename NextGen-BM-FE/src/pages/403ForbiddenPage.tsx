import { FC } from "react";
import forbiddenPage from "../static/Screenshot 2025-03-07 at 10.01.45.png";
import { Button } from "@mui/material";
import { useNavigate } from "react-router-dom";

const ForbiddenPage: FC = () => {
  const navigate = useNavigate();
  
  return (
    <div
      style={{
        textAlign: "center",
      }}
    >
      <img src={forbiddenPage} height={"100%"} width={"100%"} />
      <Button onClick={() => navigate('/')}>Go back to home</Button>
    </div>
  );
};

export default ForbiddenPage;
