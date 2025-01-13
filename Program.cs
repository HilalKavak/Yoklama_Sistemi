namespace bseu_yoklama_sistemi1
{
    internal static class Program
    {
        public static string CurrentTeacher;
        public static string CurrentTeacherNameSurname;
        public static string CurrentUser;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}