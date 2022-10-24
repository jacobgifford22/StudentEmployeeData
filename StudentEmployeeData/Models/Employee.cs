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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string International { get; set; }
        public string Gender { get; set; }
        public double ExpectedHours { get; set; }
        public string Semester { get; set; }
        public int Year { get; set; }
        public string Phone { get; set; }
        public string BYUID { get; set; }
        public string PositionType { get; set; }
        public string ClassCode { get; set; }
        public int EmplRecord { get; set; }
        public string Supervisor { get; set; }
        public string HireDate { get; set; }
        public double PayRate { get; set; }
        public string LastPayIncrease { get; set; }
        public double PayIncreaseAmount { get; set; }
        public string IncreaseInputDate { get; set; }
        public string YearInProgram { get; set; }
        public string PayGradTuition { get; set; }
        public bool NameChangeCompleted { get; set; }
        public string Notes { get; set; }
        public bool Terminated { get; set; }
        public string TerminationDate { get; set; }
        public string QualtricsSurveySent { get; set; }
        public bool SubmittedEForm { get; set; }
        public string EFormSubmissionDate { get; set; }
        public bool AuthorizationToWorkReceived { get; set; }
        public string AuthorizationToWorkEmailSentDate { get; set; }
        public string BYUName { get; set; }
    }
}
