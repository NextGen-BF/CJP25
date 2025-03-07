import { FC, ReactNode } from "react";
import { Navigate } from "react-router-dom";

interface ProtectedRouteProps {
    element: ReactNode;  
    userId: number;  
    userRole: string;
    requiredRole?: string;
};

const ProtectedRoute: FC<ProtectedRouteProps> = ({ element, userId, userRole, requiredRole }) => {
    if (userId === 0) {
      return <Navigate to="/login" replace />;
    }

    if (requiredRole === "super" && userRole !== requiredRole) {
      return <Navigate to="/forbidden" replace />;
    }

    return element;
  };

export default ProtectedRoute;