using System;
using System.Globalization;
using System.IO;
using Core.SqlScripting.Common.Syntax.Insert;
using Core.SqlScripting.SqlServer.Syntax;
using Core.Text.Formatter;

namespace Core.SqlScripting.SqlServer.Writer
{
    internal class ColumnAssignmentValueFormatter: ITextFormatter<IColumnAssignment>
    {
        
        public void Write(IColumnAssignment value, TextWriter writer)
        {
            if (value is ColumnAssignment<int> intAssignment)
                writer.Write(string.Format(CultureInfo.InvariantCulture, "{0:D}", intAssignment.Value));
            else if (value is ColumnAssignment<long> longAssignment)
                writer.Write(string.Format(CultureInfo.InvariantCulture, "{0:D}", longAssignment.Value));
            else if (value is ColumnAssignment<short> shortAssignment)
                writer.Write(string.Format(CultureInfo.InvariantCulture, "{0:D}", shortAssignment.Value));
            else if (value is ColumnAssignment<byte> byteAssignment)
                writer.Write(string.Format(CultureInfo.InvariantCulture, "{0:D}", byteAssignment.Value));
            else if (value is ColumnAssignment<float> floatAssignment)
                writer.Write(string.Format(CultureInfo.InvariantCulture, "{0:F}", floatAssignment.Value));
            else if (value is ColumnAssignment<double> doubleAssignment)
                writer.Write(string.Format(CultureInfo.InvariantCulture, "{0:F}", doubleAssignment.Value));
            else if (value is ColumnAssignment<string> stringAssignment)
            {
                var escapedString = stringAssignment.Value.Replace("'", "''");
                writer.Write($"'{escapedString}'");
            }
            else if (value is ColumnAssignment<bool> boolAssignment)
                writer.Write(string.Format(CultureInfo.InvariantCulture, "{0:D}", boolAssignment.Value ? "1": "0"));
            else if (value is ColumnAssignment<DateTime> dateTimeAssignment)
                writer.Write(string.Format(CultureInfo.InvariantCulture, "'{0:yyyy-MM-dd HH:mm:ss.fffffff}'", dateTimeAssignment.Value));
            else 
                throw new NotImplementedException($"detected unexpected column assignment type: {value.GetType().FullName}");
        }
    }
}
