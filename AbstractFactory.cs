using System ;
namespace DesignPatterns{

  public class Design
  {
    static void Main(){
      IToyFactory toyFactory = new TeddyToysFactory() ;
      Cat MyBear = toyFactory.GetCat() ;
      Console.WriteLine(MyBear.Name) ;
    }
  }
  // abstract factory
  public interface IToyFactory
  {
    Bear GetBear() ;
    Cat GetCat() ;
  }

  //contcrete factory
  public class TeddyToysFactory : IToyFactory
  {
    public Bear GetBear()
    {
      return new TeddyBear() ;
    }

    public Cat GetCat()
    {
      return new TeddyCat() ;
    }
  }

  public abstract class AnimalToy
  {
      protected AnimalToy(string name)
      {
          Name = name;
      }
      public string Name { get; private set; }
  }

  public abstract class Cat : AnimalToy
  {
    protected Cat(string name) : base(name) { }
  }

  // Базовий клас для усіх ведмедиків
  public abstract class Bear : AnimalToy
  {
    protected Bear(string name) : base(name) { }
  }
  // Конкретні реалізації
  class TeddyCat : Cat
  {
    public TeddyCat() : base("Teddy Cat") { }
  }

  class TeddyBear : Bear
  {
    public TeddyBear() : base("Teddy Bear") { }
  }
}
