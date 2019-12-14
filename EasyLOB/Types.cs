namespace EasyLOB
{
    #region Types Data

    /// <summary>
    /// Z Database Loggers.
    /// </summary>
    public enum ZDatabaseLogger
    {
        None,
        File,
        NLog
    };

    /// <summary>
    /// Z Database Management Systems.
    /// </summary>
    public enum ZDBMS
    {
        Unknown,
        Firebird,
        MongoDB, // NoSQL
        MySQL,
        OData,
        Oracle,
        PostgreSQL,
        RavenDB, // NoSQL
        Redis, // NoSQL
        SQLite,
        SQLServer
    };

    #endregion Types Data

    #region Types File

    /// <summary>
    /// Z File Types.
    /// </summary>
    public enum ZFileTypes
    {
        // Unknown
        ftUnknown = 0,

        // Document
        ftPDF = 11,

        ftDOC = 12,
        ftDOCX = 13,
        ftTXT = 14,
        ftXLS = 15,
        ftXLSX = 16,

        // Image
        ftJPG = 21,

        ftPNG = 22,

        // Audio
        ftMP3 = 31,

        // Video
        ftAVI = 41,
        ftMOV = 42,
        ftMP4 = 43,
        ftMPEG = 44,
        ftWMV = 45,

        // Mail
        ftMSG = 51
    };

    #endregion Types File

    #region Types Security

    /// <summary>
    /// Z Operations.
    /// </summary>
    public enum ZOperations
    {
        Index,
        Search,
        Create,
        Read,
        Update,
        Delete,
        Export,
        Execute,
        None
    };

    #endregion Types Security
}