using ObservablePattern.models;

namespace ObservablePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var thermometer = new Thermometer();
            thermometer.AddObserver(new Display("A"));
            thermometer.AddObserver(new Display("B"));

            thermometer.SetTemperature(25.0);
        }
    }
}
