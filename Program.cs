namespace project_temporature
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            using (var loginForm = new Login())        //此处设置一个变量loginForm，代表登陆窗体
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {       //shouDialog是模态对话框，仅当DialogResult为OK的时候，才会继续下去
                    Application.Run(new CollectPLC());
                }
            }
        }
    }
}