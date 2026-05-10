using System;
namespace granja
{
	public class Parcela
	{
		public string tipo_cultivo_actual;
		public int crecimiento_actual;
		public bool parcela_ocupada;

		public Parcela()
		{
			tipo_cultivo_actual = "Libre";
			crecimiento_actual = 0;
			parcela_ocupada = false;
		}

		public void MostrarInfo()
		{
			Console.WriteLine("Cultivo" + tipo_cultivo_actual);
            Console.WriteLine("Crecimiento" + crecimiento_actual);
            Console.WriteLine("Estado" + parcela_ocupada);
        }
	}
}

