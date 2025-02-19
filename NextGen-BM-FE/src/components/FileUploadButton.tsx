import { ChangeEvent, FC } from "react";
import { useSelector } from "react-redux";
import { RootState, useAppDispatch } from "../redux/store";
import { addDocument } from "../redux/slices/documentSlice";
import "./scss/fileUploadButton.scss";
import { fileTypeConstants } from "../constants/constants";

const FileUploadButton: FC = () => {
  const dispatch = useAppDispatch();
  const documents = useSelector((state: RootState) => state.documentReducer);
  function handleFileChange(e: ChangeEvent<HTMLInputElement>) {
    if (e.target.files) {
      dispatch(addDocument(e.target.files[0]));
    }
  }

  return (
    <div>
      <input
        accept="image/*, .pdf"
        type="file"
        disabled={documents.value.length > 5}
        onChange={handleFileChange}
      ></input>
      <p>{fileTypeConstants.supportedFileTypes}</p>
    </div>
  );
};
export default FileUploadButton;
