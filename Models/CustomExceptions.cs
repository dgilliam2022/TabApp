namespace CustomExceptions;


public class NotANumber : Exception
{
    public NotANumber() { }
    public NotANumber(string message) : base(message) { }
    public NotANumber(string message, System.Exception inner) : base(message, inner) { }
    protected NotANumber(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}

public class LikeDoesNotExist : Exception
{
    public LikeDoesNotExist() { }
    public LikeDoesNotExist(string message) : base(message) { }
    public LikeDoesNotExist(string message, System.Exception inner) : base(message, inner) { }
    protected LikeDoesNotExist(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
