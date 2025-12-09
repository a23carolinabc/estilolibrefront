using System.Text.Json;

namespace EstiloLibreFront.Objetos.Conjuntos
{
    public class Canvas
    {
        public class PrendaConImagenDTO
        {
            public int Id { get; set; }
            public string? ImagenBase64 { get; set; }
            public string? NombreCategoria { get; set; }
            public string? NombreColor { get; set; }
        }
        public class PrendaEnCanvas
        {
            public int PrendaId { get; set; }
            public string? ImagenBase64 { get; set; }
            public double X { get; set; }
            public double Y { get; set; }
            public double Ancho { get; set; }
            public double Alto { get; set; }
            public double Rotacion { get; set; }
            public int ZIndex { get; set; }
            public bool EstaSeleccionada { get; set; }

            public PrendaEnCanvas()
            {
                this.X = 0;
                this.Y = 0;
                this.Ancho = 150;
                this.Alto = 150;
                this.Rotacion = 0;
                this.ZIndex = 0;
                this.EstaSeleccionada = false;
            }
        }

        public class ComposicionCanvas
        {
            public double Ancho { get; set; }
            public double Alto { get; set; }
            public List<PrendaEnCanvas> Prendas { get; set; }

            public ComposicionCanvas()
            {
                this.Ancho = 800;
                this.Alto = 1000;
                this.Prendas = new List<PrendaEnCanvas>();
            }

            public string SerializarAJson()
            {
                string json;

                json = JsonSerializer.Serialize(this);
                return json;
            }

            public static ComposicionCanvas? DeserializarDesdeJson(string strJson)
            {
                ComposicionCanvas? composicion;

                if (string.IsNullOrWhiteSpace(strJson))
                {
                    return new ComposicionCanvas();
                }

                composicion = JsonSerializer.Deserialize<ComposicionCanvas>(strJson);
                return composicion ?? new ComposicionCanvas();
            }
        }
    }
}