using System.Text.Json;
using DnDApplication.Classes;
using DnDApplication.Classes.Data;

namespace DnDApplication
{

    public partial class CharacterForm : Form
    {
        public CharacterForm()
        {
            InitializeComponent();

        }

        private TrainingTimes trainingTimes = new TrainingTimes();

        private decimal prevStr = 0;
        private decimal prevDex = 0;
        private decimal prevCon = 0;
        private decimal prevInt = 0;
        private decimal prevWis = 0;
        private decimal prevCha = 0;

        private int proficienciesIdx = 18;
        private int simpleMeleeIdx = 28;
        private int simpleRangedIdx = 32;
        private int martialMeleeIdx = 56;
        private int martialRangedIdx = 61;

        private void BaseStatChanged(NumericUpDown statObj, NumericUpDown savingThrowObj, Label statLabel, decimal prevNum)
        {
            decimal num = statObj.Value;
            int mod = (int)Math.Floor((num - 10) / 2);

            if (mod < 0)
            {
                // Removes plus sign for negative numbers and zero.
                statLabel.Text = $"({mod.ToString()})";
            }
            else
            {
                // Displays positive stat modifiers with a plus sign.
                statLabel.Text = $"(+{mod.ToString()})";
            }

            // Adds the stat's difference to the saving throw stats.
            decimal newSave;
            if (prevNum == 0)
            {
                // Previous STR stat wasn't initalized so it subtracts the base stat (8) from the current stat value.
                newSave = num - 8;
            }
            else
            {
                // Substracts the previous STR stat from the current stat value.
                newSave = num - prevNum;
            }

            // Valids the saving throw's value.
            if (statObj.Value + newSave >= 8 && savingThrowObj.Value + newSave <= 30)
            {
                // Adds/subtracts to the stat's difference to the saving throw.
                savingThrowObj.Value += newSave;
            }
            else if (savingThrowObj.Value + newSave < 8)
            {
                // If the new saving throw stat value is too small, it defaults to 8.
                savingThrowObj.Value = 8;
            }
            else if (savingThrowObj.Value + newSave > 30)
            {
                // If the new saving throw stat value is too big, it defaults to 30.
                savingThrowObj.Value = 30;
            }
        }
        
        private void SavingThrowChanged(NumericUpDown savingThrowObj, Label statLabel) {
            decimal num = (decimal)savingThrowObj.Value;
            int mod = (int)Math.Floor((num - 10) / 2);

            if (mod < 0)
            {
                statLabel.Text = $"({mod.ToString()})";
            }
            else
            {
                statLabel.Text = $"(+{mod.ToString()})";
            }
        }

        private void StrengthNumericBox_ValueChanged(object sender, EventArgs e)
        {
            BaseStatChanged(StrengthNumericBox, StrengthSaveNumericBox, StrengthModLabel, prevStr);
            prevStr = StrengthNumericBox.Value;
        }
        private void DexterityNumericBox_ValueChanged(object sender, EventArgs e)
        {
            BaseStatChanged(DexterityNumericBox, DexteritySaveNumericBox, DexterityModLabel, prevDex);
            prevDex = DexterityNumericBox.Value;

            // Updates Initiative and AC values accordingly
            ArmorClassNumericBox.Value = 10 + (int)Math.Floor((prevDex - 10) / 2);
            InitiativeNumericBox.Value = (int)Math.Floor((prevDex - 10) / 2);
        }
        private void ConstitutionNumericBox_ValueChanged(object sender, EventArgs e)
        {
            BaseStatChanged(ConstitutionNumericBox, ConstitutionSaveNumericBox, ConstitutionModLabel, prevCon);
            prevCon = ConstitutionNumericBox.Value;
        }
        private void IntelligenceNumericBox_ValueChanged(object sender, EventArgs e)
        {
            BaseStatChanged(IntelligenceNumericBox, IntelligenceSaveNumericBox, IntelligenceModLabel, prevInt);
            prevInt = IntelligenceNumericBox.Value;
        }
        private void WisdomNumericBox_ValueChanged(object sender, EventArgs e)
        {
            BaseStatChanged(WisdomNumericBox, WisdomSaveNumericBox, WisdomModLabel, prevWis);
            prevWis = WisdomNumericBox.Value;

            // Updates the perception's value accordingly
            PerceptionNumericBox.Value = 10 + (int)Math.Floor((prevWis - 10) / 2);
        }
        private void CharismaNumericBox_ValueChanged(object sender, EventArgs e)
        {
            BaseStatChanged(CharismaNumericBox, CharismaSaveNumericBox, CharismaModLabel, prevCha);
            prevCha = CharismaNumericBox.Value;
        }
        private void StrengthSaveNumericBox_ValueChanged(object sender, EventArgs e)
        {
            SavingThrowChanged(StrengthSaveNumericBox, StrengthSaveModLabel);
        }
        private void DexteritySaveNumericBox_ValueChanged(object sender, EventArgs e)
        {
            SavingThrowChanged(DexteritySaveNumericBox, DexteritySaveModLabel);

        }
        private void ConstitutionSaveNumericBox_ValueChanged(object sender, EventArgs e)
        {
            SavingThrowChanged(ConstitutionSaveNumericBox, ConstitutionSaveModLabel);

        }
        private void IntelligenceSaveNumericBox_ValueChanged(object sender, EventArgs e)
        {
            SavingThrowChanged(IntelligenceSaveNumericBox, IntelligenceSaveModLabel);

        }
        private void WisdomSaveNumericBox_ValueChanged(object sender, EventArgs e)
        {
            SavingThrowChanged(WisdomSaveNumericBox, WisdomSaveModLabel);

        }
        private void CharismaSaveNumericBox_ValueChanged(object sender, EventArgs e)
        {
            SavingThrowChanged(CharismaSaveNumericBox, CharismaSaveModLabel);

        }
        private void UnlockPerceptionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PerceptionNumericBox.Enabled = !PerceptionNumericBox.Enabled;
            PerceptionNumericBox.ReadOnly = !PerceptionNumericBox.ReadOnly;
        }
        private void UnlockInitiativeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            InitiativeNumericBox.Enabled = !InitiativeNumericBox.Enabled;
            InitiativeNumericBox.ReadOnly = !InitiativeNumericBox.ReadOnly;
        }
        private void UnlockACCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ArmorClassNumericBox.Enabled = !ArmorClassNumericBox.Enabled;
            ArmorClassNumericBox.ReadOnly = !ArmorClassNumericBox.ReadOnly;
        }
        private void PrimaryMagicComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Checks if an artificial magic or that 'None' magic was picked
            if (PrimaryMagicComboBox.SelectedIndex <= 0 || PrimaryMagicComboBox.SelectedIndex > 12)
            {
                // Disables the secondary magic if the user picked None or an artificial magic.
                SecondaryMagicComboBox.Enabled = false;
                SecondaryMagicComboBox.SelectedIndex = 0;
            }
            else
            {
                SecondaryMagicComboBox.Enabled = true;
            }
        }
        private void ClassComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ClassComboBox.SelectedIndex >= 0)
            {
                var className = ClassComboBox.Text.ToString();
                var startingIdx = className.IndexOf("(") + 1;
                var endIdx = className.IndexOf(")");
                var classModifier = className.Substring(startingIdx, endIdx - startingIdx);

                SpellModifier.Text = classModifier;
            }
        }
        private void VulnerabilitiesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = VulnerabilitiesListBox.SelectedIndex;

            ResistancesListBox.SetItemChecked(idx, false);
            ImmunitiesListBox.SetItemChecked(idx, false);
        }
        private void ResistancesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = ResistancesListBox.SelectedIndex;

            VulnerabilitiesListBox.SetItemChecked(idx, false);
            ImmunitiesListBox.SetItemChecked(idx, false);
        }
        private void ImmunitiesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = ImmunitiesListBox.SelectedIndex;

            if (idx < VulnerabilitiesListBox.Items.Count)
            {
                VulnerabilitiesListBox.SetItemChecked(idx, false);
                ResistancesListBox.SetItemChecked(idx, false);
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            // Resets the page back to default.
            StrengthNumericBox.Value = 8;
            DexterityNumericBox.Value = 8;
            ConstitutionNumericBox.Value = 8;
            IntelligenceNumericBox.Value = 8;
            WisdomNumericBox.Value = 8;
            CharismaNumericBox.Value = 8;
            StrengthSaveNumericBox.Value = 8;
            DexteritySaveNumericBox.Value = 8;
            ConstitutionSaveNumericBox.Value = 8;
            IntelligenceSaveNumericBox.Value = 8;
            WisdomSaveNumericBox.Value = 8;
            CharismaSaveNumericBox.Value = 8;

            MaxHPNumericBox.Value = 20;
            ArmorClassNumericBox.Value = 10;
            InitiativeNumericBox.Value = 0;
            PerceptionNumericBox.Value = 10;

            DarkVisionNumericBox.Value = 60;
            BlindSightNumericBox.Value = 0;
            TremorSenseNumericBox.Value = 0;
            TrueSightNumericBox.Value = 0;

            WalkSpeedNumericBox.Value = 30;
            SwimSpeedNumericBox.Value = 0;
            BurrowSpeedNumericBox.Value = 0;
            ClimbSpeedNumericBox.Value = 0;
            FlySpeedNumericBox.Value = 0;

            PrimaryMagicComboBox.SelectedIndex = 0;
            SecondaryMagicComboBox.SelectedIndex = 0;
            ClassComboBox.SelectedIndex = 0;
            RaceComboBox.SelectedIndex = 0;

            for (int i = 0; i < ProficienciesListBox.Items.Count; i++)
            {
                ProficienciesListBox.SetItemChecked(i, false);
            }

            for (int i = 0; i < LanguagesListBox.Items.Count; i++)
            {
                LanguagesListBox.SetItemChecked(i, false);
            }

            for (int i = 0; i < ProfessionsListBox.Items.Count; i++)
            {
                ProfessionsListBox.SetItemChecked(i, false);
            }

            for (int i = 0; i < VulnerabilitiesListBox.Items.Count; i++)
            {
                VulnerabilitiesListBox.SetItemChecked(i, false);
            }

            for (int i = 0; i < ResistancesListBox.Items.Count; i++)
            {
                ResistancesListBox.SetItemChecked(i, false);
            }

            for (int i = 0; i < ImmunitiesListBox.Items.Count; i++)
            {
                ImmunitiesListBox.SetItemChecked(i, false);
            }
        }

        private async void CreateButton_Click(object sender, EventArgs e)
        {
            List<string> magic = new List<string>();
            List<string> languages = new List<string>();
            List<string> vulnerabilites = new List<string>();
            List<string> resistances = new List<string>();
            List<string> immunities = new List<string>();
            Dictionary<string, int> professions = new Dictionary<string, int>();
            Dictionary<string, int> proficiencies = new Dictionary<string, int>();
            string spellMod = SpellModifier.Text;
            string race;
            int armorClass = (int)ArmorClassNumericBox.Value;
            int maxHp = (int)MaxHPNumericBox.Value;


            // Creates a new stat sheet
            Dictionary<string, int> stats = new Dictionary<string, int>
            {
                { "strength",(int)StrengthNumericBox.Value},
                { "dexterity",(int)DexterityNumericBox.Value},
                { "constitution",(int)ConstitutionNumericBox.Value},
                { "intelligence",(int)IntelligenceNumericBox.Value},
                { "wisdom",(int)WisdomNumericBox.Value},
                { "charisma", (int)CharismaNumericBox.Value},
                { "strengthSave",(int)StrengthSaveNumericBox.Value},
                { "dexteritySave",(int)DexteritySaveNumericBox.Value},
                { "constitutionSave",(int)ConstitutionSaveNumericBox.Value},
                { "intelligenceSave",(int)IntelligenceSaveNumericBox.Value},
                { "wisdomSave",(int)WisdomSaveNumericBox.Value},
                { "charismaSave",(int)CharismaSaveNumericBox.Value},
                { "maxHp",maxHp},
                { "proficiencyBonus",(int)PBNumericBox.Value},
                { "initiative",(int)InitiativeNumericBox.Value},
                { "perception",(int)PerceptionNumericBox.Value},
                { "walkSpeed",(int)WalkSpeedNumericBox.Value},
                { "swimSpeed",(int)SwimSpeedNumericBox.Value},
                { "burrowSpeed",(int)BurrowSpeedNumericBox.Value},
                { "climbSpeed",(int)ClimbSpeedNumericBox.Value},
                { "flySpeed",(int)FlySpeedNumericBox.Value},
                { "blindsight",(int)BlindSightNumericBox.Value},
                { "darkvision",(int)DarkVisionNumericBox.Value},
                { "tremorsense",(int)TremorSenseNumericBox.Value},
                { "truesight",(int)TrueSightNumericBox.Value}
            };

            try
            {
                // Adds the user's magic to the magic list
                if (PrimaryMagicComboBox.SelectedIndex >= 0)
                {
                    magic.Add(PrimaryMagicComboBox.SelectedItem.ToString());

                    if (SecondaryMagicComboBox.SelectedIndex >= 0)
                    {
                        magic.Add(SecondaryMagicComboBox.SelectedItem.ToString());
                    }
                }
                else
                {
                    throw new Exception("Magic selection empty! Please select a Magic!");
                }

                // Ensures the user picked a race
                if (RaceComboBox.SelectedIndex >= 0)
                {
                    race = RaceComboBox.SelectedItem.ToString();
                }
                else
                {
                    throw new Exception("Race selection empty! Please select a Race!");
                }

                // Adds all proficincies to the proficiencies dictionary
                for (int i = 0; i < ProficienciesListBox.Items.Count; i++)
                {
                    if (ProficienciesListBox.GetItemChecked(i))
                    {
                        if (i >= proficienciesIdx)
                        {
                            proficiencies.Add(ProficienciesListBox.Items[i].ToString(), trainingTimes.GetTrainingTime("Proficiency"));
                        }
                        else if (i >= simpleMeleeIdx)
                        {
                            proficiencies.Add(ProficienciesListBox.Items[i].ToString(), trainingTimes.GetTrainingTime("Simple_Melee"));
                        }
                        else if (i >= simpleRangedIdx)
                        {
                            proficiencies.Add(ProficienciesListBox.Items[i].ToString(), trainingTimes.GetTrainingTime("Simple_Ranged"));
                        }
                        else if (i >= martialMeleeIdx)
                        {
                            proficiencies.Add(ProficienciesListBox.Items[i].ToString(), trainingTimes.GetTrainingTime("Martial_Melee"));
                        }
                        else if (i >= martialRangedIdx)
                        {
                            proficiencies.Add(ProficienciesListBox.Items[i].ToString(), trainingTimes.GetTrainingTime("Martial_Ranged"));
                        }
                    }
                }

                // Adds all professions to the professions dictionary
                for (int i = 0; i < ProfessionsListBox.Items.Count; i++)
                {
                    foreach (string level in trainingTimes.GetProfessionLevels())
                    {
                        if (ProfessionsListBox.GetItemChecked(i))
                        {
                            string item = ProfessionsListBox.Items[i].ToString();

                            if (item.Contains(level))
                            {
                                // Separates the item from the profession level
                                item = item.Substring(item.IndexOf(" ") + 1);
                                professions.Add(item, trainingTimes.GetTrainingTime(level + "_Profession"));
                            }
                        }
                    }
                }

                // Adds all languages to the languages list
                for (int i = 0; i < LanguagesListBox.Items.Count; i++)
                {
                    if (LanguagesListBox.GetItemChecked(i))
                    {
                        languages.Add(LanguagesListBox.Items[i].ToString());
                    }
                }

                // Adds all vulnerabilities to the vulnerabilities list
                for (int i = 0; i < VulnerabilitiesListBox.Items.Count; i++)
                {
                    if (VulnerabilitiesListBox.GetItemChecked(i))
                    {
                        vulnerabilites.Add(VulnerabilitiesListBox.Items[i].ToString());
                    }
                }

                // Adds all resistances to the resistances list
                for (int i = 0; i < ResistancesListBox.Items.Count; i++)
                {
                    if (ResistancesListBox.GetItemChecked(i))
                    {
                        resistances.Add(ResistancesListBox.Items[i].ToString());
                    }
                }

                // Adds all immunities to the immunities list
                for (int i = 0; i < ImmunitiesListBox.Items.Count; i++)
                {
                    if (ImmunitiesListBox.GetItemChecked(i))
                    {
                        immunities.Add(ImmunitiesListBox.Items[i].ToString());
                    }
                }

                // creates a character object and asks where the user wants to save the data.
                var character = new Character(stats, magic, race, spellMod, armorClass, maxHp, 0, professions, proficiencies, languages, immunities, resistances, vulnerabilites);

                SaveCharacterSheet(character);
            }
            catch (Exception ex)
            {
                // Shows the error and stops the function if data is missing
                MessageBox.Show("Failed to create character sheet.\n\n" + ex.Message, "Error: Missing Data!");
            }
        }

        private void SaveCharacterSheet(Character character)
        {
            // Gets the charactersheet directory
            var characterSheetPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "./CharacterSheets");

            // Checks if the charactersheet directory exists. Creates the directory if it doesn't exist already.
            if (!Directory.Exists(characterSheetPath))
            {
                Directory.CreateDirectory(characterSheetPath);
            }

            // Ensures a name was inputted into the name textbox
            if (NameTextBox.Text.Length != 0)
            {
                // Ensures the name only contains letters and digits to prevent issues when saving the character sheet.
                if (NameTextBox.Text.All(char.IsLetterOrDigit))
                {
                    // Gets the path of the character sheet and 
                    var filePath = Path.Combine(characterSheetPath, NameTextBox.Text + ".txt");

                    // If the file exists
                    if (File.Exists(filePath))
                    {
                        // Prompts the user if they'd like to override the file.
                        var overrideFile = MessageBox.Show("The character sheet \"" + NameTextBox.Text + "\" already exists. Would you like to override the character sheet?", "Are you sure?", MessageBoxButtons.YesNoCancel);

                        // Stops the file being replaced
                        if (overrideFile == DialogResult.No)
                        {
                            return;
                        }
                    }

                    // Writes the character sheet into a json file
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    var jsonString = JsonSerializer.Serialize(character, options);
                    File.WriteAllText(filePath, jsonString);

                    // Prompts the user the character sheet was successfully created!
                    MessageBox.Show("Successfully created character sheet!");
                }
                else
                {
                    MessageBox.Show("Name can only include numeric and alphabetical characters only. Please change the character sheet's name.");
                }
            }
            else
            {
                MessageBox.Show("Name for character sheet required!");
            }
        }

        private void CharacterForm_Load(object sender, EventArgs e)
        {
            // Ensures all objects are loaded with default values selected
            ResetButton_Click(sender, e);
        }
    }
}