namespace Examination.Infrastructure.SeedWork
{
    public class ExamSettings
    {
        public string IdentityUrl { get; set; }

        public DatabaseSettings DatabaseSettings { get; set; }
    }

    public class DatabaseSettings
    {
        public string ConnectionString { set; get; }
        public string DatabaseName { get; set; }

    }
}