using CodeWalker.GameFiles;
using SkylineVVehicleTuning.Classes;

namespace SkylineVVehicleTuning.Functions
{
    public class CarVariation
    {
        private const string FileName = "carvariations.meta";

        public static List<VehicleModel> Load(string path)
        {
            // Global
            List<VehicleModel> datas = new();

            // Datei nicht gefunden
            if (!File.Exists($@"{path}\{FileName}")) return datas;

            // Lade Datei
            using StreamReader streamCarols = new($@"{path}\{FileName}");

            var bytes = default(byte[]);
            using (MemoryStream memstream = new())
            {
                streamCarols.BaseStream.CopyTo(memstream);
                bytes = memstream.ToArray();
            }

            // Extrahiere
            CarVariationsFile carVariationsFile = RpfFile.GetResourceFile<CarVariationsFile>(ResourceBuilder.Compress(bytes));

            // Gehe Daten durch
            foreach (CVehicleModelInfoVariation_418053801 variationData in carVariationsFile.VehicleModelInfo.variationData)
            {
                // Füge zu Liste hinzu
                datas.AddRange(variationData.kits.Select(x => new VehicleModel(variationData.modelName, $"{x}")));
            }

            // Rückgabe
            return datas;
        }
    }
}
