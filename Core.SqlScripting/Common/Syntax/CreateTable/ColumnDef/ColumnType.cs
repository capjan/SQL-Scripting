using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;
using Core.SqlScripting.Common.Syntax.Datatypes;

namespace Core.SqlScripting.Common.Syntax.CreateTable
{



    public class SqlBooleanType : IColumnType
    {
    }

    /// <summary>
    /// Integer number with a given storage size
    /// </summary>
    public class SqlIntegerType: IColumnType
    {
        /// <summary>
        /// Number of Bytes used to store this value
        /// </summary>
        public SqlIntegerStorageSize StorageSize { get; }

        public SqlIntegerType(SqlIntegerStorageSize storageSize = SqlIntegerStorageSize.Default)
        {
            StorageSize = storageSize;
        }
    }

    /// <summary>
    /// A floating point number
    /// </summary>
    public class SqlFloatType : IColumnType
    {
        public SqlFloatType(SqlFloatingPointPrecision precision)
        {
            Precision = precision;
        }
        public SqlFloatingPointPrecision Precision { get; }
    }

    /// <summary>
    /// Possibility to store a point of time (date and time)
    /// </summary>
    public class SqlDateTimeType : IColumnType
    {

    }

    /// <summary>
    /// defines a SQL type for storing strings
    /// </summary>
    public class SqlStringType : IColumnType
    {
        public SqlStringType(SqlStringLengthBehavior lengthBehavior, uint length)
        {
            Length              = length;
            LengthBehavior = lengthBehavior;
        }

        public uint Length  { get; }
        public SqlStringLengthBehavior LengthBehavior { get; }
    }

    /// <summary>
    /// Defines the BLOB datatype. Typically used for binary data.
    /// </summary>
    public class SqlBlobType : IColumnType
    {

    }

    /// <summary>
    /// An arbitrary precision Number with a given amount of digits before and after the decimal point. Recommended to store monetary values.
    /// </summary>
    public class SqlDecimalType : IColumnType
    {
        public SqlDecimalType(int digitsBeforeDecimalPoint, int digitsAfterDecimalPoint)
        {
            DigitsBeforeDecimalPoint     = digitsBeforeDecimalPoint;
            DigitsAfterDecimalPoint = digitsAfterDecimalPoint;
        }

        public int DigitsBeforeDecimalPoint { get; }
        public int DigitsAfterDecimalPoint { get; }

    }

    public interface IColumnType
    {
    }
}
