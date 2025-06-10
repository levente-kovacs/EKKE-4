using ObservablePattern.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservablePattern.models
{
    internal class Thermometer
    {
        private List<IObserver> observers = new();

        private double temperature;

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void SetTemperature(double newTemp)
        {
            temperature = newTemp;
            NotifyObservers();
        }

        private void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(temperature);
            }
        }
    }
}
