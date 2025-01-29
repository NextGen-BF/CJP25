import { useTheme } from "@mui/material/styles";
import { Button, TextField } from "@mui/material";
import { AppProvider } from "@toolpad/core";
import { FC } from "react";
import { Link } from "react-router-dom";

const SignupPage: FC = () => {
  const theme = useTheme();

  return (
    <AppProvider theme={theme}>
      <div>
        <form>
          <h1>Sign Up</h1>
          <div>
            <TextField
              required
              label="First Name"
              helperText="Please provide a first name"
              variant="outlined"
              size="small"
              sx={{ m: 1 }}
            />
            <TextField
              required
              label="Last Name"
              helperText="Please provide a last name"
              variant="outlined"
              size="small"
              sx={{ m: 1 }}
            />
          </div>

          <TextField
            required
            label="Email"
            type="email"
            variant="outlined"
            size="small"
            fullWidth
            sx={{ m: 1 }}
          />

          <TextField
            required
            label="Password"
            type="password"
            variant="outlined"
            size="small"
            fullWidth
            sx={{ m: 1 }}
          />

          <TextField
            required
            label="Confirm Password"
            type="password"
            variant="outlined"
            size="small"
            fullWidth
            sx={{ m: 1 }}
          />

          <TextField
            label="Phone number"
            type="number"
            variant="outlined"
            size="small"
            fullWidth
            sx={{ m: 1 }}
          />

          <Button
            type="submit"
            variant="contained"
            color="primary"
            fullWidth
            sx={{ m: 1 }}
          >
            Submit
          </Button>

          <Link to="/login">Already Have an Account</Link>
        </form>
      </div>
    </AppProvider>
  );
};
export default SignupPage;
