// Definimos el espacio de nombres para mantener todo organizado
namespace CalculadoraHistorial
{
    // Esta clase representa una operación matemática realizada en la calculadora
    public class Operacion
    {
        private double resultadoAnterior; // Guarda el valor que había antes de esta operación
        private double nuevoValor;        // Valor con el que se realiza la operación
        private TipoOperacion operacion; // Tipo de operación (suma, resta, etc.)

        // Constructor: inicializa los valores de una operación
        public Operacion(double anterior, double nuevo, TipoOperacion tipo)
        {
            resultadoAnterior = anterior;
            nuevoValor = nuevo;
            operacion = tipo;
        }

        // Propiedad pública que devuelve el resultado de esta operación
        public double Resultado
        {
            get
            {
                // Calculamos el resultado según el tipo de operación
                switch (operacion)
                {
                    case TipoOperacion.Suma:
                        return resultadoAnterior + nuevoValor;
                    case TipoOperacion.Resta:
                        return resultadoAnterior - nuevoValor;
                    case TipoOperacion.Multiplicacion:
                        return resultadoAnterior * nuevoValor;
                    case TipoOperacion.Division:
                        return nuevoValor != 0 ? resultadoAnterior / nuevoValor : 0;
                    case TipoOperacion.Limpiar:
                        return 0;
                    default:
                        return resultadoAnterior;
                }
            }
        }

        // Propiedad para acceder al nuevo valor utilizado en la operación
        public double NuevoValor
        {
            get { return nuevoValor; }
        }

        // Propiedad para conocer el tipo de operación
        public TipoOperacion Tipo
        {
            get { return operacion; }
        }

        // Este método sirve para mostrar la operación en forma de texto
        public override string ToString()
        {
            return $"{resultadoAnterior} {SimboloOperacion()} {nuevoValor} = {Resultado}";
        }

        // Método privado que devuelve el símbolo correspondiente al tipo de operación
        private string SimboloOperacion()
        {
            switch (operacion)
            {
                case TipoOperacion.Suma: return "+";
                case TipoOperacion.Resta: return "-";
                case TipoOperacion.Multiplicacion: return "*";
                case TipoOperacion.Division: return "/";
                case TipoOperacion.Limpiar: return "LIMPIAR";
                default: return "?";
            }
        }

        // Enumeración para definir los distintos tipos de operación posibles
        public enum TipoOperacion
        {
            Suma,
            Resta,
            Multiplicacion,
            Division,
            Limpiar // Representa una operación que reinicia el valor actual
        }
    }
}
