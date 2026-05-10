using System;
using granja;

class Program
{
    static void Main()
    {
        Console.WriteLine("¡Bienvenid@ a su granja!");
        Console.WriteLine();


        //Pedir al usuario los datos principales
        Console.WriteLine("Ingrese el monto con el que iniciará su granja: ");
        double dinero_inicial;
        while (!double.TryParse(Console.ReadLine(), out dinero_inicial) || dinero_inicial <= 0) //Validación de entrada
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error. Ingrese un monto válido mayor a 0: ");
            Console.ResetColor();
        }
        Console.WriteLine();

        Console.WriteLine("Ingrese la cantidad inicial de empleados: ");
        int num_empleados;
        while(!int.TryParse(Console.ReadLine(), out num_empleados) || num_empleados <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error. Ingrese un número válido mayor a 0: ");
            Console.ResetColor();
        }
        Console.WriteLine();

        Console.WriteLine("Ingrese el sueldo mensual: ");
        double sueldo_mensual;
        while(!double.TryParse(Console.ReadLine(), out sueldo_mensual) || sueldo_mensual <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error. Ingrese un monto válido mayor a 0: ");
            Console.ResetColor();
        }
        Console.WriteLine();

        Console.WriteLine("Ingrese la cantidad meses a simular: ");
        int meses;
        while(!int.TryParse(Console.ReadLine(), out meses) || meses <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error. Ingrese un número válido mayor a 0: ");
            Console.ResetColor(); 
        }
        Console.WriteLine();

        Console.WriteLine("Ingrese el número de filas que desea para sus parcelas: ");
        int filas;
        while (!int.TryParse(Console.ReadLine(), out filas) || filas <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error. Ingrese un número válido mayor a 0: ");
            Console.ResetColor();
        }
        Console.WriteLine();

        Console.WriteLine("Ingrese el número de columnas que desea para sus parcelas: ");
        int columnas;
        while (!int.TryParse(Console.ReadLine(), out columnas) || columnas <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error. Ingrese un número válido mayor a 0: ");
            Console.ResetColor();
        }
        Parcela[,] parcelas = new Parcela[filas, columnas];

        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                parcelas[i, j] = new Parcela();
            }
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Datos ingresados correctamente.");
        Console.ResetColor();
        Console.WriteLine("Presione una tecla para acceder al menú.");
        Console.WriteLine();
        Console.ReadKey();
        Console.Clear();

        //Menú
        int opcion_menu;
        bool simulacion_activa = true;
        do
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("----------MENÚ PRINCIPAL----------");
            Console.ResetColor();
            Console.WriteLine("1. Comprar semillas");
            Console.WriteLine("2. Siembra de cultivos");
            Console.WriteLine("3. Consulta de parcelas");
            Console.WriteLine("4. Avance de mes");
            Console.WriteLine("5. Finalización de simulación");
            Console.WriteLine();

            Console.Write("Seleccione una opción: ");
            while (!int.TryParse(Console.ReadLine(), out opcion_menu) || opcion_menu < 1 || opcion_menu > 5)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error. Ingrese una opción válida del 1 al 5: ");
                Console.ResetColor();
            }
            Console.Clear();

            switch (opcion_menu)
            {
                case 1:
                    Console.WriteLine("COMPRAR SEMILLAS");
                    Console.WriteLine();
                    Console.WriteLine("Presione una tecla para regresar al menú...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                    //Agregar el resto (siguientes pasos)
                case 2:
                    Console.WriteLine("SIEMBRA DE CULTIVOS");
                    Console.WriteLine();
                    Console.WriteLine("Presione una tecla para regresar al menú...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                //Agregar el resto (siguientes pasos)

                case 3:
                    Console.WriteLine("CONSULTA DE PARCELAS");
                    for (int i = 0; i < filas; i++) //Mapa
                    {
                        for(int j = 0; j < columnas; j++)
                        {
                            if (parcelas[i,j].parcela_ocupada == true)
                            {
                                Console.Write("[0]");
                            }
                            else
                            {
                                Console.Write("[L]");
                            }
                        }
                        Console.WriteLine();
                        
                    }

                    Console.Write("Ingrese la fila que desea consultar: ");
                    int consult_fila = int.Parse(Console.ReadLine());

                    Console.Write("Ingrese la columna que desea consultar: ");
                    int consult_columna = int.Parse(Console.ReadLine());

                    parcelas[consult_fila, consult_columna].MostrarInfo();
                    Console.WriteLine("Presione una tecla para regresar al menú...");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 4:
                    Console.WriteLine("AVANCE DE MES");
                    Console.WriteLine();
                    Console.WriteLine("Presione una tecla para regresar al menú...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                //Agregar el resto (siguientes pasos)
                case 5:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Saliendo de la simulación...");
                    Console.ResetColor();
                    simulacion_activa = false;
                    //Agregar el resto (siguientes pasos)
                    break; 
            }

        } while (simulacion_activa);
    }
}