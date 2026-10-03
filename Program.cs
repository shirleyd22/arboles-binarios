using System.Diagnostics;

string[] lineas = File.ReadAllLines("datos.txt");

List<int> datosArbol1 = new List<int>();
List<int> datosArbol2 = new List<int>();

bool segundoArbol = false;

foreach (string lineaOriginal in lineas)
{
    string linea = lineaOriginal.Trim();

    if (string.IsNullOrWhiteSpace(linea))
    {
        continue;
    }

    if (linea == "ARBOL 1")
    {
        segundoArbol = false;
        continue;
    }

    if (linea == "ARBOL 2")
    {
        segundoArbol = true;
        continue;
    }

    string[] valores = linea.Split(',');

    foreach (string valorTexto in valores)
    {
        if (int.TryParse(valorTexto.Trim(), out int numero))
        {
            if (segundoArbol)
            {
                datosArbol2.Add(numero);
            }
            else
            {
                datosArbol1.Add(numero);
            }
        }
    }
}

Arbol arbol1 = new Arbol();
Arbol arbol2 = new Arbol();

// Medir tiempo de construcción del Árbol 1
Stopwatch tiempoArbol1 = Stopwatch.StartNew();

foreach (int numero in datosArbol1)
{
    arbol1.Insertar(numero);
}

tiempoArbol1.Stop();

// Medir tiempo de construcción del Árbol 2
Stopwatch tiempoArbol2 = Stopwatch.StartNew();

foreach (int numero in datosArbol2)
{
    arbol2.Insertar(numero);
}

tiempoArbol2.Stop();

Console.WriteLine("========== arbol 1 ==========");
Console.WriteLine("Raíz: " + arbol1.Raiz?.Valor);

Console.WriteLine("\nRecorrido Inorden:");
arbol1.Inorden();

Console.WriteLine("Recorrido Preorden:");
arbol1.Preorden();

Console.WriteLine("Recorrido Postorden:");
arbol1.Postorden();

Console.WriteLine("\n========== arbol 2 ==========");
Console.WriteLine("Raíz: " + arbol2.Raiz?.Valor);

Console.WriteLine("\nRecorrido Inorden:");
arbol2.Inorden();

Console.WriteLine("Recorrido Preorden:");
arbol2.Preorden();

Console.WriteLine("Recorrido Postorden:");
arbol2.Postorden();

Console.WriteLine("\n=== consulta de búsqueda ===");
Console.WriteLine("el valor 60 se encuentra en el arbol 1: " + arbol1.Buscar(60));
Console.WriteLine("el valor 10 se encuentra en el arbol 1: " + arbol1.Buscar(10));
Console.WriteLine("el valor 98 se encuentra en el arbol 2: " + arbol2.Buscar(98));
Console.WriteLine("el valor 15 se encuentra en el arbol 2: " + arbol2.Buscar(15));

Console.WriteLine("\n=== grafica del arbol 1 ===");
arbol1.MostrarArbol();

Console.WriteLine("\n=== grafica del arbol 2 ===");
arbol2.MostrarArbol();

Console.WriteLine("\n=== tiempo de ejecucion ===");
Console.WriteLine("Tiempo de construcción del Árbol 1: " +
    tiempoArbol1.Elapsed.TotalMilliseconds + " ms");

Console.WriteLine("Tiempo de construcción del Árbol 2: " +
    tiempoArbol2.Elapsed.TotalMilliseconds + " ms");