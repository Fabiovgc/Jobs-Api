namespace jobs_api.Models
{
    public class Job
    {
        public Job()
        {
            CreatedAt = DateTime.Now;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Salary { get; set; }

        // Method to update job details except Id and CreatedAt 
        // (which should remain unchanged)
        // We will use this method in the JobsController's Update action
        // to update the job details.
        // This approach encapsulates the update logic within the Job model.
        // This is a common practice in domain-driven design.

        public void Update(string title, string description, string company, string location, decimal salary)
        {
            Title = title;
            Description = description;
            Company = company;
            Location = location;
            Salary = salary;
        }


    }
}
