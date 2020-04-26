namespace AbpVnext.Learn
{
    public static class LearnDbProperties
    {
        public static string DbTablePrefix { get; set; } = "Learn";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "Learn";
    }
}
