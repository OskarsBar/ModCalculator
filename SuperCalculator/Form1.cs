using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace SuperCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            
            if (Validation.ValidFormula(input))
            {
                input = SearchUnknowVariables(input);
                textBox3.Text = Solver.RemoveBrackets(input);
            }
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && (!string.IsNullOrWhiteSpace(textBox2.Text)))
            {
                if (Validation.ValidFormula(textBox1.Text)&&Validation.ValidFormulaName(textBox2.Text))
                {
                    ListViewItem lvi = new ListViewItem(textBox2.Text);

                    lvi.SubItems.Add("(" + textBox1.Text + ")");
                    bool isInList = false;
                    foreach(ListViewItem item in listView1.Items)
                    {
                        if (item.SubItems[0].Text == textBox2.Text)
                        {
                            isInList = true;
                        }
                    }
                    if (!isInList)
                    {
                        listView1.Items.Add(lvi);
                    }
                    else
                    {
                        MessageBox.Show("Formul with name ("+textBox2.Text+") already exist");
                    }
                }
                

            }
            else
                MessageBox.Show("Name and Formula filds must not be empty");
            
        }
        public string SearchUnknowVariables(string input)
        {
            int counter = 0;
            string result = "";
            string unknown = "";
            bool unknownFound = false;
            foreach(char character in input)
            {
                counter++;
                if(Char.IsLetter(character))
                {
                    unknownFound = true;
                }
                if (unknownFound&& Char.IsLetter(character))
                {
                    unknown += character;
                }
                if(unknownFound && !Char.IsLetter(character))
                {
                    bool foundInListView = false;
                    foreach (ListViewItem xxx in listView1.Items)
                    {
                        if (xxx.SubItems[0].Text == unknown)
                        {
                            unknown = xxx.SubItems[1].Text;
                            foundInListView = true;
                            break;
                        }
                    }


                    if (foundInListView)
                    {
                        result += SearchUnknowVariables(unknown);
                        unknownFound = false;
                        unknown = "";
                    }
                    else
                    {
                        result += Validation.UnknowReplacer(unknown);
                        unknownFound = false;
                        unknown = "";
                    }
                    
                }
                if(!unknownFound&& !Char.IsLetter(character))
                {
                    result += character;
                }
                if (counter == input.Length&&unknownFound)
                {
                    bool foundInListView = false;
                    foreach (ListViewItem xxx in listView1.Items)
                    {
                        if (xxx.SubItems[0].Text == unknown)
                        {
                            unknown = xxx.SubItems[1].Text;
                            foundInListView = true;
                            break;
                        }
                    }
                    if (foundInListView)
                        result += SearchUnknowVariables(unknown);
                    else
                        result += Validation.UnknowReplacer(unknown);
                }
            }
            return result;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
                if (item.Selected)
                    listView1.Items.Remove(item);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem("Sum");
            lvi.SubItems.Add("2+3");
            ListViewItem lvi2 = new ListViewItem("Multi");
            lvi2.SubItems.Add("2*5");
            ListViewItem lvi3 = new ListViewItem("Test");
            lvi3.SubItems.Add("4+4*((Sum/2)+Multi)");
            listView1.Items.Add(lvi);
            listView1.Items.Add(lvi2);
            listView1.Items.Add(lvi3);
            textBox1.Text = "6+(Test*(Sum+Multi))-x";

        }
    }
}
