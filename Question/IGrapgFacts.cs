namespace Expert_System_2.Question
{
    public interface IGrapgFacts
    {
        /// <summary>
        /// Возрощаемое значение
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Название категории
        /// </summary>
        public string Category_Name { get; set; }
        /// <summary>
        /// Задаваемый вопрос
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Список возможных значений
        /// </summary>
        public List<string> Value_list { get; set; }
        /// <summary>
        /// Задать вопрос
        /// </summary>
        public string Ask_Question();

    }
}
