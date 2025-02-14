import { Dispatch, SetStateAction, useState } from "react";
import {
  DataGrid,
  GridColDef,
  GridRowModes,
  GridRowModel,
  GridRowModesModel,
  GridActionsCellItem,
  GridToolbarContainer,
  GridSlotProps,
} from "@mui/x-data-grid";
import { Check, X, Pencil, DeleteIcon } from "lucide-react";
import { Button } from "@mui/material";
import { useAppDispatch } from "../redux/store";
import {
  addProperty,
  removeProperty
} from "../redux/slices/propertySlice";
import { Property } from "../models/property";
import { editableTableConstants } from "../constants/constants";
import { updateProperty } from "../redux/services/propertyService";

declare module "@mui/x-data-grid" {
  interface ToolbarPropsOverrides {
    setRows: Dispatch<SetStateAction<Property[]>>;
    setRowModesModel: Dispatch<SetStateAction<GridRowModesModel>>;
  }
}

const initialRows: Property[] = [];

export default function EditableTable() {
  const dispatch = useAppDispatch();
  const [rows, setRows] = useState(initialRows);
  const [rowModesModel, setRowModesModel] = useState<GridRowModesModel>({});

  function EditToolbar(props: GridSlotProps["toolbar"]) {
    const { setRows, setRowModesModel } = props;

    const handleClick = () => {
      let newRow: Property = {
        propertyId: 0,
        propertyNumber: rows.length + 1,
        buildingId: 0,
        size: 0,
        floor: 0,
        sizeOfIdealParts: 0,
        entranceIsExternal: true,
        payments: null,
        residentHistory: null,
      };
      setRows((oldRows) => [...oldRows, newRow]);
      setRowModesModel((oldModel) => ({
        ...oldModel,
        [rows.length + 1]: { mode: GridRowModes.Edit, fieldToFocus: "name" },
      }));
      dispatch(addProperty(newRow));
    };

    return (
      <GridToolbarContainer>
        <Button color="primary" onClick={handleClick}>
          {editableTableConstants.addRecond}
        </Button>
      </GridToolbarContainer>
    );
  }

  const processRowUpdate = (newRow: GridRowModel) => {
    const updatedRow = newRow as Property;
    setRows((prevRows) =>
      prevRows.map((row) =>
        row.propertyNumber === updatedRow.propertyNumber ? updatedRow : row,
      ),
    );
    dispatch(updateProperty(updatedRow));
    return newRow;
  };

  const handleEditClick = (id: number) => {
    setRowModesModel({ ...rowModesModel, [id]: { mode: GridRowModes.Edit } });
  };

  const handleSaveClick = (id: number) => {
    setRowModesModel({ ...rowModesModel, [id]: { mode: GridRowModes.View } });
  };

  const handleCancelClick = (id: number) => {
    setRowModesModel({
      ...rowModesModel,
      [id]: { mode: GridRowModes.View, ignoreModifications: true },
    });
  };

  const handleDeleteClick = (id: number) => () => {
    let row = rows.filter((row) => row.propertyNumber !== id);
    setRows(row);
    dispatch(removeProperty(row[0]));
  };

  const columns: GridColDef[] = [
    {
      field: "propertyNumber",
      headerName: "Property Number",
      width: 150,
      editable: true,
    },
    {
      field: "size",
      headerName: "Size (in m2)",
      width: 120,
      editable: true,
      type: "number",
    },
    {
      field: "floor",
      headerName: "Floor",
      width: 120,
      editable: true,
      type: "number",
    },
    {
      field: "sizeOfIdealParts",
      headerName: "Ideal Parts (in %)",
      width: 180,
      editable: true,
      type: "number",
    },
    {
      field: "entranceIsExternal",
      headerName: "External Entrance",
      width: 180,
      editable: true,
      type: "boolean",
    },
    {
      field: "actions",
      type: "actions",
      headerName: "Actions",
      width: 150,
      getActions: ({ id }) => {
        const isEditing = rowModesModel[id]?.mode === GridRowModes.Edit;
        return isEditing
          ? [
            <GridActionsCellItem
              icon={<Check size={18} />}
              label="Save"
              onClick={() => handleSaveClick(id as number)}
            />,
            <GridActionsCellItem
              icon={<X size={18} />}
              label="Cancel"
              onClick={() => handleCancelClick(id as number)}
            />,
          ]
          : [
            <GridActionsCellItem
              icon={<Pencil size={18} />}
              label="Edit"
              onClick={() => handleEditClick(id as number)}
            />,
            <GridActionsCellItem
              icon={<DeleteIcon />}
              label="Delete"
              onClick={handleDeleteClick(id as number)}
              color="inherit"
            />,
          ];
      },
    },
  ];

  return (
    <div>
      <DataGrid
        rows={rows}
        getRowId={(row) => row.propertyNumber}
        columns={columns}
        editMode="row"
        rowModesModel={rowModesModel}
        onRowModesModelChange={(newModel) => setRowModesModel(newModel)}
        processRowUpdate={processRowUpdate}
        pageSizeOptions={[10, 25, 50, 100]}
        slots={{ toolbar: EditToolbar }}
        slotProps={{
          toolbar: { setRows, setRowModesModel },
        }}
      />
    </div>
  );
}
