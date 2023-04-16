using System;
using System.Collections.Generic;
using System.Linq;
using System.IO; //Manejo de archivos
//using BusquedaProfu;
namespace GenerarSopaLetras;

//Programa de un tercero generado con CHATGPT
public class Program
{
    
    //La ruta del archivo .txt
    private string rutaArchivo = "C:\\Users\\fapor\\OneDrive\\Desktop\\Universidad\\5 semestre\\Lenguajes de programacion\\Semana 7\\Proyecto2-Lenguajes-de-programacion\\Proyecto2Funcional\\GenerarSopaLetras\\palabras.txt";


    public  List<string> palabras = new List<string> { }; //Se inicializa la lista donde van a ir las palabras
   
    //Funcion que se encarga de cargar las palabras del archivo a la variable palabras
    public  void cargarPalabras()
    {
        
        using (StreamReader reader = new StreamReader(rutaArchivo))
        {
            // Lee cada línea del archivo y la agrega a la variable
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                palabras.Add(line);
            }
            reader.Close();
        }
    }

    //Funcion que se encarga de convertir un List<string> a un List<List<char>> para habilitar la compati
    public List<List<char>> ConvertirACharListList(List<string> listaDePalabras)
    {
        List<List<char>> listaDeCharListas = new List<List<char>>();

        foreach (string palabra in listaDePalabras)
        {
            List<char> listaDeChars = new List<char>();

            foreach (char caracter in palabra)
            {
                listaDeChars.Add(caracter);
            }

            listaDeCharListas.Add(listaDeChars);
        }

        return listaDeCharListas;
    }


    //Funcion que se encarga de cambiar una palabra vieja por una nueva en el archivo
    public void cambiarArchivo(int indVieja, string nueva)
    {
        string[] lines = File.ReadAllLines(rutaArchivo); //Obtiene todas las palabras por lineas
        lines[indVieja] = nueva;
        using (StreamWriter writer = new StreamWriter(rutaArchivo, false))
        {
            foreach (string line in lines)
            {
                writer.WriteLine(line);
            }
        }
    }

    //Obtiene la palabra mas larga
    public  int palabraMasLarga()
    {
        var palabrasOrd = palabras.OrderByDescending(p => p.Length).ToList(); // Ordenar las palabras por longitud descendente
        return palabrasOrd[0].Length;// Tamaño de la matriz (la longitud de la palabra más larga)
    }


    //Dirreciones horizontales, verticales, diagonales, reversas
    public readonly int[][] Direcciones = new int[][] {
    new[] { 1, 0 }, new[] { 0, 1 }, new[] { -1, 0 }, new[] { 0, -1 },
    new[] { 1, 1 }, new[] { 1, -1 }, new[] { -1, 1 }, new[] { -1, -1 }};

    
    //Funcion que se encarga de generar la matriz con las palabras del archivo
    public char[,] GenerateSopaDeLetras()
    {
        var n = palabraMasLarga();
        var matriz = new char[n, n];
        var random = new Random();
        foreach (string palabra in palabras)
        {
            bool encontrada = false;
            while (!encontrada)
            {
                int fila = random.Next(n);
                int columna = random.Next(n);
                int dx = random.Next(3) - 1;
                int dy = random.Next(3) - 1;

                if (dx == 0 && dy == 0)
                {
                    continue;
                }

                bool superpuesta = false;
                for (int i = 0; i < palabra.Length; i++)
                {
                    int nuevaFila = fila + i * dy;
                    int nuevaColumna = columna + i * dx;
                    if (nuevaFila < 0 || nuevaFila >= n || nuevaColumna < 0 || nuevaColumna >= n || (matriz[nuevaFila, nuevaColumna] != '\0' && matriz[nuevaFila, nuevaColumna] != palabra[i]))
                    {
                        superpuesta = true;
                        break;
                    }
                }

                if (!superpuesta)
                {
                    for (int i = 0; i < palabra.Length; i++)
                    {
                        matriz[fila + i * dy, columna + i * dx] = palabra[i];
                    }
                    encontrada = true;
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matriz[i, j] == '\0')
                {
                    matriz[i, j] = (char)random.Next('A', 'Z' + 1);
                }
                Console.Write(matriz[i, j] + " ");
            }
            Console.WriteLine();
        }
        return matriz;
    }
   
    //CambiarPalabra Funcion que se encarga de cambiar una palabra de la lista de palabras por una nueva mandada por parametro    
    public  void CambiarPalabra(string vieja, string nueva)
    {
        var confir = palabras.IndexOf(vieja);
        Console.WriteLine(confir);
        if (confir != -1)
        {
            cambiarArchivo(confir, nueva);
            palabras[confir] = nueva;
            var matriz = GenerateSopaDeLetras();
            Console.WriteLine("Sopa de letras actualizada:");
           
        }
    
        }
    static void Main()
    {
        
    }
}