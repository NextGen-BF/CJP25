export const validationConstants = {
  firstNameField: "firstName",
  lastNameField: "lastName",
  passwordField: "password",
  confirmPasswordField: "confirmPassword",
  nameEmpty: "Names must not be empty",
  nameContainsNumbers: "Names must not contain numbes",
  passwordEmpty: "Please enter a password",
  passwordWhiteSpaces: "Password cannot contain white spaces",
  passwordRequirements:
    "Password requires at least 6 characters, one uppercase, one lower case letter, a number and a special character",
  confirmPasswordDoesNotMatch: "Passwords do not match",
  regexNoNumbers: "[0-9]",
  regexPasswordRequirements:
    "^(?=.*[A-Z])(?=.*[!@#$&*.,:;-=()])(?=.*[0-9])(?=.*[a-z]).{6,}$",
};

export const signupResponseConstants = {
  emailInUse: "This email is already in use.",
  genericError: "We have encountered an error, please try again later.",
};

export const createBuildingConstants = {
  create: "Create Building",
  createHeader: "Create a Building"
}

export const logOut = {
  logout: "Log out"
}

export const editableTableConstants = {
  addRecord: "Add a property"
}

export const createPropertyExpenseConstants = {
  title: "Create Property Expense",
  role: "Role",
  role_owner: "Owner",
  role_tenant: "Tenant",
  create: "Create Property Epense",
  addRecond: "Add a property"
}