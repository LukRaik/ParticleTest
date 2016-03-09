using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleTest
{
    static class ObjectMenager
    {
        /*
         * System zarządzania obiektami
         */
        public static List<object> Obiekty = new List<object>();
        public static List<object> Smietnik = new List<object>();
        public static void Add(object obj, EventArgs e)
        {
            Obiekty.Add(obj);
        }
        public static void Usun(object obj,EventArgs e)
        {
            if (Obiekty.Contains(obj))
            {
                Smietnik.Add(obj);
            }
        }
        static public void Update()
        {
            if (Smietnik.Count >= 1)
            {
                foreach (object obj in Smietnik)
                {
                    Obiekty.Remove(obj);
                }
                Smietnik = new List<object>();
            }
        }
    }
}
