using System.ComponentModel.DataAnnotations;

namespace EstiloLibreFront.Objetos.Prendas
{
    public class PrendaDTO
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string RutaFoto { get; set; }
        
        [Required(ErrorMessage = "El color es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un color")]
        public int ColorId { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una categoría")]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un estado")]
        public int EstadoId { get; set; }

        [Required(ErrorMessage = "La talla es obligatoria")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una talla")]
        public int TallaId { get; set; }

        [Required(ErrorMessage = "El material es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un material")]
        public int MaterialId { get; set; }

        public int MarcaId { get; set; }
        public int EstacionId { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser mayor o igual a 0")]
        public decimal Precio { get; set; }

        [Url(ErrorMessage = "Debe ser una URL válida")]
        public string? EnlaceCompra { get; set; }

        public DateTime? FechaCompra { get; set; }

        [Required(ErrorMessage = "Debe subir una foto")]
        public string FotoBase64 { get; set; } = string.Empty;
    
}
}
