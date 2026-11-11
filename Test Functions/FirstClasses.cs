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
            /*
             * Created the class for a duelist to create new duelists when needed
             * Lists are used for the Hand, Banished, and Graveyard as they are not needed to be in the same position all the time
             * The Zones are arrays as they are fixed values
             * Will need to add the extra monster zones at a later date when things are more developed
            */
            public DuelistCreation Duelist { get; set; }
            public int LP { get; set; }
            public List<Card> Hand { get; set; } //Might not be needed overall
            public Card[] MonsterZones { get; set; }
            public Card[] SpellTrapZones { get; set; }
            public List<Card> Banished { get; set; }
            public List<Card> Graveyard { get; set; }

            public DuelistCreation(int lp, List<Card> hand, Card[] monsterZones, Card[] spelltrapZones, List<Card> banished, List<Card> graveyard)
            {
                LP = lp;
                Hand = hand;
                MonsterZones = new Card[5];
                SpellTrapZones = new Card[6];
                Banished = banished;
                Graveyard = graveyard;
            }
        }
        public class Card
        {
            /*
             * Created the class for all cards
             * More variables and items can be added/adjusted if and when needed
             */
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
        public class Phases
        {
            public int Draw { get; set; }
            public int Standby { get; set; }
            public int Main1 { get; set; }
            public int Battle { get; set; }
            public int Main2 { get; set; }
            public int End { get; set; }

            public Phases ()
            {
                Draw = 1;
                Standby = 2;
                Main1 = 3;
                Battle = 4;
                Main2 = 5;
                End = 6;
            }
        }
        public class TurnManager 
        {
            public int TurnCounter { get; set; }
            public TurnManager TurnPlayer { get; set; }
            public TurnManager DefendingPlayer { get; set; }

        }
        public Form1()
        {
            InitializeComponent();

            //Needed
            Phases phases = new Phases();
            int currentPhase = phases.Draw;
            int requestedPhase;
            /////////////////////////////////////////////
            /////Messing aroung and trying stuff out
            /////Will want to look at keeping the if statements for security
            requestedPhase = 4;

            if(requestedPhase <= currentPhase)
            {
                Console.WriteLine("Cannot go back a phase");
            }
            else 
            {
                currentPhase = requestedPhase;
            }
            //////////////////////////////////////////////
            //////////////////////////////////////////////
            //Messing around and trying stuff out
            DuelistCreation duelist1 = new DuelistCreation(8000, new List<Card> { }, new Card[] { }, new Card[] { }, new List<Card> { }, new List<Card> { });
            DuelistCreation duelist2 = new DuelistCreation(8000, new List<Card> { }, new Card[] {}, new Card[] { }, new List<Card> { }, new List<Card> { });
            Console.WriteLine(duelist1.LP);
            Console.WriteLine(duelist1.Hand.Count);
            Console.WriteLine(duelist2.LP);

            Card tmpCard = new Card("Familiar-Possessed - Aussa", "Effect", "", "Earth", "Spellcaster", 1850, false, 1500, false, false, 1, true, false, duelist1);
            Console.WriteLine(tmpCard.Name + " " + tmpCard.Atk + " " + tmpCard.Def + " " + tmpCard.Attribute + " " + tmpCard.Type + " " + tmpCard.Position);

            Console.WriteLine("Added Aussa to the hand");
            duelist1.Hand.Add(tmpCard);
            Console.WriteLine(duelist1.Hand.Count);
            Console.WriteLine(duelist1.Hand[0].Name);

            duelist1.Graveyard.Add(tmpCard);
            Console.WriteLine(duelist1.Graveyard.Count);
            duelist1.MonsterZones[0] = tmpCard;

            Console.WriteLine("Monster in grave");
            Console.WriteLine(duelist1.Graveyard[0].Name);
            Console.WriteLine(duelist1.MonsterZones[0].Name);
            //May want to keep to skip any empty zones
            for(int x = 1; x <= 5; x++)
            {
                if (duelist1.MonsterZones[x - 1] == null)
                {
                    //Allows the program to ignore the empty zones
                    continue; 
                }
                else
                {
                    Console.WriteLine("Zone " + x + ": " + duelist1.MonsterZones[x - 1].Name);
                }
            }
            //////////////////////////////////////////////
        }
    }
}
