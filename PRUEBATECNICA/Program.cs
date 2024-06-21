using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    //}Diseño de la interfaz
    static void Main(string[] args)
    {
        GestorDeContactos gestor = new GestorDeContactos();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("1. Agregar nuevo contacto");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("2. Buscar contactos");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");

            Console.WriteLine("3. Mostrar todos los contactos");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");

            Console.WriteLine("4. Eliminar contactos");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");

            Console.WriteLine("5. Salir ");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");

            Console.Write("Ingrese un número para elegir la opción: ");
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");

            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    AgregarNuevoContacto(gestor);
                    break;
                case 2:
                    BuscarContactos(gestor);
                    break;
                case 3:
                    ListarContactos(gestor);
                    break;
                case 4:
                    EliminarContacto(gestor);
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    //Validación para agregar
    private static void AgregarNuevoContacto(GestorDeContactos gestor)
    {
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
        Console.Write("Teléfono: ");
        string telefono = Console.ReadLine();
        Console.WriteLine("--------------------------------------------------------------------------------------------------------------");

        Console.Write("Email: ");
        string email = Console.ReadLine();
        Console.WriteLine("--------------------------------------------------------------------------------------------------------------");

        Contacto contacto = new Contacto { Nombre = nombre, Telefono = telefono, Email = email };
        int id = gestor.AgregarContacto(contacto);
        Console.WriteLine($"Contacto agregado con el ID = {id}. Presione cualquier tecla para regresar al menú...");
        Console.ReadKey();
    }


    //Validación para Buscar
    private static void BuscarContactos(GestorDeContactos gestor)
    {
        Console.Write("Ingrese el nombre o teléfono para buscar: ");
        string criterio = Console.ReadLine();
        var resultados = gestor.BuscarContactos(criterio);

        if (resultados.Count > 0)
        {
            Console.WriteLine("Contactos encontrados:");
            foreach (var contacto in resultados)
            {
                Console.WriteLine(contacto);
            }
        }
        else
        {
            Console.WriteLine("No se encontraron contactos.");
        }

        Console.WriteLine("Presione cualquier tecla para volver al menu...");
        Console.ReadKey();
    }
    //Validación para mostrar todo
    private static void ListarContactos(GestorDeContactos gestor)
    {
        var contactos = gestor.ListarContactos();

        if (contactos.Count > 0)
        {
            Console.WriteLine("Lista de contactos:");
            foreach (var contacto in contactos)
            {
                Console.WriteLine(contacto);
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------");


            }
        }
        else
        {
            Console.WriteLine("No hay contactos en la lista.");
        }

        Console.WriteLine("Presione cualquier tecla para regresar al menu...");
        Console.ReadKey();
    }
    //Validación para eliminar
    private static void EliminarContacto(GestorDeContactos gestor)
    {
        Console.Write("Ingrese el ID del contacto a eliminar: ");
        int id = int.Parse(Console.ReadLine());

        gestor.EliminarContacto(id);
        Console.WriteLine("Contacto eliminado. Presione cualquier tecla para regresar al menu...");
        Console.ReadKey();
    }
}
