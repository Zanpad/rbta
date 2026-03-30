using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace familyBudget
{
    public partial class AddOrEditForm : Form
    {
        public Person currentPerson;
        public double currentCapital = 0;
        public AddOrEditForm(Person selectPerson)
        {
            InitializeComponent();
            if(selectPerson == null)
            {
                currentPerson = new Person();
                textBox2.Enabled = true;
            }
            else
            {
                currentPerson = selectPerson;
                textBox2.Enabled = false;
                textBox1.Text = selectPerson.Name;
                dateTimePicker1.Value = selectPerson.BirthDay;
                if(selectPerson.Female)
                {
                    radioButton1.Checked = true;
                    radioButton2.Checked = false;
                }
                else
                {
                    radioButton1.Checked = false;
                    radioButton2.Checked = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            currentPerson.Name = textBox1.Text;
            currentPerson.BirthDay = dateTimePicker1.Value;
            if(radioButton1.Checked){currentPerson.Female = true;}
            else { currentPerson.Female = false; }
            if(!string.IsNullOrWhiteSpace(textBox2.Text))
            {
                currentCapital = Convert.ToDouble(textBox2.Text);
            }
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
