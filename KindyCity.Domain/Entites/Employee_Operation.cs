using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KindyCity.Domain.Entites
{
    public class Employee_Operation
    {
        [Key]
        public Guid EmployeeAction { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public Guid EmployeeId { get; set; }
        [ForeignKey(nameof(OperationId))]
        public Guid OperationId { get; set; }
        public Employee? Employee { get; set; }
        public Operation? Operation { get; set; }
    }
}
