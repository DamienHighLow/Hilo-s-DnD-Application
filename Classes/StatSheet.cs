using System;
using System.Collections.Generic;
using System.Text;

namespace DnDApplication.Classes
{
    public class StatSheet
    {
        public int strength { get; set; }
        public int dexterity { get; set; }
        public int constitution { get; set; }
        public int intelligence { get; set; }
        public int wisdom { get; set; }
        public int charisma { get; set; }
        public int strengthSave { get; set; }
        public int dexteritySave { get; set; }
        public int constitutionSave { get; set; }
        public int intelligenceSave { get; set; }
        public int wisdomSave { get; set; }
        public int charismaSave { get; set; }
        public int maxHp { get; set; }
        public int proficiencyBonus { get; set; }
        public int initiative { get; set; }
        public int perception { get; set; }
        public int walkSpeed { get; set; }
        public int swimSpeed { get; set; }
        public int burrowSpeed { get; set; }
        public int climbSpeed { get; set; }
        public int flySpeed { get; set; }
        public int blindsight { get; set; }
        public int darkvision { get; set; }
        public int tremorsense { get; set; }
        public int truesight { get; set; }

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
