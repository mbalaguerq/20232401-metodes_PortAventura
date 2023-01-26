using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _20232401_metodes_PortAventura
{
    internal class Aplicacio
    {
        public void Inici()
        {

            String[,] alumnes = DadesAlumnes();
            String[,] inscripcions = DadesInscripcions();
            String[,] activitats = DadesActivitats();


            bool salir = false;
            string opcio;

            do
            {
                mostrarMenu();
                opcio = DemanarOpcioMenu();
                salir = ExecutarMenu(alumnes, inscripcions, activitats, opcio);

            } while (!salir);
            Console.WriteLine();

        }

        string DemanarOpcioMenu()
        {
            string opcio;
            do
            {
                Console.Write("Sel.lecciona opció: ");
                opcio = Console.ReadLine();
            } while (!"0123456789".Contains(opcio));
            return opcio;
        }


        bool ExecutarMenu(String[,] alumnes, String[,] inscripcions, String[,] activitats, string opcio)
        {
            bool salir = false;
            switch (opcio)
            {
                case "1":
                    ;
                    break;
                case "0":
                    salir = true;
                    break;

            }
            return salir;
        }

        void mostrarMenu()
        {
            Console.WriteLine("1.  ");
            Console.WriteLine("2. ");
            Console.WriteLine("3. ");
            Console.WriteLine("4. ");
            Console.WriteLine("5. ");
            Console.WriteLine("6. ");
            Console.WriteLine("7. ");
            Console.WriteLine("8. ");
            Console.WriteLine("9. ");
            Console.WriteLine("0. Sortir");
        }



        string[,] DadesAlumnes()
        {
            //nif/nom
            String[,] alumnes = new String[50, 2];
            return alumnes;
        }
        string[,] DadesInscripcions()
        {
            //nif/codi activitat
            String[,] inscripcions = new String[50, 2];
            return inscripcions;
        }
        string[,] DadesActivitats()
        {
            //codi activitat/nom activitat
            String[,] activitats = {
                    { "1, Salida a esquiar" }, { "2, Salida a Port Aventura" }, { "3,Feria Games World" } };
            return activitats;
        }
    }
}   

