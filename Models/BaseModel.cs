namespace Transport.ly.Models
{
    using System;

    [Serializable]
    public class BaseModel
    {
        public Guid InstanceId { get; set; } = Guid.NewGuid();

        public ModelStatus ModelStatus { get; set; } = ModelStatus.Enable;

        public override string ToString()
            => $"InstanceId: {this.InstanceId} - ModelStatus: {this.ModelStatus}";
    }
}