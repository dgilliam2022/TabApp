namespace Models;

public class Entries 
{
    public int id { get; set; }
    public double davidOwes { get; set; }
    public double andreOwes { get; set; }
    public string description { get; set; }

    public Entries(){}

    public Entries(double davidOwes, double andreOwes, string description)
    {
        this.davidOwes = davidOwes;
    	this.andreOwes = andreOwes;
    	this.description = description;
    }

    public Entries(int id, double davidOwes, double andreOwes, string description)
    {
    	this.id = id;
    	this.davidOwes = davidOwes;
    	this.andreOwes = andreOwes;
    	this.description = description;
    }
    
    public override string ToString() 
    {
    	return "Transaction num: " + this.id +
    	", David owes: " + this.davidOwes +
    	", Andre owes: " + this.andreOwes +
    	", Description: " + this.description;
    }
     
}