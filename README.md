Proyecto 2 paradigma funcional utilizando f# para realizar una busqueda en profundidad y encontrar las palabras en una matriz que simula ser una sopa de letras y permite la jugabilidad de la sopa de letras mediante c# interfaz grafica. Por lo que se tiene que hacer una conexion de ensamblado entre c# y f# para permitir intercambiar funciones, variables y parametros entre ambos subproyectos.

Enlace video explicativo de manera muy general: https://youtu.be/wmUPN8v1AgY (El video en teoria tiene que durar 5 minutos pero es imposible explicar 3 subproyectos y una interfaz grafica con ese tiempo y eso que explico muy general)


Ejemplos de la funcion:

    (fila, columna)
    let sopaLetras =[['c';'o';'l';'a';'o';'r']
                     ['c';'a';'s';'a';'c';'h']  
                     ['c';'a';'m';'a';'y';'o']
                     ['h';'o';'y';'o';'p';'l']
                     ['a';'s';'a';'m';'x';'a']
                     ['a';'s';'a';'c';'z';'w']]
    


                   Palabra             Ubicacion devuelta por el programa
    let palabra = ['c';'a';'s';'a'] = [(1, 0); (1, 1); (1, 2); (1, 3)]
    let palabra2 = ['c';'a';'m';'a'] = [(2, 0); (2, 1); (2, 2); (2, 3)]
    let palabra3 = ['m';'a';'s';'a'] = [(4, 3); (4, 2); (4, 1); (4, 0)]
    let palabra4 = ['h';'o';'l';'a'] = [(1,5);(2,5);(3,5);(4;5)]
    let palabra5 = ['c';'a';'y'] = [(1,0);(2,1);(3,2)]
    let palabra6 = ['m';'o';'a'] = [(2,2);(3,1);(4,0)]
    let palabra5 = ['p';'e';'r';'a'] = no encontrada -> No devolver nada

Apartado principal:

![image](https://user-images.githubusercontent.com/82431338/232261363-a58f3071-6bf2-4d83-ba17-f574df0407e0.png)

Boton cambiar palabra:

![image](https://user-images.githubusercontent.com/82431338/232261386-676f194f-5c7a-4429-ae9f-e625b65d4015.png)

Cuenta con especificaciones de seleccionar solo una palabra y escribir la nueva en mayusculas y sin espacios, esto pasa si se incumple:
![image](https://user-images.githubusercontent.com/82431338/232261418-bc8c755c-6d4d-4819-b048-0ce0d69dfbac.png)
![image](https://user-images.githubusercontent.com/82431338/232261435-982781ea-86a9-4586-907a-d6f2fa4f7335.png)

Y si lo cambiamos correctamente:
![image](https://user-images.githubusercontent.com/82431338/232261445-2aba7f60-d0bf-4c24-9a15-bcd24d359c30.png)


Ejemplo de la sopa de letras en ejecucion al iniciar el juego:

![image](https://user-images.githubusercontent.com/82431338/232261318-3d1dede1-4133-483c-96fa-0acea7002445.png)

Si pulsamos el boton de "Resolver todo" que se encarga de obtener las coordenadas del subproyecto de f# y pinta el datagridView

![image](https://user-images.githubusercontent.com/82431338/232261356-7d71d3a7-37d2-4149-a69c-117ad1ee2261.png)

En el video se explica de manera muy general, entonces se van a podran cambios de documentacion e interfaz. Parte funcional no, porque ya funciona perfectamente
