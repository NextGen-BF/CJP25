import { AxiosResponse } from "axios";
import { signupResponseConstants } from "../constants/signupResponseConstants";

export const getMessageForSignupError = (error: AxiosResponse): string => {
  try {
    const duplicateNameError = error.data.errors.DuplicateUserName;
    if (duplicateNameError !== undefined) {
      return signupResponseConstants.emailInUse;
    }
  } catch (error) {
    return signupResponseConstants.genericError;
  }
  return "";
};
