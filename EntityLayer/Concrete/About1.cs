using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class About1
	{
        [Key]
        public int About1ID { get; set; }
        public string Title1 { get; set; }
        public string Description1 { get; set; }
        public string Image1 { get; set; }
        public string Title2 { get; set; }
		public string Description2 { get; set; }
		public bool Status { get; set; }
    }
}
