using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace la_mia_pizzeria_static.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La mail e' obbligatoria")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Il nome deve essere presente.")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Il titolo del messaggio e' obbligatorio.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Il corpo del messaggio e' obblicatorio.")]
        public string Text { get; set; }

    }
}
