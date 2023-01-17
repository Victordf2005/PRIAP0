protected class Personaje {

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
protected class Guerrero : Personaje {
    public Guerrero() : base (20, 10) {}
}

protected class Arquero : Personaje {
    public Personaje() : base(20, 5) {}
}

protected class Aldeano : Personaje {
    public Aldeano(): base(20, 0) {}
}

