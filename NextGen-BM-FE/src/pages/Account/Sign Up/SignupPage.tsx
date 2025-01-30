import { Button, TextField } from "@mui/material";
import { FC, useState } from "react";
import { Link } from "react-router-dom";
import "./signup.scss";
import { validateFormData } from "../../../utils/signupValidation";
import { validationConstants } from "../../../constants/validationConstants";

export interface FormData {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  confirmPassword: string;
  phoneNumber: string;
}

const SignupPage: FC = () => {
  const [formData, setFormData] = useState<FormData>({
    firstName: "",
    lastName: "",
    email: "",
    password: "",
    confirmPassword: "",
    phoneNumber: "",
  });
  const [errors, setErrors] = useState(new Map<String, String>());

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>,
  ) => {
    const { name, value } = e.target;
    errors.delete(name);
    setFormData((previousData) => ({ ...previousData, [name]: value }));
  };

  const submit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    setErrors(validateFormData(formData));
    if (errors.keys.length === 0) {
      console.log("submited", formData);
    }
  };

  return (
    <div className="sign-up-container">
      <form className="sign-up-form" onSubmit={(e) => submit(e)}>
        <h2 className="sign-up-header">Sign Up</h2>
        <div className="names-container">
          <TextField
            name={validationConstants.firstNameField}
            label="First Name *"
            error={errors.has(validationConstants.firstNameField)}
            helperText={errors.get(validationConstants.firstNameField)}
            variant="outlined"
            size="small"
            onChange={(e) => handleChange(e)}
          />
          <TextField
            name={validationConstants.lastNameField}
            label="Last Name *"
            error={errors.has(validationConstants.lastNameField)}
            helperText={errors.get(validationConstants.lastNameField)}
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
          error={errors.has(validationConstants.passwordField)}
          helperText={errors.get(validationConstants.passwordField)}
          type="password"
          variant="outlined"
          size="small"
          fullWidth
          onChange={(e) => handleChange(e)}
        />

        <TextField
          name={validationConstants.confirmPasswordField}
          label="Confirm Password *"
          error={errors.has(validationConstants.confirmPasswordField)}
          helperText={errors.get(validationConstants.confirmPasswordField)}
          type="password"
          variant="outlined"
          size="small"
          fullWidth
          onChange={(e) => handleChange(e)}
        />

        <TextField
          name="phoneNumber"
          label="Phone number"
          error={errors.has("phoneNumber")}
          helperText={errors.get("phoneNumber")}
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
