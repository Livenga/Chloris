namespace Chloris.Chrome.Data;


// type     System.String
// name     System.String
// tbl_name System.String
// rootpage System.Int32
// sql      System.String


/// <summary></summary>
public class TableInfo
{
    /// <summary></summary>
    public string Type { set; get; } = string.Empty;

    /// <summary></summary>
    public string Name { set; get; } = string.Empty;

    /// <summary></summary>
    public string TblName { set; get; } = string.Empty;

    /// <summary></summary>
    public int RootPage { set; get; } = 0;

    /// <summary></summary>
    public string Sql { set; get; } = string.Empty;

}
