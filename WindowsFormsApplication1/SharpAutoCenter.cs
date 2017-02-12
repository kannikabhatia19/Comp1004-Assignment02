/* 
 * App name : SharpAutoCenter
 * Author's Name: Kannika Bhatia
 * Student ID: 200332992
 * App Creation Date: Sunday, 12, Feb, 2017
 * App Description: This program calculates the amount due on a new our used vehicle
 */


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
        //Variables that are used in the calculation
        private double _taxRate = 0.13;
        private double _basePrice = 0.00;
        private double _tradeInAllowance = 0.00;
        private double _subTotal = 0.00;
        private double _amountDue = 0.0;
        private double _additionalOptions = 0.0;
        //_taxesCal[0] is for sale taxes
        //_taxesCal[1] is for total
        private double[] _taxesCal = new double[2];

        public SharpAutoCenter()
        {
            InitializeComponent();
        }
        /// <summary>
        /// This method is for clearing all the textbox and set the
        /// trade-in allowance to zero. All the checkboxs are set to uncheck
        /// The standard radiobutton is checked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            StereoSystemCheck.Checked = false;
            LeatherInteriorCheck.Checked = false;
            ComputerNavigationCheck.Checked = false;
            StandardRadio.Checked = true;

            this._basePrice = 0.00;
            this._tradeInAllowance = 0.00;
            this._subTotal = 0.00;
            this._amountDue = 0.00;
            this._additionalOptions = 0.00;
            this._taxesCal[0] = 0.00;
            this._taxesCal[1] = 0.00;

            BasePriceText.Text = "";
            AdditionalOptionsText.Text = "";
            SubTotalText.Text = "";
            SaleTaxesText.Text = "";
            TotalText.Text = "";
            TradeInAllowanceText.Text = "0";
            AmountDueText.Text = "";
        }
        /// <summary>
        /// This method is for calculating the amount due. 
        /// If user input invalid information in either BasePrice or Trade-in Allowance, 
        /// the messagebox will display the error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculateButton_Click(object sender, EventArgs e)
        {

            this._basePrice = Convert.ToDouble(BasePriceText.Text.ToString());
            this._tradeInAllowance = Convert.ToDouble(TradeInAllowanceText.Text.ToString());

            if (this._basePrice >= 0 && this._tradeInAllowance >= 0) {
                this._subTotal = this._basePrice + this._additionalOptions;
                SubTotalText.Text = this._subTotal.ToString();
                _saleTaxesCalculation(this._subTotal);
                SaleTaxesText.Text = this._taxesCal[0].ToString();
                TotalText.Text = this._taxesCal[1].ToString();

                this._amountDue = this._taxesCal[1] - this._tradeInAllowance;
                AmountDueText.Text = this._amountDue.ToString();
            }
            else 
            {
                String _errMessage = "";
                if (this._basePrice < 0) {
                    _errMessage += "Please Enter value greater or equal to zero for Base Price\n";
                }
                if(this._tradeInAllowance < 0)
                {
                    _errMessage += "Please Enter value greater or equal to zero for Trade-in Allowance";
                }
                MessageBox.Show(_errMessage,"Invalid Input", MessageBoxButtons.OK);
            }
        }
        /// <summary>
        /// This method calculate saleTaxes and Total which is subTotal + saleTaxes.
        /// By using array, this method can return void
        /// </summary>
        /// <param name="subTotal"></param>
        private void _saleTaxesCalculation(double subTotal) {
            _taxesCal[0] = _subTotal * _taxRate;
            _taxesCal[1] = _subTotal + _taxesCal[0];
        }
        /// <summary>
        /// This method is for closing the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// This method is to calculate the additional options.
        /// If user select one item, the price of that item will be added to the
        /// additional options.
        /// If user changes mind and select new item, the price of past item will be
        /// deducted and the price of the new item will be added to the additional options
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Radio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton _radioButton = sender as RadioButton;
            if (_radioButton.Checked == true) {
                this._additionalOptions += Convert.ToDouble(_radioButton.Tag.ToString());
            }
            else
            {
                this._additionalOptions -= Convert.ToDouble(_radioButton.Tag.ToString());
                if (this._additionalOptions < 0) {
                    this._additionalOptions = 0;
                }
            }

            AdditionalOptionsText.Text = this._additionalOptions.ToString();
        }

        /// <summary>
        /// This method is to handle all the checkboxes. If the checkbox is checked, 
        /// the amount will be added to the additionOptions. If the checkbox changes to 
        /// unchecked, the price of that item will be deducted from the additionOptions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkboxCheckedChanged(object sender, EventArgs e)
        {
            CheckBox _checkBoxObj = sender as CheckBox;
            if (_checkBoxObj.Checked == true) {
                this._additionalOptions += Convert.ToDouble(_checkBoxObj.Tag.ToString());
            }
            else
            {
                this._additionalOptions -= Convert.ToDouble(_checkBoxObj.Tag.ToString());
                if (this._additionalOptions < 0)
                {
                    this._additionalOptions = 0;
                }
            }

            AdditionalOptionsText.Text = this._additionalOptions.ToString();

        }

        /// <summary>
        /// This method is for descriping the application to the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This program calculates the amount due on a new our used vehicle", "About", MessageBoxButtons.OK);
        }
    }
}
