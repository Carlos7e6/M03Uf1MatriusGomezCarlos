//AUTHOR: CARLOS GOMEZ
//DATE: 23/11/2000
//DESCRIPTION: Exercicis vectors Uf1


using System.Numerics;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

public class Vectors
{
    public static void Main()
    {
        var menu = new Vectors();
        menu.MultiMatriu();
    }

    /*DESCRIPTION: Aquest es el menu que utilitzarem per navegar*/
    public void Menu()
    {


        char x;
        do
        {
            Console.Clear(); ;
            Console.WriteLine();
            Console.WriteLine("");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - SimpleBattleshipResult");
            Console.WriteLine("2 - MatrixElementSum");
            Console.WriteLine("3 - MatrixBoxesOpenedCounter");
            Console.WriteLine("4 - MatrixThereADiv13");
            Console.WriteLine("5 - HighestMountainOnMap");
            Console.WriteLine("6 - HighestMountainScalechange");
            Console.WriteLine("7 - MatrixSum");
            Console.WriteLine("8 - RookMoves");
            Console.WriteLine("9 - MatrixSimetric");


            Console.WriteLine();
            Console.WriteLine("Escolleix una opció: ");
            x = Convert.ToChar(Console.ReadLine());

            switch (x)
            {
                case '0':
                    Console.WriteLine("Bye");
                    break;
                case '1':
                    SimpleBattleshipResult();
                    break;
                case '2':
                    MatrixElementSum();
                    break;
                case '3':
                    MatrixBoxesOpenedCounter();
                    break;
                case '4':
                    MatrixThereADiv13();
                    break;
                case '5':
                    HighestMountainOnMap();
                    break;
                case '6':
                    HighestMountainScalechange();
                    break;
                case '7':
                    MatrixSum();
                    break;
                case '8':
                    RookMoves();
                    break;
                case '9':
                    MatrixSimetric();
                    break;
                default:
                    Console.WriteLine("Prem un valor valid");
                    break;
            }

        } while (x != '0');
    }

    /*Donada la següent configuració del joc Enfonsar la flota, indica si a la posició (x, y) hi ha aigua o un vaixell (tocat)*/
    public void SimpleBattleshipResult()
    {

        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("SimpleBattleshipResult");
        Console.WriteLine();

        int mx;
        int my;

        my = mx = 7;//li dono variables a l'array perque m'agrada mes si en un futur vull cambiar el tamany y no vull cambiar el codi ( DI NO! AL HARDCODE)
        char[,] mar = new char[mx,my];

        for(int i=0; i < mar.Length/mx ; i++)
        {
            for(int j =0; j < mar.Length/my; j++) //aqui basicament el que faig es omplir la array de 0, seria com l'aigua
            {
                mar[i,j]= '0'; 

            }
        }

        mar[0,0] = 'x';
        mar[0,6] = 'x';
        mar[1,0] = 'x';
        mar[1,3] = 'x';
        mar[2,1] = 'x';
        mar[2,3] = 'x'; //aqui dic les posicions on hi ha vaixells que sera la x
        mar[3,3] = 'x';
        mar[4,4] = 'x';
        mar[4,5] = 'x';
        mar[6,0] = 'x';
        mar[6,1] = 'x';
        mar[6,2] = 'x';
        mar[6,3] = 'x';

        int x = -1;
        int y = -1;

        do
        {
            Console.WriteLine("Donam un valor entre 1 y 7 per x: ");
            x = Convert.ToInt32(Console.ReadLine());
            x--;
           

        } while (x <= -1 || x > 7);//COMPROVO si em donen valors valids

        do
        {
            Console.WriteLine("Donam un valor entre 1 y 7 per y: ");
            y = Convert.ToInt32(Console.ReadLine());
            y--;

        } while (y <= -1 || y > 7);//mes comprovacions

        if (mar[x, y] == 0) Console.WriteLine("aigua");// comprovo si el que m'han donat es aigua o no
        else Console.WriteLine("tocat");

        for (int i = 0; i < mar.Length / mx; i++)//printo la taula
        {
            Console.WriteLine();
            Console.Write((i + 1) + " ");
            for (int j = 0; j < mar.Length / my; j++)
            {
                Console.Write(mar[j, i] + "\t");//s'ha de printar amb y al lloc de x i a l'inreves perque la array i el writeline funcionen de diferent manera
            }
        }
        Console.WriteLine() ;
        Console.WriteLine("Prem enter per tornar al menu");
        Console.ReadLine();

    }
    /*Donada la següent matriu
    matrix = {{2,5,1,6},{23,52,14,36},{23,75,81,64}}

    Imprimeix la suma de tots els seus valors.
    */
    public void MatrixElementSum()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("MatrixElementSum");
        Console.WriteLine();

        int[,] matrix = { { 2, 5, 1, 6 }, { 23, 52, 14, 36 }, { 23, 75, 81, 64 } };//pues la matriz sin mas
        int contador = 0;


            foreach (int num in matrix)
            {
            contador += num;//lo sumo todo y pa casa
            }

        Console.WriteLine(contador);//printo

        Console.WriteLine();
        Console.WriteLine("Prem enter per tornar al menu");
        Console.ReadLine();
    }

    /*Un banc té tot de caixes de seguretat en una graella, numerades per fila i columna del 0 al 3.
    Volem registrar quan els usuaris obren una caixa de seguretat, i al final del dia, fer-ne un recompte.
    L'usuari introduirà parells d'enters del 0 al 3 quan s'obri la caixa indicada.
    Quan introdueixi l'enter -1, és que s'ha acabat el dia. Printa per pantalla el nombre de cops que s'ha obert.
    */
    public void MatrixBoxesOpenedCounter() 
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("MatrixBoxesOpenedCounter");
        Console.WriteLine();

        int bx;
        int by;
        bx = by = 4;

        int openBX =0;
        int openBY =0;

        int[,] boxes = new int [bx,by];

        for (int i = 0; i < boxes.Length / bx; i++)
        {
            for (int j = 0; j < boxes.Length/by; j++) boxes[i, j] = 0;//dic que totes les boxes s'han obert 0 vegades
        }

        while (openBX != -1 && openBY != -1)
        {
            Console.WriteLine("Donam el valor de x: ");
            
            do
            {
                Console.WriteLine("Ha de ser entre 0 i 3 o -1 si vols sortir del programa");
                openBX = Convert.ToInt32(Console.ReadLine());

            } while (openBX < -2 || openBX > 4) ;

            if (openBX != -1)                               //aqui demano x e y
            {
                Console.WriteLine("Donam el valor de y: ");
                do
                {
                    Console.WriteLine("Ha de ser entre 0 i 3  o -1 si vols sortir del programa ");
                    openBY = Convert.ToInt32(Console.ReadLine());

                }while(openBY < -2 || openBY > 4);
                if(openBY != -1) boxes[openBX, openBY] += 1;//sumo 1 a la caixa oberta
            }

        }

        for (int i = 0; i < boxes.Length / bx; i++)//printo la taula
        {
            Console.WriteLine();
            Console.Write((i) + " ");
            for (int j = 0; j < boxes.Length / by; j++)
            {
                Console.Write(boxes[j, i] + "\t");//s'ha de printar amb y al lloc de x i a l'inreves perque la array i el writeline funcionen de diferent manera
            }
        }

        Console.WriteLine();
        Console.WriteLine("Prem enter per tornar al menu");
        Console.ReadLine();
    }



    public void MatrixThereADiv13()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("MatrixThereADiv13");
        Console.WriteLine();

        int[,] matrix = { { 2, 5, 1, 6 }, { 23, 52, 14, 36 }, { 23, 75, 81, 62 } };
        bool divisible;
        int contador = 0;

        foreach (int num in matrix)
        {
            if(num % 13 == 0) contador++; //conto quins son divisibles per 13
        }

        if (contador > 0) divisible = true; else divisible =false; //si algun es divisible es true

        Console.Write(divisible);

        Console.WriteLine();
        Console.WriteLine("Prem enter per tornar al menu");
        Console.ReadLine();
    }

    /*Usant les imatges d'un satel·lit hem pogut fer raster o (mapa de bits)[https://ca.wikipedia.org/wiki/Mapa_de_bits] que ens indica l'alçada d'un punt concret d'un mapa. Hem obtingut la següent informació:
    map ={{1.5,1.6,1.8,1.7,1.6},{1.5,2.6,2.8,2.7,1.6},{1.5,4.6,4.4,4.9,1.6},{2.5,1.6,3.8,7.7,3.6},{1.5,2.6,3.8,2.7,1.6}}

    Digues en quin punt(x,y) es troba el cim més alt i la seva alçada
    */
    public void HighestMountainOnMap()
    {

        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("HighestMountainOnMap");
        Console.WriteLine();


        double altMax = 0;
        int x = 0; ;
        int y = 0; ;

        double[,] map = { { 1.5, 1.6, 1.8, 1.7, 1.6 }, { 1.5, 2.6, 2.8, 2.7, 1.6 }, { 1.5, 4.6, 4.4, 4.9, 1.6 }, { 2.5, 1.6, 3.8, 7.7, 3.6 }, { 1.5, 2.6, 3.8, 2.7, 1.6 } };

        for(int i =0; i <map.Length/5; i++)
        {
            for(int j=0; j<map.Length/5; j++)
            {
                if (map[i,j] > altMax)
                {
                    altMax = map[i,j];
                    x = i;
                    y=j;
                }
            }
        }

        Console.WriteLine("[" +x + "," + y + "]: " + map[x, y] + " metres");

        Console.WriteLine();
        Console.WriteLine("Prem enter per tornar al menu");
        Console.ReadLine();
    }

    /*El govern britànic ens ha demanat que també vol accedir a les dades de l'exercici anterior i que les necessitaria en peus i no metres.
Per convertir un metre a peus has de multiplicar els metres per 3.2808.
Fes la conversió i imprimeix la matriu per pantalla.
*/

    public void HighestMountainScalechange() 
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("HighestMountainOnMap");
        Console.WriteLine();

        double[,] map = { { 1.5, 1.6, 1.8, 1.7, 1.6 }, { 1.5, 2.6, 2.8, 2.7, 1.6 }, { 1.5, 4.6, 4.4, 4.9, 1.6 }, { 2.5, 1.6, 3.8, 7.7, 3.6 }, { 1.5, 2.6, 3.8, 2.7, 1.6 } };

        for (int i = 0; i < map.Length / 5; i++)
        {
            for (int j = 0; j < map.Length / 5; j++)
            {
                map[i,j]*= 3.2808;
            }
        }

        foreach (var item in map)
        {

            Console.WriteLine(item + " peus");
        }



        Console.WriteLine();
        Console.WriteLine("Prem enter per tornar al menu");
        Console.ReadLine();
    }

    /*Implementa un programa que demani dos matrius a l'usuari i imprimeixi la suma de les dues matrius.*/


    public void MatrixSum() 
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("MatrixSum");
        Console.WriteLine();

        int matriuX1 = 0;
        int matriuY1 = 0;
        int matriuX2 = 1;
        int matriuY2 = 1;

        int[,] matriu1 = new int[matriuX1,matriuY1];
        int[,] matriu2 = new int[matriuX2, matriuY2];
        int[,] final = new int[matriuX1, matriuY1];

        while ( matriuX1 != matriuX2 || matriuY1 != matriuY2)
        {
            Console.Clear();
            Console.WriteLine("Porfavor introduce matrices que sean compatibles");

            Console.WriteLine("Primera matriu");
            Console.WriteLine("Escriu X de la primera matriu");

            matriuX1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Escriu Y de la primera matriu");

            matriuY1 = Convert.ToInt32(Console.ReadLine());

            matriu1 = new int[matriuX1, matriuY1];

            for (int i = 0; i < matriu1.GetLength(0); i++)
            {
                for (int j = 0; j < matriu1.GetLength(1); j++)
                {
                    Console.WriteLine("Escriu el valor del camp de la primera matriu de: [" + i + "," + j + "]");
                    matriu1[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }


            Console.WriteLine("Segona matriu");
            Console.WriteLine("Escriu X de la segona matriu");

            matriuX2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Escriu Y de la segona matriu");

            matriuY2 = Convert.ToInt32(Console.ReadLine());

            matriu2 = new int[matriuX2, matriuY2];

            for (int i = 0; i < matriu1.GetLength(0); i++)
            {
                for (int j = 0; j < matriu1.GetLength(1); j++)
                {
                    Console.WriteLine("Escriu el valor del camp de la segona matriu de: [" + i + "," + j + "]");
                    matriu2[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

        }

        final = new int[matriuX1, matriuY1];

        for (int i = 0; i < matriu1.GetLength(0); i++)
        {
            for (int j = 0; j < matriu1.GetLength(1); j++)
            {
                final[i,j]= matriu1[i,j] + matriu2[i,j];
            }
        }

        for (int i = 0; i <matriu1.GetLength(0); i++)
        {
            Console.WriteLine();

            for (int j = 0; j < matriu1.GetLength(1); j++)
            {
                Console.Write(final[i,j] + "\t");
            }
        }


        Console.WriteLine();
        Console.WriteLine("Prem enter per tornar al menu");
        Console.ReadLine();
    }

    /*Programa una funció que donat un tauler d'escacs, i una posició, ens mostri per pantalla quines són les possibles posicions a les que es pot moure una torre.
Primer caldrà llegir la posició de la torre, que simbolitzarem en el tauler amb el valor ♜ (fes copy & paste del símbol, és un string ja que ocupa dos chars), les posicions on aquesta es pugui moure les simbolitzarem amb el valor ♖ i la resta de posicions amb el valor x.
El moviment de la torre és el següent: Es pot moure al llarg d'una fila o d'una columna (però no successivament en una mateixa jugada); se la pot fer avançar tantes caselles com es vulgui.
*/
    public void RookMoves() 
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("RookMoves");
        Console.WriteLine();

        char[,] tablero = new char[8, 8];
        int alt=0;
        int anchura = 0;
        char lletra;

        Console.WriteLine("Dame la altura de la torre");
        do
        {
            
            lletra = Convert.ToChar(Console.ReadLine());

            switch (lletra)
            {
                case 'a':
                    alt = 0; break;
                case 'b':
                    alt = 1; break;
                case 'c':
                    alt = 2; break;
                case 'd':
                    alt = 3; break;
                case 'e':
                    alt = 4; break;
                case 'f':
                    alt = 5; break;
                case 'g':
                    alt = 6; break;
                case 'h':
                    alt = 7; break;
                default: Console.WriteLine("Dame un valor valido"); break;
            }
        } while (lletra !='a' && lletra !='b' && lletra !='c' && lletra != 'd' && lletra !='e' && lletra !='f' && lletra !='g' && lletra !='h');

        Console.WriteLine("Dame la anchura de la torre");
        do
        {
            Console.WriteLine("Tiene que estar entre la anchura de la torre -- (1-8)");
            anchura = Convert.ToInt32(Console.ReadLine());

        } while (anchura <= 0 || anchura >= 9);

        for(int i = 0; i < tablero.GetLength(0); i++)
        {
            for (int j = 0; j < tablero.GetLength(1); j++)
            {
                tablero[i, j] = '.';
            }
        }
        for(int i=0; i < tablero.GetLength(0); i++)
        {
            tablero[alt, i] = '#';
            tablero[i, anchura -1] = '#';
        }

        tablero[alt, anchura - 1] = '@';

        for (int i = 0; i < tablero.GetLength(0); i++)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            for (int j = 0; j < tablero.GetLength(1); j++)
            {
                Console.Write(tablero[i, j]+"\t");
            }
        }

        Console.WriteLine();
        Console.WriteLine("Prem enter per tornar al menu");
        Console.ReadLine();
        Console.ReadLine();
    }

    /*Donada una matriu quadrada, el programa imprimeix true si la matriu és simètrica, false en cas contrari.*/

    public void MatrixSimetric()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("MatrixSimetric");
        Console.WriteLine();

        int alt = Convert.ToInt32(Console.ReadLine());
        int amp = alt;
        int[,] Matrix = new int[alt,amp];
        bool simetric = true;

        for (int i = 0; i < Matrix.GetLength(0); i++)
        {
            for (int j = 0; j < Matrix.GetLength(j); j++)
            {
                Matrix[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        for (int i = 0; i < Matrix.GetLength(0); i++)
        {
            for(int j =0; j < Matrix.GetLength(1); j++)
            {
                if (Matrix[i, j] != Matrix[j, i]) simetric = false;
                
            }    
        }

        Console.WriteLine(simetric);

        Console.WriteLine();
        Console.WriteLine("Prem enter per tornar al menu");
        Console.ReadLine();
    }




    public void MatrixSimetricErroni()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("HighestMountainOnMap");
        Console.WriteLine();

        int[,] Matrix= new int[3, 3] { { 1, 2, 3 }, { 2, 1, 2 }, { 3,2,1} };


        int x = Convert.ToInt32(Console.ReadLine());
        int y = Convert.ToInt32(Console.ReadLine());
        int[,] MatrixSim = new int [x,y];

        bool simetric = true;

        if (x == Matrix.GetLength(0) && y == Matrix.GetLength(1))
        {
            for (int i = 0; i < MatrixSim.GetLength(0); i++)
            {
                for (int j = 0; j < MatrixSim.GetLength(1); j++)
                {
                    MatrixSim[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            for (int i = 0; i < MatrixSim.GetLength(0); i++)
            {
                for (int j = 0; j < MatrixSim.GetLength(1); j++)
                {
                    if (Matrix[i, j] != MatrixSim[i, j]) simetric = false;
                }
            }
        }
        else simetric = false;

        Console.WriteLine(simetric);


        Console.WriteLine();
        Console.WriteLine("Prem enter per tornar al menu");
        Console.ReadLine();
    }

    /*Multiplicació de matrius

Les matrius es poden multiplicar entre elles mentre siguin de quadrades de igual dimensió o interc
*/

    public void MultiMatriu()
    {

        Console.WriteLine("Donam el valor x de la matriu 1");
        int Matriu1X = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Donam el valor y de la matriu 1");
        int Matriu1Y = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Donam el valor x de la matriu 2");
        int Matriu2X = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Donam el valor y de la matriu 1");
        int Matriu2Y = Convert.ToInt32(Console.ReadLine());

         int[,] Matriu1 = new int[Matriu1X, Matriu1Y];
         int[,] Matriu2 = new int[Matriu2X, Matriu2Y];

         int[,] resultat = new int[Matriu1X,Matriu1Y];

          while(Matriu1Y != Matriu2X)
          {
              Console.WriteLine("Les matrius han de ser iguals o interc");
              Matriu1X = Convert.ToInt32(Console.ReadLine());
              Matriu1Y = Convert.ToInt32(Console.ReadLine());
              Matriu2X = Convert.ToInt32(Console.ReadLine());
              Matriu2Y = Convert.ToInt32(Console.ReadLine());

          }  
         
        for(int i=0; i < Matriu1.GetLength(0); i++)
        {
            for(int j =0; j < Matriu1.GetLength(1); j++)
            {
                Matriu1[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        for (int i = 0; i < Matriu2.GetLength(0); i++)
        {
            for (int j = 0; j < Matriu2.GetLength(1); j++)
            {
                Matriu2[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }


        for (int i =0; i < resultat.GetLength(0); i++)
        {
            for(int j = 0; j < Matriu2.GetLength(1); j++)
            {
                for (int z=0; z < Matriu1.GetLength(0); z++)
                {
                    resultat[i, j] += Matriu1[i, z] * Matriu2[z, j];
                }
            }
        }

        for(int i=0; i < resultat.GetLength(0); i++)
        {
            Console.WriteLine();

            for(int j =0; j < resultat.GetLength(1); j++)
            {
                Console.Write(resultat[i, j] +"\t");
            }
        }
        

    }
}