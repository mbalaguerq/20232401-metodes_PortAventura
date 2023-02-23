using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Channels;
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
            filalliure = GetNewFilaAlumnes(alumnes);

            if (fila != REGISTRE_INEXISTENT)
            {
                Console.WriteLine("L'alumne ja està registrat. ");
                Console.WriteLine("Alumne" + alumnes[fila, ALU_NOM]);
                Console.WriteLine();
            }
            else
            {
                alumnes[filalliure, ALU_NIF] = nif;
                alumnes[filalliure, ALU_NOM] = nom;
            }
            Console.WriteLine("NIF\t\t " + "NOM\t");

            for (int i = 0; i < alumnes.GetLength(0); i++)
            {
                if (alumnes[i, ALU_NIF] != null)
                {
                    Console.Write(alumnes[i, ALU_NIF] + "\t" + alumnes[i, ALU_NOM] + "\n");
                }
            }
            Console.WriteLine();
        }

        public void novaInscripció(String[,] inscripcions, String[,] alumnes, String[,] activitats)//opció 2
        {
            /* 2.Añadir inscripción(7 puntos)
            - Se pidiera el nif del alumno que se quiere inscribir a una salida
            -se comprobará si existe en el array de «alumnos», en caso afirmativo mostrará el nombre del alumno, (*)
            -Después se pedirá el código de la actividad a la que se quiere apuntar, se comprobará si esa actividad existe,
            en caso afirmativo mostrará el nombre de la actividad y de lo contrario mostrará un mensaje indicando que 
            la actividad no existe.
            - Si el Nif y la actividad existen, comprobar si este alumno con esta actividad ya existe en el array inscripciones,
            en caso afirmativo debe mostrar un mensaje indicando que este alumno ya está inscrito en esta actividad
            - de lo contrario el programa debe preguntar si los datos son correctos, en caso afirmativo añadir en el array
            inscripciones una fila con el Nif y Actividad.*/

            string nif;
            int fila, filaLliure;
            string opcio, acti, resposta;


            nif = DemanaAlumne();
            fila = existsNif(nif, alumnes);

            Console.WriteLine();


            if (fila == REGISTRE_INEXISTENT)//si l'alumne no existeix
            {
                Console.WriteLine("Alumne no registrat");
                afegirAlumnes(alumnes);
            }


            else//si l'alumne existeix
            {
                Console.WriteLine("Alumne: " + alumnes[fila, ALU_NOM]);
                Console.WriteLine("Introdueix el codi de la activitat a realitzar: ");
                Console.WriteLine("1. Sortida a esquiar");
                Console.WriteLine("2. Sortida a Port Aventura");
                Console.WriteLine("3. Sortida a Fira Games World");
                Console.WriteLine("4. Sortida a Catalunya en Miniatura");
                Console.WriteLine("5. Sortida al parc Güell");
                Console.WriteLine("6. Sortida Visita Andorra en un dia");

                opcio = (Console.ReadLine());
                Console.WriteLine();
                acti = GetActivitat(activitats, opcio);

                if (!acti.Equals(""))//si la activitat a realitzar existeix
                {
                    Console.WriteLine("Activitat disponible: " + acti);

                    fila = 0;
                    fila = GetInscripcions(inscripcions, nif);

                    if (fila != REGISTRE_INEXISTENT)//Si ja està registrat a activitats
                    {
                        Console.WriteLine("Aquest alumne ja està inscrit a l'activitat " + activitats[fila, INS_ACTI]);
                    }
                    else
                    {
                        Console.WriteLine("Indiqui si les dades són correctes: ");
                        Console.WriteLine("DNI: " + nif);
                        Console.WriteLine("Activitat: " + acti);
                        Console.Write("S/N :");
                        resposta = Console.ReadLine();
                        resposta.ToLower();

                        if (resposta == "s")//si les dades son correctes
                        {
                            filaLliure = 0;
                            filaLliure = GetNewFilaInscripcions(inscripcions);
                            {
                                if (filaLliure != REGISTRE_INEXISTENT) //Si hi ha una fila lliure
                                {
                                    nif = inscripcions[filaLliure, INS_NOM];
                                    acti = inscripcions[filaLliure, INS_ACTI];

                                    //llistem array activitats
                                    for (int i = 0; i < inscripcions.GetLength(0); i++)
                                    {
                                        for (int j = 0; j < inscripcions.GetLength(1); j++)
                                        {
                                            Console.Write(inscripcions[i, j] + "\t");
                                        }
                                    }
                                }
                                else//Si no hi ha fila lliurel'array està plè
                                {
                                    Console.WriteLine("Incidència. Avisi al tècnic");
                                    Console.WriteLine();
                                }
                            }
                        }

                    }

                }
                else //si la activitat no existeix
                {
                    Console.WriteLine("Activitat no disponible ");
                    Console.WriteLine();
                }
            }

        }


        public void llistaInscripcio(String[,] inscripcions, String[,] alumnes, String[,] activitats)//opció 3
        {

        }

        //3. Lista de inscripciones de una actividad (1,5 puntos)
        //Debe pedir el código de una actividad, comprobar si existe en el array "actividades", 
        //  en caso afirmativo debe mostrar el nombre de la actividad y a continuación mostrar el nif y el nombre 
        //de todos los alumnos inscritos en la actividad

        public string GetActivitat(String[,] activitats, string opcio)
        {
            bool encontrado = false;
            int i = 0;

            while (i < activitats.GetLength(0) & !encontrado)
            {
                if (activitats[i, NUM_ACT].Equals(opcio))
                {
                    encontrado = true;
                }
                else
                {
                    i++;
                }
            }
            if (encontrado)
            {
                return activitats[i, NUM_ACT];
            }
            else
            {
                return null;
            }
        }//busca act Array act retonra act
        public int GetInscripcions(String[,] inscripcions, string nif)
        {
            bool encontrado = false;
            int i = 0;

            while (i < inscripcions.GetLength(0) & !encontrado)
            {
                if (inscripcions[i, INS_NOM].Equals(nif))
                {
                    encontrado = true;
                }
                else
                {
                    i++;
                }
            }
            if (encontrado)
            {
                return i;
            }
            else
            {
                return REGISTRE_INEXISTENT;
            }
        }
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
        public int GetNewFilaAlumnes(String[,] alumnes)
        {
            bool encontrado = false;
            int filaLliure = 0;
            while (filaLliure < alumnes.GetLength(0) & !encontrado)
            {
                if (alumnes[filaLliure, ALU_NIF] == null)
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
        public int GetNewFilaInscripcions(String[,] inscripcions)
        {
            bool encontrado = false;
            int filaLliure = 0;
            while (filaLliure < inscripcions.GetLength(0) & !encontrado)
            {
                if (inscripcions[filaLliure, ALU_NIF] == null)
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
            } //busca fila lliure Array Iniscripcions Retorna fila lliure
        }

        const int REGISTRE_INEXISTENT = -1;
        const int ALU_NIF = 0;
        const int ALU_NOM = 1;
        const int ACT = 1;
        const int NUM_ACT = 0;
        const int INS_NOM = 0;
        const int INS_ACTI = 1;
    }
}


