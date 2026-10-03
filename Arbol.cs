public class Arbol
{
    public Nodo? Raiz;

    public Arbol()
    {
        Raiz = null;
    }

    public void Insertar(int valor)
    {
        Raiz = InsertarNodo(Raiz, valor);
    }

    private Nodo InsertarNodo(Nodo? nodo, int valor)
    {
        if (nodo == null)
        {
            return new Nodo(valor);
        }

        if (valor < nodo.Valor)
        {
            nodo.Izquierda = InsertarNodo(nodo.Izquierda, valor);
        }
        else if (valor > nodo.Valor)
        {
            nodo.Derecha = InsertarNodo(nodo.Derecha, valor);
        }

        return nodo;
    }

    public void Inorden()
    {
        InordenRecorrido(Raiz);
        Console.WriteLine();
    }

    private void InordenRecorrido(Nodo? nodo)
    {
        if (nodo != null)
        {
            InordenRecorrido(nodo.Izquierda);
            Console.Write(nodo.Valor + " ");
            InordenRecorrido(nodo.Derecha);
        }
    }

    public void Preorden()
    {
        PreordenRecorrido(Raiz);
        Console.WriteLine();
    }

    private void PreordenRecorrido(Nodo? nodo)
    {
        if (nodo != null)
        {
            Console.Write(nodo.Valor + " ");
            PreordenRecorrido(nodo.Izquierda);
            PreordenRecorrido(nodo.Derecha);
        }
    }

    public void Postorden()
    {
        PostordenRecorrido(Raiz);
        Console.WriteLine();
    }

    private void PostordenRecorrido(Nodo? nodo)
    {
        if (nodo != null)
        {
            PostordenRecorrido(nodo.Izquierda);
            PostordenRecorrido(nodo.Derecha);
            Console.Write(nodo.Valor + " ");
        }
    }

    public bool Buscar(int valor)
    {
        return BuscarNodo(Raiz, valor);
    }

    private bool BuscarNodo(Nodo? nodo, int valor)
    {
        if (nodo == null)
        {
            return false;
        }

        if (valor == nodo.Valor)
        {
            return true;
        }

        if (valor < nodo.Valor)
        {
            return BuscarNodo(nodo.Izquierda, valor);
        }

        return BuscarNodo(nodo.Derecha, valor);
    }

    public void MostrarArbol()
    {
        MostrarNodo(Raiz, "", true);
    }

    private void MostrarNodo(Nodo? nodo, string espacio, bool esDerecha)
    {
        if (nodo == null)
        {
            return;
        }

        Console.WriteLine(espacio + (esDerecha ? "└── " : "├── ") + nodo.Valor);

        if (nodo.Izquierda != null || nodo.Derecha != null)
        {
            MostrarNodo(nodo.Izquierda, espacio + (esDerecha ? "    " : "│   "), false);
            MostrarNodo(nodo.Derecha, espacio + (esDerecha ? "    " : "│   "), true);
        }
    }
}