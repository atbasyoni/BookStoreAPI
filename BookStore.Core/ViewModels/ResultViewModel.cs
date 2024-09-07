namespace BookStore.API.ViewModels
{
    public class ResultViewModel
    {
        public int StatusCode { get; set; }
        public dynamic Data { get; set; }
        public string Message { get; set; }

        public static ResultViewModel Sucess(dynamic data, string message = "success operation")
        {
            return new ResultViewModel
            {
                StatusCode = 200,
                Data = data,
                Message = message,
            };
        }

        public static ResultViewModel Faliure(string message = "invalid operation")
        {
            return new ResultViewModel
            {
                StatusCode = 400,
                Data = default,
                Message = message,
            };
        }
    }
}
