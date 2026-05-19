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

        //OBJETOS

        Parcela[,] parcelas = new Parcela[filas, columnas];

        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                parcelas[i, j] = new Parcela();
            }
        }

        Inventario inventario = new Inventario();


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

                    double costos_mensuales = num_empleados * sueldo_mensual;
                    double utilidad = dinero_inicial - costos_mensuales;

                    Console.WriteLine("Utilidad disponible: Q" + utilidad);
                    Console.WriteLine();

                    Console.WriteLine("Seleccione una semilla: ");
                    Console.WriteLine("1. Trigo --------- Q" + inventario.costo_trigo);
                    Console.WriteLine("2. Repollo ------- Q" + inventario.costo_repollo);
                    Console.WriteLine("3. Tomate -------- Q" + inventario.costo_tomate);
                    Console.WriteLine("4. Calabaza ------ Q" + inventario.costo_calabaza);
                    Console.WriteLine("5. Espárrago ----- Q" + inventario.costo_esparrago);

                    int tipo_semilla;
                    while (!int.TryParse(Console.ReadLine(), out tipo_semilla) || tipo_semilla < 1 || tipo_semilla > 5)
                    {
                        Console.WriteLine("Error. Ingrese una opción válida del 1 al 5: ");
                    }

                    Console.WriteLine("Ingrese la cantidad que desea comprar: ");
                    int cantidad;
                    while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error. Ingrese una cantidad válida: ");
                        Console.ResetColor();
                    }

                    double total_compra = inventario.CostoFinalCompra(tipo_semilla, cantidad);


                    if (total_compra <= dinero_inicial)
                    {
                        inventario.AgregarSemillas(tipo_semilla, cantidad);
                        dinero_inicial = dinero_inicial - total_compra;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Compra realizada correctamente.");
                        Console.ResetColor();
                        Console.WriteLine("Dinero restante: Q" + dinero_inicial);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No tiene suficiente dinero para realizar la compra.");
                        Console.ResetColor();
                        Console.Write("Regrese al menú principal para iniciar un nuevo proceso de compra.");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Presione una tecla para regresar al menú...");
                    Console.ReadKey();
                    Console.Clear();

                    break;

                case 2:
                    Console.WriteLine("SIEMBRA DE CULTIVOS");
                    Console.WriteLine();

                    Console.WriteLine("MAPA");
                    for (int i = 0; i < filas; i++) //Mapa
                    {
                        for (int j = 0; j < columnas; j++)
                        {
                            if (parcelas[i, j].parcela_ocupada == true)
                            {
                                Console.Write("[Ocupada]");
                            }
                            else
                            {
                                Console.Write("[Libre]");
                            }
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Nota: La primera fila corresponde al número 0");
                    Console.ResetColor();
                    Console.Write("Ingrese la fila en la que desea sembrar un cultivo: ");
                    int siembra_fila;
                    while (!int.TryParse(Console.ReadLine(), out siembra_fila) || siembra_fila < 0 || siembra_fila >= filas) //Trata de convertir en int pero si es una palabra el programa no avanza, si es menor a 0 o se sale de la matriz tampoco lo hace
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Fila inválida. Intente otra vez: ");
                        Console.ResetColor();
                    }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Nota: La primera columan corresponde al número 0");
                    Console.ResetColor();
                    Console.Write("Ingrese la columna en la que desea sembrar un cultivo: ");
                    int siembra_columna;
                    while (!int.TryParse(Console.ReadLine(), out siembra_columna) || siembra_columna < 0 || siembra_columna >= columnas)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Columna inválida. Intente otra vez: ");
                        Console.ResetColor();
                    }

                    while (parcelas[siembra_fila, siembra_columna].parcela_ocupada == true)
                    {
                        Console.WriteLine("La parcela ya está ocupada, seleccione otra parcela e ingrese los nuevos valores: ");

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Nota: La primera fila corresponde al número 0");
                        Console.ResetColor();
                        Console.Write("Ingrese la nueva fila en la que desea sembrar un cultivo: ");

                        while (!int.TryParse(Console.ReadLine(), out siembra_fila) || siembra_fila < 0 || siembra_fila >= filas) //Trata de convertir en int pero si es una palabra el programa no avanza, si es menor a 0 o se sale de la matriz tampoco lo hace
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Fila inválida. Intente otra vez: ");
                            Console.ResetColor();
                        }

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Nota: La primera columna corresponde al número 0");
                        Console.ResetColor();
                        Console.Write("Ingrese la nueva columna en la que desea sembrar un cultivo: ");

                        while (!int.TryParse(Console.ReadLine(), out siembra_columna) || siembra_columna < 0 || siembra_columna >= columnas)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Columna inválida. Intente otra vez: ");
                            Console.ResetColor();
                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine("SEMILLAS DISPONIBLES: ");
                    Console.WriteLine("1. Trigo: " + inventario.cant_trigo);
                    Console.WriteLine("2. Repollo: " + inventario.cant_repollo);
                    Console.WriteLine("3. Tomate: " + inventario.cant_tomate);
                    Console.WriteLine("4. Calabaza: " + inventario.cant_calabaza);
                    Console.WriteLine("5. Espárrago: " + inventario.cant_esparrago);
                    Console.WriteLine();
                    int seleccion_semilla;

                    do
                    {
                        Console.Write("Seleccione la semilla que desea sembrar: ");
                        while (!int.TryParse(Console.ReadLine(), out seleccion_semilla) || seleccion_semilla < 1 || seleccion_semilla > 5)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error. Seleccione una opción válida: ");
                            Console.ResetColor();
                        }

                        if (!inventario.VerificarSemillas(seleccion_semilla)) // el signo de exclamación indica que es falso
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("No tiene semillas disponibles de ese cultivo.");
                            Console.ResetColor();
                        }

                    } while (!inventario.VerificarSemillas(seleccion_semilla)); //lo mismo que poner: inventario.VerificarSemillas(seleccion_semilla) == false

                    inventario.SembrarEnParcela(seleccion_semilla, parcelas[siembra_fila, siembra_columna]);
                    Console.WriteLine(parcelas[siembra_fila, siembra_columna].tipo_cultivo_actual);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Se sembró correctamente.");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine("MAPA");
                    for (int i = 0; i < filas; i++)
                    {
                        for (int j = 0; j < columnas; j++)
                        {
                            if (parcelas[i, j].parcela_ocupada == true)
                            {
                                Console.Write("[" + parcelas[i,j].tipo_cultivo_actual + "]");
                            }
                            else
                            {
                                Console.Write("[Libre]");
                            }
                        }
                        Console.WriteLine();
                    }

                    Console.WriteLine("Presione una tecla para regresar al menú...");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 3:
                    Console.WriteLine("CONSULTA DE PARCELAS");
                    for (int i = 0; i < filas; i++) //Mapa
                    {
                        for(int j = 0; j < columnas; j++)
                        {
                            if (parcelas[i,j].parcela_ocupada == true)
                            {
                                Console.Write("[Ocupada]");
                            }
                            else
                            {
                                Console.Write("[Libre]");
                            }
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Nota: La primera fila corresponde al número 0");
                    Console.ResetColor();
                    Console.Write("Ingrese la fila que desea consultar: ");

                    int consult_fila;
                    while(!int.TryParse(Console.ReadLine(), out consult_fila) || consult_fila < 0 || consult_fila >= filas) //Trata de convertir en int pero si es una palabra el programa no avanza, si es menor a 0 o se sale de la matriz tampoco lo hace
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Fila inválida. Intente otra vez: ");
                        Console.ResetColor();
                    }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Nota: La primera columna corresponde al número 0");
                    Console.ResetColor();
                    Console.Write("Ingrese la columna que desea consultar: ");

                    int consult_columna;
                    while(!int.TryParse(Console.ReadLine(), out consult_columna) || consult_columna < 0 || consult_columna >= columnas)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Columna inválida. Intente otra vez: ");
                        Console.ResetColor();
                    }

                    Console.WriteLine();
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