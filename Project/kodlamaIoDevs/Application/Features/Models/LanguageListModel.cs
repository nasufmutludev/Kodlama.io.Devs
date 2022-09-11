using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Models
{
    public class LanguageListModel:BasePageableModel
    {
        public IList<LanguageListDto> Items { get; set; }
    }
}
