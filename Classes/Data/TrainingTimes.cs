using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace DnDApplication.Classes.Data
{
    internal class TrainingTimes
    {
        private static readonly List<string> ProfessionLevels = new List<string>()
        {
            "Novice",
            "Apprentice",
            "Advanced",
            "Expert",
            "Master",
        };

        private static readonly Dictionary<string, int> trainingTimes = new Dictionary<string, int>() {
            ["Novice_Profession"] = 24,
            ["Apprentice_Profession"] = 168,
            ["Advanced_Profession"] = 840,
            ["Expert_Profession"] = 2520,
            ["Proficiency"] = 96,
            ["Light_Armor"] = 96,
            ["Medium_Armor"] = 384,
            ["Heavy_Armor"] = 2304,
            ["Shield"] = 96,
            ["Simple_Melee"] = 24,
            ["Simple_Ranged"] = 36,
            ["Martial_Melee"] = 48,
            ["Martial_Ranged"] = 72,
            ["Stat_8"] = 0,
            ["Stat_9"] = 6,
            ["Stat_10"] = 18,
            ["Stat_11"] = 30,
            ["Stat_12"] = 54,
            ["Stat_13"] = 24,
            ["Stat_14"] = 126,
            ["Stat_15"] = 174,
            ["Stat_16"] = 270,
            ["Stat_17"] = 366,
            ["Stat_18"] = 558,
            ["Stat_19"] = 750,
            ["Stat_20"] = 1134,
            ["Save_1"] = 96,
            ["Save_2"] = 192,
            ["Save_3"] = 384,
            ["Save_4"] = 768,
            ["Save_5"] = 1536,
            ["Save_6"] = 3072,
        };

        public int GetTrainingTime(string type)
        {
            if (!trainingTimes.ContainsKey(type))
            {
                return -1;
            }
            return trainingTimes[type];
        }

        public List<string> GetProfessionLevels()
        {
            return ProfessionLevels;
        }
    };
}
