using System.Collections.Generic;
using System.IO;
using Selkie.Windsor;

namespace Evaluation.Importers.CSV
{
    // todo testing
    [ProjectComponent(Lifestyle.Transient)]
    public class MinesightFile : IFile
    {
        public IEnumerable <string> ReadLines(string filename)
        {
            return File.ReadLines(filename);
        }
    }
}