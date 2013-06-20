using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
	public class Laptop
    {
        public string MonitorResolution { get; set; }
        public string Processor { get; set; }
        public string Memory { get; set; }
        public string HDD { get; set; }
        public string Battery { get; set; }

        public override string ToString()
        {
            return String.Format("Laptop: {0}, {1}, {2}, {3}, {4}", MonitorResolution, Processor, Memory, HDD, Battery);
        }
    }
	
	public abstract class LaptopBuilder
	{
		protected Laptop Laptop{get; private set;}
		public Laptop GetMyLaptop (){
			return new Laptop() ;
		}
		public abstract void SetMonitorResolution() ;
		public abstract void SetProcessor() ;
		public abstract void SetMemory() ;
		public abstract void SetHDD() ;
		public abstract void SetBattery() ;
	}
	
	class GamingLaptopBuilder : LaptopBuilder
	{
		public override void SetMonitorResolution(){
			Laptop.MonitorResolution = "1900X1200";
		}
		public override void SetProcessor(){
			Laptop.Processor = "Core 2 Duo, 3.2 GHz";
		}
		public override void SetMemory(){
			Laptop.Memory = "6144 Mb";
		}
		public override void SetHDD(){
			Laptop.HDD = "500 Gb";
		}
		public override void SetBattery(){
			Laptop.Battery = "6 lbs";
		}
	}
	
	public class main
	{
		public void Main(){
			//var tripBuilder = new TripLaptopBuilder();
			var gamingBuilder = new GamingLaptopBuilder();
			var shopForYou = new BuyLaptop();//Директор
			// Покупець каже, що хоче грати ігри
			shopForYou.SetLaptopBuilder(gamingBuilder);
			shopForYou.ConstructLaptop();
			// Ну то нехай бере що хоче!
			Laptop laptop = shopForYou.GetLaptop();
			Console.WriteLine(laptop.ToString());
		}
		
	}
	class BuyLaptop
	{
		private LaptopBuilder _laptopBuilder;
		public void SetLaptopBuilder(LaptopBuilder lBuilder){
			_laptopBuilder = lBuilder;
		}
		// Змушує будівельника повернути цілий ноутбук
		public Laptop GetLaptop(){
			return _laptopBuilder.GetMyLaptop();
		}
		// Змушує будівельника додавати деталі
		public void ConstructLaptop(){
			_laptopBuilder.CreateNewLaptop();
			_laptopBuilder.SetMonitorResolution();
			_laptopBuilder.SetProcessor();
			_laptopBuilder.SetMemory();
			_laptopBuilder.SetHDD();
			_laptopBuilder.SetBattery();
		}
	}
}

