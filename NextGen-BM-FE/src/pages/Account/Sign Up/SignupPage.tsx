import { Button, TextField } from "@mui/material";
import { FC, useState } from "react";
import { Link } from "react-router-dom";
import "./signup.scss";

const SignupPage: FC = () => {
  const error = true;
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");

  const submit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    // console.log(firstName);
  };

  return (
    <div className="sign-up-container">
      <form className="sign-up-form" onSubmit={(e) => submit(e)}>
        <h2 className="sign-up-header">Sign Up</h2>
        <div className="names-container">
          <TextField
            label="First Name *"
            error={error}
            helperText={error ? "Please provide a first name" : ""}
            variant="outlined"
            size="small"
            onChange={(e) => {
              setFirstName(e.currentTarget.value);
            }}
          />
          <TextField
            label="Last Name *"
            helperText={error ? "Please provide a last name" : ""}
            variant="outlined"
            size="small"
          />
        </div>

        <TextField
          label="Email *"
          type="email"
          variant="outlined"
          size="small"
          fullWidth
        />

        <TextField
          label="Password *"
          type="password"
          variant="outlined"
          size="small"
          fullWidth
        />

        <TextField
          label="Confirm Password *"
          type="password"
          variant="outlined"
          size="small"
          fullWidth
        />

        <TextField
          label="Phone number"
          type="number"
          variant="outlined"
          size="small"
          fullWidth
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
