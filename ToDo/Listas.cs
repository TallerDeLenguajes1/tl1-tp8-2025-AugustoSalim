namespace Lista
{
    // Clase que representa una tarea
    public class Tarea
    {
        public int TareaID { get; set; }
        public string Descripcion { get; set; }
        public int Duracion { get; set; }

        public Tarea(int id, string descripcion, int duracion)
        {
            TareaID = id;
            Descripcion = descripcion;
            Duracion = duracion;
        }
    }

    // Clase que contiene todos los métodos para manejar las tareas
    public class GestorDeTareas
    {
        // Función para mostrar los detalles de una tarea
        public static void MostrarTarea(Tarea tarea)
        {
            Console.WriteLine("---------------");
            Console.WriteLine($"Tarea Numero: {tarea.TareaID}.");
            Console.WriteLine($"Duración: {tarea.Duracion} horas.");
            Console.WriteLine($"Descripción: {tarea.Descripcion}.");
            Console.WriteLine("---------------");
        }

        // Función para mostrar la lista de tareas pendientes y realizadas
        public static void MostrarLista(List<Tarea> pendientes, List<Tarea> realizadas)
        {
            Console.WriteLine("\n---------------TAREAS PENDIENTES---------------\n");
            foreach (Tarea tarea in pendientes)
            {
                MostrarTarea(tarea); // Mostrar cada tarea en pendientes
            }

            Console.WriteLine("\n---------------TAREAS COMPLETADAS---------------\n");
            foreach (Tarea tarea in realizadas)
            {
                MostrarTarea(tarea); // Mostrar cada tarea en realizadas
            }
        }

        // Función para mover tareas de pendientes a realizadas
        public static void OrdenarTareas(List<Tarea> pendientes, List<Tarea> realizadas)
        {
            int indice, end = 1;
            do
            {
                //no me gusta el usar el convert, no entiendo bien para que es, prefiero tryparse
                MostrarLista(pendientes, realizadas);
                Console.WriteLine("Ingrese el índice de la tarea que desea marcar como realizada: ");
                indice = Convert.ToInt32(Console.ReadLine()) - 1;

                if (indice >= 0 && indice < pendientes.Count)
                {
                    realizadas.Add(pendientes[indice]);
                    pendientes.RemoveAt(indice);
                }
                else
                {
                    Console.WriteLine("Índice inválido.");
                }

                Console.WriteLine("¿Quiere seguir ordenando las tareas? [0]: NO - [1]: SI");
                end = Convert.ToInt32(Console.ReadLine());
            } while (end == 1);
        }

        // Función para buscar tareas por descripción
        public static void BuscarTarea(List<Tarea> pendientes, List<Tarea> realizadas)
        {
            string palabra;
            Console.WriteLine("Ingrese la palabra para buscar: ");
            palabra = Console.ReadLine();

            //quiero cambiar la forma en la que se buscan las tareas. Prefiero comparar el tema de las mayusculas tambien y si se llega a encontrar parte de la cadena en lo que estoy buscando
            bool encontrado = false;
            foreach (Tarea tarea in pendientes)
            {
                if (tarea.Descripcion.Contains(palabra))
                {
                    Console.WriteLine("Tarea encontrada en PENDIENTES");
                    MostrarTarea(tarea);
                    encontrado = true;
                }
            }

            foreach (Tarea tarea in realizadas)
            {
                if (tarea.Descripcion.Contains(palabra))
                {
                    Console.WriteLine("Tarea encontrada en REALIZADAS");
                    MostrarTarea(tarea);
                    encontrado = true;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("No se encontró ninguna tarea con esa descripción.");
            }
        }

        // Función para contar las horas trabajadas
        public static void ContarHoras(List<Tarea> realizadas)
        {
            int horasTrabajadas = 0;
            foreach (Tarea tarea in realizadas)
            {
                horasTrabajadas += tarea.Duracion;
            }
            Console.WriteLine($"El trabajador completó {horasTrabajadas} horas de trabajo.");
        }

        // Función para mostrar el menú
        public static void MostrarMenu()
        {
            Console.WriteLine("1. Ver tareas pendientes y realizadas");
            Console.WriteLine("2. Mover tarea de pendiente a realizada");
            Console.WriteLine("3. Buscar tarea por descripción");
            Console.WriteLine("4. Contar horas de trabajo realizadas");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
        }
    }
}
