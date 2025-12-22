namespace CarAccessories.Application.Common.QueryFilter;
public static class DateFormat
{
    /// <summary>
    ///"yyyy-MM-ddTHH:mm",
    ///"yyyy-MM-ddTHH:mm:ss",
    ///"yyyy-MM-ddTHH",
    ///"yyyy-MM-dd",
    ///"yyyy-MM-ddTHH:mm:ss.fffZ",
    ///"yyyy-MM-ddTHH:mm:ssZ",
    ///"yyyy-MM-ddTHH:mm:ss"
    /// </summary>
    public static string[] ReadDateFormats { get ; } = [
        "yyyy-MM-ddTHH:mm",
        "yyyy-MM-ddTHH:mm:ss",
        "yyyy-MM-ddTHH",
        "yyyy-MM-dd",
        "yyyy-MM-ddTHH:mm:ss.fffZ",
        "yyyy-MM-ddTHH:mm:ssZ",
        "yyyy-MM-ddTHH:mm:ss"
    ];
   
}
