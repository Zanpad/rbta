using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace familyBudget
{
    public partial class AddExpense : Form
    {
        public Expense CurrentExpense;
        public List<Category> categoryListCurrent;
        public List<Product> productListCurrent;
        public int idCategory = -1;
        public int idProduct = -1;
        BindingList<Person> personListCurrent;
        public AddExpense(
            Expense selectExpense,
            List<Category> categoryList,
            List<Product> productList,
            BindingList<Person> personList,
            int idCategoryLast, int idProductLast
            )
        {
            InitializeComponent();
            categoryListCurrent = categoryList;
            productListCurrent = productList;
            personListCurrent = personList;
            idCategory = idCategoryLast;
            idProduct = idProductLast;
            if(selectExpense == null)
            {
                CurrentExpense = new Expense();
            }
            else
            {
                CurrentExpense = selectExpense;
                string nameSelectCategory = "";
                string nameSelectProduct = "";
                string nameSelectPerson = "";

                foreach (var category in categoryList)
                {
                    if (category.Id == selectExpense.IdCategory)
                    { nameSelectCategory = category.Name; break; }
                }
                foreach (var product in productList)
                {
                    if (product.Id == selectExpense.IdProduct)
                    { nameSelectProduct = product.Name; break; }
                }
                foreach (var person in personList)
                {
                    if (person.Id == selectExpense.IdBuyer)
                    { nameSelectPerson = person.Name; break; }
                }
                comboBox1.Text = nameSelectCategory;
                comboBox2.Text = nameSelectProduct;
                comboBox3.Text = nameSelectPerson;
                textBox1.Text = selectExpense.Price.ToString();
                textBox2.Text = selectExpense.Comment;
                dateTimePicker1.Value = selectExpense.DateOperation;
            }

            foreach(var category in categoryList)
            {
                comboBox1.Items.Add(category.Name);
            }
            foreach(var product in productList)
            {
                comboBox2.Items.Add(product.Name);
            }
            foreach(var person in personList)
            {
                 comboBox3.Items.Add(person.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK; 

            if(comboBox1.Items.IndexOf(comboBox1.Text) == -1)
            {
                CurrentExpense.IdCategory = ++idCategory;
                categoryListCurrent.Add(
                    new Category { Name = comboBox1.Text, Id = CurrentExpense.IdCategory }
                    );
            }
            else
            {
                CurrentExpense.IdCategory
                    = categoryListCurrent[comboBox1.Items.IndexOf(comboBox1.Text)].Id;
            }
            if (comboBox2.Items.IndexOf(comboBox2.Text) == -1)
            {
                CurrentExpense.IdProduct = ++idProduct;
                productListCurrent.Add(
                    new Product { Name = comboBox2.Text, Id = CurrentExpense.IdProduct });
            }
            else
            {
                CurrentExpense.IdProduct
                    = categoryListCurrent[comboBox2.Items.IndexOf(comboBox2.Text)].Id;
            }
            
            if(comboBox3.SelectedIndex != 1)
            {
                CurrentExpense.IdBuyer = personListCurrent[comboBox3.SelectedIndex].Id;
            }

            if(!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                CurrentExpense.Price = Convert.ToDouble(textBox1.Text);
            }
            CurrentExpense.Comment = textBox2.Text;
            CurrentExpense.DateOperation = dateTimePicker1.Value;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
