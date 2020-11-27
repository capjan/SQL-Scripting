using System.Collections.Generic;

namespace Core.SqlScripting.Common.Syntax.Column
{
    /// <summary>
    /// Syntax Element of a comma separated list of Column Names
    /// </summary>
    public class ColumnNameList: IColumnNameOrColumnNameList
    {
        public IList<ColumnName> NameList { get; set; } = new List<ColumnName>();
    }
}