using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp7
{
    class juego
    {
        Jugador player;
        List<Enemigo> EnemyList = new List<Enemigo>();
        Enemigo test = new Enemigo(0,0);
        Random rnd = new Random();
        int Enemyname = 0;

        public void CreateCharacter(int p1, int p2) 
        {
            player = new Jugador(p1, p2);
        }

        public void CreateEnemy(int p1) 
        {
            for(int i = 0; i < p1; i++) 
            {
                EnemyList.Add(test);
            }
        }

        public void EnemyValor(int p1, int p2, int x)
        {
            for (int i = 0; i < EnemyList.Count; i++)
            {
                if(i == x) 
                {
                    EnemyList[i] = new Enemigo(p1, p2);
                }
            }
        }

        public void Combate()
        {
            for (int i = 0; i < EnemyList.Count; i++) // revisamos si tenemos un enemigo muerto
            {
                if (EnemyList[i].Is_Dead() == false)
                {
                    EnemyList.RemoveAt(i);
                    i -= 1;
                }
            }

            if(player.Dead() == true) 
            {
                while (EnemyList.Count > 0)
                {
                    bool continuar = true;
                    int p1 = 0;

                    mostrar_Consola();

                    Escribir("a quien te deseas madrear: \n");

                    while (continuar)
                    {
                        p1 = int.Parse(Console.ReadLine()) - 1;
                        if (p1 < EnemyList.Count && p1 >= 0)
                        {
                            continuar = false;
                        }
                        else Escribir("selecciones un numero dentro de sus posibilidades \n");
                    }

                    Console.WriteLine("\n");
                    Escribir("-------------------------------------------------------------- \n");

                    EnemyList[p1].damage(player.daño); //atacamos al enemigo seleccionado

                    Escribir($"{EnemyList[p1].nombre} a sufrido {player.daño} de daño \n");

                    if (EnemyList[p1].Is_Dead() == false)
                    {
                        Escribir($"Enemigo {EnemyList[p1].nombre} a sido derrotado \n");
                        EnemyList.RemoveAt(p1);
                    }

                    if (EnemyList.Count > 0)
                    {
                        p1 = rnd.Next(0, EnemyList.Count);

                        player.damage(EnemyList[p1].Atack());

                        Escribir($"Enemigo {EnemyList[p1].nombre} te ah atacado \n");
                        Escribir($" has recibido {EnemyList[p1].Atack()} de daño \n");

                        Escribir("-------------------------------------------------------------- \n");
                    }

                    if (player.Dead() == false)
                    {
                        Escribir("\n\n Fuiste derrotado");
                        Escribir("\n\n\n\n\n\n Fin del juego");

                       while(EnemyList.Count > 0)
                        {
                            EnemyList.RemoveAt(0);
                        }
                    }
                }
                if (EnemyList.Count <= 0 && player.Dead() == true)
                {
                    Escribir("\n\n Felicidades Conseguiste derrotar a todos los enemigos");
                    Escribir("\n\n\n\n\n\n Fin del juego");
                }
            }
            
        }


        public void mostrar_Consola() //para ver la cantidad de enemigos que se tiene dentro del juego 
        {
            Escribir("-------------------------------------------------------------- \n");
            Escribir( $"Player..... Vida: {player.vida} / Daño: {player.daño}\n");
            Escribir("-------------------------------------------------------------- \n");
            mostrar();
            Escribir("-------------------------------------------------------------- \n");
        }


        public void mostrar() //para ver la cantidad de enemigos que se tiene dentro del juego 
        {
            char n1 = 'j';

            while (Enemyname == 0)
            {
                for (int i = 0; i < EnemyList.Count; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        n1 = Convert.ToChar(rnd.Next(97, 123));
                        EnemyList[i].nombre = EnemyList[i].nombre + n1;
                    }
                }
                Enemyname = 1;
            }

            for (int i = 0; i < EnemyList.Count; i++)
            {
                Escribir($"{i + 1}....{EnemyList[i].nombre}: Vida: {EnemyList[i].Life()} / Daño: { EnemyList[i].Atack()} \n");
            }
        }

        public void Escribir(string text) //crea un texto dinamico
        {
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                Thread.Sleep(15);
            }
        }
    }
}
