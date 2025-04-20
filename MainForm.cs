using System.Windows.Forms;
using MetroSuite;
using System.Diagnostics;

public partial class MainForm : MetroForm
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void gunaButton4_Click(object sender, System.EventArgs e)
    {
        Application.Exit();
    }

    private void gunaButton1_Click(object sender, System.EventArgs e)
    {
        Calculation calculation = new Calculation();
        calculation.Show();
        Reset();
    }

    private void gunaButton2_Click(object sender, System.EventArgs e)
    {
        Validation validation = new Validation();
        validation.Show();
        Reset();
    }

    private void gunaButton3_Click(object sender, System.EventArgs e)
    {
        Reverse reverse = new Reverse();
        reverse.Show();
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

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        Process.GetCurrentProcess().Kill();
    }
}