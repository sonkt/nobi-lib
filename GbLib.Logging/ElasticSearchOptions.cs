namespace GbLib.Logging
{
    public class ElasticSearchOptions
    {
        #region Constructors

        public ElasticSearchOptions()
        {
            ElasticsearchEnvironments = "Development,Production";
            ApplicationName = "unknownapp";
        }

        #endregion Constructors

        #region Properties

        public string ApplicationName { get; set; }

        public string ElasticsearchEnvironments { get; set; }

        public string ElasticsearchPassword { get; set; }

        public string ElasticsearchUrl { get; set; }

        public string ElasticsearchUser { get; set; }

        public bool Enabled { get; set; }

        #endregion Properties
    }
}