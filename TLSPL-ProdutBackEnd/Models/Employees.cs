namespace TLSPL_ProdutBackEnd.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeCode { get; set; }

        // Personal Info
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string NationalIdNumber { get; set; }
        public string MaritalStatus { get; set; }

        // Contact Info
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string EmergencyContact { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }

        // Job Info
        public DateTime HireDate { get; set; }
        public string JobTitle { get; set; }
        public string EmploymentType { get; set; }
        public string WorkLocation { get; set; }
        public int? DepartmentId { get; set; }
        public int? ManagerId { get; set; }
        public string Status { get; set; }
        public DateTime? LastWorkingDay { get; set; }

        // Compensation
        public decimal? Salary { get; set; }
        public string PayGrade { get; set; }
        public string BankAccount { get; set; }
        public string IFSCCode { get; set; }

        // Other Info
        public string ProfilePictureUrl { get; set; }
        public string Experience { get; set; }
        public string BgverifiStatus { get; set; }
        public string Remarks { get; set; }

        // System Fields
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
