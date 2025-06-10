using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern.interfaces
{
    internal interface IFileSystemItem
    {
        void Accept(IVisitor visitor);
    }
}
