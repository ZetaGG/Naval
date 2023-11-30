
class Funciones
{
    public void llenar(string[,] a, string[,] b, double r)
    {
        double b1 = r;
        double b2 = r;

        for (int j = 0; j < r; j++)
        {
        Denuevo:
            Console.Clear();
            Console.WriteLine($"Barcos restantes {b1}");
            Console.WriteLine($"Jugador 1 ingrese la posicion su barco {j + 1}");
            Console.Write("X");
            int x = int.Parse(Console.ReadLine())-1;
            if (x >= a.GetLength(0))
            {
                Console.WriteLine("Ingresa numero dentro del tablero");
                goto Denuevo;
            }
            Console.Write("Y");
            int y = int.Parse(Console.ReadLine())-1;
            if (x >=a.GetLength(0))
            {
                Console.WriteLine("Ingresa numero dentro del tablero");
                goto Denuevo;
            }
            if (a[y,x]=="B")
            {
                Console.WriteLine("Esta posicion ya esta ocupada");
                Console.ReadKey();
                goto Denuevo;
            }
            a[y, x] = "B";
            b1--;

        }

        for (int j = 0; j < r; j++)
        {
        Denuevo2:
            Console.Clear();
            Console.WriteLine($"Barcos restantes {b2}");
            Console.WriteLine($"Jugador 2 ingrese la posicion su barco {j + 1}");
            Console.Write("X");
            int x = int.Parse(Console.ReadLine())-1;
            if (x >= a.GetLength(0))
            {
                Console.WriteLine("Ingresa numero dentro del tablero");
                goto Denuevo2;
            }
            Console.Write("Y");
            int y = int.Parse(Console.ReadLine())-1;
            if (y >= a.GetLength(0))
            {
                Console.WriteLine("Ingresa numero dentro del tablero");
                goto Denuevo2;
            }

            if (b[y, x] == "B")
            {
                Console.WriteLine("Esta posicion ya esta ocupada");
                Console.ReadKey();
                goto Denuevo2;
            }

            b[y, x] = "B";
            b2--;
        }
    }

    public void Juego(int N, string[,] a, string[,] b, double barcos,bool jugador)
    {
       
        string[,] tab = new string[N, N];
        string[,] tab2 = new string[N, N];
        double barcos1 = barcos;
        double barcos2 = barcos;

        //Llenar tablero
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
            {
                
                tab[i, j] = "0";

            }


        }

        for (int i = 0; i < b.GetLength(0); i++)
        {
            for (int j = 0; j < b.GetLength(1); j++)
            {
                
                tab2[i, j] = "0";
            }


        }

    
       
        

        while (true)
        {



            switch (jugador)
            {
                case false:

                    Console.Clear();
                    Console.WriteLine("Tablero Jugador 2");

                    // Mostrar el tablero del jugador 2
                VolverAtacar:
                    Console.Clear();
                    for (int i = 0; i < N; i++)
                    {
                        for (int j = 0; j < N; j++)
                        {
                            if (tab2[i, j] == "A")
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write(tab2[i, j] + "\t");
                                Console.ForegroundColor = ConsoleColor.White;

                            }
                            else if (tab2[i, j] == "V")
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.Write(tab2[i, j] + "\t");
                                Console.ForegroundColor = ConsoleColor.White;

                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(tab2[i, j] + "\t");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        Console.WriteLine();
                    }

                    // Ingresar el ataque del jugador 1

                    Console.WriteLine("Jugador 1 Ingrese su ataque");
                    Console.Write("X: ");
                    int x = int.Parse(Console.ReadLine()) - 1;

                    if (x < 0 || x >= N)
                    {
                        Console.WriteLine("Ingresa un número dentro del rango del tablero.");
                        Console.ReadKey();
                        continue;  // Vuelve al inicio del bucle
                    }

                    Console.Write("Y: ");
                    int y = int.Parse(Console.ReadLine()) - 1;

                    if (y < 0 || y >= N)
                    {
                        Console.WriteLine("Ingresa un número dentro del rango del tablero.");
                        Console.ReadKey();
                        continue;  // Vuelve al inicio del bucle
                    }

                    if (tab2[y, x] == "A")
                    {
                        Console.WriteLine("Esta posicion ya a sido atacada");
                        Console.ReadKey();
                        goto VolverAtacar;
                    }
                    else if (tab2[y, x] == "V")
                    {
                        Console.WriteLine("Esta ya a sido atacada y esta vacia");
                        Console.ReadKey();
                        goto VolverAtacar;
                    }
                    tab2[y, x] = "B";
                    if (tab2[y, x] == b[y, x])
                    {
                        Console.WriteLine("Acertaste a un barco");
                        Console.ReadKey();
                        tab2[y, x] = "A";
                        barcos2--;

                        if (barcos2 == 0)
                        {
                            Console.WriteLine("Jugador 1 ha hundido todos los barcos");
                            Console.WriteLine("¡Jugador 1 Gana!");
                            Console.ReadKey();
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Erraste");
                        Console.ReadKey();
                        tab2[y, x] = "V";
                    }

                    jugador = true;
                    break;
                    //Fin del ataque del jugador 1


                case true:
                
                    DenuevoAtaque2:
                    Console.Clear();
                    Console.WriteLine("Tablero Jugador 1");
                    for (int i = 0; i < N; i++)
                    {
                        for (int j = 0; j < N; j++)
                        {
                            //Comparar el lugar y cambiar l color
                            if (tab[i, j] == "A")
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write(tab[i, j] + "\t");
                                Console.ForegroundColor= ConsoleColor.White;

                            }
                            else if (tab[i, j] == "V")
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.Write(tab[i, j] + "\t");
                                Console.ForegroundColor = ConsoleColor.White;

                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(tab[i, j] + "\t");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }

                        Console.WriteLine();
                    }




                    Console.WriteLine("Jugador 2 Ingrese su ataque");
                    Console.Write("X");
                    int x2 = int.Parse(Console.ReadLine())-1;
                    if (x2 > N||x2<0)
                    {
                        Console.WriteLine("Ingresa numero dentro del tablero");
                        Console.ReadKey();
                        goto DenuevoAtaque2;
                    }
                    Console.Write("Y");
                    int y2 = int.Parse(Console.ReadLine())-1;
                    if (y2 <0|| y2> N)
                    {
                        Console.WriteLine("Ingresa numero dentro del tablero");
                        Console.ReadKey();
                        goto DenuevoAtaque2;
                    }

                    //Comparar si ya a sdo atacado la posicion
                    if (tab[y2, x2] == "A")
                    {
                        Console.WriteLine("Esta posicion ya a sido atacada");
                        Console.ReadKey();
                        goto DenuevoAtaque2;
                    }
                    else if (tab[y2, x2] == "V")
                    {
                        Console.WriteLine("Esta ya a sido atacada y esta vacia");
                        Console.ReadKey();
                        goto DenuevoAtaque2;
                    }

                    tab[y2, x2] = "B";
                    if (tab[y2, x2] == a[y2, x2])
                    {
                        Console.WriteLine("Acertaste a un barco");

                        tab[y2, x2] = "A";
                        Console.ReadKey();
                        barcos1--;
                        if (barcos1 == 0)
                        {
                            Console.WriteLine("Jugador 1 a hundido todos los barcos");
                            Console.WriteLine("Jugador 1 Gana");
                            Console.ReadKey();
                            return;
                        }
                    }

                    else
                    {
                        Console.WriteLine("Erraste");
                        tab[y2, x2] = "V";
                        Console.ReadKey();

                    }
                    jugador = false;
                    break;

            }

        }

    }
}


class program
{
    static void Main()
    {
        Console.WriteLine(@"
Representacion de colores
R=Barco Atacado
0=Mar
V=Vacio");
        Funciones funciones = new Funciones();
        Console.WriteLine("Ingrese el tamano del tablero");
        int N = int.Parse(Console.ReadLine());

        string[,] tablero = new string[N, N];
        string[,] tablero2 = new string[N, N];

        double numeroOriginal = (N * N) * 0.2;
        double numeroRedondeado = Math.Round(numeroOriginal, 0);
        
        funciones.llenar(tablero, tablero2,numeroRedondeado);
        Console.Clear();
        bool jugador = false;
        funciones.Juego(N, tablero, tablero2, numeroRedondeado, jugador);
    }
}

