using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace To_do_List_App
{
    public partial class ToDoList : Form
    {
        public ToDoList()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        DataTable todoList = new DataTable();
        bool isEditing = false;
        private void ToDoList_Load(object sender, EventArgs e)
        {
            //Criar colunas
            todoList.Columns.Add("Título");
            todoList.Columns.Add("Descrição");

            //Apontar a datagridview para o datasource
            toDoListView.DataSource = todoList;

        }

        private void newButton_Click(object sender, EventArgs e)
        {
            titleTextBox.Text = "";
            descriptionTextBox.Text = "";

        }

        private void editButton_Click(object sender, EventArgs e)
        {
            isEditing = true;
            //Pegar o texto da tabela e usar no campo de texto
            titleTextBox.Text = todoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[0].ToString();
            descriptionTextBox.Text = todoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[1].ToString();

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                todoList.Rows[toDoListView.CurrentCell.RowIndex].Delete();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Erro: " + ex);
            }

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(isEditing)
            {
                todoList.Rows[toDoListView.CurrentCell.RowIndex]["Título"] = titleTextBox.Text;
                todoList.Rows[toDoListView.CurrentCell.RowIndex]["Descrição"] = descriptionTextBox.Text;
            }
            else
            {
                todoList.Rows.Add(titleTextBox.Text, descriptionTextBox.Text);
            }
            //Limpar campos de texto
            titleTextBox.Text = "";
            descriptionTextBox.Text = "";
            isEditing = false;
        }
    }
}
