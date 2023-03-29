using System;
using System.Collections.Generic;
using System.Linq;

//Programa de un tercero generado con CHATGPT

class Program
{
    // static List<string> palabras = new List<string> { "HOLA", "MUNDO", "PROGRAMACION", "FUNCIONAL", "SOPA", "LETRAS", "C#", "NET" };

    static List<string> palabras = new List<string> { "HOLA","SOPAS", "CASA", "NET","SAP" };
   
    static char[,] GenerateSopaDeLetras(List<string> palabras)
    {
        palabras = palabras.OrderByDescending(p => p.Length).ToList(); // Ordenar las palabras por longitud descendente
        int n = palabras[0].Length; // Tamaño de la matriz (la longitud de la palabra más larga)
        var matriz = new char[n, n];

        foreach (var palabra in palabras)
        {
            bool inserted = false;
            foreach (var direccion in Direcciones)
            {
                var posiciones = GenerarPosiciones(matriz, palabra.Length, direccion);
                foreach (var posicion in posiciones)
                {
                    if (PosicionDisponible(matriz, palabra, posicion, direccion))
                    {
                        InsertarPalabra(matriz, palabra, posicion, direccion);
                        inserted = true;
                        break;
                    }
                }
                if (inserted) break;
            }
        }

        // Rellenar los espacios vacíos con letras aleatorias
        var random = new Random();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matriz[i, j] == '\0')
                {
                    matriz[i, j] = (char)random.Next('A', 'Z' + 1);
                }
            }
        }

        return matriz;
    }

    static readonly int[][] Direcciones = new int[][] { new[] { 1, 0 }, new[] { 0, 1 }, new[] { -1, 0 }, new[] { 0, -1 }, new[] { 1, 1 }, new[] { 1, -1 }, new[] { -1, 1 }, new[] { -1, -1 } };

    static IEnumerable<(int, int)> GenerarPosiciones(char[,] matriz, int longitud, int[] direccion)
    {
        int n = matriz.GetLength(0);
        int x = direccion[0];
        int y = direccion[1];
        int maxX = n - x * (longitud - 1);
        int maxY = n - y * (longitud - 1);
        for (int i = 0; i < maxX; i++)
        {
            for (int j = 0; j < maxY; j++)
            {
                yield return (i + x * j, j + y * j);
            }
        }
    }

    static bool PosicionDisponible(char[,] matriz, string palabra, (int, int) posicion, int[] direccion)
    {
        int n = matriz.GetLength(0);
        int x = direccion[0];
        int y = direccion[1];
        for (int i = 0; i < palabra.Length; i++)
        {
            int posX = posicion.Item1 + x * i;
            int posY = posicion.Item2 + y * i;
            if (posX < 0 || posX >= n || posY < 0 || posY >= n || (matriz[posX, posY] != '\0' && matriz[posX, posY] != palabra[i]))
            {
                return false;
            }
        }
        return true;
    }

    static void InsertarPalabra(char[,] matriz, string palabra, (int, int) posicion, int[] direccion)
    {
        int x = direccion[0];
        int y = direccion[1];
        for (int i = 0; i < palabra.Length; i++)
        {
            int posX = posicion.Item1 + x * i;
            int posY = posicion.Item2 + y * i;
            matriz[posX, posY] = palabra[i];
        }
    }

    /**
     * CambiarPalabra Funcion que se encarga de cambiar una palabra de la lista de palabras por una nueva mandada por parametro
     */
    static void CambiarPalabra(string vieja, string nueva)
    {
        var confir = palabras.IndexOf("SOPAS");
        if (confir != -1)
        {
            palabras[confir] = nueva;
        }
        else
        {
            throw new ArgumentException("La palabra " + vieja + " no se encuentra en la lista de palabras.");
        }
    }
    
    static void Main(string[] args)
    {
        var matriz = GenerateSopaDeLetras(palabras);
        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                Console.Write(matriz[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
    
