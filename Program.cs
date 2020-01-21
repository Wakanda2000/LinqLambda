using System;
using System.Collections.Generic;
using System.Linq;

namespace TA_LinqLambda
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //  *****   NUMEROS RANDOM  *****
            List<int> numeros = new List<int>();
            Random random = new Random();

            while (numeros.Count < 50)
            {
                {
                    int num = random.Next(1, 100);
                    numeros.Add(num);
                }
            }

            //  *****   FIN DE NUMEROS RANDOM   *****

            #region EJERCICIO 1. NUMEROS PRIMOS 
            var consulta =
                from numero in numeros
                where esPrimo(numero)
                select numero;
            Console.WriteLine("Numeros primos");

            foreach (var item in consulta)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey(); Console.Clear();
            #endregion  

            #region EJERCICIO 2. SUMA DE NUMEROS RANDOM - TERMINADO

            // EJERCICIO 2 - LA SUMA DE LOS NUMEROS RANDOM
            var suma = numeros.Sum();

            foreach (var item in numeros)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("La suma de los numeros es: " + suma);

            Console.ReadKey(); Console.Clear();

            #endregion

            #region EJERCICIO 3. EL CUADRADO DE LOS NUMEROS - TERMINADO

            // EJERCICIO 3 - EL CUADRADO DE LOS NUMEROS

            var consulta3 =
                (from numero in numeros
                 select new
                 {
                     numerocuadrado = numero * numero,
                     numero = numero
                 });
            Console.WriteLine("CUADRADO DE LOS NUMEROS");
            foreach (var item in consulta3)
            {
                Console.WriteLine("El cuadrado de: " + item.numero + " es igual a: " + item.numerocuadrado);
            }
            Console.ReadKey(); Console.Clear();

            #endregion

            #region EJERCICIO 4. NUMEROS NO PRIMOS
            var consulta4 =
                from numero in numeros
                where noEsPrimo(numero)
                select numero;
            Console.WriteLine("Numeros que no son primos");
            foreach (var item in consulta4)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey(); Console.Clear();
            #endregion 

            #region EJERCICIO 5. PROMEDIO DE LOS NUMEROS RAMDON MAYORES A 50 - TERMINADO
            // EJERCICIO 5 - MUESTRA EL PROMEDIO DE LOS NUMEROS RANDOM MAYORES A 50

            IEnumerable<int> resultado5 =
                from numero in numeros
                where numero > 50
                select numero;

            foreach (var item in resultado5)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("El promedio de los numeros random mayores de 50 es: " + resultado5.Average());

            Console.ReadKey(); Console.Clear();

            #endregion

            #region EJERICIO 6. NUMEROS PARES E IMPARES
            
            Console.WriteLine("\n\tNUMEROS PARES E IMPARES\n Serie Random");

            var consulta6A =
                from numero1 in numeros
                where numero1 % 2 == 0
                select numero1;
            var consulta6B =
                from numero2 in numeros
                where numero2 % 2 != 0
                select numero2;

            foreach (var item in numeros)
            {
                Console.WriteLine("\t" + item);
            }

            Console.WriteLine("Numero Pares: " + consulta6A.Count());
            Console.WriteLine("Numeros Impares: " + consulta6B.Count());

            Console.ReadKey();  Console.Clear();
            #endregion

            #region EJERCICIO 7. NUMEROS Y LAS VECES QUE SE REPITEN
            var consulta7 =
                from numero in numeros
                where numeros.Count() != numero
                select numero;

            foreach (var item in consulta7)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();  Console.Clear();

            #endregion

            #region EJERCICIO 8. ELEMENTOS DE FORMA DESCENDIENTE - TERMINADO

            // EJERCICIO 8 - ELEMENTOS DE FORMA DESECNDIENTE

            IEnumerable<int> resultado8 =
                    from numero in numeros
                    orderby numero descending
                    select numero;
            Console.WriteLine("Numeros de Mayor a Menor");

            foreach (var item in resultado8)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey(); Console.Clear();

            #endregion

            #region EJERCICIO 9. ELEMENTOS QUE NO SE REPITEN - TERMINADO

            var consulta9 =
               from numero in numeros
               group numero by numero into g
               where g.Count() == 1
               select g.Key;

            Console.WriteLine("\n\tNUMEROS RANDOM\n");

            foreach (var item in numeros)
            {
                Console.WriteLine("{0}", item);
            }

            Console.Read();
            Console.WriteLine("\tNUMEROS RANDOM UNICOS\n");
            foreach (var item in consulta9)
            {
                Console.WriteLine(item);
            }
            
            Console.ReadKey(); Console.Clear();

            #endregion

            #region EJERCICIO 10. SUMA DE LOS ELEMNTOS QUE NO SE REPITEN - TERMINADO

            var sumita = consulta9.Sum();
            Console.WriteLine("LA SUMA DE NUMEROS UNICOS ES: " + sumita);

            Console.ReadKey();

            #endregion
        }

        private static bool esPrimo(int numero1)
        {
            if (numero1 < 2) return false;
            if (numero1 == 2) return true;
            if (numero1 % 2 == 0) return false;
            for (int i = 3; i * i <= numero1; i += 2)
                if (numero1 % i == 0) return false;
            return true;
        }

        private static bool noEsPrimo(int numero2)
        {
            if (numero2 < 2) return false;
            if (numero2 == 2) return false;
            if (numero2 == 3) return false;
            if (numero2 == 5) return false;
            if (numero2 == 7) return false;
            if (numero2 == 11) return false;
            if (numero2 % 2 == 0) return true;
            if (numero2 % 3 == 0) return true;
            if (numero2 % 5 == 0) return true;
            if (numero2 % 7 == 0) return true;
            if (numero2 % 11 == 0) return true;
            for (int i = 3; i * i <= numero2; i += 2)
                if (numero2 % i == 0) return true;
            return false;
        }
    }
}
