using System.Windows.Forms;
using Doctor.Classes;

namespace Doctor.Forms
{
    public partial class AcountCreationForm : Form
    {
        private DoctorConnector _connector;

        public AcountCreationForm(DoctorConnector connector)
        {
            InitializeComponent();

            _connector = connector;
            errorPasswordsMatchLabel.Visible = false;
            errorEmptyFIeldLabel.Visible = false;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (NameTextBox.Text != "" && passwordBoxOne.Text != "" && passWordBoxTwo.Text != "")
            {
                if (passwordBoxOne.Text == passWordBoxTwo.Text)
                {
                    _connector.SendMessage(new
                    {
                        id = "client/new",
                        data = new
                        {
                            name = NameTextBox.Text,
                            password = passwordBoxOne.Text,
                            isDoctor = false
                        }
                    });
                    Close();
                }
                else
                {
                    errorPasswordsMatchLabel.Visible = true;
                    errorEmptyFIeldLabel.Visible = false;
                    Invalidate();
                }
            }
            else
            {
                errorPasswordsMatchLabel.Visible = false;
                errorEmptyFIeldLabel.Visible = true;
                Invalidate();
            }
        }
    }
}
