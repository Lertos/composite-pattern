namespace composite_pattern
{
    //A demonstration of the Composite pattern in C#
    public class Program
    {
        static void Main(string[] args)
        {
            Table table = new Table();

            foreach (var item in table.Components)
            {
                Console.WriteLine($"Component name: {item.GetType().Name}");
            }
        }
    }

    //Since all classes extend Product, we can have an infinitely growing node system where components can have many other components
    public abstract class Product
    {
        public List<Product> Components { get; set; } = new List<Product>();
    }

    public class Table : Product
    {
        public Table() 
        {
            Components.Add(new Top());
            //By adding Legs, we are also adding Screws, Feet, and Padding
            Components.Add(new Legs());
        }
    }

    public class Top : Product { }

    public class Legs : Product
    {
        public Legs()
        {
            Components.Add(new Screws());
            Components.Add(new Feet());
            Components.Add(new Padding());
        }
    }

    public class Screws : Product { }

    public class Padding : Product { }

    public class Feet : Product { }
}
