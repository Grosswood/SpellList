using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpellList
{
    public partial class Form1 : Form
    {
        public string searchFor;
        List<spell> allSpells = new List<spell>();

        
        public void createSpellList()
        {
            int counter = 0;
            string currentLine = "-";
            var fileName = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "SpellList.txt");
            System.IO.StreamReader file = new System.IO.StreamReader(fileName);
            while ((currentLine = file.ReadLine()) != null)
            {
                assign(counter, currentLine);
                counter++;
            }
            file.Close();
        }

        public void assign(int lineNumber, string stringToInput)
        {
            int spellNumber = lineNumber / 10;
            int valueNumber = lineNumber % 10;
            spell newSpell = new spell();
            
            if (valueNumber == 0)
            {
                allSpells.Add(newSpell);
                allSpells[spellNumber].name = stringToInput;
            }
            if (valueNumber == 1)
            {
                allSpells[spellNumber].level = stringToInput;
            }
            if (valueNumber == 2)
            {
                allSpells[spellNumber].school = stringToInput;
            }
            if (valueNumber == 3)
            {
                allSpells[spellNumber].castingTime = stringToInput;
            }
            if (valueNumber == 4)
            {
                allSpells[spellNumber].range = stringToInput;
            }
            if (valueNumber == 5)
            {
                allSpells[spellNumber].components = stringToInput;
            }
            if (valueNumber == 6)
            {
                allSpells[spellNumber].duration = stringToInput;
            }
            if (valueNumber == 7)
            {
                allSpells[spellNumber].description = stringToInput;
            }
            if (valueNumber == 8)
            {
                
            }
            if (valueNumber == 9)
            {

            }
        }

        private void writeSpell(spell spellName)
        {
            this.label20.Text = spellName.name;
            this.label21.Text = spellName.level;
            this.label22.Text = spellName.school;
            this.label23.Text = spellName.castingTime;
            this.label24.Text = spellName.range;
            this.label25.Text = spellName.components;
            this.label26.Text = spellName.duration;
            this.label27.Text = spellName.description;
            this.label28.Text = "-";
            this.label29.Text = "-";
        }

        public void searchByName()
        {
            if (allSpells[0].name.Contains(searchFor))
            {
                this.button2.Visible = true;
                this.button2.Text = allSpells[0].name;
            }
            else
            {
                this.button2.Visible = false;
            }
            if (allSpells[1].name.Contains(searchFor))
            {
                this.button3.Visible = true;
                this.button3.Text = allSpells[1].name;
            }
            else
            {
                this.button3.Visible = false;
            }

        }
        
        public Form1()
        {
            InitializeComponent();
            createSpellList();
            //writeSpell(allSpells[0]);
            this.button2.Visible = false;
            this.button3.Visible = false;
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            searchFor = this.textBox1.Text;
            searchByName();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            writeSpell(allSpells[0]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            writeSpell(allSpells[1]);
        }

    }

    class spell
    {
        public string name;
        public string level;
        public string school;
        public string castingTime;
        public string range;
        public string components;
        public string duration;
        public string description;
    }
}
