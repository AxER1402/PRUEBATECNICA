using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

//Crear la lista 
public class GestorDeContactos
{
    private List<Contacto> contactos;
    private string filePath = "contactos.txt";

    public GestorDeContactos()
    {
        contactos = new List<Contacto>();
        CargarContactos();
    }
    //Agregar
    public int AgregarContacto(Contacto contacto)
    {
        contacto.Id = contactos.Count > 0 ? contactos[contactos.Count - 1].Id + 1 : 1;
        contactos.Add(contacto);
        GuardarContactos();
        return contacto.Id;
    }

    //Buscar
    public List<Contacto> BuscarContactos(string criterio)
    {
        return contactos.FindAll(c => c.Nombre.IndexOf(criterio, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                      c.Telefono.IndexOf(criterio, StringComparison.OrdinalIgnoreCase) >= 0);
    }


    public List<Contacto> ListarContactos()
    {
        return new List<Contacto>(contactos);
    }
    //Eliminar
    public void EliminarContacto(int id)
    {
        contactos.RemoveAll(c => c.Id == id);
        GuardarContactos();
    }
    //Guardar
    private void GuardarContactos()
    {
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            foreach (var contacto in contactos)
            {
                sw.WriteLine($"{contacto.Id},{contacto.Nombre},{contacto.Telefono},{contacto.Email}");
            }
        }
    }
    //Subida
    private void CargarContactos()
    {
        if (File.Exists(filePath))
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 4)
                    {
                        Contacto contacto = new Contacto
                        {
                            Id = int.Parse(parts[0]),
                            Nombre = parts[1],
                            Telefono = parts[2],
                            Email = parts[3]
                        };
                        contactos.Add(contacto);
                    }
                }
            }
        }
    }
}
