using System;


namespace TodoDomain.Models
{
    public class Todo
    {
        private readonly string _id;
        private readonly DateTime _createdAt;


        public string Id { get { return this._id; } }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool IsCompleted { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreatedAt { get { return this._createdAt; } }
        public DateTime UpdatedAt { get; private set; }


        public Todo(string id, string title, string description, bool isCompleted, bool isDeleted,
            DateTime createdAt, DateTime updatedAt)
        {
            this._id = id;
            this.Title = title;
            this.Description = description;
            this.IsCompleted = isCompleted;
            this.IsDeleted = isDeleted;
            this._createdAt = createdAt;
            this.UpdatedAt = updatedAt;
        }


        public void updateTitle(string title)
        {
            this.EnsureNotDeleted();

            if (title == null || string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("title is required");

            this.Title = title.Trim();
            this.UpdateUpdatedAt();
        }

        public void updateDescription(string description)
        {
            this.EnsureNotDeleted();

            if (description == null)
                description = string.Empty;

            this.Description = description.Trim();
            this.UpdateUpdatedAt();
        }

        public void MarkAsCompleted()
        {
            this.EnsureNotDeleted();

            this.IsCompleted = true;
            this.UpdateUpdatedAt();
        }

        public void MarkAsDeleted()
        {
            if (this.IsDeleted)
                return;

            this.IsDeleted = true;
            this.UpdateUpdatedAt();
        }


        private void EnsureNotDeleted()
        {
            if (this.IsDeleted)
                throw new InvalidOperationException("Cannot modify deleted entity");
        }

        private void UpdateUpdatedAt()
        {
            this.UpdatedAt = DateTime.UtcNow;
        }
    }
}