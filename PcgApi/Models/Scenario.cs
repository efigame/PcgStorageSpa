using System.Runtime.Serialization;

namespace PcgApi.Models
{
    [DataContract]
    public class Scenario
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Index { get; set; }
        [DataMember]
        public bool Completed { get; set; }

        internal Scenario(DataAccess.Dto.Scenario scenario)
        {
            Id = scenario.Id;
            Name = scenario.Name;
            Index = scenario.Index;
        }
    }
}