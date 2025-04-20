using MetroSuite;
using System.Diagnostics;
using System.Windows.Forms;

public partial class Reverse : MetroForm
{
    public Reverse()
    {
        InitializeComponent();
        Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;
        CheckForIllegalCrossThreadCalls = false;
    }

    private void gunaButton1_Click(object sender, System.EventArgs e)
    {
        metroLabel1.Text = FiscalCodeSharp.GetMostProbableDateOfBirth(gunaLineTextBox1.Text);
        metroLabel2.Text = FiscalCodeSharp.GetBirthPlace(gunaLineTextBox1.Text);
        metroLabel3.Text = FiscalCodeSharp.GetGender(gunaLineTextBox1.Text) == FiscalCodeGender.MALE ? "Male" : "Female";
    }

    private void gunaButton2_Click(object sender, System.EventArgs e)
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

    private void Reverse_FormClosing(object sender, FormClosingEventArgs e)
    {
        Process.GetCurrentProcess().Kill();
    }
}