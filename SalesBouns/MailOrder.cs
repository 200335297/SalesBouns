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
        private string _EmployeeName;
        private string _EmployeeId;
        private string _HoursWorked;
        private string _TotalSales;
        private double _TotalSalesBouns;
        private double _value;
        private double _phours;
        private double _totalsalesamount;

        public MailOrder()
        {
            InitializeComponent();
        }

        private void calculate()
        {
            this._EmployeeName = Employeename.Text;
            this._EmployeeId = EmployeeId.Text;
            this._HoursWorked = HoursWorked.Text;
            this._TotalSales = TotalSales.Text;
            if (Isnumberandnegative(this._HoursWorked))
            {
                this._phours = (Convert.ToDouble(this._HoursWorked))/160;
            }
            if (Isnumberandnegative(this._TotalSales))
            {
                this._totalsalesamount = (Convert.ToDouble(this._TotalSales))*(0.02);
            }
            this._TotalSalesBouns = (this._phours) * (this._totalsalesamount);
            SalesBouns.Text = Convert.ToString(this._TotalSalesBouns);
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

       private void CalculateSales(object sender, EventArgs e)
        {
            Button salesbutton = sender as Button;

            switch (salesbutton.Tag.ToString())
            {
                case "calculate":
                    this.calculate();
                    break;
            }
        }
    }
}
