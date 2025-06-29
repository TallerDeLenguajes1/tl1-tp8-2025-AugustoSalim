namespace CalculadoraHistorial
{
    // Clase principal que realiza cálculos y guarda historial de operaciones
    public class Calculadora
    {
        private double resultadoActual; // Guarda el valor actual acumulado
        private List<Operacion> historial; // Lista con todas las operaciones realizadas

        // Constructor: inicia el resultado en cero y la lista vacía
        public Calculadora()
        {
            resultadoActual = 0;
            historial = new List<Operacion>();
        }

        // Método para aplicar una operación sobre el resultado actual
        public void AplicarOperacion(double valor, Operacion.TipoOperacion tipo)
        {
            // Creamos una nueva operación con los valores actuales
            Operacion op = new Operacion(resultadoActual, valor, tipo);

            // Agregamos la operación al historial usando .Add()
            historial.Add(op);

            // Actualizamos el resultado con el nuevo valor calculado
            resultadoActual = op.Resultado;
        }

        // Método para limpiar la calculadora (resetear resultado e historial)
        public void Limpiar()
        {
            AplicarOperacion(0, Operacion.TipoOperacion.Limpiar);
        }

        // Método para obtener el resultado actual
        public double ObtenerResultado()
        {
            return resultadoActual;
        }

        // Método para obtener el historial completo
        public List<Operacion> ObtenerHistorial()
        {
            // Devolvemos una copia de la lista para proteger los datos internos
            return new List<Operacion>(historial);
        }
    }
}
