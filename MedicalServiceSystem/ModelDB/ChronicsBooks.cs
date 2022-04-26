using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelDB
{
    public class ChronicsBooks : BaseEntity
    {
        public int Id { get; set; }
        public int BookNo { get; set; }
        public int DocNo { get; set; }
        public int BookTypeId { get; set; }
        [ForeignKey("BookTypeId")]
        public virtual ChronicBookType ChronicBookType { get; set; }
        public DateTime BookDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CenterId { get; set; }
        [ForeignKey("CenterId")]
        public virtual CenterInfo CenterInfo { get; set; }
        public int SubscriberId { get; set; }
        [ForeignKey("SubscriberId")]
        public virtual Subscriber Subscriber { get; set; }
        public string Notes { get; set; }

    }
 
}
