using System;
using System.Collections.Generic;

// Author: Sonia Álvarez

class Program
{
    static void Main()
    {
        // Probando que compila y que se usan tipos enumerados
       const int fuerzaAldeano = 0;
       const int fuerzaGuerrero = 10;
       const int fuerzaArquero = 5;

       private bool gameOver = false;

        // Toda Unidad tiene el mismo valor entero para su salud/vida
        int vida = 20;

        // Creando una lista vacía para el equipo Azul
        List<Personaje> EquipoAzul = new List<Personaje>();
        List<Personaje> EquipoRojo = new List<Personaje>();

        // Agregando un Personaje a la lista del equipo Azul

        EquipoAzul.Add(new Aldeano(20, fuerzaAldeano));
        EquipoAzul.Add(new Aldeano(20, fuerzaAldeano));
        EquipoAzul.Add(new Arquero(20, fuerzaArquero));
        EquipoAzul.Add(new Guerrero(20, fuerzaGuerrero));


        EquipoRojo.Add(new Aldeano(20, fuerzaAldeano));
        EquipoRojo.Add(new Aldeano(20, fuerzaAldeano));
        EquipoRojo.Add(new Arquero(20, fuerzaArquero));
        EquipoRojo.Add(new Guerrero(20, fuerzaGuerrero));

        while (! gameOver) {
            LanzarAtaque(EquipoAzul, EquipoRojo);
        }


    }


    private LanzarAtaque(List<Personaje> equipo1, List<Personaje> equipo2) {

        // escoger equipo atacante

        //

    }



}




 

// Cada equipo juega con varios tipos de personajes (Unidades)
// Cada Tipo se distingue por:
//      su cantidad de salud/vida (En este caso igual para todas)
//      su cantidad de fuerza de ataque

public abstract class Personaje {
    public abstract int Attack();
    public abstract void LoseLife(int value);

    public void Info() {
        Console.WriteLine($"Este personaje tiene {Attack()} fuerza de ataque");
    }
}


public class Arquero: Personaje
{
    private int _Vida;
    private int _Ataque;

    public Arquero (
        int pVida,
        int pAtaque )
    {
        Vida = pVida;
        Ataque = pAtaque;
    }

    public int Vida
    {
        get { return _Vida; }
        set { _Vida = value; }
    }

    public int Ataque
    {
        get { return _Ataque; }
        set { _Ataque = value; }
    }

    public override int Attack()
    {
        return Ataque;
    }

    public override void LoseLife ( int atack )
    {
        Vida -= atack;
    }
}

    public class Guerrero: Personaje
{
    private int _Vida;
    private int _Ataque;

    public Guerrero (
        int pVida,
        int pAtaque )
    {
        Vida = pVida;
        Ataque = pAtaque;
    }

    public int Vida
    {
        get { return _Vida; }
        set { _Vida = value; }
    }

    public int Ataque
    {
        get { return _Ataque; }
        set { _Ataque = value; }
    }

    public override int Attack()
    {
        return Ataque;
    }

    public override void LoseLife ( int atack )
    {
        Vida -= atack;
    }

}
    public class Aldeano: Personaje
{
    private int _Vida;
    private int _Ataque;

    public Aldeano (
        int pVida,
        int pAtaque )
    {
        Vida = pVida;
        Ataque = pAtaque;
    }

    public int Vida
    {
        get { return _Vida; }
        set { _Vida = value; }
    }

    public int Ataque
    {
        get { return _Ataque; }
        set { _Ataque = value; }
    }

    public override int Attack()
    {
        return Ataque;
    }

    public override void LoseLife ( int atack )
    {
        Vida -= atack;
    }

}


