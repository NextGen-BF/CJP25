import { AxiosResponse } from "axios";

export const getMessageForSignupError = (error: AxiosResponse): string => {
  try {
    const duplicateNameError = error.data.errors.DuplicateUserName;
    if (duplicateNameError !== undefined) {
      return "This email is already in use.";
    }
  } catch (error) {
    return "We have encountered an error, please try again later.";
  }
  return "";
};
