using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Jugador
    {
        public int vida;
        public int daño;

         public Jugador(int x, int y) 
         {
            vida = x;
            daño = y;
         }

        public void damage(int golpe)
        {
            vida -= golpe;
        }

        public int Atack()
        {
            return daño;
        }

        public bool Dead()
        {
            if (vida <= 0)
            {
                return false;
            }
            else return true;
        }
    }
}
