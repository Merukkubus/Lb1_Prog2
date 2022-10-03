using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeroClass;
using Microsoft.VisualBasic;

namespace Lb1_Prog2
{
    public partial class MainForm : Form
    {
        readonly List<Hero> heroes = new List<Hero>();
        public MainForm()
        {
            InitializeComponent();
            heroes.Add(new Hero("Hero1", 100, 500, 300, 1));
            heroes.Add(new Hero("Hero2", 100, 500, 300, 1));
            Hero1FightButton.Enabled = false;
            Hero2FightButton.Enabled = false;
        }

        Point lastPoint;
        private void MainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void MainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ExitButton_MouseEnter(object sender, EventArgs e)
        {
            this.ExitButton.ForeColor = Color.Red;
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e)
        {
            this.ExitButton.ForeColor = Color.Black;
        }

        private int InputValue(string result)
        {
            int temp;
            if (int.TryParse(result, out temp) != false)
            {
                temp = int.Parse(result);
            }
            else
            {
                MessageBox.Show("Вы ввели неверное значение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return temp;
        }

        private void CheckComboBox(ComboBox box, Button but, int num)
        {
            if (box.SelectedIndex != num - 1)
            {
                but.Enabled = true;
            }
            if (heroes[num - 1].GetHp() == 0 || box.SelectedItem == null)
            {
                but.Enabled = false;
            }
        }

        private void Hero1HealButton_Click(object sender, EventArgs e)
        {
            string result = Interaction.InputBox("Введите количество HP для исцеления:", "Лечение", "0", 500, 300);
            heroes[0].Heal(InputValue(result));
            Hero1HpLabel.Text = Convert.ToString(heroes[0].GetHp());
            CheckComboBox(Hero1ComboBox, Hero1FightButton, 1);
        }

        private void UpScoreHero1Button_Click(object sender, EventArgs e)
        {
            string result = Interaction.InputBox("Введите количество бонусов:", "Бонусы >> Счёт", "0", 500, 300);
            heroes[0].UpScore(InputValue(result));
            Hero1ScoreLabel.Text = Convert.ToString(heroes[0].GetScore());
            Hero1BonusesLabel.Text =Convert.ToString(heroes[0].GetBonuses());
        }

        private void LvlUpHero1Button_Click(object sender, EventArgs e)
        {
            heroes[0].LvlUp();
            Hero1LvlLabel.Text = Convert.ToString(heroes[0].GetLvl());
        }

        private void Hero1ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckComboBox(Hero1ComboBox, Hero1FightButton, 1);
        }

        private void Hero1FightButton_Click(object sender, EventArgs e)
        {
            if (heroes[1].GetHp() == 0)
            {
                MessageBox.Show("У противника недостаточно здоровья!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                heroes[0].Fight(heroes[1]);
                Hero1HpLabel.Text = Convert.ToString(heroes[0].GetHp());
                Hero1ScoreLabel.Text = Convert.ToString(heroes[0].GetScore());
                Hero2HpLabel.Text = Convert.ToString(heroes[1].GetHp());
                Hero2ScoreLabel.Text = Convert.ToString(heroes[1].GetScore());
            }
            CheckComboBox(Hero1ComboBox, Hero1FightButton, 1);
            Hero1ComboBox.SelectedItem = null;
            Hero2ComboBox.SelectedItem = null;
        }

        private void Hero2HealButton_Click(object sender, EventArgs e)
        {
            string result = Interaction.InputBox("Введите количество HP для исцеления:", "Лечение", "0", 500, 300);
            heroes[1].Heal(InputValue(result));
            Hero2HpLabel.Text = Convert.ToString(heroes[1].GetHp());
            CheckComboBox(Hero2ComboBox, Hero2FightButton, 2);
        }

        private void UpScoreHero2Button_Click(object sender, EventArgs e)
        {
            string result = Interaction.InputBox("Введите количество бонусов:", "Бонусы >> Счёт", "0", 500, 300);
            heroes[1].UpScore(InputValue(result));
            Hero2ScoreLabel.Text = Convert.ToString(heroes[1].GetScore());
            Hero2BonusesLabel.Text = Convert.ToString(heroes[1].GetBonuses());
        }

        private void LvlUpHero2Button_Click(object sender, EventArgs e)
        {
            heroes[1].LvlUp();
            Hero2LvlLabel.Text = Convert.ToString(heroes[1].GetLvl());
        }

        private void Hero2ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckComboBox(Hero2ComboBox, Hero2FightButton, 2);
        }

        private void Hero2FightButton_Click(object sender, EventArgs e)
        {
            if (heroes[0].GetHp() == 0)
            {
                MessageBox.Show("У противника недостаточно здоровья!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                heroes[1].Fight(heroes[0]);
                Hero1HpLabel.Text = Convert.ToString(heroes[0].GetHp());
                Hero1ScoreLabel.Text = Convert.ToString(heroes[0].GetScore());
                Hero2HpLabel.Text = Convert.ToString(heroes[1].GetHp());
                Hero2ScoreLabel.Text = Convert.ToString(heroes[1].GetScore());
            }
            CheckComboBox(Hero2ComboBox, Hero2FightButton, 2);
            Hero1ComboBox.SelectedItem = null;
            Hero2ComboBox.SelectedItem = null;
        }
    }
}
