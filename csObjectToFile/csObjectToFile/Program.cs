using csObjectToFile.Storages;
using System;
using System.Threading.Tasks;

namespace csObjectToFile
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var myClass = new MyClass()
            {
                MyPropertyInt = 20,
                MyPropertyString = "Vulcan Lee",
                MyPropertyDateTime = DateTime.Now.AddDays(-3),
                MyPropertyDouble = 99.82,
                MyPropertyTimeSpan = new TimeSpan(15, 23, 58),
            };

            await StorageJSONService<MyClass>.WriteToDataFileAsync
                ("Data", nameof(myClass), myClass);
        }
    }
}
