namespace Lista
{
    // Clase que representa una tarea
    public class Tarea
    {
        // Propiedades públicas de la tarea
        public int TareaID { get; set; }         // ID único de la tarea
        public string Descripcion { get; set; }  // Descripción textual de la tarea
        public int Duracion { get; set; }        // Duración en horas (entre 10 y 100)

        // Constructor para crear una nueva tarea con ID, descripción y duración
        public Tarea(int id, string descripcion, int duracion)
        {
            TareaID = id;
            Descripcion = descripcion;
            Duracion = duracion;
        }
    }

    // Clase que contiene todas las funciones para gestionar las tareas
    public class GestorDeTareas
    {
        // Función para mostrar en pantalla una sola tarea
        public static void MostrarTarea(Tarea tarea)
        {
            Console.WriteLine("---------------");
            Console.WriteLine($"Tarea Numero: {tarea.TareaID}.");
            Console.WriteLine($"Duración: {tarea.Duracion} horas.");
            Console.WriteLine($"Descripción: {tarea.Descripcion}.");
            Console.WriteLine("---------------");
        }

        // Función para mostrar ambas listas: pendientes y realizadas
        public static void MostrarLista(List<Tarea> pendientes, List<Tarea> realizadas)
        {
            Console.WriteLine("\n---------------TAREAS PENDIENTES---------------\n");
            foreach (Tarea tarea in pendientes)
            {
                MostrarTarea(tarea);
            }

            Console.WriteLine("\n---------------TAREAS COMPLETADAS---------------\n");
            foreach (Tarea tarea in realizadas)
            {
                MostrarTarea(tarea);
            }
        }

        // Función para mover tareas de pendientes a realizadas
        public static void OrdenarTareas(List<Tarea> pendientes, List<Tarea> realizadas)
        {
            int indice;
            string input;
            bool seguir = true;

            while (seguir)
            {
                // Mostrar el listado actual de tareas
                MostrarLista(pendientes, realizadas);

                Console.WriteLine("Ingrese el índice de la tarea que desea marcar como realizada: ");
                input = Console.ReadLine();
                bool esNumero = int.TryParse(input, out indice);

                if (esNumero && indice > 0 && indice <= pendientes.Count)
                {
                    // Se pasa de 1-index a 0-index restando 1
                    realizadas.Add(pendientes[indice - 1]);
                    pendientes.RemoveAt(indice - 1);
                }
                else
                {
                    Console.WriteLine("Índice inválido.");
                }

                Console.WriteLine("¿Quiere seguir ordenando las tareas? [0]: NO - [1]: SI");
                seguir = Console.ReadLine() == "1";
            }
        }

        // Función para buscar tareas por descripción ignorando mayúsculas/minúsculas
        public static void BuscarTarea(List<Tarea> pendientes, List<Tarea> realizadas)
        {
            Console.WriteLine("Ingrese palabra o frase a buscar en la descripción:");
            string palabra = Console.ReadLine();

            // Convertimos a minúscula para comparar sin distinguir mayúsculas
            string palabraBuscada = palabra.ToLower();
            bool encontrado = false;

            // Buscar en tareas pendientes
            foreach (Tarea tarea in pendientes)
            {
                if (tarea.Descripcion.ToLower().Contains(palabraBuscada))
                {
                    Console.WriteLine("Tarea encontrada en PENDIENTES");
                    MostrarTarea(tarea);
                    encontrado = true;
                }
            }

            // Buscar en tareas realizadas
            foreach (Tarea tarea in realizadas)
            {
                if (tarea.Descripcion.ToLower().Contains(palabraBuscada))
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

        // Función para contar el total de horas trabajadas (solo en tareas realizadas)
        public static void ContarHoras(List<Tarea> realizadas)
        {
            int horasTrabajadas = 0;

            foreach (Tarea tarea in realizadas)
            {
                horasTrabajadas += tarea.Duracion;
            }

            Console.WriteLine($"El trabajador completó {horasTrabajadas} horas de trabajo.");
        }

        // Función que muestra el menú principal de opciones
        public static void MostrarMenu()
        {
            Console.WriteLine("\n======= MENÚ PRINCIPAL =======");
            Console.WriteLine("1. Ver tareas pendientes y realizadas");
            Console.WriteLine("2. Mover tarea de pendiente a realizada");
            Console.WriteLine("3. Buscar tarea por descripción");
            Console.WriteLine("4. Contar horas de trabajo realizadas");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
        }
    }
}

