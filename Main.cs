using DnDApplication;

namespace DnDApplication
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void CharacterFormButton_Click(object sender, EventArgs e)
        {
            CharacterForm charForm = new CharacterForm();
            charForm.Show();

        }

    }
}
