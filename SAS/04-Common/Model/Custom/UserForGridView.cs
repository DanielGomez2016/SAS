using System.Collections;
using System.Collections.Generic;

namespace Model.Custom
{
    public class UserForGridView
    {
        public string Id { get; set; }
        public int Idm { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public List<string> Roles { get; set; }
    }
}
