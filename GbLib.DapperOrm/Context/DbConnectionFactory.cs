using MicroOrm.Dapper.Repositories.SqlGenerator;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Reflection;

namespace GbLib.DapperOrm.Context
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;
        private readonly SqlProvider _sqlProvider;
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        public DbConnectionFactory(string connectionString, SqlProvider sqlProvider)
        {
            _connectionString = connectionString;
            _sqlProvider = sqlProvider;
        }

        public IDbConnection OpenDbConnection()
        {
            return OpenDbConnection(_connectionString, _sqlProvider);
        }

        public IDbTransaction GetDbTransaction()
        {
            if (_transaction == null)
            {
                _transaction = OpenDbConnection().BeginTransaction();
            }
            return _transaction;
        }

        private IDbConnection OpenDbConnection(string connectionString, SqlProvider providerType)
        {
            // Assume failure.
            //DbConnection connection = null;

            // Create the DbProviderFactory and DbConnection.
            if (_connection == null)
            {
                DbProviderFactory factory = DbProviderFactoryUtils.GetDbProviderFactory(providerType);

                _connection = factory.CreateConnection();
                _connection.ConnectionString = connectionString;
                _connection.Open();
            }
            // Return the connection.
            return _connection;
        }

        internal static class DbProviderFactoryUtils
        {
            public static DbProviderFactory GetDbProviderFactory(SqlProvider type)
            {
                if (type == SqlProvider.MSSQL)
                    return SqlClientFactory.Instance; // this library has a ref to SqlClient so this works

                if (type == SqlProvider.SQLite)
                {
                    return GetDbProviderFactory("Microsoft.Data.Sqlite.SqliteFactory", "Microsoft.Data.Sqlite");
                }
                if (type == SqlProvider.MySQL)
                    return GetDbProviderFactory("MySql.Data.MySqlClient.MySqlClientFactory", "MySql.Data");
                if (type == SqlProvider.PostgreSQL)
                    return GetDbProviderFactory("Npgsql.NpgsqlFactory", "Npgsql");


                throw new NotSupportedException(string.Format("Unsupported Provider Factory", type.ToString()));
            }

            public static DbProviderFactory GetDbProviderFactory(string providerName)
            {
                var providername = providerName.ToLower();

                if (providerName == "system.data.sqlclient")
                    return GetDbProviderFactory(SqlProvider.MSSQL);
                if (providerName == "system.data.sqlite" || providerName == "microsoft.data.sqlite")
                    return GetDbProviderFactory(SqlProvider.SQLite);
                if (providerName == "mysql.data.mysqlclient" || providername == "mysql.data")
                    return GetDbProviderFactory(SqlProvider.MySQL);
                if (providerName == "npgsql")
                    return GetDbProviderFactory(SqlProvider.PostgreSQL);

                throw new NotSupportedException(string.Format("Unsupported Provider Factory", providerName));
            }

            public static DbProviderFactory GetDbProviderFactory(string dbProviderFactoryTypename, string assemblyName)
            {
                var instance = GetStaticProperty(dbProviderFactoryTypename, "Instance");
                if (instance == null)
                {
                    var a = LoadAssembly(assemblyName);
                    if (a != null)
                        instance = GetStaticProperty(dbProviderFactoryTypename, "Instance");
                }

                if (instance == null)
                    throw new InvalidOperationException(string.Format("Unable to retrieve DbProvider Factory Form", dbProviderFactoryTypename));

                return instance as DbProviderFactory;
            }

            #region Reflection Utilities
            //https://github.com/RickStrahl/Westwind.Utilities/blob/master/Westwind.Utilities/Utilities/ReflectionUtils.cs

            /// <summary>
            /// Retrieves a value from  a static property by specifying a type full name and property
            /// </summary>
            /// <param name="typeName">Full type name (namespace.class)</param>
            /// <param name="property">Property to get value from</param>
            /// <returns></returns>
            public static object GetStaticProperty(string typeName, string property)
            {
                Type type = GetTypeFromName(typeName);
                if (type == null)
                    return null;

                return GetStaticProperty(type, property);
            }

            /// <summary>
            /// Returns a static property from a given type
            /// </summary>
            /// <param name="type">Type instance for the static property</param>
            /// <param name="property">Property name as a string</param>
            /// <returns></returns>
            public static object GetStaticProperty(Type type, string property)
            {
                object result = null;
                try
                {
                    result = type.InvokeMember(property, BindingFlags.Static | BindingFlags.Public | BindingFlags.GetField | BindingFlags.GetProperty, null, type, null);
                }
                catch
                {
                    return null;
                }

                return result;
            }

            /// <summary>
            /// Helper routine that looks up a type name and tries to retrieve the
            /// full type reference using GetType() and if not found looking 
            /// in the actively executing assemblies and optionally loading
            /// the specified assembly name.
            /// </summary>
            /// <param name="typeName">type to load</param>
            /// <param name="assemblyName">
            /// Optional assembly name to load from if type cannot be loaded initially. 
            /// Use for lazy loading of assemblies without taking a type dependency.
            /// </param>
            /// <returns>null</returns>
            public static Type GetTypeFromName(string typeName, string assemblyName)
            {
                var type = Type.GetType(typeName, false);
                if (type != null)
                    return type;

                var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                // try to find manually
                foreach (Assembly asm in assemblies)
                {
                    type = asm.GetType(typeName, false);

                    if (type != null)
                        break;
                }
                if (type != null)
                    return type;

                // see if we can load the assembly
                if (!string.IsNullOrEmpty(assemblyName))
                {
                    var a = LoadAssembly(assemblyName);
                    if (a != null)
                    {
                        type = Type.GetType(typeName, false);
                        if (type != null)
                            return type;
                    }
                }

                return null;
            }

            /// <summary>
            /// Overload for backwards compatibility which only tries to load
            /// assemblies that are already loaded in memory.
            /// </summary>
            /// <param name="typeName"></param>
            /// <returns></returns>        
            public static Type GetTypeFromName(string typeName)
            {
                return GetTypeFromName(typeName, null);
            }

            /// <summary>
            /// Try to load an assembly into the application's app domain.
            /// Loads by name first then checks for filename
            /// </summary>
            /// <param name="assemblyName">Assembly name or full path</param>
            /// <returns>null on failure</returns>
            public static Assembly LoadAssembly(string assemblyName)
            {
                Assembly assembly = null;
                try
                {
                    assembly = Assembly.Load(assemblyName);
                }
                catch { }

                if (assembly != null)
                    return assembly;

                if (File.Exists(assemblyName))
                {
                    assembly = Assembly.LoadFrom(assemblyName);
                    if (assembly != null)
                        return assembly;
                }
                return null;
            }
            #endregion
        }
    }
}
