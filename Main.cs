using System;
using System.Collections.Generic;

// Author: Sonia Álvarez

class Program
{
    static void Main()
    {

       // constantes de fuerza de cada unidad
        const int fuerzaAldeano = 0;
        const int fuerzaGuerrero = 10;
        const int fuerzaArquero = 5;

        // Toda Unidad tiene el mismo valor entero para su salud/vida
        int vida = 20;

        bool gameOver = false;

        Random aleatorio = new Random();
        int equipoAtacante;

        // Creando una lista vacía para el equipo Azul
        List<Personaje> EquipoAzul = new List<Personaje>();
        List<Personaje> EquipoRojo = new List<Personaje>();

        // Agregando un Personaje a la lista del equipo Azul

        EquipoAzul.Add(new Aldeano(vida, fuerzaAldeano));
        EquipoAzul.Add(new Aldeano(vida, fuerzaAldeano));
        EquipoAzul.Add(new Arquero(vida, fuerzaArquero));
        EquipoAzul.Add(new Guerrero(vida, fuerzaGuerrero));


        EquipoRojo.Add(new Aldeano(vida, fuerzaAldeano));
        EquipoRojo.Add(new Aldeano(vida, fuerzaAldeano));
        EquipoRojo.Add(new Arquero(vida, fuerzaArquero));
        EquipoRojo.Add(new Guerrero(vida, fuerzaGuerrero));

        while (! gameOver) {
            // Escogemos atacante
            //Con enteros, el valor máximo está excluido
            equipoAtacante = aleatorio.Next(,2);
            if (equipoAtacante == 0) {  
                // Ataca EquipoAzul
                LanzarAtaque(EquipoAzul, EquipoRojo);
            } else {
                // Ataca EquipoRojo
                LanzarAtaque(EquipoRojo, EquipoAzul);
            }
        }

        if (EquipoAzul.length > 0) {
            Console.WriteLine("Ganador: EQUIPO AZUL.");
        } else {
            Console.WriteLine("Ganador: EQUIPO ROJO.");
        }
        


    }


    private void LanzarAtaque(List<Personaje> equipo1, List<Personaje> equipo2) {

        // Escoger unidad atacante
        Personaje atacante = equipo1(Random.Range(0, equipo1.length));
        // Escoger unidad atacada
        
        int atacadoIndex = Random.Range(0, equipo2.length);
        Personaje atacado = equipo2(atacadoIndex);
        // Ejecutar ataque
        atacado.ReceiveAttack(atacante);
        if (atacado.IsDead()) {
            equipo2.RemoveAt(atacadoIndex);
            if (equipo2.length == 0) {
                gameOver = true;
            }
        }
    }



}

 

// Cada equipo juega con varios tipos de personajes (Unidades)
// Cada Tipo se distingue por:
//      su cantidad de salud/vida (En este caso igual para todas)
//      su cantidad de fuerza de ataque

public abstract class Personaje {

    protected int Life {get; set;}
    protected int Attack {get; set;}

    public void LoseLife(int value) {
        this.Life -= value;
    }

    public void ReceiveAttack(Personaje other) {
        if (this.Attack <= other.Attack) {
            LoseLife(other.Attack);
        }
    }

    public bool IsDead() {
        return Life<=0;
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

/**
    public int Vida
    {
        get { return _Vida; }
        set { _Vida = value; }
    }

    public int getAttack
    {
        get { return Attack; }
        set { _Ataque = value; }
    }
*/
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
/**
    public int Vida
    {
        get { return _Vida; }
        set { _Vida = value; }
    }

    public int getAttack
    {
        get { return Attack;}
        set { _Ataque = value; }
    }
*/
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
/**
    public int Vida
    {
        get { return _Vida; }
        set { _Vida = value; }
    }

    public int getAttack
    {
        get { return Attack; }
        set { _Ataque = value; }
    }
*/
}


