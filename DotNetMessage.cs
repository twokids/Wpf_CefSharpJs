using System;
using System.Collections.Generic;

namespace CefSharpJs
{

    public class DotNetMessage
    {
        MainWindow _mainWindow;
        private static List<Animal> animals = new List<Animal>();
        public DotNetMessage(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }
        public string showwindow(string message)
        {
            return "你好，" + message;
        }

        public List<Animal> getanimals()
        {
            return animals;
        }

        public List<Animal> addanimal(string json)
        {
            animals.Add(new Animal() { Name = json });
            return animals;
        }
    }

    public class Animal
    {
        public string Name { get; set; }

        public DateTime Birthday { get; set; }
    }
}
