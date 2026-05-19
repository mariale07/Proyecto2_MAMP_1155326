using System;
namespace granja
{
	public class Parcela
	{
		public string tipo_cultivo_actual;
		public int crecimiento_actual;
		public bool parcela_ocupada;
		public int meses_cosecha;
		public double ganancia_cosecha;

		public Parcela()
		{
			tipo_cultivo_actual = "Libre";
			crecimiento_actual = 0;
			parcela_ocupada = false;
			//Tiempo
			meses_cosecha = 0;
			ganancia_cosecha = 0; 
		}

		public void MostrarInfo()
		{
			Console.WriteLine("Cultivo: " + tipo_cultivo_actual);
            Console.WriteLine("Crecimiento: " + crecimiento_actual);
            Console.WriteLine("Estado: " + parcela_ocupada);
        }

		public void Sembrar(string cultivo)
		{
			tipo_cultivo_actual = cultivo;
			crecimiento_actual = 0;
			parcela_ocupada = true;

			if (cultivo == "Trigo") //El valor viene de la clase Inventario, específicamente de SembrarEnParcela
			{
				meses_cosecha = 1;
				ganancia_cosecha = 130;
			}
			else if (cultivo == "Repollo")
			{
				meses_cosecha = 2;
				ganancia_cosecha = 280;
			}
            else if (cultivo == "Tomate")
            {
                meses_cosecha = 3;
                ganancia_cosecha = 450;
            }
            else if (cultivo == "Calabaza")
            {
                meses_cosecha = 4;
                ganancia_cosecha = 360;
            }
            else if (cultivo == "Espárrago")
            {
                meses_cosecha = 6;
                ganancia_cosecha = 1000;
            }
        }
	}
}

