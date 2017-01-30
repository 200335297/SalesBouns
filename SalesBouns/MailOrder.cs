/// App name: SalesBouns Calculator
/// Author's Name: Gowtham Talluri(200335297)
/// App Creation Date: Jan 23, 2017
/// App Description: This app is used to calculate sale bouns amount based on hours worked and sale amount

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesBouns
{
    public partial class MailOrder : Form
    {
        //private instance variables
        private double _TotalSalesBouns;
        private double _value;
        private double _phours;
        private double _totalsalesamount;
        
        // MailOrder Constructor
        public MailOrder()
        {
            InitializeComponent();
            this._textclear();
        }


        /// <summary>
        /// This function grab the user data and calculate salesbouns amount
        /// </summary>


        private void calculate()
        {
            if (Isnumberandnegative(HoursWorked.Text) && (Convert.ToDouble(HoursWorked.Text)) <= 160)
            {

                this._phours = (Convert.ToDouble(HoursWorked.Text)) / 160;
 }
            else
            {
                this.errorfunction("Incorrect Hours Data", "Error");
 }
            if (TotalSales.Text != string.Empty)
            {
                if (TotalSales.Text.Substring(0, 1) == "$")
                {
                    if (Isnumberandnegative(TotalSales.Text.Substring(1)))
                    {
                        this._totalsalesamount = Convert.ToDouble(TotalSales.Text.Substring(1)) * 0.02;
                    }
                    else
                    {
                        this.errorfunction("Incorrect sales Amount", "Error");

                        TotalSales.Text = string.Empty;

                    }

                }
                else
                {
                    if (Isnumberandnegative(TotalSales.Text))
                    {
                        this._totalsalesamount = Convert.ToDouble(TotalSales.Text) * 0.02;
                    }
                    else
                    {
                        this.errorfunction("Incorrect sales Amount", "Error");
                        TotalSales.Text = string.Empty;

                    }

                    TotalSales.Text = "$" + TotalSales.Text;
                }
            }
            else
            {
                this.errorfunction("Incorrect sales Amount", "Error");
                TotalSales.Text = string.Empty;

            }

            if (this._phours != 0 && this._totalsalesamount != 0)
            {
                this._TotalSalesBouns = (this._phours) * (this._totalsalesamount);
                SalesBouns.Text = Convert.ToString(this._TotalSalesBouns);
                this._phours = 0;
                this._totalsalesamount = 0;
                this._TotalSalesBouns = 0;
            }
            else
            {
                this.SalesBouns.Text = string.Empty;
            }
        }
       
        //This function will execute for print button
        private void print()
        {
            
            this.errorfunction("The form is being sent to the printer.", "Print");

                }

        /// <summary>
        /// This function clears the fields text
        /// </summary>

        private void _textclear()
        {
            this.Employeename.Focus();
            this.Employeename.Text = string.Empty;
            this.EmployeeId.Text = string.Empty;
            this.HoursWorked.Text = string.Empty;
            this.SalesBouns.Text = string.Empty;
        }

        /// <summary>
        /// This function is used to display messages
        /// </summary>
        private void errorfunction(string message,string val)
        {
            MessageBox.Show(message,val);
        }

        private bool Isnumberandnegative(string hoursandsales)
        {
            if (Double.TryParse(hoursandsales, out _value))
            {
                if (_value>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }else
            {
                return false;
            }


        }

        /// <summary>
        /// Event Handler for all SalesBouns Buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void CalculateSales(object sender, EventArgs e)
        {
            Button salesbutton = sender as Button;

            switch (salesbutton.Tag.ToString())
            {
                case "calculate":
                    this.calculate();
                    break;
                case "clear":
                    this._textclear();
                    break;
                case "print":
                    this.print();
                    break;
            }
        }

        /// <summary>
        /// This function translates lables and button text to english
        /// </summary>
        
        private void translateenglish()
        {
            this.button1.Text = "Calculate";
            this.button2.Text = "Print";
            this.button3.Text = "Clear";
            this.label1.Text = "Employee\'s Name :";
            this.label2.Text = "Empolyee Id :";
            this.label3.Text = "Hours Worked :";
            this.label4.Text = "Total Sales :";
            this.label5.Text = "Sales Bonus :";
            this.groupBox1.Text = "Languages";

        }

        /// <summary>
        /// This function translates lables and button text to french when french button is selected
        /// </summary>

        private void translatefrench()
        {
            this.button1.Text = "Calculer";
            this.button2.Text = "Impression";
            this.button3.Text = "Clair";
            this.label1.Text = "Le nom de l\'employé :";
            this.label2.Text = "Id d'Empolyee :";
            this.label3.Text = "Heures travaillées :";
            this.label4.Text = "Ventes totales:";
            this.label5.Text = "Bonus de vente :";
            this.groupBox1.Text = "Langues";


        }

        /// <summary>
        /// Event Handler for all SalesBouns Lnaguage Group Buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void LanguageChange(object sender, EventArgs e)
        {
            RadioButton languagebutton = sender as RadioButton;
            switch (languagebutton.Tag.ToString())
            {
                case "english":
                    this.translateenglish();
                    break;
                case "france":
                    this.translatefrench();
                    break;
            }


        }
    }
}
