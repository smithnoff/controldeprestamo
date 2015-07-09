using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int salario_base = 0, salario_extra = 0, horas_laboradas = 0;

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("trabajador nro "+(i+1));
                Console.WriteLine("ingrese horas trabajadas:");

                horas_laboradas = Int32.Parse(Console.ReadLine());

                if (horas_laboradas <= 40)
                {
                    salario_base = 200 * horas_laboradas;

                }
                else
                {
                    if (horas_laboradas>40)
                    {
                        salario_extra=(horas_laboradas-40)*250;
                        salario_base = (40 * 200) + salario_extra;
                    }

                }     Console.WriteLine("el salario es: "+salario_base);
                Console.WriteLine("*******************************************");
                Console.WriteLine("");
           
            }
        }
    }
}
