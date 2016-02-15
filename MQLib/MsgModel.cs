using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQLib
{
    public class MsgModel
    {
        public string id { get; set; }
        public string Name { get; set; }
        public MsgModel() { }
        public MsgModel(string _id, string _Name)
        {
            id = _id;
            Name = _Name;
        }
        public override string ToString()
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(Name)) return "";
            return string.Format("id--{0},Name--{1}", id, Name);
        }
    }
}
