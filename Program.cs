using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declaro las constantes, el mensaje y el corte establecido por el ejercicio.
            var MENSAJE = "Hola soy programador";
            var CORTE = 5;

            //Declaro un diccionario y lo lleno.
            Dictionary<Char, int> diccionario = new Dictionary<Char, int>();
            diccionario = LlenarDiccionario(diccionario);
            
            //Agarramos el mensaje y lo seccionamos segun lo establecido por el ejercicio.
            ArrayList recorte = cortarCadena(MENSAJE, CORTE);

            //Cifro mensaje
            string MENSAJE_CIFRADO = cifrar(recorte, diccionario);

            //IMPRIMO RESULTADOS DEL CIRADO
            Console.WriteLine("A continuación se muestra el mensaje cifrado");
            Console.WriteLine(MENSAJE_CIFRADO);
            Console.WriteLine("--------------------------------------------------");

            //Descifro mensaje
            string MENSAJE_DESCIFRADO = descifrar(MENSAJE_CIFRADO, diccionario, CORTE - 1);

            Console.WriteLine("A continuación se muestra el mensaje descifrado");
            Console.WriteLine(MENSAJE_DESCIFRADO);

            //---------------------METODOS---------------------//


            //Metodo para llenar el diccionario según las claves establecidas por consigna
            static Dictionary<Char, int> LlenarDiccionario(Dictionary<Char, int> diccionario)
            {
                diccionario.Add('H', 1234);
                diccionario.Add('o', 1233);
                diccionario.Add('l', 1245);
                diccionario.Add('a', 1355);
                diccionario.Add(' ', 5566);
                diccionario.Add('s', 1324);
                diccionario.Add('y', 3245);
                diccionario.Add('p', 5556);
                diccionario.Add('r', 1534);              
                diccionario.Add('m', 1866);
                diccionario.Add('g', 1777);
                diccionario.Add('d', 1111);

                return diccionario;
            }


            //Metodo para cortar una cadena y devolver una lista con los recortes, en función de un "corte" numérico
           // pasado por parámetros
            static ArrayList cortarCadena (String cadena, int CORTE)
            {
                int i = 0;

                ArrayList recorte = new ArrayList();

                while (i < cadena.Length) { 
                recorte.Add(cadena.Substring(i, CORTE));
                i += CORTE;
                }


                return recorte;

            }

            //Método de cifrado, utiliza el ArrayList de recortes y el diccionario para asignarle un valor en función
           // de una clave
            static string cifrar(ArrayList recorte, Dictionary<char, int> diccionario)
            {
                int i = 0;
                string cadenaCifrada ="";
                
                while (i<recorte.Count) {

                    string pieza = (string)recorte[i];

                    foreach (char c in pieza)
                    {
                        cadenaCifrada += (diccionario[c].ToString());
                    }

                    i++;
                }
                return cadenaCifrada;

            }

            //Método de descifrado de una cadena
            static string descifrar (string cifrado, Dictionary<char,int> diccionario, int SERIAL_CORTE)
            {
                ArrayList recorte = new ArrayList();
                recorte = cortarCadena(cifrado, SERIAL_CORTE);
                int i = 0;
                int serialNumber;
                string descifrado = "";

                while (i<recorte.Count) { 

                serialNumber = Int32.Parse((string)recorte[i]);
               
                descifrado += diccionario.FirstOrDefault(x => x.Value == serialNumber).Key;

                i++;
                }

                return descifrado;
            }
        }
    }
}
