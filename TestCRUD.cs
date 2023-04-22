// CRUD Program with MySQL database

using CRUD;
using System;

class TestCRUD
{
	public static void Main(String[] args)
	{
		// String ClassName = args[0];
		// Type type = Type.GetType(ClassName);
		// Type ClassType = Type.GetType("CRUD.cCRUDMySQL");
		// Type type = Type.GetType("CRUD.cCRUDMySQL");
		// iCRUD iobjCRUD = (iCRUD)Activator.CreateInstance(type);

		iCRUD iobjCRUD = new cCRUDMySQL();
		iobjCRUD.ShowAccounts();
	}
}