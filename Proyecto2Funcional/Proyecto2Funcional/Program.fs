open System
open Microsoft.FSharp.Core

let listaPalabras = ["HOLA"; "MUNDO"; "LUNA"; "CASA"; "SOL"] //La lista de palabras que vamos a utilizar

let palabraMasLarga = listaPalabras |> List.maxBy (fun palabra -> palabra.Length) //Se obtiene la palabra mas larga que va a ser el X*X de la matriz
let tamanoCuadricula = palabraMasLarga.Length //Se obtiene el largo de la palabra


let random = System.Random() //Se encarga de dar valores al azar


let generarMatrizAleatoria tamano = //Se genera la matriz con letras aleatorias del tamano de la palabra mas grande
    Array2D.init tamano tamano (fun _ _ -> Convert.ToChar(random.Next(65,91)))
let matriz = generarMatrizAleatoria tamanoCuadricula //La matriz que vamos a utilizar

//Generar una lista de direcciones aleatorias
let generarDireccion tamanoPalabra =
    let direccion = match random.Next(0, 3) with
                    | 0 -> (1, 0) //horizontal
                    | 1 -> (0, 1) //vertical
                    | 2 -> (1, 1) //diagonal
                    | _ -> failwith "Error en la direccion"
    let maxFila = tamanoCuadricula - (tamanoPalabra * fst direccion)
    let maxCol = tamanoCuadricula - (tamanoPalabra * snd direccion)
    let fila = random.Next(0, maxFila + 1)
    let col = random.Next(0, maxCol + 1)
    seq { for i in 0..tamanoPalabra-1 do yield (fila + i * fst direccion, col + i * snd direccion) }

                
let matrizConPalabras = insertarPalabras matriz
   
    
// let generarMatriz tamano =
//     let rnd = System.Random()
//     Array2D.init tamano tamano (fun _ _ -> char (48))
//
// printfn "%A" (generarMatriz 5)