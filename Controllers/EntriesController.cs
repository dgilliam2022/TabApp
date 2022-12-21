using Microsoft.AspNetCore.Mvc;
using Models;
using DAO;
using Services;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class EntryController : ControllerBase
{
    EntryService access = new EntryService();

    [Route("/viewEntries")]
    [HttpGet]
    public ActionResult<Entries> Get()
    {
        try
        {
            List<Entries> allEntries = access.CheckEntries();
            return Ok(allEntries); 
        }
        catch(Exception)
        {
            return BadRequest("Something went wrong");    
        }
    }

    [Route("/subEntryFromAndre")]
    [HttpPost]
    public ActionResult<Entries> SubPost(double amount, string purpose)
    {
        try
        {
            Entries mostRecent = access.GetTransaction();
            access.SubtractFromEntry(mostRecent, amount, purpose);
            mostRecent = access.GetTransaction();
            return Created("/subEntryFromAndre", mostRecent.andreOwes);   
        }
        catch(Exception)
        {
            return BadRequest("Something went wrong");    
        }  
    }

    [Route("/addEntryToAndre")]
    [HttpPost]
    public ActionResult<Entries> AddPost(double amount, string purpose)
    {
        try
        {
            Entries mostRecent = access.GetTransaction();
            access.AddToEntry(mostRecent, amount, purpose);
            mostRecent = access.GetTransaction();
            return Created("/addEntryToAndre", mostRecent.andreOwes);   
        }
        catch(Exception)
        {
            return BadRequest("Something went wrong");    
        }  
    }

    [Route("/addEntryToDavid")]
    [HttpPost]
    public ActionResult<Entries> AddPostDave(double amount, string purpose)
    {
        try
        {
            Entries mostRecent = access.GetTransaction();
            access.AddToEntryDave(mostRecent, amount, purpose);
            mostRecent = access.GetTransaction();
            return Created("/addEntryToDavid", mostRecent.davidOwes);   
        }
        catch(Exception)
        {
            return BadRequest("Something went wrong");    
        }  
    }

    [Route("/subEntryFromDavid")]
    [HttpPost]
    public ActionResult<Entries> SubPostDave(double amount, string purpose)
    {
        try
        {
            Entries mostRecent = access.GetTransaction();
            access.SubtractFromEntryDave(mostRecent, amount, purpose);
            mostRecent = access.GetTransaction();
            return Created("/subEntryFromDavid", mostRecent.davidOwes);   
        }
        catch(Exception)
        {
            return BadRequest("Something went wrong");    
        }  
    }

    [Route("/updateEntry")]
    [HttpPut]
    public ActionResult<int> Put(string description, int ID)
    {
        try
        {
            access.UpdateEntry(description, ID);  
            return Ok(ID); 
        }
        catch(Exception)
        {
            return BadRequest("Something went wrong");    
        }  
    }
}
