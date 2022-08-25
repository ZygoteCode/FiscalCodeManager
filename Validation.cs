using System.Windows.Forms;
using MetroSuite;
using System;
using System.Diagnostics;

public partial class Validation : MetroForm
{
    public Validation()
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
            if (FiscalCodeSharp.IsFiscalCodeValid(gunaLineTextBox4.Text, gunaLineTextBox1.Text, gunaLineTextBox2.Text, gunaLineTextBox3.Text, siticoneComboBox1.SelectedItem + "/" + siticoneComboBox2.SelectedItem + "/" + siticoneComboBox3.SelectedItem, siticoneRadioButton1.Checked ? FiscalCodeGender.MALE : FiscalCodeGender.FEMALE))
            {
                MessageBox.Show("This fiscal code is valid.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("This fiscal code is not valid.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

    private void Validation_FormClosing(object sender, FormClosingEventArgs e)
    {
        Process.GetCurrentProcess().Kill();
    }
}