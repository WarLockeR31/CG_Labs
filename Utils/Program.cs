namespace Lab3
{
    internal static class Program
    {
        private static NavigatorContext? Nav;

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Nav = new NavigatorContext(new Form1a());
            Application.Run(Nav); 
        }

        public static void LoadForm(int idx)
        {
            Form next = idx switch
            {
                1 => new Form1a(),
                2 => new Form1b(),
                3 => new Form1c(),
                4 => new Form2(),
                5 => new Form3(),
                _ => new SwitchableForm(),
            };
            
            if (next != null) 
                Nav!.Show(next);
        }
    }

    public sealed class NavigatorContext : ApplicationContext
    {
        public NavigatorContext(Form start) { Show(start); }

        public void Show(Form next)
        {
            
            next.FormClosed += (s, e) =>
            {
                if (s == MainForm) 
                    ExitThread();
            };

            // Position and scale
            if (MainForm != null)
            {
                var srcBounds = MainForm.WindowState == FormWindowState.Normal
                    ? MainForm.Bounds
                    : MainForm.RestoreBounds;

                next.StartPosition = FormStartPosition.Manual;
                next.Bounds = srcBounds;

                if (MainForm.WindowState == FormWindowState.Maximized)
                    next.WindowState = FormWindowState.Maximized;
            }

            if (MainForm == null)
            {
                MainForm = next;
                next.Show();
                return;
            }

            var old = MainForm;
            MainForm = next;
            next.Show();
            old.Close();
        }
    }
}