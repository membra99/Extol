using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Universal.MainData
{
	public class DoorHandle
	{
        public int DoorHandleId { get; set; }
		public int MaterialId { get; set; }
		public int? MediaId { get; set; }
		public string? Code { get; set; }

		public Media? Media { get; set; }
		public Materials? Material { get; set; }
	}
}
