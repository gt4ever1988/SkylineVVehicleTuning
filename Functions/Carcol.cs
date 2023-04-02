using CodeWalker.GameFiles;

namespace SkylineVVehicleTuning.Functions
{
    public class Carcol
    {
        private const string FileName = "carcols.meta";

        public static List<CVehicleKit> Load(string path)
        {
            // Global
            List<CVehicleKit> datas = new();

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
            CarColsFile carColsFile = RpfFile.GetResourceFile<CarColsFile>(ResourceBuilder.Compress(bytes));

            if (carColsFile == null || carColsFile.VehicleModelInfo == null || carColsFile.VehicleModelInfo.Kits == null) return datas;

            // Rückgabe
            return carColsFile.VehicleModelInfo.Kits.ToList();
        }
    }
}