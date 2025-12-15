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

    private JobApplication()
    {
    }

    public static JobApplication Create(string companyName, string jobName, string jobDescription,
        string? jobUrl = null, string? notes = null, int followUpInDays = 7)
    {
        if (string.IsNullOrWhiteSpace(companyName))
            throw new ArgumentException($"'{nameof(companyName)}' cannot be null or empty and it is required.",
                nameof(companyName));
        if (string.IsNullOrWhiteSpace(jobName))
            throw new ArgumentException($"'{nameof(jobName)}' cannot be null or empty and it is required.",
                nameof(jobName));
        if (string.IsNullOrWhiteSpace(jobName))
            throw new ArgumentException($"'{nameof(jobName)}' cannot be null or empty and it is required.",
                nameof(jobName));
        if (string.IsNullOrWhiteSpace(jobDescription))
            throw new ArgumentException($"'{nameof(jobDescription)}' cannot be null or empty and it is required.",
                nameof(jobDescription));
        if (followUpInDays < 0)
            throw new ArgumentOutOfRangeException($"'{nameof(followUpInDays)} must not be less than 0'",
                nameof(followUpInDays));


        return new()
        {
            Id = Guid.NewGuid(),
            CompanyName = companyName.Trim(),
            JobName = jobName.Trim(),
            JobDescription = jobDescription.Trim(),
            JobUrl = jobUrl?.Trim(),
            Notes = notes?.Trim(),
            Status = ApplicationStatus.Applied,
            AppliedAt = DateTime.UtcNow,
            NextFollowUpAt = DateTime.UtcNow.AddDays(followUpInDays),
            CreatedAt = DateTime.UtcNow,
        };
    }
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