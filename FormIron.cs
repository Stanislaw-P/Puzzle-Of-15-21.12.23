using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle_Of_15
{
    public partial class FormIron : Form
    {
        string[,] field = new string[,] { { "иу", "дыууӕ", "ӕртӕ", "цыппар" },{ "фондз", "ӕхсӕз", "авд", "аст" }, { "фараст", "дӕс", "иуӕндӕс", "дыууадӕс" }, { "ӕртындӕс", "цыппӕрдӕс", "фынддӕс", "ноль" } };
        int countStep = 0;
        int s;

        public FormIron()
        {
            InitializeComponent();
            for (int i = 0; i < 4; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Height = 95;
            }
            timer1.Interval = 1000;
            s = 0;
        }

        void ShuffleTheField()
        {
            Random rnd = new Random();

            for (int i = field.GetLength(0) - 1; i >= 1; i--)
            {
                for (int j = field.GetLength(1) - 1; j >= 1; j--)
                {
                    if (i + j != 6)
                    {
                        int k = rnd.Next(i + 1);
                        int l = rnd.Next(j + 1);
                        string temp = field[k, l];
                        field[k, l] = field[i, j];
                        field[i, j] = temp;
                    }
                }
            }
        }

        void ShowArrayToDataGrid()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i + j != 6)
                    {

                        dataGridView1.Rows[i].Cells[j].Value = field[i, j];
                    }
                }
            }
        }

        void NewGame()
        {
            field = new string [,] { { "иу", "дыууӕ", "ӕртӕ", "цыппар" }, { "фондз", "ӕхсӕз", "авд", "аст" }, { "фараст", "дӕс", "иуӕндӕс", "дыууадӕс" }, { "ӕртындӕс", "цыппӕрдӕс", "фынддӕс", "ноль" } };
            countStep = 0;
            ShuffleTheField();
            ShowArrayToDataGrid();
            s = 0;
            timer1.Enabled = true;
        }

        private void FormIron_Load(object sender, EventArgs e)
        {
            ShuffleTheField();
            ShowArrayToDataGrid(); // Отображение перемешанного поля
            timer1.Enabled = true;
        }

        bool IsWin()
        {
            string[,] winField = new string[,] { { "иу", "дыууӕ", "ӕртӕ", "цыппар" }, { "фондз", "ӕхсӕз", "авд", "аст" }, { "фараст", "дӕс", "иуӕндӕс", "дыууадӕс" }, { "ӕртындӕс", "цыппӕрдӕс", "фынддӕс", "ноль" } };
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (i + j != 6)
                    {
                        if (field[i, j] != winField[i, j])
                            return false;
                    }
                }
            }
            return true;
        }

        bool AlsoWin()
        {
            string[,] alsoWinField = new string[,] { { "иу", "дыууӕ", "ӕртӕ", "цыппар" }, { "фондз", "ӕхсӕз", "авд", "аст" }, { "фараст", "дӕс", "иуӕндӕс", "дыууадӕс" }, { "ӕртындӕс", "фынддӕс", "цыппӕрдӕс", "ноль" } };
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (i + j != 6)
                    {
                        if (field[i, j] != alsoWinField[i, j])
                            return false;
                    }
                }
            }
            return true;
        }

        bool MoveElement(int xB, int yB)
        {
            for (int i = xB - 1; i <= xB + 1; i++)
            {
                for (int j = yB - 1; j <= yB + 1; j++)
                {
                    if (0 <= i && i < 4 && 0 <= j && j < 4 && (i == xB || j == yB))
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value == null)   // Если у ячейки на которую кликнули есть пустой сосед, то меняем их местами
                        {
                            dataGridView1.Rows[i].Cells[j].Value = dataGridView1.Rows[xB].Cells[yB].Value;
                            dataGridView1.Rows[xB].Cells[yB].Value = null;
                            string temp = field[i, j];
                            field[i, j] = field[xB, yB];
                            field[xB, yB] = temp;
                            return true;
                        }
                    }
                }
            }
            return false;
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.ClearSelection(); // Убрать выделение ячеек синим

            int xB, yB;
            xB = e.RowIndex;
            yB = e.ColumnIndex;
            if (MoveElement(xB, yB))
                countStep++;
            labelCountStep.Text = countStep.ToString();
            if (IsWin() || AlsoWin())
            {
                timer1.Enabled = false;
                MessageBox.Show($"\t  Иттӕг хорз!\nДы рамбылдтай {countStep} цыдаей {s - 1} секундмае!");
                NewGame();
            }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTimer.Text = s.ToString();
            s++;
        }
    }
}
