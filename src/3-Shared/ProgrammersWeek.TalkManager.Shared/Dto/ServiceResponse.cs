namespace ProgrammersWeek.TalkManager.Shared.Dto
{
    public class ServiceResponse<T>
    {
        public T? Response { get; set; }
        public bool IsSuccessful { get; set; } = true;
        public string ErrorMessage { get; set; } = string.Empty;

        public bool IsValid() => IsSuccessful && Response != null;
    }
}
