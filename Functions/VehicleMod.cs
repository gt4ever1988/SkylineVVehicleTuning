using CodeWalker.GameFiles;
using Newtonsoft.Json;
using SkylineVVehicleTuning.Classes;
using System.Data;
using System.Text;

namespace SkylineVVehicleTuning.Functions
{
    public class VehicleMod
    {
        public static string Load(List<VehicleModel> models, List<Gxt2Entry> labels, List<CVehicleKit> kits)
        {
            // Global
            string data = "";

            // Gehe Kit's durch
            foreach (CVehicleKit kit in kits)
            {
                // Lade Model
                VehicleModel? model = models.Find(x => x.VehicleKit == $"{kit.kitName}");

                if (model == null) continue;

                List<CVehicleModVisible> mods = kit.visibleMods != null ? kit.visibleMods.ToList() : new List<CVehicleModVisible>();

                List<string> jsonMods = new();

                // Gehe Mod's gruppiert anhand Type durch
                foreach (CVehicleModVisible mod in mods.GroupBy(x => x.type).Select(s => s.First()))
                {
                    // Erstelle Index
                    int index = 1;

                    // Gehe Mod's je Type durch
                    foreach (CVehicleModVisible modSingle in mods.Where(x => x.type == mod.type))
                    {
                        // Lade Übersetzung
                        Gxt2Entry? gxt2Entry = labels.Find(x => x.Hash == GetHash(modSingle.modShopLabel.ToLower()));

                        // Lade Übersetzung-String
                        string gtxName = gxt2Entry != null ? gxt2Entry.Text : modSingle.modShopLabel;

                        // Erstelle JSON-String
                        jsonMods.Add($"{{ " +
                            $"\"UniqueName\": \"{modSingle.modelName}\", " +
                            $"\"Index\": {index}, " +
                            $"\"TranslatedLabel\": {{ " +
                                $"\"Hash\": {GetHash(modSingle.modShopLabel)}, " +
                                $"\"English\":\"{gtxName}\", " +
                                $"\"German\": \"{gtxName}\", " +
                                $"\"French\": \"\", " +
                                $"\"Italian\": \"\", " +
                                $"\"Russian\": \"\", " +
                                $"\"Polish\": \"\" }}, " +
                            $"\"Type\": {(int)mod.type}, " +
                            $"\"Bone\": \"{mod.bone.ToString().ToUpper()}\", " +
                            $"\"CollisionBone\": \"{mod.collisionBone.ToString().ToUpper()}\", " +
                            $"\"Weight\": {mod.weight}, " +
                            $"\"IsWeapon\": false }}");

                        // Erhöhe Index
                        index++;
                    }
                }

                // Füge zu Daten (komplett) hinzu
                data += $"{{ \"Id\": {kit.id}, " +
                    $"\"Name\": \"{kit.kitName}\", " +
                    $"\"Type\": \"{kit.kitType}\", " +
                    $"\"Mods\": [{string.Join(", ", jsonMods)}], " +
                    $"\"VehicleModels\": {JsonConvert.SerializeObject(models.FindAll(x =>
                    x.VehicleKit == kit.kitName.ToString()).Select(x => x.VehicleName).ToList())} }},";
            }

            // Rückgabe
            return data;
        }

        private static uint GetHash(string stringToHash)
        {
            if (string.IsNullOrEmpty(stringToHash)) return 0;

            var characters = Encoding.UTF8.GetBytes(stringToHash.ToLower());

            uint hash = 0;

            foreach (var c in characters)
            {
                hash += c;
                hash += hash << 10;
                hash ^= hash >> 6;
            }

            hash += hash << 3;
            hash ^= hash >> 11;
            hash += hash << 15;

            return hash;
        }
    }
}