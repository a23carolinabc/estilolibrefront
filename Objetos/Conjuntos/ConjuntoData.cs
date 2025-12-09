using EstiloLibreFront.Utils;

namespace EstiloLibreFront.Objetos.Conjuntos
{
    public class ConjuntoData
    {
        public ConjuntoDTO? Conjunto { get; set; }
        public IEnumerable<ControlItem> Ocasiones { get; set; }
        public IEnumerable<ControlItem> Estaciones { get; set; }
        public IEnumerable<ControlItem> Estilos { get; set; }
        public IEnumerable<ControlItem> Colores { get; set; }
    }
}
