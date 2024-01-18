using System.IO;
using Core.SqlScripting.Common;
using Core.SqlScripting.SQLite.Syntax.Enums;

namespace Core.SqlScripting.SQLite.Writer.Statements.CreateTable.Constraints.Table
{
    /// <summary>
    /// Formats the Index Key. Used in CREATE TABLE constraints.
    /// </summary>
    internal class IndexKeyTypeFormatter: ITextFormatter<KeyType>
    {
        public void Write(KeyType value, TextWriter writer)
        {
            switch (value)
            {
                case KeyType.PrimaryKey:
                    writer.Write("PRIMARY KEY");
                    break;
                case KeyType.Unique:
                    writer.Write("UNIQUE");
                    break;
            }
        }
    }
}