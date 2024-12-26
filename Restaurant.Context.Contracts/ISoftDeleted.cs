namespace Restaurant.Context.Contracts
{
    /// <summary>
    /// Мякое удаление
    /// </summary>
    public interface ISoftDeleted
    {
        public DateTimeOffset? Deleted {  get; set; }
    }
}
