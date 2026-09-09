namespace Sufficit.Logging
{
    /// <summary>
    ///    Json log with diverged class name and content type
    /// </summary>
    /// <typeparam name="TClass"></typeparam>
    /// <typeparam name="TContent"></typeparam>
    public class GenericLogDiverged<TClass, TContent> : GenericLog<TContent>
    {
        public new string ClassName { get => base.ClassName; }

        public GenericLogDiverged()
        {
            base.ClassName = typeof(TClass).FullName ?? typeof(TClass).ToString();
        }
    }
}
