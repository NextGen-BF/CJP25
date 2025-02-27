import { FC, ReactNode } from "react";
import { Navigate } from "react-router-dom";

interface ProtectedRouteProps {
    element: ReactNode;  
    userId: number;  
};

const ProtectedRoute: FC<ProtectedRouteProps> = ({ element, userId }) => {
    if (userId === 0) {
      return <Navigate to="/login" replace />;
    }
  
    return element;
  };

export default ProtectedRoute;