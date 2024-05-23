using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCProgerss.Model
{
    public class Worker : Employee
    {
		private int category;

		public int Category
		{
			get { return category; }
			set { category = value; }
		}

		public Worker() { }
    }
}
