using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSixteenthProgram
{
    internal static class ConstantsForConnectionToDB
    {
        public const string Login = "postgres";
        public const string Password = "postgres";
        public const string Host = "localhost";
        public const string Port = "5432";
        public const string DbName = "Shop";

        public static string ConnectionString { get; } = $"User ID={Login};Password={Password};Host={Host};Port={Port};Database={DbName};";

    }
}
