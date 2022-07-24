using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelDB
{
    public class Reclaim : BaseEntity
    {
        public int Id { get; set; }
        public string ReclaimNo { get; set; }
        public DateTime ReclaimDate { get; set; }
        public int SubscriberId { get; set; }
        [ForeignKey("SubscriberId")]
        public virtual Subscriber Subscriber { get; set; }
        public decimal BillsTotal { get; set; }
        public decimal ReclaimTotal { get; set; }
        public decimal MedicalTotal { get; set; }
        public decimal MedicineTotal { get; set; }
        public string Notes { get; set; }
        public ReclaimStatus ReclaimStatus { get; set; }
        public int? RefMedicineExcCenterId { get; set; }
        public int? RefMedicineReqCenterId { get; set; }
        public int? RefMedicalExcCenterId { get; set; }
        public int? RefMedicalReqCenterId { get; set; }

        public int ReclaimMedicalResonId { get; set; }
        [ForeignKey("ReclaimMedicalResonId")]
        public virtual ReclaimMedicalReasonsList ReclaimMedicalReasonsList { get; set; }
        public int ReclaimMedicineResonId { get; set; }
        [ForeignKey("ReclaimMedicineResonId")]
        public virtual ReclaimMedicineReasonsList ReclaimMedicineReasonsList { get; set; }
        public bool? IsMedicine { get; set; }
        public bool? IsMedical { get; set; }
        public bool? RefuseMedical { get; set; }
        public bool? RefuseMedicine { get; set; }


    }
    public enum ReclaimStatus
    {
        مرت_بالتأمين,
        لم_تمر_بالتأمين

    }
}
