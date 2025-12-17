using JobTracker.Domain.Policies;

namespace JobTracker.Domain.Entities;

/// <summary>
/// Represents a job application with tracking capabilities for followups and status changes.
/// Uses the Strategy pattern via <see cref="IFollowUpCalculator"/> to determine followup intervals.
/// </summary>
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

    // Parameterless constructor for ORM/serialization
    private JobApplication()
    {
    }

    /// <summary>
    /// Creates a new job application with the specified details.
    /// </summary>
    /// <param name="companyName">The name of the company (required).</param>
    /// <param name="jobName">The job title/position (required).</param>
    /// <param name="jobDescription">Description of the job (required).</param>
    /// <param name="followUpCalculator">Strategy for calculating follow-up dates based on job level.</param>
    /// <param name="jobUrl">Optional URL to the job posting.</param>
    /// <param name="notes">Optional notes about the application.</param>
    /// <returns>A new <see cref="JobApplication"/> instance.</returns>
    /// <exception cref="ArgumentException">Thrown when required fields are null or whitespace.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when calculated follow-up date is invalid.</exception>
    public static JobApplication Create(
        string companyName,
        string jobName,
        string jobDescription,
        IFollowUpCalculator followUpCalculator,
        string? jobUrl = null,
        string? notes = null)
    {
        if (string.IsNullOrWhiteSpace(companyName))
            throw new ArgumentException($"'{nameof(companyName)}' cannot be null or empty.", nameof(companyName));

        if (string.IsNullOrWhiteSpace(jobName))
            throw new ArgumentException($"'{nameof(jobName)}' cannot be null or empty.", nameof(jobName));

        if (string.IsNullOrWhiteSpace(jobDescription))
            throw new ArgumentException($"'{nameof(jobDescription)}' cannot be null or empty.", nameof(jobDescription));

        var appliedAt = DateTime.UtcNow;
        var nextFollowUpAt = followUpCalculator.CalculateNextFollowUp(appliedAt);

        if (nextFollowUpAt < appliedAt)
            throw new ArgumentOutOfRangeException(
                nameof(followUpCalculator),
                $"Calculated followup date ({nextFollowUpAt}) cannot be before application date ({appliedAt}).");

        return new JobApplication
        {
            Id = Guid.NewGuid(),
            CompanyName = companyName.Trim(),
            JobName = jobName.Trim(),
            JobDescription = jobDescription.Trim(),
            JobUrl = jobUrl?.Trim(),
            Notes = notes?.Trim(),
            Status = ApplicationStatus.Applied,
            AppliedAt = appliedAt,
            NextFollowUpAt = nextFollowUpAt,
            CreatedAt = DateTime.UtcNow,
        };
    }
}

/// <summary>
/// Represents the current status of a job application in the hiring pipeline.
/// </summary>
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