using System;

namespace HeroClass
{
    public class Hero
    {
        private readonly string name;
        private int hp;
        private int score;
        private int bonuses;
        private int lvl;

        static readonly Random r = new Random();

        public Hero(string name, int hp, int score, int bonuses, int lvl)
        {
            this.name = name;
            this.hp = hp;
            this.score = score;
            this.bonuses = bonuses;
            this.lvl = lvl;
        }

        public void Heal(int hp)
        {
            this.hp += hp;
            if (this.hp < 0) { this.hp = 0; }
        }

        public bool UpScore(int bonuses)
        {
            if (this.bonuses >= bonuses)
            {
                this.bonuses -= bonuses;
                this.score += bonuses;
                return true;
            }
            return false;
        }

        public void LvlUp()
        {
            this.lvl += 1;
        }

        public bool Fight(Hero enemy)
        {
            double win_chance = (double)lvl / (double)(lvl + enemy.lvl);
            if (r.NextDouble() > win_chance)
            {
                hp -= 1;
                score -= 50;
                return false;
            }
            else
            {
                enemy.hp -= 1;
                enemy.score -= 50;
                return true;
            }
        }

        public string GetName()
        {
            return name;
        }
        public int GetHp()
        {
            return hp;
        }
        public int GetScore()
        {
            return score;
        }
        public int GetBonuses()
        {
            return bonuses;
        }
        public int GetLvl()
        {
            return lvl;
        }
    }
}
