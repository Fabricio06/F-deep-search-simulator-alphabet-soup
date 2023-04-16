namespace BusquedaProfu
module parteFShart =
    open Microsoft.FSharp.Core
    open Microsoft.FSharp.Collections

    //Se encarga de convertir la matriz recibida de c# que viene como una matriz de dos dimenciones y lo convierte
    //a un char list list como el ejemplo que dio el profe
    let ConvertirMatriz (matriz : char[,]) : char list list =
        let filas = Array2D.length1 matriz
        let columnas = Array2D.length2 matriz

        [for i in 0 .. filas - 1 do
            yield [for j in 0 .. columnas - 1 do
                        matriz.[i, j]
                ]]


    (*
    let sopaLetras = [['P';'E';'D';'R';'O';'N';'S';'M';'C']
                      ['L';'S';'A';'P';'O';'S';'R';'V';'S']
                      ['E';'B';'M';'U';'N';'D';'O';'T';'H']
                      ['T';'A';'O';'S';'O';'P';'A';'X';'X']
                      ['R';'T';'L';'O';'C';'N';'S';'M';'C']
                      ['A';'Y';'K';'X';'E';'P';'E';'P';'O']
                      ['S';'E';'I';'I';'D';'F';'E';'L';'S']
                      ['S';'R';'G';'B';'J';'F';'W';'Q';'K']
                      ['L';'G';'A';'D';'N';'J';'O';'L';'R']]
    let listaPalabras = [['P';'E';'D';'R';'O'];['S';'A';'P';'O'];['M';'U';'N';'D';'O'];['S';'O';'P';'A'];['L';'E';'T';'R';'A';'S'];['P';'E';'P';'O']]
    
    (Fila, Columna) convierte la matriz recibido de c# a este tipo de matriz
    let sopaLetras =[['c';'o';'l';'a';'o';'r']
                     ['c';'a';'s';'a';'c';'h']  = [(1, 0); (1, 1); (1, 2); (1, 3);(1,5);(1,6)]
                     ['c';'a';'m';'a';'y';'o']
                     ['h';'o';'y';'o';'p';'l']
                     ['a';'s';'a';'m';'x';'a']
                     ['a';'s';'a';'c';'z';'w']]
    
    let palabra = ['c';'a';'s';'a'] = [(1, 0); (1, 1); (1, 2); (1, 3)]
    let palabra2 = ['c';'a';'m';'a'] = [(2, 0); (2, 1); (2, 2); (2, 3)]
    let palabra3 = ['m';'a';'s';'a'] = [(4, 3); (4, 2); (4, 1); (4, 0)]
    let palabra4 = ['h';'o';'l';'a'] = [(1,5);(2,5);(3,5);(4;5)]
    let palabra5 = ['c';'a';'y'] = [(1,0);(2,1);(3,2)]
    let palabra6 = ['m';'o';'a'] = [(2,2);(3,1);(4,0)]
    let palabra5 = ['p';'e';'r';'a'] = no encontrada
    *)


    //Funcion que se encarga simplemente de buscar los miembros de un nodo
    let miembro e lista =
        lista
        |> List.map (fun x -> x = e)
        |> List.reduce (fun x y -> x || y)

    //Se encarga de recibir una coordenada y devolver el caracter de esa coordenada encontrada en la sopa de letras
    let getElement i j (matrix: _ list list)=
        if matrix.Length > i && matrix[i].Length > j then
                matrix[i][j]
        else
            '_'
    
    //Funcion que recibe una coordenada inicial y un caracter y se encarga de buscar las coordenadas del caracter en la matriz y devuelve las coordenadas del caracter encontrado
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
    
     //Se encarga de obtener los vecinos horizontales, diagonales, verticales y reversos y le realiza una poda para que solo se obtengan en la direccion necesaria
    let vecinos_aux (posicion: int * int) (origin: int * int) (matrix: _ list list) =
        let x, y = posicion
        let ox, oy = origin
        match posicion with
        | p when p = origin ->
            [(x, y + 1); (x, y - 1); (x + 1, y); (x - 1, y); (x - 1, y - 1); (x - 1, y + 1); (x + 1, y - 1); (x + 1, y + 1)]
        | (px, _) when px = ox ->
            if y > oy then [(x, y + 1)] else [(x, y - 1)]
        | (_, py) when py = oy ->
            if x > ox then [(x + 1, y)] else [(x - 1, y)]
        | _ when abs (x - ox) = abs (y - oy) ->
            let dx = if x > ox then 1 else -1
            let dy = if y > oy then 1 else -1
            [(x + dx, y + dy)]
        | _ -> [(fst origin, snd origin)]


    //Filtra las coordenadas recibidas de vecinos_aux para que solo nos devuelva los valores validos de los vecinos
    let vecinos (posicion: (int*int)) (origen: (int*int)) (matrix: _ list list) =
        (vecinos_aux posicion origen matrix)
        |> List.filter (fun x -> if ((fst(x) >= 0)&&(fst(x) < matrix.Length)) && ((snd(x) < (matrix[0].Length))&&(snd(x) >= 0)) then true else false) 

    //Se encarga de extender las rutas enviadas buscandole los vecinos y devuelve la lista con las nuevas rutas
    let extender (ruta: _ list) (origen: (int*int)) (matrix: _ list list) =
        (vecinos ruta.Head origen matrix)
        |> List.map (fun x -> if (miembro x ruta) then [] else x::ruta)
        |> List.filter (fun x -> x <> [])

    //Funcion que se encarga de verificar si el caracter de una posicion en la matriz es el caracter siguiente de la palabra que buscamos
    let verificarCorrespondencia (posicion:(int*int)) needed (matrix: _ list list) =
        if (getElement (fst(posicion)) (snd(posicion)) matrix) = needed then
            true
        else
            false

    //Funcion que se encarga de revisar si una ruta con el mismo tamano de la palabra que estamos buscando 
    //tienen el mismo valor
    let verificarCoordenadas (ruta: (int * int) list) (goal: char list) (matrix: char list list) =
        let rec verificarAux (r: (int * int) list) (g: char list) (m: char list list) =
            match (r, g) with
            | ([], []) -> true
            | ((x,y)::restoRutas, letra::restoGoal) when x >= 0 && x < List.length m && y >= 0 && y < List.length m.[0] && m.[x].[y] = letra -> verificarAux restoRutas restoGoal m
            | _ -> false
        verificarAux (List.rev ruta) goal matrix                
    //printfn "%A" (verificarCoordenadas [(1,3);(1,2);(1,1);(1,0)] palabra sopaLetras)
     
    //Funcion que se encarga de buscar la siguiente letra en la matriz del caracter principal sino funciono con
    //el que se estaba intentado
    let siguienteLetra (rutas: _ list list) (origin:('a*'b)) (goal:_ list) index (matrix: _ list list) =
          if snd(origin) < matrix[0].Length-1 then
              [[findFirstLetterPosition (fst(origin)) (snd(origin)+1) goal[0] matrix];[(findFirstLetterPosition (fst(origin)) (snd(origin)+1) goal[0] matrix)]]    
          else
             [[findFirstLetterPosition (fst(origin)+1) 0 goal[0] matrix];[(findFirstLetterPosition (fst(origin)+1) 0 goal[0] matrix)]]

    //Es la funcion que se encarga de hacer todo el recorrido recursivo para poder encontrar las rutas de ser posible
    let rec prof_aux (rutas: _ list list) (origin:('a*'b)) (goal:_ list) index (matrix: _ list list) =
        if rutas = [] then //Si no funciono con la ruta que le mandamos y queda vacio, buscamos la esa letra con otra ubicacion en la matriz
            let nuevaRuta = siguienteLetra rutas origin goal index matrix
            prof_aux [nuevaRuta.Head] (nuevaRuta.Tail.Head.Head) goal 0 matrix
        elif origin = (-1,-1) then //Si entra en este condicional es porque se buscaron todas las letras y no se encontro la palabra
             printfn "Palabra no encontrada: %A" goal
             []
        elif verificarCoordenadas rutas.Head goal matrix then //Si entra aqui es porque la cabeza de las rutas tiene el mismo tamano que la palabra buscada, entonces se verifica si son iguales
            printfn "%A" (List.rev rutas.Head)
            List.rev rutas.Head
        elif goal.Length<=rutas.Head.Length then   // Si la ruta actual tiene una longitud mayor o igual a la palabra buscada, pasamos a la siguiente ruta
            if(rutas.Tail <> []) then
            prof_aux rutas.Tail origin goal (rutas.Tail.Head.Length-1) matrix
            else
            prof_aux rutas.Tail origin goal index matrix
  
        elif (verificarCorrespondencia rutas.Head.Head (goal[index]) matrix) then // Si la letra actual de la ruta coincide con la letra correspondiente de la palabra buscada, extendemos la ruta y pasamos a la siguiente letra de la palabra
              prof_aux (List.append (extender rutas.Head origin matrix) rutas.Tail) origin goal (index+1) matrix  
        else // Si no se cumple ninguna de las condiciones anteriores, pasamos a la siguiente ruta
            if(rutas.Tail <> []) then
            prof_aux rutas.Tail origin goal (rutas.Tail.Head.Length-1) matrix
            else
            prof_aux rutas.Tail origin goal index matrix

    //Es la funcion principal que vamos a utilizar que recibe la lista de palabras y la matriz y llama
    //las funciones encargados de realizar los procedimientos y obtiene la lista con todas las coordenadas de las palabras
    //Es una modificacion de prof original pero que ahora reciba una lista de palabras en vez de una sola palabra 
    let prof (listaPalabras: _ list list) (matrix: char[,]) =
        let (matriz : char list list) = ConvertirMatriz matrix 
        listaPalabras
        |> List.map (fun goal -> (prof_aux [[findFirstLetterPosition 0 0 goal[0] matriz]] (findFirstLetterPosition 0 0 goal[0] matriz) goal 0 matriz))
        |> List.filter (fun x -> x <> [])

    
    