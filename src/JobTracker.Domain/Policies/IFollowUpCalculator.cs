namespace JobTracker.Domain.Policies;
/// <summary>
/// Strategy pattern interface for calculating followup dates based on job application level/type.
/// Implementations determine the appropriate followup interval (ex 7 days for midlevel, 14 days for senior level positions).
/// </summary>
public interface IFollowUpCalculator
{
   /// <summary>
   /// alculates the next follow up date based on the initial application date.
   /// </summary>
   /// <param name="appliedAt">The date when the job application was submitted.</param>
   /// <returns>The calculated next followup date.</returns>
   DateTime CalculateNextFollowUp(DateTime appliedAt); 
}