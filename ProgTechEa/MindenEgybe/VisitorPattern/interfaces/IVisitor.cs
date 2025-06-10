using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorPattern.models;

namespace VisitorPattern.interfaces
{
    internal interface IVisitor
    {
        void Visit(models.File file);
        void Visit(Folder folder);
    }
}
