import { useState } from "react";
import {
  DataGrid,
  GridColDef,
  GridRowModes,
  GridRowModel,
  GridRowModesModel,
  GridActionsCellItem,
} from "@mui/x-data-grid";
import { Check, X, Pencil } from "lucide-react";

interface Property {
  id: number;
  propertyNumber: number;
  size: number;
  floor: number;
  sizeOfIdealParts: number;
  entranceIsExternal: boolean;
}

const initialRows: Property[] = [
  {
    id: 1,
    propertyNumber: 101,
    size: 120,
    floor: 3,
    sizeOfIdealParts: 50,
    entranceIsExternal: false,
  },
  {
    id: 2,
    propertyNumber: 102,
    size: 90,
    floor: 2,
    sizeOfIdealParts: 40,
    entranceIsExternal: true,
  },
];

export default function EditableTable() {
  const [rows, setRows] = useState<Property[]>(initialRows);
  const [rowModesModel, setRowModesModel] = useState<GridRowModesModel>({});

  const processRowUpdate = (newRow: GridRowModel) => {
    const updatedRow = newRow as Property;
    setRows((prevRows) =>
      prevRows.map((row) =>
        updatedRow.id === updatedRow.id ? updatedRow : row,
      ),
    );
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

  const columns: GridColDef[] = [
    {
      field: "propertyNumber",
      headerName: "Property Number",
      width: 150,
      editable: true,
    },
    {
      field: "size",
      headerName: "Size",
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
      headerName: "Size of Ideal Parts",
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
            ];
      },
    },
  ];

  return (
    <DataGrid
      rows={rows}
      columns={columns}
      editMode="row"
      processRowUpdate={processRowUpdate}
      rowModesModel={rowModesModel}
      onRowModesModelChange={(newModel) => setRowModesModel(newModel)}
    />
  );
}
