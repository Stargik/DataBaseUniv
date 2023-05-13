using System.ComponentModel.DataAnnotations;

namespace DataBaseUniv.ViewModels
{
    public class QuerySearchModel
    {
        public int? CourceCount { get; set; }
        public string LevelStatus { get; set; }
        public int? TaskCount { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
