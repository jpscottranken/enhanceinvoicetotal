using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnhancedInvoiceTotalGUI
{
    public partial class frmEnhancedInvoiceTotal : Form
    {
        public frmEnhancedInvoiceTotal()
        {
            InitializeComponent();
        }

        //  Set program constant
        const decimal DISCOUNT_PERCENT = 0.25m;

        //  Set class-level variables
        int numInvoices             = 0;
        decimal totalOfAllInvoices  = 0m;
        decimal totalInvoiceAverage = 0m;

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            decimal subtotal        = Convert.ToDecimal(txtEnterSubtotal.Text);
            decimal discountAmount  = subtotal * DISCOUNT_PERCENT;
            decimal total           = subtotal - discountAmount;

            //  Put associated values into associated textboxes
            txtSubtotal.Text        = subtotal.ToString("c");
            txtDiscountAmount.Text  = discountAmount.ToString("c");
            txtTotal.Text           = total.ToString("c");

            //  Total number of invoices
            ++numInvoices;
            txtNumberOfInvoices.Text = numInvoices.ToString();

            //  Total of all invoices amount
            totalOfAllInvoices += total;
            txtTotalOfInvoices.Text = totalOfAllInvoices.ToString("c");

            //  Total average invoice amount
            totalInvoiceAverage = totalOfAllInvoices / numInvoices;
            txtInvoiceAverage.Text = totalInvoiceAverage.ToString("c");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEnterSubtotal.Text   = "";
            txtSubtotal.Text        = "";
            txtDiscountAmount.Text  = "";
            txtTotal.Text           = "";
            txtEnterSubtotal.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show(
                "Do You Really Want To Exit?",
                "EXIT NOW?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void frmEnhancedInvoiceTotal_Load(object sender, EventArgs e)
        {
            txtDiscountPercent.Text = DISCOUNT_PERCENT.ToString("p");
        }
    }
}
