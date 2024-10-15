using Papeleria.LogicaNegocio.Entidades;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try { 
                int menu = 0;
                while(menu == 0)
                {

                    Console.WriteLine("=Crear=");
                    Console.WriteLine("Ingresa el RUT");
                    long.TryParse(Console.ReadLine(), out long rut);
                    Console.WriteLine("Ingresa la calle");
                    string calle = Console.ReadLine();
                    Console.WriteLine("Ingresa el numero");
                    int.TryParse(Console.ReadLine(), out int numero);
                    Console.WriteLine("Ingrese la ciudad");
                    string ciudad = Console.ReadLine();
                    Console.WriteLine("Ingresa la distancia");
                    int.TryParse(Console.ReadLine(), out int distancia);


                    

                    Cliente cliente = new Cliente(rut, calle, numero, ciudad, distancia);
                    Console.WriteLine(cliente);
                    Console.WriteLine("Ingrese 1 para salir");
                    int.TryParse(Console.ReadLine(), out menu);
                    Console.Clear();
                }
            } 
            catch (Exception ex)
            { 
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }
    }
}
