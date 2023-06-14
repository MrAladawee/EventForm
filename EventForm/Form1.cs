namespace EventForm
{
    public partial class Form1 : Form
    {
        private const int maxVal = 20000000;
        private SeqSummator ss = new SeqSummator(maxVal);
        private ParSummator ps = new ParSummator(maxVal);
        public Form1()
        {
            InitializeComponent();
        }

        private void onProgress()
        {
            if (progressBar1.InvokeRequired)
            {
                Invoke(onProgress);
            }
            else
            {
                progressBar1.Value++;
            }
        }

        private void ShowResult()
        {
            // � Finish �� ���������� �� Thread, � ��������� � Main Thread
            // ��� �������� Form'����� ����������

            // ����� � ������� ����������� ����� �������� ��� ���? �� ������ ��������� ���.
            // ����������� ��� ������ ��� �� ����� ������� �����������, ������� � ����������
            // ������� �������� ���� ������������� ��������� � ��� �� ��������� ������, � �� �� ������
            // �� ��� � ������� �������� �������:
            // True - ��������� �� ������� ������, �� � ���, � ������� �������
            // False - ����� �� ���� ������, � ������� �������
            if (lblParSum.InvokeRequired)
            {
                Invoke(ShowResult); // Invoke = �����; ��������� ����� ������ �� ��������� ������
                                    // ���� ��� ���, �� ������������ ����� ��������� ��������� ������� Main Thread
                                    // ����� ��������� ��������� �� �������� ������ (���������� ������������ ������)
                                    // ����� ������� Invoke ����� �������� � if � InvokeRuqires = false � � if �� ������.
                                    // (����������� �����)
            }
            else 
            { 
                lblParSum.Text = ps.Result.ToString();
                progressBar1.Value = 100;
            }
        }

        private void btnStartSeqSum_Click(object sender, EventArgs e)
        {
            ss.Sum();
            lblSeqSum.Text = ss.Result.ToString();
            ps.Finish += ShowResult;
            ps.Progress += onProgress;
            progressBar1.Value = 0;
            ps.Sum();
        }
    }
}