using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EElmore_CPT_206_Lab_2
{
 /*
 * Elisabeth Elmore
 * CPT-206-A80H
 * Lab 2
 */
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cityBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.cityBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cityDBDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cityDBDataSet.City' table. You can move, or remove it, as needed.
            this.cityTableAdapter.Fill(this.cityDBDataSet.City); //Import city table

        }

        private void btnAscend_Click(object sender, EventArgs e) //Sort city table by ascending order
        {
            cityBindingSource.Sort = "Population ASC";
        }

        private void btnDescend_Click(object sender, EventArgs e) //Sort city table by desending order
        {
            cityBindingSource.Sort = "Population DESC";
        }

        private void btnName_Click(object sender, EventArgs e) //Sort city table by name
        {
            cityBindingSource.Sort = "City ASC";
        }

        private void btnTotal_Click(object sender, EventArgs e) //Give user total population result
        {
            lblResults.Text = "Total Population: " + 
                cityDBDataSet.City.Compute("SUM(Population)", "");
        }

        private void btnAdv_Click(object sender, EventArgs e) //Give user average population result
        {
            lblResults.Text = "Average Population: " +
                cityDBDataSet.City.Compute("AVG(Population)", "");
        }

        private void btnHighPop_Click(object sender, EventArgs e) //Give user highest population result
        {
            lblResults.Text = "Highest Population: " +
                 cityDBDataSet.City.Compute("MAX(Population)", "");
        }

        private void btnLowPop_Click(object sender, EventArgs e) //Give user lowest population result
        {
            lblResults.Text = "Lowest Population: " +
                cityDBDataSet.City.Compute("MIN(Population)", "");

        }

        private void btnReset_Click(object sender, EventArgs e) //Clear all Fields 
        {
            cityBindingSource.RemoveSort();
            lblResults.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e) //Close form
        {
            this.Close();
        }

      
    }
}
