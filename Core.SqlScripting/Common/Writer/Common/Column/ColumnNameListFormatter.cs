using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Core.Extensions.CollectionRelated;
using Core.Extensions.TextRelated;
using Core.SqlScripting.Common.Syntax.Column;
using Core.SqlScripting.Common.Syntax.Update;
using Core.Text.Formatter;

namespace Core.SqlScripting.Common.Writer.Common.Column
{
    internal class ColumnNameListFormatter : ITextFormatter<ColumnNameList>
    {
        private readonly ColumnNameFormatter        _columnNameFormatter;
        private readonly SeparatorFormatter<string> _separatorFormatter;

        public ColumnNameListFormatter(ColumnNameFormatter columnNameFormatter, SeparatorFormatter<string> separatorFormatter)
        {
            _columnNameFormatter     = columnNameFormatter;
            _separatorFormatter = separatorFormatter;
        }

        public void Write(ColumnNameList value, TextWriter writer)
        {
            writer.Write("( ");
            _separatorFormatter.Write(value.NameList.Select(i => _columnNameFormatter.WriteToString(i)), writer);
            writer.Write(" )");
        }
    }
}
