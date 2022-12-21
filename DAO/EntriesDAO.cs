using Sensitive;
using Models;
using System.Data.SqlClient;
using System.Collections.Generic;
using CustomExceptions;

namespace DAO;

//The purpose of this layer is to execute the SQL statements to the database

public class EntriesDAO 
{
	//the connection string from azure (class level variable)
    string connectionString = SensitiveVariables.dbConnString;		
	public List<Entries> CheckEntries() 
	{
		List<Entries> transactions = new List<Entries>();

        //this defines the sql statement we'd like to execute
        string sql = "select * from tabapp.entries;"; //could I do drop table tabapp.entries; here? probably no cause diff language types

		//data type for an active connection
		SqlConnection connection = new SqlConnection(connectionString);
		//data type to reference the sql command you want to do to a specific connection
		SqlCommand command = new SqlCommand(sql, connection);

		try 
		{
		   //opening the connection to the database
		   connection.Open();
		   //storing the result set of a DQL statement into a variable
		   SqlDataReader reader = command.ExecuteReader(); //I'll likely need to modify this for drop table
		   while (reader.Read()) 
		   {
		   	  transactions.Add(new Entries((int)reader[0], (double)reader[1], (double)reader[2], (string)reader[3]));
		   }
		   reader.Close();
		   connection.Close();
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}

           return transactions;
	}
	public void SubtractFromEntry(Entries entry1, double money, string description) 
	{
		//this defines the sql statement we'd like to execute
        string sql = "insert into tabapp.entries (David_Owes, Andre_Owes, Description) values (@davidOwes, @andreOwes, @description);";

		//data type for an active connection
		SqlConnection connection = new SqlConnection(connectionString);
		//data type to reference the sql command you want to do to a specific connection
		SqlCommand command = new SqlCommand(sql, connection);
		command.Parameters.AddWithValue("@davidOwes", entry1.davidOwes); 
        command.Parameters.AddWithValue("@andreOwes", entry1.andreOwes - money); //could I just reference an older value from the database here?
        command.Parameters.AddWithValue("@description", description); //AddWithValue assigns variable values
		try 
		{
		   //opening the connection to the database
		   connection.Open();
		   //this is for DML statements
		   int rowsAffected = command.ExecuteNonQuery();
		  
		   if (rowsAffected != 0)
		   {
		   	  Console.WriteLine("This many rows were affected: " + rowsAffected);
		   }
		 
		   connection.Close();
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
		
	}
    public void AddToEntry(Entries entry1, double money, string description) 
    {
    	//this defines the sql statement we'd like to execute
        string sql = "insert into tabapp.entries (David_Owes, Andre_Owes, Description) values (@davidOwes, @andreOwes, @description);";
       
		//data type for an active connection
		SqlConnection connection = new SqlConnection(connectionString);
		//data type to reference the sql command you want to do to a specific connection
		SqlCommand command = new SqlCommand(sql, connection);
		command.Parameters.AddWithValue("@davidOwes", entry1.davidOwes); 
        command.Parameters.AddWithValue("@andreOwes", entry1.andreOwes + money); //could I just reference an older value from the database here?
        command.Parameters.AddWithValue("@description", description); //AddWithValue assigns variable values
		try 
		{
		   //opening the connection to the database
		   connection.Open();
		   //this is for DML statements
		   int rowsAffected = command.ExecuteNonQuery();
		  
		   if (rowsAffected != 0)
		   {
		   	Console.WriteLine("This many rows were affected: " + rowsAffected);
		   }
		 
		   connection.Close();

		   
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
    }
    public void AddToEntryDave(Entries entry1, double money, string description) 
    {
    	//this defines the sql statement we'd like to execute
        string sql = "insert into tabapp.entries (David_Owes, Andre_Owes, Description) values (@davidOwes, @andreOwes, @description);";
       
		//data type for an active connection
		SqlConnection connection = new SqlConnection(connectionString);
		//data type to reference the sql command you want to do to a specific connection
		SqlCommand command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@davidOwes", entry1.davidOwes + money); //could I just reference an older value from the database here?
        command.Parameters.AddWithValue("@andreOwes", entry1.andreOwes); 
        command.Parameters.AddWithValue("@description", description); //AddWithValue assigns variable values
		try 
		{
		   //opening the connection to the database
		   connection.Open();
		   //this is for DML statements
		   int rowsAffected = command.ExecuteNonQuery();
		  
		   if (rowsAffected != 0)
		   {
		   	Console.WriteLine("This many rows were affected: " + rowsAffected);
		   }
		 
		   connection.Close();

		   
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
    }

    public void SubtractFromEntryDave(Entries entry1, double money, string description) 
    {
    	//this defines the sql statement we'd like to execute
        string sql = "insert into tabapp.entries (David_Owes, Andre_Owes, Description) values (@davidOwes, @andreOwes, @description);";
       
		//data type for an active connection
		SqlConnection connection = new SqlConnection(connectionString);
		//data type to reference the sql command you want to do to a specific connection
		SqlCommand command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@davidOwes", entry1.davidOwes - money); //could I just reference an older value from the database here?
        command.Parameters.AddWithValue("@andreOwes", entry1.andreOwes); 
        command.Parameters.AddWithValue("@description", description); //AddWithValue assigns variable values
		try 
		{
		   //opening the connection to the database
		   connection.Open();
		   //this is for DML statements
		   int rowsAffected = command.ExecuteNonQuery();
		  
		   if (rowsAffected != 0)
		   {
		   	Console.WriteLine("This many rows were affected: " + rowsAffected);
		   }
		 
		   connection.Close();

		   
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
    }

    public void UpdateEntry(string description, int ID) 
    {
    	//this defines the sql statement we'd like to execute
        string sql = "UPDATE tabapp.entries SET Description = @description WHERE Transaction_ID = @ID;";
       
		//data type for an active connection
		SqlConnection connection = new SqlConnection(connectionString);
		//data type to reference the sql command you want to do to a specific connection
		SqlCommand command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@description", description); //AddWithValue assigns variable values
        command.Parameters.AddWithValue("@ID", ID);
		try 
		{
		   //opening the connection to the database
		   connection.Open();
		   //this is for DML statements
		   int rowsAffected = command.ExecuteNonQuery();
		  
		   if (rowsAffected != 0)
		   {
		   	Console.WriteLine("This many rows were affected: " + rowsAffected);
		   }
		 
		   connection.Close();

		   
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
    }

    public Entries GetTransaction() 
    {
    	string sql = "select top 1 * from tabapp.entries order by Transaction_ID desc;";

    	SqlConnection connection = new SqlConnection(connectionString);
		//data type to reference the sql command you want to do to a specific connection
		SqlCommand command = new SqlCommand(sql, connection);
             
        Entries mostRecent = new Entries(); 
		try 
		{
		   //opening the connection to the database
		   connection.Open();
		   //storing the result set of a DQL statement into a variable
		   SqlDataReader reader = command.ExecuteReader(); //I'll likely need to modify this for drop table
		   while (reader.Read()) 
		   {
		   	  mostRecent = new Entries((int)reader[0], (double)reader[1], (double)reader[2], (string)reader[3]);
		   }

		   reader.Close();
		   connection.Close();
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}

         return mostRecent; 
    }


}