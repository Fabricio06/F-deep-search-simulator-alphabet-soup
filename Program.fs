//test

let palabras = [['h';'o';'l';'a']
                ['c';'a';'s';'a']
                ['c';'a';'m';'a']
                ['h';'o';'y';'o']
                ['a';'s';'a';'m']
                ['a';'s';'a';'c']]

//let objetivo = ['c';'a';'s';'a']
let objetivo2 = ['c';'a';'m';'a']
let objetivo3 = ['m';'a';'s';'a']
let objetivo4 = ['y';'o']
let objetivo = ['a';'s';'a';'c']
//let objetivo5 = ['p';'e';'r';'a']

let miembro e lista =
    lista
    |> List.map (fun x -> x = e)
    |> List.reduce (fun x y -> x || y)
    
let getElement i j (matrix: _ list list)=
    if matrix.Length > i then
        if matrix[i].Length > j then
            matrix[i][j]
        else
            '_'
    else
        '_'

let rec findFirstLetterPosition (i:int) (j:int) (letter:char) (matrix: _ list list) =    
    if matrix[i][j] = letter then
        (i,j)
    elif (i = matrix.Length-1) & (j = matrix[i].Length-1) then
        (-1,-1)
    else
        if j = matrix[i].Length-1 then
            findFirstLetterPosition (i+1) 0 letter matrix
        else
            findFirstLetterPosition i (j+1) letter matrix
            
                           
//vecinos en horizontal solamente
let vecinos_aux (posicion: (int*int)) (matrix: _ list list) =
    let x,y = fst(posicion),snd(posicion)
    [(x,y+1); (x,y-1)]
let vecinos (posicion: (int*int)) (matrix: _ list list) =
    (vecinos_aux posicion matrix)
    |> List.filter (fun x -> if ((fst(x) >= 0)&(fst(x) < matrix.Length)) & ((snd(x) < (matrix[0].Length))&(snd(x) >= 0)) then true else false) 
    
let extender (ruta: _ list) (matrix: _ list list) =
    (vecinos ruta.Head matrix)
    |> List.map (fun x -> if (miembro x ruta) then [] else x::ruta)
    |> List.filter (fun x -> x <> [])

let verificarCorrespondencia (posicion:(int*int)) needed (matrix: _ list list) =
    if (getElement (fst(posicion)) (snd(posicion)) matrix) = needed then
        true
    else
        false

let rec prof_aux (rutas: _ list list) (origin:('a*'b)) (goal:_ list) index (matrix: _ list list) =
    if rutas = [] then
        []
    elif rutas.Head.Length = goal.Length then
        List.rev rutas.Head
        (*List.append
        ([List.rev rutas.Head])
        (prof_aux rutas.Tail
             (findFirstLetterPosition (fst(origin)) (snd(origin)+1) goal[0] matrix) 
             goal 0 matrix)*)
    elif (verificarCorrespondencia rutas.Head.Head (goal[index]) matrix) then
        prof_aux (List.append (extender rutas.Head matrix) rutas.Tail) origin goal (index+1) matrix
    else
        if snd(rutas.Head.Head) < matrix[0].Length then
            prof_aux [[findFirstLetterPosition (fst(origin)) (snd(origin)+1) goal[0] matrix]]
                (findFirstLetterPosition (fst(origin)) (snd(origin)+1) goal[0] matrix)
                goal 0 matrix
        else
            prof_aux [[findFirstLetterPosition (fst(origin)+1) 0 goal[0] matrix]]
                (findFirstLetterPosition (fst(origin)+1) 0 goal[0] matrix)
                goal 0 matrix
        
let prof (goal:char list) (matrix: _ list list) =
    let posicionArranque = findFirstLetterPosition 0 0 goal[0] matrix
    prof_aux [[posicionArranque]] posicionArranque goal 0 matrix
    
printfn "%A" (prof objetivo palabras)
printfn "%A" (prof objetivo2 palabras)
printfn "%A" (prof objetivo3 palabras)
printfn "%A" (prof objetivo4 palabras)
//printfn "%A" (prof objetivo5 palabras)