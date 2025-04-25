using BookManager.API.Models.DTO;
using BookManager.BLL.Models;

namespace BookManager.API.Mappers
{
    public static class Mapper
    {
        #region Livres
        public static LivreDTO ToDTO (this Livre entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new LivreDTO()
            {
                Id = entity.Id,
                Titre = entity.Titre,
                Auteur = entity.Auteur,
                Annee = entity.Annee,
                NbrePage = entity.NbrePage,
                UtilisateurId = entity.UtilisateurId
            };
        }

        public static Livre ToBLL(this CreateLivreDTO entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new Livre()
            {
                Titre = entity.Titre,
                Auteur = entity.Auteur,
                Annee = entity.Annee,
                NbrePage = entity.NbrePage,
                UtilisateurId = 1
            };
        }
        public static Livre ToBLL(this EditLivreDTO entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new Livre()
            {
                Titre = entity.Titre,
                Auteur = entity.Auteur,
                Annee = entity.Annee,
                NbrePage = entity.NbrePage,
                UtilisateurId = 1
            };
        }
        #endregion
    }
}
