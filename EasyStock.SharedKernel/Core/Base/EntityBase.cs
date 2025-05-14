namespace EasyStock.SharedKernel.Core.Base
{
    public interface IEntityBase
    {
        Guid Id { get; }
        bool Active { get; }
        DateTime CreatedDate { get; }
        DateTime LastUpdate { get; }

        void SetToActive();
        void SetToInactive();
        void SetActive(bool active);
        void SetCreatedDateToNow();
        void SetLastUpdateToNow();
        void SetCreatedDate(DateTime createdDate);
        void SetLastUpdate(DateTime lastUpdate);

        public void SetNewEntity();
    }

    public class EntityBase : IEntityBase
    {
        public Guid Id { get; protected set; }
        public bool Active { get; protected set; }
        public DateTime CreatedDate { get; protected set; }
        public DateTime LastUpdate { get; protected set; }

        public void SetToActive() => Active = true;
        public void SetToInactive() => Active = false;
        public void SetActive(bool active) => Active = active;
        public void SetCreatedDateToNow() => CreatedDate = DateTime.Now;
        public void SetLastUpdateToNow() => LastUpdate = DateTime.Now;
        public void SetCreatedDate(DateTime createdDate) => CreatedDate = createdDate;
        public void SetLastUpdate(DateTime lastUpdate) => LastUpdate = lastUpdate;

        public void SetNewEntity()
        {
            SetCreatedDateToNow();
            SetLastUpdateToNow();
            SetToActive();
        }
    }
}
