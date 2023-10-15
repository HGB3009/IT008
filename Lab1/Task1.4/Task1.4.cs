using System;
using System.Threading;

class Thermometer
{
#pragma warning disable CS8618 
    public event Action<int> TemperatureChanged;
#pragma warning restore CS8618 

    private int temperature;

    public int Temperature
    {
        get { return temperature; }
        set
        {
            if (temperature != value)
            {
                temperature = value;
                TemperatureChanged?.Invoke(temperature);
            }
        }
    }

    public void SimulateTemperatureChange()
    {
        var random = new Random();
        while (true)
        {
            Thread.Sleep(1000);
            Temperature = random.Next(-100, 100);
        }
    }
}

class TemperatureDisplay
{
    public void SubscribeToThermometer(Thermometer thermometer)
    {
        thermometer.TemperatureChanged += OnTemperatureChanged;
    }

    private void OnTemperatureChanged(int newTemperature)
    {
        DateTime currentTime = DateTime.Now;
        string timestamp = currentTime.ToString("yyyy-MM-dd HH:mm:ss");
        Console.WriteLine($"Temperature changed at {timestamp} to {newTemperature}°C.");
    }
}

class Program
{
    static void Main()
    {
        Thermometer thermometer = new Thermometer();
        TemperatureDisplay temperatureDisplay = new TemperatureDisplay();

        temperatureDisplay.SubscribeToThermometer(thermometer);

        Thread simulatorThread = new Thread(thermometer.SimulateTemperatureChange);
        simulatorThread.Start();

        Console.WriteLine("Press Enter to exit.");
        Console.ReadLine();
    }
}