using System.IO;

namespace Core.SqlScripting.Common
{
    public interface ITextFormatter<in T>
    {
        void Write(T value, TextWriter writer);
    }
}