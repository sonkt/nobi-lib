using FluentValidation.Results;

namespace GbLib.Base
{
    public abstract class Command<T> : Message<T> where T : class
    {
        #region Constructors

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        #endregion Constructors

        #region Properties

        public DateTime CreatedDate { get; set; }

        public Guid CreatedUser { get; set; } = Guid.Empty;

        public bool? IsDeleted { get; set; }

        public DateTime Timestamp { get; private set; }

        public DateTime? UpdatedDate { get; set; }

        public Guid? UpdatedUser { get; set; } = Guid.Empty;

        public string Description { get; set; }

        public ValidationResult ValidationResult { get; set; }

        #endregion Properties

        #region Methods

        public virtual Dictionary<string, List<string>> GetListModelErrors()
        {
            var listModelErrors = new Dictionary<string, List<string>>();
            foreach (var error in ValidationResult.Errors)
            {
                if (listModelErrors.ContainsKey(error.PropertyName))
                {
                    listModelErrors[error.PropertyName].Add(error.ErrorMessage);
                }
                else
                {
                    listModelErrors.Add(error.PropertyName, new List<string> { error.ErrorMessage });
                }
            }
            return listModelErrors;
        }

        public virtual List<string> GetListMessageModelErrors()
        {
            var listModelErrors = new List<string>();
            foreach (var error in ValidationResult.Errors)
            {
                if (!listModelErrors.Contains(error.ErrorMessage))
                {
                    listModelErrors.Add(error.ErrorMessage);
                }
            }
            return listModelErrors;
        }

        public abstract bool IsValid();

        #endregion Methods
    }
}