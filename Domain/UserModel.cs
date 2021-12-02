using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserModel 
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AvatarURL { get; set; }
        public bool Status { set; get; }
        public DateTimeOffset CreatedDate { get; set; }
        public string CreatedByUserName { set; get; }
        public DateTimeOffset UpdatedDate { get; set; }
        public string UpdatedByUserName { set; get; }
        public int? LecturerId { get; set; }
        public IList<string> Roles { get; set; }
        public string userId { get; set; }
    }
    
}
