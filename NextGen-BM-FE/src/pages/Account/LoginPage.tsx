import { FC } from "react";
import { SignInPage } from "@toolpad/core/SignInPage";
import { Link } from "@mui/material";
import { useNavigate } from "react-router-dom";
import { loginCall } from "../../redux/services/loginService.ts";
import { useSelector } from "react-redux";
import { useAppDispatch } from "../../redux/store.ts";
import { RootState } from "../../redux/store.ts";

const providers = [
  { id: "credentials", name: "email and password" },
  { id: "google", name: "Google" },
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
  const userToken = useSelector((state: RootState) => state.loginReducer.value);

  const signIn = async (formData: FormData) => {
    if (!formData.has("email") || !formData.has("password")) {
      return;
    }
    dispatch(
      loginCall({
        email: formData.get("email")!.toString(),
        password: formData.get("password")!.toString(),
      }),
    );
    if (userToken.accessToken) {
      //TODO: Fix bug where it doesn't register on first click
      navigate("/");
    }
  };

  return (
    <SignInPage
      signIn={(_, formData) => {
        signIn(formData);
      }}
      providers={providers}
      slots={{ signUpLink: SignUpLink }}
    />
  );
};
export default LoginPage;
