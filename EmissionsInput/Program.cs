using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmissionsLibrary;

namespace EmissionsInput
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Source.Get(Helper.ConnectionStringValue("EmissionsDb")).Count == 0)
            {
                SeedDb();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        // Заполняет базу данных начальными данными
        private static void SeedDb()
        {
            var dbConnectionString = Helper.ConnectionStringValue("emissionsDb");

            // Создать источники выбросов
            var sources = new List<Source>();

            for (int i = 0; i < 3; i++)
            {
                var newSource = new Source() { pniv = i };
                sources.Add(newSource);

                Source.Create(dbConnectionString, newSource);
            }

            // Создать датчики для каждого источника выбросов
            var sensors = new List<Sensor>();
            var states = new string[3] { "OK", "ERROR", "MAINTENANCE" };
            var random = new Random();

            sources.ForEach(delegate (Source source)
            {
                for (int i = 0; i < 4; i++)
                {
                    var newSensor = new Sensor() { sourceUuid = source.sourceUuid, state = states[random.Next(0, states.Length)] };
                    sensors.Add(newSensor);

                    Sensor.Create(dbConnectionString, newSensor);
                }
            });

            // Создать параметры для каждого датчика
            var parameters = new List<Parameter>();

            sensors.ForEach(delegate (Sensor sensor)
            {
                parameters.AddRange(Helper.GenerateParameters(sensor.sensorUuid));
            });

            parameters.ForEach(delegate (Parameter parameter)
            {
                Parameter.Create(dbConnectionString, parameter);
            });
        }
    }
}
