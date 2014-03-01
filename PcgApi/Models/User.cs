using DataAccess.Dto;
using System.Runtime.Serialization;

namespace PcgApi.Models
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }

        internal User()
        {
        }
        internal User(PcgUser pcgUser)
        {
            Id = pcgUser.Id;
            Email = pcgUser.Email;
        }
    }
}