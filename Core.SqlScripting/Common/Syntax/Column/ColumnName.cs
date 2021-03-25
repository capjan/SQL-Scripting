namespace Core.SqlScripting.Common.Syntax.Column
{
    /// <summary>
    /// Syntax Element for a Column Name
    /// </summary>
    public class ColumnName: IColumnNameOrColumnNameList
    {
        public string Name { get; }

        public ColumnName(string name)
        {
            Name = name;
        }
    }
}
