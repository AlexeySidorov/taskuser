using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MvvmCross.Platform;
using SQLite;
using Task3.Core.Data;
using Task3.Core.Services;

namespace Task3.Core.DataBaseService
{
    /// <summary>
    /// Создание таблиц в базе данных
    /// </summary>
    public class DataBase
    {
        public void CreateDataBase(List<Assembly> assemblies)
        {
            using (var connection = Mvx.Resolve<IDataBaseService>().GetConnection(Mvx.Resolve<IPlatformService>().GetLocalFilePath(ProjectSettings.DbName)))
            {
                foreach (var types in assemblies.Select(assembly => assembly.DefinedTypes.Where(
                                    t => t.ImplementedInterfaces.Any(i => i == typeof(IEntity)) && t.IsClass)).ToList())
                {
                    // ReSharper disable once PossibleMultipleEnumeration
                    if (!types.Any()) continue;

                    try
                    {
                        connection.BeginTransaction();
                        Migration(connection);

                        // ReSharper disable once PossibleMultipleEnumeration
                        foreach (var type in types)
                            connection.CreateTable(type.AsType(), CreateFlags.AllImplicit);

                        connection.Commit();
                    }
                    catch (Exception)
                    {
                        connection.Rollback();
                        throw;
                    }
                }
            }
        }

        // ReSharper disable once UnusedParameter.Local
        private void Migration(SQLiteConnection connection)
        {

        }
    }
}