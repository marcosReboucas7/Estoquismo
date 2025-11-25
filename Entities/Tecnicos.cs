namespace Estoquismo.Entities
{
    public class Tecnicos
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<Equipamentos>? Equipamentos { get; set; }
    }
}
