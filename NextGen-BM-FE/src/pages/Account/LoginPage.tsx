import { FC } from "react";
import { AppProvider } from '@toolpad/core/AppProvider';
import {
  SignInPage,
  type AuthProvider,
} from '@toolpad/core/SignInPage';
import { useTheme } from '@mui/material/styles';
import { Link } from "@mui/material";
import { Login } from "../../api/authApi";
import { useNavigate } from "react-router-dom";

const providers = [
  {id: 'credentials', name: 'email and password'},
  {id: 'google', name: 'Google'}
]

function SignUpLink() {
  return (
    <Link href="/signup" variant="body2">
      Sign up
    </Link>
  );
}

const LoginPage: FC = () => {
  const navigate = useNavigate();

  if(sessionStorage.getItem("accessToken")){
    navigate("/")
  }

  const signIn = async (
    signIn: AuthProvider,
    formData: FormData,
    redirectTo?: string,
  ) => {
    if (!formData.has("email") || !formData.has("password")) {
      return;
    }
    await Login(
      formData.get("email")!.toString(),
      formData.get("password")!.toString(),
    ).then((response) => {
      if (response != undefined) {
        sessionStorage.setItem("accessToken", response.accessToken);
        console.log(response.accessToken);
        navigate(redirectTo ?? "/");
      }
    });
  };

  const theme = useTheme();
  return (
    <AppProvider theme={theme}>
      <SignInPage signIn={(provider, formData, redirectTo) => {
          signIn(provider, formData, redirectTo);
        }} providers={providers} slots={{signUpLink: SignUpLink}}/>
    </AppProvider>
  );
};
export default LoginPage;