namespace JobTrackerAPI.Models;

public class Job
{
    public int Id {get;set;}
    public string CompanyName {get;set;} = string.Empty;
    public string Position {get;set;} = string.Empty;
    public string Status {get;set;} =  "Applied";
    public DateTime AppliedDate {get;set;} = DateTime.UtcNow;
    public string? Notes{get;set;}
    

}

