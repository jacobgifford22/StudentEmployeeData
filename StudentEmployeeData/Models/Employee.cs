using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEmployeeData.Models
{
    public class Employee
    {
        [Key]
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string International { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string ExpectedHours { get; set; }
        [Required]
        public string Semester { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        public string BYUID { get; set; }
        [Required]
        public string PositionType { get; set; }
        [Required]
        public string ClassCode { get; set; }
        [Required]
        public string EmplRecord { get; set; }
        [Required]
        public string Supervisor { get; set; }
        [Required]
        public string HireDate { get; set; }
        [Required]
        public string PayRate { get; set; }
        [Required]
        public string LastPayIncrease { get; set; }
        public string PayIncreaseAmount { get; set; }
        public string IncreaseInputDate { get; set; }
        public string YearInProgram { get; set; }
        public string PayGradTuition { get; set; }
        public string NameChangeCompleted { get; set; }
        public string Notes { get; set; }
        public string Terminated { get; set; }
        public string TerminationDate { get; set; }
        public string QualtricsSurveySent { get; set; }
        public string SubmittedEForm { get; set; }
        public string EFormSubmissionDate { get; set; }
        public string AuthorizationToWorkReceived { get; set; }
        public string AuthorizationToWorkEmailSentDate { get; set; }
        public string BYUName { get; set; }
    }
}
