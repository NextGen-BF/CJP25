import { ChangeEvent, FC, useEffect, useRef, useState } from "react";
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
  const [error, setError] = useState("");
  function handleFileChange(e: ChangeEvent<HTMLInputElement>) {
    if (e.target.files) {
      if (e.target.files[0].size < 10000000) {
        dispatch(addDocument(e.target.files[0]));
        setError("");
      } else setError(fileTypeConstants.fileSizeError);
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
      {error.length > 0 && (
        <div>
          <p className="error-message">{error}</p>
        </div>
      )}
    </div>
  );
};
export default FileUploadButton;
