let listaPalabras = ["HOLA"; "MUNDO"; "LUNA"; "CASA"; "SOL"]

let palabraMasLarga = listaPalabras |> List.maxBy (fun palabra -> palabra.Length)
let tamanoCuadricula = palabraMasLarga.Length

let generarMatrizAleatoria tamano =
    let rnd = System.Random()
    Array2D.init tamano tamano (fun _ _ -> char (rnd.Next(65,91)))

let matriz = generarMatrizAleatoria tamanoCuadricula

let colocarPalabra (palabra:string) matriz =
    let tamano = Array2D.length1 matriz
    let rnd = System.Random()
    let direccion =
        match rnd.Next(0,3) with
        | 0 -> (fun x -> (x,0)) // horizontal
        | 1 -> (fun x -> (0,x)) // vertical
        | _ -> (fun x -> (x,x)) // diagonal
    let posicion = rnd.Next(0,tamano - palabra.Length)
    let (fila, columna) = direccion posicion
    for i = 0 to palabra.Length - 1 do
        matriz.[fila + i, columna + i] <- palabra.[i]
    matriz

let matrizConPalabras = listaPalabras |> List.fold (fun matriz palabra -> colocarPalabra palabra matriz) matriz


let cambiarPalabra (palabraVieja : string) (palabraNueva : string) (matriz : char[,]) =
    let rows = matriz.GetLength(0)
    let cols = matriz.GetLength(1)
    let palabraLen = palabraVieja.Length
    for r = 0 to rows - 1 do
        for c = 0 to cols - 1 do
            let mutable found = true
            if matriz.[r,c] = palabraVieja.[0] then
                for i = 1 to palabraLen - 1 do
                    if r + i >= rows || matriz.[r+i,c] <> palabraVieja.[i] then
                        found <- false
                        exit |> ignore
                if found then
                    for i = 0 to palabraLen - 1 do
                        matriz.[r+i,c] <- palabraNueva.[i]
                else
                    matriz |> ignore
    matriz // palabra antigua no encontrada, devolver matriz original
//Imprime la sopa de letras
printfn "%A" matrizConPalabras
// Imprime la matriz original y la matriz cambiada
let matrizCambiada = cambiarPalabra "MUNDO-" "OPENAI" matrizConPalabras
//printfn "Matriz original:\n%s" (matrizConPalabras |> Array2D.map (char >> string) |> Array2D.map2D (fun _ _ c -> c + " ") |> Array2D.fold (fun acc _ c -> acc + c) "")
printfn "Matriz cambiada:\n %A" matrizCambiada