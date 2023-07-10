namespace Expert_System_2.Question
{
    public class Selection_Question : IGrapgFacts
    {
        public string Value { get; set; }
        public string Category_Name { get; set; }
        public string Description { get; set; }
        public List<string> Value_list { get; set; }


        public Selection_Question(string category_name, string description, List<string> value_list)
        {
            Category_Name = category_name;
            Description = description;
            Value_list = value_list;
        }
        public Selection_Question(string value, string category_name, string description, List<string> value_list)
        {
            Value = value;
            Category_Name = category_name;
            Description = description;
            Value_list = value_list;
        }

        public string Ask_Question()
        {
            string? nambur_value;
            Console.WriteLine(Description);
            Console.WriteLine("Выберите один из предложенных вариантов:");
            int a = 1;
            for (int i = 0; i < Value_list.Count; i++)
            {
                Console.Write(a++ + " - ");
                Console.Write(Value_list[i]);
                Console.WriteLine();
            }
            Console.Write("Ведите порядковый номер: ");
            nambur_value = Console.ReadLine();
            Console.WriteLine();
            Value = Value_list[Convert.ToInt32(nambur_value) - 1];
            if (Value != null)
                return Value;
            else return String.Empty;
        }
    }
}
