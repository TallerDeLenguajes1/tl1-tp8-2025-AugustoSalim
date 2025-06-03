using Lista;

    // Listas de tareas pendientes y realizadas
    var tareasPendientes = new List<Tarea>();
    var tareasRealizadas = new List<Tarea>();

    // Precargar algunas tareas en la lista de pendientes usando Add
    tareasPendientes.Add(new Tarea(1, "Revisar inventario", 15));
    tareasPendientes.Add(new Tarea(2, "Limpieza de oficina", 20));
    tareasPendientes.Add(new Tarea(3, "Entrega de pedidos", 30));
    tareasPendientes.Add(new Tarea(4, "Reunión con cliente", 25));
    tareasPendientes.Add(new Tarea(5, "Organizar documentos", 10));

  // Interacción con el usuario
        int opcion = 0;

        // Bucle para asegurar que el usuario ingrese una opción válida
        while (opcion != 5)
        {
            Console.Clear();
            GestorDeTareas.MostrarMenu(); // Mostrar el menú

            // Leer la opción del usuario
            string choice = Console.ReadLine();
            bool esNumeroEleccion = int.TryParse(choice, out opcion);

            // Si la opción es válida, ejecutamos el switch
            if (!esNumeroEleccion || opcion < 1 || opcion > 5)
            {
                Console.WriteLine("Por favor, ingrese una opción válida entre 1 y 5.");
                continue; // Si la opción es incorrecta, volvemos a mostrar el menú
            }

            // Dependiendo de la opción, ejecutamos la acción correspondiente
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
                Console.WriteLine("Saliendo del sistema...");
                break;
            default:
                Console.WriteLine("Opción no válida.");
                break;
        }

        if (opcion != 5)
        {
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
    }
