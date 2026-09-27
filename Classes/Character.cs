using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Swift;
using System.Text;

namespace DnDApplication.Classes
{
    public class Character
    {
        private StatSheet stats {  get; set; }
        private List<string> magic { get; set; }
        private string _race { get; set; }
        private string _spellMod { get; set; }
        private int _armorClass { get; set; }
        private int _currentHP { get; set; }
        private int? _tempHP { get; set; }
        private Dictionary<string, int>? _professions {  get; set; }
        private Dictionary<string, int>? _proficiencies { get; set; }
        private List<string>? _languages { get; set; }
        private List<string>? _immunities { get; set; }
        private List<string>? _resistances { get; set; }
        private List<string>? _vulnerabilites { get; set; }

        public Character(Dictionary<string, int> stats, List<string> magic, string race, string spellMod, int armorClass, int currentHp, int tempHP) { 
            this.stats = new StatSheet(stats);
            this.magic = magic;
            this._race = race;
            this._spellMod = spellMod;
            this._armorClass = armorClass;
            this._currentHP = currentHp;
            this._tempHP = tempHP;
        }

        public Character(Dictionary<string, int> stats, List<string> magic, string race, string spellMod, int armorClass, int currentHP, int? tempHP, Dictionary<string, int>? professions, Dictionary<string, int>? proficiencies, List<string>? languages)
        {
            this.stats = new StatSheet(stats);
            this.magic = magic;
            this._race = race;
            this._spellMod = spellMod;
            this._armorClass = armorClass;
            this._currentHP = currentHP;
            this._tempHP = tempHP;
            this._professions = professions;
            this._proficiencies = proficiencies;
            this._languages = languages;
        }

        public Character(Dictionary<string, int> stats, List<string> magic, string race, string spellMod, int armorClass, int currentHP, int tempHP, Dictionary<string, int> professions, Dictionary<string, int> proficiencies, List<string> languages, List<string> immunities, List<string> resistances, List<string> vulnerabilites)
        {
            this.stats = new StatSheet(stats);
            this.magic = magic;
            this._race = race;
            this._spellMod = spellMod;
            this._armorClass = armorClass;
            this._currentHP = currentHP;
            this._tempHP = tempHP;
            this._professions = professions;
            this._proficiencies = proficiencies;
            this._languages = languages;
            this._immunities = immunities;
            this._resistances = resistances;
            this._vulnerabilites = vulnerabilites;
        }
    }
}
