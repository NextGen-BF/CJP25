import { ChangeEvent, FC, useEffect, useRef } from "react";
import { useSelector } from "react-redux";
import { RootState, useAppDispatch } from "../redux/store";
import { addDocument } from "../redux/slices/documentSlice";
import "./scss/fileUploadButton.scss";
import { fileTypeConstants } from "../constants/constants";
import { Button } from "@mui/material";

const FileUploadButton: FC = () => {
  const ref = useRef<HTMLInputElement | null>(null);
  const dispatch = useAppDispatch();
  const documents = useSelector((state: RootState) => state.documentReducer);
  function handleFileChange(e: ChangeEvent<HTMLInputElement>) {
    if (e.target.files) {
      dispatch(addDocument(e.target.files[0]));
    }
  }
  useEffect(() => {
    if (ref.current && documents.value.length == 0) ref.current.value = "";
  }, [documents.value.length]);

  const triggerFileInput = () => {
    ref.current?.click();
  };

  return (
    <div>
      <input
        ref={ref}
        accept="image/*, .pdf"
        type="file"
        disabled={documents.value.length > 5}
        onChange={handleFileChange}
        style={{ display: "none" }}
      />
      <Button onClick={triggerFileInput}>{fileTypeConstants.selectFile}</Button>
      <span>{fileTypeConstants.supportedFileTypes}</span>
      <p></p>
    </div>
  );
};
export default FileUploadButton;
