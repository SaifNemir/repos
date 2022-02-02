using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace ModelDB
{
	public class ApproveMedicine:BaseEntity
    {
		public int Id { get; set; }
		public int InsurId { get; set; }
		[ForeignKey("InsurId")]
		public virtual Subscriber Subscriber { get; set; }
		public int ReqCenterId { get; set; }
        public int RouchitaNo { get; set; }
        public int ExcCenterId { get; set; }
		public DateTime ApproveDate { get; set; }
        public string ApproveCode { get; set; }
        public int DiagnosisId { get; set; }
        [ForeignKey("DiagnosisId")]
        public virtual Diagnosis Diagnosis { get; set; }
        public int pharmacistId { get; set; }
        [ForeignKey("pharmacistId")]
        public virtual Pharmacist Pharmacist { get; set; }
        public int ApproveTypeId { get; set; }
        [ForeignKey("ApproveTypeId")]
        public virtual ApproveMedicineType ApproveMedicineType { get; set; }

    }

}
