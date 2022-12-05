using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entities
{
    public class EmployeeFormEntity
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public long Salary { get; set; }
        public string Notes { get; set; }
        [ForeignKey("EmployeeEntity")]
        public long EmployeeId { get; set; }
        public virtual EmployeeEntity User { get; set; }

    }
}

