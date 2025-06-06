
using System;
using System.Collections.Generic;

namespace JuegoCartas
{
    class Carta
    {
        public string Palo { get; set; }
        public string Valor { get; set; }

        public Carta(string valor, string palo)
        {
            Valor = valor;
            Palo = palo;
        }

        public override string ToString()
        {
            return $"{Valor} de {Palo}";
        }
    }

    class Baraja
    {
        private List<Carta> cartas;
        private static readonly string[] Palos = { "Corazones", "Diamantes", "Tréboles", "Picas" };
        private static readonly string[] Valores = { "As", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

        public Baraja()
        {
            cartas = new List<Carta>();
            foreach (var palo in Palos)
            {
                foreach (var valor in Valores)
                {
                    cartas.Add(new Carta(valor, palo));
                }
            }
        }

        public void Barajar()
        {
            Random random = new Random();
            for (int i = cartas.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (cartas[i], cartas[j]) = (cartas[j], cartas[i]);
            }
        }

        public List<Carta> Repartir(int cantidad)
        {
            List<Carta> mano = new List<Carta>();
            for (int i = 0; i < cantidad && cartas.Count > 0; i++)
            {
                mano.Add(cartas[0]);
                cartas.RemoveAt(0);
            }
            return mano;
        }
    }

    class Program
    {
        static void Main()
        {
            Baraja baraja = new Baraja();
            baraja.Barajar();

            Console.Write("¿Cuántas cartas deseas repartir? ");
            string? entrada = Console.ReadLine();
            if (int.TryParse(entrada, out int cantidad))
            {
                List<Carta> mano = baraja.Repartir(cantidad);
                Console.WriteLine("\nCartas repartidas:");
                foreach (var carta in mano)
                {
                    Console.WriteLine(carta);
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida.");
            }
        }
    }
}
