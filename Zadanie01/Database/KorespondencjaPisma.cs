namespace Zadanie01.Database
{
    public class KorespondencjaPisma
    {
        public long Id { get; set; }

        public string IdKorespondencja { get; set; }
        public Korespondencja Korespondencja { get; set; }

        public string IdPismo { get; set; }
        public Pismo Pismo { get; set; }
    }
}