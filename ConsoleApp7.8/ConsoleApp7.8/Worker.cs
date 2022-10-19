namespace ConsoleApp7._8
{
    struct Worker
    {
        #region Поля структуры

        /// <summary>
        /// ID 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        public DateTime NowDateTime { get; set; }
        /// <summary>
        /// Ф.И.О.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// Рост
        /// </summary>
        public float Growth { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateOnly DateBirth { get; set; }
        /// <summary>
        /// Место рождения
        /// </summary>
        public string BirthPlace { get; set; }

        #endregion

        #region Создание структуры
        /// <summary>
        /// Создание структуры
        /// </summary>
        /// <param name="_id">ID</param>
        /// <param name="dateTime">Дата и время добавления записи</param>
        /// <param name="name">Ф.И.О.</param>
        /// <param name="age">Возраст</param>
        /// <param name="growth">Рост</param>
        /// <param name="dateBirth">Дата рождения</param>
        /// <param name="birthPlace">Место рождения</param>
        public Worker(int _id, DateTime dateTime, string name, int age, float growth, DateOnly dateBirth, string birthPlace)
        {
            this.Id = _id;
            this.NowDateTime = dateTime;
            this.Name = name;
            this.Age = age;
            this.Growth = growth;
            this.DateBirth = dateBirth;
            this.BirthPlace = birthPlace;
        }
        #endregion
    }
}
