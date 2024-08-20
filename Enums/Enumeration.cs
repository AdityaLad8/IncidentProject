namespace incidentMgtSystem.API.Enums
{
    public enum IncidentStatus
    {
        New =0,
        Assigned,
        Inprogress,
        Resolved,
        Closed,
        Cancelled,
        Rejected
    }

    public enum Priority
    {
        High =0,
        Medium=1,
        Low=2,
    }

    public enum Urgency
    {
        High =0,
        Medium =1,
        Low=2,
    }
}
