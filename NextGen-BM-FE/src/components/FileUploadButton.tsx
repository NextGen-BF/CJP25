import { ChangeEvent, FC } from "react";
import { useSelector } from "react-redux";
import { RootState, useAppDispatch } from "../redux/store";
import { addDocument } from "../redux/slices/documentSlice";
import "./scss/fileUploadButton.scss";

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
        type="file"
        disabled={documents.value.length > 5}
        onChange={handleFileChange}
      ></input>
      {documents.value.map((file) => (
        <div>
          <img
            src={URL.createObjectURL(file)}
            className="image"
            width="300px"
          ></img>
          <p>File name: {file.name}</p>
          <p>Size: {(file.size / 1048576).toPrecision(3)} Mb</p>
          <p>Type: {file.type}</p>
        </div>
      ))}
    </div>
  );
};
export default FileUploadButton;
