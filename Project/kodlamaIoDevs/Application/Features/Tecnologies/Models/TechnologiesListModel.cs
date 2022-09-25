using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Tecnologies.Dtos;

namespace Application.Features.Tecnologies.Models
{
    public class TechnologiesListModel : BasePageableModel
    {
        public IList<TechnologiesListDto> Items { get; set; }
    }
}
