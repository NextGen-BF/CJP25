namespace NextGen_BM_BE_Domain;

public class Property{
    public int PropertyID { get; set; }
    public int PropertyNumber { get; set; }
    public int BuildingID { get; set; }
    public double Size { get; set; }
    public int Floor { get; set; }
    public double SizeOfIdealParts { get; set; }
    public int PropertyTypeID { get; set; }
    public bool entranceIsExternal { get; set; }

}