using System;
using System.Collections.Generic;

// Author: Sonia Álvarez

class Program
{
    static void Main()
    {
        // Probando que compila y que se usan tipos enumerados
       const int fuerzaAldeana = 0;
       const int fuerzaGuerrero = 10;
       const int fuerzaArquero = 5;


        

        // Toda Unidad tiene el mismo valor entero para su salud/vida
        int vida = 20;

        // Creando una lista vacía para el equipo Azul
        List<Personaje> EquipoAzul = new List<Personaje>();

        // Probando una instancia de la clase Personaje
        Arquero pepe = new Arquero (
            vida, 
            fuerzaArquero 
        );

        // Agregando un Personaje a la lista del equipo Azul
        EquipoAzul.Add( pepe );

        EquipoAzul[0].Info();
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


