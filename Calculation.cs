using System.Diagnostics;
using MetroSuite;
using System;
using System.Windows.Forms;

public partial class Calculation : MetroForm
{
    public Calculation()
    {
        InitializeComponent();
        Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;
        CheckForIllegalCrossThreadCalls = false;

        for (int i = 1; i <= 31; i++)
        {
            if (i.ToString().Length == 1)
            {
                siticoneComboBox1.Items.Add("0" + i);
            }
            else
            {
                siticoneComboBox1.Items.Add(i);
            }
        }

        for (int i = 1; i <= 12; i++)
        {
            if (i.ToString().Length == 1)
            {
                siticoneComboBox2.Items.Add("0" + i);
            }
            else
            {
                siticoneComboBox2.Items.Add(i);
            }
        }

        for (int i = 1900; i <= DateTime.Now.Year; i++)
        {
            siticoneComboBox3.Items.Add(i);
        }

        siticoneComboBox1.SelectedIndex = 0;
        siticoneComboBox2.SelectedIndex = 0;
        siticoneComboBox3.SelectedIndex = 0;
    }

    private void gunaButton1_Click(object sender, EventArgs e)
    {
        try
        {
            gunaLineTextBox4.Text = FiscalCodeSharp.GenerateFiscalCode(gunaLineTextBox1.Text, gunaLineTextBox2.Text, gunaLineTextBox3.Text, siticoneComboBox1.SelectedItem + "/" + siticoneComboBox2.SelectedItem + "/" + siticoneComboBox3.SelectedItem, siticoneRadioButton1.Checked ? FiscalCodeGender.MALE : FiscalCodeGender.FEMALE);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void gunaButton2_Click(object sender, EventArgs e)
    {
        MainForm mainForm = new MainForm();
        mainForm.Show();
        Reset();
    }

    public void Reset()
    {
        this.Hide();
        this.Opacity = 0;
        this.Visible = false;
        this.Enabled = false;
        this.Size = new System.Drawing.Size(0, 0);

        foreach (Control control in Controls)
        {
            Controls.Remove(control);
        }
    }

    private void Calculation_FormClosing(object sender, FormClosingEventArgs e)
    {
        Process.GetCurrentProcess().Kill();
    }
}