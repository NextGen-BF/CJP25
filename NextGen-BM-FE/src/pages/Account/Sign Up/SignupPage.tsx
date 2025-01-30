import { Button, TextField } from "@mui/material";
import { FC, useState } from "react";
import { data, Link } from "react-router-dom";
import "./signup.scss";

interface ValidationError {
  key: string;
  error: string;
}

function validateNameField(field: string, value: string): ValidationError {
  const regex = new RegExp("[0-9]");

  if (value.length === 0) {
    return { key: field, error: "Names must not be empty" };
  }

  if (regex.test(value)) {
    return { key: field, error: "Names must not contain numbes" };
  }

  return { key: "", error: "" };
}

function validatePassword(key: string, value: string): ValidationError {
  const regex = new RegExp(
    `^(?=.*[A-Z])(?=.*[!@#$&*.,:;-=()])(?=.*[0-9])(?=.*[a-z]).{6,}$`,
  );

  if (value.length === 0) {
    return { key: key, error: "Please enter a password" };
  }

  if (value.includes(" ")) {
    return { key: key, error: "Password cannot contain white spaces" };
  }

  if (!regex.test(value)) {
    return {
      key: key,
      error:
        "Password requires at least 6 characters, one uppercase, one lower case letter, a number and a special character",
    };
  }

  return { key: "", error: "" };
}

function validateFormData(data: FormData): Map<String, String> {
  const errors = new Map<String, String>();
  const firstName = data.firstName.trim();
  const lastName = data.lastName.trim();
  const password = data.password;
  const confirmPassword = data.confirmPassword;

  const firstNameError = validateNameField("firstName", firstName);
  errors.set(firstNameError.key, firstNameError.error);
  const lastNameError = validateNameField("lastName", lastName);
  errors.set(lastNameError.key, lastNameError.error);
  const passwordError = validatePassword("password", password);
  errors.set(passwordError.key, passwordError.error);

  if (password !== confirmPassword) {
    errors.set("confirmPassword", "Passwords do not match")
  }

  return errors;
}

interface FormData {
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
    errors.delete(name)
    setFormData((previousData) => ({ ...previousData, [name]: value }));
  };

  const submit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    setErrors(validateFormData(formData));
    if (errors.keys.length === 0) {
      console.log("submited", formData)
    }
  };

  return (
    <div className="sign-up-container">
      <form className="sign-up-form" onSubmit={(e) => submit(e)}>
        <h2 className="sign-up-header">Sign Up</h2>
        <div className="names-container">
          <TextField
            name="firstName"
            label="First Name *"
            error={errors.has("firstName")}
            helperText={errors.get("firstName")}
            variant="outlined"
            size="small"
            onChange={(e) => handleChange(e)}
          />
          <TextField
            name="lastName"
            label="Last Name *"
            error={errors.has("lastName")}
            helperText={errors.get("lastName")}
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
          name="password"
          label="Password *"
          error={errors.has("password")}
          helperText={errors.get("password")}
          type="password"
          variant="outlined"
          size="small"
          fullWidth
          onChange={(e) => handleChange(e)}
        />

        <TextField
          name="confirmPassword"
          label="Confirm Password *"
          error={errors.has("confirmPassword")}
          helperText={errors.get("confirmPassword")}
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
