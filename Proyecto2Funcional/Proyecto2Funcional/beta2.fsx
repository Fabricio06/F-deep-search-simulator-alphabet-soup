// Función para crear una matriz aleatoria
let createRandomMatrix (rows:int) (cols:int) = 
    let rand = System.Random()
    Array2D.init rows cols (fun _ _ -> char(rand.Next(65, 91))) // Genera una letra mayúscula aleatoria

// Función para imprimir una matriz en la consola
let printMatrix matrix = 
    for i in 0 .. Array2D.length1 matrix - 1 do
        for j in 0 .. Array2D.length2 matrix - 1 do
            printf "%c " matrix.[i, j]
        printfn ""

// Función para insertar una palabra en una matriz en una dirección y posición aleatorias
let insertWord (matrix:char[,]) (word:string) = 
    let rand = System.Random()
    let (rows, cols) = (Array2D.length1 matrix, Array2D.length2 matrix)
    let directions = [|
        fun r c i -> (r + i, c)   // vertical hacia abajo
        fun r c i -> (r - i, c)   // vertical hacia arriba
        fun r c i -> (r, c + i)   // horizontal hacia la derecha
        fun r c i -> (r, c - i)   // horizontal hacia la izquierda
        fun r c i -> (r + i, c + i) // diagonal hacia abajo y derecha
        fun r c i -> (r + i, c - i) // diagonal hacia abajo e izquierda
        fun r c i -> (r - i, c + i) // diagonal hacia arriba y derecha
        fun r c i -> (r - i, c - i) // diagonal hacia arriba e izquierda
    |]
    let maxIndex = max (rows - 1) (cols - 1)
    let (dirFunc, rStart, cStart) = 
        let dirIndex = rand.Next(directions.Length)
        let rStart = rand.Next(rows)
        let cStart = rand.Next(cols)
        (directions.[dirIndex], rStart, cStart)
    let wordFits r c i = 
        let (r', c') = dirFunc r c i
        r' >= 0 && r' < rows && c' >= 0 && c' < cols && (matrix.[r', c'] = ' ' || matrix.[r', c'] = word.[i])
    let rec tryInsert i r c = 
        if i = word.Length then
            Some(matrix)
        elif wordFits r c i then
            let matrix' = Array2D.copy matrix
            matrix'.[r, c] <- word.[i]
            tryInsert (i + 1) (fst(dirFunc r c i)) (snd(dirFunc r c i)) |> Option.map (fun m -> m)
        else
            None
    let rec tryInsertLoop count = 
        if count = 100 then None
        else
            let r = rand.Next(rows)
            let c = rand.Next(cols)
            match tryInsert 0 r c with
            | Some(m) -> Some(m)
            | None -> tryInsertLoop (count + 1)
    tryInsertLoop 0

// Función principal
[<EntryPoint>]
let main argv = 
    let words = ["HOLA"; "MUNDO";"CASA";"FELIPE"]
    let (rows, cols) = (15, 15)
    let matrix = createRandomMatrix rows cols
    let matrices = List.map (fun w -> insertWord matrix w) words
    let solutionMatrix = Array2D.copy matrix
    let matrices = List.map (fun w -> insertWord matrix w |> Option.defaultValue matrix) words
    printfn "Encuentra las siguientes palabras en la sopa de letras:"
    List.iteri (fun i w -> printfn "%d. %s" (i+1) w) words
    printfn ""
    printfn "\n%A\n" solutionMatrix
    printMatrix solutionMatrix
    0 // Retorna un código de salida 0 al terminar el programa
    
