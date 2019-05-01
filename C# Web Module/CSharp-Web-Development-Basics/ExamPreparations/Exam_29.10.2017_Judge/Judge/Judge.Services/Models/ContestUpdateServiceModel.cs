namespace Judge.Services.Models
{
    using Judge.Common.AutoMapping;
    using Judge.Models;

    public class ContestUpdateServiceModel : IMapWith<Contest>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int UserId { get; set; }
    }
}
