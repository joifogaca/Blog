using System.ComponentModel.DataAnnotations;

namespace Blog.ViewsModels.Accounts
{
    public class UploadViewModel
    {
        [Required(ErrorMessage = "Imagem Inválida")]
        public string Base64Image { get; set; }
    }
}
