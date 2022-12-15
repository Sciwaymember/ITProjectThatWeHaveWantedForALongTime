using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transleader.LibraryServer.DataAccessL.Types;

namespace Transleader.LibraryServer.DataAccessL.Models
{
    public class BookCompact
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Uid Id { get; set; }

        public int? ParentId { get; set; }

        public string? CoverPicture { get; set; }

        public string? Title { get; set; }

        public string? Author { get; set; }

        public Source Source { get; set; }
    }
}
