import { Button, TextField } from "@mui/material";
import { FC, useState } from "react";
import { Link } from "react-router-dom";
import "./signup.scss";
import { validateFormData } from "../../../utils/signupValidation";
import { validationConstants } from "../../../constants/validationConstants";
import { useAppDispatch } from "../../../redux/store";
import { signupCall } from "../../../redux/services/signupService";
import { useSelector } from "react-redux";
import { RootState } from "../../../redux/store.ts";

export interface FormData {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  confirmPassword: string;
  phoneNumber: string;
}

const SignupPage: FC = () => {
  const dispatch = useAppDispatch();
  const [formData, setFormData] = useState<FormData>({
    firstName: "",
    lastName: "",
    email: "",
    password: "",
    confirmPassword: "",
    phoneNumber: "",
  });
  let errors = new Map<String, String>();
  const [presentedErrors, setpresentedErrors] = useState(errors);
  const message = useSelector(
    (state: RootState) => state.signupReducer.signupResultMessage,
  );

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>,
  ) => {
    const { name, value } = e.target;
    errors.delete(name);
    setFormData((previousData) => ({ ...previousData, [name]: value }));
  };

  const handleFormSubmition = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    errors = validateFormData(formData);
    setpresentedErrors(errors);
    errors.delete("");
    if (errors.size === 0) {
      dispatch(signupCall({ ...formData }));
    }
  };

  return (
    <div className="sign-up-container">
      <form className="sign-up-form" onSubmit={(e) => handleFormSubmition(e)}>
        <h2 className="sign-up-header">Sign Up</h2>
        <h4 className="sign-up-message" hidden={message.length === 0}>
          {message}
        </h4>
        <div className="names-container">
          <TextField
            name={validationConstants.firstNameField}
            label="First Name *"
            error={presentedErrors.has(validationConstants.firstNameField)}
            helperText={presentedErrors.get(validationConstants.firstNameField)}
            variant="outlined"
            size="small"
            onChange={(e) => handleChange(e)}
          />
          <TextField
            name={validationConstants.lastNameField}
            label="Last Name *"
            error={presentedErrors.has(validationConstants.lastNameField)}
            helperText={presentedErrors.get(validationConstants.lastNameField)}
            variant="outlined"
            size="small"
            onChange={(e) => handleChange(e)}
          />
        </div>

        <TextField
          required
          name="email"
          label="Email"
          type="email"
          variant="outlined"
          size="small"
          fullWidth
          onChange={(e) => handleChange(e)}
        />

        <TextField
          name={validationConstants.passwordField}
          label="Password *"
          error={presentedErrors.has(validationConstants.passwordField)}
          helperText={presentedErrors.get(validationConstants.passwordField)}
          type="password"
          variant="outlined"
          size="small"
          fullWidth
          onChange={(e) => handleChange(e)}
        />

        <TextField
          name={validationConstants.confirmPasswordField}
          label="Confirm Password *"
          error={presentedErrors.has(validationConstants.confirmPasswordField)}
          helperText={presentedErrors.get(
            validationConstants.confirmPasswordField,
          )}
          type="password"
          variant="outlined"
          size="small"
          fullWidth
          onChange={(e) => handleChange(e)}
        />

        <TextField
          name="phoneNumber"
          label="Phone number"
          error={presentedErrors.has("phoneNumber")}
          helperText={presentedErrors.get("phoneNumber")}
          type="text"
          variant="outlined"
          size="small"
          fullWidth
          onChange={(e) => handleChange(e)}
        />

        <Button type="submit" variant="contained" color="primary" fullWidth>
          Submit
        </Button>

        <Link to="/login">Already Have an Account?</Link>
      </form>
    </div>
  );
};
export default SignupPage;
