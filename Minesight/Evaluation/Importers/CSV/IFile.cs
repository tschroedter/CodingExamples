using System.Collections.Generic;

namespace Evaluation.Importers.CSV
{
    public interface IFile
    {
        IEnumerable <string> ReadLines(string filename);
    }
}