﻿using System;
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
        public void afegirAlumnes(String[,] alumnes) //Opcio1
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
            string nif, nom;
            int fila, filaLliure;
            string opcio;
            string acti;


            nif = DemanaAlumne();
            fila = existsNif(nif, alumnes);
            

            if (fila != REGISTRE_INEXISTENT)
            {
                Console.WriteLine("Alumne" + alumnes[fila, ALU_NOM]);
                Console.WriteLine("Introdueix el codi de la activitat a realitzar: ");
                Console.WriteLine("1. Sortida a esquiar");
                Console.WriteLine("2. Sortida a Port Aventura");
                Console.WriteLine("3. Sortida a Fira Games World");
                opcio = (Console.ReadLine());
                acti = GetActivitat(activitats, opcio) ;

                

                

            }


        }

           /* 2.Añadir inscripción(7 puntos)
- Se pidiera el nif del alumno que se quiere inscribir a una salida
-se comprobará si existe en el array de «alumnos», en caso afirmativo mostrará el nombre del alumno, (*)
-Después se pedirá el código de la actividad a la que se quiere apuntar, se comprobará si esa actividad existe,
en caso afirmativo mostrará el nombre de la actividad y de lo contrario mostrará un mensaje indicando que la actividad
no existe.
- Si el Nif y la actividad existen, componer si este alumno con esta actividad ya existe en el array inscripciones,
en caso afirmativo debe mostrar un mensaje indicando que este alumno ya está inscrito en esta actividad
-de lo contrario el programa debe preguntar si los datos son correctos, en caso afirmativo añadir en el array
inscripciones una fila con el Nif y Actividad.*/
        
        public string GetActivitat(String[,] activitats, string opcio)
        {
            bool encontrado = false;
            int i = 0;

            while (i < activitats.GetLength(0) & !encontrado)
            {
                if(activitats[i, ACT].Equals (opcio))
                {
                    encontrado = true;
                }
                else
                {
                    i++;
                }
            }
            if(encontrado)
            {
                return activitats[i, ACT];
            }
            else
            {
                return null;
            }


        }//busca act Array act retonra act
        public string DemanaAlumne()
        {
            string nif;
            Console.Write("Introdueix Dni del alumne: ");
            nif = Console.ReadLine();
            return nif;
        }//Demana Dni alumne, retorna Dni
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
        }//busca nif array alumnes
        public int getNewFilaAlumnes(String[,] alumnes)
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
        }//busca fila lliure Array Alumnes Retorna fila lliure

        const int REGISTRE_INEXISTENT = -1;
        const int ALU_NIF = 0;
        const int ALU_NOM = 1;
        const int ACT = 1;
        const int NUM_ACT = 0;
    }
}
