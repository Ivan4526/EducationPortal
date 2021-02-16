public struct Result
{
    public bool Succeeded { get; set; }

    public string Error { get; set; }

    public static Result Failed(string error) => new Result
    {
        Succeeded = false,
        Error = error
    };

    public static Result Success => new Result { Succeeded = true };
}