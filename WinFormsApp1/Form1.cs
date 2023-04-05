using static System.Net.Mime.MediaTypeNames;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private DataGridViewColumn dataGridViewColumn1 = null;
        private DataGridViewColumn dataGridViewColumn2 = null;
        private DataGridViewColumn dataGridViewColumn3 = null;

        private void initDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Add(getDataGridViewColumn1());
            dataGridView1.Columns.Add(getDataGridViewColumn2());
            dataGridView1.Columns.Add(getDataGridViewColumn3());
            dataGridView1.AutoResizeColumns();
        }

        private DataGridViewColumn getDataGridViewColumn1()
        {
            if (dataGridViewColumn1 == null)
            {
                dataGridViewColumn1 = new DataGridViewTextBoxColumn();
                dataGridViewColumn1.Name = "";
                dataGridViewColumn1.HeaderText = "Имя";
                dataGridViewColumn1.ValueType = typeof(string);
                dataGridViewColumn1.Width = dataGridView1.Width / 3;
            }

            return dataGridViewColumn1;
        }

        private DataGridViewColumn getDataGridViewColumn2()
        {
            if (dataGridViewColumn2 == null)
            {
                dataGridViewColumn2 = new DataGridViewTextBoxColumn();
                dataGridViewColumn2.Name = "";
                dataGridViewColumn2.HeaderText = "Фамилия";
                dataGridViewColumn2.ValueType = typeof(string);
                dataGridViewColumn2.Width = dataGridView1.Width / 3;
            }

            return dataGridViewColumn2;
        }

        private DataGridViewColumn getDataGridViewColumn3()
        {
            if (dataGridViewColumn3 == null)
            {
                dataGridViewColumn3 = new DataGridViewTextBoxColumn();
                dataGridViewColumn3.Name = "";
                dataGridViewColumn3.HeaderText = "Зачетка";
                dataGridViewColumn3.ValueType = typeof(string);
                dataGridViewColumn3.Width = dataGridView1.Width / 3;
            }

            return dataGridViewColumn3;
        }

        private List<Student> studentList = new List<Student>();

        private void addStudent(string name, string surname, string recordBookNumber)
        {
            Student s = new Student(name, surname, recordBookNumber);
            studentList.Add(s);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox2.Text = "";
            showListInGrid();
        }

        private void deleteStudent(int elementIndex)
        {
            studentList.RemoveAt(elementIndex);
            showListInGrid();
        }

        private void showListInGrid()
        {
            dataGridView1.Rows.Clear();
            foreach (Student s in studentList)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell cell1 = new
                    DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell2 = new
                    DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell3 = new
                    DataGridViewTextBoxCell();
                cell1.ValueType = typeof(string);
                cell1.Value = s.getName();
                cell2.ValueType = typeof(string);
                cell2.Value = s.getSurname();
                cell3.ValueType = typeof(string);
                cell3.Value = s.getRecordBookNumber();
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                dataGridView1.Rows.Add(row);
            }
        }

        public Form1()
        {
            InitializeComponent();
            initDataGridView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedRow = dataGridView1.SelectedCells[0].RowIndex;
            DialogResult dr = MessageBox.Show("Удалить студента?", "", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    deleteStudent(selectedRow);
                }
                catch (Exception)
                {

                }

            }
        }

        string CheckError()
        {
            string mess = "";
            if (textBox1.Text == "")
            {
                mess += "Поле Имя пустое\n";
            }

            foreach (var el in textBox1.Text)
            {
                if (char.IsDigit(el))
                {

                    mess += "Поле Имя должно содержать только буквы\n";
                    break;
                }
            }

            if (textBox2.Text == "")
            {
                mess += "Поле Фамилия пустое\n";
            }

            foreach (var el in textBox2.Text)
            {
                if (char.IsDigit(el))
                {

                    mess += "Поле Фамилия должно содержать только буквы\n";
                    break;
                }
            }

            if (textBox3.Text == "")
            {
                mess += "Поле номер зачетки пустое\n";
            }

            foreach (var el in textBox3.Text)
            {
                if (!char.IsDigit(el))
                {

                    mess += "Поле номер зачетки должно содержать только цифры\n";
                    break;
                }
            }

            if (textBox3.Text.Length != 6)
            {
                mess += "Поле номер зачетки должно содержать 6 цифр\n";
            }

            return mess;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string check = CheckError();
            if (check == "")
            {
                addStudent(textBox1.Text, textBox2.Text, textBox3.Text);
                MessageBox.Show("Запись добавлена", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
            else
            {
                MessageBox.Show(check, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}