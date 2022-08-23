namespace DAL.Models
{
    public class Company
    {
        public Company()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }

    //public class CompanyValidation : AbstractValidator<Company>
    //{
    //    public CompanyValidation()
    //    {
    //        RuleFor(c => c.Name)
    //            .NotNull()
    //            .NotEmpty()
    //            .MaximumLength(50)
    //            .WithMessage("you should insert name");
    //        RuleFor(c => c.Address)
    //            .NotNull()
    //            .NotEmpty()
    //            .MaximumLength(100)
    //            .WithMessage("you should insert address");
    //    }
    //}
}
