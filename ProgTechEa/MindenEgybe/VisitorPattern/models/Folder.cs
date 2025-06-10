using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorPattern.interfaces;

namespace VisitorPattern.models
{
    internal class Folder
    {
        public List<IFileSystemItem> Items;
    }
}
