using Lista; // Usamos el espacio de nombres del archivo listas.cs

class Program
{
    static void Main(string[] args)
    {
        // Creamos las listas de tareas pendientes y realizadas
        List<Tarea> tareasPendientes = new List<Tarea>();
        List<Tarea> tareasRealizadas = new List<Tarea>();

        // Precargamos 5 tareas con datos de ejemplo
        tareasPendientes.Add(new Tarea(1, "Revisar inventario", 15));
        tareasPendientes.Add(new Tarea(2, "Limpieza de oficina", 20));
        tareasPendientes.Add(new Tarea(3, "Entrega de pedidos", 30));
        tareasPendientes.Add(new Tarea(4, "Reunión con cliente", 25));
        tareasPendientes.Add(new Tarea(5, "Organizar documentos", 10));

        int opcion;
        bool continuar = true;

        while (continuar)
        {
            // Mostrar el menú y leer la opción del usuario
            GestorDeTareas.MostrarMenu();
            string entrada = Console.ReadLine();

            // Validamos la entrada con TryParse
            bool valido = int.TryParse(entrada, out opcion);

            if (!valido)
            {
                Console.WriteLine("Entrada inválida. Ingrese un número del 1 al 5.");
                continue;
            }

            // Ejecutamos la opción seleccionada
            switch (opcion)
            {
                case 1:
                    GestorDeTareas.MostrarLista(tareasPendientes, tareasRealizadas);
                    break;
                case 2:
                    GestorDeTareas.OrdenarTareas(tareasPendientes, tareasRealizadas);
                    break;
                case 3:
                    GestorDeTareas.BuscarTarea(tareasPendientes, tareasRealizadas);
                    break;
                case 4:
                    GestorDeTareas.ContarHoras(tareasRealizadas);
                    break;
                case 5:
                    continuar = false;
                    Console.WriteLine("Gracias por usar el gestor de tareas.");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                    break;
            }
        }
    }
}

// // Declaramos un contador de ID para asignar automáticamente
// int proximoID = 6; // Empieza en 6 porque ya cargamos 5 tareas

// string descripcion;
// int duracion;
// string entrada;

// // Preguntamos cuántas tareas quiere cargar el usuario
// Console.WriteLine("¿Cuántas tareas nuevas desea cargar?");
// entrada = Console.ReadLine();
// int cantidad;
// if (int.TryParse(entrada, out cantidad))
// {
//     for (int i = 0; i < cantidad; i++)
//     {
//         Console.WriteLine($"\nTarea #{proximoID}");

//         // Pedimos la descripción
//         Console.Write("Descripción: ");
//         descripcion = Console.ReadLine();

//         // Pedimos duración y validamos que sea un número entre 10 y 100
//         do
//         {
//             Console.Write("Duración (entre 10 y 100): ");
//             entrada = Console.ReadLine();
//         } while (!int.TryParse(entrada, out duracion) || duracion < 10 || duracion > 100);

//         // Agregamos la nueva tarea a la lista de pendientes
//         tareasPendientes.Add(new Tarea(proximoID, descripcion, duracion));

//         // Aumentamos el ID para la próxima tarea
//         proximoID++;
//     }
// }
// else
// {
//     Console.WriteLine("Número inválido.");
// }

