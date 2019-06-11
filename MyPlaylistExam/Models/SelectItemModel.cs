using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlaylistExam.Models
{
    public class SelectItemModel
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public override string ToString()
        {
            return Value;
        }
    }
}
