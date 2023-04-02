using CodeWalker.GameFiles;

namespace SkylineVVehicleTuning.Functions
{
    public class Label
    {
        private const string FileName = "global.gxt2";

        public static List<Gxt2Entry> Load(string path)
        {
            // Global
            List<Gxt2Entry> datas = new();

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

            // Rückgabe
            return RpfFile.GetResourceFile<Gxt2File>(ResourceBuilder.Compress(bytes)).TextEntries.ToList();
        }
    }
}
