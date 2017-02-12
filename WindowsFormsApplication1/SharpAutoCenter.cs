using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class SharpAutoCenter : Form
    {
        public SharpAutoCenter()
        {
            InitializeComponent();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            BasePriceText.Text = "";
            AdditionalOptionsText.Text = "";
            SubTotalText.Text = "";
            SaleTaxesText.Text = "";
            TotalText.Text = "";
            TradeInAllowanceText.Text = "0";
            AmountDueText.Text = "";
            StereoSystemCheck.Checked = false;
            LeatherInteriorCheck.Checked = false;
            ComputerNavigationCheck.Checked = false;
            StandardRadio.Checked = true;
            //PearlizedRadio.Checked = false;
            //CustomizedDetailingRadio.Checked = false;
            //StereoSystemCheck.CheckState = CheckState.Unchecked;
        }


        private double _steroSystem = 425.76;
        private double _leatherInterior = 987.41;
        private double _computerNavigation = 1741.23;
        private double _standard = 0.0;
        private double _pearlized = 345.72;
        private double _customizedDetailing = 599.99;
        private double _taxRate = 0.13;
        private double _basePrice = 1000.00;
        private double _tradeInAllowance = 800.00;
        private double _subTotal = 0.00;
        //private double _saleTaxes = 0.0;
        //private double _total = 0.0;
        private double _amountDue = 0.0;
        private double _additionalOptions = 0.0;
        private double[] _taxesCal = new double[2];

        private void CalculateButton_Click(object sender, EventArgs e)
        {

            this._basePrice = Convert.ToDouble(BasePriceText.Text.ToString());

            if (this._basePrice < 0) {
                MessageBox.Show("Please Enter value greater or equal to zero for Base Price",
                    "Input Invalid", MessageBoxButtons.OK);
            }

            this._tradeInAllowance = Convert.ToDouble(TradeInAllowanceText.Text.ToString());

            if(this._tradeInAllowance < 0)
            {
                MessageBox.Show("Please Enter value greater or equal to zero for Trade-in Allowance",
                    "Input Invalid", MessageBoxButtons.OK);
            }


            this._subTotal = this._basePrice + this._additionalOptions;
            SubTotalText.Text = this._subTotal.ToString();
            _saleTaxesCalculation(this._subTotal);
            SaleTaxesText.Text = this._taxesCal[0].ToString();
            TotalText.Text = this._taxesCal[1].ToString();

            this._amountDue = this._taxesCal[1] - this._tradeInAllowance;
            AmountDueText.Text = this._amountDue.ToString();

        }

        private void _saleTaxesCalculation(double subTotal) {
            _taxesCal[0] = _subTotal * _taxRate;
            _taxesCal[0] = _subTotal + _taxesCal[0];
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Close();
        }
    }
}
