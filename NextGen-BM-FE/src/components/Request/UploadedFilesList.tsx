import { Button, Divider } from "@mui/material";
import { FC } from "react";
import { fileTypeConstants } from "../../constants/constants";
import { removeDocument } from "../../redux/slices/documentSlice";
import { RootState, useAppDispatch } from "../../redux/store";
import { useSelector } from "react-redux";

const UploadedFilesList: FC = () => {
  const dispatch = useAppDispatch();
  const documents = useSelector((state: RootState) => state.documentReducer);
  return (
    <div>
      {documents.value.map((file) => (
        <>
          {file.type && (
            <>
              <div className="file-container">
                {file.type.includes("image") && (
                  <img
                    src={URL.createObjectURL(file)}
                    className="image"
                    width="300px"
                  />
                )}
                {file.type.includes("pdf") && (
                  <object data={URL.createObjectURL(file)} />
                )}
                <p>
                  {fileTypeConstants.fileName} {file.name}
                </p>
                <Button onClick={() => dispatch(removeDocument(file))}>
                  X
                </Button>
              </div>
              <Divider />
            </>
          )}
        </>
      ))}
    </div>
  );
};
export default UploadedFilesList;
