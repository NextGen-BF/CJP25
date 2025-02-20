import { FC, useEffect, useState } from "react";
import { SignInPage } from "@toolpad/core/SignInPage";
import { Link } from "@mui/material";
import { useNavigate } from "react-router-dom";
import { loginCall } from "../../../redux/services/loginService.ts";
import { useSelector } from "react-redux";
import { useAppDispatch } from "../../../redux/store.ts";
import { RootState } from "../../../redux/store.ts";
import { GoogleLogin } from "@react-oauth/google";
import {
  Providers,
  LoginFields,
  LoginConstants,
} from "../../../constants/loginConstants.ts";
import {
  GoogleLoginCredentials,
  loginWithGoogleCall,
} from "../../../redux/services/googleLoginService.ts";
import { subtitleStyle } from "./loginComponentUtilities.ts";
import "./login.scss";

const providers = [
  { id: Providers.credentialsId, name: Providers.credentialsName },
];

function SignUpLink() {
  return (
    <Link href="/signup" variant="body2">
      Sign up
    </Link>
  );
}

const LoginPage: FC = () => {
  const dispatch = useAppDispatch();
  const navigate = useNavigate();
  const [error, setError] = useState("");
  const userToken = useSelector((state: RootState) => state.loginReducer.value);

  useEffect(() => {
    userToken.isLoggedIn ? navigate("/") : null;
  }, [userToken]);

  const Subtitle = () => {
    const hasError = error.length !== 0;
    return (
      <p className={subtitleStyle(hasError)}>
        {hasError ? error : LoginConstants.subtitleText}
      </p>
    );
  };

  const onSuccesfullGoogleSignIn = (credentials: GoogleLoginCredentials) => {
    if (credentials.credential === undefined) {
      pressentLoginError(LoginConstants.googleNoCredentialsError);
      return;
    }
    dispatch(loginWithGoogleCall(credentials));
  };

  const pressentLoginError = (error: string) => {
    setError(error);
  };

  const logInWithCredentials = (email: string, password: string) => {
    dispatch(
      loginCall({
        email: email,
        password: password,
      }),
    );
  };

  const signIn = async (formData: FormData) => {
    const email = formData.get(LoginFields.email)?.toString();
    const password = formData.get(LoginFields.password)?.toString();
    if (email === undefined || password === undefined) return;
    logInWithCredentials(email!, password!);
  };

  return (
    <div>
      <GoogleLogin
        onSuccess={(credentials) =>
          onSuccesfullGoogleSignIn({
            credential: credentials.credential,
            clientId: credentials.clientId,
          })
        }
        onError={() => pressentLoginError(LoginConstants.genericLoginError)}
      />

      <SignInPage
        signIn={(_, formData) => {
          signIn(formData);
        }}
        providers={providers}
        slots={{
          signUpLink: SignUpLink,
          subtitle: Subtitle,
        }}
      />
    </div>
  );
};
export default LoginPage;
