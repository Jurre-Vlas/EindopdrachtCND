namespace Eindopdrachtcnd2.Data.Entities
{
    public class CardTaskUser
    {
        public int CardTaskId { get; set; }
        public CardTask CardTask { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}