using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Appps
{
    public partial class RunningForm : Form
    {
        //старая позиция курсора
        Point pos;
        //на сколько увеличилась позиция курсора(скорость изменения)
        Point delta;
        public RunningForm()
        {
            InitializeComponent();
        }

        private void RunningForm_Load(object sender, EventArgs e)
        {

        }

        //При движении мышки по форме вызываем функцию для движения кнопки
        private void RunningForm_MouseMove(object sender, MouseEventArgs e)
        {
            ChangePositionButton();
        }

        //Подсчет скорости изменения позиции курсора
        private void CalcDelta(Point new_pos)
        {
            delta.X = pos.X - new_pos.X;
            delta.Y = pos.Y - new_pos.Y;
            pos = new_pos;
        }

        /*Изменение положения кнопки.
        Если при рассчетах кнопка выходит за пределы формы, то ее перебрасывает на другую сторону формы*/
        private void ChangePositionButton()
        {
            Point new_pos;
            new_pos = MousePosition;
            CalcDelta(new_pos);
            if (button1.Location.X - delta.X < 5)
            {
                button1.Location = new Point(RunningForm.ActiveForm.Width - button1.Width - 20, button1.Location.Y);
            }
            else if (button1.Location.X - delta.X > RunningForm.ActiveForm.Width - button1.Width - 20)
            {
                button1.Location = new Point(5, button1.Location.Y);
            }
            else if (button1.Location.Y - delta.Y < 5)
            {
                button1.Location = new Point(button1.Location.X, RunningForm.ActiveForm.Height - button1.Height - 35);
            }
            else if (button1.Location.Y - delta.Y > RunningForm.ActiveForm.Height - button1.Height - 35)
            {
                button1.Location = new Point(button1.Location.X, 5);
            }
            else
            {
                button1.Location = new Point(button1.Location.X - delta.X, button1.Location.Y - delta.Y);
            }
        }

        /*Если размеры окна изменяются, то нужно высчитать новое положение кнопки.
        Если кнопка выходит за границы, то просто приклеиваем ее к ближайшему краю*/
        private void RunningForm_ResizeEnd(object sender, EventArgs e)
        {
            if (button1.Location.X < 5)
            {
                button1.Location = new Point(5, button1.Location.Y);
            }

            if (button1.Location.X > RunningForm.ActiveForm.Width - button1.Width - 20)
            {
                button1.Location = new Point(RunningForm.ActiveForm.Width - button1.Width - 20, button1.Location.Y);
            }

            if (button1.Location.Y < 5)
            {
                button1.Location = new Point(button1.Location.X, 5);
            }

            if (button1.Location.Y > RunningForm.ActiveForm.Height - button1.Height - 35)
            {
                button1.Location = new Point(button1.Location.X, RunningForm.ActiveForm.Height - button1.Height - 35);
            }
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            ChangePositionButton();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Спасибо, мы так и думали!");
            Close();
        }
    }
}
