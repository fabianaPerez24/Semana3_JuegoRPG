using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Enemigo
    {
        public String nombre;
        int vida;
        int daño;

        public Enemigo(int x, int y)
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

        public int Life()
        {
            return vida;
        }

        public bool Is_Dead()
        {
            if (vida <= 0)
            {
                return false;
            }
            else return true;
        }

    }
}