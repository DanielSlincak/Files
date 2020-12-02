using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files.ClassLibrary.Controllers
{
    internal interface IJson
    {
        string JsonFileName { get; }

        void Init();

        void SaveModel();
    }
}