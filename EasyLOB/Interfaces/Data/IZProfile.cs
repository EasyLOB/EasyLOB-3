using System.Collections.Generic;

namespace EasyLOB
{
    /// <summary>
    /// IZProfile.
    /// </summary>
    public interface IZProfile
    {
        #region Properties

        /// <summary>
        /// Name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Is identity ?
        /// </summary>
        bool IsIdentity { get; set; }

        /// <summary>
        /// Key properties
        /// </summary>
        List<string> Keys { get; set; }

        /// <summary>
        /// Lookup property
        /// </summary>
        string Lookup { get; set; }

        /// <summary>
        /// Order by clause
        /// </summary>
        string LINQOrderBy { get; set; }

        /// <summary>
        /// Where clause
        /// </summary>
        string LINQWhere { get; set; }

        //bool IsLog { get; set; }

        //bool IsSearch { get; set; }

        //int RecordsByLookup { get; set; }

        //int RecordsByPage { get; set; }

        //int RecordsBySearch { get; set; }
        
        /// <summary>
        /// Associations
        /// </summary>
        List<string> Associations { get; }

        /// <summary>
        /// Collections
        /// </summary>
        Dictionary<string, bool> Collections { get; }

        /// <summary>
        /// Properties
        /// </summary>
        List<IZProfileProperty> Properties { get; }

        #endregion Properties

        #region Properties Helper Edit

        /// <summary>
        /// Edit collections
        /// </summary>
        List<string> EditCollections { get; }

        /// <summary>
        /// Edit hidden collections
        /// </summary>
        List<string> EditHiddenCollections { get; }

        /// <summary>
        /// Edit hidden properties
        /// </summary>
        List<string> EditHiddenProperties { get; }

        /// <summary>
        /// Edit read-only properties
        /// </summary>
        List<string> EditReadOnlyProperties { get; }

        #endregion Properties Helper Edit

        #region Properties Helper Grid

        /// <summary>
        /// Grid properties
        /// </summary>
        List<string> GridProperties { get; }

        /// <summary>
        /// Grid search properties
        /// </summary>
        List<string> GridSearchProperties { get; }

        #endregion Properties Helper Grid

        #region Methods

        /// <summary>
        /// Get profile property
        /// </summary>
        /// <param name="name">Property name</param>
        /// <returns></returns>
        IZProfileProperty GetProfileProperty(string name);
        /*
        /// <summary>
        /// Is required data model ?
        /// </summary>
        /// <param name="property">Property name</param>
        /// <returns></returns>
        bool IsRequiredData(string property);
        */
        /// <summary>
        /// Is required view model ?
        /// </summary>
        /// <param name="property">Property name</param>
        /// <returns></returns>
        bool IsRequiredView(string property);

        /// <summary>
        /// Set edit read-only
        /// </summary>
        /// <param name="value">Value</param>
        void SetEditReadOnly(bool value);

        /// <summary>
        /// Set edit visible
        /// </summary>
        /// <param name="value">Value</param>
        void SetEditVisible(bool value);

        /// <summary>
        /// Set grid search
        /// </summary>
        /// <param name="value">Value</param>
        void SetGridSearch(bool value);

        /// <summary>
        /// Set grid visible
        /// </summary>
        /// <param name="value">Value</param>
        void SetGridVisible(bool value);

        /// <summary>
        /// Set profile property
        /// </summary>
        /// <param name="name">Property name</param>
        /// <param name="isGridVisible">Is grid visible ?</param>
        /// <param name="isGridSearch">Is grid search ?</param>
        /// <param name="gridWidth">Grid width</param>
        /// <param name="isEditVisible">Is edit visible ?</param>
        /// <param name="isEditReadOnly">Is edit read-only ?</param>
        /// <param name="editCSS">Edit CSS</param>
        void SetProfileProperty(string name,
            bool? isGridVisible = null,
            bool? isGridSearch = null,
            int? gridWidth = null,
            bool? isEditVisible = null,
            bool? isEditReadOnly = null,
            string editCSS = null);

        #endregion Methods

        #region Methods Helper Edit

        /// <summary>
        /// Edit CSS for property
        /// </summary>
        /// <param name="property">Property name</param>
        /// <returns></returns>
        string EditCSSFor(string property);

        /// <summary>
        /// Edit CSS Editor
        /// </summary>
        /// <param name="required">Required ?</param>
        /// <returns></returns>
        string EditCSSEditor(bool required);

        /// <summary>
        /// Edit CSS Editor for property
        /// </summary>
        /// <param name="property">Property name</param>
        /// <returns></returns>
        string EditCSSEditorFor(string property);

        /// <summary>
        /// Edit CSS Editor Date
        /// </summary>
        /// <param name="required">Required ?</param>
        /// <returns></returns>
        string EditCSSEditorDate(bool required);

        /// <summary>
        /// Edit CSS Editor Date for property
        /// </summary>
        /// <param name="property">Property name</param>
        /// <returns></returns>
        string EditCSSEditorDateFor(string property);

        /// <summary>
        /// Edit CSS Editor DateTime
        /// </summary>
        /// <param name="required">Required ?</param>
        /// <returns></returns>
        string EditCSSEditorDateTime(bool required);

        /// <summary>
        /// Edit CSS Editor DateTime for property
        /// </summary>
        /// <param name="property">Property name</param>
        /// <returns></returns>
        string EditCSSEditorDateTimeFor(string property);

        /// <summary>
        /// Edit CSS Label
        /// </summary>
        /// <param name="required">Required ?</param>
        /// <returns></returns>
        string EditCSSLabel(bool required);

        /// <summary>
        /// Edit CSS Label for property
        /// </summary>
        /// <param name="property">Property name</param>
        /// <returns></returns>
        string EditCSSLabelFor(string property);

        /// <summary>
        /// Edit CSS Lookup Editor
        /// </summary>
        /// <param name="required">Required ?</param>
        /// <returns></returns>
        string EditCSSLookupEditor(bool required);

        /// <summary>
        /// Is collection visible ?
        /// </summary>
        /// <param name="collectionName">Collection name</param>
        /// <returns></returns>
        bool IsCollectionVisibleFor(string collectionName);

        #endregion Methods Helper Edit

        #region Methods Helper Grid

        /// <summary>
        /// Is grid visible ?
        /// </summary>
        /// <param name="property">Property name</param>
        /// <returns></returns>
        bool IsGridVisibleFor(string property);

        /// <summary>
        /// Grid width
        /// </summary>
        /// <param name="property">Property name</param>
        /// <returns></returns>
        int GridWidthFor(string property);

        #endregion Methods Helper Grid
    }
}
 