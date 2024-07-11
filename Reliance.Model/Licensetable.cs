using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace Reliance.Model
{
    public class Licensetable
    {
        [Key]
        public int ID { get; set; }

        public string Autonumber { get; set;}
public string AppCode { get; set; }
public string CustomerCode { get; set; }
public DateTime LicenseStartDate { get; set; }
        public DateTime LicenseEndDate { get; set; }
        public DateTime EntryDate { get; set; }
      public string  CustomerName { get; set; }
       public string CustomerAddress { get; set; }
   public string CustomerContact { get; set; }
   public string LicenseKeyParameter { get; set; }
        public string Licensekey { get; set; }
    }
}
