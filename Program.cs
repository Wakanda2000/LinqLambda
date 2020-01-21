using System;
using System.Collections.Generic;
using System.Linq;

using TA_LinqLambda2.Clases;

namespace TA_LinqLambda2
{
    public class Program
    {
        public static void Main(string[] args)
        {

            List<Cliente> clientes = new List<Cliente>()
            {
                new Cliente(){Nombre = "Dustin", IdCliente = 1234},
                new Cliente(){Nombre = "Andric", IdCliente = 1567},
                new Cliente(){Nombre = "William", IdCliente = 1890},
                new Cliente(){Nombre = "Andres", IdCliente = 1246},
                new Cliente(){Nombre = "Michael", IdCliente = 1810},
                new Cliente(){Nombre = "Joel", IdCliente = 1357},
                new Cliente(){Nombre = "Ider", IdCliente = 1911},
                new Cliente(){Nombre = "Leonardo", IdCliente = 1369},
                new Cliente(){Nombre = "Sanler", IdCliente = 1480},
                new Cliente(){Nombre = "Josue", IdCliente = 1510}
            };

            List<Factura> facturas = new List<Factura>()
            {
                new Factura(){ Obeservacion= "Plato", IdCliente = 1234, Fecha = new DateTime(2020, 12, 31), Total = 10000},
                new Factura(){ Obeservacion= "Vaso", IdCliente = 1567, Fecha = new DateTime(2020, 01, 01), Total = 15000},
                new Factura(){ Obeservacion= "Vaso", IdCliente = 1890, Fecha = new DateTime(2019, 12, 31), Total = 20000},
                new Factura(){ Obeservacion= "Plato", IdCliente = 1246, Fecha = new DateTime(2019, 01, 31), Total = 25000},
                new Factura(){ Obeservacion= "Plato", IdCliente = 1810, Fecha = new DateTime(2000, 04, 23), Total = 30000},
                new Factura(){ Obeservacion= "Cuchara", IdCliente = 1357, Fecha = new DateTime(2018, 12, 31), Total = 35000},
                new Factura(){ Obeservacion= "Cuchara", IdCliente = 1911, Fecha = new DateTime(2018, 01, 31), Total = 40000},
                new Factura(){ Obeservacion= "Cuchara", IdCliente = 1369, Fecha = new DateTime(2016, 09, 06), Total = 45000},
                new Factura(){ Obeservacion= "Vaso", IdCliente = 1480, Fecha = new DateTime(2016, 08, 10), Total = 50000},
                new Factura(){ Obeservacion= "Vaso", IdCliente = 1510, Fecha = new DateTime(2016, 02, 11), Total = 55000}
            };

            #region EJERCICIO 1. CLIENTES CON MAYOR NUMEROS DE VENTAS
            // EJERCICO 1 - CLIENTES CON MAYOR NUMEROS DE VENTAS

            Console.WriteLine("\n\t3 CLIENTES CON MAYOR NUMEROS DE VENTAS\n");

            var consultita =
                from cliente in clientes
                join factura in facturas on
                cliente.IdCliente equals factura.IdCliente
                orderby factura.Total descending
                select new
                {
                    totalsito = factura.Total,
                    nombre = cliente.Nombre
                };

            int ventaMayor = 4,  cont = 0;
            foreach (var item in consultita)
            {
                cont++;
                if (cont < ventaMayor)
                {
                    Console.WriteLine("\tNombre del cliente: " + item.nombre + "\tTotal de Ventas: " + item.totalsito);
                }
            }

            Console.ReadKey();
            Console.Clear();

            #endregion

            #region EJERCICIO 2. CLIENTES CON MENOR NUMEROS DE VENTAS

            // EJERCICO 2 - CLIENTES CON MENOR NUMEROS DE VENTAS

            Console.WriteLine("\n\t3 CLIENTES CON MENOR NUMEROS DE VENTAS\n");
            
            var consultita2 =
               from cliente in clientes
               join factura in facturas on
               cliente.IdCliente equals factura.IdCliente
               orderby factura.Total ascending
               select new
               {
                   totalsito = factura.Total,
                   nombre = cliente.Nombre
               };

            int ventaMayor2 = 4, cont2 = 0;
            foreach (var item in consultita2)
            {
                cont2++;
                if (cont2 < ventaMayor2)
                {
                    Console.WriteLine("\tNombre del cliente: " + item.nombre + "\tTotal de Ventas: " + item.totalsito);
                }
            }

            Console.ReadKey();
            Console.Clear();

            #endregion

            #region EJERCICIO 3. CLIENTE CON MAS VENTAS REALIZADAS
            //EJERCICO 3 - CLIENTE CON MAS VENTAS REALIZADAS

            Console.WriteLine("\n\tCLIENTE CON MAS VENTAS REALIZADAS\n");
            var consultita3 =
                from cliente in clientes
                join factura in facturas on
                cliente.IdCliente equals factura.IdCliente
                orderby factura.Total descending
                select new
                {
                    totalsito = factura.Total,
                    nombre = cliente.Nombre
                };

            int ventaMayor3 = 2, cont3 = 0;
            foreach (var item in consultita3)
            {
                cont3++;
                if (cont3 < ventaMayor3)
                {
                    Console.WriteLine("\tNombre del cliente: " + item.nombre + "\tTotal de Ventas: " + item.totalsito);
                }
            }

            Console.ReadKey(); Console.Clear();

            #endregion

            #region EJERCICIO 4. MUESTRA EL NOMBRE DEL CLIENTE CON SU TOTAL DE VENTAS - TERMINADO
            // EJERCICIO 4 - MUESTRA EL NOMBRE DEL CLIENTE CON SU TOTAL DE VENTAS

            var consultita4 =
                from cliente in clientes
                join factura in facturas on
                cliente.IdCliente equals factura.IdCliente
                select new
                {
                    ventas = factura.Total,
                    nombre = cliente.Nombre
                };

            Console.WriteLine("\n\tMUESTRA EL NOMBRE DEL CLIENTE CON SU TOTAL DE VENTAS\n");

            foreach (var item in consultita4)
            {
                Console.WriteLine("\tNombre del Cliente: " + item.nombre + "\tVenta Realizada: $" + item.ventas);
            }

            Console.ReadKey(); Console.Clear();
            #endregion

            #region EJERCICIO 5. VENTAS REALIZADAS EN EL 2019 - TERMINADA   

            //EJERCICIO 5 - VENTAS REALIZADAS EN EL 2019
       
            var consultita5 =
                facturas.Where(f => f.Fecha.Year == 2019).
                Select(f1 => new { total = f1.Total, fecha = f1.Fecha});

            Console.WriteLine("\n\tVENTAS REALIZADAS EN EL 2019\n");

            foreach (var item in consultita5)
            {
                Console.WriteLine("\tFecha: " + item.fecha + "\tcantidad de venta $:" + item.total);
            }
            Console.ReadKey(); Console.Clear();

            #endregion

            #region EJERCICIO 6. MUESTRA LA VENTA MAS ANTIGUA -TERMINADO

            //EJERCICIO 6 - MUESTRA LA VENTA MAS ANTIGUA

            var consultita6 =
                facturas.Where(f => f.Fecha.Year < 2001);
            Console.WriteLine("\n\tMUESTRA LA VENTA MAS ANTIGUA\n");

            foreach (var item in consultita6)
            {
                Console.WriteLine("\tLa venta mas antigua es de la fecha: " + item.Fecha + "\tpor concepto de: " + item.Obeservacion);
            }
            Console.ReadKey(); Console.Clear();


            #endregion

            #region EJERCICIO 7. MUESTRA LOS CLIENTES QUE TENGAN VENTA CON PLATOS TERMINADO

            // EJERCICIO 7 - MUESTRA LOS CLIENTES QUE TENGAN VENTA CON PLATOS


            Console.WriteLine("\n\tMUESTRA LOS CLIENTES QUE TENGAN VENTA CON PLATOS\n");

            var consultita7 =
                from cliente in clientes
                join factura in facturas on
                cliente.IdCliente equals factura.IdCliente
                select new
                {
                    observacion = factura.Obeservacion == "Plato",
                    nombre = cliente.Nombre
                };

            foreach (var item in consultita7)
            {
                Console.WriteLine("\tClientes con Observaciones de Platos: " + item.nombre +"\t"+ item.observacion);
            }
            Console.ReadKey();

            #endregion
            
        }
    }
}
