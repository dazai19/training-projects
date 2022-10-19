namespace ConsoleApp7._8
{
    class Repository
    {
        private string fileName = "workers.txt";

        /// <summary>
        /// массив структур
        /// </summary>
        private Worker[] workers;

        public Worker this[int index]
        {
            get { return workers[index]; }
            set { workers[index] = value; }
        }

        public Repository(params Worker[] arr) { workers = arr; }

        /// <summary>
        /// Проверка на наличие файла
        /// </summary>
        public void CreateFileName()
        {
            if (File.Exists(fileName))
            {
                LoadWorker();
            }
            else
            {
                File.Create(fileName);
            }
        }

        /// <summary>
        /// Чтение файла для структуры
        /// </summary>
        public void LoadWorker()
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                int count = System.IO.File.ReadAllLines(fileName).Length;

                if (count > 0)
                {
                    workers = new Worker[count];
                    for (int i = 0; (line = sr.ReadLine()) != null; ++i)
                    {
                        string[] str = line.Split("#");

                        workers[i] = new Worker()
                        {
                            Id = int.Parse(str[0]),
                            NowDateTime = DateTime.Parse(str[1]),
                            Name = str[2],
                            Age = int.Parse(str[3]),
                            Growth = int.Parse(str[4]),
                            DateBirth = DateOnly.Parse(str[5]),
                            BirthPlace = str[6]
                        };
                    }
                }
                else
                {

                    Console.WriteLine("Фаил пустой!");
                }
                sr.Close();
            }
        }

        /// <summary>
        /// Добавление записей в фаил 
        /// </summary>
        public void FileWriter()
        {
            Console.WriteLine("Сколько записей хотите добавить?");
            int count = Int32.Parse(Console.ReadLine());
            int lineCount = 0, workerNum = 1;

            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    if (sr.Read() == '\n') lineCount++;
                }
                lineCount++;
            }

            workers = new Worker[count];
            for (int i = 0; i < workers.Length; i++)
            {
                Console.WriteLine($"Введите данные сотрудника No.{workerNum++}");

                workers[i].Id = lineCount++;

                workers[i].NowDateTime = DateTime.Now;

                Console.WriteLine("Введите ФИО = ");
                workers[i].Name = Console.ReadLine();

                Console.WriteLine("Введите рост = ");
                workers[i].Growth = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите дату рождения в формате гггг.мм.дд = ");
                workers[i].DateBirth = DateOnly.Parse(Console.ReadLine());

                Console.WriteLine("Введите место рождения = ");
                workers[i].BirthPlace = Console.ReadLine();

                TimeSpan interval = workers[i].NowDateTime - DateTime.Parse(workers[i].DateBirth.ToString());
                workers[i].Age = (new DateTime(1, 1, 1) + interval).Year - 1;
            }

            using (StreamWriter sw = new StreamWriter(fileName, true))
            {
                for (int i = 0; i < workers.Length; i++)
                {
                    string temp = String.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}",
                                            workers[i].Id,
                                            workers[i].NowDateTime,
                                            workers[i].Name,
                                            workers[i].Age,
                                            workers[i].Growth,
                                            workers[i].DateBirth,
                                            workers[i].BirthPlace);

                    sw.WriteLine(temp.Replace(", ", "#"));
                }
                sw.Close();
            }

            Console.Clear();
            Console.WriteLine("Данные сохранены");
            LoadWorker();
        }

        /// <summary>
        /// Вывод 1 записи 
        /// </summary>
        /// <param name="id">id workers</param>
        public void FileReaderByKey(int id)
        {
            for (int i = 0; i < workers.Length; i++)
            {
                if (workers[i].Id == id) Console.WriteLine(String.Format("{0} {1} {2} {3} {4} {5} {6}",
                                            workers[i].Id,
                                            workers[i].NowDateTime,
                                            workers[i].Name,
                                            workers[i].Age,
                                            workers[i].Growth,
                                            workers[i].DateBirth,
                                            workers[i].BirthPlace));
            }
        }

        /// <summary>
        /// Вывод всех записей
        /// </summary>
        public void ShowAllLines()
        {
            Console.WriteLine("ID | Дата и время записи | Ф.И.О | Возраст | Рост | День Рождения | Место Рождения\n");
            for (int i = 0; i < workers.Length; i++)
            {
                Console.WriteLine(String.Format("{0} {1} {2} {3} {4} {5} {6}",
                                            workers[i].Id,
                                            workers[i].NowDateTime,
                                            workers[i].Name,
                                            workers[i].Age,
                                            workers[i].Growth,
                                            workers[i].DateBirth,
                                            workers[i].BirthPlace));
            }
        }

        /// <summary>
        /// Сортировка
        /// </summary>
        public void OrderByWorker()
        {
            Console.WriteLine("Выберете столбец: \n1.ID\n2.Дата и время записи\n3.ФИО\n4.Возраст\n5.Рост\n6.Дата рождения\n7.Место рождения");
            int col = int.Parse(Console.ReadLine());
            bool sortOn = false;

            IEnumerable<Worker> w = new List<Worker>();

            switch (col)
            {
                case 1:
                    w = workers.OrderBy(Worker => Worker.Id);
                    sortOn = true;
                    break;
                case 2:
                    w = workers.OrderBy(Worker => Worker.NowDateTime);
                    sortOn = true;
                    break;
                case 3:
                    w = workers.OrderBy(Worker => Worker.Name);
                    sortOn = true;
                    break;
                case 4:
                    w = workers.OrderBy(Worker => Worker.Age);
                    sortOn = true;
                    break;
                case 5:
                    w = workers.OrderBy(Worker => Worker.Growth);
                    sortOn = true;
                    break;
                case 6:
                    w = workers.OrderBy(Worker => Worker.DateBirth);
                    sortOn = true;
                    break;
                case 7:
                    w = workers.OrderBy(Worker => Worker.BirthPlace);
                    sortOn = true;
                    break;

                default:
                    Console.WriteLine("Введите цифру от 1 до 7");
                    break;
            }

            if (sortOn)
            {
                foreach (Worker i in w)
                {
                    Console.WriteLine(String.Format("{0} {1} {2} {3} {4} {5} {6}",
                                            i.Id,
                                            i.NowDateTime,
                                            i.Name,
                                            i.Age,
                                            i.Growth,
                                            i.DateBirth,
                                            i.BirthPlace));
                }

                Console.WriteLine("Сохранить изменения? y/n");
                if(Console.ReadLine() == "y")
                {
                    using (StreamWriter sw = new StreamWriter(fileName, false))
                    {
                        foreach (Worker i in w)
                        {
                            sw.WriteLine(String.Format("{0}#{1}#{2}#{3}#{4}#{5}#{6}",
                                            i.Id,
                                            i.NowDateTime,
                                            i.Name,
                                            i.Age,
                                            i.Growth,
                                            i.DateBirth,
                                            i.BirthPlace));
                        }
                        sw.Close();
                    }
                    LoadWorker();
                }
            }
        }

        /// <summary>
        /// Удаление по ID
        /// </summary>
        /// <param name="id">id workers</param>
        public void DelitedLineByKey(int id)
        {
            bool save = false;
            string[] lines = File.ReadAllLines(fileName);

            for (int i = 0; i < lines.Length; i++)
            {
                string n = lines[i].Substring(0, lines[i].IndexOf("#"));
                if (int.Parse(n) == id)
                {
                    save = true;
                    lines[i] = "";
                }
            }
            if (save)
            {
                using (StreamWriter sw = new StreamWriter(fileName, false))
                {
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i] == "") continue;
                        sw.WriteLine(lines[i]);
                    }
                    sw.Close();
                }
                Console.WriteLine("Запись удалена");
                LoadWorker();
            }
            else
            {
                Console.WriteLine("введенный ID не найден!");
            }
        }

        /// <summary>
        /// Вывод записей в диапазоне дат
        /// </summary>
        public void ShowLineDate()
        {
            Console.WriteLine($"Вывод дат в формате С гггг.мм.дд чч:мм:сс ПО гггг.мм.дд чч:мм:сс");
            Console.Write("C = ");
            DateTime beginDate = DateTime.Parse(Console.ReadLine());
            Console.Write("ПО = ");
            DateTime endDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine($"\nПоиск с {beginDate} по {endDate} : ");

            for (int i = 0; i < workers.Length; i++)
            {
                if (workers[i].NowDateTime > beginDate && workers[i].NowDateTime < endDate) 
                    Console.WriteLine(String.Format("{0} {1} {2} {3} {4} {5} {6}",
                                            workers[i].Id,
                                            workers[i].NowDateTime,
                                            workers[i].Name,
                                            workers[i].Age,
                                            workers[i].Growth,
                                            workers[i].DateBirth,
                                            workers[i].BirthPlace));
            }
        }



        public void ShowText()
        {
            Console.WriteLine("1) считать фаил\n2) записать в фаил\n3) просмотр записи по ID" +
                "\n4) сортировка по столбцу\n5) удаление по ID\n6) поиск в диапазоне дат");
        }
    }
}
