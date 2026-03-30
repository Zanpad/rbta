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
    public partial class Form1 : Form
    {
        BindingList<Person> familyMember = new BindingList<Person>();
        BindingList<Expense> expenses = new BindingList<Expense>();
        BindingList<Income> incomes = new BindingList<Income>();
        List<Category> categories = new List<Category>();
        List<Product> products = new List<Product>();
        List<FromClass> fromClasses = new List<FromClass>();
        public int IdPerson = 1;
        public int IdIncome = 1;
        public int IdExpense = 1;
        public int IdCaregory = 1;
        public int IdProduct = 1;
        public int IdFrom = 1;
        private void reffreshTables()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = familyMember;

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = expenses;

            dataGridView3.DataSource = null;
            dataGridView3.DataSource = incomes;

            double summExpenses = 0;
            double summIncomes = 0;

            foreach (var element in expenses)
            {
                summExpenses += element.Price;
            }
            foreach (var element in incomes)
            {
                summIncomes += element.Price;
            }
            double resSumm = summIncomes - summExpenses;
            label2.Text = (resSumm.ToString() + " рублей");
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var formAdd = new AddOrEditForm(null))
            {
                formAdd.ShowDialog();
                if (formAdd.DialogResult == DialogResult.OK)
                {
                    formAdd.currentPerson.Id = IdPerson++;
                    familyMember.Add(formAdd.currentPerson);
                    Income income = new Income();
                    income.Price = formAdd.currentCapital;
                    income.Id = IdIncome++;
                    income.IdBuyer = formAdd.currentPerson.Id;
                    income.Comment = "Добавлен член семьи";
                    incomes.Add(income);
                    reffreshTables();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Не выбран человек", "Ошибка");
                return;
            }
            Person personSelect = (Person)dataGridView1.SelectedRows[0].DataBoundItem;
            //Кнопка изменить
            using (var formAdd = new AddOrEditForm(personSelect))
            {
                formAdd.ShowDialog();
                reffreshTables();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (var formadd = new AddExpense(null,
                categories, products, familyMember, IdCaregory, IdProduct))
            {
                formadd.ShowDialog();
                if (formadd.DialogResult == DialogResult.OK)
                {
                    formadd.CurrentExpense.Id = IdExpense++;
                    expenses.Add(formadd.CurrentExpense);
                    if(formadd.idCategory != IdCaregory)
                    {
                        IdCaregory = formadd.idCategory;
                    }

                    if (formadd.idProduct != IdProduct)
                    {
                        IdProduct = formadd.idProduct;
                    }
                    reffreshTables();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Не выбран расход", "Ошибка");
                return;
            }
            Expense expenseSelect = (Expense)dataGridView2.SelectedRows[0].DataBoundItem;
            using (var formAdd = new AddExpense(expenseSelect,
                categories, products, familyMember, IdCaregory, IdProduct))
            {
                formAdd.ShowDialog();
                if (formAdd.DialogResult == DialogResult.OK)
                {
                    if (formAdd.idCategory != IdCaregory)
                    {
                        IdCaregory = formAdd.idCategory;
                    }

                    if (formAdd.idProduct != IdProduct)
                    {
                        IdProduct = formAdd.idProduct;
                    }
                    reffreshTables();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            using (var formAdd = new AddIncome(null,
                fromClasses, IdFrom, familyMember))
            {
                formAdd.ShowDialog();
                if(formAdd.DialogResult == DialogResult.OK)
                {
                    formAdd.CurrentIncome.Id = IdIncome++;
                    incomes.Add(formAdd.CurrentIncome);
                    if (formAdd.idFrom != IdFrom)
                    {
                        IdFrom = formAdd.idFrom;
                    }

                    reffreshTables();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Не выбран доход", "Ошибка");
                return;
            }
            Income incomeselect
                = (Income)dataGridView3.SelectedRows[0].DataBoundItem;

            using (var formAdd = new AddIncome(incomeselect,
                fromClasses, IdFrom, familyMember))
            {
                formAdd.ShowDialog();
                if (formAdd.DialogResult == DialogResult.OK)
                {
                    if(formAdd.idFrom != IdFrom)
                    {
                        IdFrom = formAdd.idFrom;
                    }

                    reffreshTables();
                }
            }
        }
    }
}
