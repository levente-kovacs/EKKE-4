using ObservablePattern.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservablePattern.models
{
    internal class Display : IObserver
    {
        private string name;

        public Display(string name) => this.name = name;

        public void Update(double temperature)
        {
            Console.WriteLine($"{name} kijelző: új hőmérséklet = {temperature} °C");
        }
    }
}
