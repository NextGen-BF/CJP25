import { FC, useEffect, useState } from "react";
import {
  Avatar,
  Button,
  Container,
  Divider,
  Link,
  Paper,
  TextField,
  Typography,
} from "@mui/material";
import { useNavigate } from "react-router-dom";
import { useSelector } from "react-redux";
import { useAppDispatch } from "../../../redux/store.ts";
import { RootState } from "../../../redux/store.ts";
import "../../../style/shared.scss";
import { LoginConstants } from "../../../constants/loginConstants.ts";
import "./login.scss";
import { LockIcon } from "lucide-react";
import { GoogleLoginModel, LoginModel } from "../../../models/user.ts";
import { SubmitHandler, useForm } from "react-hook-form";
import { loginCall } from "../../../redux/services/loginService.ts";
import { validationConstants } from "../../../constants/constants.ts";
import { useGoogleLogin } from "@react-oauth/google";
import {
  getJWTTokenFromTokenResponse,
  loginWithGoogleCall,
} from "../../../redux/services/googleLoginService.ts";

const LoginPage: FC = () => {
  const dispatch = useAppDispatch();
  const navigate = useNavigate();
  const userToken = useSelector((state: RootState) => state.loginReducer.value);
  const [googleLoginTokens, setGoogleLoginTokens] =
    useState<GoogleLoginModel>();
  const {
    register,
    handleSubmit,
    setError,
    formState: { errors, isSubmitting },
  } = useForm<LoginModel>();

  const onSubmit: SubmitHandler<LoginModel> = async (data) => {
    try {
      await dispatch(loginCall(data)).unwrap();
    } catch (error) {
      setError("root", {
        message: LoginConstants.wrongCredentials,
      });
    }
  };

  useEffect(() => {
    if (googleLoginTokens?.access_token)
      dispatch(loginWithGoogleCall(googleLoginTokens.id_token));
  }, [googleLoginTokens]);

  const GoogleAuthProvider = useGoogleLogin({
    onSuccess: async (codeResponse) => {
      const token = await dispatch(
        getJWTTokenFromTokenResponse(codeResponse),
      ).unwrap();
      setGoogleLoginTokens(token);
    },
    flow: "auth-code",
  });

  if (userToken.isLoggedIn) {
    navigate("/");
  }

  return (
    <Container maxWidth="xs" className="text-field">
      <Paper
        elevation={10}
        sx={{ marginTop: 8, padding: 2 }}
        className="text-field"
      >
        <Avatar sx={{ mx: "auto", textAlign: "center", mb: 1 }}>
          <LockIcon />
        </Avatar>
        <Typography component="h1" variant="h5" sx={{ textAlign: "center" }}>
          {LoginConstants.signIn}
        </Typography>
        <div>
          <Button onClick={() => GoogleAuthProvider()} fullWidth>
            {LoginConstants.googleLogin}
          </Button>
        </div>
        <Divider className="text-field">or</Divider>
        <form onSubmit={handleSubmit(onSubmit)}>
          <div className="text-field">
            <TextField
              {...register("email", {
                required: LoginConstants.emailRequired,
                pattern: {
                  value: validationConstants.regexEmailRequirements,
                  message: LoginConstants.emailInvalid,
                },
              })}
              label={validationConstants.emailField}
              fullWidth
            />
          </div>
          {errors.email && (
            <div className="error-message">{errors.email.message}</div>
          )}
          <div className="text-field">
            <TextField
              {...register("password", {
                required: validationConstants.passwordEmpty,
                pattern: {
                  value: validationConstants.regexPasswordRequirements,
                  message: validationConstants.passwordRequirements,
                },
              })}
              type="password"
              label={validationConstants.passwordField}
              fullWidth
            />
          </div>
          {errors.password && (
            <div className="error-message">{errors.password.message}</div>
          )}
          <Button fullWidth disabled={isSubmitting} type="submit">
            {LoginConstants.signIn}
          </Button>
          {errors.root && (
            <div className="error-message">{errors.root.message}</div>
          )}
        </form>
        <div style={{ textAlign: "center" }}>
          <Link href={"/signup"} variant="body2">
            {LoginConstants.signUpLink}
          </Link>
        </div>
      </Paper>
    </Container>
  );
};
export default LoginPage;
