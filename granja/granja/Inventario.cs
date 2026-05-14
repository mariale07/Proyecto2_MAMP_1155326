using System;
namespace granja
{
	public class Inventario
	{
		public int cant_trigo;
		public int cant_repollo;
		public int cant_tomate;
		public int cant_calabaza;
		public int cant_esparrago;

		public double costo_trigo;
		public double costo_repollo;
		public double costo_tomate;
		public double costo_calabaza;
		public double costo_esparrago;

		public Inventario()
		{
			cant_trigo = 0;
			cant_repollo = 0;
			cant_tomate = 0;
            cant_calabaza = 0;
            cant_esparrago = 0;

			costo_trigo = 100;
			costo_repollo = 180;
			costo_tomate = 250;
			costo_calabaza = 220;
			costo_esparrago = 500;

        }

		public double CostoFinalCompra(int tipo_semilla, int cantidad)
		{
			double total_compra = 0;

            if (tipo_semilla == 1)
            {
                total_compra = cantidad * costo_trigo;
            }
            else if (tipo_semilla == 2)
            {
                total_compra = cantidad * costo_repollo;
            }
            else if (tipo_semilla == 3)
            {
                total_compra = cantidad * costo_tomate;
            }
            else if (tipo_semilla == 4)
            {
                total_compra = cantidad * costo_calabaza;
            }
            else if (tipo_semilla == 5)
            {
                total_compra = cantidad * costo_esparrago;
            }

			return total_compra;
        }

		public void AgregarSemillas(int tipo_semilla, int cantidad)
		{
            if (tipo_semilla == 1)
            {
                cant_trigo = cant_trigo + cantidad;
            }
            else if (tipo_semilla == 2)
            {
                cant_repollo = cant_repollo + cantidad;
            }
            else if (tipo_semilla == 3)
            {
                cant_tomate = cant_tomate + cantidad;
            }
            else if (tipo_semilla == 4)
            {
                cant_calabaza = cant_calabaza + cantidad;
            }
            else if (tipo_semilla == 5)
            {
                cant_esparrago = cant_esparrago + cantidad;
            }
        }
	}
}

