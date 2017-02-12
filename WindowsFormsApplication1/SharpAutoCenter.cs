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

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
