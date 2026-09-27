using System;
using System.Collections.Generic;
using System.Text;

namespace DnDApplication.Classes
{
    internal class StatSheet
    {
        private int strength { get; set; }
        private int dexterity { get; set; }
        private int constitution { get; set; }
        private int intelligence { get; set; }
        private int wisdom { get; set; }
        private int charisma { get; set; }
        private int strengthSave { get; set; }
        private int dexteritySave { get; set; }
        private int constitutionSave { get; set; }
        private int intelligenceSave { get; set; }
        private int wisdomSave { get; set; }
        private int charismaSave { get; set; }
        private int maxHp { get; set; }
        private int proficiencyBonus { get; set; }
        private int initiative { get; set; }
        private int perception { get; set; }
        private int walkSpeed { get; set; }
        private int swimSpeed { get; set; }
        private int burrowSpeed { get; set; }
        private int climbSpeed { get; set; }
        private int flySpeed { get; set; }
        private int blindsight { get; set; }
        private int darkvision { get; set; }
        private int tremorsense { get; set; }
        private int truesight { get; set; }

        // Basic Stats oOnly 
        public StatSheet(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
        {
            this.strength = strength;
            this.dexterity = dexterity;
            this.constitution = constitution;
            this.intelligence = intelligence;
            this.wisdom = wisdom;
            this.charisma = charisma;
        }

        // All parameters constructor
        public StatSheet(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma, int strengthSave, int dexteritySave, int constitutionSave, int intelligenceSave, int wisdomSave, int charismaSave, int maxHp, int proficiencyBonus, int initiative, int perception, int walkSpeed, int swimSpeed, int burrowSpeed, int climbSpeed, int flySpeed, int darkvision, int blindsight, int tremorsense, int truesight)
        {
            this.strength = strength;
            this.dexterity = dexterity;
            this.constitution = constitution;
            this.intelligence = intelligence;
            this.wisdom = wisdom;
            this.charisma = charisma;
            this.strengthSave = strengthSave;
            this.dexteritySave = dexteritySave;
            this.constitutionSave = constitutionSave;
            this.intelligenceSave = intelligenceSave;
            this.wisdomSave = wisdomSave;
            this.charismaSave = charismaSave;
            this.maxHp = maxHp;
            this.proficiencyBonus = proficiencyBonus;
            this.initiative = initiative;
            this.perception = perception;
            this.walkSpeed = walkSpeed;
            this.swimSpeed = swimSpeed;
            this.burrowSpeed = burrowSpeed;
            this.climbSpeed = climbSpeed;
            this.flySpeed = flySpeed;
            this.blindsight = blindsight;
            this.darkvision = darkvision;
            this.tremorsense = tremorsense;
            this.truesight = truesight;
        }

        // All parameters constructor /w Dictionary
        public StatSheet(Dictionary<string, int> stats)
        {
            this.strength = stats["strength"];
            this.dexterity = stats["dexterity"];
            this.constitution = stats["constitution"];
            this.intelligence = stats["intelligence"];
            this.wisdom = stats["wisdom"];
            this.charisma = stats["charisma"];
            this.strengthSave = stats["strengthSave"];
            this.dexteritySave = stats["dexteritySave"];
            this.constitutionSave = stats["constitutionSave"];
            this.intelligenceSave = stats["intelligenceSave"];
            this.wisdomSave = stats["wisdomSave"];
            this.charismaSave = stats["charismaSave"];
            this.maxHp = stats["maxHp"];
            this.proficiencyBonus = stats["proficiencyBonus"];
            this.initiative = stats["initiative"];
            this.perception = stats["perception"];
            this.walkSpeed = stats["walkSpeed"];
            this.swimSpeed = stats["swimSpeed"];
            this.burrowSpeed = stats["burrowSpeed"];
            this.climbSpeed = stats["climbSpeed"];
            this.flySpeed = stats["flySpeed"];
            this.blindsight = stats["blindsight"];
            this.darkvision = stats["darkvision"];
            this.tremorsense = stats["tremorsense"];
            this.truesight = stats["truesight"];
        }

        // Gets all related stat Modifiers
        protected int getStrength()
        {
            return (this.strength - 10) / 2;
        } 
        protected int getDexterity()
        {
            return (this.dexterity - 10) / 2;
        }
        protected int getConstitution()
        {
            return (this.constitution - 10) / 2;
        }
        protected int getIntelligence()
        {
            return (this.intelligence - 10) / 2;
        }
        protected int getWisdom()
        {
            return (this.wisdom - 10) / 2;
        }
        protected int getCharisma()
        {
            return (this.charisma - 10) / 2;
        }
        protected int getStrengthSave()
        {
            return (this.strengthSave - 10) / 2;
        }
        protected int getDexteritySave()
        {
            return (this.dexteritySave - 10) / 2;
        }
        protected int getConstitutionSave()
        {
            return (this.constitutionSave - 10) / 2;
        }
        protected int getIntelligenceSave()
        {
            return (this.intelligenceSave - 10) / 2;
        }
        protected int getWisdomSave()
        {
            return (this.wisdomSave - 10) / 2;
        }
        protected int getCharismaSave()
        {
            return (this.charismaSave - 10) / 2;
        }
    }
}
