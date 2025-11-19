namespace EstiloLibreFront.Objetos.Usuarios
{
    public partial class UsuarioSaveDataDTO
    {
        public Dtos.UsuarioDTO Usuario { get; set; }
        public IEnumerable<int>? LstPermisosAsignadosIds { get; set; }
        public IEnumerable<int>? LstGruposAsignadosIds { get; set; }
    }
}
