using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Contracts.Model
{
	public class MenuDish
	{
		public Guid MenuId { get; set; }
		public Guid DishId { get; set; }

		// Навигационные свойства
		public Menu Menu { get; set; }
		public Dish Dish { get; set; }
	}
}
