using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Blog.Extensions
{
    public static class ModelStateExtension
    {
        public static List<string> GetErros(this ModelStateDictionary modelState) 
        {
            var result = new List<string>();
                foreach (var item in modelState.Values) 
            {
                //Faz o mesmo que o AddRange
                //foreach (var error in item.Errors) 
                //{
                //  result.Add(error.ErrorMessage);  
                //}

                result.AddRange(item.Errors.Select(error => error.ErrorMessage));
            }
        return result;
        }
    }
}
