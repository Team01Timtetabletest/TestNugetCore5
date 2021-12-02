using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User /*: IdentityUser<int>*/
    {
        public string AvatarURL { set; get; }
        //public int PermissionId { set; get; }
        //public Permission Permission { set; get; }
        public byte[] RowVersion { get; set; }
        public bool Status { set; get; }
        public DateTimeOffset CreatedDate { get; set; }
        public int CreatedByUserId { get; set; }
        public string CreatedByUserName { set; get; }
        public DateTimeOffset UpdatedDate { get; set; }
        public int UpdatedByUserId { get; set; }
        public string UpdatedByUserName { set; get; }
        public string NetResetCode { set; get; }
        public string ResetCode { set; get; }
        public string UniqueId { get; set; }
       /* public Lecturer Lecturer { get; set; }*/
        public int? LecturerId { get; set; }
    }
}
