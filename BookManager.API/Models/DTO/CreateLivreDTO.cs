namespace BookManager.API.Models.DTO
{
    public class CreateLivreDTO
    {
        public string Titre { get; set; }
        public int Annee { get; set; }
        public int NbrePage { get; set; }
        public string Auteur { get; set; }
    }
}
