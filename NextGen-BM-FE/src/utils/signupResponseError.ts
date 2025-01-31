import { signupResponseConstants } from "../constants/signupResponseConstants";

export const getMessageForSignupError = (error: any): string => {
  try {
    const duplicateNameError = error.errors.DuplicateUserName;
    if (duplicateNameError !== undefined) {
      return signupResponseConstants.emailInUse;
    }
  } catch (error) {
    return signupResponseConstants.genericError;
  }
  return "";
};
