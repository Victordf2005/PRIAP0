public class Personaje {

    protected int vida;
    protected int ataque;

    public Personaje(
        int vida,
        int ataque )
    {
        this.vida = vida;
        this.ataque = ataque;
    }

}

// Esto es un comentario
public class Guerrero : Personaje {
    public Guerrero() : base (20, 10) {}
}

public class Arquero : Personaje {
    public Arquero() : base(20, 5) {}
}

public class Aldeano : Personaje {
    public Aldeano(): base(20, 0) {}
}

