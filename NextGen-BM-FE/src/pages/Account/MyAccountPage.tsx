import { FC, useEffect } from "react";
import { RootState, useAppDispatch } from "../../redux/store";
import { useSelector } from "react-redux";
import { getUserById } from "../../redux/services/loginService";

const MyAccountPage: FC = () => {
  const dispatch= useAppDispatch();
  const currentUserId=useSelector((state: RootState) => state.loginReducer.value.userId);
  
  const user=useSelector((state: RootState) => state.accountReducer.value);
  useEffect(() => {
    dispatch(getUserById(currentUserId));
  }, []);
  
  return (
    <>
      <h1>My account Page</h1>
      <div>
        
      </div>
    </>
  );
};
export default MyAccountPage;
