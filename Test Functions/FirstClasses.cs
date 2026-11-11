using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARC_System
{
    public partial class Form1 : Form
    {
        public class DuelistCreation
        {
            public DuelistCreation Duelist { get; set; }
            public int LP { get; set; }
            public Card[] Hand { get; set; } //Might not be needed overall
            public Card[] MonsterZones { get; set; }
            public Card[] SpellTrapZones { get; set; }
            public Card[] Banished { get; set; }
            public Card[] Graveyard { get; set; }

            public DuelistCreation(int lp, Card[] hand, Card[] monsterZones, Card[] spelltrapZones, Card[] banished, Card[] graveyard)
            {
                LP = lp;
                Hand = hand;
                MonsterZones = monsterZones;
                SpellTrapZones = spelltrapZones;
                Banished = banished;
                Graveyard = graveyard;
            }
        }
        public class Card
        {
            public string Name { get; set; }
            public string Card_Frame { get; set; } //(Ex: Spell, Trap, Effect, Normal)
            public string Special_Card_Frame { get; set; } //(Ritual, Fusion, XYZ, Link, Synchro)
            public string Attribute { get; set; } //(Ex: Light, Dark, Spell, Trap, Earth, Fire, Water, Wind)
            public string Type { get; set; } //(Ex: Spell and Trap types, Warrior, Dragon, Pyro, Aqua, Plant, Zombie, etc)
            public int Atk { get; set; }
            public bool unoriginalAtk { get; set; } //(True means the attack points are no longer their original value)
            public int Def { get; set; }
            public bool unoriginalDef { get; set; } //(True means the defense points are no longer their original value)
            public bool Flip { get; set; } //(True means interactions will need a check to flip the Monster if needed such as: Attacking, changing position, effect forcing a position change)
            public int Position { get; set; } //(1 = Face-Up Attack, 2 = Face-Up Defense, 3 = Face-Down Defense)
            public bool CanAttack { get; set; } //(All Monsters with Position 1 are marked true at turn change and marked false after attacking)
            public bool SpecialSummoned { get; set; }
            public DuelistCreation Owner { get; set; }

            public Card(string name, string card_frame, string special_card_frame, string attribute, string type, int atk, bool unoriginalatk, int def, bool unoriginaldef, bool flip, int position, bool canattack, bool specialsummoned, DuelistCreation owner)
            {
                Name = name;
                Card_Frame = card_frame;
                Special_Card_Frame = special_card_frame;
                Attribute = attribute;
                Type = type;
                Atk = atk;
                unoriginalAtk = unoriginalatk;
                Def = def;
                unoriginalDef = unoriginaldef;
                Flip = flip;
                Position = position;
                CanAttack = canattack;
                SpecialSummoned = specialsummoned;
                Owner = owner;
            }
        }
        public Form1()
        {
            InitializeComponent();

            DuelistCreation duelist1 = new DuelistCreation(8000, new Card[] { }, new Card[] { }, new Card[] { }, new Card[] { }, new Card[] { });
            DuelistCreation duelist2 = new DuelistCreation(8000, new Card[] { }, new Card[] { }, new Card[] { }, new Card[] { }, new Card[] { });
            Console.WriteLine(duelist1.LP);
            Console.WriteLine(duelist1.Hand.Length);
            Console.WriteLine(duelist2.LP);

            Card tmpCard = new Card("Familiar-Possessed - Aussa", "Effect", "", "Earth", "Spellcaster", 1850, false, 1500, false, false, 1, true, false, duelist1);
            Console.WriteLine(tmpCard.Name + " " + tmpCard.Atk + " " + tmpCard.Def + " " + tmpCard.Attribute + " " + tmpCard.Type + " " + tmpCard.Position);
        }
    }
}
