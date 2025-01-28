using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace workshop.wwwapi.ViewModels
{
    public class GetDoctor
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
}
