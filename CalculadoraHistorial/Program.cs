// Definimos el mismo namespace para mantener todo organizado y coherente
namespace CalculadoraHistorial
{
    // Clase principal para probar la Calculadora y el historial de operaciones
    class Program
    {
        // Método principal que se ejecuta al iniciar el programa
        static void Main()
        {
            // Creamos una instancia de la calculadora, el objeto que hará las operaciones
            Calculadora calc = new Calculadora();

            // Aplicamos algunas operaciones básicas y guardamos en el historial
            calc.AplicarOperacion(10, Operacion.TipoOperacion.Suma);
            // Resultado actual: 0 + 10 = 10

            calc.AplicarOperacion(5, Operacion.TipoOperacion.Resta);
            // Resultado actual: 10 - 5 = 5

            calc.AplicarOperacion(3, Operacion.TipoOperacion.Multiplicacion);
            // Resultado actual: 5 * 3 = 15

            calc.AplicarOperacion(5, Operacion.TipoOperacion.Division);
            // Resultado actual: 15 / 5 = 3

            // Mostramos el resultado final en pantalla
            System.Console.WriteLine($"Resultado final: {calc.ObtenerResultado()}");
            // Resultado final: 3

            // Ahora recorremos el historial y mostramos cada operación realizada
            foreach (Operacion op in calc.ObtenerHistorial())
            {
                // Llamamos al método ToString() que devuelve la operación en texto legible
                System.Console.WriteLine(op.ToString());
            }

            // Finalmente, limpiamos la calculadora (resultado = 0 y registro de historial)
            calc.Limpiar();

            // Verificamos que el resultado quedó en 0
            System.Console.WriteLine($"Resultado tras limpiar: {calc.ObtenerResultado()}");
            // Resultado tras limpiar: 0
        }
    }
}
