using System.IO;
using Core.SqlScripting.Common;

namespace Core.SqlScripting.SqlServer.Writer.Helper
{
    internal class OnOffFormatter: ITextFormatter<bool>
    {
        public void Write(bool value, TextWriter writer)
        {
            var onOffString = value ? "ON" : "OFF";
            writer.Write(onOffString);
        }
    }
}
