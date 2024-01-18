using Core.SqlScripting.Common.Syntax.Column;

namespace Core.SqlScripting.Common.Syntax.Update
{
    /// <summary>
    /// Assignment that is SET by the Update Statement
    /// </summary>
    public class UpdateAssignment<T> : IUpdateAssignment
    {
        public IColumnNameOrColumnNameList? ColumnOrColumnNameList { get; set; }
        public T?                           Value                  { get; set; }
    }

    public interface IUpdateAssignment
    {
        IColumnNameOrColumnNameList? ColumnOrColumnNameList { get; set; }
    }
}