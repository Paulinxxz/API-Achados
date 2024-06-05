namespace Api.Models
{
    public class ObservacoesModel
    {
        public int ObservacoesId { get; set; }

        public string ObservacaoDescricao { get; set; } = string.Empty;

        public string ObservacaoLocal { get; set; } = string.Empty;

        public DateTime ObservacaoData { get; set; }

        public int AnimalId { get; set; }

        public int UsuarioId { get; set; }
        
        public static implicit operator List<object>(ObservacoesModel v)
        {
            throw new NotImplementedException();
        }
    }
}
