using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Technologies : Entity
    {
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public virtual Language? Language { get; set; }

        public Technologies()
        {

        }

        public Technologies(int id, int languageId, string name) : this()
        {
            Id=id;
            LanguageId=languageId;
            Name=name;
        }
    }
}
