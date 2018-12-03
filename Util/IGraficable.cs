
namespace PodaProject.Util
{
    /// <summary>
    /// Interfaz que permite representar a un objeto en forma de datos.
    /// Todo objeto que implemente esta interfaz podrá ser utilizado
    /// con la clase Disenio y renderizarse en forma de gráfica en la interfaz gráfica
    /// </summary>
    public interface IGraficable
    {
        /// <summary>
        /// Obtiene los datos necesarios para ser representados en una gráfica.
        /// Los datos que se consideran necesarios son dos valores: label y value
        /// donde label es la etiqueta a mostrarse y value el valor numérico 
        /// </summary>
        /// <returns>Un arreglo de dos elementos: [label, value]</returns>
        string[] GetDatosGrafica();
    }
}
