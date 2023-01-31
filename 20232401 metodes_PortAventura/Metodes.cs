using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _20232401_metodes_PortAventura
{
    internal class Metodes
    {
        public void afegirAlumnes(String[,] alumnes)
        {
            string nif;
            string nom;
            int fila;
            int filalliure;

            nif = DemanaAlumne();
            Console.Write("Nom: ");
            nom = Console.ReadLine();
            fila = existsNif(nif, alumnes);
            filalliure = getNewFilaAlumnes(alumnes);

            if (fila !=REGISTRE_INEXISTENT)
            {
                Console.WriteLine("L'alumne ja està registrat. ");
                Console.WriteLine("Alumne" +  alumnes[fila,ALU_NOM]);
                Console.WriteLine();
            }
            else
            {
                alumnes[filalliure, ALU_NIF] = nif;
                alumnes[filalliure,ALU_NOM] = nom;
            }
        }

        public void novaInscripció(String[,] inscripcions, String[,] alumnes, String[,] activitats)
        {
            string nif;
            string nom;
            int fila;
            int filalliure;

            nif = DemanaAlumne();
            fila = existsNif(nif, alumnes);

            if (fila != REGISTRE_INEXISTENT)
            {
               
                Console.WriteLine("Alumne" + alumnes[fila, ALU_NOM]);
                Console.ReadLine();
            }

        }



        public string DemanaAlumne()
        {
            string nif;
            Console.Write("Introdueix Dni del CLient: ");
            nif = Console.ReadLine();
            return nif;
        }
        int existsNif(String nif, String[,] alumnes)
        {
            bool encontrado = false;
            int fila = 0;

            while (fila < alumnes.GetLength(0) & !encontrado)
            {
                if (nif.Equals(alumnes[fila, ALU_NIF]))
                {
                    encontrado = true;
                }
                else
                {
                    fila++;
                }

            }
            if (encontrado)
            {
                return fila;
            }
            else
            {
                return REGISTRE_INEXISTENT;
            }
        }
        int getNewFilaAlumnes(String[,] alumnes)
        {
            bool encontrado = false;
            int filaLliure = 0;
            while (filaLliure < alumnes.GetLength(0) & !encontrado)
            {
                if (alumnes[filaLliure, ALU_NIF].Equals(""))
                {
                    encontrado = true;
                }
                else
                {
                    filaLliure++;
                }
            }
            if (encontrado)
            {
                return filaLliure;
            }
            else
            {
                return REGISTRE_INEXISTENT;
            }
        }

        const int REGISTRE_INEXISTENT = -1;
        const int ALU_NIF = 0;
        const int ALU_NOM = 1;
    }
}
