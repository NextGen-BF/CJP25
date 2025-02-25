import { Button, TextField } from "@mui/material";
import { FC } from "react";
import { Link } from "react-router-dom";
import "./signup.scss";
import {
  signupResponseConstants,
  validationConstants,
} from "../../../constants/constants.ts";
import { useAppDispatch } from "../../../redux/store";
import { signupCall } from "../../../redux/services/signupService";
import { useNavigate } from "react-router-dom";
import { RootState } from "../../../redux/store.ts";
import { setSnackbar } from "../../../redux/slices/snackbarSlice.ts";
import { ErrorSnackbarConstants, SucessSnackbarConstants } from "../../../constants/snackbarConstants.ts";
import { SubmitHandler, useForm } from "react-hook-form";
import { LoginConstants } from "../../../constants/loginConstants.ts";

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
  const navigate = useNavigate();

  const {
    register,
    handleSubmit,
    setError,
    getValues,
    formState: { errors, isSubmitting },
  } = useForm<FormData>();

  const onSubmit: SubmitHandler<FormData> = async (data) => {
    try {
      await dispatch(signupCall({ ...data })).unwrap();
      dispatch(
        setSnackbar({
          snackbarOpen: true,
          snackbarType: "success",
          snackbarMessage: SucessSnackbarConstants.signUpSuccess,
        }),
      );
      setTimeout(() => {
        navigate("/login");
      }, 3000);
    } catch (error) {
      dispatch(
        setSnackbar({
          snackbarOpen: true,
          snackbarType: "error",
          snackbarMessage: ErrorSnackbarConstants.signUpError,
        }),
      );
      
      setError("root", {
        message: signupResponseConstants.genericError,
      });
    }
  };

  return (
    <div className="sign-up-container">
      <form className="sign-up-form" onSubmit={handleSubmit(onSubmit)}>
        <h2 className="sign-up-header">Sign Up</h2>
        <div className="names-container">
          <TextField
            {...register("firstName", {
              required: validationConstants.nameEmpty,
            })}
            label="First Name *"
            variant="outlined"
            size="small"
          />
          <TextField
            {...register("lastName", {
              required: validationConstants.nameEmpty,
            })}
            label="Last Name *"
            variant="outlined"
            size="small"
          />
        </div>
        {errors.lastName && (
          <span className="error-message">{errors.lastName.message}</span>
        )}

        <TextField
          {...register("email", {
            required: LoginConstants.emailRequired,
            pattern: {
              value: validationConstants.regexEmailRequirements,
              message: LoginConstants.emailInvalid,
            },
          })}
          label="Email"
          type="email"
          variant="outlined"
          size="small"
          fullWidth
        />
        {errors.email && (
          <span className="error-message">{errors.email.message}</span>
        )}
        <TextField
          {...register("password", {
            required: validationConstants.passwordEmpty,
            pattern: {
              value: validationConstants.regexPasswordRequirements,
              message: validationConstants.passwordRequirements,
            },
          })}
          label="Password *"
          type="password"
          variant="outlined"
          size="small"
          fullWidth
        />
        {errors.password && (
          <span className="error-message">{errors.password.message}</span>
        )}
        <TextField
          {...register("confirmPassword", {
            required: validationConstants.passwordEmpty,
            pattern: {
              value: validationConstants.regexPasswordRequirements,
              message: validationConstants.passwordRequirements,
            },
            validate: (value) =>
              value == getValues("password")
                ? true
                : validationConstants.confirmPasswordDoesNotMatch,
          })}
          label="Confirm Password *"
          type="password"
          size="small"
          fullWidth
        />
        {errors.confirmPassword && (
          <span className="error-message">
            {errors.confirmPassword.message}
          </span>
        )}
        <TextField
          {...register("phoneNumber")}
          name="phoneNumber"
          label="Phone number"
          type="text"
          variant="outlined"
          size="small"
          fullWidth
        />

        <Button
          type="submit"
          variant="contained"
          color="primary"
          fullWidth
          disabled={isSubmitting}
        >
          Submit
        </Button>

        <Link to="/login">Already Have an Account?</Link>
      </form>
    </div>
  );
};
export default SignupPage;
