using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp7
{
    class Program
    {

        static void Main(string[] args)
        {
            juego game = new juego();

            game.Escribir("wenas, bienvenido a este juego \n");
            game.Escribir("Crea tu personaje: \n");
            game.Escribir("introduce tu vida: \n");

            int p1 = int.Parse(Console.ReadLine()); //p1 = 5

            game.Escribir("introduce tu daño: \n");
            int p2 = int.Parse(Console.ReadLine());
            if (p2 > 100) p2 = 0;

            game.CreateCharacter(p1,  p2); // p1 = 5

            game.Escribir("Con cuantos deseas pelear \n");
            p1 = int.Parse(Console.ReadLine()); //p1 = 10

            game.CreateEnemy(p1);
            int p3;

            for (int i = 0; i < p1; i++)
            {
                game.Escribir("por favor ingresar los datos del enemigos (vida - daño): \n");
                p2 = int.Parse(Console.ReadLine()); //vida
                p3 = int.Parse(Console.ReadLine()); //daño
                game.EnemyValor(p2 , p3, i);
            }

            game.Combate();

            Console.ReadLine();


        }
    }
}
