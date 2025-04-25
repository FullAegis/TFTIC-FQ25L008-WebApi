namespace BookManager.API.Models.DTO
{
    public class LivreDTO
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public int Annee { get; set; }
        public int NbrePage { get; set; }
        public string Auteur { get; set; }
        public int UtilisateurId { get; set; }
    }
}
