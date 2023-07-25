namespace GbLib.Base.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        #region Constructors

        public ColumnAttribute(string columnName)
        {
            Name = columnName;
        }

        #endregion Constructors

        #region Properties

        public string Name { get; private set; }

        #endregion Properties
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class DisplayNameAttribute : Attribute
    {
        #region Constructors

        public DisplayNameAttribute(string displayName, int order)
        {
            DisplayName = displayName;
            Order = order;
        }

        #endregion Constructors

        #region Properties

        public string DisplayName { get; private set; }
        public int Order { get; private set; }

        #endregion Properties
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class EditableAttribute : Attribute
    {
        #region Constructors

        public EditableAttribute(bool iseditable)
        {
            AllowEdit = iseditable;
        }

        #endregion Constructors

        #region Properties

        public bool AllowEdit { get; private set; }

        #endregion Properties
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreInsertAttribute : Attribute
    {
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreSelectAttribute : Attribute
    {
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreUpdateAttribute : Attribute
    {
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class KeyAttribute : Attribute
    {
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class NotMappedAttribute : Attribute
    {
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class ReadOnlyAttribute : Attribute
    {
        #region Constructors

        public ReadOnlyAttribute(bool isReadOnly)
        {
            IsReadOnly = isReadOnly;
        }

        #endregion Constructors

        #region Properties

        public bool IsReadOnly { get; private set; }

        #endregion Properties
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredAttribute : Attribute
    {
    }
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute : Attribute
    {
        #region Constructors

        public TableAttribute(string tableName)
        {
            Name = tableName;
        }

        #endregion Constructors

        #region Properties

        public string Name { get; private set; }

        public string Schema { get; set; }

        #endregion Properties
    }
}
