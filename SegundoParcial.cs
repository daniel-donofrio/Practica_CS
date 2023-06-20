namespace SegundoParcial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void mostrarMenu()
            {
                Console.WriteLine("  _________________________________");
                Console.WriteLine(" |                                 |");
                Console.WriteLine(" |               MENU              |");
                Console.WriteLine(" |_________________________________|");
                Console.WriteLine(" |                                 |");
                Console.WriteLine(" |   1. Ingresar numeros           |");
                Console.WriteLine(" |   2. Leer números ingresados    |");
                Console.WriteLine(" |   3. Salir del programa         |");
                Console.WriteLine(" |_________________________________|");
                Console.WriteLine();
                Console.Write("Ingrese la opción deseada: ");
            }
            string opcion;
            string rutaArchivo = @"c:\Parcial\numeros.txt";
            do
            {
                mostrarMenu();
                opcion = Console.ReadLine();
                Console.WriteLine();
                switch (opcion)
                {
                    case "1":
                        GuardarNumeros(rutaArchivo);
                        Console.WriteLine();
                        Console.WriteLine("Presione enter para continuar...");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case "2":
                        LeerArchivo(rutaArchivo);
                        Console.WriteLine();
                        Console.WriteLine("Presione enter para continuar...");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case "3":
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida");
                        Console.WriteLine();
                        Console.WriteLine("Presione enter para intentar nuevamente...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            } while (opcion != "3");

            static int IngresarNumeros(int num)
            {
                int numero;
                bool esNumeroValido = false;
                do
                {
                    Console.Write($"Ingrese el número de la posición {num}: ");
                    string numeroIngresado = Console.ReadLine();
                    if (int.TryParse(numeroIngresado, out numero))
                    {
                        esNumeroValido = true;
                    }
                    else
                    {
                        Console.WriteLine("Error: Solo se admite el ingreso de números enteros. Inténtelo nuevamente.");
                    }
                } while (!esNumeroValido);
                return numero;
            }
            static void GuardarNumeros(string rutaArch)
            {
                int[] arreglo = new int[10];

                for (int i = 0; i < 10; i++)
                {
                    arreglo[i] = IngresarNumeros(i + 1);
                }

                try
                {
                    StreamWriter guardar = new StreamWriter(rutaArch);
                    for (int i = 0; i < 10; i++)
                    {
                        guardar.WriteLine(arreglo[i]);
                    }
                    guardar.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error en el archivo." + e.Message);
                }


            }
            
            static void LeerArchivo(string rutaArchivo)
            {
                if (File.Exists(rutaArchivo))
                {
                    string? linea;
                    try
                    {
                        StreamReader lector = new StreamReader(rutaArchivo);
                        linea = lector.ReadLine();

                        while (linea != null)
                        {
                            Console.WriteLine(linea);
                            linea = lector.ReadLine();
                        }
                        lector.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error con el archivo. " + e.Message);
                    }
                }
                else
                {
                    Console.WriteLine("No existe el archivo.");
                }
            }
        }
    }
}