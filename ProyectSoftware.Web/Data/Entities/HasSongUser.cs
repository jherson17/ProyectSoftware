namespace ProyectSoftware.Web.Data.Entities
{
    public class HasSongUser
    {
        public int IdSong { get; set; }
        public Song Song { get; set; }

        public int IdUser{ get; set; }
        public User User { get; set; }
    }
}
