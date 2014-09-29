using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Logic;
using Business.Entities;

namespace UI.Consola
{
    public class Usuarios
    {
        //private Business.Logic.UsuarioLogic _usuarioLogic;

        //public Business.Logic.UsuarioLogic UsuarioLogic
        //{
        //    get { return _usuarioLogic; }
        //    set { _usuarioLogic = value; }
        //}

        //public Usuarios()
        //{
        //    this._usuarioLogic = new UsuarioLogic();
        //}

        //private void ListadoGeneral()
        //{
        //    Console.Clear();
        //    try{	        
        //        foreach (Business.Entities.Usuario usr in this._usuarioLogic.GetAll())
        //        {
        //            this.MostrarDatos(usr);
        //        }
        //    }
        //    catch (NullReferenceException){
        //        Console.Write("No hay Usuarios para listar.");
        //    } 
        //    finally
        //    {
        //        Console.Write("Presione una tecla para continuar.");
        //        Console.ReadKey();
        //    }
        //}

        //private void Consultar()
        //{
        //    Console.Clear();

        //    int id = 0;
        //    try
        //    {

        //        while (id == 0)
        //        {
        //            try
        //            {
        //                Console.Write("Ingrese el Id del Usuario a consultar: ");
        //                id = int.Parse(Console.ReadLine());
        //            }
        //            catch (FormatException)
        //            {
        //                Console.Clear();
        //                Console.WriteLine("La ID ingresada debe ser un número entero.\n");
        //            }
        //        }

        //        this.MostrarDatos(this._usuarioLogic.GetOne(id));
        //    }
        //    catch (NullReferenceException)
        //    {// No se encontro ningun Usuario con el Id.
        //        Console.Clear();
        //        Console.WriteLine("No se encontro un Usuario con ese ID: {0}.", id);
        //    }
        //    catch (Exception) {
        //        Console.WriteLine("Excepcion no identificada en Consultar()");
        //    }
        //    finally
        //    {
        //        Console.Write("Presione una tecla para continuar.");
        //        Console.ReadKey();
        //    }

        //}

        //private void Agregar()
        //{
        //    Console.Clear();
        //    Business.Entities.Usuario usr = new Usuario();

        //    Console.WriteLine("Ingrese Nombre: ");
        //    usr.Nombre = Console.ReadLine();
        //    Console.WriteLine("Ingrese Apellido: ");
        //    usr.Apellido = Console.ReadLine();
        //    Console.WriteLine("Ingrese Nombre de Usuario");
        //    usr.NombreUsuario = Console.ReadLine();
        //    Console.WriteLine("Ingrese Email:");
        //    usr.Email = Console.ReadLine();
        //    Console.WriteLine("Ingrese Clave");
        //    usr.Clave = Console.ReadLine();
        //    Console.WriteLine("Ingrese Habilitacion de Usuario (1-Si/otro-No):");
        //    usr.Habilitado = (Console.ReadLine() == "1");
        //    usr.State = Usuario.States.New;

        //    this._usuarioLogic.Save(usr);
        //    Console.WriteLine("\nId: {0}",usr.Id);
        //    Console.Write("\nPresione una tecla para continuar.");
        //    Console.ReadKey();


        //}

        //private void Modificar()
        //{
        //    Console.Clear();

        //    int id = 0;
        //    try
        //    {

        //        while (id == 0)
        //        {
        //            try
        //            {
        //                Console.Write("Ingrese el Id del Usuario a modificar: ");
        //                id = int.Parse(Console.ReadLine());
        //            }
        //            catch (FormatException)
        //            {
        //                Console.Clear();
        //                Console.WriteLine("La ID ingresada debe ser un número entero.\n");
        //            }
        //        }

        //        Business.Entities.Usuario usr = this._usuarioLogic.GetOne(id);
        //        Console.WriteLine("Ingrese Nuevo Nombre: ");
        //        usr.Nombre = Console.ReadLine();
        //        Console.WriteLine("Ingrese Nuevo Apellido: ");
        //        usr.Apellido = Console.ReadLine();
        //        Console.WriteLine("Ingrese Nuevo Nombre de Usuario");
        //        usr.NombreUsuario = Console.ReadLine();
        //        Console.WriteLine("Ingrese Nuevo Email:");
        //        usr.Email = Console.ReadLine();
        //        Console.WriteLine("Ingrese Nueva Clave");
        //        usr.Clave = Console.ReadLine();
        //        Console.WriteLine("Ingrese Habilitacion de Usuario (1-Si/otro-No):");
        //        usr.Habilitado = (Console.ReadLine() == "1");
        //        usr.State = Usuario.States.Modified;

        //        this._usuarioLogic.Save(usr);
        //    }
        //    catch (NullReferenceException)
        //    {// No se encontro ningun Usuario con el Id.
        //        Console.Clear();
        //        Console.WriteLine("No se encontro un Usuario con ese ID: {0}.", id);
        //    }
        //    catch (Exception)
        //    {
        //        Console.WriteLine("Excepcion no identificada en Consultar()");
        //    }
        //    finally
        //    {
        //        Console.Write("Presione una tecla para continuar.");
        //        Console.ReadKey();
        //    }
        //}

        //private void Eliminar()
        //{
        //    Console.Clear();

        //    int id = 0;
        //    try
        //    {

        //        while (id == 0)
        //        {
        //            try
        //            {
        //                Console.Write("Ingrese el Id del Usuario a Eliminar: ");
        //                id = int.Parse(Console.ReadLine());
        //            }
        //            catch (FormatException)
        //            {
        //                Console.Clear();
        //                Console.WriteLine("La ID ingresada debe ser un número entero.\n");
        //            }
        //        }

        //        this._usuarioLogic.Delete(id);
        //        Console.WriteLine("\nEl usuario ha sido eliminado.");

        //    }
        //    catch (NullReferenceException)
        //    {// No se encontro ningun Usuario con el Id.
        //        Console.Clear();
        //        Console.WriteLine("No se encontro un Usuario con ese ID: {0}.", id);
        //    }
        //    catch (Exception)
        //    {
        //        Console.WriteLine("Excepcion no identificada en Consultar()");
        //    }
        //    finally
        //    {
        //        Console.Write("Presione una tecla para continuar.");
        //        Console.ReadKey();
        //    }

        //}

        //private void MostrarDatos(Business.Entities.Usuario usr)
        //{
        //    Console.WriteLine("Usuario: {0}", usr.Id);
        //    Console.WriteLine("\t\tApellido: {0}", usr.Apellido);
        //    Console.WriteLine("\t\tNombre: {0}", usr.Nombre);
        //    Console.WriteLine("\t\tNombre Usuario: {0}", usr.NombreUsuario);
        //    Console.WriteLine("\t\tEmail: {0}", usr.Email);
        //    Console.WriteLine("\t\tClave: {0}", usr.Clave);
        //    Console.WriteLine("\t\tHabilitado: {0}", usr.Habilitado);
        //    Console.WriteLine();
        //}

        //public void Menu()
        //{
        //    Console.Clear();
        //    int opc = 0;
        //    while (true)
        //    {
        //        try
        //        {
        //            Console.Write("Menu de Opciones:\n1– Listado General\n2– Consulta\n3– Agregar\n4- Modificar\n5- Eliminar\n6- Salir\n\nIngrese su opcion: ");
        //            opc = int.Parse(Console.ReadLine());
        //            switch (opc)
        //            {
        //                case 1://Opcion Listado 
        //                    this.ListadoGeneral();
        //                    break;
        //                case 2://Opcion Consulta
        //                    this.Consultar();
        //                    break;
        //                case 3://Opcion Agregar
        //                    this.Agregar();
        //                    break;
        //                case 4://Opcion Modificar
        //                    this.Modificar();
        //                    break;
        //                case 5://Opcion Eliminar
        //                    this.Eliminar();
        //                    break;
        //                case 6://Opcion Salir
        //                    return;
        //                default:
        //                    Console.Clear();
        //                    Console.WriteLine("Por favor ingrese una opcion Valida.\n");
        //                    opc = 0;
        //                    break;
        //            }
        //        }
        //        catch (FormatException)
        //        {
        //            //Excepcion de format Exception.
        //            Console.Clear();
        //            Console.WriteLine("Por favor ingrese una opcion Valida.\n");
        //        }
        //        catch(Exception e){
        //            Console.Clear();
        //            Console.WriteLine("Excepcion desconocida.\n " + e.Message);
        //        }
        //    }

        //}



    }
}