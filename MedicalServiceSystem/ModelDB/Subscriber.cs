using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace ModelDB
{
	public class Subscriber
	{
		public int Id { get; set; }
		public string PhoneNo { get; set; }
		public string InsurNo { get; set; }
		public string InsurName { get; set; }
		public string Gender { get; set; }
		public string Address { get; set; }
		public string Server { get; set; }
		public string ClientId { get; set; }
		public DateTime BirthDate { get; set; }
        public DateTime? StopCard { get; set; }
        public Boolean? IsStoped { get; set; }
		public string Notes { get; set; }
        public int localityId { get; set; }
    }
}
