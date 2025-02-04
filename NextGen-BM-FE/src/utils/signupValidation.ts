import { validationConstants } from "../constants/constants";
import { FormData } from "../pages/Account/Sign Up/SignupPage";

interface ValidationError {
  key: string;
  error: string;
}

const validateNameField = (field: string, value: string): ValidationError => {
  const regex = new RegExp(validationConstants.regexNoNumbers);

  if (value.length === 0) {
    return { key: field, error: validationConstants.nameEmpty };
  }

  if (regex.test(value)) {
    return { key: field, error: validationConstants.nameContainsNumbers };
  }

  return { key: "", error: "" };
};

const validatePassword = (key: string, value: string): ValidationError => {
  const regex = new RegExp(validationConstants.regexPasswordRequirements);

  if (value.length === 0) {
    return { key: key, error: validationConstants.passwordEmpty };
  }

  if (value.includes(" ")) {
    return { key: key, error: validationConstants.passwordWhiteSpaces };
  }

  if (!regex.test(value)) {
    return {
      key: key,
      error: validationConstants.passwordRequirements,
    };
  }

  return { key: "", error: "" };
};

export const validateFormData = (data: FormData): Map<String, String> => {
  const errors = new Map<String, String>();
  const firstName = data.firstName.trim();
  const lastName = data.lastName.trim();
  const password = data.password;
  const confirmPassword = data.confirmPassword;

  const firstNameError = validateNameField(
    validationConstants.firstNameField,
    firstName,
  );
  errors.set(firstNameError.key, firstNameError.error);
  const lastNameError = validateNameField(
    validationConstants.lastNameField,
    lastName,
  );
  errors.set(lastNameError.key, lastNameError.error);
  const passwordError = validatePassword(
    validationConstants.passwordField,
    password,
  );
  errors.set(passwordError.key, passwordError.error);

  if (password !== confirmPassword) {
    errors.set(
      validationConstants.confirmPasswordField,
      validationConstants.confirmPasswordDoesNotMatch,
    );
  }

  return errors;
};
