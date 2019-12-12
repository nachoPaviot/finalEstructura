using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace finalEstructura
{
    class Cola
    {
        static void Main(string[] args)
        {
            Queue <int> pedidos = null;//Se instancia cola de enteros sin inicializarla.

            void menuPrincipal()
            {
                int decision;

                Console.Write("\nMENU:\n");
                Console.Write("1) Crear Cola\n" + "2) Borrar Cola\n" + "3) Agregar Pedido\n" + "4) Borrar Pedido\n" + "5) Listar todos los Pedidos\n" + "6) Listar mayor pedido\n" + "7) Listar último Pedido\n" + "8) Listar primer Pedido\n" + "9) Cantidad de un Pedido\n" + "10) Sumar pedidos\n" + "0) Salir\n");
                Console.Write("\nSeleccione una opción: ");
                decision = Convert.ToInt32(Console.ReadLine());

                switch (decision)
                {
                    case 1:
                        crearCola();
                        break;
                    case 2:
                        borrarCola();
                        break;
                    case 3:
                        agregarPedido();
                        break;
                    case 4:
                        borrarPedido();
                        break;
                    case 5:
                        todosPedidos();
                        break;
                    case 6:
                        mayorPedido();
                        break;
                    case 7:
                        ultimoPedido();
                        break;
                    case 8:
                        primerPedido();
                        break;
                    case 9:
                        cantidadPedidos();
                        break;
                    case 10:
                        sumaPedidos();
                        break;
                    case 0:
                        Salir();
                        break;
                    default:
                        Console.WriteLine("\nIngresaste cualquier cosa. Probá de nuevo...");
                        break;
                }
                Thread.Sleep(2000);
                menuPrincipal();//Se utiliza recursividad excepto "case 9"
            }

            void crearCola()
            {
                pedidos = new Queue<int>();
                Console.WriteLine("\nCola creada!!!\n");
            }

            void borrarCola()
            {
                pedidos.Clear();
                Console.WriteLine("\nCola vaciada!!!\n");
            }

            void agregarPedido()
            {
                Console.WriteLine("\nIngrese su pedido: ");
                int pedido = Convert.ToInt32(Console.ReadLine());

                if (pedido > 0 && pedido < 999)//Validación de valores ingresados por el usuario.
                {
                    pedidos.Enqueue(pedido);//Se carga la cola con pedidos.
                    Console.Write("\nPedido ingresado!!!\n");
                }
                else
                {
                    Console.WriteLine("\nPedido ingresado incorrectamente. Pruebe de nuevo...\n");
                    agregarPedido(); //Se utiliza recursividad para volver a pedir el ingreso en caso de error de valores de entrada. 
                }
               
            }

            void borrarPedido()
            {
                Queue<int> colaAux = new Queue<int>();//Se inicializa cola auxiliar para pasar valores con la cola de instancia.
                int valorAux = 0;//Variable auxiliar.

                Console.WriteLine("\n¿Qué pedido desea borrar?");
                int pedido = Convert.ToInt32(Console.ReadLine());

                while (pedidos.Count() > 0)//Comenzamos pasando los valores de la cola de instancia a la cola auxiliar.
                {
                    valorAux = pedidos.Dequeue();//Cargamos la variable con los elementos de la cola de instancia.

                    if (valorAux != pedido)//Cargamos todos los valores expecto el valor de la variable "pedido", asi no incluimos el valor que el usuario desea eliminar.
                    {
                        colaAux.Enqueue(valorAux);//Cargamos la cola auxiliar con el elemento de "valorAux".
                    }
                }
                while (colaAux.Count() > 0)
                {
                    pedidos.Enqueue(colaAux.Dequeue());//Finalmente llenamos la cola de instancia con todos los valores expecto el elemento eliminado.
                }
                Console.WriteLine("\nPedido eliminado!!!");
            }

            void todosPedidos()
            {
                int indicador = 1;

                foreach (int num in pedidos)//Recorremos la cola
                {
                    Console.WriteLine(indicador + "-" + num);//Imprimimos por pantalla la lista de pedidos con el formato indicado.
                    indicador += 1;
                }
            }

            void ultimoPedido()
            {
                int cantidad = pedidos.Count();
                int cont = 0;

                foreach (int num in pedidos)//Recorremos la cola
                {
                    cont += 1;
                    if (cont==cantidad)//Entramos al if cuando llegamos al último elemento de la cola.
                    {
                        Console.WriteLine("\nEl último pedido es: " + num);//Imprimimos por pantalla el último elemento.
                    }
                }
            }

            void primerPedido()
            {
                Console.WriteLine("\nEl primer pedido es: " + pedidos.Peek() + "\n");//Método Peek nos muestra el primer elemento de la cola sin eliminarlo.
            }

            void cantidadPedidos()
            {
                Console.WriteLine("\nLa cantidad de pedidos es: " + pedidos.Count());//Método Count da la cantidad de elementos.
            }

            void Salir()
            {
                Console.Write("\nGracias por utilizar nuestra herramienta.\n\n\n");
                Console.ReadKey();
                Environment.Exit(1);
            }

            //métodos adicionales

            void mayorPedido()
            {
                int mayor = 0;

                foreach (int num in pedidos)
                {
                    if (num > mayor)//Si el valor en la cola es mayor a la variable de referencia. La asignamos como mayor.
                    {
                        mayor = num;
                    }
                }
                Console.WriteLine("\nEl mayor pedido fue de: " + mayor);
            }

            void sumaPedidos()
            {
                int suma = 0;
                foreach (int num in pedidos)//Recorremos la cola y sumamos los elementos.
                {
                    suma += num;
                }
                Console.WriteLine("\nLa suma de los pedidos es: " + suma);
            }

            menuPrincipal();
        }
    }
}


