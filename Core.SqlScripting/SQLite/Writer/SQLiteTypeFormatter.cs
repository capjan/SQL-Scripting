using System;
using System.IO;
using Core.SqlScripting.Common.Syntax.CreateTable;
using Core.SqlScripting.Common.Writer.Common;

namespace Core.SqlScripting.SQLite.Writer
{
    /// <summary>
    /// SQLite Strict Type Formatter, that ist required for databases targeting Android Room
    /// </summary>
    internal class SQLiteTypeFormatter: ISqlTypeFormatter
    {
        private readonly string _dateTimeStorageType;

        public SQLiteTypeFormatter(string dateTimeStorageType = "NUMERIC")
        {
            _dateTimeStorageType = dateTimeStorageType;
        }

        public void Write(IColumnType value, TextWriter writer)
        {
            if (value is SqlIntegerType)
                writer.Write("INTEGER");
            else if (value is SqlFloatType)
                writer.Write("REAL");
            else if (value is SqlBooleanType)
                writer.Write("INTEGER");
            else if (value is SqlStringType)
                writer.Write("TEXT");
            else if (value is SqlDateTimeType)
                writer.Write(_dateTimeStorageType);
            else if (value is SqlDecimalType)
                writer.Write("NUMERIC");
            else if (value is SqlBlobType)
                writer.Write("BLOB");
            else
                throw new ArgumentException($"Unsupported type error: {value.GetType().FullName}", nameof(value));
        }
    }

   
}
