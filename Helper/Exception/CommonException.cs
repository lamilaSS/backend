namespace mcq_backend.Helper.Exception
{
    public class CommonException : System.Exception
    {
        public string Code { get; set; }


        public CommonException(string message = null) : base(message)
        {
            Code = "ERR";
        }

        public CommonException(string code, string message = "") : base(message)
        {
            Code = code;
        }
    }

    public class CommonExceptionDataset
    {
        public CommonExceptionDataset(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public CommonExceptionDataset(CommonException e)
        {
            Code = e.Code;
            Message = e.Message;
        }

        public string Code { get; set; }
        public string Message { get; set; }
    }
}