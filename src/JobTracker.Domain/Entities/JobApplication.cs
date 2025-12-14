namespace JobTracker.Domain.Entities;

public class JobApplication
{
    public Guid Id { get; private set; }
    public string CompanyName { get; private set; } = string.Empty;
    public string JobName { get; private set; } = string.Empty;
    public string JobDescription { get; private set; } = string.Empty;
    public string? JobUrl { get; private set; }
    public string? Notes { get; private set; }
    public ApplicationStatus Status { get; private set; }
    public DateTime AppliedAt { get; private set; }
    public DateTime? LastFollowUpAt { get; private set; }
    public DateTime? NextFollowUpAt { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? LastModifiedAt { get; private set; }
}

public enum ApplicationStatus
{
    Applied = 0,
    InterviewScheduled = 1,
    InterviewCompleted = 2,
    OfferReceived = 3,
    Accepted = 4,
    Declined = 5,
    Rejected = 6,
    NoResponse = 7 
}