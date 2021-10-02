namespace Login.Infrastructure.ApplicationExceptions
{
    public class ExceptionMessage
    {
        public static readonly string AddUserException =
            $"ExceptionCode={ExceptionCode.AddUserDbFailed}, Add user in db failed";
    }
}
