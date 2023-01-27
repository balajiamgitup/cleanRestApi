using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Domain
{
    public class orderStatus
    {
        [KeyAttribute()]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid statusId { get; set; }
        public string statusName { get; set; }

        public IEnumerable<order> Walks { get; set; }

    }
}
