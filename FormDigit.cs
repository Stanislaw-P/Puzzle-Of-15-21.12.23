using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Puzzle_Of_15
{
    public partial class FormDigit : Form
    {
        
        int[,] field = new int[,] { { 1,2,3,4 }, { 5, 6, 7, 8 }, { 9,10,11,12 }, { 13, 14, 15, 0 } };
        int countStep = 0;
        int s;

        public FormDigit()
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

        bool FieldIsTrue()
        {
            int count = 0;
            int n = field.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i + j != 6)
                    {
                        int currElement = field[i, j];
                        for (int k = i; k < n; k++)
                        {
                            for (int l = j; l < n; l++)
                            {
                                if (k + l != 6)
                                    if (field[k, l] < currElement)
                                        count++;
                            }
                        }
                    }

                }
            }
            return count % 2 == 0;
        }

        void ShuffleTheField()
        {
            Random rnd = new Random();

            for (int i = field.GetLength(0) - 1; i >= 1; i--)
            {
                for (int j = field.GetLength(1) - 1; j >= 1; j--)
                {
                   if(i + j != 6)
                   {
                        int k = rnd.Next(i + 1);
                        int l = rnd.Next(j + 1);
                        int temp = field[k, l];
                        field[k, l] = field[i, j];
                        field[i, j] = temp;
                   }
                }      
            }



            //for (int i = 0; i < field.GetLength(0); i++)
            //{
            //    for (int j = 0; j < field.GetLength(1); j++)
            //    {
            //        if (i + j != 6)
            //        {
            //            int k, l;
            //            k = rnd.Next(field.GetLength(0));
            //            l = rnd.Next(field.GetLength(1));
            //            if (k + l != 6)
            //            {
            //                int temp = field[i, j];
            //                field[i, j] = field[k, l];
            //                field[k, l] = temp;
            //            }
            //        }
            //    }
            //}

           
        }

        void ShowArrayToDataGrid()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if(i + j != 6)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = field[i,j];
                    }
                }
            }
        }

        void NewGame()
        {
            field = new int[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 0 } };
            countStep = 0;
            ShuffleTheField();
            ShowArrayToDataGrid();
            s = 0;
            timer1.Enabled = true;

        }

        private void FormDigit_Load(object sender, EventArgs e)
        {
            ShuffleTheField();
            while (!FieldIsTrue())
            {
                ShuffleTheField();
            }

            ShowArrayToDataGrid(); // Отображение перемешанного поля
            timer1.Enabled = true;
        }

        bool IsWin()
        {
            int[,] winField = new int[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 0 } };
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if(i + j != 6)
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
            int[,] alsoWinField = new int[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 15, 14, 0 } };
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
                            int temp = field[i, j];
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
            if(MoveElement(xB, yB))
                countStep++;    
            labelCountStep.Text = countStep.ToString();
            if (IsWin() || AlsoWin())
            {
                timer1.Enabled = false;
                MessageBox.Show($"Вы выиграли за {countStep} ходов и {s-1} сек!");
                NewGame();
            }
        }


        private void toolStripMenuItem2_Click(object sender, EventArgs e)
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
