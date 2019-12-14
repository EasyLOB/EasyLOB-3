using EasyLOB.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace EasyLOB.Data
{
    /// <summary>
    /// Data Helper.
    /// </summary>
    public static partial class DataHelper
    {
        #region Properties

        /// <summary>
        /// Profiles.
        /// </summary>
        public static Dictionary<Type, IZProfile> Profiles { get; }

        #endregion Properties

        #region Methods

        static DataHelper()
        {
            Profiles = new Dictionary<Type, IZProfile>();
        }

        /// <summary>
        /// Try validate.
        /// </summary>
        /// <param name="object"></param>
        /// <param name="results"></param>
        /// <returns></returns>
        public static bool TryValidate(object @object, ICollection<ValidationResult> results)
        {
            var context = new ValidationContext(@object, serviceProvider: null, items: null);

            return Validator.TryValidateObject(@object, context, results, validateAllProperties: true);
        }

        #endregion Methods

        #region Methods IdTo...

        /// <summary>
        /// Id to byte.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static byte IdToByte(object value)
        {
            if (value is int)
            {
                return (byte)value;
            }
            else if (value is Decimal)
            {
                return Decimal.ToByte((decimal)value);
            }
            else if (value is int)
            {
                return (byte)value;
            }
            else if (value is long)
            {
                return (byte)value;
            }
            else if (value is short)
            {
                return (byte)value;
            }
            else
            {
                return LibraryDefaults.Default_Byte;
            }
        }

        /// <summary>
        /// Id to byte[] (Binary).
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static byte[] IdToBinary(object value)
        {
            return (byte[])value;
        }

        /// <summary>
        /// Id to DateTime.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static DateTime IdToDateTime(object value)
        {
            if (value is DateTime)
            {
                return (DateTime)value;
            }
            else
            {
                return LibraryDefaults.Default_DateTime;
            }
        }

        /// <summary>
        /// Id to Guid.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static Guid IdToGuid(object value)
        {
            if (value is Guid)
            {
                return (Guid)value;
            }
            else
            {
                return LibraryDefaults.Default_Guid;
            }
        }

        /// <summary>
        /// Id to Int16.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static short IdToInt16(object value)
        {
            if (value is Decimal)
            {
                return Decimal.ToInt16((decimal)value);
            }
            else if (value is int)
            {
                return (short)value;
            }
            else if (value is long)
            {
                return (short)value;
            }
            else if (value is short)
            {
                return (short)value;
            }
            else
            {
                return LibraryDefaults.Default_Int16;
            }
        }

        /// <summary>
        /// Id to Int32.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int IdToInt32(object value)
        {
            if (value is Decimal)
            {
                return Decimal.ToInt32((decimal)value);
            }
            else if (value is int)
            {
                return Convert.ToInt32(value);
            }
            else if (value is long)
            {
                return Convert.ToInt32(value);
            }
            else if (value is short)
            {
                return Convert.ToInt32(value);
            }
            else
            {
                return LibraryDefaults.Default_Int32;
            }
        }

        /// <summary>
        /// Id to Int64.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long IdToInt64(object value)
        {
            if (value is Decimal)
            {
                return Decimal.ToInt64((decimal)value);
            }
            else if (value is int)
            {
                return (long)value;
            }
            else if (value is long)
            {
                return (long)value;
            }
            else if (value is short)
            {
                return (long)value;
            }
            else
            {
                return LibraryDefaults.Default_Int64;
            }
        }

        /// <summary>
        /// Id to String.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string IdToString(object value)
        {
            if (value is string)
            {
                return (string)value;
            }
            else
            {
                return LibraryDefaults.Default_String;
            }
        }

        #endregion Methods IdTo...

        #region Methods Profile

        /// <summary>
        /// Get profile by type.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns></returns>
        public static IZProfile GetProfile(Type type)
        {
            IZProfile profile;

            if (Profiles.Keys.Contains(type))
            {
                profile = Profiles[type];
            }
            else
            {
                profile = (IZProfile)LibraryHelper.GetStaticPropertyValue(type, "Profile");
            }

            return profile;
        }

        /// <summary>
        /// Setup Data Profile for assembly.
        /// </summary>
        /// <param name="dataAssemblyName">Data assembly</param>
        public static void SetupDataProfile(string dataAssemblyName)
        {
            Assembly.Load(dataAssemblyName);
            Assembly dataAssembly = LibraryHelper.GetAssembly(dataAssemblyName);

            Type[] types = dataAssembly.GetTypes();
            foreach (Type typeDataModel in types)
            {
                if (typeDataModel.IsSubclassOf(typeof(ZDataBase)) && !typeDataModel.IsAbstract)
                {
                    IZProfile profile = SetDataProfile(typeDataModel);

                    LibraryHelper.InvokeMethod(typeDataModel, "OnSetupProfile", new object[] { profile });
                }
            }
        }

        /// <summary>
        /// Set Data Profile for type.
        /// </summary>
        /// <param name="typeDataModel">Type</param>
        /// <returns></returns>
        public static IZProfile SetDataProfile(Type typeDataModel)
        {
            IZProfile profile;
            if (!Profiles.Keys.Contains(typeDataModel))
            {
                profile = new ZProfile();
                profile.Name = typeDataModel.Name;

                Profiles.Add(typeDataModel, profile);
            }
            else
            {
                profile = Profiles[typeDataModel];
            }

            bool isIdentity = false;
            string lookup = "";

            PropertyInfo[] properties = typeDataModel.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo property in properties)
            {
                if (property.Name != "LookupText")
                {
                    // Associations - ZDataBase
                    bool isAssociation = false;
                    if (property.PropertyType.IsSubclassOf(typeof(ZDataBase)) && !property.PropertyType.IsAbstract)
                    {
                        isAssociation = true;
                        profile.Associations.Add(property.Name);
                    }

                    // Collections - IList<ZDataBase>
                    bool isCollection = false;
                    Type typeIList = IListType(property.PropertyType);
                    if (typeIList.IsSubclassOf(typeof(ZDataBase)) && !typeIList.IsAbstract)
                    {
                        isCollection = true;
                        profile.Collections.Add(property.Name, true);
                    }

                    if (!isAssociation && !isCollection)
                    {
                        IZProfileProperty profileProperty = profile.GetProfileProperty(property.Name);
                        if (profileProperty == null)
                        {
                            profileProperty = new ZProfileProperty();
                            profileProperty.Name = property.Name;

                            profile.Properties.Add(profileProperty);
                        }

                        //profile.IsRequiredData = LibraryHelper.IsNullable(property.PropertyType);
                        //if (Attribute.IsDefined(property, typeof(RequiredAttribute)))
                        //{
                        //    profileProperty.IsRequiredData = true;
                        //}
                        //else
                        //{
                        //    profileProperty.IsRequiredData = false;
                        //}

                        // ZKeyAttribute
                        ZKeyAttribute zKey = (ZKeyAttribute)property.GetCustomAttribute(typeof(ZKeyAttribute));
                        if (zKey != null)
                        {
                            profile.Keys.Add(property.Name);
                            profileProperty.IsKey = true;
                            profileProperty.IsIdentity = zKey.IsIdentity;
                            isIdentity = zKey.IsIdentity;
                        }
                        else
                        {
                            // 1st Property after Primary Key(s)
                            if (String.IsNullOrEmpty(lookup) &&
                                !property.Name.StartsWith("Id") &&
                                !property.Name.EndsWith("Id") &&
                                !property.Name.EndsWith("LookupText"))
                            {
                                lookup = property.Name;
                            }
                        }
                    }
                }
            }

            lookup = String.IsNullOrEmpty(lookup) ? profile.Keys[0] : lookup;

            profile.IsIdentity = isIdentity;
            profile.Lookup = lookup;
            profile.LINQOrderBy = lookup;
            string where = "";
            int parameter = 0;
            foreach (string key in profile.Keys)
            {
                where += String.IsNullOrEmpty(where) ? "" : " && ";
                where += key + " == @" + parameter++.ToString();
            }
            profile.LINQWhere = where;

            return profile;
        }

        /// <summary>
        /// Get IListType from type.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns></returns>
        private static Type IListType(Type type)
        {
            Type result = typeof(Object);

            foreach (Type interfaceType in type.GetInterfaces())
            {
                //if (interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == typeof(IList<>))
                if (interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == typeof(ICollection<>))
                {
                    if (type.GetGenericArguments().Count() > 0)
                    {
                        result = type.GetGenericArguments()[0];

                        break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Setup View Profile.
        /// </summary>
        /// <param name="dataAssemblyName">Data assembly</param>
        /// <param name="viewAssemblyName">View assembly</param>
        public static void SetupViewProfile(string dataAssemblyName, string viewAssemblyName)
        {
            Assembly.Load(dataAssemblyName);
            Assembly.Load(viewAssemblyName);
            Assembly dataAssembly = LibraryHelper.GetAssembly(dataAssemblyName);
            Assembly viewAssembly = LibraryHelper.GetAssembly(viewAssemblyName);

            Type[] types = dataAssembly.GetTypes();
            foreach (Type typeDataModel in types)
            {
                if (typeDataModel.IsSubclassOf(typeof(ZDataBase)) && !typeDataModel.IsAbstract)
                {
                    string viewModel = typeDataModel.FullName + "ViewModel";
                    Type typeViewModel = viewAssembly.GetType(viewModel);

                    IZProfile profile = SetViewProfile(typeViewModel, typeDataModel);

                    LibraryHelper.InvokeMethod(typeViewModel, "OnSetupProfile", new object[] { profile });
                }
            }
        }

        /// <summary>
        /// Set View Profile for types.
        /// </summary>
        /// <param name="typeViewModel">View type</param>
        /// <param name="typeDataModel">Data type</param>
        /// <returns></returns>
        public static IZProfile SetViewProfile(Type typeViewModel, Type typeDataModel)
        {
            IZProfile profile;
            if (!Profiles.Keys.Contains(typeDataModel))
            {
                profile = new ZProfile();
                profile.Name = typeDataModel.Name;

                Profiles.Add(typeDataModel, profile);
            }
            else
            {
                profile = Profiles[typeDataModel];
            }

            //int gridVisibles = 0;

            PropertyInfo[] properties = typeViewModel.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo property in properties)
            {
                if (property.Name != "LookupText")
                {
                    IZProfileProperty profileProperty = profile.GetProfileProperty(property.Name);
                    if (profileProperty == null)
                    {
                        profileProperty = new ZProfileProperty();
                        profileProperty.Name = property.Name;

                        profile.Properties.Add(profileProperty);
                    }

                    if (Attribute.IsDefined(property, typeof(RequiredAttribute)))
                    {
                        profileProperty.IsRequiredView = true;
                    }
                    else
                    {
                        profileProperty.IsRequiredView = false;
                    }

                    /*
                     * IsBoolean          5
                     * IsDateTime        10
                     * IsFloat           10
                     * IsInteger          5
                     * IsString
                     *   GridWidth
                     *     <= 5           5
                     *     <= 10         10
                     *     <= 15         15
                     *     ...           20
                     *   LookupText      20
                     * 
                     * IsBoolean         50     col-md-1
                     * IsDateTime        50     col-md-2
                     * IsFloat           50     col-md-1
                     * IsInteger         50     col-md-1
                     * IsString
                     *   GridWidth
                     *     <= 5          50
                     *     <= 10        100
                     *     <= 15        150
                     *     ...          200
                     *   EditCSS
                     *     <= 10                col-md-1
                     *     <= 20                col-md-2
                     *     <= 30                col-md-3
                     *     <= 50                col-md-4
                     *     ...                  col-md-4
                     *   LookupText     200     col-md-4
                     */

                    //bool isGridVisible = false;
                    bool isGridSearch = false;
                    int gridWidth = 5; // 50
                    string editCSS = "col-md-2";

                    if (LibraryHelper.IsBoolean(property.PropertyType))
                    {
                        //isGridVisible = true;
                        gridWidth = 5; // 50;
                        editCSS = "col-md-1";
                    }
                    else if (LibraryHelper.IsDateTime(property.PropertyType))
                    {
                        //isGridVisible = true;
                        gridWidth = 10; // 100;
                        editCSS = "col-md-2";
                    }
                    else if (LibraryHelper.IsFloat(property.PropertyType))
                    {
                        //isGridVisible = true;
                        gridWidth = 5; // 50;
                        editCSS = "col-md-1";
                    }
                    else if (LibraryHelper.IsInteger(property.PropertyType))
                    {
                        //isGridVisible = true;
                        gridWidth = 5; // 50;
                        editCSS = "col-md-1";
                    }
                    else if (LibraryHelper.IsString(property.PropertyType))
                    {
                        //isGridVisible = true;
                        isGridSearch = true;

                        int length = 0;
                        StringLengthAttribute stringLength = (StringLengthAttribute)property.GetCustomAttribute(typeof(StringLengthAttribute));
                        if (stringLength != null)
                        {
                            length = stringLength.MaximumLength;
                        }

                        if (length <= 5)
                        {
                            gridWidth = 5; // 50;
                        }
                        else if (length <= 10)
                        {
                            gridWidth = 10; // 100;
                        }
                        else if (length <= 15)
                        {
                            gridWidth = 15; // 150;
                        }
                        else
                        {
                            gridWidth = 20; // 200;
                        }

                        if (length <= 10) // 9
                        {
                            editCSS = "col-md-1";
                        }
                        else if (length <= 20) // 22
                        {
                            editCSS = "col-md-2";
                        }
                        else if (length <= 30) // 35
                        {
                            editCSS = "col-md-3";
                        }
                        else if (length <= 50) // 48
                        {
                            editCSS = "col-md-4";
                        }
                        else
                        {
                            editCSS = "col-md-4";
                        }

                        if (property.Name.EndsWith("LookupText"))
                        {
                            gridWidth = 20; // 200;
                            editCSS = "col-md-4";
                        }
                    }

                    // Foreign Key
                    //if (property.Name != "Id" && (property.Name.StartsWith("Id") || property.Name.EndsWith("Id")))
                    //{
                    //    isGridVisible = false;
                    //}

                    // Primary Key
                    //if (profileProperty.IsKey)
                    //{
                    //    if (properties.Count() == profile.Keys.Count())
                    //    {
                    //        isGridVisible = true;
                    //    }
                    //    else
                    //    {
                    //        isGridVisible = false;
                    //    }

                    //    profileProperty.IsGridVisible = isGridVisible;
                    //}
                    //else
                    //{
                    //    if (isGridVisible)
                    //    {
                    //        if (!property.Name.EndsWith("LookupText"))
                    //        {
                    //            gridVisibles++;
                    //            if (gridVisibles > 1)
                    //            {
                    //                isGridVisible = false;
                    //            }
                    //        }

                    //        profileProperty.IsGridVisible = isGridVisible;
                    //    }
                    //}

                    profileProperty.IsGridVisible =
                        property.Name == profile.Lookup || (profileProperty.IsKey && !profileProperty.IsIdentity);
                    profileProperty.IsGridSearch = isGridSearch;
                    profileProperty.GridWidth = gridWidth;
                    profileProperty.IsEditVisible = true;
                    profileProperty.IsEditReadOnly = false;
                    profileProperty.EditCSS = editCSS;
                }
            }

            return profile;
        }

        #endregion Methods Profile
    }
}