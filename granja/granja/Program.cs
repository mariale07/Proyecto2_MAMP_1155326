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

        //VARIABLES
        double planilla = 0;
        int meses_simulados = 0;
        int meses_restantes = meses;

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
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("COMPRAR SEMILLAS");
                    Console.ResetColor();
                    Console.WriteLine();

                    double costos_mensuales = num_empleados * sueldo_mensual;
                    double utilidad = dinero_inicial - costos_mensuales;

                    Console.WriteLine("Utilidad disponible: Q" + utilidad);
                    Console.WriteLine();

                    Console.WriteLine("Semillas disponibles: ");
                    Console.WriteLine("1. Trigo --------- Q" + inventario.costo_trigo);
                    Console.WriteLine("2. Repollo ------- Q" + inventario.costo_repollo);
                    Console.WriteLine("3. Tomate -------- Q" + inventario.costo_tomate);
                    Console.WriteLine("4. Calabaza ------ Q" + inventario.costo_calabaza);
                    Console.WriteLine("5. Espárrago ----- Q" + inventario.costo_esparrago);
                    Console.Write("Seleccione una semilla: ");

                    int tipo_semilla;
                    while (!int.TryParse(Console.ReadLine(), out tipo_semilla) || tipo_semilla < 1 || tipo_semilla > 5)
                    {
                        Console.WriteLine("Error. Ingrese una opción válida del 1 al 5: ");
                    }

                    Console.Write("Ingrese la cantidad que desea comprar: ");
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
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("SIEMBRA DE CULTIVOS");
                    Console.ResetColor();
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
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("CONSULTA DE PARCELAS");
                    Console.ResetColor();
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
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("AVANCE DE MES");
                    Console.ResetColor();
                    Console.WriteLine();

                    if (meses_restantes > 0)
                    {
                        planilla = num_empleados * sueldo_mensual;
                        dinero_inicial = dinero_inicial - planilla;
                        Console.WriteLine("Planilla pagada este mes: Q" + planilla);
                        Console.WriteLine();

                        double total_ingresos = 0;
                        for (int i = 0; i < filas; i++)
                        {
                            for (int j = 0; j < columnas; j++)
                            {
                                if (parcelas[i, j].parcela_ocupada == true)
                                {
                                    parcelas[i, j].crecimiento_actual++;
                                    Console.WriteLine("Cultivo sembrado: " + parcelas[i, j].tipo_cultivo_actual + " en la parcela [" + i + ", " + j + "] avanzó al mes: " + parcelas[i, j].crecimiento_actual);
                                    if (parcelas[i,j].crecimiento_actual >= parcelas[i, j].meses_cosecha)
                                    {
                                        Console.WriteLine("El cultivo de " + parcelas[i, j].tipo_cultivo_actual + " en la parcela [" + i + ", " + j + "] fue cosechado.");
                                        dinero_inicial = dinero_inicial + parcelas[i, j].ganancia_cosecha;
                                        total_ingresos = total_ingresos + parcelas[i, j].ganancia_cosecha;
                                        parcelas[i, j].tipo_cultivo_actual = "Libre";
                                        parcelas[i, j].crecimiento_actual = 0;
                                        parcelas[i, j].parcela_ocupada = false;

                                        parcelas[i, j].meses_cosecha = 0;
                                        parcelas[i, j].ganancia_cosecha = 0;
                                    }
                                }
                            }
                        }
                        meses_simulados++;
                        meses_restantes--;
                        Console.WriteLine();
                        Console.WriteLine("Ingresos del mes: Q" + total_ingresos);
                        Console.WriteLine("Dinero disponible: Q" + dinero_inicial);
                        Console.WriteLine("Meses restantes: " + meses_restantes);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("La simulación ya no tiene meses disponibles.");
                        Console.ResetColor();
                    }

                    Console.WriteLine();
                    Console.WriteLine("Presione una tecla para regresar al menú...");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 5:
                    Console.Clear();

                    Console.WriteLine("----- RESUMEN DE LA SIMULACIÓN-----");

                    Console.WriteLine("Dinero final: Q" + dinero_inicial);
                    Console.WriteLine("Meses simulados: " + meses_simulados);
                    Console.WriteLine("Meses restantes: " + meses_restantes);

                    Console.WriteLine();
                    Console.WriteLine("Inventario final: ");
                    Console.WriteLine("Trigo: " + inventario.cant_trigo);
                    Console.WriteLine("Repollo: " + inventario.cant_repollo);
                    Console.WriteLine("Tomate: " + inventario.cant_tomate);
                    Console.WriteLine("Calabaza: " + inventario.cant_calabaza);
                    Console.WriteLine("Espárrago: " + inventario.cant_esparrago);

                    Console.WriteLine();
                    Console.Write("¿Desea salir de la simulación? (true/false");
                    bool respuesta;
                    while (!bool.TryParse(Console.ReadLine(), out respuesta))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ingrese un valor válido (true/false) ");
                        Console.ResetColor();
                    }

                    if (respuesta == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Saliendo de la simulación...");
                        Console.ResetColor();
                        simulacion_activa = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Precione una tecla para regresar al menú.");
                        Console.ResetColor();
                    }

                    break; 
            }

        } while (simulacion_activa);
    }
}