Dieses Skript ist für den [alt:V-Launcher](https://altv.mp).

## Allgemein
Dieses Skript erzeugt automatisch eine vehicleMods.json von einer Modding-Fahrzeug Ressource mit Hilfe von [CodeWalker.Core](https://github.com/dexyfex/CodeWalker) in dem alle Stammdaten der Tuningteile extrahiert werden. Diese können wie identisch wie die von [DurtyFree](https://github.com/DurtyFree) kostenfrei zur Verfügung gestellten [Export-Daten (GTA Original: vehicleModKits.json)](https://github.com/DurtyFree/gta-v-data-dumps) eingebunden werden um Modding-Fahrzeuge gleich einfach wie orignale Fahrzeug einzubinden.

## Anwendung
Umgesetzt wurde das Skript als Konsolenanwendung um durch einen Paramter (Pfad zum Stream-Path) automatisch eine *vehicleMods.json*-Datei überschreibend in der Ressource zu erstellen. Starte in einer Konsole die **SkylineVVehicleTuning.exe** (im Bild Rot) und gib einen Pfad zu einer Ressource (Bspw. C:\ALTV-S\resources\vkunoisa\stream) an (im Bild Gelb) um darin die **vehicleModKits.json** (im Bild Grün) zu erstellen.

![Preview](https://user-images.githubusercontent.com/3730600/229350752-d1080a25-737f-4c0f-a3d9-617214324e34.png)

## Unterstützte Typen
```
"VMT_SPOILER" => 0,
"VMT_BUMPER_F" => 1,
"VMT_BUMPER_R" => 2,
"VMT_SKIRT" => 3,
"VMT_EXHAUST" => 4,
"VMT_CHASSIS" => 5,
"VMT_GRILL" => 6,
"VMT_BONNET" => 7,
"VMT_WING_L" => 8,
"VMT_WING_R" => 9,
"VMT_ROOF" => 10,
"VMT_ENGINE" => 11,
"VMT_BRAKES" => 12,
"VMT_GEARBOX" => 13,
"VMT_HORN" => 14,
"VMT_SUSPENSION" => 15,
"VMT_ARMOUR" => 16,
"VMT_NITROUS" => 17,
"VMT_TURBO" => 18,
"VMT_SUBWOOFER" => 19,
"VMT_TYRE_SMOKE" => 20,
"VMT_HYDRAULICS" => 21,
"VMT_XENON_LIGHTS" => 22,
"VMT_WHEELS" => 23,
"VMT_WHEELS_REAR_OR_HYDRAULICS" => 24,
"VMT_PLTHOLDER" => 25,
"VMT_PLTVANITY" => 26,
"VMT_INTERIOR1" => 27,
"VMT_INTERIOR2" => 28,
"VMT_INTERIOR3" => 29,
"VMT_INTERIOR4" => 30,
"VMT_INTERIOR5" => 31,
"VMT_SEATS" => 32,
"VMT_STEERING" => 33,
"VMT_KNOB" => 34,
"VMT_PLAQUE" => 35,
"VMT_ICE" => 36,
"VMT_TRUNK" => 37,
"VMT_HYDRO" => 38,
"VMT_ENGINEBAY1" => 39,
"VMT_ENGINEBAY2" => 40,
"VMT_ENGINEBAY3" => 41,
"VMT_CHASSIS2" => 42,
"VMT_CHASSIS3" => 43,
"VMT_CHASSIS4" => 44,
"VMT_CHASSIS5" => 45,
"VMT_DOOR_L" => 46,
"VMT_DOOR_R" => 47,
"VMT_LIVERY_MOD" => 48,
"VMT_LIGHTBAR" => 49,
```
