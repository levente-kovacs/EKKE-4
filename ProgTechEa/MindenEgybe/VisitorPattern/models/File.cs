using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorPattern.interfaces;

namespace VisitorPattern.models
{
    internal class File : IFileSystemItem
    {
        public int Size;

        public File(int size)
        {
            Size = size;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
