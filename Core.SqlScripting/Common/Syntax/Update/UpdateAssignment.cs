using Core.SqlScripting.Common.Syntax.Column;

namespace Core.SqlScripting.Common.Syntax.Update
{
    /// <summary>
    /// Assignment that is SET by the Update Statement
    /// </summary>
    public class UpdateAssignment
    {
        public IColumnNameOrColumnNameList ColumnOrColumnNameList { get; set; }
        public IExpression                 Expression             { get; set; }
    }
}