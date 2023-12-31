namespace Blog.ViewsModels
{
    public class ResultViewModel<T>
    {
        public ResultViewModel(T data, List<string> errors)
        {
            Data = data;
            Erros = errors;
        }

        public ResultViewModel(T data)
        {
            Data = data;  
        }

        public ResultViewModel(List<string> erros)
        {
            Erros = erros; 
        }

        public ResultViewModel(string erro)
        {
            Erros.Add(erro);
        }

        public T Data { get; private set; }
        public List<string> Erros { get; private set; } = new(); //o mesmo que inicializar no construtor, o C# entende o tipo
    }
}
