using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmissionsLibrary;

namespace EmissionsInput
{
    public static class Helper
    {
        public static string ConnectionStringValue(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public static List<Parameter> GenerateParameters(string sensorUuid)
        {
            var parameters = new List<Parameter>();

            parameters.Add(new Parameter() { sensorUuid = sensorUuid, code = "H2SkgPerHour", type = "float", unit = "kgPH" });
            parameters.Add(new Parameter() { sensorUuid = sensorUuid, code = "SO2kgPerHour", type = "float", unit = "kgPH" });
            parameters.Add(new Parameter() { sensorUuid = sensorUuid, code = "SuspendedParticulateskgPerHour", type = "float", unit = "kgPH" });
            parameters.Add(new Parameter() { sensorUuid = sensorUuid, code = "NOxkgPerHour", type = "float", unit = "kgPH" });
            parameters.Add(new Parameter() { sensorUuid = sensorUuid, code = "COxFuelkgPerHour", type = "float", unit = "kgPH" });
            parameters.Add(new Parameter() { sensorUuid = sensorUuid, code = "COxkgPerHour", type = "float", unit = "kgPH" });
            parameters.Add(new Parameter() { sensorUuid = sensorUuid, code = "HFkgPerHour", type = "float", unit = "kgPH" });
            parameters.Add(new Parameter() { sensorUuid = sensorUuid, code = "HClkgPerHour", type = "float", unit = "kgPH" });
            parameters.Add(new Parameter() { sensorUuid = sensorUuid, code = "NH3kgPerHour", type = "float", unit = "kgPH" });
            parameters.Add(new Parameter() { sensorUuid = sensorUuid, code = "ElectronicSealState", type = "string", unit = "State" });

            return parameters;
        }
    }
}
