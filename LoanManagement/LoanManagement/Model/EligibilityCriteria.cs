using System.ComponentModel.DataAnnotations;

namespace LoanManagementSystem.Model
{
    public class EligibilityCriteria
    {
        [Key]
        public int EligibilityCriteriaId { get; set; }
        public double MinimumIncome {  get; set; }
        public int MinimumAge { get; set; }
        public int MaximumAge {  get; set; }
        public double MinimumCreditScore {  get; set; }
        public int EmploymentYears {  get; set; }
        public string Documents { get; set; }


    }
}
