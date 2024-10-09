

namespace TechShop.Exceptions
{
    public static class ExceptionHandler
    {
        public static void HandleException(Exception ex)
        {
            // Log the exception (e.g., to a file, database, or logging service)
            LogException(ex);

            // Display a user-friendly message
            Console.WriteLine("An error occurred. Please try again later.");
        }

        private static void LogException(Exception ex)
        {
            // Example: Log to a file
            string logFilePath = "error.log";
            using StreamWriter writer = new StreamWriter(logFilePath, true);
            writer.WriteLine($"{DateTime.Now}: {ex.Message}");
            writer.WriteLine(ex.StackTrace);
        }
    }
}