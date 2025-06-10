using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorPattern.interfaces;

namespace VisitorPattern.models
{
    internal class SizeCalculatorVisitor : IVisitor
    {
        private int totalSize = 0;

        public void Visit(File file)
        {
            totalSize += file.Size;
        }

        public void Visit(Folder folder)
        {
            foreach (IFileSystemItem item in folder.items)
            {
                item.Accept(this);
            }
        }

        public int getTotalSize()
        {
            return totalSize;
        }
    }
}
