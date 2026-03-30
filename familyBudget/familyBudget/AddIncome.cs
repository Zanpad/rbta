using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace familyBudget
{
    public partial class AddIncome : Form
    {
        public Expense CurrentIncome;
        public List<FromClass> fromListCurrent;
        public int idFrom = -1;
        BindingList<Person> personListCurrent;
        public AddIncome(Income SelectIncome,
            List<FromClass> fromListSelect,
            int idFromSelect,
            BindingList<Person> personListSelect)
        {
            InitializeComponent();
            fromListCurrent = fromListSelect;
            idFrom = idFromSelect;
            personListCurrent = personListSelect;
            if(SelectIncome == null)
            {
                CurrentIncome = new Income();
            }
            else
            {
                CurrentIncome = SelectIncome;
                string fromText = "";
                string whoText = "";
                foreach(var fromElement in fromListCurrent)
                {
                    if(fromElement.Id == CurrentIncome.IdFrom)
                    {
                        fromText = fromElement.Name;
                    }
                }
                foreach(var personElement in personListCurrent)
                {
                    if(personElement.Id == CurrentIncome.IdBuyer)
                    {
                        whoText = personElement.Name;
                        break;
                    }
                }
                comboBox1.Text = fromText;
                comboBox3.Text = whoText;
                textBox1.Text = CurrentIncome.Price.ToString();
                textBox2.Text = CurrentIncome.Comment;
                dateTimePicker1.Value = CurrentIncome.DateOperation;
            }
            foreach(var fromElement in fromListCurrent)
            {
                comboBox1.Items.Add(fromElement.Name);
            }
            foreach(var personElement in personListCurrent)
            {
                comboBox3.Items.Add(personElement.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            if (comboBox1.Items.IndexOf(comboBox1.Text) == -1)
            {
                CurrentIncome.IdFrom = ++idFrom;
                fromListCurrent.Add(
                    new FromClass { 
                        Name = comboBox1.Text, 
                        Id = CurrentIncome.IdFrom }
                    );
            }
            else
            {
                CurrentIncome.IdFrom
                    = fromListCurrent
                    [comboBox1.Items.IndexOf(comboBox1.Text)].Id;
            }
            if (comboBox3.SelectedIndex != -1)
            {
                CurrentIncome.IdBuyer = personListCurrent[comboBox3.SelectedIndex].Id;
            }

            if (comboBox3.SelectedIndex != 1)
            {
                CurrentIncome.IdBuyer = personListCurrent[comboBox3.SelectedIndex].Id;
            }

            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                CurrentIncome.Price = Convert.ToDouble(textBox1.Text);
            }
            CurrentIncome.Comment = textBox2.Text;
            CurrentIncome.DateOperation = dateTimePicker1.Value;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
