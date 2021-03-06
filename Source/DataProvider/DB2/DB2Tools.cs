﻿using System;
using System.Data;
using System.Reflection;

namespace LinqToDB.DataProvider.DB2
{
	using Data;

	public static class DB2Tools
	{
		static readonly DB2DataProvider _db2DataProvider = new DB2DataProvider();

		static DB2Tools()
		{
			DataConnection.AddDataProvider(_db2DataProvider);
		}

		public static IDataProvider GetDataProvider()
		{
			return _db2DataProvider;
		}

		public static void ResolveDB2(string path)
		{
			new AssemblyResolver(path, "IBM.Data.DB2");
		}

		public static void ResolveDB2(Assembly assembly)
		{
			new AssemblyResolver(assembly, "IBM.Data.DB2");
		}

		#region CreateDataConnection

		public static DataConnection CreateDataConnection(string connectionString)
		{
			return new DataConnection(_db2DataProvider, connectionString);
		}

		public static DataConnection CreateDataConnection(IDbConnection connection)
		{
			return new DataConnection(_db2DataProvider, connection);
		}

		public static DataConnection CreateDataConnection(IDbTransaction transaction)
		{
			return new DataConnection(_db2DataProvider, transaction);
		}

		#endregion
	}
}
