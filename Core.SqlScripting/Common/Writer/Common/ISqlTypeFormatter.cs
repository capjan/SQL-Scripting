using System;
using System.Collections.Generic;
using System.Text;
using Core.SqlScripting.Common.Syntax.CreateTable;
using Core.Text.Formatter;

namespace Core.SqlScripting.Common.Writer.Common
{
    internal interface ISqlTypeFormatter: ITextFormatter<IColumnType>
    {
    }
}
