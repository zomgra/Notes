namespace Notes.Domain
{
    public class Note
    {
        /// <summary>
        /// Ключ заметки
        /// </summary>
        public int NoteId { get; set; }
        /// <summary>
        /// Заголовок заметки
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Описание заметки
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Дата создания заметки
        /// </summary>
        public DateTime DateCreation { get; set; }
        /// <summary>
        /// Время последнего изменения заметки
        /// </summary>
        public DateTime LastChangeDate { get; set; } = DateTime.UtcNow;
        public void ChangeDate()
        {
            LastChangeDate = DateTime.UtcNow;
        }
    }
}
