using VisitorPattern.interfaces;
using VisitorPattern.models;

namespace VisitorPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var file1 = new models.File(120);
            var file2 = new models.File(80);

            var folder = new Folder("docs", new List<IFileSystemItem> { file1, file2 });

            var visitor = new SizeCalculatorVisitor();
            folder.Accept(visitor);

            Console.WriteLine($"Total size: {visitor.TotalSize}");

        }
    }
}
