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
        Metodes metode = new Metodes();
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
                    metode.afegirAlumnes(alumnes);
                    break;
                    case "2":
                    metode.novaInscripció(alumnes, inscripcions, activitats);
                    break;
                    case "3":
                    metode.llistaInscripcio(alumnes, inscripcions, activitats);
                    break;
                case "0":
                    salir = true;
                    break;

            }
            return salir;
        }
        void mostrarMenu()
        {
            Console.WriteLine("1. Afegir Alumnes");
            Console.WriteLine("2. Afegir Inscripcions");
            Console.WriteLine("3. Llistar inscripcions");
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
                     { "1" }, {"Salida a esquiar" },
                     { "2" }, {"Salida a Port Aventura" },
                     { "3" }, {"Feria Games World" },};

            return activitats;
        }
    }
}   

/* 1.Añadir alumnos(1, 5 puntos)
Se pedirán los datos Nif y Nombre, se comprobará si este alumno ya existe en el array «alumnos» y si no está, 
pues se añadirá en el array, en caso de que exista debe mostrar el mensaje 
"Este alumno ya existe, su nombre es: Ramon Lopez"

2. Añadir inscripción (7 puntos)
-Se pidiera el nif del alumno que se quiere inscribir a una salida
- se comprobará si existe en el array de «alumnos», en caso afirmativo mostrará el nombre del alumno, (*)
- Después se pedirá el código de la actividad a la que se quiere apuntar, se comprobará si esa actividad existe, 
en caso afirmativo mostrará el nombre de la actividad y de lo contrario mostrará un mensaje indicando que la actividad 
no existe.
- Si el Nif y la actividad existen, componer si este alumno con esta actividad ya existe en el array inscripciones, 
en caso afirmativo debe mostrar un mensaje indicando que este alumno ya está inscrito en esta actividad
- de lo contrario el programa debe preguntar si los datos son correctos, en caso afirmativo añadir en el array 
inscripciones una fila con el Nif y Actividad.

(*) Opcionalmente(1 punto) si el alumno no existe, preguntar si se quiere dar de alta, en caso afirmativo, 
pedir el nombre y añadirlo al array "alumnos"

3. Lista de inscripciones de una actividad (1,5 puntos)
Debe pedir el código de una actividad, comprobar si existe en el array "actividades", en caso afirmativo debe mostrar 
el nombre de la actividad y a continuación mostrar el nif y el nombre de todos los alumnos inscritos en la actividad
*/
