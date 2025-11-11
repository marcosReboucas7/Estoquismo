namespace Estoquismo.Entities
{

    public enum TipoEquipamento
    {
        Ont,
        Roteador,
        Conector,
        Onu,
        Epi
    }
    public class Equipamentos
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public TipoEquipamento TipoEquipamento { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;


    }
}
