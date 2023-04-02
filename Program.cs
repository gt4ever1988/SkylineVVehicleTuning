using CodeWalker.GameFiles;
using SkylineVVehicleTuning.Classes;
using SkylineVVehicleTuning.Functions;

namespace SkylineVVehicleTuning
{
    internal class Program
    {
        private const string FileName = "vehicleMods.json";

        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                // Logging
                Console.WriteLine($"{FileName} not created: No 'stream'-Path passed as a parameter!");
            }
            else
            {
                // Beginne Generierung
                Start(args[0]);
            }
        }

        public static void Start(string path)
        {
            // Lade Grunddaten
            List<VehicleModel> models = CarVariation.Load(path);
            List<Gxt2Entry> labels = Label.Load(path);
            List<CVehicleKit> kits = Carcol.Load(path);

            // Lade JSON-Rohdaten
            string dataRaw = VehicleMod.Load(models, labels, kits);

            // Erstelle Datei
            if (dataRaw.Length >= 1)
            {
                // Erzeuge Daten
                File.WriteAllText(@$"{path}\{FileName}", $"[{dataRaw[0..^1]}]");

                // Logging
                Console.WriteLine($"{FileName} created:\n- {string.Join("\n- ", models.Select(x => x.VehicleName))}");
            }
            else
            {
                // Logging
                Console.WriteLine($"{FileName} not created: No tuning parts found!");
            }
        }
    }
}