using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core.SqlScripting.Common.Syntax.CreateTable;
using Core.SqlScripting.Common.Syntax.Datatypes;
using Core.SqlScripting.Common.Writer.Common;

namespace Core.SqlScripting.SqlServer.Writer
{
    internal class SqlServerTypeFormatter: ISqlTypeFormatter
    {
        public void Write(IColumnType value, TextWriter writer)
        {
            if (value is SqlIntegerType intType)
            {
                switch (intType.StorageSize)
                {
                    case SqlIntegerStorageSize.Int8:
                        writer.Write("TINYINT");
                        break;
                    case SqlIntegerStorageSize.Default:
                        writer.Write("INT");
                        break;
                    case SqlIntegerStorageSize.Int16:
                        writer.Write("SMALLINT");
                        break;
                    case SqlIntegerStorageSize.Int32:
                        writer.Write("INT");
                        break;
                    case SqlIntegerStorageSize.Int64:
                        writer.Write("BIGINT");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else if (value is SqlFloatType floatType)
            {
                switch (floatType.Precision)
                {
                    case SqlFloatingPointPrecision.Default:
                        writer.Write("FLOAT");
                        break;
                    case SqlFloatingPointPrecision.Float:
                        // Single
                        writer.Write("REAL");
                        break;
                    case SqlFloatingPointPrecision.Double:
                        writer.Write("FLOAT");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else if (value is SqlBooleanType)
                writer.Write("BIT");
            else if (value is SqlStringType stringType)
                switch (stringType.LengthBehavior)
                {
                    case SqlStringLengthBehavior.Varying:
                        writer.Write($"NVARCHAR({stringType.Length})");
                        break;
                    case SqlStringLengthBehavior.Fixed:
                        writer.Write($"CHAR({stringType.Length})");
                        break;
                    case SqlStringLengthBehavior.Unlimited:
                        writer.Write("NVARCHAR(MAX)");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            else if (value is SqlDateTimeType)
                writer.Write("DATETIME2");
            else if (value is SqlDecimalType decimalType)
                writer.Write($"DECIMAL({decimalType.DigitsBeforeDecimalPoint}, {decimalType.DigitsAfterDecimalPoint})");
            else if (value is SqlBlobType)
                writer.Write("VARBINARY");
            else
                throw new ArgumentException($"Unsupported type error: {value.GetType().FullName}", nameof(value));
        }
    }
}
