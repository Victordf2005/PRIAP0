using System;
using System.Collections.Generic;
using System.Linq;


/*
 Autores: Gabriel,Sonia,Victor,Racha
*/
namespace Practica1
{
    //Clase unidad clase principal de la cuales descenderan guerrero y arquero por defecto la unidad se tomara como un aldeano
    public class Unidad
    {
        //Propiedades de la unidad
        #region propiedades
        protected short vida;
        protected short ataque;
        // tipoUnidad 0 = aldeano 1 = guerrero 2 = arquero
        protected short tipoUnidad;
        #endregion

        public Unidad()
        {

            this.vida = 20;
            this.ataque = 0;
            this.tipoUnidad = 0;
        }
        #region Funciones
        public short Vida()
        {
            //Devuelve la vida de la unidad
            return this.vida;
        }
        public short RestarVida(short v)
        {
            //resta vida a la unidad
            this.vida -= v;
            if (vida <= 0)
            {
                this.vida = 0;
                Console.WriteLine($"Unidad {this.TipoUnidad()} a muerto\n");
            }

            return Vida();
        }
        public short Ataque()
        {
            //devuelve valor del ataque
            return this.ataque;
        }
        public String TipoUnidad()
        {
            //devuelve valor del ataque
            switch (this.tipoUnidad)
            {
                case 0:
                    return "Aldeano:";
                case 1:
                    return "Guerrero:";
                case 2:
                    return "Arquero:";
                default:
                    return "No Definido:";

            }
        }
        #endregion

    }
    //Clase Guerrero hereda de unidad
    public class Guerrero : Unidad
    {
        public Guerrero() : base()
        {
            base.ataque = 10;
            base.tipoUnidad = 1;
        }
    }
    //Clase Arquero hereda de unidad
    public class Arquero : Unidad
    {
        public Arquero() : base()
        {
            base.ataque = 5;
            base.tipoUnidad = 2;
        }
    }

    public class Program
    {
        //Creamos las listas de los dos equipos
        private static List<Unidad> equipoRojo = CrearEquipo();
        private static List<Unidad> equipoAzul = CrearEquipo();
        public static void Main(string[] args)
        {
            //el primer turno lo elejimos aleatoriamente entre 0 y 1 0 = rojo 1 = azul
            short turno = (short)new Random().Next(0, 2);
            //el primer turno lo elejimos quien va a atacar
            short atacante = (short)new Random().Next(0, equipoRojo.Count());
            //el primer turno lo elejimos  quien va a defender
            short defensor = (short)new Random().Next(0, equipoAzul.Count());
            //variable bool que controla el bucle del juego
            bool fin = false;
            do
            {
                //usaremos el bucle do while como bucle de juego y cuando un equipo tenga las vidas totales a 0 este equipo perdera y saldremos del bucle
                //se cambia el turno al siguiente equipo
                turno = (turno == 0) ? turno = 1 : turno = 0;

                switch (turno)
                {
                    case 0:
                        //turno del equipo rojo
                        if (VidasEquipo(equipoRojo))
                        {
                            fin = true;
                            Console.WriteLine("Equipo Azul Gana\n");
                            break;
                        }
                        else
                        {
                            Console.Write("Turno del equipo rojo: ");
                            AcionesDeTurno(equipoRojo[atacante], equipoAzul[defensor]);
                            break;
                        }
                    case 1:
                        //turno del equipo Azul
                        if (VidasEquipo(equipoAzul))
                        {
                            fin = true;
                            Console.WriteLine("Equipo Rojo Gana\n");
                            break;
                        }
                        Console.Write("Turno del equipo azul: ");
                        AcionesDeTurno(equipoAzul[atacante], equipoRojo[defensor]);
                        break;
                    default:
                        Console.WriteLine("Error: equipos no saben que hacer en el truno");
                        break;
                }
                //se eligue al defensor
                defensor = DefensorVivo(turno);
                //se eligue al atacante 
                atacante = (short)new Random().Next(0, equipoAzul.Count());
            } while (!fin);
            //Cuando el equipo se queda sin unidades vivas finalizamos el bucle 
            Console.ReadLine();
        }

        private static List<Unidad> CrearEquipo()
        {
            List<Unidad> listTemp = new List<Unidad>();
            listTemp.Add(new Unidad());
            listTemp.Add(new Guerrero());
            listTemp.Add(new Unidad());
            listTemp.Add(new Arquero());
            return listTemp;
        }

        private static bool VidasEquipo(List<Unidad> equipo)
        {
            short vidas = 0;
            foreach (Unidad item in equipo)
            {
                vidas += item.Vida();
            }
            return vidas <= 0;
        }

        private static void AcionesDeTurno(Unidad atacante, Unidad defensor)
        {
            if (atacante.Vida() == 0)
            {
                Console.WriteLine($"{atacante.TipoUnidad()} muerto pasa turno\n");
            }
            else
            {
                Console.Write($"{atacante.TipoUnidad()} Ataca {defensor.TipoUnidad()} defiende\t");

                if ((atacante.Ataque() + defensor.Ataque()) == 0)
                {
                    //si un aldeano ataca a otro este le arra 5 de daño ya que podria llegar a un bucle infinito si no se hace
                    Console.Write($"{atacante.TipoUnidad()} Infrigue: 5 de daño a {defensor.TipoUnidad()} \n");
                    defensor.RestarVida(5);
                }
                else
                {
                    Console.Write($"{atacante.TipoUnidad()} Infrigue: {atacante.Ataque()} de daño a {defensor.TipoUnidad()} \n");
                    defensor.RestarVida(atacante.Ataque());
                }
            }
        }

        private static short DefensorVivo(short t)
        {//se eligue aleatoriamente un defensor si este esta muerto se vuelve a comprobar
            short num = 0;
            Unidad unidadTemp;
            do
            {
                num = (short)new Random().Next(0, equipoRojo.Count());
                //al tener los mismos miembros calculamos el ramdon con uno para ambos
                unidadTemp = (t == 0) ? unidadTemp = equipoRojo[num] : unidadTemp = equipoAzul[num];

            } while (unidadTemp.Vida() == 0);
            return num;
        }
    }
}