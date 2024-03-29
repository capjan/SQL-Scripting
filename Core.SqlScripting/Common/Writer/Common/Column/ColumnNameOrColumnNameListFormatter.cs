﻿using System;
using System.IO;
using Core.SqlScripting.Common.Syntax.Column;

namespace Core.SqlScripting.Common.Writer.Common.Column
{
    internal class ColumnNameOrColumnNameListFormatter: ITextFormatter<IColumnNameOrColumnNameList>
    {
        private readonly ColumnNameFormatter     _columnNameFormatter;
        private readonly ColumnNameListFormatter _columnNameListFormatter;
        public ColumnNameOrColumnNameListFormatter(ColumnNameFormatter columnNameFormatter, ColumnNameListFormatter columnNameListFormatter)
        {
            _columnNameFormatter          = columnNameFormatter;
            _columnNameListFormatter = columnNameListFormatter;
        }

        public void Write(IColumnNameOrColumnNameList? value, TextWriter writer)
        {
            if (value is ColumnName columnName)
                _columnNameFormatter.Write(columnName, writer);
            else if (value is ColumnNameList columnNameList)
                _columnNameListFormatter.Write(columnNameList, writer);
            else
                throw new ArgumentException("unsupported", nameof(value));
        }
    }
}
