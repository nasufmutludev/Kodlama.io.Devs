using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Tecnologies.Dtos
{
    public class CreatedTechnologiesCommandDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LanguageId { get; set; }
    }
}
