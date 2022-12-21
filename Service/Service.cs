using System.Data.SqlClient;
using DAO;
using Models;
using System.Collections.Generic;
using CustomExceptions;

namespace Services;

public class EntryService
{
    EntriesDAO entry = new EntriesDAO();

    public List<Entries> CheckEntries() 
    {
    	return entry.CheckEntries();
     
    }

    public void SubtractFromEntry(Entries entry1, double money, string description) 
    {
      double cleansed = 0; 
      if (money < 0)
      {
        cleansed = Math.Abs(money);
        entry.SubtractFromEntry(entry1, cleansed, description);
      }
      else 
      {       	
        entry.SubtractFromEntry(entry1, money, description); 
      }
    }

    public void AddToEntry(Entries entry1, double money, string description) 
    {
      //doing business logic here
      double cleansed = 0; 
      if (money < 0)
      {
        cleansed = Math.Abs(money);
        entry.AddToEntry(entry1, cleansed, description);
      }
      else 
      {
        entry.AddToEntry(entry1, money, description);
      }
    }

    public void AddToEntryDave(Entries entry1, double money, string description)
    {
      double cleansed = 0; 
      if (money < 0)
      {
        cleansed = Math.Abs(money);
        entry.AddToEntryDave(entry1, cleansed, description);
      }
      else 
      {
        entry.AddToEntryDave(entry1, money, description);
      }
    } 

    public void SubtractFromEntryDave(Entries entry1, double money, string description) 
    {
      double cleansed = 0; 
      if (money < 0)
      {
        cleansed = Math.Abs(money);
        entry.SubtractFromEntryDave(entry1, cleansed, description);
      }
      else 
      {
        entry.SubtractFromEntryDave(entry1, money, description);
      }
    } 

    public void UpdateEntry(string description, int ID) 
    {
      entry.UpdateEntry(description, ID); 
    }

    public Entries GetTransaction() 
    {
    	return entry.GetTransaction();
    }
}