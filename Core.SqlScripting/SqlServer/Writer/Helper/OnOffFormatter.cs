using System.IO;
using Core.Text.Formatter;

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
