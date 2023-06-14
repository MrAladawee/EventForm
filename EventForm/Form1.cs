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
            // К Finish мы обращаемся из Thread, а создается в Main Thread
            // Это проблема Form'енных приложений

            // Поток в котором выполняется метод основной или доп? Мы должны проверить это.
            // Проверяется при помощи тех же самых классов компонентов, которые и используем
            // Создают головную боль заставляением обращения к ним из основного потока, а не из левого
            // но они и создают средства решения:
            // True - обращение из другого потока, не в том, в котором создана
            // False - вызов из того потока, в котором создана
            if (lblParSum.InvokeRequired)
            {
                Invoke(ShowResult); // Invoke = вызов; требуется вызов метода из основного потока
                                    // Если это так, то перевызываем метод ШоуРезалт пользуясь методом Main Thread
                                    // Метод ШоуРезалт вызовется из главного потока (произойдет переключение потока)
                                    // Когда вызовем Invoke снова перейдем в if и InvokeRuqires = false и в if не войдем.
                                    // (рекурсивный вызов)
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