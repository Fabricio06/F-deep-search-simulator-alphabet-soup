open System
//
// let random = Random()
//
// let generar_tablero (palabras: string list) =
//     let tamano = palabras |> List.map (fun p -> p.Length) |> List.max
//     let ancho = tamano * 2
//     let alto = tamano * 2
//     let tablero = Array2D.create alto ancho ' '
//
//     let rec colocar_palabra (palabra: string) =
//         let palabra_reversa = new string(palabra.ToCharArray() |> Array.rev)
//         let direccion = if random.Next(2) = 0 then 1 else alto
//         let inicio = random.Next(if direccion = 1 then ancho - palabra.Length else alto - palabra.Length) + 1
//         let fin = inicio + palabra.Length * direccion
//         let rango = if direccion = 1 then inicio .. fin - 1 else inicio .. direccion .. fin - 1
//         let casillas = rango |> Seq.map (fun i -> if direccion = 1 then tablero.[0, i] <- palabra.[i - inicio] else tablero.[i, 0] <- palabra.[i - inicio])
//         if casillas |> Seq.forall (fun c -> c = ' ') then
//             rango |> Seq.iteri (fun i j -> if direccion = 1 then tablero.[1, j] <- palabra.[i] else tablero.[j, 1] <- palabra.[i])
//             true
//         else
//             false
//
//     let mutable intentos = 0
//     while intentos < 100 && palabras <> [] do
//         let palabra = palabras.[random.Next(palabras.Length)]
//         if colocar_palabra palabra then
//             palabras <- palabras |> List.filter (fun p -> p <> palabra)
//             intentos <- 0
//         else
//             intentos <- intentos + 1
//
//     for i = 0 to alto - 1 do
//         for j = 0 to ancho - 1 do
//             if tablero.[i, j] = ' ' then
//                 tablero.[i, j] <- char(random.Next(26) + int 'A')
//
//     tablero
//
// let imprimir_tablero (tablero: char[,]) =
//     let alto, ancho = tablero.GetLength(0), tablero.GetLength(1)
//     for i = 0 to alto - 1 do
//         for j = 0 to ancho - 1 do
//             printf "%c " tablero.[i, j]
//         printfn ""
//
// let resolver_sopa (palabras: string list) =
//     let tablero = generar_tablero palabras
//     imprimir_tablero tablero
//     printfn ""
//
//     let grafo =
//         [ for i = 0 to tablero.GetLength(0) - 1 do
//             yield [ for j = 0 to tablero.GetLength(1) - 1 do
//                       yield (i, j) ] ]
//         |> List.concat
//         |> List.map (fun (i, j) -> ((i, j), [ for di = -1 to 1 do
//                                                 for dj = -1 to 1 do
//                                                     let i2, j2 = i + di, j + dj
//                                                     if i2 >= 0 && i2 < tablero.GetLength(0) && j2 >= 0 && j2 < tablero.GetLength(1) && (i2, j2) <> (i, j) then
//                                                         yield (i2, j2) ] |> List.filter (fun (i2, j2) -> tablero.[i2, j2] |> string) |> List.filter (fun c -> c <> " ")
//                                                         |> List.map (fun c -> char.Parse(c))
//                                                         |> List.toArray
//                                                         )])
//                                                         |> Map.ofList
//
//
// let palabras_restantes = ref palabras
//
// while palabras_restantes.Value <> [] do
//     let palabra = palabras_restantes.Value.Head
//     palabras_restantes := palabras_restantes.Value.Tail
//     let solucion = prof (List.head palabra) (List.last palabra) grafo |> List.rev
//     if solucion <> [] then
//         for i = 0 to solucion.Length - 1 do
//             let (x, y) = solucion.[i]
//             tablero.[x, y] <- Char.ToUpper(tablero.[x, y])
//         printfn "La palabra \"%s\" se encuentra en el tablero:" palabra
//         imprimir_tablero tablero
//         printfn ""
//     else
//         printfn "La palabra \"%s\" no se pudo encontrar en el tablero" palabra


open System

type Direction = Up | Down | Left | Right | UpLeft | UpRight | DownLeft | DownRight

let random = Random()

let createMatrix size =
    Array.init size (fun _ -> Array.init size (fun _ -> ' '))

let canPlaceWord (matrix: char[][]) (word:string) (x:int)(y:int) direction =
    let dx, dy =
        match direction with
        | Up -> -1, 0
        | Down -> 1, 0
        | Left -> 0, -1
        | Right -> 0, 1
        | UpLeft -> -1, -1
        | UpRight -> -1, 1
        | DownLeft -> 1, -1
        | DownRight -> 1, 1

    let rec check i =
        if i = word.Length then true
        else
            let x' = x + i * dx
            let y' = y + i * dy
            if x' < 0 || x' >= matrix.Length || y' < 0 || y' >= matrix.Length then false
            else if matrix.[x'].[y'] = ' ' || matrix.[x'].[y'] = word.[i] then check (i + 1)
            else false

    check 0

let placeWord (matrix: char[][]) (word:string) (x:int)(y:int) direction =
    let dx, dy =
        match direction with
        | Up -> -1, 0
        | Down -> 1, 0
        | Left -> 0, -1
        | Right -> 0, 1
        | UpLeft -> -1, -1
        | UpRight -> -1, 1
        | DownLeft -> 1, -1
        | DownRight -> 1, 1

    for i = 0 to word.Length - 1 do
        let x' = x + i * dx
        let y' = y + i * dy
        matrix.[x'].[y'] <- word.[i]

let addWord (matrix: char[][]) word maxAttempts =
    let directions = [|Up; Down; Left; Right; UpLeft; UpRight; DownLeft; DownRight|]

    let rec tryPlace attempts =
        if attempts = maxAttempts then false
        else
            let x = random.Next(matrix.Length)
            let y = random.Next(matrix.Length)
            let direction = directions.[random.Next(directions.Length)]

            if canPlaceWord matrix word (x, y) direction then
                placeWord matrix word (x, y) direction
                true
            else tryPlace (attempts + 1)

    tryPlace 0

let createWordSearch words size maxAttempts =
    let matrix = createMatrix size

    for word in words do
        if not (addWord matrix word maxAttempts) then
            printfn "Failed to place word: %s" word

    matrix

let printMatrix (matrix: char[][]) =
    for row in matrix do
        printfn "%s" (String.Join(" ", row))

let words = ["hola", "mundo", "fsharp", "sopa"]
let size = 10
let maxAttempts = 20

let wordSearch = createWordSearch words size maxAttempts
printMatrix wordSearch