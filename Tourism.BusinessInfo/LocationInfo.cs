


namespace Tourism.BusinessInfo
{
    /// <summary>
    /// Summary description for Location
    /// </summary>
    public class LocationInfo
    {
        #region Class Members

        private int _locationId;
        private string _locationUrl;
        private string _description;
        private string _locationName;


        //these properties can also declared as  public int LocationId { get; set; }
        public int LocationId
        {
            get { return _locationId; }
            set { _locationId = value; }
        }
        public string LocationUrl
        {
            get { return _locationUrl; }
            set { _locationUrl = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string LocationName
        {
            get { return _locationName; }
            set { _locationName = value; }
        }


        #endregion

    }
}
