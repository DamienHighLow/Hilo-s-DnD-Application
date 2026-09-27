using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Swift;
using System.Text;

namespace DnDApplication.Classes
{
    public class Character
    {
        public StatSheet stats { get; set; }
        public List<string> magic { get; set; }
        public string race { get; set; }
        public string spellMod { get; set; }
        public int armorClass { get; set; }
        public int currentHP { get; set; }
        public int? tempHP { get; set; }
        public Dictionary<string, int>? professions {  get; set; }
        public Dictionary<string, int>? proficiencies { get; set; }
        public List<string>? languages { get; set; }
        public List<string>? immunities { get; set; }
        public List<string>? resistances { get; set; }
        public List<string>? vulnerabilites { get; set; }

        public Character(Dictionary<string, int> stats, List<string> magic, string race, string spellMod, int armorClass, int currentHp, int tempHP) { 
            this.stats = new StatSheet(stats);
            this.magic = magic;
            this.race = race;
            this.spellMod = spellMod;
            this.armorClass = armorClass;
            this.currentHP = currentHp;
            this.tempHP = tempHP;
        }

        public Character(Dictionary<string, int> stats, List<string> magic, string race, string spellMod, int armorClass, int currentHP, int? tempHP, Dictionary<string, int>? professions, Dictionary<string, int>? proficiencies, List<string>? languages)
        {
            this.stats = new StatSheet(stats);
            this.magic = magic;
            this.race = race;
            this.spellMod = spellMod;
            this.armorClass = armorClass;
            this.currentHP = currentHP;
            this.tempHP = tempHP;
            this.professions = professions;
            this.proficiencies = proficiencies;
            this.languages = languages;
        }

        public Character(Dictionary<string, int> stats, List<string> magic, string race, string spellMod, int armorClass, int currentHP, int tempHP, Dictionary<string, int> professions, Dictionary<string, int> proficiencies, List<string> languages, List<string> immunities, List<string> resistances, List<string> vulnerabilites)
        {
            this.stats = new StatSheet(stats);
            this.magic = magic;
            this.race = race;
            this.spellMod = spellMod;
            this.armorClass = armorClass;
            this.currentHP = currentHP;
            this.tempHP = tempHP;
            this.professions = professions;
            this.proficiencies = proficiencies;
            this.languages = languages;
            this.immunities = immunities;
            this.resistances = resistances;
            this.vulnerabilites = vulnerabilites;
        }
    }
}
