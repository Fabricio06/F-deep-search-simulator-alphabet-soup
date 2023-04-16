using System;
using System.Collections.Generic;
using System.Linq;
using System.IO; //Manejo de archivos
//using BusquedaProfu;
namespace GenerarSopaLetras;

//Programa de un tercero generado con CHATGPT
public class Program
{
    
    //La ruta del archivo .txt (no funciono con la ruta relatica, si se quiere probar el codigo, cambiar esta ruta por la actual)
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
                palabras.Add(line); //Agrega cada linea como una palabra a la lista
            }
            reader.Close();
        }
    }

    //Funcion que se encarga de cambiar una palabra vieja por una nueva en el archivo
    public void cambiarArchivo(int indVieja, string nueva) //Recibe lel indice de la palabra vieja y la nueva palabra para cambiarla en el archivo
    {
        string[] lines = File.ReadAllLines(rutaArchivo); //Obtiene todas las palabras por lineas
        lines[indVieja] = nueva; //Sustituye la palabra vieja por la nueva
        
        //Vuelve a sobrescribir todo el archivo con la nueva actualizacion
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
        var matriz = new char[n, n]; //La matriz es del tamano de la palabra mas grande
        var random = new Random(); //Para generar ubicaciones aleatorias
        foreach (string palabra in palabras)
        {
            bool encontrada = false;
            while (!encontrada) //Se hace fuerza bruta para encajar la palabra
            {
                int fila = random.Next(n); //Fila aleatoria
                int columna = random.Next(n); //Columna aleatoria
                int dx = random.Next(3) - 1; //Representa si va a ser, vertical, horizontal o diagonal
                int dy = random.Next(3) - 1; //Representa si va a ser, vertical, horizontal o diagonal

                if (dx == 0 && dy == 0)
                {
                    continue; //Para que la ubicacion no sea solo el origen
                }


                //Se verifica que no se superpongan las palabras con otras
                bool superpuesta = false;
                for (int i = 0; i < palabra.Length; i++)
                {
                    int nuevaFila = fila + i * dy;
                    int nuevaColumna = columna + i * dx;
                    if (nuevaFila < 0 || nuevaFila >= n || nuevaColumna < 0 || nuevaColumna >= n || (matriz[nuevaFila, nuevaColumna] != '\0' && matriz[nuevaFila, nuevaColumna] != palabra[i])) //Verifica que no se salga del margen o se superponga
                    {
                        superpuesta = true; //Si se superpone entonces se vuelve para ir con otra ubicacion
                        break;
                    }
                }

                //Si no se superpone, se coloca en la matriz
                if (!superpuesta)
                {
                    for (int i = 0; i < palabra.Length; i++) //Se va recorriendo caracter por caracter
                    {
                        matriz[fila + i * dy, columna + i * dx] = palabra[i]; //Se coloca cada caracter en la matriz
                    }
                    encontrada = true;
                }
            }
        }


        //Se rellenan los espacios vacios con letras al azar
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
        return matriz; //Se devuelve la matriz procesada
    }
   
    //CambiarPalabra Funcion que se encarga de cambiar una palabra de la lista de palabras por una nueva mandada por parametro    
    public  void CambiarPalabra(string vieja, string nueva)
    {
        var confir = palabras.IndexOf(vieja); //Obtiene el indice de la palabra vieja
        if (confir != -1) //Entra solo si existe
        {
            cambiarArchivo(confir, nueva); //Se cambia en el archivo

            //Sino me equivoco esto solo era necesario cuando probaba el codigo individual, desde la interfaz ya funciona sin esto
            palabras[confir] = nueva; //Se cambia en la variable
            var matriz = GenerateSopaDeLetras(); //Se vuelve a generar la matriz
        }
    
        }
    static void Main()
    {
        
    }
}