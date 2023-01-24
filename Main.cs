using System;
using System.Collections.Generic;

class Program
{
    // Nota de Sonia:
        // El método Main() debe ser estático en .NET (creo)
    static void Main()
    {
        // Constantes de fuerza de cada unidad
        const int fuerzaAldeana = 0;
        const int fuerzaGuerrera = 10;
        const int fuerzaArquera = 5;
        // Constante de salud/vida
        const int vida = 20;

        // Antes de la primera elección de turno
        int equipoAtacante = -1;

        // Variable global de fin de juego (por implementar)
            // Nota de Sonia:
                // No se puede poner pública
        bool gameOver = false;

        // Entero en DEV para contar las vueltas de ejecución
        // mientras gameOver == true
        int update = 0;

        // Random() es un método que se debe crear para cada uso
        // Random aleatorio = new Random();

        // Creando una lista vacía para el equipo Azul
        List<Personaje> EquipoAzul = new List<Personaje>();
        List<Personaje> EquipoRojo = new List<Personaje>();

        // Agregando 4 unidades al equipo azul
        EquipoAzul.Add(new Aldeano(vida, fuerzaAldeana));
        EquipoAzul.Add(new Aldeano(vida, fuerzaAldeana));
        EquipoAzul.Add(new Arquero(vida, fuerzaArquera));
        EquipoAzul.Add(new Guerrero(vida, fuerzaGuerrera));

        // Agregando 4 unidades al equipo rojo
        EquipoRojo.Add(new Aldeano(vida, fuerzaAldeana));
        EquipoRojo.Add(new Aldeano(vida, fuerzaAldeana));
        EquipoRojo.Add(new Arquero(vida, fuerzaArquera));
        EquipoRojo.Add(new Guerrero(vida, fuerzaGuerrera));

        while ( ! gameOver ) {
            // Establecer turnos de ataque
            // Se inicia con una moneda al aire

            equipoAtacante = SetTurno( equipoAtacante );

            // (DEV) Mostrando las vueltas de ejecución
            update++;
            Console.WriteLine( $"Class Program: Ejecutando Main() num {update}. Turno para: {equipoAtacante}.\n" );

            // Turno para el equipo azul == 0
            if ( equipoAtacante == 0 ) {

                gameOver = LanzarAtaque( EquipoAzul, EquipoRojo );

                // Turno para el equipo rojo == 1
            } else {

                gameOver = LanzarAtaque( EquipoRojo, EquipoAzul );
            }
        }

        // El método Length() es para arrays. Count() para listas
        if ( EquipoAzul.Count > 0 ) {
            Console.WriteLine( "Ganador: EQUIPO AZUL." );
        } else {
            Console.WriteLine( "Ganador: EQUIPO ROJO." );
        }
    }

    // Solucionar error de compilación
    // error CS0120: An object reference is required for the non-static field, method, or property 'Program.LanzarAtaque(List<Personaje>, List<Personaje>)'

    // El método Main es estático y sólo puede acceder a miembros estáticos
    // de la misma clase

    static bool LanzarAtaque(List<Personaje> equipo1, List<Personaje> equipo2)
    {
        Random rnd = new Random();

        // Para enviar (o no) el gameOver
        bool noDanger = false;

        // Escoger unidad atacante
        int atacanteIndex = rnd.Next( equipo1.Count);
        Personaje atacante = equipo1[ atacanteIndex ];

        // Escoger unidad atacada
        int atacadoIndex = rnd.Next( equipo2.Count);
        Personaje atacado = equipo2[ atacadoIndex ];

        // Ejecutar ataque
        atacado.ReceiveAttack( atacante );
        if ( atacado.IsDead() )
        {
            equipo2.RemoveAt( atacadoIndex );
            if ( equipo2.Count == 0 )
            {
                // gameOver = true;
                // Cuando no haya unidades enemigas se establece el gameOver
                noDanger = true;
                Console.WriteLine( "*** GAME OVER ***" );
            }
        }

        return noDanger;
    }


    static int SetTurno ( int atacante )
    {
        Random rnd = new Random();

        switch( atacante )
        {
            case 0:
                atacante = 1;
            break;

            case 1:
                atacante = 0;
            break;

            // Escogemos atacante ( moneda al aire )
            default:
                // Random.Next(int maxValue)
                // devuelve un entero aleatorio no negativo
                // El primer parámetro se incluye y el segundo se excluye

                // Se corrige errata
                // equipoAtacante = aleatorio.Next(,2);
                atacante = rnd.Next(2);
            break;
        }

        return atacante;
    }
}

// Cada equipo juega con varios tipos de personajes (Unidades)
// Cada Tipo se distingue por:
//      su cantidad de salud/vida (En este caso igual para todas)
//      su cantidad de fuerza de ataque

public abstract class Personaje {

    protected int Life { get; set; }
    protected int Attack { get; set; }

    public void LoseLife( int value )
    {
        this.Life -= value;
    }

    public void ReceiveAttack( Personaje other ) {
        if ( this.Attack <= other.Attack )
        {
            LoseLife(other.Attack);
        }
    }

    public bool IsDead() {
        return Life <=0;
    }
}


public class Arquero: Personaje
{

    public Arquero (
    int pVida,
    int pAtaque )
    {
        Life = pVida;
        Attack = pAtaque;
    }
}


public class Guerrero: Personaje
{

    public Guerrero (
    int pVida,
    int pAtaque )
    {
        base.Life = pVida;
        base.Attack = pAtaque;
    }
}


public class Aldeano: Personaje
{

    public Aldeano (
    int pVida,
    int pAtaque )
    {
        base.Life = pVida;
        base.Attack = pAtaque;
    }
}
