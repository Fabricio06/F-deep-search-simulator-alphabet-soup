open System
open Microsoft.FSharp.Collections
open Microsoft.FSharp.Core

let listaPalabras = ["HOLA"; "MUNDO"; "LUNA"; "CASA"; "SOL"] //La lista de palabras que vamos a utilizar

let palabraMasLarga = listaPalabras |> List.maxBy (fun palabra -> palabra.Length) //Se obtiene la palabra mas larga que va a ser el X*X de la matriz
let tamanoCuadricula = palabraMasLarga.Length //Se obtiene el largo de la palabra

let random = System.Random() //Se encarga de dar valores al azar

let generarMatrizAleatoria tamano = //Se genera la matriz con letras aleatorias del tamano de la palabra mas grande
    // Array2D.init tamano tamano (fun _ _ -> char(random.Next(65,91)))
    Array2D.init tamano tamano (fun _ _ -> char(48))
let matriz = generarMatrizAleatoria tamanoCuadricula //La matriz que vamos a utilizar



// let generarMatriz tamano =
//     let rnd = System.Random()
//     Array2D.init tamano tamano (fun _ _ -> char (48))
//
// printfn "%A" (generarMatriz 5)